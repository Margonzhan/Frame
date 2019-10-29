namespace HalWindow
{
    partial class HDisplay
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HDisplay));
            this.hWindowControl = new HalconDotNet.HWindowControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ts_ImageSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.ts_GrayValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.ts_Position = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cms_ROI = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_Set = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.适应大小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.cms_ROI.SuspendLayout();
            this.cms_Set.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hWindowControl
            // 
            this.hWindowControl.BackColor = System.Drawing.Color.Gray;
            this.hWindowControl.BorderColor = System.Drawing.Color.Gray;
            this.hWindowControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindowControl.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl.Location = new System.Drawing.Point(0, 0);
            this.hWindowControl.Margin = new System.Windows.Forms.Padding(0);
            this.hWindowControl.Name = "hWindowControl";
            this.hWindowControl.Size = new System.Drawing.Size(522, 363);
            this.hWindowControl.TabIndex = 0;
            this.hWindowControl.WindowSize = new System.Drawing.Size(522, 363);
            this.hWindowControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hWindowControl_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.hWindowControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 363);
            this.panel1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_ImageSize,
            this.ts_GrayValue,
            this.ts_Position});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(522, 30);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ts_ImageSize
            // 
            this.ts_ImageSize.Name = "ts_ImageSize";
            this.ts_ImageSize.Size = new System.Drawing.Size(342, 25);
            this.ts_ImageSize.Spring = true;
            this.ts_ImageSize.Text = "Image:0×0byte";
            // 
            // ts_GrayValue
            // 
            this.ts_GrayValue.AutoSize = false;
            this.ts_GrayValue.Image = ((System.Drawing.Image)(resources.GetObject("ts_GrayValue.Image")));
            this.ts_GrayValue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ts_GrayValue.Name = "ts_GrayValue";
            this.ts_GrayValue.Size = new System.Drawing.Size(60, 25);
            this.ts_GrayValue.Text = "0";
            // 
            // ts_Position
            // 
            this.ts_Position.AutoSize = false;
            this.ts_Position.Image = ((System.Drawing.Image)(resources.GetObject("ts_Position.Image")));
            this.ts_Position.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ts_Position.Name = "ts_Position";
            this.ts_Position.Size = new System.Drawing.Size(100, 25);
            this.ts_Position.Text = "0,0";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 363);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(522, 30);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(524, 395);
            this.panel3.TabIndex = 3;
            // 
            // cms_ROI
            // 
            this.cms_ROI.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_ROI.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.cms_ROI.Name = "cms_ROI";
            this.cms_ROI.Size = new System.Drawing.Size(109, 28);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // cms_Set
            // 
            this.cms_Set.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_Set.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.适应大小ToolStripMenuItem});
            this.cms_Set.Name = "cms_Set";
            this.cms_Set.Size = new System.Drawing.Size(139, 28);
            // 
            // 适应大小ToolStripMenuItem
            // 
            this.适应大小ToolStripMenuItem.Name = "适应大小ToolStripMenuItem";
            this.适应大小ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.适应大小ToolStripMenuItem.Text = "适应大小";
            this.适应大小ToolStripMenuItem.Click += new System.EventHandler(this.适应大小ToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(522, 393);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // HDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "HDisplay";
            this.Size = new System.Drawing.Size(524, 395);
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.cms_ROI.ResumeLayout(false);
            this.cms_Set.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public HalconDotNet.HWindowControl hWindowControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ts_ImageSize;
        private System.Windows.Forms.ToolStripStatusLabel ts_GrayValue;
        private System.Windows.Forms.ToolStripStatusLabel ts_Position;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ContextMenuStrip cms_ROI;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cms_Set;
        private System.Windows.Forms.ToolStripMenuItem 适应大小ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
