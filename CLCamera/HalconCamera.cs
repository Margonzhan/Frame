using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
namespace CLCamera
{
   public  class HalconCamera:CameraBase
    {
        private HTuple m_CameraHandle;
        event EventHandler<ImageEventArgs<HObject>> ImageEvent;
       
        public HalconCamera(string cameraname,CameraConnectType cameraconnecttype)
        {
          this.m_Cameraname = cameraname;
          this.m_CameraConnectType = cameraconnecttype;
        }
        
        public override void OpenCamera()
        {
            try
            {
                if (m_CameraHandle != null)
                {
                    return;
                }
                string cameratype = m_CameraConnectType.ToString();
                HOperatorSet.OpenFramegrabber(cameratype, 0, 0, 0, 0, 0, 0, "progressive", -1,
        "default", -1, "false", "default", m_Cameraname, 0, -1, out m_CameraHandle);
                this.m_IsConnected = true;               
            }
            catch (Exception ex)
            {
                m_IsConnected = false;
                throw new Exception("打开相机异常：" + m_Cameraname+"\r\n"+ex.Message);
               
            }
        }

       
        public override void CloseCamera()
        {
            if (m_CameraHandle != null)
            {
                try
                {
                    HOperatorSet.CloseFramegrabber(m_CameraHandle);
                }
                catch (Exception ex)
                {
                    throw new Exception("关闭相机异常：" + m_Cameraname + "\r\n" + ex.Message);
                }
            }
        }
        public override void SnapShot()
        {
            if (m_CameraHandle != null)
            {
                try
                {
                    HObject image=new HObject();
                    HOperatorSet.GrabImageAsync(out image, m_CameraHandle, -1);
                    ImageEventArgs<HObject> e = new ImageEventArgs<HObject>();
                    e.image = image.Clone();
                    OnImageEvent(e);
                }
                catch (Exception ex)
                {
                    throw new Exception("取像异常：" + m_Cameraname + "\r\n" + ex.Message);
                }
            }
            else
            {
                throw new Exception("相机未连接：" + m_Cameraname );
            }

        }
        private void OnImageEvent(ImageEventArgs<HObject> e)
        {
            if (e != null)
            {
                ImageEvent(this, e);
            }
        }
        public override void SetExpourseTime(int t)
        { 
             if (m_CameraHandle != null)
            {
                try
                {
                    HOperatorSet.SetFramegrabberParam(m_CameraHandle, "ExposureTime", t);
                }
                catch (Exception ex)
                {
                    throw new Exception("设置曝光时间异常：" + m_Cameraname);
                }
            }
             else
             {
                 throw new Exception("相机未连接：" + m_Cameraname);
             }
        }
        public override void  SetGain(int g)
        {
            if (m_CameraHandle != null)
            {
                try
                {
                    HOperatorSet.SetFramegrabberParam(m_CameraHandle, "Gain", g);
                }
                catch (Exception ex)
                {
                    throw new Exception("设置增益异常：" + m_Cameraname);
                }
            }
            else
            {
                throw new Exception("相机未连接：" + m_Cameraname);
            }
        }
    }
   public  class ImageEventArgs<T> : EventArgs
    {
        public  T image;
    }
}
