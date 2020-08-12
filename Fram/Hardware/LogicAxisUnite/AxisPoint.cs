using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Hardware.LogicAxisUnite
{
    public class AxisPoint
    {
        /// <summary>
        /// 当前轴是否参与该点位运行
        /// </summary>
        public bool IsMove { get; set; }
        /// <summary>
        /// 逻辑轴名称
        /// </summary>
        public string LogicAxisName { get;  set; }
        /// <summary>
        /// 移动顺序
        /// </summary>
        public uint MoveIndex { get;  set; }
        /// <summary>
        /// 轴移动速度
        /// </summary>
        public uint Speed { get;  set; }
        /// <summary>
        /// 轴移动位置
        /// </summary>
        public double Position { get; set; }
    }
}
