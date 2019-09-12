using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Config
{
    public  class AxisConfig:ConfigBase
    {
        /// <summary>
        /// which motion card to bind
        /// </summary>
        public Guid BindDeviceGuid { get; set; }
        /// <summary>
        /// the index number on the motion card
        /// </summary>
        public int AxisIndex { get; set; }
    }
}
