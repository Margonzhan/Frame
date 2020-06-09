using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fram.Config;
using Fram.Hardware;
namespace Fram.FormFolder
{
    internal partial class FormIO : UserControl
    {
        Timer Timer = new Timer();
        int InputCurrentPage = 1;
        int OutputCurrentPage = 1;
        const int PageCount = 18;
        Dictionary<string, Hardware.IOBaseDevice.SingleIoDevice> Inputs = new Dictionary<string, Hardware.IOBaseDevice.SingleIoDevice>();
        Dictionary<string, Hardware.IOBaseDevice.SingleIoDevice> Outputs = new Dictionary<string, Hardware.IOBaseDevice.SingleIoDevice>();

        public FormIO()
        {
            InitializeComponent();
            Timer.Interval = 100;
            Timer.Tick += Timer_Tick;
            this.VisibleChanged += FormIO_VisibleChanged;       
            Init();       
        }

        private void FormIO_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                RefrushOutput();
                Timer.Start();
            }               
            else
                Timer.Stop();
        }

        public void StartReadIO()
        {
            Timer.Start();
        }
        public void StopReadIO()
        {
            Timer.Stop();
        }
    

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.Visible)
                foreach (var mem in tLPanel_Input2.Controls)
                {
                    Button _button = (Button)mem;
                    if (_button != null)
                    {
                        _button.Image = Inputs[_button.Text].GetStatue() ? global::Fram.Properties.Resources.led_on : global::Fram.Properties.Resources.led_off;
                    }
                }
            else
                Timer.Stop();
            
        }

        private void Init()
        {
            foreach(var mem in IoDeviceManager.Instance.IODeviceS)
            {
                if (mem.Value.Enable && mem.Value.IsShow)
                {
                    if (mem.Value.IsInput)
                        Inputs.Add(mem.Key, mem.Value);
                    else
                        Outputs.Add(mem.Key, mem.Value);
                }
       
            }
            if(Inputs.Count> PageCount)
            {
                for(int i=0;i< PageCount; i++)
                {
                    Button _button = new Button();
                    _button.TextImageRelation = TextImageRelation.ImageBeforeText;
                    _button.TextAlign = ContentAlignment.MiddleLeft;
                    _button.Dock = DockStyle.Left;
                    _button.Image = global::Fram.Properties.Resources.led_off;
                    _button.Text = Inputs.ElementAt(i).Value.DeviceName;
                    _button.Width = 200;
                    _button.Height = 50;
                    tLPanel_Input2.Controls.Add(_button, i / (PageCount/2), i % (PageCount/2));
                }
                btn_InputLastPage.Enabled = false;
                btn_InputNextPage.Enabled = true;
            }
            else
            {
                for (int i = 0; i < Inputs.Count; i++)
                {
                    Button _button = new Button();
                    _button.TextImageRelation = TextImageRelation.ImageBeforeText;
                    _button.TextAlign = ContentAlignment.MiddleLeft;
                    _button.Image = global::Fram.Properties.Resources.led_off;
                    _button.Dock = DockStyle.Left;
                    _button.Text = Inputs.ElementAt(i).Value.DeviceName;
                    _button.Width = 200;
                    _button.Height = 50;
                    tLPanel_Input2.Controls.Add(_button, i / (PageCount/2), i % (PageCount/2));
                }
                btn_InputLastPage.Enabled = false;
                btn_InputNextPage.Enabled = false;
            }
            if (Outputs.Count > PageCount)
            {
                for (int i = 0; i < PageCount; i++)
                {
                    Button _button = new Button();
                    _button.TextImageRelation = TextImageRelation.ImageBeforeText;
                    _button.TextAlign = ContentAlignment.MiddleLeft;
                    _button.Dock = DockStyle.Left;
                    _button.Click += Button_Click;
                    _button.Image = Outputs.ElementAt(i).Value.GetStatue() ? global::Fram.Properties.Resources.led_on : global::Fram.Properties.Resources.led_off;
                    _button.Text = Outputs.ElementAt(i).Value.DeviceName;
                    _button.Width = 200;
                    _button.Height = 50;
                    tLPanel_Output2.Controls.Add(_button, i / (PageCount / 2), i % (PageCount / 2));
                }
                btn_OutputLastPage.Enabled = false;
                btn_OutputNextPage.Enabled = true;
            }
            else
            {
                for (int i = 0; i < Outputs.Count; i++)
                {
                    Button _button = new Button();
                    _button.TextImageRelation = TextImageRelation.ImageBeforeText;
                    _button.TextAlign = ContentAlignment.MiddleLeft;
                    _button.Image = Outputs.ElementAt(i).Value.GetStatue()? global::Fram.Properties.Resources.led_on: global::Fram.Properties.Resources.led_off;
                    _button.Dock = DockStyle.Left;
                    _button.Click += Button_Click;
                    _button.Text = Outputs.ElementAt(i).Value.DeviceName;
                    _button.Width = 200;
                    _button.Height = 50;
                    tLPanel_Output2.Controls.Add(_button, i / (PageCount / 2), i % (PageCount / 2));
                }
                btn_OutputLastPage.Enabled = false;
                btn_OutputNextPage.Enabled = false;
            }

        }

        private void btn_InputLastPage_Click(object sender, EventArgs e)
        {
            Timer.Stop();
            InputCurrentPage--;
            tLPanel_Input2.Controls.Clear();
            for(int i=0 ; i<PageCount; i++)
            {
                Button _button = new Button();
                _button.TextImageRelation = TextImageRelation.ImageBeforeText;
                _button.TextAlign = ContentAlignment.MiddleLeft;
                _button.Image = global::Fram.Properties.Resources.led_off;
                _button.Dock = DockStyle.Left;
                _button.Text = Inputs.ElementAt(i+ (InputCurrentPage-1) * PageCount).Value.DeviceName;
                _button.Width = 200;
                _button.Height = 50;
                tLPanel_Input2.Controls.Add(_button, i / (PageCount / 2), i % (PageCount / 2));
            }
            btn_InputLastPage.Enabled = InputCurrentPage>1?true:false;
            btn_InputNextPage.Enabled = true;
            Timer.Start();
        }

        private void btn_InputNextPage_Click(object sender, EventArgs e)
        {
            Timer.Stop();
            tLPanel_Input2.Controls.Clear();
            if(Inputs.Count>(InputCurrentPage+1)*PageCount)
            {
                for (int i = 0; i < PageCount; i++)
                {
                    Button _button = new Button();
                    _button.TextImageRelation = TextImageRelation.ImageBeforeText;
                    _button.TextAlign = ContentAlignment.MiddleLeft;
                    _button.Image = global::Fram.Properties.Resources.led_off;
                    _button.Dock = DockStyle.Left;
                    _button.Text = Inputs.ElementAt(i + InputCurrentPage * PageCount).Value.DeviceName;
                    _button.Width = 200;
                    _button.Height = 50;
                    tLPanel_Input2.Controls.Add(_button, i / (PageCount / 2), i % (PageCount / 2));
                }
                btn_InputNextPage.Enabled = true;
            }
           else
            {
                for (int i = 0; i < Inputs.Count%PageCount; i++)
                {
                    Button _button = new Button();
                    _button.TextImageRelation = TextImageRelation.ImageBeforeText;
                    _button.TextAlign = ContentAlignment.MiddleLeft;
                    _button.Image = global::Fram.Properties.Resources.led_off;
                    _button.Dock = DockStyle.Left;
                    _button.Text = Inputs.ElementAt(i + InputCurrentPage * PageCount).Value.DeviceName;
                    _button.Width = 200;
                    _button.Height = 50;
                    tLPanel_Input2.Controls.Add(_button, i / (PageCount / 2), i % (PageCount / 2));
                }
                btn_InputNextPage.Enabled = false;
            }

            btn_InputLastPage.Enabled = true ;
            InputCurrentPage++;
            Timer.Start();
        }

        private void btn_OutputLastPage_Click(object sender, EventArgs e)
        {
            OutputCurrentPage--;
            tLPanel_Output2.Controls.Clear();
            for (int i = 0; i < PageCount; i++)
            {
                Button _button = new Button();
                _button.TextImageRelation = TextImageRelation.ImageBeforeText;
                _button.TextAlign = ContentAlignment.MiddleLeft;
                _button.Image = Outputs.ElementAt(i + (OutputCurrentPage - 1) * PageCount).Value.GetStatue() ? global::Fram.Properties.Resources.led_on : global::Fram.Properties.Resources.led_off;
                _button.Dock = DockStyle.Left;
                _button.Click += Button_Click;
                _button.Text = Outputs.ElementAt(i + (OutputCurrentPage - 1) * PageCount).Value.DeviceName;
                _button.Width = 200;
                _button.Height = 50;
                tLPanel_Output2.Controls.Add(_button, i / (PageCount / 2), i % (PageCount / 2));
            }
            btn_OutputLastPage.Enabled = OutputCurrentPage > 1 ? true : false;
            btn_OutputNextPage.Enabled = true;
        }

        private void btn_OutputNextPage_Click(object sender, EventArgs e)
        {
            tLPanel_Output2.Controls.Clear();
            if (Outputs.Count > (OutputCurrentPage + 1) * PageCount)
            {
                for (int i = 0; i < PageCount; i++)
                {
                    Button _button = new Button();
                    _button.TextImageRelation = TextImageRelation.ImageBeforeText;
                    _button.TextAlign = ContentAlignment.MiddleLeft;
                    _button.Image = Outputs.ElementAt(i + OutputCurrentPage * PageCount).Value.GetStatue() ? global::Fram.Properties.Resources.led_on : global::Fram.Properties.Resources.led_off;
                    _button.Dock = DockStyle.Left;
                    _button.Click += Button_Click;
                    _button.Text = Outputs.ElementAt(i + OutputCurrentPage * PageCount).Value.DeviceName;
                    _button.Width = 200;
                    _button.Height = 50;
                    tLPanel_Output2.Controls.Add(_button, i / (PageCount / 2), i % (PageCount / 2));
                }
                btn_OutputNextPage.Enabled = true;
            }
            else
            {
                for (int i = 0; i < Outputs.Count % PageCount; i++)
                {
                    Button _button = new Button();
                    _button.TextImageRelation = TextImageRelation.ImageBeforeText;
                    _button.TextAlign = ContentAlignment.MiddleLeft;
                    _button.Image = Outputs.ElementAt(i + InputCurrentPage * PageCount).Value.GetStatue() ? global::Fram.Properties.Resources.led_on : global::Fram.Properties.Resources.led_off;
                    _button.Dock = DockStyle.Left;
                    _button.Click += Button_Click;
                    _button.Text = Outputs.ElementAt(i + InputCurrentPage * PageCount).Value.DeviceName;
                    _button.Width = 200;
                    _button.Height = 50;
                    tLPanel_Output2.Controls.Add(_button, i / (PageCount / 2), i % (PageCount / 2));
                }
                btn_OutputNextPage.Enabled = false;
            }

            btn_OutputLastPage.Enabled = true;
            OutputCurrentPage++;
        }
        private void Button_Click(object sender,EventArgs e)
        {
            Button button = (Button)sender;
            bool nowstatue = Outputs[button.Text].GetStatue();
            Outputs[button.Text].SetStatue(!nowstatue);
            button.Image = !nowstatue ? global::Fram.Properties.Resources.led_on : global::Fram.Properties.Resources.led_off;
        }
        private void RefrushOutput()
        {
            foreach(var mem in tLPanel_Output2.Controls)
            {
                if(mem is Button)
                {
                    Button button = (Button)mem;
                    bool nowstatue = Outputs[button.Text].GetStatue();
                    button.Image = nowstatue ? global::Fram.Properties.Resources.led_on : global::Fram.Properties.Resources.led_off;
                }
            }
        }
    }
}
