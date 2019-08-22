using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Hardware.AxisDevice
{
   public  abstract class Motor:HardwareBase
    {
        public Motor(string devicename,Guid guid):base(devicename,guid)
        {

        }
        public abstract double HomeAccV
        {
            get;set;
        }
        public abstract double HomeDecV
        { get; set; }
        public abstract double HomeStartV
        { get; set; }
        public abstract double HomeMaxV
        { get; set; }
        public abstract int HomeMode
        { get; set; }
        public abstract  double MoveAccV
        { get; set; }
        public abstract double MoveDecV
        { get; set; }
        public abstract double MoveV
        { get; set; }

       //  public abstract void PowerSet(bool value);
         public abstract void Home(bool ispositivedir);
         public abstract void AbsMove(int position);
         public abstract void RelMove(int distance);
         public abstract void JogStart(bool ispositivedir);
         public abstract void JogStop();
    }
}
