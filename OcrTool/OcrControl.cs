using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HalconDotNet;
using HalWindow;
using System.Runtime.Serialization.Formatters.Binary;

namespace OcrTool
{
    public partial class OcrControl: UserControl
    {
        HObject m_image = new HObject();//需要处理的图片
        HTuple m_ocrhandle = null;//ocr模板句柄
        string m_TrainOcrName;//训练的ocr文件名称
        RegionParam m_OcrParam;//抓取ocr区域的参数类
        OcrTrainParam m_TrainParam;//训练ocr的参数类
        public OcrControl()
        {
            InitializeComponent();
            AddEvent();
            m_OcrParam = new RegionParam();
            m_TrainParam = new OcrTrainParam();
            DelegateUIControl.GetInstance().FormSetHDisplay = this.hDisplay1;
        }
        public HObject BackImage
        {
            set 
            {
                m_image = value;
                DelegateUIControl.GetInstance().UpdateHDisplay("FormSetHDisplay", m_image, null, null);
            }
        }
        ///手动加载图片      
        private void btn_LoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "|*.bmp;*.jpeg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                HOperatorSet.ReadImage(out m_image, path);
                HOperatorSet.InvertImage(m_image, out m_image);
                DelegateUIControl.GetInstance().UpdateHDisplay("FormSetHDisplay", m_image, null, null);
            }
        }
        //手动添加区域
        private void btn_AddRoiModle_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cmb_RoiModle.Text))
            {
                MessageBox.Show("请先选择ROI形状");
                return;
            }
            if (hDisplay1.GetSearchRegions().Count == 0)
            {
                if (cmb_RoiModle.SelectedItem.ToString() == "矩形")
                {
                    hDisplay1.AddRegion("矩形", true);
                }
                else if (cmb_RoiModle.SelectedItem.ToString() == "旋转矩形")
                {
                    hDisplay1.AddRegion("旋转矩形", true);
                }
            }
        }

        private void btn_extract_Click(object sender, EventArgs e)
        {
            if (hDisplay1.GetSearchRegions().Count == 0)
            {
                MessageBox.Show("请先添加搜索区域");
                return;
            }
            HTuple hv_Number;
            HObject _roi = hDisplay1.GetSearchRegions().ElementAt(0);
            HObject _region=new HObject();
            HObject _imagereduced=new HObject();
            HObject ho_ObjectSelected = new HObject();

            HOperatorSet.ReduceDomain(m_image, _roi, out _imagereduced);
            HOperatorSet.Threshold(_imagereduced, out _region, m_OcrParam.GrayMin, m_OcrParam.GrayMax);
            HOperatorSet.Connection(_region, out _region);
            HOperatorSet.SelectShape(_region, out _region, "area", "and", m_OcrParam.AreaMin, m_OcrParam.AreaMax);

            HOperatorSet.CountObj(_region, out hv_Number);
            HTuple hv_Index = new HTuple();
            List<RegionX> _listregionx = new List<RegionX>();

            for (hv_Index = 1; hv_Index.Continue(hv_Number, 1); hv_Index = hv_Index.TupleAdd(1))
            {
                ho_ObjectSelected.Dispose();
                HOperatorSet.SelectObj(_region, out ho_ObjectSelected, hv_Index);
                RegionX _hregion = new RegionX(ho_ObjectSelected.CopyObj(1, -1), "green");
                _listregionx.Add(_hregion);
               
            }
            DelegateUIControl.GetInstance().UpdateHDisplay("FormSetHDisplay", m_image, _listregionx, null);

        }
        private void UpdateParam(object sender, EventArgs e)
        {
            m_OcrParam.AreaMin = (int)nmud_AreaMin.Value;
            m_OcrParam.AreaMax = (int)nmud_AreaMax.Value;
            m_OcrParam.GrayMin = (int)nmud_GrayMin.Value;
            m_OcrParam.GrayMax = (int)nmud_GrayMax.Value;
            m_TrainParam.CharacterWidth = (int)nmud_CharacterWidth.Value;
            m_TrainParam.CharacterHeiht = (int)nmud_CharacterHidth.Value;
            m_TrainParam.ZoomModle = cmb_ZoomModle.Text;
        }
        private void AddEvent()
        {
            nmud_GrayMin.ValueChanged += UpdateParam;
            nmud_GrayMax.ValueChanged += UpdateParam;
            nmud_AreaMax.ValueChanged += UpdateParam;
            nmud_AreaMin.ValueChanged += UpdateParam;
            nmud_CharacterHidth.ValueChanged += UpdateParam;
            nmud_CharacterWidth.ValueChanged += UpdateParam;
            cmb_ZoomModle.SelectedIndexChanged += UpdateParam;
        }
        private void RemoveEvent()
        {
            nmud_GrayMin.ValueChanged -= UpdateParam;
            nmud_GrayMax.ValueChanged -= UpdateParam;
            nmud_AreaMax.ValueChanged -= UpdateParam;
            nmud_AreaMin.ValueChanged -= UpdateParam;
        }
        private void btn_LoadCustomCharacterL_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string path = fbd.SelectedPath;
                LoadCharacterLibrary(path);
            }
        }
        /// <summary>
        /// 手动添加ocr模板文件
        /// </summary>
        /// <param name="path">保存有ocr模板文件的文件夹</param>
        public void LoadCharacterLibrary(string path)
        {
            if (!Directory.Exists(path)) 
            {
             throw new Exception(path+"路径不存在");
            }
            string[] filenames = Directory.GetFiles(path);
            if (filenames.Length == 0)
            {
                throw new Exception(path + "文件夹为空");
            }
            string omcfile = string.Empty;
            string trffile = string.Empty;
            foreach (string member in filenames)
            {
                if (member.EndsWith(".omc"))
                {
                    omcfile = member;
                }
                else if (member.EndsWith(".trf"))
                {
                    trffile = member;
                }
            }
            if (omcfile == null)
            {
                throw new Exception(path+"路径下缺少.omc文件");
               
            }
            if (trffile == null)
            {
                throw new Exception(path + "路径下缺少.trf文件");
            }
            try
            {
                HOperatorSet.ReadOcrClassMlp(omcfile, out m_ocrhandle);
               // HOperatorSet.ReadOcrTrainf(
            }
            catch(Exception ex)
            { 
            
            }
        }

        private void btn_ReadCharacter_Click(object sender, EventArgs e)
        {
            if (m_ocrhandle == null)
            {
                MessageBox.Show("请先读取字符库");
                return;
            }
            if (hDisplay1.GetSearchRegions().Count == 0)
            {
                MessageBox.Show("请先添加搜索区域");
                return;
            }
            HTuple hv_Number;
            HObject _roi = hDisplay1.GetSearchRegions().ElementAt(0);
            HObject _region=new HObject();
            HObject _imagereduced=new HObject();
            HObject ho_ObjectSelected = new HObject();

            HOperatorSet.ReduceDomain(m_image, _roi, out _imagereduced);
            HOperatorSet.Threshold(_imagereduced, out _region, m_OcrParam.GrayMin, m_OcrParam.GrayMax);
            HOperatorSet.Connection(_region, out _region);
            HOperatorSet.SelectShape(_region, out _region, "area", "and", m_OcrParam.AreaMin, m_OcrParam.AreaMax);

            HOperatorSet.CountObj(_region, out hv_Number);
            HTuple hv_Index = new HTuple();
            List<RegionX> _listregionx = new List<RegionX>();
            List<ViewROI.StringX> _liststringx = new List<ViewROI.StringX>();
            for (hv_Index = 1; hv_Index.Continue(hv_Number, 1); hv_Index = hv_Index.TupleAdd(1))
            {
                ho_ObjectSelected.Dispose();
                HOperatorSet.SelectObj(_region, out ho_ObjectSelected, hv_Index);
                RegionX _hregion = new RegionX(ho_ObjectSelected.CopyObj(1, -1), "green");
                _listregionx.Add(_hregion);

            }

         

            HTuple _characters=new HTuple();
            HTuple _confidence=new HTuple();
           // DelegateUIControl.GetInstance().UpdateHDisplay("FormSetHDisplay", m_image, _listregionx, null);
            HOperatorSet.DoOcrMultiClassMlp(_region, m_image,m_ocrhandle, out _characters, out _confidence);
            

            HTuple _row = new HTuple();
            HTuple _column = new HTuple();
            HTuple _area = new HTuple();
            for (hv_Index = 1; hv_Index.Continue(hv_Number, 1); hv_Index = hv_Index.TupleAdd(1))
            {
                ho_ObjectSelected.Dispose();
                HOperatorSet.SelectObj(_region, out ho_ObjectSelected, hv_Index);
                HOperatorSet.AreaCenter(ho_ObjectSelected, out _area, out _row, out _column);
                ViewROI.StringX sx = new ViewROI.StringX(19, true, false);
                sx.SetString(_characters[hv_Index - 1], (int)_row.D+50, (int)_column.D, Color.Green);
                _liststringx.Add(sx);
            }
            DelegateUIControl.GetInstance().UpdateHDisplay("FormSetHDisplay", m_image, _listregionx, _liststringx);
            
            List<OcrResult> ocrresultlist = new List<OcrResult>();
           for(int i=0;i<_characters.TupleLength();i++)
           {
               OcrResult _ocrresult=new OcrResult();
               _ocrresult.character=_characters[i];
               _ocrresult.scale=_confidence[i].D.ToString("F4");
               ocrresultlist.Add(_ocrresult);
           }        
           dGV_CharacterResult.DataSource = ocrresultlist;
        }

        private void btn_TrainOcr_Click(object sender, EventArgs e)
        {
            if (hDisplay1.GetSearchRegions().Count == 0)
            {
                MessageBox.Show("请先添加搜索区域");
                return;
            }
            if (string.IsNullOrEmpty(txt_CharacterTrained.Text))
            {
                MessageBox.Show("请先填写要训练的字符");
                return;
            }
            HTuple hv_Number;
            HObject _roi = hDisplay1.GetSearchRegions().ElementAt(0);
            HObject _region = new HObject();
            HObject _imagereduced = new HObject();
            HObject ho_ObjectSelected = new HObject();

            HOperatorSet.ReduceDomain(m_image, _roi, out _imagereduced);
            HOperatorSet.Threshold(_imagereduced, out _region, m_OcrParam.GrayMin, m_OcrParam.GrayMax);
            HOperatorSet.Connection(_region, out _region);
            HOperatorSet.SelectShape(_region, out _region, "area", "and", m_OcrParam.AreaMin, m_OcrParam.AreaMax);
            if (cklb_SortRegionModle.GetItemChecked(0))
                HOperatorSet.SortRegion(_region, out _region, "character", "true", "row");
            else
                HOperatorSet.SortRegion(_region, out _region, "character", "true", "column");
            HOperatorSet.CountObj(_region, out hv_Number);

            if (hv_Number.I == 0)
            {
                MessageBox.Show("分割字符为空");
                return;
            }
            string[] _characterTrained = new string[] { };
            _characterTrained=txt_CharacterTrained.Text.Split(',');
            if (_characterTrained.Length != hv_Number.I)
            {
                MessageBox.Show("字符区域与字符个数不相等");
                return;
            }

            HTuple hv_Index = new HTuple();
            List<RegionX> _listregionx = new List<RegionX>();

            for (hv_Index = 1; hv_Index.Continue(hv_Number, 1); hv_Index = hv_Index.TupleAdd(1))
            {
                ho_ObjectSelected.Dispose();
                HOperatorSet.SelectObj(_region, out ho_ObjectSelected, hv_Index);
                RegionX _hregion = new RegionX(ho_ObjectSelected.CopyObj(1, -1), "green");
                _listregionx.Add(_hregion);

            }
            string path = string.Empty;
            string Foldername = string.Empty;
            string trffilepath = string.Empty;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton=true;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                 path = fbd.SelectedPath;
                 string[] _f = path.Split('\\');
                  Foldername = _f[_f.Length - 1];
                 trffilepath = path + "\\" + Foldername + ".trf";
            }
            else
                return;
            HObject _characterRegion=new HObject();
            HOperatorSet.GenEmptyObj(out _characterRegion);
            for (int i = 0; i < hv_Number.I; i++)
            {
                HOperatorSet.AppendOcrTrainf(_region[i + 1], m_image, _characterTrained[i], trffilepath);
            
            }
            HTuple _ocrhandle=new HTuple();
            HTuple error=new HTuple();
            HTuple errorlog=new HTuple();
            HOperatorSet.CreateOcrClassMlp(m_TrainParam.CharacterWidth, m_TrainParam.CharacterHeiht, m_TrainParam.ZoomModle, "default", _characterTrained,
                80, "none", 10, 42, out _ocrhandle);
            HOperatorSet.TrainfOcrClassMlp(_ocrhandle,  trffilepath, 200, 1, 0.01, out error, out errorlog);
            HOperatorSet.WriteOcrTrainf(_region, m_image, _characterTrained, trffilepath);
            HOperatorSet.WriteOcrClassMlp(_ocrhandle, path +"\\"+ Foldername);
            DelegateUIControl.GetInstance().UpdateHDisplay("FormSetHDisplay", m_image, _listregionx, null);
        }

        private void cklb_SortRegionModle_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked) return;
            for (int k = 0; k < ((CheckedListBox)sender).Items.Count; k++)
            {
                ((CheckedListBox)sender).SetItemCheckState(k, CheckState.Unchecked);
            }
            e.NewValue = CheckState.Checked;
        }
        private void btn_CombineModle_Click(object sender, EventArgs e)
        {
            string trffile1 = string.Empty;
            string trffile2 = string.Empty;
            string folderpath = string.Empty;
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "|*.trf";
            if (opd.ShowDialog() == DialogResult.OK)
            {
                trffile1 = opd.FileName;                           
            }
            else return;

            if (opd.ShowDialog() == DialogResult.OK)
            {
                trffile2 = opd.FileName;
            }
            else return;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.Description = "请选择保存路径";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                folderpath = fbd.SelectedPath;
                string Foldername = string.Empty;
                try
                {
                    string[] _f = folderpath.Split('\\');
                    Foldername = _f[_f.Length - 1];
                    HOperatorSet.ConcatOcrTrainf(new string[] { trffile1, trffile2 }, folderpath+"\\"+Foldername+".trf");
                    HTuple _characterTrained=new HTuple();
                    HObject _characcter=new HObject();
                    HOperatorSet.ReadOcrTrainf(out _characcter, folderpath + "\\" + Foldername + ".trf", out _characterTrained);
                    HTuple _ocrhandle = new HTuple();
                    HOperatorSet.CreateOcrClassMlp((int)nmud_CharacterWidth.Value, (int)nmud_CharacterHidth.Value, "constant", "default", _characterTrained,
                80, "none", 10, 42, out _ocrhandle);
                    HTuple error = new HTuple();
                    HTuple errorlog = new HTuple();
                    HOperatorSet.TrainfOcrClassMlp(_ocrhandle, folderpath + "\\" + Foldername + ".trf", 200, 1, 0.01, out error, out errorlog);
                    HOperatorSet.WriteOcrClassMlp(_ocrhandle, folderpath + "\\" + Foldername);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("合并模板失败：" + ex.Message);
                }
            }
            else return;
        }
        public HObject  SearchReagion
        {
            set { hDisplay1.HSeaarchRegionXList = new List<HObject>() {value}; }
            get { return hDisplay1.GetSearchRegions().ElementAt(0); }
        }
        public void SerializeParam(string path)
        {
            System.Runtime.Serialization.IFormatter f = new BinaryFormatter();
            Stream s = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
           // f.Serialize(f,);
           // f.Serialize(
        }
        public void ReSerializeParam()
        { 
        
        }
    }
    public class OcrResult
    {
       public  string character{ get; set; }
       public  string scale{ get; set; }
    }
    [Serializable]
    internal class RegionParam
    {
        public int GrayMin { get; set; }
        public int GrayMax { get; set; }
        public int AreaMin { get; set; }
        public int AreaMax { get; set; }
    }
    [Serializable]
   internal  class OcrTrainParam
    {
    
        public int CharacterWidth { get; set; }
        public int CharacterHeiht { get; set; }
        public string ZoomModle { get; set; }
        public string Feature { get; set; }
        public int NumHidden{get;set;}
        public string Preprocessing { get; set; }
        public int NumComponents { get; set; }
        public int RandSeed { get; set; }

    }
}
