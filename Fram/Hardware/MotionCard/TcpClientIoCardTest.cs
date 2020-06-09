using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication;

namespace Fram.Hardware.IoCard
{
    public class TcpClientIoCardTest : IoCardBase
    {
        public TcpClientIoCardTest( Guid guid, string devicename, uint inputcount, uint outputcount,string cinfo) : base( guid, devicename, inputcount, outputcount)
        {
            
        }
        public override bool GetSingleInput(int index)
        {
            return base.GetSingleInput(index);
        }
        public override void SetSingleOutput(int index, bool value)
        {
        }
    }
}
