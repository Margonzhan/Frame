using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Config
{
    public class IoCardConfig : ConfigBase
    {
        private IoCardBrand m_ioCardBrand;
        public string IoCardBrand
        {
            get { return m_ioCardBrand.ToString(); }
            set
            {
                if(!Enum.TryParse<IoCardBrand>(value, out m_ioCardBrand))
                {
                    throw new InvalidCastException($"{IoCardBrand} {value} change to System.IO.Ports.Parity Exception");

                }
            }
        }
        private IoCardConnectType m_ioCardConnectType;
        public string ConnectType
        {
            get { return m_ioCardConnectType.ToString(); }
            set
            {
               if(! Enum.TryParse<IoCardConnectType>(value, out m_ioCardConnectType))
                {
                    throw new InvalidCastException($"{ConnectType} {value} change to System.IO.Ports.Parity Exception");
                }
            }
        }
        public string COM { get; set; }
        public int BaudRate { get; set; }
        public int DataBits { get; set; }

        System.IO.Ports.StopBits m_stopBits;
        public string  StopBits
        {
            get { return m_stopBits.ToString(); }
            set
            {
                
                if(value !=null)
                {
                    if (!Enum.TryParse<System.IO.Ports.StopBits>(value, out m_stopBits))
                    {
                        throw new InvalidCastException($"{DeviceName} {value} change to System.IO.Ports.StopBits Exception");
                    }
                }
               
            }
        }
        private System.IO.Ports.Parity m_parity;
        public string Parity
        {
            get { return m_parity.ToString(); }
            set
            {
                if(value!=null)
                {
                    if(!Enum.TryParse<System.IO.Ports.Parity>(value,out m_parity))
                    {
                        throw new InvalidCastException($"{DeviceName} {value} change to System.IO.Ports.Parity Exception");

                    }
                }

            }
        }



        public int InputCount { get; set; }
        public int OutputCount { get; set; }
    }
    /// <summary>
    /// 硬件连接方式
    /// SerialPort:串口
    /// EtherNet:网口
    /// </summary>
    public enum IoCardConnectType
    {
        SerialPort,
        EtherNet,
    }
    public enum IoCardBrand
    {
        ZMotion_ECI0064,
    }
}
