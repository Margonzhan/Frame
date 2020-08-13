using Fram.Config;
using Fram.FormFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO.Ports;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fram.Station;
using Fram.Hardware.LogicAxisUnite;

namespace Fram
{
    public partial class FormMain : Form
    {
        FormIO formIO ;
        FormVision formVision;
        FormAxis formAxis;

        ConfigManager configManager;
        Hardware.IoCardManager IoCardManager;
        Hardware.IoDeviceManager IoDeviceManager;
        Hardware.CameraManager CameraManager;
        Hardware.MotionCardManager MotionCardManager;
        Hardware.AxisManager AxisManager;
        LogicAxisUnitManager LogicAxisUnitManager;

        public FormMain()
        {
            
            FormLoading.GetInstance().ShowDialog();
            InitializeComponent();          
            this.Text += $"   V{Assembly.GetExecutingAssembly().GetName().Version}";
            
            Init();         
            FormLoading.GetInstance().Closed();
            
            this.WindowState = FormWindowState.Maximized;          
            this.Show();
        }
        private void Init()
        {
            configManager = ConfigManager.Instance;
            MotionCardManager = Hardware.MotionCardManager.Instance;
            IoCardManager = Hardware.IoCardManager.Instance;
            IoDeviceManager = Hardware.IoDeviceManager.Instance;
            CameraManager = Hardware.CameraManager.Instance;
            AxisManager = Hardware.AxisManager.Instance;
            LogicAxisUnitManager = Hardware.LogicAxisUnite.LogicAxisUnitManager.Instance;
          //  GloablObject.Instance.Init();
          //Stationtest stationtest = new Stationtest("test");
          //StationManager.Instance.StationDictionry.Add(stationtest.StationName, stationtest);
          //StationManager.Instance.InitAll();


            DelegateUIControl.Instance.RichTxtBoxZdS.Add("FormMain_RichTBoxZD_Log", this.rTBZD_Log);
            try
            {
                if (IoDeviceManager.IODeviceS.Count > 0)
                {
                    formIO = new FormIO();
                    formIO.Dock = DockStyle.Fill;
                    tabNavigationPage_IoDevice.Controls.Add(formIO);
                }
                else
                {
                    tabNavigationPage_IoDevice.PageVisible = false;
                }

                if (CameraManager.Cameras.Count > 0)
                {
                    formVision = new FormVision();
                    formVision.Dock = DockStyle.Fill;
                    tabNavigationPage_Cameras.Controls.Add(formVision);
                }
                else
                {
                    tabNavigationPage_Cameras.PageVisible = false;
                }

                FormAxisUnit formAxisUnit = new FormAxisUnit();
                formAxisUnit.Dock = DockStyle.Fill;
                tabNavigationPage_LogicAxisUnit.Controls.Add(formAxisUnit);

                if (AxisManager.AxisDeviceS.Count > 0)
                {
                    formAxis = new FormAxis();
                    formAxis.Dock = DockStyle.Fill;
                    tabNavigationPage_AxisDevice.Controls.Add(formAxis);
                    tabNavigationPage_AxisDevice.PageVisible = true;

                }
                else
                {
                    tabNavigationPage_AxisDevice.PageVisible = false;
                }

                tabPane.SelectedPage = tabPage_Auto;
                tabNagPage_Menu.PageVisible = false;
                foreach (var mem in tabPane_Menu.Pages)
                {
                    if(mem.PageVisible==true)
                    {
                        tabNagPage_Menu.PageVisible = true;
                        break;
                    }
                }
             
                FormAuto formAuto = new FormAuto();
                this.splitContainer1.Panel1.Controls.Add(formAuto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "异常");
                Environment.Exit(0);
            }

        }
    }
    

}
