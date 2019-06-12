using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Fram
{
    public partial class FormLoading : Form
    {
        Thread t;
        private static FormLoading m_instance;
        private static readonly object m_lock = new object();
        public FormLoading()
        {
            InitializeComponent();
            t = new Thread(Loading);
            t.IsBackground = true;
            // this.TransparencyKey = Color.FromArgb(34, 32, 33);//自行车图案隐藏背景色
            this.TransparencyKey = Color.FromArgb(255, 255, 255);
        }
        private void Loading()
        {
            base.ShowDialog();
        }

        public new void ShowDialog()
        {
            t.Start();
        }
        public static FormLoading GetInstance()
        {
            if (m_instance == null)
            {
                lock (m_lock)
                {
                    m_instance = new FormLoading();
                }
            }
            return m_instance;
        }
        new public void Closed()
        {
            if (m_instance == null)
            {
                return;
            }
            else
            {
                if (m_instance.InvokeRequired)
                {
                    m_instance.Invoke(new Action(() => { m_instance.Close(); }));
                }
                else
                    m_instance.Close();
            }
        }
    }
}
