using System;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using FileOperate;
using HalconDotNet;
using CLCamera;
using HalconModle;
using System.Xml;
using Connection;
using CommonFunc;
using Fram.Config;
using System.Text;
using System.Threading.Tasks;
using Fram.Hardware.MotionCard;
using Fram.Hardware.AxisDevice;
namespace Fram
{
    public partial class FormMain : Form
    {
        FormIO formIO ;
        FormVision formVision;
        ConfigManager configManager;
        Hardware.IoCardManager IoCardManager;
        Hardware.IoDeviceManager IoDeviceManager;
        Hardware.CameraManager CameraManager;
        Hardware.MotionCardManager MotionCardManager;
        ServoMotor stepMotor;
        //  HaiKangCamera hk = new HaiKangCamera("camera1", CameraConnectType.GigEVision);
        public FormMain()
        {
            FormLoading.GetInstance().ShowDialog();
            InitializeComponent();
            configManager = ConfigManager.Instance;
            MotionCardManager = Hardware.MotionCardManager.Instance;
            IoCardManager = Hardware.IoCardManager.Instance;
            IoDeviceManager = Hardware.IoDeviceManager.Instance;
            CameraManager = Hardware.CameraManager.Instance;
            Init();
            Thread.Sleep(3000);
            
            FormLoading.GetInstance().Closed();
            this.WindowState = FormWindowState.Maximized;
            MotionCardBase card = (MotionCardBase)MotionCardManager.GetByKey("amp204c");
            stepMotor = new ServoMotor(card, 0, "server0", new Guid());

        }
        private void Init()
        {
            formIO = new FormIO();
            formIO.Dock = DockStyle.Fill;         
            tabNavigationPage_IoDevice.Controls.Add(formIO);

            formVision = new FormVision();
            formVision.Dock = DockStyle.Fill;
            tabNavigationPage_Cameras.Controls.Add(formVision);

            tabPane.SelectedPage = tabPage_Auto;
            tabPane_Menu.SelectedPage = tabNavigationPage_IoDevice;
        }
        private void ProcessLoading()
        {
            FormLoading.GetInstance().ShowDialog();
        }



        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
           // hk.CloseCamera();
        }
       
        private async void  button1_Click(object sender, EventArgs e)
        {
            stepMotor.PowerSet(true);
            button3.Enabled = true;
            button2.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }
        private async Task<int> testasync()
        {
          await  Task.Run(() => { Thread.Sleep(5000);MessageBox.Show("111"); });
            return 3;
        }
        private void test()
        {
            
            
        }
        private async void button2_Click(object sender, EventArgs e)
        {
           await stepMotor.HomeAsync(true);
            MessageBox.Show("home over");
        }

        private void tabPane_Menu_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (e.Page == tabNavigationPage_IoDevice)
            {
               
               
            }
            else
            {
               
            }
                
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            stepMotor.RelMoveAsync(10000);
        }
        private async Task thre()
        {
            //if (string.IsNullOrEmpty(textBox1.Text))
            //    return;
            int puls = 100000;// Convert.ToInt32(textBox1.Text);
            int v = 10000;// Convert.ToInt32(textBox2.Text);
            MotionCardBase card = (MotionCardBase)MotionCardManager.GetByKey("amp204c");           
            card.RelMoveAsync(0,  puls);
      
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            stepMotor.JogStart(true);
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            stepMotor.JogStop();
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            stepMotor.JogStart(false);
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            stepMotor.JogStop();
        }
    }
    public class managerrrr : Singleton<managerrrr>
    {
        bool flag = false;
        public managerrrr()
        {
            flag = true;
        }
        public void kkk()
        { }
    }

}
