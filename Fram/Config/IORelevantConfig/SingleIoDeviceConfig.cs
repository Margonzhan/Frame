using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Config
{
    public  class SingleIoDeviceConfig:ConfigBase
    {          
         /// <summary>
        /// which iocard to bind this io device
        /// </summary>
        public Guid BindDeviceGuid { get; set; }
      
        public bool IsShow { get; set; } = true;
        public bool IsInput { get; set; }
        public int IoIndex { get; set; }
    }
}
