using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Config
{
   public  class MotionCardConfig:ConfigBase
    {
        /// <summary>
        /// the Motincard type
        /// </summary>
        public string MotionCardBrand { get; set; }
        /// <summary>
        /// which way to use to connect the iocard,usually,ethernet,serialport ,ect
        /// </summary>
        public string ConnectType { get; set; }
        public int CardId { get; set; }
        public int CardIdMode { get; set; }
    }
}
