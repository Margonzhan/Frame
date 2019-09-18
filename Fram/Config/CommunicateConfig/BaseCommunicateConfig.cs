using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Config
{
   public class BaseCommunicateConfig:ConfigBase
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public CommunicatioinType CommunicationType { get; set; }
    }
    public enum CommunicatioinType
    {
        SerialPort,
        TcpClient,
    }
}
