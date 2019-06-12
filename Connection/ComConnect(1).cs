using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Connection
{
    public class ComConnect
    {
       
        public SerialPort port;
        public string m_portname=null,m_NewLine=null;
        public int m_BaudRate, m_DateBits;
        public Parity m_parity;
        public StopBits m_stopbit;
        public int m_ReadBuffSize, m_WriteBuffSize,m_OutTime;
        public ComConnect(string PortName, int BaudRate, int DateBits, Parity parity, StopBits StopBit, string newline, int readbuffsize = 2048, int writebuffsize = 2028,int outtime=1000)
        {
            
            m_portname = PortName;
            m_BaudRate = BaudRate;
            m_DateBits = DateBits;
            m_parity = parity;
            m_stopbit = StopBit;
            m_ReadBuffSize = readbuffsize;
            m_WriteBuffSize = writebuffsize;
            m_OutTime = outtime;
            switch (newline)
            { 
                case null:
                    m_NewLine = "";
                    break;
                case "CR":
                    m_NewLine="\r";
                    break;
                case "LF":
                    m_NewLine="\n";
                    break;
                case "CRLF":
                    m_NewLine="\r\n";
                    break;
                default:
                    m_NewLine = "";
                    break;
            }
           
        }
        public bool OpenSerialPort()
        {
            if (port==null)
            {
                port = new SerialPort();
            }
            if (!port.IsOpen)
            {
                port.PortName = m_portname;
                port.BaudRate = m_BaudRate;
                port.DataBits = m_DateBits;
                port.Parity = m_parity;
                port.StopBits = m_stopbit;
                port.NewLine = m_NewLine;
                port.ReadBufferSize = m_ReadBuffSize;
                port.WriteBufferSize = m_WriteBuffSize;
                port.ReadTimeout = port.WriteTimeout=m_OutTime;
                port.Open();
            }

            return port.IsOpen;
        }
        public bool SendString(string str )
        {
            if (port.IsOpen)
            {
                port.Write(str);
                return true;
            }
            return false;
        }
        public bool SendData(Byte[] data,int length)
        {
            if (port.IsOpen)
            {
                port.Write(data, 0, length); 
                return true;
            }
            return false;
        }
        public int ReadLineString(out string str)
        {
            
            if (port.IsOpen)
            {
              str= port.ReadLine();
              return str.Length;
            }
            str = null;
            return 0;
        }
        public int ReadBytes(byte[] data,int length)
        {
            if (port.IsOpen)
            {
               int n= port.Read(data, 0, length);
                return n;
            }
            return 0;
        }
        public void Close()
        {
            if (port.IsOpen)
            {
                port.Close();
                port.Dispose();
                port = null;
            }
        }
    }
}
