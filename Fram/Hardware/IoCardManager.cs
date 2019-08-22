using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFunc;
using Fram.Config;
using Fram.Hardware.IoCard;
using Fram.Hardware.MotionCard;
namespace Fram.Hardware
{
  public   class IoCardManager:Singleton<IoCardManager>
    {
        Dictionary<string, IIoCard> m_IoCards = new Dictionary<string, IIoCard>();
       public  IoCardManager()
        {
            foreach(var mem in ConfigManager.Instance.HardWareConfigrationMuster.IoCardConfigs)
            {
               IoCardBrand _iocardbrand;
                if (!mem.Enable)
                    continue;
                if (m_IoCards.ContainsKey(mem.DeviceName))
                {
                    //show error info in this place
                    continue;
                }
                bool ismotioncard = false;
                foreach(var motionCard in ConfigManager.Instance.HardWareConfigrationMuster.MotionCardConfigs)
                {
                    if(mem.Guid==motionCard.Guid)
                    {
                        ismotioncard = true;
                        MotionCard.MotionCardBase _motionCard = (MotionCard.MotionCardBase)Hardware.MotionCardManager.Instance.GetByKey(motionCard.DeviceName);
                        m_IoCards.Add(mem.DeviceName, _motionCard);
                        break;
                        
                    }
                }
                if (ismotioncard)
                    continue;
               if( Enum.TryParse<IoCardBrand>(mem.IoCardBrand,out _iocardbrand))
                {
                    switch(_iocardbrand)
                    {
                        case IoCardBrand.ZMotion_EMC0064:
                            if (mem.ConnectType == IoCardConnectType.EtherNet.ToString())
                            {
                                EMC0064 eMC0064 = new EMC0064(IoCardConnectType.EtherNet, mem.IpAddress, mem.Port, mem.Guid, mem.DeviceName, mem.InputCount, mem.OutputCount); ;
                                m_IoCards.Add(mem.DeviceName, eMC0064);
                            }
                            else
                            {
                                System.IO.Ports.StopBits _stopBits;
                                if(!Enum.TryParse<System.IO.Ports.StopBits>(mem.StopBits, out _stopBits))
                                {
                                    // log the error info
                                    continue;
                                }
                                System.IO.Ports.Parity _parity;
                                if(!Enum.TryParse<System.IO.Ports.Parity>(mem.Parity, out _parity))
                                {
                                    // log the error info
                                    continue;
                                }
                                EMC0064 eMC0064 = new EMC0064(IoCardConnectType.SerialPort,mem.COM,mem.BaudRate, _stopBits, _parity, mem.DataBits, mem.Guid, mem.DeviceName, mem.InputCount, mem.OutputCount); ;
                                m_IoCards.Add(mem.DeviceName, eMC0064);
                            }
                           
                            
                            
                            break;
                    }
                }
            }
        }
        public void Add(string key, IoCardBase value)
        {
            if (m_IoCards.ContainsKey(key))
            {
                throw new Exception($"the keyname {key} is already exist");
            }
            m_IoCards.Add(key, value);
        }
        public void Remove(string key)
        {
            if (!m_IoCards.ContainsKey(key))
            {
                throw new Exception($"the keyname {key} is not found ");
            }
            m_IoCards.Remove(key);
        }
        public IIoCard GetByKey(string key)
        {
            return m_IoCards[key];
        }
        public Dictionary<string, IIoCard> IoCards
        {
            get { return m_IoCards; }
        }
    }
}
