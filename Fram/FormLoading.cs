using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormLoading : Form
    {
        public FormLoading()
        {
            InitializeComponent();
            this.TransparencyKey = Color.FromArgb(34, 32, 33);
           // pictureBox1.Image = Image.FromFile(@"C:\\Users\\Administrator\\Desktop\\loading01.gif");
            
        }
    }
}
