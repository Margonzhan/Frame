using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
namespace Connection
{
    public class ComConnect
    {    
        public delegate void PortDateReceiveEventHandle(object sender,PortEventArgs e);
        public event PortDateReceiveEventHandle PortDateReceiveEvent;
        private SerialPort m_port;
        private  string m_portname=null,m_NewLine=null;
        private int m_BaudRate, m_DateBits;
        private Parity m_parity;
        private StopBits m_stopbit;
        private int m_ReadBuffSize, m_WriteBuffSize, m_OutTime;
       public  enum NewLine
        {
            CR,
            LF,
            CRLF,
        }
        public ComConnect(string PortName, int BaudRate, int DateBits, Parity parity, StopBits StopBit, NewLine newline= NewLine.LF, int readbuffsize = 2048, int writebuffsize = 2028,int outtime=1000)
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
                case NewLine.CR:
                    m_NewLine="\r";
                    break;
                case NewLine.LF:
                    m_NewLine="\n";
                    break;
                case NewLine.CRLF:
                    m_NewLine="\r\n";
                    break;
                default:
                    m_NewLine = "\n";
                    break;
            }
           
           
        }

        private  void m_port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            PortEventArgs ea = new PortEventArgs();

            
            int bytes = 0;
            bytes = m_port.BytesToRead;
            Thread.Sleep(20);
            bytes = m_port.BytesToRead;

            byte[] buffer = new byte[bytes];
            m_port.Read(buffer, 0, bytes);
            ea.bytes = bytes;
            ea.buffer = buffer.Take(bytes).ToArray();
            OnPublishEvent(ea);
        }
        private void OnPublishEvent(PortEventArgs e)
        {
            if (e != null)
            {
                PortDateReceiveEvent(this, e);
            }
        
        }
        public bool OpenSerialPort()
        {
            if (m_port == null)
            {
                m_port = new SerialPort();
            }
            if (!m_port.IsOpen)
            {
                m_port.PortName = m_portname;
                m_port.BaudRate = m_BaudRate;
                m_port.DataBits = m_DateBits;
                m_port.Parity = m_parity;
                m_port.StopBits = m_stopbit;
                m_port.NewLine = m_NewLine;
                m_port.ReadBufferSize = m_ReadBuffSize;
                m_port.WriteBufferSize = m_WriteBuffSize;
                m_port.ReadTimeout = m_port.WriteTimeout = m_OutTime;
                m_port.Open();
                m_port.DataReceived += m_port_DataReceived;
            }

            return m_port.IsOpen;
        }
        public bool SendString(string str )
        {
            if (m_port.IsOpen)
            {
                m_port.Write(str);
                return true;
            }
            return false;
        }
        public bool SendData(Byte[] data,int length)
        {
            if (m_port.IsOpen)
            {
                m_port.Write(data, 0, length); 
                return true;
            }
            return false;
        }
        public int ReadLineString(out string str)
        {
            if (m_port.IsOpen)
            {
                str = m_port.ReadLine();
              return str.Length;
            }
            str = null;
            return 0;
        }
        public int ReadBytes(byte[] data,int length)
        {
            if (m_port.IsOpen)
            {
                int n = m_port.Read(data, 0, length);
                return n;
            }
            return 0;
        }
        public void Close()
        {
            if (m_port.IsOpen)
            {
                m_port.Close();
                m_port.Dispose();
                m_port = null;
            }
        }
        
    }
    public class PortEventArgs:EventArgs
    {
      public   byte[] buffer = new byte[2048];
       public int bytes;
    }
}
