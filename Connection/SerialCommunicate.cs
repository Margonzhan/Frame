using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Communication
{
    public class SerialCommunicate : BaseCommunicate,ISerialCommunicate
    {
        #region member variables
        SerialPort port;
        static readonly object  m_lock=new object();
        #endregion
        
        

        #region property
        string ISerialCommunicate.PortName
        {
            get { return port.PortName; }          
        }
        int ISerialCommunicate.BaudRate
        {
            get { return port.BaudRate; }         
        }
        Parity ISerialCommunicate.Parity
        {
            get { return port.Parity; }         
        }
        int ISerialCommunicate.DataBits
        {
            get { return port.DataBits; }
            
        }
        StopBits ISerialCommunicate.StopBits
        {
            get { return port.StopBits; }            
        }
        string ISerialCommunicate.NewLine
        {
            get {return  port.NewLine; }           
        }
        #endregion
        #region function
        public SerialCommunicate()
        {
            port = new SerialPort();
            CommunicationType = CommunicatioinType.SerialPort;
        }

        public SerialCommunicate(string portName, int baudRate, int dataBits = 8, Parity parity = Parity.None, StopBits stopBits = StopBits.One, string newline = "\n")
        {
            port = new SerialPort();
            CommunicationType = CommunicatioinType.SerialPort;
            
            port.PortName = portName;
            port.BaudRate = baudRate;
            port.DataBits = dataBits;
            port.Parity = parity;
            port.StopBits = stopBits;
            port.NewLine = newline;

        }    

        public override void Connect()
        {
            lock(m_lock)
            {
                try
                {
                    if (port.IsOpen)
                        return;
                    port.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("fiald to open the serialPort:" + ex.Message);
                }
            }        
        }

        public override void DisConnect()
        {
            lock(m_lock)
            {
                if (port.IsOpen)
                    port.Close();
            }            
        }

        public override async Task<byte[]> ReadAll( )
        {
            if (!port.IsOpen)
                throw new NotImplementedException(port.PortName + " is not opend");
            
                byte[] data = await Task<byte[]>.Run(() =>
                {
                    byte[] rtn;
                    string receive= port.ReadExisting();
                    rtn = Encoding.Default.GetBytes(receive);
                    return rtn;
                });
                return data;
            
           
        }

        public override async Task<byte[]> ReadBytes(  int length)
        {
            if (!port.IsOpen)
                throw new NotImplementedException(port.PortName + " is not opend");
            byte[] data = await Task<byte[]>.Run(() =>
            {               
                int l = port.BytesToRead;
                if(l>length)
                {
                    Thread.Sleep(5);
                }
                l = port.BytesToRead;
                if(l < length)
                {
                    throw new IndexOutOfRangeException("the receive cache area donot have eanogh data");
                }
                byte[] rtn = new byte[length] ;
                port.Read(rtn, 0, length);          
                return rtn;
            });
            return data;
        }

        public override void SendBytes(byte[] data)
        {
            if (!port.IsOpen)
                throw new NotImplementedException(port.PortName + " is not opend");
            port.Write(data, 0, data.Length);
        }

        public override void SendString(string data)
        {
            if (!port.IsOpen)
                throw new NotImplementedException(port.PortName + " is not opend");
            port.WriteLine(data);
        }
        #endregion
    }
}