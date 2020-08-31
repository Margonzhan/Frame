using CommonFunc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram
{
   public  class GloableObject:Singleton<GloableObject>
    {
        MachineStatueControl machineStatueControl = new MachineStatueControl();
        public MachineStatueControl MachineStatueControl
        {
            get { return machineStatueControl; }
        }
    }
}
