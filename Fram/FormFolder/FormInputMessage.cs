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
    public partial class FormInputMessage : Form
    {
        public string RtnInfo { get; private set; }
        public FormInputMessage(string formInfo)
        {
            InitializeComponent();
            this.label1.Text = formInfo + ": ";
        }

        private void txt_Message_TextChanged(object sender, EventArgs e)
        {
            RtnInfo = txt_Message.Text;
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            return;
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            return;
        }
    }
}
