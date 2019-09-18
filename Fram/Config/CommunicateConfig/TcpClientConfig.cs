using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Config
{
   public  class TcpClientConfig:BaseCommunicateConfig
    {
        public  string LocalIpAddress { get; private set; }
        public uint LocalPort { get; private set; }
        public string RemoteIpAddress { get; private set; }
        public uint RemotePort { get; private set; }
    }
}
