using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cszmcaux;
namespace Fram.IOCard
{
    /// <summary>
    /// 正运动公司的EMC存io控制卡，32路input，32路output
    /// </summary>
  public  class EMC0064:IoCardBase
    {
        public override bool Open()
        {
          int ret=  zmcaux.ZAux_OpenCom(3, out IntPtr phandle);
          return true;
        }
    }
}
