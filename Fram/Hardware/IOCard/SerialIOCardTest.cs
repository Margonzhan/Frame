using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication;

namespace Fram.Hardware.IoCard
{
    public class SerialIOCardTest : IoCardBase
    {
       
        public SerialIOCardTest(BaseCommunicate communicate, Guid guid, string devicename, uint inputcount, uint outputcount) : base(communicate, guid, devicename, inputcount, outputcount)
        {
            Communicate.Connect();
        }
        public override bool GetSingleInput(int index)
        {
            Communicate.SendString($"getoutput {index } \r\n");
            return base.GetSingleInput(index);
        }
        public override void SetSingleOutput(int index, bool value)
        {           
            Communicate.SendString($"setoutput {index } to {value} \r\n");
        }
    }
}
