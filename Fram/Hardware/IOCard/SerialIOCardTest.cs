using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication;

namespace Fram.Hardware.IoCard
{
    public class SerialIOCardTest : IoCardBase
    {
       
        public SerialIOCardTest( Guid guid, string devicename, uint inputcount, uint outputcount) : base( guid, devicename, inputcount, outputcount)
        {
           
        }
        public override bool GetSingleInput(int index)
        {
            Random random = new Random();
            int r=  random.Next(1, 10);
            return r>5?true:false;
        }
        public override void SetSingleOutput(int index, bool value)
        {
            base.SetSingleOutput(index, value);
        }
    }
}
