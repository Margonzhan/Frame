using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fram.Hardware.AxisDevice;
namespace Fram.Hardware.LogicAxisUnite
{
    class LogicAxis
    {
        StepMotor motor;//对应的物理轴
        string axisName;//逻辑轴名称
        uint homeIndex;//回原点顺序
        bool isHome;//是否执行回原点操作
        public  string Name { get { return axisName; } }
        public uint HomeIndex { get; }
        public StepMotor Motor { get { return motor; } }

    }
}
