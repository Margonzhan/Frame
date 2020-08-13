using DevExpress.XtraCharts.Designer.Native;
using Fram.Hardware.AxisDevice;
using Fram.Hardware.LogicAxisUnite;
using Fram.PrivateControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fram.FormFolder
{
    public partial class FormAxisUnit : UserControl
    {
        LogicAxisUnit logicAxisUnit;
        public FormAxisUnit()
        {
            InitializeComponent();
            foreach (var mem in LogicAxisUnitManager.Instance.LogicAxisUnitS)
            {
                cmb_AxisUnitName.Items.Add(mem.Key);
            }
        }

        private void cmb_AxisUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            dGV_PointsName.Rows.Clear();
            string unitName = cmb_AxisUnitName.Text;
            logicAxisUnit = LogicAxisUnitManager.Instance.GetByKey(unitName);
            foreach(var mem in logicAxisUnit.AxisUnitPoints)
            {
                DataGridViewRow dataGridViewRow = dGV_PointsName.RowTemplate;
                
                dataGridViewRow.Cells[0].Value = mem.Key;
                dGV_PointsName.Rows.Add(dataGridViewRow);
            }
            flowLayoutPanel1.Controls.Clear();
            dGV_PointInfo.Rows.Clear();
            foreach (var mem in logicAxisUnit.AxisDeviceS)
            {
              
                AxisControlZd axisControlZd = new AxisControlZd(mem.Value);
                flowLayoutPanel1.Controls.Add(axisControlZd);

                
                dGV_PointInfo.Rows.Add();             
                dGV_PointInfo.Rows[dGV_PointInfo.Rows.Count-1].Cells[1].Value = mem.Value.DeviceName;
                dGV_PointInfo.Rows[dGV_PointInfo.Rows.Count-1].Cells[2].Value = mem.Value.Motor.MoveVM;
                dGV_PointInfo.Rows[dGV_PointInfo.Rows.Count - 1].Cells[3].Value="2";
                dGV_PointInfo.Rows[dGV_PointInfo.Rows.Count - 1].Cells[4].Value = 0;
            }

            this.ResumeLayout(true);
        }

        private void dGV_PointsName_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           string pointName=  dGV_PointsName.Rows[e.RowIndex].Cells[0].Value.ToString();
           AxisUnitPoint axisUnitPoint= logicAxisUnit.GetPointByKey(pointName);

        }
    }
}
