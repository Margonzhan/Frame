using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Config
{
   public  class ConfigBase
    {
        public bool Enable { get; set; } = false;
        public string DeviceName { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();

    }
}
