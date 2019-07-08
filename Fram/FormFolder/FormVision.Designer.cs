namespace Fram
{
    partial class FormVision
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_GrabContinue = new System.Windows.Forms.Button();
            this.btn_GrabOnce = new System.Windows.Forms.Button();
            this.cmB_Camera = new System.Windows.Forms.ComboBox();
            this.label_Gain = new System.Windows.Forms.Label();
            this.label_ExpoureseTime = new System.Windows.Forms.Label();
            this.label_camera = new System.Windows.Forms.Label();
            this.hDisplay1 = new HalWindow.HDisplay();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 338F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.hDisplay1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1037, 673);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(332, 665);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_GrabContinue);
            this.panel1.Controls.Add(this.btn_GrabOnce);
            this.panel1.Controls.Add(this.cmB_Camera);
            this.panel1.Controls.Add(this.label_Gain);
            this.panel1.Controls.Add(this.label_ExpoureseTime);
            this.panel1.Controls.Add(this.label_camera);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 232);
            this.panel1.TabIndex = 0;
            // 
            // btn_GrabContinue
            // 
            this.btn_GrabContinue.Location = new System.Drawing.Point(169, 188);
            this.btn_GrabContinue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_GrabContinue.Name = "btn_GrabContinue";
            this.btn_GrabContinue.Size = new System.Drawing.Size(108, 28);
            this.btn_GrabContinue.TabIndex = 2;
            this.btn_GrabContinue.Text = "视频播放";
            this.btn_GrabContinue.UseVisualStyleBackColor = true;
            // 
            // btn_GrabOnce
            // 
            this.btn_GrabOnce.Location = new System.Drawing.Point(29, 188);
            this.btn_GrabOnce.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_GrabOnce.Name = "btn_GrabOnce";
            this.btn_GrabOnce.Size = new System.Drawing.Size(108, 28);
            this.btn_GrabOnce.TabIndex = 2;
            this.btn_GrabOnce.Text = "单次采集";
            this.btn_GrabOnce.UseVisualStyleBackColor = true;
            this.btn_GrabOnce.Click += new System.EventHandler(this.btn_GrabOnce_Click);
            // 
            // cmB_Camera
            // 
            this.cmB_Camera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_Camera.FormattingEnabled = true;
            this.cmB_Camera.Location = new System.Drawing.Point(129, 28);
            this.cmB_Camera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmB_Camera.Name = "cmB_Camera";
            this.cmB_Camera.Size = new System.Drawing.Size(191, 26);
            this.cmB_Camera.TabIndex = 1;
            this.cmB_Camera.SelectedIndexChanged += new System.EventHandler(this.cmB_Camera_SelectedIndexChanged);
            // 
            // label_Gain
            // 
            this.label_Gain.AutoSize = true;
            this.label_Gain.Location = new System.Drawing.Point(75, 144);
            this.label_Gain.Name = "label_Gain";
            this.label_Gain.Size = new System.Drawing.Size(53, 18);
            this.label_Gain.TabIndex = 0;
            this.label_Gain.Text = "Gain:";
            // 
            // label_ExpoureseTime
            // 
            this.label_ExpoureseTime.AutoSize = true;
            this.label_ExpoureseTime.Location = new System.Drawing.Point(3, 90);
            this.label_ExpoureseTime.Name = "label_ExpoureseTime";
            this.label_ExpoureseTime.Size = new System.Drawing.Size(125, 18);
            this.label_ExpoureseTime.TabIndex = 0;
            this.label_ExpoureseTime.Text = "ExpourseTime:";
            // 
            // label_camera
            // 
            this.label_camera.AutoSize = true;
            this.label_camera.Location = new System.Drawing.Point(57, 31);
            this.label_camera.Name = "label_camera";
            this.label_camera.Size = new System.Drawing.Size(71, 18);
            this.label_camera.TabIndex = 0;
            this.label_camera.Text = "Camera:";
            // 
            // hDisplay1
            // 
            this.hDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hDisplay1.HImageX = null;
            this.hDisplay1.HRegionXList = null;
            this.hDisplay1.HStringXList = null;
            this.hDisplay1.IsCancelImageMove = false;
            this.hDisplay1.Location = new System.Drawing.Point(342, 5);
            this.hDisplay1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.hDisplay1.Name = "hDisplay1";
            this.hDisplay1.Size = new System.Drawing.Size(691, 663);
            this.hDisplay1.TabIndex = 1;
            // 
            // FormVision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormVision";
            this.Size = new System.Drawing.Size(1037, 673);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmB_Camera;
        private System.Windows.Forms.Label label_Gain;
        private System.Windows.Forms.Label label_ExpoureseTime;
        private System.Windows.Forms.Label label_camera;
        private HalWindow.HDisplay hDisplay1;
        private System.Windows.Forms.Button btn_GrabContinue;
        private System.Windows.Forms.Button btn_GrabOnce;
    }
}
