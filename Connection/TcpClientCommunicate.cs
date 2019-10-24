using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonFunc;
namespace Communication
{
   public  class TcpClientCommunicate : BaseCommunicate,IHeartBeat 
    {
        #region variable member
        private TcpClient m_Client;
        private readonly object m_lock=new object();
        private IPAddress remoteIpaddress,localIpAddress;
        private uint remotePort,localPort;
        private CancellationTokenSource cts;
        private Task _heartTask;
        #endregion
        #region property
        /// <summary>
        /// return the local ip address
        /// </summary>
        public string LocalIpAddress
        {
            get
            {           
                return ((IPEndPoint)m_Client.Client.LocalEndPoint).Address.ToString();
            }
        }
        /// <summary>
        /// return the local port number
        /// </summary>
        public int LocalPort
        {
            get
            {
                return ((IPEndPoint)m_Client.Client.LocalEndPoint).Port;
            }
        }
        /// <summary>
        /// return thr remote ip address
        /// </summary>
       public  string RemoteIpAddress
        {
            get
            {
                return ((IPEndPoint)m_Client.Client.RemoteEndPoint).Address.ToString();
            }
        }

      public   int RemotePort
        {
            get
            {
                return ((IPEndPoint)m_Client.Client.RemoteEndPoint).Port;
            }
        }

        public string HeartBeatKey
        {
            get;
            set ;
        } = "HeartBeat";
        public int HeartBeatIntervals
        {
            get;
            set;
        } = 10000;
        public bool HeartBeatEnable
        {
            get { return cts.IsCancellationRequested; }
            set
            {
                lock (m_lock)
                {
                    if (value == true)
                    {
                        if (_heartTask == null || _heartTask.IsCanceled || _heartTask.Status == TaskStatus.RanToCompletion)
                        {
                            cts = new CancellationTokenSource();
                            _heartTask = new Task(ThreadHeartBeat, cts.Token);
                            _heartTask.Start();
                        }
                        else if (_heartTask.Status == TaskStatus.Running)
                            return;

                    }
                    else
                    {
                        cts.Cancel();
                    }

                }
            }
        }
        #endregion

        #region function
        public TcpClientCommunicate(string localIpAddress,uint localPort, string remoteIpAddress, uint remotePort)
        {
            if(!IPAddress.TryParse(localIpAddress,out  IPAddress localipaddress))
            {
                throw new FormatException($"{localIpAddress} is  not an avaliable ipaddress");
            }
            if (!IPAddress.TryParse(remoteIpAddress, out IPAddress remoteipaddress))
            {
                throw new FormatException($"{localIpAddress} is  not an avaliable ipaddress");
            }
            this.localIpAddress = localipaddress;
            this.localPort = localPort;
            this.remoteIpaddress = remoteipaddress;
            this.remotePort = remotePort;
            m_Client = new TcpClient(new System.Net.IPEndPoint(localipaddress, (int)localPort));

        }
        public override  void Connect()
        {
            lock (m_lock)
            {             
                try
                {                 
                    if (!m_Client.Connected)
                    {                    
                        m_Client.Connect(remoteIpaddress, (int)remotePort);
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public override void DisConnect()
        {
            if (m_Client.Connected)
            {
                m_Client.Close();
              
            }
                
        }
        public override void SendString(string data)
        {
            if (!m_Client.Connected)
            {
                throw new InvalidOperationException("not connect to server");
            }
            lock (m_lock)
            {
                try
                {
                    if (m_Client != null && m_Client.Connected)
                    {
                        NetworkStream ns = m_Client.GetStream();
                        if (ns.CanWrite)
                        {
                            byte[] sendByte = Encoding.UTF8.GetBytes(data);
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
        public override void SendBytes(byte[] data)
        {
            if(!m_Client.Connected)
            {
                throw new InvalidOperationException("not connect to server");
            }
            lock (m_lock)
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
        public override async Task<byte[]> ReadBytes(int length,int outtime=300)
        {
            if (!m_Client.Connected)
            {
                throw new InvalidOperationException("not connect to server");
            }
            byte[] data = await Task<byte[]>.Run(() =>
            {
                NetworkStream ns = m_Client.GetStream();
                {
                    Time_Meter time_Meter = new Time_Meter();
                    byte[] rtn = new byte[length];
                    while (m_Client.Available < length)
                    {
                        if (time_Meter.IstimeOn(outtime))
                            throw new Exception("time out");
                        Thread.Sleep(5);
                    }
                    if (ns.CanRead)
                    {
                        ns.Read(rtn, 0, length);
                    }
                    return rtn;
                }
                          
            });
            return data;
        }
        public override async Task<byte[]> ReadAll(int outtime=300)
        {
            if (!m_Client.Connected)
            {
                throw new InvalidOperationException("not connect to server");
            }
            byte[] data = await Task<byte[]>.Run(() =>
            {
                byte[] rtn;
                NetworkStream ns = m_Client.GetStream();
                {
                    Time_Meter time_Meter = new Time_Meter();

                    while (m_Client.Available == 0)
                    {
                        if (time_Meter.IstimeOn(outtime))
                            throw new Exception("time out");
                        Thread.Sleep(5);
                    }
                    long bufferLength = m_Client.Available;
                    rtn = new byte[bufferLength];
                    if (ns.CanRead)
                        ns.Read(rtn, 0, Convert.ToInt32(bufferLength));
                }
                    
              
                return rtn;
            });
            return data;
        }

        private void ThreadHeartBeat()
        {

            while (!cts.IsCancellationRequested)
            {
                try
                {
                    SendString(HeartBeatKey);
                }
                catch (Exception ex)
                {

                }
                Thread.Sleep(HeartBeatIntervals);
            }

        }
        #endregion
    }
}
