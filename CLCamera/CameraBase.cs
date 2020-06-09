using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
namespace CLCamera
{
   public  class CameraBase
    {
        public  bool m_IsConnected;
        public string m_Cameraname=string .Empty;
        public string m_IpAddress=string.Empty;
        public CameraConnectType m_CameraConnectType;
        protected  readonly object m_lock = new object();
        public CameraBase(string cameraname, CameraConnectType cameraconnecttype)
        {
            this.m_Cameraname = cameraname;
            this.m_CameraConnectType = cameraconnecttype;
        }
        /// <summary>
        /// 连接相机
        /// </summary>
        /// <returns></returns>
        public virtual void OpenCamera() { }
      
        /// <summary>
        /// 关闭相机
        /// </summary>
        public virtual void CloseCamera() { }
      
        /// <summary>
        /// 单次取像
        /// </summary>
        public virtual HObject  SnapShot() { return new HObject(); }
       
        /// <summary>
        /// 设置曝光时间
        /// </summary>
        /// <param name="t"></param>
        public virtual void SetExpourseTime(uint t) { }
        public virtual uint GetExpourseTime() { return 0; }
        /// <summary>
        /// 设置相机增益
        /// </summary>
        /// <param name="g"></param>
        public virtual void SetGain(uint g) { }
        public virtual uint GetGain() { return 0; }
        
    }
   public  enum CameraConnectType
    {
        GigEVision2,//
        USB3Vision,//
        DirectShow//
    }
    public enum CameraType
    {
        HaiKangCamera,
        HalconCamera,
        PylonCamera,
    }
    public enum ImageType
    {
        HObject,
        BMP,
    }
}
