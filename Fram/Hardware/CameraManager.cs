using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFunc;
using Fram.Config;
using CLCamera;
namespace Fram.Hardware
{
   public  class CameraManager : Singleton<CameraManager>
    {
        Dictionary<string, CameraBase> m_cameras = new Dictionary<string, CameraBase>();

        public CameraManager()
        {
            foreach(var mem in ConfigManager.Instance.HardWareConfigrationMuster.CameraConfigs)
            {
                if (!mem.Enable)
                    continue;
                if(!Enum.TryParse< CameraType >(mem.CameraType,out CameraType cameraType))
                {
                    ///log the error info
                    continue;
                }
                if (!Enum.TryParse<CameraConnectType>(mem.CameraConnectType, out CameraConnectType cameraConnectType))
                {
                    ///log the error info
                    continue;
                }
                CameraBase camera=null;
                switch(cameraType)
                {
                    case CameraType.HaiKangCamera:
                        camera = new HaiKangCamera(mem.DeviceName, cameraConnectType);
                        
                        break;
                    case CameraType.HalconCamera:
                        camera = new HalconCamera(mem.DeviceName, cameraConnectType);
                        break;
                    case CameraType.PylonCamera:
                        camera=new PylonCamera(mem.DeviceName, cameraConnectType);
                        break;
                    default:
                        break;
                }
                try
                {
                    camera.OpenCamera();
                }
                catch(Exception ex)
                {
                    ///log the error info
                    continue;
                }
                
                m_cameras.Add(mem.DeviceName,camera);
            }
        }
        public void Add(string key, CameraBase value)
        {
            if (m_cameras.ContainsKey(key))
            {
                throw new Exception($"the keyname {key} is already exist");
            }
            m_cameras.Add(key, value);
        }
        public void Remove(string key)
        {
            if (!m_cameras.ContainsKey(key))
            {
                throw new Exception($"the keyname {key} is not found ");
            }
            m_cameras.Remove(key);
        }
        public CameraBase GetByKey(string key)
        {
            return m_cameras[key];
        }
        public Dictionary<string, CameraBase> Cameras
        {
            get { return m_cameras; }
        }
    }
}
