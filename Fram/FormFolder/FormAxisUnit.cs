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
            dGV_PointsName.RowEnter -= dGV_PointsName_RowEnter;
            dGV_PointsName.Rows.Clear();
            string unitName = cmb_AxisUnitName.Text;
            logicAxisUnit = LogicAxisUnitManager.Instance.GetByKey(unitName);
            foreach(var mem in logicAxisUnit.AxisUnitPoints)
            {
                dGV_PointsName.Rows.Add();
                dGV_PointsName.Rows[dGV_PointsName.Rows.Count - 1].Cells[0].Value = mem.Key;
                
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
                dGV_PointInfo.Rows[dGV_PointInfo.Rows.Count - 1].Cells[3].Value="1";
                dGV_PointInfo.Rows[dGV_PointInfo.Rows.Count - 1].Cells[4].Value = 0;
            }
            dGV_PointsName.RowEnter += dGV_PointsName_RowEnter;
            this.ResumeLayout(true);
            
        }

        private void dGV_PointsName_RowEnter(object sender, DataGridViewCellEventArgs e)
        {        
           string pointName=  dGV_PointsName.Rows[e.RowIndex].Cells[0].Value.ToString();
            RefrushPointInfo(pointName);

        }

        private void btn_CreateNewPoint_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(cmb_AxisUnitName.Text))
            {
                MessageBox.Show("请先选择轴单元", "提示");
                return;
            }
            using (FormInputMessage formInputMessage = new FormInputMessage("点位名称"))
            {
                
                if (formInputMessage.ShowDialog()==DialogResult.OK)
                {
                    dGV_PointsName.RowEnter -= dGV_PointsName_RowEnter;
                    string pointName = formInputMessage.RtnInfo;
                    dGV_PointsName.Rows.Add();
                    dGV_PointsName.Rows[dGV_PointsName.Rows.Count - 1].Cells[0].Value = pointName;
                    dGV_PointsName.Rows[dGV_PointsName.Rows.Count-1].Selected = true;

                    RefrushPointInfo(string.Empty);

                    AddNewPoint(pointName);

                    dGV_PointsName.RowEnter += dGV_PointsName_RowEnter;
                }
            }
        }

        private void RefrushPointInfo(string pointName)
        {
            if(string.IsNullOrEmpty(pointName))//新建点位时，只需要刷新轴的位置信息
            {
                foreach(DataGridViewRow mem in dGV_PointInfo.Rows)
                {
                    double axisCurrentP = 0;
                    logicAxisUnit.AxisDeviceS[mem.Cells[1].Value.ToString()].Motor.GetAxisCPoint(ref axisCurrentP);
                    mem.Cells[4].Value = axisCurrentP;
                }
            }
            else
            {
                if(logicAxisUnit.AxisUnitPoints.ContainsKey(pointName))
                {
                    foreach (DataGridViewRow mem in dGV_PointInfo.Rows)
                    {

                        AxisPoint axisPoint = logicAxisUnit.AxisUnitPoints[pointName].AxisPoints.Find(x => x.LogicAxisName == mem.Cells[1].Value.ToString());
                        mem.Cells[0].Value = axisPoint.IsMove;
                        mem.Cells[2].Value = axisPoint.Speed;
                        mem.Cells[3].Value = axisPoint.MoveIndex.ToString();
                        mem.Cells[4].Value = axisPoint.Position;
                    }
                }
            }
        }

        private void AddNewPoint(string pointName)
        {
            if(logicAxisUnit.AxisUnitPoints.ContainsKey(pointName))
            {
                MessageBox.Show("当前点位已存在");
                return;
            }

            AxisUnitPoint axisUnitPoint = new AxisUnitPoint();
            axisUnitPoint.AxisUnitName = pointName;
            foreach(DataGridViewRow mem in dGV_PointInfo.Rows)
            {
                AxisPoint axisPoint = new AxisPoint();
                axisPoint.IsMove = (bool)((DataGridViewCheckBoxCell)mem.Cells[0]).FormattedValue;
                axisPoint.LogicAxisName = mem.Cells[1].Value.ToString();
                axisPoint.Speed = uint.Parse(mem.Cells[2].Value.ToString());
                axisPoint.MoveIndex = uint.Parse(mem.Cells[3].Value.ToString());
                axisPoint.Position = double.Parse(mem.Cells[4].Value.ToString());
                axisUnitPoint.AxisPoints.Add(axisPoint);
            }
            logicAxisUnit.AxisUnitPoints.Add(pointName, axisUnitPoint);
        }

        private void btn_SavePoint_Click(object sender, EventArgs e)
        {
            logicAxisUnit.SavePoint();
        }

        private void btn_DeletePoint_Click(object sender, EventArgs e)
        {
            if(dGV_PointsName.SelectedRows.Count>0)
            {
                if(MessageBox.Show("确认删除当前点位？","提示",MessageBoxButtons.YesNo)!=DialogResult.Yes)
                {
                    return;
                }
                DataGridViewRow dataGridViewRow = dGV_PointsName.SelectedRows[0];
                string pointName=  dataGridViewRow.Cells[0].Value.ToString();
                dGV_PointsName.Rows.Remove(dataGridViewRow);
                logicAxisUnit.AxisUnitPoints.Remove(pointName);
            }
        }

        private void btn_ClearAllPoint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除全部点位？", "提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            dGV_PointsName.Rows.Clear();
            logicAxisUnit.AxisUnitPoints.Clear();
        }

        private void btn_UpdatePointInfo_Click(object sender, EventArgs e)
        {
            RefrushPointInfo(string.Empty);
            DataGridViewRow dataGridViewRow = dGV_PointsName.CurrentRow;
            string pointName = dataGridViewRow.Cells[0].Value.ToString();
            AxisUnitPoint axisUnitPoint = logicAxisUnit.AxisUnitPoints[pointName];
            foreach (DataGridViewRow mem in dGV_PointInfo.Rows)
            {
                AxisPoint axisPoint = logicAxisUnit.AxisUnitPoints[pointName].AxisPoints.Find(x => x.LogicAxisName == mem.Cells[1].Value.ToString());
                axisPoint.IsMove = (bool)((DataGridViewCheckBoxCell)mem.Cells[0]).FormattedValue;
                axisPoint.LogicAxisName = mem.Cells[1].Value.ToString();
                axisPoint.Speed = uint.Parse(mem.Cells[2].Value.ToString());
                axisPoint.MoveIndex = uint.Parse(mem.Cells[3].Value.ToString());
                axisPoint.Position = double.Parse(mem.Cells[4].Value.ToString());
            }

        }

        private void btn_MoveToPoint_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataGridViewRow = dGV_PointsName.CurrentRow;
            string pointName = dataGridViewRow.Cells[0].Value.ToString();
            Task.Run(() => { logicAxisUnit.MoveToPoint(pointName); });
            
            
        }
    }
}
