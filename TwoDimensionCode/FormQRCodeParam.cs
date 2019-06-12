using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwoDimensionCode
{
    internal partial class FormQRCodeParam : UserControl
    {
      
        QRCodeParam qRCodeParam;
        public FormQRCodeParam()
        {
            InitializeComponent();
            this.cmB_ModulGapRowMax.DataSource = System.Enum.GetNames(typeof(enumNoSmallBig));
            this.cmB_ModulGapRowMin.DataSource = System.Enum.GetNames(typeof(enumNoSmallBig));
            this.cmB_ModulGapColMax.DataSource = System.Enum.GetNames(typeof(enumNoSmallBig));
            this.cmB_ModulGapColMin.DataSource = System.Enum.GetNames(typeof(enumNoSmallBig));
            this.cmB_Robustness.DataSource = System.Enum.GetNames(typeof(enumLowHigh));
            this.cmB_Mirrored.DataSource = System.Enum.GetNames(typeof(enumMirrored));
            this.cmB_StrictQuitZone.DataSource = System.Enum.GetNames(typeof(enumnoyes));
            this.cmB_Polarity.DataSource = System.Enum.GetNames(typeof(enumPolarity));
            this.cmB_DecodeHance.DataSource = System.Enum.GetNames(typeof(enumDecodeHance));
            qRCodeParam = new QRCodeParam();
            Init();
        }
        public FormQRCodeParam(TDCodeParam _data)
        {
            InitializeComponent();
            this.cmB_ModulGapRowMax.DataSource = System.Enum.GetNames(typeof(enumNoSmallBig));
            this.cmB_ModulGapRowMin.DataSource = System.Enum.GetNames(typeof(enumNoSmallBig));
            this.cmB_ModulGapColMax.DataSource = System.Enum.GetNames(typeof(enumNoSmallBig));
            this.cmB_ModulGapColMin.DataSource = System.Enum.GetNames(typeof(enumNoSmallBig));
            this.cmB_Robustness.DataSource = System.Enum.GetNames(typeof(enumnoyes));
            this.cmB_Mirrored.DataSource = System.Enum.GetNames(typeof(enumMirrored));            
            this.cmB_StrictQuitZone.DataSource = System.Enum.GetNames(typeof(enumnoyes));         
            this.cmB_Polarity.DataSource = System.Enum.GetNames(typeof(enumPolarity));
            this.cmB_DecodeHance.DataSource = System.Enum.GetNames(typeof(enumDecodeHance));
            qRCodeParam = (QRCodeParam)_data.Clone();
            Init();
        }
        private void Init()
        {
            cmB_DecodeHance.Text = qRCodeParam.DecodeHance.ToString();
            cmB_Polarity.Text = qRCodeParam.Polarity.ToString();
           
            cmB_Mirrored.Text = qRCodeParam.Mirrored.ToString();
            cmB_Robustness.Text = qRCodeParam.SmallModulesRobustness.ToString();
            cmB_ModulGapColMax.Text = qRCodeParam.ModuleGapRowMax.ToString();
            cmB_ModulGapColMin.Text = qRCodeParam.ModuleGapColMin.ToString();
            cmB_ModulGapRowMin.Text = qRCodeParam.ModuleGapRowMin.ToString();
            cmB_ModulGapRowMax.Text = qRCodeParam.ModuleGapRowMax.ToString();
            cmB_StrictQuitZone.Text = qRCodeParam.StrictQuietZone.ToString();
            nmUD_TimeOut.Value = qRCodeParam.TimeOut;
            nmUD_ContrastMin.Value = qRCodeParam.ContrastMin;
         
            nmUD_SymbolSizeMin.Value = qRCodeParam.SymbolSizeMin;
            nmUD_SymbolSIzeMax.Value = qRCodeParam.SymbolSizeMax;
            nmUD_VisionMin.Value = qRCodeParam.VersionMin;
            nmUD_VisionMax.Value = qRCodeParam.VersionMax;
            AddEvent();

        }
        public void AddEvent()
        {
            cmB_DecodeHance.TextChanged += ValueChangedRvent;
            cmB_Polarity.TextChanged += ValueChangedRvent;
     
            cmB_Mirrored.TextChanged += ValueChangedRvent;
            cmB_Robustness.TextChanged += ValueChangedRvent;
            cmB_ModulGapColMax.TextChanged += ValueChangedRvent;
            cmB_ModulGapColMin.TextChanged += ValueChangedRvent;
            cmB_ModulGapRowMin.TextChanged += ValueChangedRvent;
            cmB_ModulGapRowMax.TextChanged += ValueChangedRvent;
            cmB_StrictQuitZone.TextChanged += ValueChangedRvent;
            nmUD_TimeOut.ValueChanged += ValueChangedRvent;
            nmUD_ContrastMin.ValueChanged += ValueChangedRvent;
   
            nmUD_SymbolSizeMin.ValueChanged += ValueChangedRvent;
            nmUD_SymbolSIzeMax.ValueChanged += ValueChangedRvent;
            nmUD_VisionMin.ValueChanged += ValueChangedRvent;
            nmUD_VisionMax.ValueChanged += ValueChangedRvent;
        }
        private void ValueChangedRvent(object sender, EventArgs e)
        {
            qRCodeParam.DecodeHance = (enumDecodeHance)Enum.Parse(typeof(enumDecodeHance), cmB_DecodeHance.Text);
            qRCodeParam.Polarity = (enumPolarity)Enum.Parse(typeof(enumPolarity), cmB_Polarity.Text);
            qRCodeParam.Mirrored = (enumMirrored)Enum.Parse(typeof(enumMirrored), cmB_Mirrored.Text);
            qRCodeParam.SmallModulesRobustness = (enumLowHigh)Enum.Parse(typeof(enumLowHigh), cmB_Robustness.Text);
            qRCodeParam.ModuleGapRowMax = (enumNoSmallBig)Enum.Parse(typeof(enumNoSmallBig), cmB_ModulGapColMax.Text);
            qRCodeParam.ModuleGapColMin = (enumNoSmallBig)Enum.Parse(typeof(enumNoSmallBig), cmB_ModulGapColMin.Text);
            qRCodeParam.ModuleGapRowMin = (enumNoSmallBig)Enum.Parse(typeof(enumNoSmallBig), cmB_ModulGapRowMin.Text);
            qRCodeParam.ModuleGapRowMax = (enumNoSmallBig)Enum.Parse(typeof(enumNoSmallBig), cmB_ModulGapRowMax.Text);
            qRCodeParam.StrictQuietZone = (enumnoyes)Enum.Parse(typeof(enumnoyes), cmB_StrictQuitZone.Text);
            qRCodeParam.TimeOut = (int)nmUD_TimeOut.Value;
            qRCodeParam.ContrastMin = (int)nmUD_ContrastMin.Value;

            qRCodeParam.SymbolSizeMin = (int)nmUD_SymbolSizeMin.Value;
            qRCodeParam.SymbolSizeMax = (int)nmUD_SymbolSIzeMax.Value;
            qRCodeParam.VersionMin = (int)nmUD_VisionMin.Value;
            qRCodeParam.VersionMax = (int)nmUD_VisionMax.Value;
        }
        public QRCodeParam CodeParameter
        {
            get { return qRCodeParam; }
            set { qRCodeParam = (QRCodeParam)value; Init(); }
        }
    }
}
