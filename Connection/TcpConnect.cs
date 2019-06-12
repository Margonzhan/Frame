using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
namespace Connection
{
  public  class TcpConnect
    {
      public string m_StrName;
      public string m_StrIp;
      public int m_PortNumber;
      public int m_OutTime;
      
      public TcpClient m_TcpClient;
      public TcpConnect(string Strname,string StrIp,int  PortNumber,int OutTime)
      {
          m_StrName = Strname;
          m_StrIp = StrIp;
          m_PortNumber = PortNumber;
          m_OutTime = OutTime;
      }
      public bool Connection()
      {
          if (m_TcpClient == null)
          {
              m_TcpClient = new TcpClient();
              
          }
          if (!m_TcpClient.Connected)
          {
              m_TcpClient.ReceiveTimeout = m_OutTime;
              m_TcpClient.SendTimeout = m_OutTime;
              m_TcpClient.SendBufferSize = 4096;
              m_TcpClient.ReceiveBufferSize = 4096;
              m_TcpClient.Connect(m_StrIp, m_PortNumber);
          }
          return m_TcpClient.Connected;
      }
      public bool WriteString(string str)
      {
          if (m_TcpClient.Connected)
          {
              NetworkStream stream = m_TcpClient.GetStream();
              if (stream.CanWrite)
              {
                  byte[] data = Encoding.UTF8.GetBytes(str);
                  stream.Write(data, 0, data.Length);
                  return true;
              }
          }
          return false;
      }
      public bool WriteBytes(byte[] data,int length)
      {
          if (m_TcpClient.Connected)
          {
              NetworkStream stream = m_TcpClient.GetStream();
              if (stream.CanWrite)
              {
                  stream.Write(data, 0, length);
                  return true;
              }
          }
          return false;
      }
      public bool ReadData(byte[] data, int length)
      {
          if (m_TcpClient.Connected)
          {
              NetworkStream stream = m_TcpClient.GetStream();
              if (stream.CanRead)
              {
                  stream.Read(data, 0, length);
                  return true;
              }
             
          }
          return false;
      }
      public bool ReadLine(out string str)
      {
          if (m_TcpClient.Connected)
          {
              NetworkStream stream = m_TcpClient.GetStream();
              if (stream.CanRead)
              {
                  try
                  {
                      byte[] data = new byte[m_TcpClient.ReceiveBufferSize];
                      int n = stream.Read(data, 0, data.Length);
                      str = Encoding.UTF8.GetString(data, 0, n);
                  }
                  catch (Exception e)
                  {
                      str = "";
                      return false;
                  }
                  
                 return true;
              }
          }
          str = "";
          return false;
      }
      public void Close()
      {
          if (m_TcpClient!=null)
          {
              m_TcpClient.Close();
              m_TcpClient = null;
          }

      }
    }
}
