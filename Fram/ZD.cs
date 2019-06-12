using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Connection;
using VisionTool;
using System.IO.Ports;
using System.Threading;
using FileOperate;
using HalconDotNet;
using CommonTool;
namespace Fram
{
    public partial class ZD : Form
    {
        public TcpConnect tcpclient = new TcpConnect("1", "127.0.0.1", 8100, 1000);
        public Thread thread;

        public ZD()
        {
            InitializeComponent();   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SystemTool.ShowInfo += message;
            thread = new Thread(func);
            if (! tcpclient.Connection())
            {
                MessageBox.Show("未连接上");
               
                thread.Start();
                Application.Exit();
            }
           
           
        }
      

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread.IsAlive)
            {
                thread.Abort();
            }
            tcpclient.Close();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            double[] x = { 15, 20, 25 };
            double[] y = { 20, 25, 20 };
            double x1, y1;
            Calibration.ThreePToCircle(x, y, out x1, out y1);
        }
        public void func()
        {
            string str;
            while (true)
            {
                if (tcpclient.ReadLine(out str))
                {
                    if (richTextBox1.InvokeRequired)
                    {
                        Action delegate1 = () => { richTextBox1.Text = str; };
                        richTextBox1.Invoke(delegate1);
                    }
                }
            }
        }

        
        /********************************用于在富文本中显示消息*********************************/
        public void message(string str)
        {
            DateTime time = DateTime.Now;
            richTextBox1.Text = time.Date+time.TimeOfDay+":  "+str+richTextBox1.Text;
        }

        private void 视觉ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisionTest frm = new VisionTest();
            frm.Show();
        }
        
    }
}
