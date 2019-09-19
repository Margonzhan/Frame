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
        public  string PortName { get;  set; }
        public int BaudRate { get; set; } = 9600;
        [JsonConverter(typeof(StringEnumConverter))]
        public Parity Parity { get; set; } = Parity.None;
        public int DataBits { get; set; } = 8;
        [JsonConverter(typeof(StringEnumConverter))]
        public StopBits StopBits { get; set; } = StopBits.None;
        public string NewLine { get; set; } = "\n";
    }
}
