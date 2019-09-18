using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFunc;
using Communication;
using Fram.Config;
using Fram.Hardware.IoCard;
using Fram.Hardware.MotionCard;
using Communication;
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
                            if (mem.Communicate.CommunicationType == Config.CommunicatioinType.TcpClient)
                            {
                                TcpClientConfig Config = (TcpClientConfig)mem.Communicate;
                                TcpClientCommunicate tcpClient = new TcpClientCommunicate(Config.LocalIpAddress, Config.LocalPort, Config.RemoteIpAddress, Config.RemotePort);
                                EMC0064 eMC0064 = new EMC0064(tcpClient, mem.Guid, mem.DeviceName, mem.InputCount, mem.OutputCount);                               
                                m_IoCards.Add(mem.DeviceName, eMC0064);
                            }
                            else
                            {
                                SerialPortConfig config=(SerialPortConfig)mem.Communicate;
                                SerialCommunicate serialCommunicate = new SerialCommunicate(config.PortName, config.BaudRate, config.DataBits, config.Parity, config.StopBits, config.NewLine);
                                EMC0064 eMC0064 = new EMC0064(serialCommunicate, mem.Guid, mem.DeviceName, mem.InputCount, mem.OutputCount); 
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
