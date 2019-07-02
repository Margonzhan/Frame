using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Hardware.IOBaseDevice
{
   public  interface ISingleIoDevice
    {
        /// <summary>
        /// get the statue of the device
        /// </summary>
        /// <returns></returns>
        bool GetStatue();
        /// <summary>
        /// Set the statue of the divece,on defalut,'true' mean open,'false' mean close
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        void  SetStatue(bool value);
    }
}
