using System;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using FileOperate;
using HalconDotNet;
using CLCamera;
using HalconModle;
using System.Xml;
using Communication;
using CommonFunc;
using Fram.Config;
using System.Text;
using System.Threading.Tasks;
using Fram.Hardware.MotionCard;
using Fram.Hardware.AxisDevice;
using DevExpress.XtraCharts;

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
        DataTable ddd;
        private  void  button1_Click(object sender, EventArgs e)
        {
             DataTable data= CSV.OpenCSV("C: \\Users\\test\\Desktop\\untitled5.csv");
            
           // DataTable data = CreateTestDB();
            Series series =  new Series("123",ViewType.Spline);
            
            series.ArgumentScaleType = ScaleType.Qualitative;
            series.ArgumentDataMember = "time";
            series.ValueDataMembers[0] = "data";
            series.DataSource = data;
            chartControl1.Series.Add(series);
            HTuple hTuplex = new HTuple();
            HTuple hTupley = new HTuple();
            for(int i=1;i<data.Rows.Count;i++)
            {
                hTuplex.Append(Convert.ToDouble(data.Rows[i].ItemArray[0]));
                hTupley.Append(Convert.ToDouble(data.Rows[i].ItemArray[1]));
            }
            HOperatorSet.WriteTuple(hTuplex, "C:/Users/test/Desktop/456.tup");
            HOperatorSet.WriteTuple(hTupley, "C:/Users/test/Desktop/123.tup");

            //for (int i = 1; i < data.Rows.Count/1000; i++)
            //{
            //    object k = data.Rows[i].ItemArray[1];
            //    SeriesPoint pt = new SeriesPoint(data.Rows[i].ItemArray[0]);
            //    pt.Values =new double[] { Convert.ToDouble(k)} ;
            //    chartControl1.Series[0].Points.Add(pt);

            //}

            ddd = data;
            MessageBox.Show("readover");
        }
        private DataTable CreateTestDB()
        {
            DataTable _testData = new DataTable();
            _testData.Columns.Add(new DataColumn("time", typeof(string)));
            _testData.Columns.Add(new DataColumn("Power", typeof(decimal)));
            _testData.Columns.Add(new DataColumn("ActulPower", typeof(decimal)));
            Random _rm = new Random();
            for (int i = 0; i < 24; i++)
            {
                DataRow _drNew = _testData.NewRow();
                _drNew["time"] = string.Format("{0}点", i);
                _drNew["Power"] = 250;
                _drNew["ActulPower"] = _rm.Next(2200, 4000);
                _testData.Rows.Add(_drNew);
            }
            return _testData;
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
          // await stepMotor.HomeAsync(true);
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
          //  stepMotor.RelMoveAsync(10000);
        }
        private async Task thre()
        {
            //if (string.IsNullOrEmpty(textBox1.Text))
            //    return;
            int puls = 100000;// Convert.ToInt32(textBox1.Text);
            int v = 10000;// Convert.ToInt32(textBox2.Text);
           // MotionCardBase card = (MotionCardBase)MotionCardManager.GetByKey("amp204c");           
           // card.RelMoveAsync(0,  puls);
      
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
           // stepMotor.JogStart(true);
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
           // stepMotor.JogStop();
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
           // stepMotor.JogStart(false);
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
           // stepMotor.JogStop();
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
