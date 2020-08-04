using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Hardware.LogicAxisUnite
{
   public  class LogicAxisUnite
    {
        string uniteName;//轴单元名称
        Dictionary<string, LogicAxis> LogicAxisS = new Dictionary<string, LogicAxis>();
        public string Name { get { return uniteName; } }
        public void Home()
        {

        }
        public void ReadPoint()
        {

        }
        public void MoveToPoint(string PointName)
        {

        }
    }
}
