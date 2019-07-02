using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Config
{
    public class IoCardConfig : ConfigBase
    {     
        /// <summary>
        /// the iocard type
        /// </summary>
        public string IoCardBrand { get; set; } 
        /// <summary>
        /// which way to use to connect the iocard,usually,ethernet,serialport ,ect
        /// </summary>
        public string ConnectType { get; set; }       
        /// <summary>
        /// the comport name when connect the iocard by serialport
        /// </summary>
        public uint COM { get; set; }
        /// <summary>
        /// the  Baudrate name when connect the iocard by serialport
        /// </summary>
        public uint BaudRate { get; set; }
        /// <summary>
        /// the DataBits  when connect the iocard by serialport
        /// </summary>
        public uint DataBits { get; set; }
        /// <summary>
        /// the StopBits  when connect the iocard by serialport
        /// </summary>
        public string StopBits { get; set; }
        /// <summary>
        /// the Parity  when connect the iocard by serialport
        /// </summary>
        public string Parity { get; set; }
        /// <summary>
        /// the ip address when connect the iocard by ethernet
        /// </summary>
        public string IpAddress { get; set; }
        /// <summary>
        /// the port number address when connect the iocard by ethernet
        /// </summary>
        public uint Port { get; set; }
        /// <summary>
        /// the max input count the io card have
        /// </summary>
        public uint InputCount { get; set; }
        /// <summary>
        /// the max output count the io card have
        /// </summary>
        public uint OutputCount { get; set; }
    }
    
    
}
