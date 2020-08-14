using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using Fram;
using DevExpress.XtraCharts;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Fram.Hardware;
using Fram.Hardware.AxisDevice;
using System.Drawing;
using Fram.Station;
using Fram.Hardware.LogicAxisUnite;

namespace Fram.FormFolder
{
    public partial class FormAuto : UserControl
    {  
        public FormAuto()
        {
            InitializeComponent();
            LogicAxisUnitManager.Instance.LogicAxisUnitS["test"].LoadPoint();
        }

      
    }
   
}
