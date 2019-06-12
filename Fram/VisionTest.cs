using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonTool;
namespace Fram
{
    public partial class VisionTest : Form
    {
        public VisionTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SystemTool.ShowInfo("nihao\r\n");
        }
    }
}
