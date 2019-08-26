using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fram.Hardware.MotionCard;
namespace Fram.Hardware.AxisDevice
{
   public  class ServoMotor:StepMotor
    {
        public ServoMotor(MotionCardBase motionCard, uint axisindex, string devicename, Guid guid) :base(motionCard, axisindex,devicename, guid)
        {

        }
        public void PowerSet(bool value)
        {
            m_motionCard.PowerSet(m_axisIndex, value);
        }
       
    }
}
