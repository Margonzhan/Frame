using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;
using ViewROI;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using CommonFunc;
namespace TwoDimensionCode
{
    public partial class ReadCode: UserControl
    {
        HObject m_image;
        private Control _form;
        public ReadCode()
        {
            InitializeComponent();
            m_image = new HObject();
            DelegateUIControl.GetInstance().FormSetHDisplay = this.hDisplay1;
           // 
        }

        private void btn_loadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "|*.bmp;*.jpeg;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                HOperatorSet.ReadImage(out m_image, path);              
                DelegateUIControl.GetInstance().UpdateHDisplay("FormSetHDisplay", m_image, null, null);
            }
        }
        public HObject Image
        {
            get { return m_image; }
            set { m_image = value; }
        }
        private void btn_Decode_Click(object sender, EventArgs e)
        {
            

            List<HObject> region = new List<HObject>();
            List<HObject> imageReduced = new List<HObject>();
            region = hDisplay1.GetSearchRegions();
            Time_Meter time_Meter = new Time_Meter();
            foreach (var member in region)
            {
                HObject _iamge = new HObject();
                HOperatorSet.ReduceDomain(m_image, member, out _iamge);
                HOperatorSet.CropDomain(_iamge, out _iamge);
                imageReduced.Add(_iamge);
            }
            
            TDCode tdcode ;         
            CodeResult sss = new CodeResult();
            CodeResult[] results = new CodeResult[] { };
            if (_form is FormDMCodeParam)
            {
                FormDMCodeParam form = (FormDMCodeParam)_form;
                tdcode = new DMCode();

                tdcode.SetCodeParam(form.CodeParameter);
                
                results = tdcode.Decode(imageReduced);
                txt_TimeUse.Text = (time_Meter.TimePass() * 1000).ToString();
            }
            else if (_form is FormQRCodeParam)
            {
                FormQRCodeParam form = (FormQRCodeParam)_form;

                tdcode = new QRCode();
                tdcode.SetCodeParam(form.CodeParameter);
                results = tdcode.Decode(imageReduced);
            }
           
            List<StringX> ss = new List<StringX>();
            List<HalWindow.RegionX> regions = new List<HalWindow.RegionX>();
            foreach (var member in results)
            {
                if (member.code != string.Empty)
                {
                    HTuple area = new HTuple();
                    HTuple row = new HTuple();
                    HTuple column = new HTuple();
                    HOperatorSet.AreaCenter(member.codexld, out area, out row, out column);
                    StringX sx = new StringX(15, false, false);
                    sx.SetString(member.code, (int)row.D, (int)column.D, System.Drawing.Color.Green);
                    ss.Add(sx);
                    HalWindow.RegionX regionX = new HalWindow.RegionX(member.codexld, "green");
                    regions.Add(regionX);
                }
            }
            DelegateUIControl.GetInstance().UpdateHDisplay("FormSetHDisplay", m_image, regions, ss);
           
        }
        public CodeResult[] Decode()
        {          
            
            List<HObject> region = new List<HObject>();
            List<HObject> imageReduced = new List<HObject>();
            region = hDisplay1.GetSearchRegions();
            foreach (var member in region)
            {
                HObject _iamge = new HObject();
                HOperatorSet.ReduceDomain(m_image, member, out _iamge);
                imageReduced.Add(_iamge);
            }
            TDCode tdcode;
            CodeResult sss = new CodeResult();
            CodeResult[] results = new CodeResult[] { };
            if (_form is FormDMCodeParam)
            {
                FormDMCodeParam form = (FormDMCodeParam)_form;
                tdcode = new DMCode();

                tdcode.SetCodeParam(form.CodeParameter);

                results = tdcode.Decode(imageReduced);

            }
            else if (_form is FormQRCodeParam)
            {
                FormQRCodeParam form = (FormQRCodeParam)_form;

                tdcode = new QRCode();
                tdcode.SetCodeParam(form.CodeParameter);
                results = tdcode.Decode(imageReduced);
            }
            return results;
        }
        public CodeResult[] Decode(List<HObject> regions)
        {
            
            List<HObject> imageReduced = new List<HObject>();
            
            foreach (var member in regions)
            {
                HObject _iamge = new HObject();
                HOperatorSet.ReduceDomain(m_image, member, out _iamge);
                imageReduced.Add(_iamge);
            }
            TDCode tdcode;
            CodeResult sss = new CodeResult();
            CodeResult[] results = new CodeResult[] { };
            if (_form is FormDMCodeParam)
            {
                FormDMCodeParam form = (FormDMCodeParam)_form;
                tdcode = new DMCode();

                tdcode.SetCodeParam(form.CodeParameter);

                results = tdcode.Decode(imageReduced);

            }
            else if (_form is FormQRCodeParam)
            {
                FormQRCodeParam form = (FormQRCodeParam)_form;

                tdcode = new QRCode();
                tdcode.SetCodeParam(form.CodeParameter);
                results = tdcode.Decode(imageReduced);
            }
            return results;
        }
        private void cmb_CodeType_TextChanged(object sender, EventArgs e)
        {
            foreach (var member in panel_DecodeParam.Controls)
            {
                panel_DecodeParam.Controls.Remove((Control)member);
                ((Control)member).Dispose();
            }
            if (_form != null)
                _form.Dispose();

            if (cmb_CodeType.Text == "DataMaticECC200")
            {
                try
                {
                    _form = new FormDMCodeParam();
                  
                    panel_DecodeParam.Controls.Add(_form);
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (cmb_CodeType.Text == "QR_Code")
            {
                _form = new FormQRCodeParam();                
                
                panel_DecodeParam.Controls.Add(_form);
            }
        }

        private void btn_AddRoi_Click(object sender, EventArgs e)
        {
            hDisplay1.AddRegion(HalWindow.EnumModelShapeType.Rectangle1, true);
        }
        /// <summary>
        /// 保存读码模板及参数
        /// </summary>
        /// <param name="directory">要保存的文件夹路径</param>
        /// <param name="filename">文件名称，必须后缀名必须为.cp</param>
        public void SaveParam(string directory,string filename)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            if (!filename.EndsWith(".cp"))
            {
                throw new Exception("文件名称的扩展名错误");
            }
            List<object> param = new List<object>();
            param.Add(cmb_CodeType.Text);
            param.Add(hDisplay1.GetROIList());
            if (_form is FormDMCodeParam)
            {
                FormDMCodeParam form = (FormDMCodeParam)_form;
                param.Add(form.CodeParameter);

            }
            else if (_form is FormQRCodeParam)
            {
                FormQRCodeParam form = (FormQRCodeParam)_form;
                param.Add(form.CodeParameter);
            }
            Stream fs= new FileStream(directory+"\\"+filename, FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {              
                bf.Serialize(fs, param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {              
                fs.Close();
            }
          
            
        }
        public void ReadParam(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new Exception("文件不存在");
            }
            if (!filepath.EndsWith(".cp"))
            {
                throw new Exception("不支持的文件类型，请选择.cp类型的文件");
            }
            Stream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                fs.Position = 0;
                List<object> datas=   bf.Deserialize(fs) as List<object>;
                cmb_CodeType.TextChanged -= cmb_CodeType_TextChanged;
                cmb_CodeType.Text = datas[0].ToString();
                
                hDisplay1.SetROIList(datas[1] as System.Collections.ArrayList );
                foreach (Control member in panel_DecodeParam.Controls)
                {
                    panel_DecodeParam.Controls.Remove(member);                   
                }
                if (datas[0].ToString() == "DataMaticECC200")
                {
                    FormDMCodeParam form = new FormDMCodeParam(datas[2] as DMCodeParam);                   
                    _form = form;
                    
                }
                else if (datas[0].ToString() == "")
                {
                    FormQRCodeParam form = new FormQRCodeParam(datas[2] as QRCodeParam);
                   
                    _form = form;
                }
                
                panel_DecodeParam.Controls.Add(_form);
                cmb_CodeType.TextChanged += cmb_CodeType_TextChanged;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                fs.Close();
            }
        }
        
    }
}
