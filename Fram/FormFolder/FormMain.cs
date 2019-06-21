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

        NetClientConnection _client;
        IOCard.EMC0064 EMC0064;
      //  HaiKangCamera hk = new HaiKangCamera("camera1", CameraConnectType.GigEVision);
        public FormMain()
        {
            FormLoading.GetInstance().ShowDialog();
            InitializeComponent();
            Thread.Sleep(3000);
            Init();
            FormLoading.GetInstance().Closed();
            //_client = new NetClientConnection("127.0.0.1", 8080);
            //_client.ReConnect();
            EMC0064 = new IOCard.EMC0064();

        }
        private void Init()
        {
            
        }
        private void ProcessLoading()
        {
            FormLoading.GetInstance().ShowDialog();
        }

        void hk_ImageAcquired(object sender, ImageEventArgs<HObject> e)
        {
            HObject image=new HObject();
           // HOperatorSet.InvertImage(e.image, out image);
         //   ocrControl1.BackImage = e.image.Clone();
        }

      

       

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
           // hk.CloseCamera();
        }
        XMLFile xMLFile = new XMLFile();
        private void button1_Click(object sender, EventArgs e)
        {
            //EMC0064.Open();
            HardWareConfigrationMuster hardWareConfigrationMuster = new HardWareConfigrationMuster();
           // IoCardConfig[] ioCardConfigs = new IoCardConfig[2] ;
            IoCardConfig ioCardConfig1 = new IoCardConfig();
            IoCardConfig ioCardConfig2 = new IoCardConfig();
            hardWareConfigrationMuster.IoCardConfigs.Add( ioCardConfig1);
            hardWareConfigrationMuster.IoCardConfigs.Add( ioCardConfig2);
            var settings = new Newtonsoft.Json. JsonSerializerSettings();
            settings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(hardWareConfigrationMuster, Newtonsoft.Json.Formatting.Indented,settings);
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
