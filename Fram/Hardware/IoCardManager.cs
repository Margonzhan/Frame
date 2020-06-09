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
  public sealed class IoCardManager:Singleton<IoCardManager>
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
                        IIoCard _motionCard = (IIoCard)Hardware.MotionCardManager.Instance.GetByKey(motionCard.DeviceName);
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
                            bool isfind = false;
                            foreach(var serialInfo in ConfigManager.Instance.HardWareConfigrationMuster.SerialPortConfigs)
                            {
                                if(serialInfo.BindGuid==mem.Guid)
                                {
                                    EMC0064 eMC0064 = new EMC0064( mem.Guid, mem.DeviceName, mem.InputCount, mem.OutputCount,serialInfo.PortName);
                                    m_IoCards.Add(mem.DeviceName, eMC0064);
                                    isfind = true;
                                    break;
                                }
                            }
                            if(!isfind)
                            {
                                foreach (var tcpInfo in ConfigManager.Instance.HardWareConfigrationMuster.TcpClientConfigs)
                                {
                                    if (tcpInfo.BindGuid == mem.Guid)
                                    {
                                        EMC0064 eMC0064 = new EMC0064( mem.Guid, mem.DeviceName, mem.InputCount, mem.OutputCount,tcpInfo.LocalIpAddress);
                                        m_IoCards.Add(mem.DeviceName, eMC0064);
                                        isfind = true;
                                        break;
                                    }
                                }
                            }
                            if(!isfind)
                            {
                                throw new Exception($"未找到与 ZMotion_EMC0064 {mem.DeviceName } 相对应的通讯配置文件");
                            }
                            isfind = false;
                            break;
                        case IoCardBrand.SerialIOCardTest:
                            foreach (var serialInfo in ConfigManager.Instance.HardWareConfigrationMuster.SerialPortConfigs)
                            {
                                if (serialInfo.BindGuid == mem.Guid)
                                {
                                    SerialIOCardTest serialIOCardTest = new SerialIOCardTest( mem.Guid, mem.DeviceName, mem.InputCount, mem.OutputCount);
                                    m_IoCards.Add(mem.DeviceName, serialIOCardTest);                                  
                                    break;
                                }
                            }
                            break;
                        case IoCardBrand.NLK_IOCard_16:
                            foreach (var serialInfo in ConfigManager.Instance.HardWareConfigrationMuster.SerialPortConfigs)
                            {
                                if (serialInfo.BindGuid == mem.Guid)
                                {
                                    NLK_IOCard_16 iocard = new NLK_IOCard_16(mem.Guid, mem.DeviceName, mem.InputCount, mem.OutputCount,serialInfo.CardIndex, serialInfo.PortName,serialInfo.BaudRate,serialInfo.StopBits,serialInfo.Parity,serialInfo.NewLine);

                                    if(iocard.Open())
                                         m_IoCards.Add(mem.DeviceName, iocard);
                                    iocard.StartWorking();
                                    break;
                                }
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
