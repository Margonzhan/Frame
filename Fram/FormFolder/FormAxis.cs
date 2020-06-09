using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fram.Config;
using Fram.Hardware;
using Fram.PrivateControl;
using Fram.Hardware.AxisDevice;

namespace Fram.FormFolder
{
    public partial class FormAxis : UserControl
    {
        public FormAxis()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            foreach(var mem in AxisManager.Instance.AxisDeviceS)
            {
                StepMotor motor = (StepMotor)mem.Value;
                AxisControlZd axisControlZd = new AxisControlZd(motor);
                flowLayoutPanel1.Controls.Add(axisControlZd);
            }
        }
    }
}
