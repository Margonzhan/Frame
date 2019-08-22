using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Hardware.AxisDevice
{
   public  class ServoMotor:HardwareBase
    {
        public ServoMotor(string devicename,Guid guid):base(devicename,guid)
        {

        }
        public void PowerSet(bool value)
        {

        }
        public void Home(bool direction)
        {

        }
        public void AbsMove(int position)
        {

        }
        public void RelMove(int distance)
        {

        }
        public void JogStart(bool direction)
        {

        }
        public void JogStop()
        {

        }
    }
}
