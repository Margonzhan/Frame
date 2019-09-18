using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFunc;
using Fram.Hardware.MotionCard;
using Fram.Config;
namespace Fram.Hardware
{
   public  class MotionCardManager : Singleton<MotionCardManager>
    {
        Dictionary<string, MotionCardBase> m_motionCards = new Dictionary<string, MotionCardBase>();
        public MotionCardManager()
        {
            foreach (var mem in ConfigManager.Instance.HardWareConfigrationMuster.MotionCardConfigs)
            {
                MotionCardBrand _motioncardbrand;
                if (!mem.Enable)
                    continue;
                if (m_motionCards.ContainsKey(mem.DeviceName))
                {
                    //show error info in this place
                    continue;
                }              
                if (Enum.TryParse<MotionCardBrand>(mem.MotionCardBrand, out _motioncardbrand))
                {
                    switch (_motioncardbrand)
                    {
                        case MotionCardBrand.AdlinkAMP204c:
                            Adlink_Amp204c adlink_Amp204C = new Adlink_Amp204c(mem.DeviceName, mem.Guid);
                            adlink_Amp204C.LoadConfigFile(AppDomain.CurrentDomain.BaseDirectory + "param.xml");
                            m_motionCards.Add(mem.DeviceName, adlink_Amp204C);
                            break;
                    }
                }
            }
        }
        public void Add(string key, MotionCardBase value)
        {
            if (m_motionCards.ContainsKey(key))
            {
                throw new Exception($"the keyname {key} is already exist");
            }
            m_motionCards.Add(key, value);
        }
        public void Remove(string key)
        {
            if (!m_motionCards.ContainsKey(key))
            {
                throw new Exception($"the keyname {key} is not found ");
            }
            m_motionCards.Remove(key);
        }
        public MotionCardBase GetByKey(string key)
        {
            return m_motionCards[key];
        }
        public Dictionary<string, MotionCardBase> MotionCards
        {
            get { return m_motionCards; }
        }
    }
}
