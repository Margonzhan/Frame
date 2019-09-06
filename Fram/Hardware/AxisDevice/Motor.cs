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
        public abstract double MoveVS
        { get; set; }
        public abstract double MoveVE
        { get; set; }
        public abstract double MoveVM
        { get; set; }
            
        public abstract Task HomeAsync(bool ispositivedir);
      
         public abstract Task AbsMoveAsync(int position);      
         public abstract Task RelMoveAsync(int distance);
         public abstract void JogStart(bool ispositivedir);
         public abstract void JogStop();
        public abstract void GetAxisIoStatue(ref int data);
        public abstract void GetAxisMotionStatue(ref int data);
        public abstract void GetAxisCPoint(ref double data);
    }
}
