using Fram.Hardware;
using Fram.Hardware.AxisDevice;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Fram.Station
{
    public  class Stationtest:StationBase
    {
       public   delegate void refrashChart(int x, double y);
        public delegate void clearChart();

       public    refrashChart RefrushChart;
        public clearChart ClearChart;

        StationStep m_step;
        StepMotor stepoMotor;
        int cyclePluse = 32768 * 50;//一圈脉冲数
        bool canBreak = false;

        double midV = 2.5;
        double forwardV = 4;
        double reverseV = 1;

        public Stationtest(string stationname):base (stationname)
        {

        }
        public override void Stop()
        {
            base.Stop();
            stepoMotor.Stop();
        }
        public override void Suspend()
        {
            base.Suspend();
            stepoMotor.Stop();
        }
        public  override void Init(ref string errmessage)
        {
            stepoMotor = AxisManager.Instance.AxisDeviceS["Axis1"] as StepMotor;

            StationStatue = StationStatue.Ready;
        }
        public override void AddFirstStep()
        {
            PushStep(StationStep.WaitStart);
        }
        protected async override Task Processor()
        {
            
            m_step = (StationStep)PopStep();
            switch (m_step)
            {
                case StationStep.WaitStart:
                    PushStep(StationStep.PowerOn);

                    break;
           
                   
            }
        }
       
     



        enum StationStep
        {
            WaitStart,
            PowerOn,
            ForwardMeasure,
            ReverseMeasure,
            PowerOff
        }
    }
}
