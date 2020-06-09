using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fram.Config;
using Fram.Hardware;
using HalconDotNet;
namespace Fram.FormFolder
{
    public partial class FormVision : UserControl
    {
        HObject m_image;
        CLCamera.CameraBase m_camera;
        Task m_taskCameraPaly;
        System.Threading.CancellationTokenSource cancellationTokenSource;
        public FormVision()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            nmUD_CameraExpourse.ValueChanged += UpdateCameraParam;
            nmUD_CameraGain.ValueChanged += UpdateCameraParam;
            foreach (var mem in CameraManager.Instance.Cameras)
            {
                cmB_Camera.Items.Add(mem.Key);
            }
            if(cmB_Camera.Items.Count>0)
            {
              //  m_camera = CameraManager.Instance.Cameras[cmB_Camera.Items[0].ToString()];
                cmB_Camera.SelectedItem = 0;
            }
            else
            {
                nmUD_CameraExpourse.Enabled = false;
                nmUD_CameraGain.Enabled = false;
                btn_GrabContinue.Enabled = false;
                btn_GrabOnce.Enabled = false;
            }
        }
        private void btn_GrabOnce_Click(object sender, EventArgs e)
        {
            m_image = m_camera.SnapShot();
            hDisplay1.HImageX = m_image;
        }

        private void cmB_Camera_SelectedIndexChanged(object sender, EventArgs e)
        {          
            m_camera= CameraManager.Instance.Cameras[cmB_Camera.SelectedItem.ToString()];
            try
            {
                nmUD_CameraExpourse.Value = (decimal)m_camera.GetExpourseTime();
                nmUD_CameraGain.Value = (decimal)m_camera.GetGain();
            }
            catch (Exception ex)
            {

            }
            
            nmUD_CameraExpourse.Enabled = nmUD_CameraExpourse.Value != 0 ? true : false;
            nmUD_CameraGain.Enabled = nmUD_CameraGain.Value != 0 ? true : false;
        }
        private void UpdateCameraParam(object sender,EventArgs e)
        {
            try
            {
                m_camera.SetExpourseTime((uint)nmUD_CameraExpourse.Value);
                m_camera.SetGain((uint)nmUD_CameraGain.Value);
            }
            catch (Exception ex)
            {

            }
            
        }

        private void btn_GrabContinue_Click(object sender, EventArgs e)
        {
            if(btn_GrabContinue.Text=="视频播放")
            {
                cancellationTokenSource = new System.Threading.CancellationTokenSource();
                m_taskCameraPaly = new Task(() => 
                {
                    while(!cancellationTokenSource.IsCancellationRequested)
                    {
                        m_image = m_camera.SnapShot();
                        hDisplay1.BeginInvoke(new Action(() => { hDisplay1.HImageX = m_image; }));
                        System.Threading.Thread.Sleep(10);
                    }                                                        
                }, cancellationTokenSource.Token);
                m_taskCameraPaly.Start();
                btn_GrabContinue.Text = "停止";
                btn_GrabOnce.Enabled = false;
            }
            else
            {
                cancellationTokenSource.Cancel();
                btn_GrabContinue.Text = "视频播放";
                btn_GrabOnce.Enabled = true ;
            }
        }
    }
}
