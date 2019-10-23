using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fram.Station
{
   public  class Stationtest:StationBase
    {
        StationStep m_step;
        public Stationtest(string stationname):base (stationname)
        {

        }
        public  override void Init(ref string errmessage)
        {

        }
        protected override void Processor()
        {
            switch (m_step)
            {
                case StationStep.step1:
                    Trace.Write("step1");
                    Thread.Sleep(3000);
                    break;
                case StationStep.step2:
                    Trace.Write("step2");
                    Thread.Sleep(3000);
                    break;
                case StationStep.step3:
                    Trace.Write("step3");
                    Thread.Sleep(3000);
                    break;
            }
        }
        enum StationStep
        {
            step1,
            step2,
            step3
        }
    }
}
