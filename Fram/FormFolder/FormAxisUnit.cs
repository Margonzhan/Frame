using Fram.Hardware.LogicAxisUnite;
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
    public partial class FormAxisUnit : Form
    {
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

        }
    }
}
