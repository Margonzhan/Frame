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
    internal partial class FormDMCodeParam : UserControl
    {
        DMCodeParam dMCodeParam;
        public FormDMCodeParam()
        {
            InitializeComponent();
            this.cmB_ModulGapRowMax.DataSource = System.Enum.GetValues(typeof(enumNoSmallBig));
            this.cmB_ModulGapRowMin.DataSource = System.Enum.GetValues(typeof(enumNoSmallBig));
            this.cmB_ModulGapColMax.DataSource = System.Enum.GetValues(typeof(enumNoSmallBig));
            this.cmB_ModulGapColMin.DataSource = System.Enum.GetValues(typeof(enumNoSmallBig));
            this.cmB_Robustness.DataSource = System.Enum.GetValues(typeof(enumLowHigh));
            this.cmB_Mirrored.DataSource = System.Enum.GetValues(typeof(enumMirrored));
            this.cmB_FindPatternTolerance.DataSource = System.Enum.GetValues(typeof(enumPatternTolerance));
            this.cmB_StrictQuitZone.DataSource = System.Enum.GetValues(typeof(enumnoyes));
            this.cmB_Polarity.DataSource = System.Enum.GetValues(typeof(enumPolarity));
            this.cmB_DecodeHance.DataSource = System.Enum.GetValues(typeof(enumDecodeHance));
            
            dMCodeParam = new DMCodeParam();
            Init();
        }
        public FormDMCodeParam(TDCodeParam _data)
        {
            InitializeComponent();
            this.cmB_ModulGapRowMax.DataSource = System.Enum.GetValues(typeof(enumNoSmallBig));
            this.cmB_ModulGapRowMin.DataSource = System.Enum.GetValues(typeof(enumNoSmallBig));
            this.cmB_ModulGapColMax.DataSource = System.Enum.GetValues(typeof(enumNoSmallBig));
            this.cmB_ModulGapColMin.DataSource = System.Enum.GetValues(typeof(enumNoSmallBig));
            this.cmB_Robustness.DataSource = System.Enum.GetValues(typeof(enumLowHigh));
            this.cmB_Mirrored.DataSource = System.Enum.GetValues(typeof(enumMirrored));
            this.cmB_FindPatternTolerance.DataSource = System.Enum.GetValues(typeof(enumPatternTolerance));
            this.cmB_StrictQuitZone.DataSource = System.Enum.GetValues(typeof(enumnoyes));
            this.cmB_Polarity.DataSource = System.Enum.GetValues(typeof(enumPolarity));
            this.cmB_DecodeHance.DataSource = System.Enum.GetValues(typeof(enumDecodeHance));
            dMCodeParam = (DMCodeParam)_data.Clone();
            Init();
        }
        private void Init()
        {
            cmB_DecodeHance.Text = dMCodeParam.DecodeHance.ToString();
            cmB_Polarity.Text = dMCodeParam.Polarity.ToString();
            cmB_FindPatternTolerance.Text = dMCodeParam.FindPatternTolerance.ToString();
            cmB_Mirrored.Text = dMCodeParam.Mirrored.ToString();
            cmB_Robustness.Text = dMCodeParam.SmallModulesRobustness.ToString();
            cmB_ModulGapColMax.Text = dMCodeParam.ModuleGapRowMax.ToString();
            cmB_ModulGapColMin.Text = dMCodeParam.ModuleGapColMin.ToString();
            cmB_ModulGapRowMin.Text = dMCodeParam.ModuleGapRowMin.ToString();
            cmB_ModulGapRowMax.Text = dMCodeParam.ModuleGapRowMax.ToString();
            cmB_StrictQuitZone.Text = dMCodeParam.StrictQuietZone.ToString();
            nmUD_TimeOut.Value = dMCodeParam.TimeOut;
            nmUD_ContrastMin.Value = dMCodeParam.ContrastMin;
            nmUD_SymbolSIzeColMin.Value = dMCodeParam.SymbolSizeColMin;
            nmUD_SymbolSIzeColMax.Value = dMCodeParam.SymbolSizeColMax;
            nmUD_SymbolSizeRowMin.Value = dMCodeParam.SymbolSizeRowMin;
            nmUD_SymbolSIzeRowMax.Value = dMCodeParam.SymbolSizeRowMax;
            nmUD_ModuleSizeMin.Value = dMCodeParam.ModuleSizeMin;
            nmUD_ModuleSizeMax.Value = dMCodeParam.ModuleSizeMax;
            AddEvent();

        }
        public void AddEvent()
        {
            cmB_DecodeHance.TextChanged += ValueChangedRvent;
            cmB_Polarity.TextChanged += ValueChangedRvent;
            cmB_FindPatternTolerance.TextChanged += ValueChangedRvent;
            cmB_Mirrored.TextChanged += ValueChangedRvent;
            cmB_Robustness.TextChanged += ValueChangedRvent;
            cmB_ModulGapColMax.TextChanged += ValueChangedRvent;
            cmB_ModulGapColMin.TextChanged += ValueChangedRvent;
            cmB_ModulGapRowMin.TextChanged += ValueChangedRvent;
            cmB_ModulGapRowMax.TextChanged += ValueChangedRvent;
            cmB_StrictQuitZone.TextChanged += ValueChangedRvent;
            nmUD_TimeOut.ValueChanged += ValueChangedRvent;
            nmUD_ContrastMin.ValueChanged += ValueChangedRvent;
            nmUD_SymbolSIzeColMin.ValueChanged += ValueChangedRvent;
            nmUD_SymbolSIzeColMax.ValueChanged += ValueChangedRvent;
            nmUD_SymbolSizeRowMin.ValueChanged += ValueChangedRvent;
            nmUD_SymbolSIzeRowMax.ValueChanged += ValueChangedRvent;
            nmUD_ModuleSizeMin.ValueChanged += ValueChangedRvent;
            nmUD_ModuleSizeMax.ValueChanged += ValueChangedRvent;
        }
        private void ValueChangedRvent(object sender, EventArgs e)
        {
            dMCodeParam.DecodeHance = (enumDecodeHance)Enum.Parse(typeof(enumDecodeHance), cmB_DecodeHance.Text);
            dMCodeParam.Polarity=(enumPolarity)Enum.Parse(typeof(enumPolarity), cmB_Polarity.Text);
            dMCodeParam.FindPatternTolerance = (enumPatternTolerance)Enum.Parse(typeof(enumPatternTolerance), cmB_FindPatternTolerance.Text);
            dMCodeParam.Mirrored = (enumMirrored)Enum.Parse(typeof(enumMirrored), cmB_Mirrored.Text);
            dMCodeParam.SmallModulesRobustness = (enumLowHigh)Enum.Parse(typeof(enumLowHigh), cmB_Robustness.Text);
            dMCodeParam.ModuleGapRowMax = (enumNoSmallBig)Enum.Parse(typeof(enumNoSmallBig), cmB_ModulGapColMax.Text);
            dMCodeParam.ModuleGapColMin = (enumNoSmallBig)Enum.Parse(typeof(enumNoSmallBig), cmB_ModulGapColMin.Text);
            dMCodeParam.ModuleGapRowMin = (enumNoSmallBig)Enum.Parse(typeof(enumNoSmallBig), cmB_ModulGapRowMin.Text);
            dMCodeParam.ModuleGapRowMax = (enumNoSmallBig)Enum.Parse(typeof(enumNoSmallBig), cmB_ModulGapRowMax.Text);
            dMCodeParam.StrictQuietZone = (enumnoyes)Enum.Parse(typeof(enumnoyes), cmB_StrictQuitZone.Text);
            dMCodeParam.TimeOut = (int)nmUD_TimeOut.Value;
            dMCodeParam.ContrastMin = (int)nmUD_ContrastMin.Value;
            dMCodeParam.SymbolSizeColMin = (int)nmUD_SymbolSIzeColMin.Value;
            dMCodeParam.SymbolSizeColMax = (int)nmUD_SymbolSIzeColMax.Value;
            dMCodeParam.SymbolSizeRowMin = (int)nmUD_SymbolSizeRowMin.Value;
            dMCodeParam.SymbolSizeRowMax = (int)nmUD_SymbolSIzeRowMax.Value;
            dMCodeParam.ModuleSizeMin = (int)nmUD_ModuleSizeMin.Value;
            dMCodeParam.ModuleSizeMax = (int)nmUD_ModuleSizeMax.Value;
        }
        public DMCodeParam CodeParameter
        {
            get { return dMCodeParam; }
            set { dMCodeParam = (DMCodeParam)value; Init(); }
        }
    }
}
