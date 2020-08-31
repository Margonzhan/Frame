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
using Fram.Hardware.LogicAxisUnite;
using Fram.Properties;

namespace Fram.FormFolder
{
    public partial class FormAuto : UserControl
    {  
        public FormAuto()
        {
            InitializeComponent();
            GloableObject.Instance.MachineStatueControl.MachineStatueChangeHandle += MachineStatueControl_MachineStatueChangeHandle;
          //  LogicAxisUnitManager.Instance.LogicAxisUnitS["test"].LoadPoint();
        }

        private void MachineStatueControl_MachineStatueChangeHandle(object sender, MachineStatueChangeEventArgs e)
        {
           switch(e.MachineStatue)
            {
                case MachineStatue.EMERGENCYSTOPING:
                    StationManager.Instance.StopAll();

                    break;
                case MachineStatue.RESETING:
                    StationManager.Instance.ResumeAll();
                    break;
                case MachineStatue.RUNNING:
                    break;
                case MachineStatue.STOPING:
                    break;
                case MachineStatue.SUSPENDING:
                    break;
                case MachineStatue.WAITINGINIT:
                    break;
                case MachineStatue.WAITINGRUN:
                    break;
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if(btn_Start.Text=="开始")
            {
                StationManager.Instance.StartAll();
                btn_Start.Text = "停止";
                btn_Start.BackgroundImage = Resources.stop;
            }
            else
            {
                StationManager.Instance.StopAll();
                btn_Start.Text = "开始";
                btn_Start.BackgroundImage = Resources.start;
                
            }
        }
    }
   
}
