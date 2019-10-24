using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvCamCtrl.NET;
using DeviceSource;
using System.Runtime.InteropServices;
using HalconDotNet;
using System.Threading;

namespace CLCamera
{
  public   class HaiKangCamera:CameraBase
    {
        public string Mac = string.Empty;
        
        
        MyCamera.MV_CC_DEVICE_INFO_LIST m_pDeviceList;
        MyCamera.cbOutputExdelegate ImageCallback;
        MyCamera.cbExceptiondelegate ExceptionCallback;
        private MyCamera m_pMyCamera;

        public  event EventHandler<ImageEventArgs<HObject>> ImageAcquired;
        public HaiKangCamera(string cameraname, CameraConnectType cameraconnecttype): base(cameraname, cameraconnecttype)
        {
            m_pDeviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
            
        }
        public override void OpenCamera()
        {
            try
            {
                InitCamera(m_Cameraname);
                this.m_IsConnected = true;
            }
            catch (Exception ex)
            {
                this.m_IsConnected = false;
                throw new Exception(m_Cameraname + "打开失败");
            }
        }
        public override void CloseCamera()
        {
          int nRet=  m_pMyCamera.MV_CC_CloseDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                throw new Exception($"close camera {m_Cameraname } failed");
            }
        }
        public void InitCamera(string ID)
        {
            int numberID = -1;
            int nRet = MyCamera.MV_OK;
            MyCamera.MV_CC_DEVICE_INFO device;
            try
            {

                nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref m_pDeviceList);
                for (int i = 0; i < m_pDeviceList.nDeviceNum; i++)
                {
                    device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_pDeviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                    if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                    {
                        IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stGigEInfo, 0);
                        MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                        if (gigeInfo.chUserDefinedName == ID)
                        {
                            Mac = gigeInfo.chSerialNumber;

                            numberID = i;
                            break;
                        }
                    }
                    else if (device.nTLayerType == MyCamera.MV_USB_DEVICE)
                    {
                        IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stUsb3VInfo, 0);
                        MyCamera.MV_USB3_DEVICE_INFO usbInfo = (MyCamera.MV_USB3_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                        if (usbInfo.chUserDefinedName == ID)
                        {
                            Mac = usbInfo.chSerialNumber;
                            numberID = i;
                            break;
                        }
                    }
                }
                device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_pDeviceList.pDeviceInfo[numberID], typeof(MyCamera.MV_CC_DEVICE_INFO));
                //打开设备
                if (null == m_pMyCamera)
                {
                    m_pMyCamera = new MyCamera();
                    if (null == m_pMyCamera)
                    {
                        return;
                    }
                }
                nRet = m_pMyCamera.MV_CC_CreateDevice_NET(ref device);
                if (MyCamera.MV_OK != nRet)
                {
                    throw new Exception($"failed to create camera {m_Cameraname}");
                }

                nRet = m_pMyCamera.MV_CC_OpenDevice_NET();
                if (MyCamera.MV_OK != nRet)
                {
                    m_pMyCamera.MV_CC_DestroyDevice_NET();
                    throw new Exception($"failed to open camera {m_Cameraname}");
                }
                // ch:探测网络最佳包大小(只对GigE相机有效) | en:Detection network optimal package size(It only works for the GigE camera)
                if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    int nPacketSize = m_pMyCamera.MV_CC_GetOptimalPacketSize_NET();
                    if (nPacketSize > 0)
                    {
                        nRet = m_pMyCamera.MV_CC_SetIntValue_NET("GevSCPSPacketSize", (uint)nPacketSize);
                        if (nRet != MyCamera.MV_OK)
                        {
                            throw new Exception("Warning: Set Packet Size failed");
                        }
                    }
                    else
                    {
                        throw new Exception("Warning: Get Packet Size failed");
                    }
                }
                // ch:设置采集连续模式 | en:Set Continues Aquisition Mode
                m_pMyCamera.MV_CC_SetEnumValue_NET("AcquisitionMode", 2);// ch:工作在连续模式 | en:Acquisition On Continuous Mode
                m_pMyCamera.MV_CC_SetEnumValue_NET("TriggerMode", 0);    // ch:连续模式 | en:Continuous
                m_pMyCamera.MV_CC_SetEnumValue_NET("TriggerSource", 7);//ch:触发源设为软触发 | en:Set trigger source as Software

                //ImageCallback = new MyCamera.cbOutputExdelegate(ImageOut);
                //nRet = m_pMyCamera.MV_CC_RegisterImageCallBackEx_NET(ImageCallback, IntPtr.Zero);
                //if (MyCamera.MV_OK != nRet)
                //{
                //    throw new Exception("Register image callback failed!");

                //}
                //ExceptionCallback = new MyCamera.cbExceptiondelegate(Exception);
                //nRet = m_pMyCamera.MV_CC_RegisterImageCallBackEx_NET(ImageCallback, IntPtr.Zero);
                //if (MyCamera.MV_OK != nRet)
                //{
                //    throw new Exception("Register image exception callback failed!");                   
                //}
                //开启抓图
                nRet = m_pMyCamera.MV_CC_StartGrabbing_NET();
                if (MyCamera.MV_OK != nRet)
                {
                    throw new Exception("Start grabbing failed");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ID + "初始化失败：" + ex.Message);
            }
        }
        public void SetTriggerMode(TriggerMode triggerMode)
        {
            m_pMyCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)triggerMode);
        }
        public void SetTriggerSource(TriggerSource triggerSource)
        {
            m_pMyCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)triggerSource);
        }
        public override HObject SnapShot()
        {
            lock (m_lock)
            {
                HObject _image = new HObject();
                try
                {
                    // ch:获取包大小 || en: Get Payload Size
                    MyCamera.MVCC_INTVALUE stParam = new MyCamera.MVCC_INTVALUE();
                    int nRet = m_pMyCamera.MV_CC_GetIntValue_NET("PayloadSize", ref stParam);
                    if (MyCamera.MV_OK != nRet)
                    {
                        Console.WriteLine("Get PayloadSize failed:{0:x8}", nRet);                      
                    }
                    UInt32 nPayloadSize = stParam.nCurValue;

                    int nCount = 0;
                    IntPtr pBufForDriver = Marshal.AllocHGlobal((int)nPayloadSize);
                    IntPtr pBufForSaveImage = IntPtr.Zero;

                    MyCamera.MV_FRAME_OUT_INFO_EX FrameInfo = new MyCamera.MV_FRAME_OUT_INFO_EX();
                    nRet = m_pMyCamera.MV_CC_GetOneFrameTimeout_NET(pBufForDriver, nPayloadSize, ref FrameInfo, 1000);
                    // ch:获取一帧图像 | en:Get one image
                    if (MyCamera.MV_OK == nRet)
                    {
                       return     GetImage(pBufForDriver, ref FrameInfo);
                    }


                }
                catch (Exception ex)
                {

                }
                return _image;
            }
                
        }    
        public override void SetExpourseTime(uint t)
        {
           int nRet= m_pMyCamera.MV_CC_SetFloatValue_NET("ExposureTime", t);
            if (MyCamera.MV_OK != nRet)
            {
                throw new Exception ($"camera {m_Cameraname}  set expourse time  failed");
            }
        }
        public override uint GetExpourseTime()
        {
            uint _expoursetime = 0;
            MyCamera.MVCC_FLOATVALUE stParam = new MyCamera.MVCC_FLOATVALUE();
            int nRet = m_pMyCamera.MV_CC_GetFloatValue_NET("ExposureTime", ref stParam);
            if (MyCamera.MV_OK == nRet)
            {
                _expoursetime= (uint)stParam.fCurValue;
            }
            return _expoursetime;
        }
        public override void SetGain(uint g)
        {
            int nRet = m_pMyCamera.MV_CC_SetFloatValue_NET("Gain", g);
            if (MyCamera.MV_OK != nRet)
            {
                throw new Exception($"camera {m_Cameraname}  set gain time  failed");
            }
        }
        public override uint GetGain()
        {
            uint _gain = 0;

            return _gain;
        }
       
        
        private void Exception(uint param1, IntPtr param2)
        {
            throw new Exception("123");
        }
        private HObject  GetImage(IntPtr pixelPointer, ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo)
        {
            HObject objImage = new HObject();
            // 原始数据转换
            int width = pFrameInfo.nWidth;
            int height = pFrameInfo.nHeight;
            if (pFrameInfo.enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8)
            {
                HOperatorSet.GenImage1(out objImage, "byte", width, height, pixelPointer);
            }
            else if (pFrameInfo.enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR8)
            {
                width = (width + 3) & 0xfffc;  //宽度补齐为4的倍数
                int nLength = width * height;
                byte[] dataBlue = new byte[nLength];
                byte[] dataGreen = new byte[nLength];
                byte[] dataRed = new byte[nLength];

                for (int row = 0; row < height; row++)
                {
                    //uint char* ptr = &pixelPointer[row * width * 3];
                    for (int col = 0; col < width; col++)
                    {
                        //dataBlue[row * width + col] = pixelPointer[3 * col];
                        //dataGreen[row * width + col] = pixelPointer[3 * col + 1];
                        //dataRed[row * width + col] = pixelPointer[3 * col + 2];
                    }
                }
                //objImage=new HImage("")
                //HOperatorSet.GenImage1(out objImage, "byte", width*3, height, pixelPointer);
                HOperatorSet.GenImageInterleaved(out objImage, pixelPointer, "rgb", width, height, -1, "byte", 0, 0, 0, 0, -1, 0);
            }
            return objImage;
        }
        private void ImageOut(IntPtr pixelPointer, ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo, IntPtr pUser)
        {
            HObject objImage = new HObject();
            // 原始数据转换
            int width = pFrameInfo.nWidth;
            int height = pFrameInfo.nHeight;
            if (pFrameInfo.enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8)
            {
                HOperatorSet.GenImage1(out objImage, "byte", width, height, pixelPointer);
            }
            else if (pFrameInfo.enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR8)
            {
                width = (width + 3) & 0xfffc;  //宽度补齐为4的倍数
                int nLength = width * height;
                byte[] dataBlue = new byte[nLength];
                byte[] dataGreen = new byte[nLength];
                byte[] dataRed = new byte[nLength];

                for (int row = 0; row < height; row++)
                {
                    //uint char* ptr = &pixelPointer[row * width * 3];
                    for (int col = 0; col < width; col++)
                    {
                        //dataBlue[row * width + col] = pixelPointer[3 * col];
                        //dataGreen[row * width + col] = pixelPointer[3 * col + 1];
                        //dataRed[row * width + col] = pixelPointer[3 * col + 2];
                    }
                }
                //objImage=new HImage("")
                //HOperatorSet.GenImage1(out objImage, "byte", width*3, height, pixelPointer);
                HOperatorSet.GenImageInterleaved(out objImage, pixelPointer, "rgb", width, height, -1, "byte", 0, 0, 0, 0, -1, 0);
            }
            ImageEventArgs<HObject> outEvent = new ImageEventArgs<HObject>();
            outEvent.image = objImage;
            
            OnNewImageAcquired(outEvent);

        }
          void OnNewImageAcquired(ImageEventArgs<HObject> e)
        {
            EventHandler<ImageEventArgs<HObject>> tempEvent = this.ImageAcquired;
            if (tempEvent != null)
            {
                tempEvent(this, e);
            }
        }

    }
    public enum TriggerMode
    {
        On=0,
        Off=1,
    }
    // ch:触发源选择:0 - Line0; | en:Trigger source select:0 - Line0;
    //           1 - Line1;
    //           2 - Line2;
    //           3 - Line3;
    //           4 - Counter;
    //           7 - Software;
    public enum TriggerSource
    {
        SoftVare=7,
        Line0=0,
        Line1=1,
        Line2=2,
        Line3=3,
        Counter=4,
    }
}
