using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Config.MotionRelevantConfig
{
   public  class LogicAxisConfig:ConfigBase
    {
        public Guid BindDeviceGuid { get; set; }
        public uint HomeIndex { get; set; } = 0;
        public bool IsHome { get; set; } = true;
    }
}
