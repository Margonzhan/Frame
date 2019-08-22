using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Hardware
{
    [Serializable]
   public abstract class HardwareBase
    {
        public  HardwareBase(string devicename,Guid guid)
        {
            this.DeviceName = devicename;
            this.Guid = guid;
        }
        public  string DeviceName { get; set; }
        public  Guid Guid { get; set; } = Guid.NewGuid();
        public  bool Enable { get; set; } = true;
       
    }
}
