using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Config
{
   public  class CameraConfig:ConfigBase
    {
        /// <summary>
        /// 相机类型
        /// </summary>
        public string CameraType { get; set; }
        public string IpAddress { get; set; }
        public string CameraConnectType { get; set; }
        public uint ExposureTime { get; set; }
        public uint Gain { get; set; }
    }
}
