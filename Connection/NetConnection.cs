using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
namespace Connection
{
   public  class NetClientConnection
    {
      private  TcpClient m_Client;
      private string IPAdress;
      private int PortNumber;
      private CancellationTokenSource cts;
      private string _heartBeatKey;
      private Task _heartTask;
      private int _heartBeatTimeSpan=60000;
      private readonly object m_lock;
      public  NetClientConnection (string ipadress,int portnumber)
      {
          IPAdress = ipadress;
          PortNumber = portnumber;
          m_lock = new object();
      }
        #region 属性定义
        /// <summary>
        /// 心跳包内容
        /// </summary>
        public string HeartBeatKey
        {
            get
            {
                return _heartBeatKey;
            }
            set
            {
                if(value!=null)
                    _heartBeatKey = value;                  
            }
        }
        /// <summary>
        /// 心跳包功能使能
        /// </summary>
        public bool HeartBeatEnable
        {       
            set
            {
                lock(m_lock)
                {
                    if (value == true)
                    {
                        if (_heartTask == null || _heartTask.IsCanceled || _heartTask.Status == TaskStatus.RanToCompletion)
                        {
                            cts = new CancellationTokenSource();
                            _heartTask = new Task(ThreadHeartBeat, cts.Token);
                        }
                        _heartTask.Start();
                    }
                    else
                    {
                        cts.Cancel();
                    }

                }
                
            }
        }
        public int HeartBeatTimeSpan
        {
            get { return _heartBeatTimeSpan; }
            set { _heartBeatTimeSpan = value; }
        }
        #endregion
        private void ThreadHeartBeat()
        {           
            
            while (!cts.IsCancellationRequested)
            {
                try
                {
                    SendString(_heartBeatKey);
                }
                catch (Exception ex)
                {

                }
                
                Thread.Sleep(_heartBeatTimeSpan);
            }

        }
        public void Connect()
      {
            lock(m_lock)
            {
                if (m_Client == null)
                {
                    m_Client = new TcpClient();
                }
                try
                {
                    if (!m_Client.Connected)
                        m_Client.Connect(System.Net.IPAddress.Parse(IPAdress), PortNumber);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
             
      }
      public void ReConnect()
        {
            lock(m_lock)
            {
                if (m_Client != null)
                    m_Client.Close();
                m_Client = new TcpClient();

                try
                {
                    m_Client.Connect(System.Net.IPAddress.Parse(IPAdress), PortNumber);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
           
        }
      public void SendString(string str)//发送字符串
      {
            lock(m_lock)
            {
                try
                {
                    if (m_Client != null && m_Client.Connected)
                    {
                        NetworkStream ns = m_Client.GetStream();
                        if (ns.CanWrite)
                        {
                            byte[] sendByte = Encoding.UTF8.GetBytes(str);
                            ns.Write(sendByte, 0, sendByte.Length);
                        }
                    }
                    else if (m_Client == null)
                        throw new Exception("请先实例化");
                    else if (m_Client.Connected)
                    {
                        throw new Exception("链接异常");
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
          
      
      }
      public void SendBytes(byte[] data)//发送字符串
      {
            lock(m_lock)
            {
                try
                {
                    if (m_Client != null && m_Client.Connected)
                    {
                        NetworkStream ns = m_Client.GetStream();
                        if (ns.CanWrite)
                        {
                            ns.Write(data, 0, data.Length);
                        }
                    }
                    else if (m_Client == null)
                        throw new Exception("请先实例化");
                    else if (m_Client.Connected)
                    {
                        throw new Exception("链接异常");
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
      }
      public string ReadLine()//读取一行
      {
            lock(m_lock)
            {
                string strReturn = string.Empty;
                try
                {
                    if (m_Client != null && m_Client.Connected)
                    {
                        NetworkStream ns = m_Client.GetStream();
                        if (ns.CanRead)
                        {
                            long bufferLength = m_Client.ReceiveBufferSize;
                            byte[] data = new byte[bufferLength + 1];
                            ns.Read(data, 0, Convert.ToInt32(bufferLength));
                            strReturn = Encoding.Default.GetString(data);
                        }
                    }
                    else if (m_Client == null)
                        throw new Exception("请先实例化");
                    else if (m_Client.Connected)
                    {
                        throw new Exception("链接异常");
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return strReturn;
            }
          

          
      }
      public int  Readbytes(byte[] data, int length)
      {  
            lock(m_lock)
            {
                int readLength = 0;
                try
                {
                    if (m_Client != null && m_Client.Connected)
                    {
                        NetworkStream ns = m_Client.GetStream();
                        if (ns.CanRead)
                        {
                            long bufferLength = m_Client.ReceiveBufferSize;
                            readLength = ns.Read(data, 0, length);
                        }
                    }
                    else if (m_Client == null)
                        throw new Exception("请先实例化");
                    else if (m_Client.Connected)
                    {
                        throw new Exception("链接异常");
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return readLength;
            }
         
      }
      public void Close()
      {
          if (m_Client != null)
          {
              m_Client.Close();             
          }
      }
    }
}
