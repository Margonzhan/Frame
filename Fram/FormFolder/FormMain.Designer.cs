namespace Fram
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPane = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabPage_Auto = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gB_Log = new System.Windows.Forms.GroupBox();
            this.rTBZD_Log = new Fram.RichTextBoxZd();
            this.tabNagPage_Menu = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabPane_Menu = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPage_IoDevice = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabNavigationPage_Cameras = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabNavigationPage_AxisDevice = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane)).BeginInit();
            this.tabPane.SuspendLayout();
            this.tabPage_Auto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gB_Log.SuspendLayout();
            this.tabNagPage_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane_Menu)).BeginInit();
            this.tabPane_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabPane);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1655, 892);
            this.panel1.TabIndex = 0;
            // 
            // tabPane
            // 
            this.tabPane.Controls.Add(this.tabPage_Auto);
            this.tabPane.Controls.Add(this.tabNagPage_Menu);
            this.tabPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane.Location = new System.Drawing.Point(0, 0);
            this.tabPane.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPane.Name = "tabPane";
            this.tabPane.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabPage_Auto,
            this.tabNagPage_Menu});
            this.tabPane.RegularSize = new System.Drawing.Size(1655, 892);
            this.tabPane.SelectedPage = this.tabNagPage_Menu;
            this.tabPane.Size = new System.Drawing.Size(1655, 892);
            this.tabPane.TabIndex = 2;
            this.tabPane.Text = "tabPane";
            // 
            // tabPage_Auto
            // 
            this.tabPage_Auto.BackgroundPadding = new System.Windows.Forms.Padding(10);
            this.tabPage_Auto.Caption = "Auto";
            this.tabPage_Auto.Controls.Add(this.splitContainer1);
            this.tabPage_Auto.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPage_Auto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_Auto.Name = "tabPage_Auto";
            this.tabPage_Auto.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPage_Auto.Size = new System.Drawing.Size(1633, 834);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gB_Log);
            this.splitContainer1.Panel2MinSize = 50;
            this.splitContainer1.Size = new System.Drawing.Size(1633, 834);
            this.splitContainer1.SplitterDistance = 782;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 5;
            // 
            // gB_Log
            // 
            this.gB_Log.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gB_Log.Controls.Add(this.rTBZD_Log);
            this.gB_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gB_Log.Location = new System.Drawing.Point(0, 0);
            this.gB_Log.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gB_Log.Name = "gB_Log";
            this.gB_Log.Padding = new System.Windows.Forms.Padding(0);
            this.gB_Log.Size = new System.Drawing.Size(1631, 48);
            this.gB_Log.TabIndex = 0;
            this.gB_Log.TabStop = false;
            this.gB_Log.Text = "Log:";
            // 
            // rTBZD_Log
            // 
            this.rTBZD_Log.AutoScroll = true;
            this.rTBZD_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTBZD_Log.Location = new System.Drawing.Point(0, 18);
            this.rTBZD_Log.Margin = new System.Windows.Forms.Padding(0);
            this.rTBZD_Log.Name = "rTBZD_Log";
            this.rTBZD_Log.Size = new System.Drawing.Size(1631, 30);
            this.rTBZD_Log.TabIndex = 0;
            // 
            // tabNagPage_Menu
            // 
            this.tabNagPage_Menu.Caption = "Menu";
            this.tabNagPage_Menu.Controls.Add(this.tabPane_Menu);
            this.tabNagPage_Menu.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNagPage_Menu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabNagPage_Menu.Name = "tabNagPage_Menu";
            this.tabNagPage_Menu.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNagPage_Menu.Size = new System.Drawing.Size(1633, 834);
            // 
            // tabPane_Menu
            // 
            this.tabPane_Menu.Controls.Add(this.tabNavigationPage_IoDevice);
            this.tabPane_Menu.Controls.Add(this.tabNavigationPage_Cameras);
            this.tabPane_Menu.Controls.Add(this.tabNavigationPage_AxisDevice);
            this.tabPane_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane_Menu.Location = new System.Drawing.Point(0, 0);
            this.tabPane_Menu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPane_Menu.Name = "tabPane_Menu";
            this.tabPane_Menu.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPane_Menu.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPage_IoDevice,
            this.tabNavigationPage_Cameras,
            this.tabNavigationPage_AxisDevice});
            this.tabPane_Menu.RegularSize = new System.Drawing.Size(1633, 834);
            this.tabPane_Menu.SelectedPage = this.tabNavigationPage_Cameras;
            this.tabPane_Menu.Size = new System.Drawing.Size(1633, 834);
            this.tabPane_Menu.TabIndex = 0;
            this.tabPane_Menu.Text = "IO设备";
            // 
            // tabNavigationPage_IoDevice
            // 
            this.tabNavigationPage_IoDevice.Caption = "Io Device";
            this.tabNavigationPage_IoDevice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabNavigationPage_IoDevice.Name = "tabNavigationPage_IoDevice";
            this.tabNavigationPage_IoDevice.Size = new System.Drawing.Size(1611, 776);
            // 
            // tabNavigationPage_Cameras
            // 
            this.tabNavigationPage_Cameras.Caption = "Camera";
            this.tabNavigationPage_Cameras.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabNavigationPage_Cameras.Name = "tabNavigationPage_Cameras";
            this.tabNavigationPage_Cameras.Size = new System.Drawing.Size(1611, 776);
            // 
            // tabNavigationPage_AxisDevice
            // 
            this.tabNavigationPage_AxisDevice.Caption = "Axis Device";
            this.tabNavigationPage_AxisDevice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabNavigationPage_AxisDevice.Name = "tabNavigationPage_AxisDevice";
            this.tabNavigationPage_AxisDevice.Size = new System.Drawing.Size(1504, 682);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(220, 43);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1655, 892);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "FormMain";
            this.Text = "MyFram";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane)).EndInit();
            this.tabPane.ResumeLayout(false);
            this.tabPage_Auto.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gB_Log.ResumeLayout(false);
            this.tabNagPage_Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane_Menu)).EndInit();
            this.tabPane_Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraBars.Navigation.TabPane tabPane;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabPage_Auto;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNagPage_Menu;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private DevExpress.XtraBars.Navigation.TabPane tabPane_Menu;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage_IoDevice;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage_Cameras;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage_AxisDevice;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gB_Log;
        private Fram.RichTextBoxZd rTBZD_Log;

        #endregion
        //private HalconModle.ShapeModle shapeModle;
    }
}

