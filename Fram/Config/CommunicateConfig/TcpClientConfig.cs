using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Config
{
    /// <summary>
    /// 应用于需要提供网卡通信信息的类，
    /// </summary>
   public  class TcpClientConfig
    {
        public string Description { get;  set; }
        public string DeviceName { get; set; }

        public string LocalIpAddress { get;  set; }
        public uint LocalPort { get;  set; }
        public string RemoteIpAddress { get;  set; }
        public uint RemotePort { get;  set; }
        public Guid BindGuid { get;  set; }

    }
}
