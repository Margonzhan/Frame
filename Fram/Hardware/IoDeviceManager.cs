using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFunc;
using Fram.Config;

namespace Fram.Hardware
{
   public sealed class IoDeviceManager:Singleton<IoDeviceManager>
    {
        Dictionary<string, IOBaseDevice.SingleIoDevice> m_IoDevices = new Dictionary<string, IOBaseDevice.SingleIoDevice>();
        public IoDeviceManager()
        {
            foreach(var mem in ConfigManager.Instance.HardWareConfigrationMuster.SingleIoDeviceConfigs)
            {
                if (!mem.Enable)
                    continue;
                IOBaseDevice.SingleIoDevice singleIoDevice;
                if (m_IoDevices.ContainsKey(mem.DeviceName))
                {
                    //show error info in this place
                    continue;
                }
                foreach(var iocard in IoCardManager.Instance.IoCards)
                {
                    HardwareBase hardwareBase = (HardwareBase)iocard.Value;
                    if(hardwareBase.Guid==mem.BindDeviceGuid)
                    {
                       singleIoDevice = new IOBaseDevice.SingleIoDevice(iocard.Value, mem.IsInput, mem.IoIndex, mem.DeviceName, mem.Guid);                                                        
                        m_IoDevices.Add(mem.DeviceName, singleIoDevice);
                    }
                }
                
            }
        }

        public void Add(string key,IOBaseDevice.SingleIoDevice value)
        {
            if(m_IoDevices.ContainsKey(key))
            {
                throw new Exception($"the keyname {key} is already exist");
            }
            m_IoDevices.Add(key, value);
        }
        public void Remove(string key)
        {
            if (!m_IoDevices.ContainsKey(key))
            {
                throw new Exception($"the keyname {key} is not found ");
            }
            m_IoDevices.Remove(key);
        }
        public IOBaseDevice.SingleIoDevice GetByKey(string key)
        {
            return m_IoDevices[key];
        }
        public Dictionary<string, IOBaseDevice.SingleIoDevice> IODeviceS
        {
            get { return m_IoDevices; }
        }
    }
}
