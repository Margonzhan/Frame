using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Config
{
   public  class TcpClientConfig:BaseCommunicateConfig
    {
        public  string LocalIpAddress { get;  set; }
        public uint LocalPort { get;  set; }
        public string RemoteIpAddress { get;  set; }
        public uint RemotePort { get;  set; }
    }
}
