using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.IO;
using System.Management;
using System.Threading;
using System.Threading.Tasks;

namespace TwoDimensionCode
{
    /// <summary>
    /// 二维码基类
    /// </summary>    
    /// 

  public  abstract class  TDCode : IDisposable
    {
        protected int countCPU = 0;
        ManagementClass m = new ManagementClass("Win32_Processor");
        public List<CodeResult> results = new List<CodeResult>();
        protected HTuple m_codehandle;//halcon 解码模板句柄 
        public  TDCode()
        {
            ManagementObjectCollection mn = m.GetInstances();
            foreach (ManagementObject mo in mn)
            {
                countCPU += Convert.ToInt16(mo.Properties["NumberOfLogicalProcessors"].Value);
            }
        }

        #region//通用条码参数
       protected string m_polarity;//极性 
       protected string m_mirrored;//镜像
       protected string m_contrast_min;//最小对比度
       protected string m_small_modules_robustness;//小码粒鲁棒性
       #endregion

       public virtual void Decode(HObject image, ref CodeResult results) { }
        public abstract CodeResult[] Decode(List<HObject> images);
        public virtual void SetDecodeHance(enumDecodeHance _decodehance) { }
       public virtual void SetPolarity(enumPolarity _polarity) { }
       public virtual void SetMirrored(enumMirrored _mirror) { }
       public virtual void SetContrastMin(int _contrastmin) { }
       public virtual void SetSmallModulesRobustness(enumLowHigh _smallModlesRobustness) { }
       public virtual void SetCodeParam(TDCodeParam dataparam) { }

       public virtual void Dispose() { }
    }
    /// <summary>
    /// 针对DM类型二维码
    /// </summary>
  public   class DMCode : TDCode
    {
        private bool m_hasdispose=false;
       
        public DMCode():base()
        {
            HOperatorSet.CreateDataCode2dModel("Data Matrix ECC 200", "default_parameters", "maximum_recognition", out m_codehandle);              
        }

        public   override void Dispose()
        {
            Dispse(true);
            GC.SuppressFinalize(this);
        }
        ~DMCode()
        {
            Dispse(false);
        }
        private void Dispse(bool disposing)
        {
            if (m_hasdispose) return;
            if (disposing)
            {
                HOperatorSet.ClearDataCode2dModel(m_codehandle);
            }
            m_hasdispose = true;
        
        }
        
        public  override CodeResult[] Decode(List<HObject> images)
        {
            int countThread =  images.Count;
            Task[] _Tasks = new Task[countThread];
            CodeResult[] result = new CodeResult[countThread];

            for (int i = 0; i < countThread; i++)
            {
                result[i] = new CodeResult();
                TaskDecode(images[i], result[i]);
                //_Tasks[i] = Task.Factory.StartNew((num) =>
                //{
                //    HObject image = images[(int)num];
                //    result[(int)num] = new CodeResult();
                //    TaskDecode(image, result[(int)num]);
                   
                //}, i);
            }
           // Task.WaitAll(_Tasks);
            
            return result;       
        }
        private void TaskDecode(HObject image, CodeResult result)
        {
            HObject _symbolXld = new HObject();
            HTuple _resultHandle = new HTuple();
            HTuple _resultstring = new HTuple();
            HOperatorSet.FindDataCode2d(image, out _symbolXld, m_codehandle, "stop_after_result_num", 1, out _resultHandle, out _resultstring);
            if (_resultstring.Length > 0)
            {
                result.code = _resultstring.S;
                HOperatorSet.GenRegionContourXld(_symbolXld, out result.codexld, "margin");              
            }
        }
      
        public override void SetDecodeHance(enumDecodeHance _decodehance)
        {
            HOperatorSet.SetDataCode2dParam(m_codehandle, "default_parameters", _decodehance.ToString());

        }
        public override  void SetContrastMin(int _contrastmin)
        {
            if (_contrastmin < 1 || _contrastmin > 254)
            {
                throw new Exception("SetContrastMin范围过大");
            }
            HOperatorSet.SetDataCode2dParam(m_codehandle, "contrast_min", _contrastmin);
        }
        public override  void SetPolarity(enumPolarity _polarity)
        {
            HOperatorSet.SetDataCode2dParam(m_codehandle, "polarity", _polarity.ToString());
        }
        public override  void SetMirrored(enumMirrored _mirror)
        {
            HOperatorSet.SetDataCode2dParam(m_codehandle, "mirrored", _mirror.ToString());
        }
        public override  void SetSmallModulesRobustness(enumLowHigh _smallModlesRobustness)
        {
            HOperatorSet.SetDataCode2dParam(m_codehandle, "small_modules_robustness", _smallModlesRobustness.ToString());
        }
        public virtual void SetModulSize(uint modulsizemin, uint modulsizemax)
        {
            if (modulsizemin > modulsizemax)
            {
                throw new Exception("SetModulSize中，modulsizemin > modulsizemax");
            }
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_size_min", modulsizemin);
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_size_max", modulsizemax);
        }
        public virtual void SetSymbolSize(uint symbolrowmin, uint symbolrowmax, uint symbolcolmin, uint symbolcolmax)
        {

            if (symbolrowmin > symbolrowmax)
            {
                throw new Exception("SetModulSize中，symbolsizerowmin > symbolsizemax");
            }
            if (symbolcolmin > symbolcolmax)
            {
                throw new Exception("SetModulSize中，symbolsizecolmin > symbolsizecolmax");
            }
            HOperatorSet.SetDataCode2dParam(m_codehandle, "symbol_rows_min", symbolrowmin);
            HOperatorSet.SetDataCode2dParam(m_codehandle, "symbol_rows_max", symbolrowmax);
            HOperatorSet.SetDataCode2dParam(m_codehandle, "symbol_cols_min", symbolcolmin);
            HOperatorSet.SetDataCode2dParam(m_codehandle, "symbol_cols_max", symbolcolmax);
        }
        public virtual void SetFinderPatternTolerance(enumPatternTolerance _tolerance)
        {
            HOperatorSet.SetDataCode2dParam(m_codehandle, "finder_pattern_tolerance", _tolerance.ToString());
        }
        public virtual void SetModulGap(enumNoSmallBig colgapmin,enumNoSmallBig colgapmax,enumNoSmallBig rowgapmin,enumNoSmallBig rowgapmax)
        {
            if (colgapmin > colgapmax)
                throw new Exception("colgapmin > colgapmax");
            if (rowgapmin > rowgapmax)
                throw new Exception("rowgapmin > rowgapmax");
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_gap_col_min", colgapmin.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_gap_col_max", colgapmax.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_gap_row_min", rowgapmin.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_gap_row_max", rowgapmax.ToString());        
        }
      /// <summary>
      /// 设置超时时间
      /// </summary>
      /// <param name="timeout">取值范围为 false，-1，1.。。。</param>
        public virtual void SetOutTime(int timeout)
        {
            HOperatorSet.SetDataCode2dParam(m_codehandle, "timeout", timeout);
        }
        public virtual void SetStrictQuietZone(enumnoyes _strictquietzone)
        {
            HOperatorSet.SetDataCode2dParam(m_codehandle, "strict_quiet_zone", _strictquietzone.ToString());       
        }
        public override  void SetCodeParam(TDCodeParam dataparam)
        {
            DMCodeParam data = (DMCodeParam)dataparam;
            HOperatorSet.SetDataCode2dParam(m_codehandle, "default_parameters", data.DecodeHance.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "contrast_min", data.ContrastMin);
            HOperatorSet.SetDataCode2dParam(m_codehandle, "strict_quiet_zone", data.StrictQuietZone.ToString());

            HOperatorSet.SetDataCode2dParam(m_codehandle, "polarity", data.Polarity.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "mirrored", data.Mirrored.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "small_modules_robustness", data.SmallModulesRobustness.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_size_min", data.ModuleSizeMin);
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_size_max", data.ModuleSizeMax);
            HOperatorSet.SetDataCode2dParam(m_codehandle, "symbol_rows_min", data.SymbolSizeRowMin);
            HOperatorSet.SetDataCode2dParam(m_codehandle, "symbol_rows_max", data.SymbolSizeRowMax);
            HOperatorSet.SetDataCode2dParam(m_codehandle, "symbol_cols_min", data.SymbolSizeColMin);
            HOperatorSet.SetDataCode2dParam(m_codehandle, "symbol_cols_max", data.SymbolSizeColMax);
            HOperatorSet.SetDataCode2dParam(m_codehandle, "finder_pattern_tolerance", data.FindPatternTolerance.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_gap_col_min", data.ModuleGapColMin.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_gap_col_max", data.ModuleGapColMax.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_gap_row_min", data.ModuleGapRowMin.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_gap_row_max", data.ModuleGapRowMax.ToString());
        }
    }
  public class QRCode : TDCode
  { 
   private bool m_hasdispose=false;
       
        public QRCode()
        {
            HOperatorSet.CreateDataCode2dModel("QR Code", "default_parameters", "maximum_recognition", out m_codehandle);              
        }

        public   override void Dispose()
        {
            Dispse(true);
            GC.SuppressFinalize(this);
        }
        ~QRCode()
        {
            Dispse(false);
        }
        private void Dispse(bool disposing)
        {
            if (m_hasdispose) return;
            if (disposing)
            {
                HOperatorSet.ClearDataCode2dModel(m_codehandle);
            }
            m_hasdispose = true;      
        }
        public override CodeResult[] Decode(List<HObject> images)
        {
            int countThread =  images.Count;
            Task[] _Tasks = new Task[countThread];
           // Barrier _Barrier = new Barrier(countThread);
           // int rowCount = (int)Math.Ceiling((double)images.Count / countCPU);
            CodeResult[] result = new CodeResult[countThread];

            for (int i = 0; i < countThread; i++)
            {

                _Tasks[i] = Task.Factory.StartNew((num) =>
                {
                    HObject image = images[(int)num];
                    result[(int)num] = new CodeResult();
                   // int count = (((int)num * rowCount + rowCount) > images.Count) ? (images.Count - (int)num * rowCount) : rowCount;
                    TaskDecode(image, result[(int)num]);
                   // _Barrier.SignalAndWait();
                }, i);
            }
            
            Task.WaitAll(_Tasks);
           
            return result;
        }
        private void TaskDecode(HObject image, CodeResult result)
        {
            HObject _symbolXld = new HObject();
            HTuple _resultHandle = new HTuple();
            HTuple _resultstring = new HTuple();
            HOperatorSet.FindDataCode2d(image, out _symbolXld, m_codehandle, "stop_after_result_num", 1, out _resultHandle, out _resultstring);
            if (_resultstring.Length > 0)
            {
                result.code = _resultstring.S;
                HOperatorSet.GenRegionContourXld(_symbolXld, out result.codexld, "margin");
            }
        }    
        public override void SetDecodeHance(enumDecodeHance _decodehance)
        {
            HOperatorSet.SetDataCode2dParam(m_codehandle, "default_parameters", _decodehance.ToString());

        }
        /// <summary>
        /// 设置条码与背景的对比度差值
        /// </summary>
        /// <param name="_contrastmin">有效值为1~254</param>
        public override void SetContrastMin(int _contrastmin)
        {
            if (_contrastmin < 1 || _contrastmin > 254)
            {
                throw new Exception("SetContrastMin范围过大");
            }
            HOperatorSet.SetDataCode2dParam(m_codehandle, "contrast_min", _contrastmin);
        }
        public override void SetPolarity(enumPolarity _polarity)
        {
            HOperatorSet.SetDataCode2dParam(m_codehandle, "polarity", _polarity.ToString());
        }
        public override void SetMirrored(enumMirrored _mirror)
        {
            HOperatorSet.SetDataCode2dParam(m_codehandle, "mirrored", _mirror.ToString());
        }
        public override void SetSmallModulesRobustness(enumLowHigh _smallModlesRobustness)
        {            
            HOperatorSet.SetDataCode2dParam(m_codehandle, "small_modules_robustness", _smallModlesRobustness.ToString());
        }
      /// <summary>
      /// 设置QR二维码的版本信息，
      /// </summary>
      /// <param name="_visionmin">对应symbol_size_min=_visionmin*4+17，最小为1</param>
        /// <param name="_visionmax">对应symbol_size_max=_visionmax*4+17,最大为40</param>
        public virtual void SetVersion(uint _visionmin,uint _visionmax)
        {
            if (1 > _visionmin || _visionmax > 40)
                throw new Exception("1<=_vision<=40");
            HOperatorSet.SetDataCode2dParam(m_codehandle, "version_min", _visionmin);
            HOperatorSet.SetDataCode2dParam(m_codehandle, "version_max", _visionmax);
        }
        public virtual void SetSymbolSize(uint symbolsizemin , uint symbolsizemax)
        {

            if (symbolsizemin > symbolsizemax)
            {
                throw new Exception("SetModulSize中，symbolsizemin > symbolsizemax");
            }
           
            HOperatorSet.SetDataCode2dParam(m_codehandle, "symbol_rows_min", symbolsizemin);
            HOperatorSet.SetDataCode2dParam(m_codehandle, "symbol_rows_max", symbolsizemax);
           
        }
        public virtual void SetModulGap(enumNoSmallBig colgapmin, enumNoSmallBig colgapmax, enumNoSmallBig rowgapmin, enumNoSmallBig rowgapmax)
        {
            if (colgapmin > colgapmax)
                throw new Exception("colgapmin > colgapmax");
            if (rowgapmin > rowgapmax)
                throw new Exception("rowgapmin > rowgapmax");
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_gap_col_min", colgapmin.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_gap_col_max", colgapmax.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_gap_row_min", rowgapmin.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_gap_row_max", rowgapmax.ToString());
        }
        public virtual void SetFinderPatternTolerance(enumPatternTolerance _tolerance)
        {
            HOperatorSet.SetDataCode2dParam(m_codehandle, "finder_pattern_tolerance", _tolerance.ToString());
        }
        public virtual void SetOutTime(int timeout)
        {
            HOperatorSet.SetDataCode2dParam(m_codehandle, "timeout", timeout);
        }
        public virtual void SetStrictQuietZone(enumnoyes _strictquietzone)
        {
            HOperatorSet.SetDataCode2dParam(m_codehandle, "strict_quiet_zone", _strictquietzone.ToString());
        }
        public override void SetCodeParam(TDCodeParam dataparam)
        {
            QRCodeParam data = (QRCodeParam)dataparam;
            HOperatorSet.SetDataCode2dParam(m_codehandle, "default_parameters", data.DecodeHance.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "contrast_min", data.ContrastMin);
            HOperatorSet.SetDataCode2dParam(m_codehandle, "strict_quiet_zone", data.StrictQuietZone.ToString());

            HOperatorSet.SetDataCode2dParam(m_codehandle, "polarity", data.Polarity.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "mirrored", data.Mirrored.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "small_modules_robustness", data.SmallModulesRobustness.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "version_min", data.VersionMin);
            HOperatorSet.SetDataCode2dParam(m_codehandle, "version_max", data.VersionMax);
            HOperatorSet.SetDataCode2dParam(m_codehandle, "symbol_size_min", data.SymbolSizeMin);
            HOperatorSet.SetDataCode2dParam(m_codehandle, "symbol_size_max", data.SymbolSizeMax);
            
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_gap_col_min", data.ModuleGapColMin.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_gap_col_max", data.ModuleGapColMax.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_gap_row_min", data.ModuleGapRowMin.ToString());
            HOperatorSet.SetDataCode2dParam(m_codehandle, "module_gap_row_max", data.ModuleGapRowMax.ToString());
        }
    }
    public enum enumDecodeHance
    {
        standard_recognition,
        enhanced_recognition,
        maximum_recognition
    }
  public enum enumPolarity
  { 
      any,
      dark_on_light,
      light_on_dark
  }
  public enum enumMirrored
  { 
      no,
      yes,
      any
  }
    public enum enumnoyes
    {
        no,
        yes
    }
  public enum enumLowHigh
  { 
      low,
      high
  }
  public enum enumPatternTolerance
  { 
      low,
      high,
      any
  }
  public enum enumNoSmallBig
  { 
      no,
      small,
      big
  }
    public class CodeResult
    {
        public string code;
        public HObject codexld;
        public CodeResult()
        {
            code = string.Empty;
            codexld = new HObject();
        }
    }
    [Serializable]
    public class TDCodeParam : ICloneable
    {
        protected enumDecodeHance m_decodehance;
        protected enumPolarity m_polarity;
        protected enumMirrored m_mirrored;
        protected enumLowHigh m_smallmodulerobustness;      
        protected int m_contrastmin;

        public enumDecodeHance DecodeHance
        {
            get { return m_decodehance; }
            set { m_decodehance = value; }
        }

        public enumPolarity Polarity
        {
            get { return m_polarity; }
            set { m_polarity = value; }
        }
        public enumMirrored Mirrored
        {
            get { return m_mirrored; }
            set { m_mirrored = value; }
        }
        public enumLowHigh SmallModulesRobustness
        {
            get { return m_smallmodulerobustness; }
            set { m_smallmodulerobustness = value; }

        }
        public int ContrastMin
        {
            get { return m_contrastmin; }
            set
            {
                if (value < 1 || value > 255)
                {
                    throw new Exception("超出1~255的范围");
                }
                else
                    m_contrastmin = value;

            }
        }

        public virtual object Clone()
        {
            return MemberwiseClone();
        }
    }
    [Serializable]
    public class DMCodeParam : TDCodeParam
    {
        int m_SymbolSizeRowMin;
        int m_SymbolSizeRowMax;
        int m_SymbolSizeColMin;
        int m_SymbolSizeColMax;

        int m_ModelSizeMin;
        int m_ModelSizeMax;
        enumNoSmallBig m_ModuleGapRowMin;
        enumNoSmallBig m_ModuleGapRowMax;
        enumNoSmallBig m_ModuleGapColMin;
        enumNoSmallBig m_ModuleGapColMax;

        int m_timeout;
        enumPatternTolerance m_finderpatterntolerance;
        enumnoyes m_strictquietzone;
        public int SymbolSizeRowMin
        {
            get { return m_SymbolSizeRowMin; }
            set
            {
                if (value < 8 || value > 144)
                {
                    throw new Exception("超出1~255的范围");
                }
                else
                    m_SymbolSizeRowMin = value;

            }

        }
        public int SymbolSizeRowMax
        {
            get { return m_SymbolSizeRowMax; }
            set
            {
                if (value < 8 || value > 144)
                {
                    throw new Exception("超出1~255的范围");
                }
                else
                    m_SymbolSizeRowMax = value;

            }

        }
        public int SymbolSizeColMin
        {

            get { return m_SymbolSizeColMin; }
            set
            {
                if (value < 8 || value > 144)
                {
                    throw new Exception("超出1~255的范围");
                }
                else
                    m_SymbolSizeColMin = value;

            }
        }
        public int SymbolSizeColMax
        {

            get { return m_SymbolSizeColMax; }
            set
            {
                if (value < 8 || value > 144)
                {
                    throw new Exception("超出1~255的范围");
                }
                else
                    m_SymbolSizeColMax = value;

            }
        }
        public int ModuleSizeMin
        {
            get { return m_ModelSizeMin; }
            set { m_ModelSizeMin = value; }
        }
        public int ModuleSizeMax
        {
            get { return m_ModelSizeMax; }
            set { m_ModelSizeMax = value; }
        }
        public enumNoSmallBig ModuleGapRowMin
        {
            get { return m_ModuleGapRowMin; }
            set { m_ModuleGapRowMin = value; }
        }
        public enumNoSmallBig ModuleGapRowMax
        {
            get { return m_ModuleGapRowMax; }
            set { m_ModuleGapRowMax = value; }
        }


        public enumNoSmallBig ModuleGapColMin
        {
            get { return m_ModuleGapColMin; }
            set { m_ModuleGapColMin = value; }

        }
        public enumNoSmallBig ModuleGapColMax
        {
            get { return m_ModuleGapColMax; }
            set { m_ModuleGapColMax = value; }

        }
        public int TimeOut
        {
            get { return m_timeout; }
            set
            {
                if (value < -1)
                {
                    throw new Exception("超出1~255的范围");
                }
                else
                    m_timeout = value;

            }
        }
        public enumPatternTolerance FindPatternTolerance
        {
            get { return m_finderpatterntolerance; }
            set { m_finderpatterntolerance = value; }
        }
        public enumnoyes StrictQuietZone
        {
            get { return m_strictquietzone; }
            set { m_strictquietzone = value; }
        }
        public DMCodeParam()
        {
            m_SymbolSizeRowMin = 8;
            m_SymbolSizeRowMax = 144;
            m_SymbolSizeColMin = 10;
            m_SymbolSizeColMax = 144;

            m_ModelSizeMin = 3;
            m_ModelSizeMax = 100;
            m_ModuleGapRowMin = enumNoSmallBig.no;
            m_ModuleGapRowMax = enumNoSmallBig.big;
            m_ModuleGapColMin = enumNoSmallBig.no;
            m_ModuleGapColMax = enumNoSmallBig.big;
            m_timeout = -1;
            m_finderpatterntolerance = enumPatternTolerance.any;
            m_strictquietzone = enumnoyes.no;
            m_contrastmin = 30;
        }
        public override object Clone()
        {
            return MemberwiseClone();
        }
    }
    [Serializable]
    public class QRCodeParam : TDCodeParam
    {
        
        int m_SymbolSizeMin;
        int m_SymbolSizeMax;
      

        int m_VersionMin;
        int m_VersionMax;
        enumNoSmallBig m_ModuleGapRowMin;
        enumNoSmallBig m_ModuleGapRowMax;
        enumNoSmallBig m_ModuleGapColMin;
        enumNoSmallBig m_ModuleGapColMax;

        int m_timeout;
     
        enumnoyes m_strictquietzone;
        public int SymbolSizeMin
        {
            get { return m_SymbolSizeMin; }
            set
            {
                if (value < 21 || value > 177)
                {
                    throw new Exception("超出1~255的范围");
                }
                else
                    m_SymbolSizeMin = value;

            }

        }
        public int SymbolSizeMax
        {
            get { return m_SymbolSizeMax; }
            set
            {
                if (value < 21 || value > 177)
                {
                    throw new Exception("超出1~255的范围");
                }
                else
                    m_SymbolSizeMax = value;

            }

        }
     
        public int VersionMin
        {
            get { return m_VersionMin; }
            set { m_VersionMin = value; }
        }
        public int VersionMax
        {
            get { return m_VersionMax; }
            set { m_VersionMax = value; }
        }
        public enumNoSmallBig ModuleGapRowMin
        {
            get { return m_ModuleGapRowMin; }
            set { m_ModuleGapRowMin = value; }
        }
        public enumNoSmallBig ModuleGapRowMax
        {
            get { return m_ModuleGapRowMax; }
            set { m_ModuleGapRowMax = value; }
        }


        public enumNoSmallBig ModuleGapColMin
        {
            get { return m_ModuleGapColMin; }
            set { m_ModuleGapColMin = value; }

        }
        public enumNoSmallBig ModuleGapColMax
        {
            get { return m_ModuleGapColMax; }
            set { m_ModuleGapColMax = value; }

        }
        public int TimeOut
        {
            get { return m_timeout; }
            set
            {
                if (value < -1)
                {
                    throw new Exception("超出1~255的范围");
                }
                else
                    m_timeout = value;

            }
        }
   
        public enumnoyes StrictQuietZone
        {
            get { return m_strictquietzone; }
            set { m_strictquietzone = value; }
        }
        public QRCodeParam()
        {
            m_SymbolSizeMin = 21;
            m_SymbolSizeMax = 177;
          

            m_VersionMin = 1;
            m_VersionMax = 40;
            m_ModuleGapRowMin = enumNoSmallBig.no;
            m_ModuleGapRowMax = enumNoSmallBig.big;
            m_ModuleGapColMin = enumNoSmallBig.no;
            m_ModuleGapColMax = enumNoSmallBig.big;
            m_timeout = -1;
           
            m_strictquietzone = enumnoyes.no;
            m_contrastmin = 30;
        }
        public override object Clone()
        {
            return MemberwiseClone();
        }
    }

}
