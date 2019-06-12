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
namespace Fram
{
    public partial class FormMain : Form
    {

        NetClientConnection _client;
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
            try
            {
                // _client.SendString(DateTime.Now.ToString("yyyy_MM_dd  hh:mm:ss"));
                _client.HeartBeatEnable = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _client.HeartBeatKey = "123456";
            _client.HeartBeatTimeSpan = 3000;
            _client.HeartBeatEnable = true;
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
