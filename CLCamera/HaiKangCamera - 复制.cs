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
     class HaiKangCamer:CameraBase
    {
        public string Mac = string.Empty;
        CameraOperator m_pOperator;
        
        MyCamera.MV_CC_DEVICE_INFO_LIST m_pDeviceList;
        MyCamera.cbOutputdelegate ImageCallback;
        MyCamera.cbExceptiondelegate ExceptionCallback;
        private MyCamera m_pMyCamera;

        public  event EventHandler<ImageEventArgs<HObject>> ImageAcquired;
        public HaiKangCamer(string cameraname, CameraConnectType cameraconnecttype): base(cameraname, cameraconnecttype)
        {
            m_pDeviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
            m_pOperator = new CameraOperator();       
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
            m_pOperator.Close();      
        }
        public override HObject SnapShot()
        {
            lock (m_lock)
            {
                HObject _image = new HObject();
                try
                {
                    UInt32 nPayloadSize=0;
                   int nRet =m_pOperator.GetIntValue("PayloadSize", ref nPayloadSize);
                    
                    if (MyCamera.MV_OK != nRet)
                    {
                        throw new Exception("Get PayloadSize failed");                        
                    }
                    IntPtr pBufForDriver = Marshal.AllocHGlobal((int)nPayloadSize);
                    MyCamera.MV_FRAME_OUT_INFO_EX FrameInfo = new MyCamera.MV_FRAME_OUT_INFO_EX();
                    uint pndatalen = 0;

                    m_pOperator.SetEnumValue("TriggerMode", 0);
                    m_pOperator.StartGrabbing();
                    Thread.Sleep(100);
                    m_pOperator.GetOneFrame(pBufForDriver, ref  pndatalen, nPayloadSize,ref FrameInfo);
                    int k = 0;
                    m_pOperator.StopGrabbing();
                        
                }
                catch (Exception ex)
                {

                }
                return _image;
            }
                
        }
        //public override void SnapShot<object>(ref object image)
        //{
        //    int nRet;

        //    //触发命令
        //    nRet = m_pOperator.CommandExecute("TriggerSoftware");

        //    if (CameraOperator.CO_OK != nRet)
        //    {
        //        throw new Exception(m_Cameraname+"取像失败");
        //    }
        //}
        public override void SetExpourseTime(uint t)
        {
            m_pOperator.SetFloatValue("ExposureTime", t);
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
            m_pOperator.SetFloatValue("Gain", g);
        }
        public override uint GetGain()
        {
            uint _gain = 0;

            return _gain;
        }
        public void SetTriggerMode(string mode)
        {
            m_pOperator.SetEnumValue("TriggerMode", 0);
            if (mode == "Off")
                m_pOperator.SetEnumValue("TriggerSource", 7);
            else if (mode == "On")
                m_pOperator.SetEnumValue("TriggerSource", 0);
            m_pOperator.StartGrabbing();
        }
        public void InitCamera(string ID)
        {
            int numberID = -1;
            
            MyCamera.MV_CC_DEVICE_INFO device;
            try
            {
                int nRet = -1;
                CameraOperator.EnumDevices(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref m_pDeviceList);
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
                
                nRet = m_pOperator.Open(ref device);
                if (MyCamera.MV_OK != nRet)
                {
                    throw new Exception("");
                    
                }
                
                // ch:探测网络最佳包大小(只对GigE相机有效) | en:Detection network optimal package size(It only works for the GigE camera)
                if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    MyCamera m_pMyCamera = new MyCamera();
                    nRet = m_pMyCamera.MV_CC_CreateDevice_NET(ref device);
                    if (MyCamera.MV_OK != nRet)
                    {
                        return;
                    }
                    int nPacketSize = m_pMyCamera.MV_CC_GetOptimalPacketSize_NET();
                    if (nPacketSize > 0)
                    {
                        nRet = m_pMyCamera.MV_CC_SetIntValue_NET("GevSCPSPacketSize", (uint)nPacketSize);
                        if (nRet != MyCamera.MV_OK)
                        {
                            throw new Exception(string.Format("Warning:{1} Get Packet Size failed {0:x8}", nPacketSize, m_Cameraname));
                        }
                    }
                    //else
                    //{
                    //    throw new Exception(string.Format("Warning:{1} Get Packet Size failed {0:x8}", nPacketSize, m_Cameraname));

                    //}
                }
                //设置采集连续模式
                m_pOperator.SetEnumValue("AcquisitionMode", 2);
                m_pOperator.SetEnumValue("TriggerMode", 1);
                //m_pOperator.SetPixelFormatValue(0);

                ImageCallback = new MyCamera.cbOutputdelegate(ImageOut);
                m_pOperator.RegisterImageCallBack(ImageCallback, IntPtr.Zero);
                ExceptionCallback = new MyCamera.cbExceptiondelegate(Exception);
                m_pOperator.RegisterExceptionCallBack(ExceptionCallback, IntPtr.Zero);
            }
            catch (Exception ex)
            {
                throw new Exception(ID + "初始化失败：" + ex.Message);
            }
        }
        private void Exception(uint param1, IntPtr param2)
        {
            throw new Exception("123");
        }
        private void ImageOut(IntPtr pixelPointer, ref MyCamera.MV_FRAME_OUT_INFO pFrameInfo, IntPtr pUser)
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
}
