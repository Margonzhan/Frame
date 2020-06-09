using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fram.Config
{
    public class IoCardConfig : ConfigBase
    {     
        /// <summary>
        /// the iocard type
        /// </summary>
        public string IoCardBrand { get; set; }
      
        /// <summary>
        /// the max input count the io card have
        /// </summary>
        public uint InputCount { get; set; }
        /// <summary>
        /// the max output count the io card have
        /// </summary>
        public uint OutputCount { get; set; }
    }
    
    
}
