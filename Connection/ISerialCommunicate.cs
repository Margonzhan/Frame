using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
namespace Communication
{
    public interface ISerialCommunicate
    {
        string PortName { get; }
        int BaudRate { get; }
        Parity Parity { get; }
        int DataBits { get; }
        StopBits StopBits { get;  }
        string NewLine { get;  }
    }
    public class PortEventArgs : EventArgs
    {
        public byte[] buffer;
        public int bytes;
    }
}