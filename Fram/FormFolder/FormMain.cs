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

namespace Fram
{
    public partial class FormMain : Form
    {
        FormIO formIO = new FormIO();
        ConfigManager configManager;
        Hardware.IoCardManager IoCardManager;
        Hardware.IoDeviceManager IoDeviceManager;
        Hardware.CameraManager CameraManager;
        //  HaiKangCamera hk = new HaiKangCamera("camera1", CameraConnectType.GigEVision);
        public FormMain()
        {
            FormLoading.GetInstance().ShowDialog();
            InitializeComponent();
            configManager = ConfigManager.Instance;
            IoCardManager = Hardware.IoCardManager.Instance;
            IoDeviceManager = Hardware.IoDeviceManager.Instance;
            CameraManager = Hardware.CameraManager.Instance;
            Init();
            Thread.Sleep(3000);
            
            FormLoading.GetInstance().Closed();
            this.WindowState = FormWindowState.Maximized;
           

        }
        private void Init()
        {          
            formIO.Dock = DockStyle.Fill;
            formIO.TopLevel = false;
            tabNavigationPage_IoDevice.Controls.Add(formIO);
            formIO.Show();


        }
        private void ProcessLoading()
        {
            FormLoading.GetInstance().ShowDialog();
        }



        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
           // hk.CloseCamera();
        }
        XMLFile xMLFile = new XMLFile();
        private void button1_Click(object sender, EventArgs e)
        {
            var settings = new Newtonsoft.Json.JsonSerializerSettings();
            settings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            string json;
            ConfigContent configContent = new ConfigContent();
            configContent.ConfigFillPath = new string[] { "ConfigFillContent.json", "ConfigFillContent.json" };
            json = Newtonsoft.Json.JsonConvert.SerializeObject(configContent, Newtonsoft.Json.Formatting.Indented, settings);
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Config\\" + "ConfigFillContent.json", json, Encoding.UTF8);

            HardWareConfigrationMuster hardWareConfigrationMuster = new HardWareConfigrationMuster();
           // IoCardConfig[] ioCardConfigs = new IoCardConfig[2] ;
            IoCardConfig ioCardConfig1 = new IoCardConfig();
            IoCardConfig ioCardConfig2 = new IoCardConfig();
            hardWareConfigrationMuster.IoCardConfigs.Add( ioCardConfig1);
            hardWareConfigrationMuster.IoCardConfigs.Add( ioCardConfig2);

            for(int i=0;i<4;i++)
            {
                SingleIoDeviceConfig singleIoDeviceConfig = new SingleIoDeviceConfig();
                singleIoDeviceConfig.DeviceName = "Input" + i.ToString();
                singleIoDeviceConfig.IoIndex = i;
                singleIoDeviceConfig.IsInput = true;
                hardWareConfigrationMuster.singleIoDeviceConfigs.Add(singleIoDeviceConfig);
            }
            
             json = Newtonsoft.Json.JsonConvert.SerializeObject(hardWareConfigrationMuster, Newtonsoft.Json.Formatting.Indented,settings);
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Config\\" + "HardWareConfigration.json", json, Encoding.UTF8);
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigManager configManager = ConfigManager.Instance;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabPane_Menu_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (e.Page == tabNavigationPage_IoDevice)
            {
                formIO.StartReadIO();
            }
            else
            {
                formIO.StopReadIO();
            }
                
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
