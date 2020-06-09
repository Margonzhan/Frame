using CommonFunc;
using Fram.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Hardware
{
   public sealed class AxisManager: Singleton<AxisManager>
    {
        Dictionary<string, AxisDevice.Motor> m_AxisDevices = new Dictionary<string, AxisDevice.Motor>();
        public AxisManager()
        {
            foreach (var mem in ConfigManager.Instance.HardWareConfigrationMuster.AxisConfigs)
            {
                if (!mem.Enable)
                    continue;
                AxisDevice.Motor motor;
                if (m_AxisDevices.ContainsKey(mem.DeviceName))
                {
                    //show error info in this place
                    continue;
                }
                foreach (var motioncard in MotionCardManager.Instance.MotionCards)
                {
                    HardwareBase hardwareBase = (HardwareBase)motioncard.Value;
                    if (hardwareBase.Guid == mem.BindDeviceGuid)
                    {
                        motor = new AxisDevice.StepMotor(motioncard.Value, (uint)mem.AxisIndex, mem.DeviceName, mem.Guid);
                        m_AxisDevices.Add(mem.DeviceName, motor);
                    }
                }

            }
        }

        public void Add(string key, AxisDevice.Motor value)
        {
            if (m_AxisDevices.ContainsKey(key))
            {
                throw new Exception($"the keyname {key} is already exist");
            }
            m_AxisDevices.Add(key, value);
        }
        public void Remove(string key)
        {
            if (!m_AxisDevices.ContainsKey(key))
            {
                throw new Exception($"the keyname {key} is not found ");
            }
            m_AxisDevices.Remove(key);
        }
        public AxisDevice.Motor GetByKey(string key)
        {
            return m_AxisDevices[key];
        }
        public Dictionary<string, AxisDevice.Motor> AxisDeviceS
        {
            get { return m_AxisDevices; }
        }
    }
}
