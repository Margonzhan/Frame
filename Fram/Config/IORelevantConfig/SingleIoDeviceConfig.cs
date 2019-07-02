using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Config
{
    public  class SingleIoDeviceConfig
    {
        public string DeviceName { get; set; }

        public Guid Guid { get; set; } = Guid.NewGuid();
        public Guid BindDeviceGuid { get; set; }
        public bool Enable { get; set; } = true;
        public bool IsShow { get; set; } = true;
        public bool IsInput { get; set; }
        public int IoIndex { get; set; }
    }
}
