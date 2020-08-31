using CommonFunc;
using Fram.Config;
using Fram.Hardware.AxisDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Hardware.LogicAxisUnite
{
   public  class LogicAxisUnitManager:Singleton<LogicAxisUnitManager>
    {
        Dictionary<string, LogicAxisUnit> m_LogicAxisUnits = new Dictionary<string, LogicAxisUnit>();
        public LogicAxisUnitManager()
        {
            foreach (var mem in ConfigManager.Instance.HardWareConfigrationMuster.LogicAxisUnitConfigs)
            {
                if (!mem.Enable)
                    continue;

                if (m_LogicAxisUnits.ContainsKey(mem.DeviceName))
                {
                    //show error info in this place
                    continue;
                }
                LogicAxisUnit logicAxisUnit = new LogicAxisUnit(mem.DeviceName,mem.Guid);
                
                foreach (var logicAxisConfig in mem.LogicAxisConfigs)
                {
                    foreach(var axis in AxisManager.Instance.AxisDeviceS)
                    {
                        if(logicAxisConfig.BindDeviceGuid==axis.Value.Guid)
                        {
                         
                            LogicAxis logicAxis = new LogicAxis(logicAxisConfig.DeviceName, logicAxisConfig.Guid, (StepMotor)axis.Value, logicAxisConfig.IsHome, logicAxisConfig.HomeIndex);
                            logicAxisUnit.AddLogicAxis(logicAxis.DeviceName, logicAxis);
                            break;
                        }
                    }                   
                }
                if(logicAxisUnit.AxisDeviceS.Count>0)
                    m_LogicAxisUnits.Add(logicAxisUnit.DeviceName, logicAxisUnit);
            }
        }

        public void Add(string key, LogicAxisUnit value)
        {
            if (m_LogicAxisUnits.ContainsKey(key))
            {
                throw new Exception($"the keyname {key} is already exist");
            }
            m_LogicAxisUnits.Add(key, value);
        }
        public void Remove(string key)
        {
            if (!m_LogicAxisUnits.ContainsKey(key))
            {
                throw new Exception($"the keyname {key} is not found ");
            }
            m_LogicAxisUnits.Remove(key);
        }
        public LogicAxisUnit GetByKey(string key)
        {
            return m_LogicAxisUnits[key];
        }
        public Dictionary<string, LogicAxisUnit> LogicAxisUnitS
        {
            get { return m_LogicAxisUnits; }
        }

    }
}
