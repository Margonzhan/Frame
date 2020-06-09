using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using Fram;
using DevExpress.XtraCharts;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Fram.Hardware;
using Fram.Hardware.AxisDevice;
using System.Drawing;
using Fram.Station;
namespace Fram.FormFolder
{
    public partial class FormAuto : UserControl
    {
        bool canBreak = false;
        const int TOTAL_NUMBER = 100;//
        StepMotor stepoMotor;

        int cyclePluse = 32768*50;//一圈脉冲数
        double midV=-1;
        double forwardV=-1;
        double reverseV=-1;
        public FormAuto()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.pB_Run.Enabled = false;
         
          //  stepoMotor = AxisManager.Instance.AxisDeviceS["Axis1"] as StepMotor;
           // stepoMotor.PowerStatue = true;
            DelegateUIControl.Instance.TxtBoxS.Add("FormAuto_txtMidV", this.txt_MidV);
            DelegateUIControl.Instance.TxtBoxS.Add("FormAuto_txtForwardTargetV", this.txt_ForwardTargetV);
            DelegateUIControl.Instance.TxtBoxS.Add("FormAuto_txtReverseTargetV", this.txt_ReverseTargetV);
            DelegateUIControl.Instance.TxtBoxS.Add("FormAuto_txtForwardAngle", this.txt_ForwardAngle);
            DelegateUIControl.Instance.TxtBoxS.Add("FormAuto_txtReverseAngle", this.txtReverseAngle);
            DelegateUIControl.Instance.TxtBoxS.Add("FormAuto_txtForwardTime", this.txt_ForwardTime);
            DelegateUIControl.Instance.TxtBoxS.Add("FormAuto_txtReverseTime", this.txt_ReverseTime);
            DelegateUIControl.Instance.TxtBoxS.Add("FormAuto_txtTotalTime", this.txt_TotalTime);
            DelegateUIControl.Instance.TxtBoxS.Add("FormAuto_txtRealTimeV", this.txt_RealTimeV);
           // Init();
        }

        private void Init()
        {
            if(Station.StationManager.Instance.GetStationByName("test")!=null)
            {
                Stationtest stationtest = (Stationtest)Station.StationManager.Instance.GetStationByName("test");
                stationtest.RefrushChart += RefrushChart;
                stationtest.ClearChart += ClearChart;
            }
           
        }
        
        private void btn_Start_Click(object sender, System.EventArgs e)
        {        
            if (this.btn_Start.Text == "启动")
            {
                GloablObject.Instance.Power.OutPut(true);
                if(string.IsNullOrEmpty(txt_MidV.Text))
                {
                    MessageBox.Show("中点电压不能设置为空");
                    return;
                }
                midV = double.Parse(txt_MidV.Text);

                if (string.IsNullOrEmpty(txt_ForwardTargetV.Text))
                {
                    MessageBox.Show("正传目标电压不能设置为空");
                    return;
                }
                forwardV = double.Parse(txt_ForwardTargetV.Text);

                if (string.IsNullOrEmpty(txt_ReverseTargetV.Text))
                {
                    MessageBox.Show("发传目标电压不能设置为空");
                    return;
                }
                reverseV = double.Parse(txt_ReverseTargetV.Text);

                canBreak = false;
                chartControl1.Series[0].Points.Clear();
                Task.Run(async () =>
                {
                    stepoMotor.SetAxisCPoint();
                    DateTime ts = DateTime.Now;
                    await ForwardMeasure(midV, forwardV);
                    //  await ReverseMeasure(midV, reverseV);
                    DelegateUIControl.Instance.UpdateTextBox("FormAuto_txtTotalTime", (DateTime.Now - ts).TotalSeconds.ToString("F1"), false);
                    GloablObject.Instance.VoltageMeasurement.SetVoltageParam(VoltageMeasurement.VoltRange.V10, VoltageMeasurement.VoltPLC.PLC10);
                    while (true)
                    {
                        if (canBreak)
                            break;
                       double  voltage= GloablObject.Instance.VoltageMeasurement.GetVoltage();
                      
                       
                        DelegateUIControl.Instance.UpdateTextBox("FormAuto_txtRealTimeV", voltage.ToString(), false);
                        Thread.Sleep(10);
                    }

                });
                this.btn_Start.Text = "暂停";
            }
            else
            {
                canBreak = true;
                stepoMotor.Stop();
                this.btn_Start.Text = "启动";
            }
        }  
        private async Task ForwardMeasure(double middleV,double targetV)
        {
            DateTime ts = DateTime.Now;

            ClearChart();
            FindVRoughFast(VoltageMeasurement.VoltPLC.PLC0_02, true, middleV - 0.3, 0.2, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找中点电压第一步完成");

            ClearChart();
            FindVRough(VoltageMeasurement.VoltPLC.PLC0_02, true, middleV-0.06, 0.03, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找中点电压第二步完成");


            ClearChart();
            await FindVPreciseess(VoltageMeasurement.VoltPLC.PLC0_2, true, 200, middleV, 0.01, 5000);
         //   DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找中点电压第三步完成");

            ClearChart();
            await FindVPreciseess(VoltageMeasurement.VoltPLC.PLC0_2, true, 50, middleV, 0.002, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找中点电压第三步完成");

            ClearChart();
            await FindVPreciseess(VoltageMeasurement.VoltPLC.PLC10, true,10, middleV, 0.0003, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找中点电压第四步完成");
            return;
            Thread.Sleep(1000);
            double motorPoint = 0;
            stepoMotor.GetAxisCPoint(ref motorPoint);
            double voltage = GloablObject.Instance.VoltageMeasurement.GetVoltage();
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "正转中点电压位置   " + motorPoint.ToString());
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "中点电压   " + voltage.ToString());

            ClearChart();
            FindVRough(VoltageMeasurement.VoltPLC.PLC0_02, true, targetV-0.1, 0.05, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找目标电压第一步完成");

            ClearChart();
            await FindVPreciseess(VoltageMeasurement.VoltPLC.PLC0_2, true, 200, targetV, 0.01, 5000);

            ClearChart();
            await FindVPreciseess(VoltageMeasurement.VoltPLC.PLC0_2, true, 50, targetV, 0.002, 5000);
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "查找目标电压第二步完成");
            ClearChart();
            await FindVPreciseess(VoltageMeasurement.VoltPLC.PLC10, true, 10, targetV, 0.0003, 5000);
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
            DelegateUIControl.Instance.UpdateRichTBoxZD("FormMain_RichTBoxZD_Log", "反转中点电压位置   "+motorPoint.ToString());
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
        private async Task FindVPreciseess(VoltageMeasurement.VoltPLC volplc,bool direction,uint step,double targetVol,  double accuracy,uint outTime)
        {
            GloablObject.Instance.VoltageMeasurement.SetVoltageParam(VoltageMeasurement.VoltRange.V10, volplc);

            
            stepoMotor.MoveVM = 1000;
            int minStep=-(int)step;
            double _accuracy = accuracy;
            if (!direction)
            {
                minStep = ((int)step);
              //  _accuracy = -accuracy;
            }
            int i = 1;
            while(true)
            {
                if (canBreak)
                    break;
                await stepoMotor.RelMoveAsync(minStep);
                double voltage = GloablObject.Instance.VoltageMeasurement.GetVoltage();
                DelegateUIControl.Instance.UpdateTextBox("FormAuto_txtVoltage", voltage.ToString(), false);
                if(direction)
                {
                    if (( targetVol-voltage) < accuracy)
                    {
                        Thread.Sleep(100);
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
                        Thread.Sleep(100);
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
        private  void FindVRough(VoltageMeasurement.VoltPLC volplc, bool direction,  double targetVol, double accuracy, uint outTime)
        {
            GloablObject.Instance.VoltageMeasurement.SetVoltageParam(VoltageMeasurement.VoltRange.V10, volplc);

            stepoMotor.MoveAccV = 10000;
            stepoMotor.MoveDecV = 10000;
            stepoMotor.MoveVM = 10000;
            if(direction)
                stepoMotor.RelMoveAsync(-cyclePluse * 2);
            else
                stepoMotor.RelMoveAsync(cyclePluse * 2);

            int i = 1;
            while (true)
            {
                if (canBreak)
                    break;
                double voltage = GloablObject.Instance.VoltageMeasurement.GetVoltage();
                if ( Math.Abs  (targetVol - voltage) < accuracy)
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


        private void ClearChart()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() =>
                {
                    
                        chartControl1.Series[0].Points.Clear();
                }));
            }
            else
            {
                chartControl1.Series[0].Points.Clear();
            }
        }

        private void RefrushChart(int x,double y)
        {
            if(this.InvokeRequired)
            {
                DelegateUIControl.Instance.UpdateTextBox("FormAuto_txtRealTimeV", y.ToString(), false);
                this.BeginInvoke(new Action(() => 
                {
                    chartControl1.Series[0].Points.AddPoint(x, y);
                    if (chartControl1.Series[0].Points.Count > TOTAL_NUMBER)
                        chartControl1.Series[0].Points.RemoveAt(0);
                }));
            }
            else
            {
                chartControl1.Series[0].Points.AddPoint(x, y);
                if (chartControl1.Series[0].Points.Count > TOTAL_NUMBER)
                    chartControl1.Series[0].Points.RemoveAt(0);
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            if (btn_Stop.Text == "启动")
            {
                Station.StationManager.Instance.StartAll();
                btn_Stop.Text = "暂停";
                this.pB_Run.Enabled = true;
            }
            else
            {
                Station.StationManager.Instance.SuspendAll();
                btn_Stop.Text = "启动";
                this.pB_Run.Enabled = false;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int step = int.Parse(txt_MidV.Text);
            await stepoMotor.RelMoveAsync(step);

        }
    }
   
}
