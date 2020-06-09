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
                case StationStep.PowerOn:
                    GloablObject.Instance.Power.OutPut(true);
                    DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "powerON   ");
                    PushStep(StationStep.ForwardMeasure);
                  //  Thread.Sleep(3000);
                    break;
                case StationStep.ForwardMeasure:
                    await ForwardMeasure(midV, forwardV);
                    PushStep(StationStep.ReverseMeasure);
                   // Thread.Sleep(3000);


                    break;
                case StationStep.ReverseMeasure:
                    //  await ReverseMeasure(midV, reverseV);
                    PushStep(StationStep.PowerOff);
                  //  Thread.Sleep(3000);
                    break;
                case StationStep.PowerOff:
                    GloablObject.Instance.Power.OutPut(false);
                    DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "powerOFF   ");

                    PushStep(StationStep.PowerOn);
                    Thread.Sleep(3000);
                    break;
                   
            }
        }
        private async Task ForwardMeasure(double middleV, double targetV)
        {
            DateTime ts = DateTime.Now;

            ClearChart();
            FindVRoughFast(VoltageMeasurement.VoltPLC.PLC0_02, true, middleV - 0.8, 0.4, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找中点电压第一步完成");

            ClearChart();
            FindVRough(VoltageMeasurement.VoltPLC.PLC0_02, true, middleV - 0.06, 0.03, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找中点电压第二步完成");


            ClearChart();
            await FindVPreciseess(VoltageMeasurement.VoltPLC.PLC0_2, true, 500, middleV, 0.01, 5000);
            //   DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找中点电压第三步完成");

            ClearChart();
            await FindVPreciseess(VoltageMeasurement.VoltPLC.PLC0_2, true, 100, middleV, 0.002, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找中点电压第三步完成");

            ClearChart();
            await FindVPreciseess(VoltageMeasurement.VoltPLC.PLC10, true, 4, middleV, 0.0003, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找中点电压第四步完成");

            Thread.Sleep(1000);
            double motorPoint = 0;
            stepoMotor.GetAxisCPoint(ref motorPoint);
            double voltage = GloablObject.Instance.VoltageMeasurement.GetVoltage();
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "正转中点电压位置   " + motorPoint.ToString());
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "中点电压   " + voltage.ToString());

            ClearChart();
            FindVRough(VoltageMeasurement.VoltPLC.PLC0_02, true, targetV - 0.1, 0.05, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找目标电压第一步完成");

            ClearChart();
            await FindVPreciseess(VoltageMeasurement.VoltPLC.PLC0_2, true, 50, targetV, 0.01, 5000);

            ClearChart();
            await FindVPreciseess(VoltageMeasurement.VoltPLC.PLC0_2, true, 16, targetV, 0.002, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找目标电压第二步完成");
            ClearChart();
            await FindVPreciseess(VoltageMeasurement.VoltPLC.PLC10, true, 4, targetV, 0.0003, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找目标电压第三步完成");
            DelegateUIControl.Instance.UpdateTextBox("FormAuto_txtForwardTime", (DateTime.Now - ts).TotalSeconds.ToString("F1"), false);

            double motorPoint1 = 0;
            Thread.Sleep(1000);
            stepoMotor.GetAxisCPoint(ref motorPoint1);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "正转目标电压位置   " + motorPoint1.ToString());

            double angle = Math.Abs(motorPoint1 - motorPoint) / cyclePluse * 360;
            DelegateUIControl.Instance.UpdateTextBox("FormAuto_txtForwardAngle", angle.ToString("F4"), false);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "正转角度   " + angle.ToString("F4"));

        }
        private async Task ReverseMeasure(double middleV, double targetV)
        {
            DateTime ts = DateTime.Now;
            ClearChart();
            FindVRoughFast(VoltageMeasurement.VoltPLC.PLC0_02, false, middleV + 0.6, 0.3, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找中点电压第一步完成");

            ClearChart();
            FindVRough(VoltageMeasurement.VoltPLC.PLC0_02, false, middleV + 0.06, 0.03, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找中点电压第二步完成");

            ClearChart();
            double v = GloablObject.Instance.VoltageMeasurement.GetVoltage();
            await FindVPreciseess(VoltageMeasurement.VoltPLC.PLC0_2, false, 16, middleV, 0.002, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找中点电压第三步完成");

            ClearChart();
            await FindVPreciseess(VoltageMeasurement.VoltPLC.PLC10, false, 2, middleV, 0.0002, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找中点电压第四步完成");

            double motorPoint = 0;
            stepoMotor.GetAxisCPoint(ref motorPoint);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "反转中点电压位置   " + motorPoint.ToString());
            ClearChart();
            FindVRough(VoltageMeasurement.VoltPLC.PLC0_02, false, targetV + 0.06, 0.03, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找目标电压第一步完成");

            ClearChart();
            await FindVPreciseess(VoltageMeasurement.VoltPLC.PLC0_2, false, 16, targetV, 0.002, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找目标电压第二步完成");

            ClearChart();
            await FindVPreciseess(VoltageMeasurement.VoltPLC.PLC10, false, 2, targetV, 0.0003, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找目标电压第三步完成");

            DelegateUIControl.Instance.UpdateTextBox("FormAuto_txtReverseTime", (DateTime.Now - ts).TotalSeconds.ToString("F1"), false);

            double motorPoint1 = 0;
            stepoMotor.GetAxisCPoint(ref motorPoint1);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "反转目标电压位置  " + motorPoint1.ToString());
            double angle = Math.Abs(motorPoint1 - motorPoint) / cyclePluse * 360;
            DelegateUIControl.Instance.UpdateTextBox("FormAuto_txtReverseAngle", angle.ToString("F4"), false);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "反转角度   " + angle.ToString("F4"));

        }

        private async Task FindVPreciseess(VoltageMeasurement.VoltPLC volplc, bool direction, uint step, double targetVol, double accuracy, uint outTime)
        {
            GloablObject.Instance.VoltageMeasurement.SetVoltageParam(VoltageMeasurement.VoltRange.V10, volplc);


            stepoMotor.MoveVM = 1000;
            int minStep = -(int)step;
            double _accuracy = accuracy;
            if (!direction)
            {
                minStep = ((int)step);
                //  _accuracy = -accuracy;
            }
            int i = 1;
            while (true)
            {
                if (canBreak)
                    break;
                await stepoMotor.RelMoveAsync(minStep);
                double voltage = GloablObject.Instance.VoltageMeasurement.GetVoltage();
                DelegateUIControl.Instance.UpdateTextBox("FormAuto_txtVoltage", voltage.ToString(), false);
                if (direction)
                {
                    if ((targetVol - voltage) < accuracy)
                    {
                        Thread.Sleep(500);
                        voltage = GloablObject.Instance.VoltageMeasurement.GetVoltage();
                        if ((targetVol - voltage) < accuracy)
                        {
                            stepoMotor.Stop();
                            break;

                        }
                        else
                            continue;
                    }
                }
                else
                {
                    if ((voltage - targetVol) < accuracy)
                    {
                        Thread.Sleep(500);
                        voltage = GloablObject.Instance.VoltageMeasurement.GetVoltage();
                        if ((voltage - targetVol) < accuracy)
                        {
                            stepoMotor.Stop();
                            break;

                        }
                        else
                            continue;
                    }
                }

                try
                {

                    RefrushChart(i, voltage);
                    i++;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                Thread.Sleep(10);
            }

        }
        private void FindVRough(VoltageMeasurement.VoltPLC volplc, bool direction, double targetVol, double accuracy, uint outTime)
        {
            GloablObject.Instance.VoltageMeasurement.SetVoltageParam(VoltageMeasurement.VoltRange.V10, volplc);

            stepoMotor.MoveAccV = 10000;
            stepoMotor.MoveDecV = 10000;
            stepoMotor.MoveVM = 10000;
            if (direction)
                stepoMotor.RelMoveAsync(-cyclePluse * 2);
            else
                stepoMotor.RelMoveAsync(cyclePluse * 2);

            int i = 1;
            while (true)
            {
                if (canBreak)
                    break;
                double voltage = GloablObject.Instance.VoltageMeasurement.GetVoltage();
                if (Math.Abs(targetVol - voltage) < accuracy)
                {
                    stepoMotor.Stop();
                    break;
                }
                try
                {

                    RefrushChart(i, voltage);
                    i++;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                Thread.Sleep(1);
            }
        }
        private void FindVRoughFast(VoltageMeasurement.VoltPLC volplc, bool direction, double targetVol, double accuracy, uint outTime)
        {
            GloablObject.Instance.VoltageMeasurement.SetVoltageParam(VoltageMeasurement.VoltRange.V10, volplc);

            stepoMotor.MoveAccV = 100000;
            stepoMotor.MoveDecV = 100000;
            stepoMotor.MoveVM = 100000;
            if (direction)
                stepoMotor.RelMoveAsync(-cyclePluse * 2);
            else
                stepoMotor.RelMoveAsync(cyclePluse * 2);

            int i = 1;
            while (true)
            {
                if (canBreak)
                    break;
                
                double voltage = GloablObject.Instance.VoltageMeasurement.GetVoltage();
                if (Math.Abs(targetVol - voltage) < accuracy)
                {
                    stepoMotor.Stop();
                    break;
                }
                try
                {

                    RefrushChart(i, voltage);
                    i++;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                Thread.Sleep(1);
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
