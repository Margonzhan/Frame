using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fram.Hardware.AxisDevice;
namespace Fram.Hardware.LogicAxisUnite
{
    public class LogicAxis:HardwareBase
    {
        StepMotor m_motor;//对应的物理轴
        uint m_homeIndex;//回原点顺序
        bool m_isHome;//是否执行回原点操作
      public   LogicAxis(string devicename,Guid guid,StepMotor motor,bool isHome,uint homeIndex):base(devicename,guid)
       {
            this.m_motor = motor;
            this.m_isHome = isHome;
            this.m_homeIndex = homeIndex;

       }
        public uint HomeIndex { get; }
        public bool IsHOme { get { return m_isHome; }  }//对于绝对式编码器，不需要回原点

        public StepMotor Motor { get { return m_motor; } }

    }
}
