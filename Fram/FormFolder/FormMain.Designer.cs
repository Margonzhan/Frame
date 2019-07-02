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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage_Menu = new DevExpress.XtraBars.Navigation.TabNavigationPage();
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
            this.tabPage_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane_Menu)).BeginInit();
            this.tabPane_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabPane);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1548, 799);
            this.panel1.TabIndex = 0;
            // 
            // tabPane
            // 
            this.tabPane.Controls.Add(this.tabPage_Auto);
            this.tabPane.Controls.Add(this.tabPage_Menu);
            this.tabPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane.Location = new System.Drawing.Point(0, 0);
            this.tabPane.Name = "tabPane";
            this.tabPane.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabPage_Auto,
            this.tabPage_Menu});
            this.tabPane.RegularSize = new System.Drawing.Size(1548, 799);
            this.tabPane.SelectedPage = this.tabPage_Menu;
            this.tabPane.Size = new System.Drawing.Size(1548, 799);
            this.tabPane.TabIndex = 2;
            this.tabPane.Text = "tabPane";
            // 
            // tabPage_Auto
            // 
            this.tabPage_Auto.BackgroundPadding = new System.Windows.Forms.Padding(10);
            this.tabPage_Auto.Caption = "Auto";
            this.tabPage_Auto.Controls.Add(this.button1);
            this.tabPage_Auto.Controls.Add(this.button2);
            this.tabPage_Auto.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPage_Auto.Name = "tabPage_Auto";
            this.tabPage_Auto.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPage_Auto.Size = new System.Drawing.Size(1529, 743);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(97, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 46);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage_Menu
            // 
            this.tabPage_Menu.Caption = "Menu";
            this.tabPage_Menu.Controls.Add(this.tabPane_Menu);
            this.tabPage_Menu.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPage_Menu.Name = "tabPage_Menu";
            this.tabPage_Menu.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPage_Menu.Size = new System.Drawing.Size(1526, 741);
            // 
            // tabPane_Menu
            // 
            this.tabPane_Menu.Controls.Add(this.tabNavigationPage_IoDevice);
            this.tabPane_Menu.Controls.Add(this.tabNavigationPage_Cameras);
            this.tabPane_Menu.Controls.Add(this.tabNavigationPage_AxisDevice);
            this.tabPane_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane_Menu.Location = new System.Drawing.Point(0, 0);
            this.tabPane_Menu.Name = "tabPane_Menu";
            this.tabPane_Menu.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPane_Menu.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPage_IoDevice,
            this.tabNavigationPage_Cameras,
            this.tabNavigationPage_AxisDevice});
            this.tabPane_Menu.RegularSize = new System.Drawing.Size(1526, 741);
            this.tabPane_Menu.SelectedPage = this.tabNavigationPage_Cameras;
            this.tabPane_Menu.Size = new System.Drawing.Size(1526, 741);
            this.tabPane_Menu.TabIndex = 0;
            this.tabPane_Menu.Text = "IO设备";
            this.tabPane_Menu.SelectedPageChanged += new DevExpress.XtraBars.Navigation.SelectedPageChangedEventHandler(this.tabPane_Menu_SelectedPageChanged);
            // 
            // tabNavigationPage_IoDevice
            // 
            this.tabNavigationPage_IoDevice.Caption = "Io Device";
            this.tabNavigationPage_IoDevice.Name = "tabNavigationPage_IoDevice";
            this.tabNavigationPage_IoDevice.Size = new System.Drawing.Size(1502, 681);
            // 
            // tabNavigationPage_Cameras
            // 
            this.tabNavigationPage_Cameras.Caption = "Camera";
            this.tabNavigationPage_Cameras.Name = "tabNavigationPage_Cameras";
            this.tabNavigationPage_Cameras.Size = new System.Drawing.Size(1504, 683);
            // 
            // tabNavigationPage_AxisDevice
            // 
            this.tabNavigationPage_AxisDevice.Caption = "Axis Device";
            this.tabNavigationPage_AxisDevice.Name = "tabNavigationPage_AxisDevice";
            this.tabNavigationPage_AxisDevice.Size = new System.Drawing.Size(1526, 741);
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
            this.ClientSize = new System.Drawing.Size(1548, 799);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "MyFram";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane)).EndInit();
            this.tabPane.ResumeLayout(false);
            this.tabPage_Auto.ResumeLayout(false);
            this.tabPage_Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane_Menu)).EndInit();
            this.tabPane_Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraBars.Navigation.TabPane tabPane;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabPage_Auto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabPage_Menu;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private DevExpress.XtraBars.Navigation.TabPane tabPane_Menu;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage_IoDevice;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage_Cameras;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage_AxisDevice;

        #endregion
        //private HalconModle.ShapeModle shapeModle;
    }
}

