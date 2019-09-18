using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Config
{
   public  class SerialPortConfig:BaseCommunicateConfig
    {
        public  string PortName { get; private set; }
        public int BaudRate { get; private set; }
        [JsonConverter(typeof (StringEnumConverter))]
        public Parity Parity { get; private set; }
        public int DataBits { get; private set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public StopBits StopBits { get; private set; }
        public  string NewLine { get; private set; }
    }
}
