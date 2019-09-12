using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public abstract class BaseCommunicate
    {
        public CommunicatioinType CommunicationType;
        public abstract void Connect();
        public abstract void DisConnect();
        
        public virtual void SendBytes(byte[] data) { }
        public virtual void SendString(string data) { }
        public virtual Task<byte[]> ReadBytes(int length) { return null; }
        public virtual Task<byte[]> ReadAll( ) { return null; }
    }
    public enum CommunicatioinType
    {
        SerialPort,
        TcpClient,
    }
}
