using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Hardware.LogicAxisUnite
{
    /// <summary>
    /// 轴单元点位
    /// </summary>
    public class AxisUnitPoint
    {
        List<AxisPoint> axisPoints = new List<AxisPoint>();
        /// <summary>
        /// 对应的轴单元的名称
        /// </summary>
        public string AxisUnitName { get; set; }
        /// <summary>
        /// 轴单元点位名称
        /// </summary>
        public string PointName {get;set;}
        /// <summary>
        /// 各个轴位置信息
        /// </summary>
        public List<AxisPoint> AxisPoints
        {
            get { return axisPoints; }
            
        }
    }
}
