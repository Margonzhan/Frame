using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Config.MotionRelevantConfig
{
     public   class LogicAxisUnitConfig:ConfigBase
    {
        public List<LogicAxisConfig> LogicAxisConfigs { get; set; }
        public string RelatedProductName { get; set; } = "Common";
    }
}
