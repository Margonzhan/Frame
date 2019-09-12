using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    interface ITcpClientCommunicate
    {
        string LocalIpAddress { get; }
        int LocalPort { get; }
        string RemoteIpAddress { get; }
        int RemotePort { get; }
    }
}
