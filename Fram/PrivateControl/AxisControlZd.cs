using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fram.Hardware.AxisDevice;
using System.Threading;
using Fram.Hardware.LogicAxisUnite;

namespace Fram.PrivateControl
{
    public partial class AxisControlZd : UserControl
    {
        private StepMotor Motor;
        private Task _taskFrashPosition;
        private CancellationTokenSource CancellationTokenSource;
        private Task _taskHome;
        private CancellationTokenSource _homeCancelTokenSource;
        private Task _taskMove;
        private CancellationTokenSource _moveCancelTokenSource;
        public bool IsShowing
        {
            set
            {

            }
        }
        public AxisControlZd()
        {
            InitializeComponent();
            cmB_MoveMode.SelectedIndex = 0;
            cmB_HomeDir.SelectedIndex = 0;
        }
        public AxisControlZd(StepMotor motor)
        {
            InitializeComponent();
            cmB_MoveMode.SelectedIndex = 0;
            cmB_HomeDir.SelectedIndex = 0;
            Motor = motor;
            this.label_AxisName.Text = Motor.DeviceName;
            btn_Power.Text = Motor.PowerStatue ? "Power On" : "Power Off";
            cmB_HomeDir.SelectedIndex= Motor.HomeDir;
            txt_MaxSpeed.Text = Motor.MoveVM.ToString();
            CancellationTokenSource = new CancellationTokenSource();
            Task.Run(new Action(() => FrashPosition()), CancellationTokenSource.Token);
        }
        public AxisControlZd (LogicAxis logicAxis)
        {
            InitializeComponent();
            cmB_MoveMode.SelectedIndex = 0;
            cmB_HomeDir.SelectedIndex = 0;
            Motor = logicAxis.Motor;
            this.label_AxisName.Text = logicAxis.DeviceName;
            btn_Power.Text = Motor.PowerStatue ? "Power On" : "Power Off";
            if(!logicAxis.IsHOme)
            {
                this.btn_Home.Enabled = false;
            }
            cmB_HomeDir.SelectedIndex = Motor.HomeDir;
            txt_MaxSpeed.Text = Motor.MoveVM.ToString();
            CancellationTokenSource = new CancellationTokenSource();
            Task.Run(new Action(() => FrashPosition()), CancellationTokenSource.Token);
        }
        private void FrashPosition()
        {
            while(CancellationTokenSource.Token.CanBeCanceled)
            {
                if (this.label_AbsPosition.InvokeRequired)
                {
                    label_AbsPosition.BeginInvoke(new Action(() =>
                    {
                        double p = 0;
                        Motor.GetAxisCPoint(ref p);
                        label_AbsPosition.Text = p.ToString("f0");
                    }));
                }
                else
                {
                    double p = 0;
                    Motor.GetAxisCPoint(ref p);
                    label_AbsPosition.Text = p.ToString("f0");
                }
                Thread.Sleep(100);
            }
            
        }

        private   void btn_Home_Click(object sender, EventArgs e)
        {
            if(btn_Home.Text=="Home")
            {
                if(!Motor.PowerStatue)
                {
                    MessageBox.Show("the axis is Power off", "提示");
                    return;
                }
                if (Motor.Busy)
                {
                    MessageBox.Show("the axis is moving", "提示");
                    return;
                }

                bool homedir = cmB_HomeDir.SelectedIndex == 0 ? true : false;
                _homeCancelTokenSource = new CancellationTokenSource();
                _taskHome = new Task(   () => { Task t=  Motor.HomeAsync(homedir);t.Wait(); }, _homeCancelTokenSource.Token);
                _taskHome.Start();
                btn_Home.Text = "Stop";
                Task.Run(new Action(()=> 
                {
                    while(true)
                    {
                        if (_taskHome.IsCompleted)
                        {
                            btn_Home.BeginInvoke(new Action(() => { btn_Home.Text = "Home"; }));
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    
                }));
            }
            else
            {
                if(_taskHome.Status==TaskStatus.Running)
                {                   
                    _homeCancelTokenSource.Cancel();
                    Motor.Stop();                 
                }
                btn_Home.Text = "Home";
            }
        }

        private void btn_Power_Click(object sender, EventArgs e)
        {
            bool value = Motor.PowerStatue;
            Motor.PowerStatue = !value;
            Thread.Sleep(10);
            btn_Power.Text = Motor.PowerStatue ? "Power On" : "Power Off";
        }

        private void btn_Move_Click(object sender, EventArgs e)
        {
            if(btn_Move.Text=="Move")
            {
                if (!Motor.PowerStatue)
                {
                    MessageBox.Show("the axis is Power off", "提示");
                    return;
                }
                if (Motor.Busy)
                {
                    MessageBox.Show("the axis is moving", "提示");
                    return;
                }
                int mode = cmB_MoveMode.SelectedIndex;
                if (string.IsNullOrEmpty(txt_Distance.Text))
                    return;
                if (!int.TryParse(txt_Distance.Text, out int distance))
                {
                    MessageBox.Show("distance 不为数字", "异常提示");
                    return;
                }
                if(!double.TryParse(txt_MaxSpeed.Text,out double vm))
                {
                    MessageBox.Show("移动速度 格式不正确", "异常提示");
                    return;
                }
                Motor.MoveVM = vm;
                _moveCancelTokenSource = new CancellationTokenSource();
                switch (mode)
                {
                    case 0://绝对运动
                        _taskMove = new Task(() => {Task t= Motor.AbsMoveAsync(distance);t.Wait(); }, _moveCancelTokenSource.Token);
                        
                        break;
                    case 1://相对运动
                        _taskMove = new Task(() => { Task t = Motor.RelMoveAsync(distance); ; t.Wait(); }, _moveCancelTokenSource.Token);
                        
                        break;
                }
                _taskMove.Start();
                btn_Move.Text = "Stop";
                Task.Run(new Action(() =>
                {
                    while (true)
                    {
                        if (_taskMove.IsCompleted)
                        {
                            btn_Move.BeginInvoke(new Action(() => { btn_Move.Text = "Move"; }));
                            break;
                        }
                        Thread.Sleep(100);
                    }

                }));
            }
           else
            {
                if (_taskMove.Status == TaskStatus.Running)
                {
                    _moveCancelTokenSource.Cancel();
                    Motor.Stop();
                }
                btn_Move.Text = "Move";
            }
        }
    }
}
