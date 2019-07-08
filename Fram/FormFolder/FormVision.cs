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
namespace Fram
{
    public partial class FormVision : UserControl
    {
        HObject m_image;
        CLCamera.CameraBase m_camera;
        public FormVision()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            foreach(var mem in CameraManager.Instance.Cameras)
            {
                cmB_Camera.Items.Add(mem.Key);
            }
            if(cmB_Camera.Items.Count>0)
                m_camera = CameraManager.Instance.Cameras[cmB_Camera.Items[0].ToString()];
        }
        private void btn_GrabOnce_Click(object sender, EventArgs e)
        {
            m_image = m_camera.SnapShot();
            hDisplay1.HImageX = m_image;
        }

        private void cmB_Camera_SelectedIndexChanged(object sender, EventArgs e)
        {          
            m_camera= CameraManager.Instance.Cameras[cmB_Camera.SelectedItem.ToString()];
        }
    }
}
