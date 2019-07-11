using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using Basler.Pylon;
using System.Runtime.InteropServices;
namespace CLCamera
{
   public  class PylonCamera:CameraBase
    {
        Basler.Pylon.Camera camera = null;
        public PylonCamera(string cameraname, CameraConnectType cameraconnecttype):base(cameraname, cameraconnecttype)
        {
           
        }
        public override void OpenCamera()
        {
            List<ICameraInfo> allCameras = CameraFinder.Enumerate();           
            foreach (ICameraInfo cameraInfo in allCameras)
            {
                if (this.m_Cameraname == cameraInfo[CameraInfoKey.UserDefinedName])
                {
                    camera = new Camera(cameraInfo);
                    if (!camera.Open(1000, TimeoutHandling.Return))
                    {
                        throw new Exception($"faile to open the camera{this.m_Cameraname}");                     
                    }
                    return;
                }
            }
            throw new Exception($"cannot find the camera named as{this.m_Cameraname}");
        }
        public override void CloseCamera()
        {
            if(camera!=null)
            {
                camera.Close();
            }
        }
        public override HObject SnapShot()
        {
            HObject _image = new HObject();
            try
            {
                IGrabResult grabResult = camera.StreamGrabber.GrabOne(1000, TimeoutHandling.ThrowException);
                IntPtr dataaddress = Marshal.UnsafeAddrOfPinnedArrayElement((byte[])grabResult.PixelData, 0);
                HOperatorSet.GenImage1(out _image, "byte", grabResult.Width, grabResult.Height, dataaddress);
            }
            catch (Exception ex)
            {
                throw new Exception($"camera '{this.m_Cameraname}' Snap faild,{ex.Message}");
            }
            return _image;
        }
        public override void SetExpourseTime(uint t)
        {
            if (camera!=null)
            {
                if(camera.IsOpen)
                {
                    IFloatParameter parameter = null;

                    if (camera.Parameters.Contains(PLCamera.ExposureTimeAbs))
                    {
                        parameter = camera.Parameters[PLCamera.ExposureTimeAbs];
                    }
                    else
                    {
                        parameter = camera.Parameters[PLCamera.ExposureTime];
                    }
                    if (parameter.IsWritable)
                        parameter.SetValue(t);
                }
            }
        }
        public override void SetGain(uint g)
        {
            if (camera != null)
            {
                if (camera.IsOpen)
                {
                    IFloatParameter parameter = null;
                    if (camera.Parameters.Contains(PLCamera.GainAbs))
                    {
                        parameter = camera.Parameters[PLCamera.GainAbs];
                    }
                    else
                    {
                        parameter = camera.Parameters[PLCamera.Gain];
                    }
                    if (parameter.IsWritable)
                        parameter.SetValue(g);
                }
            }
        }
        public override uint GetExpourseTime()
        {
            uint _expourestime = 0;
            if (camera != null)
            {
                if (camera.IsOpen)
                {
                    IFloatParameter parameter = null;
                    if (camera.Parameters.Contains(PLCamera.ExposureTimeAbs))
                    {
                        parameter = camera.Parameters[PLCamera.ExposureTimeAbs];
                    }
                    else
                    {
                        parameter = camera.Parameters[PLCamera.ExposureTime];
                    }
                    if (parameter.IsReadable)
                        _expourestime = (uint)parameter.GetValue();
                }
            }
            return _expourestime;
        }
        public override uint GetGain()
        {
            uint _gain = 0;
            if (camera != null)
            {
                if (camera.IsOpen)
                {
                    IFloatParameter parameter = null;
                    if (camera.Parameters.Contains(PLCamera.GainAbs))
                    {
                        parameter = camera.Parameters[PLCamera.GainAbs];
                    }
                    else
                    {
                        parameter = camera.Parameters[PLCamera.Gain];
                    }
                    if (parameter.IsReadable)
                        _gain = (uint)parameter.GetValue();
                }
            }
            return _gain;
        }
    }
}
