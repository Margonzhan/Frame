namespace TwoDimensionCode
{
    partial class ReadCode
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
            this.tLPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_TimeUse = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_CodeType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ClearRoi = new System.Windows.Forms.Button();
            this.btn_AddRoi = new System.Windows.Forms.Button();
            this.btn_Decode = new System.Windows.Forms.Button();
            this.btn_loadImage = new System.Windows.Forms.Button();
            this.gBox_CodeParam = new System.Windows.Forms.GroupBox();
            this.panel_DecodeParam = new System.Windows.Forms.Panel();
            this.tLPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.hDisplay1 = new HalWindow.HDisplay();
            this.tLPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gBox_CodeParam.SuspendLayout();
            this.tLPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tLPanel2
            // 
            this.tLPanel2.AutoScroll = true;
            this.tLPanel2.ColumnCount = 1;
            this.tLPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel2.Controls.Add(this.panel1, 0, 0);
            this.tLPanel2.Controls.Add(this.gBox_CodeParam, 0, 1);
            this.tLPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanel2.Location = new System.Drawing.Point(3, 2);
            this.tLPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tLPanel2.Name = "tLPanel2";
            this.tLPanel2.RowCount = 2;
            this.tLPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tLPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel2.Size = new System.Drawing.Size(394, 771);
            this.tLPanel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_TimeUse);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmb_CodeType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_ClearRoi);
            this.panel1.Controls.Add(this.btn_AddRoi);
            this.panel1.Controls.Add(this.btn_Decode);
            this.panel1.Controls.Add(this.btn_loadImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 184);
            this.panel1.TabIndex = 3;
            // 
            // txt_TimeUse
            // 
            this.txt_TimeUse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_TimeUse.Location = new System.Drawing.Point(105, 104);
            this.txt_TimeUse.Margin = new System.Windows.Forms.Padding(4);
            this.txt_TimeUse.Name = "txt_TimeUse";
            this.txt_TimeUse.Size = new System.Drawing.Size(129, 18);
            this.txt_TimeUse.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "/ms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "耗时：";
            // 
            // cmb_CodeType
            // 
            this.cmb_CodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CodeType.FormattingEnabled = true;
            this.cmb_CodeType.Items.AddRange(new object[] {
            "DataMaticECC200",
            "QR_Code"});
            this.cmb_CodeType.Location = new System.Drawing.Point(105, 62);
            this.cmb_CodeType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_CodeType.Name = "cmb_CodeType";
            this.cmb_CodeType.Size = new System.Drawing.Size(225, 23);
            this.cmb_CodeType.TabIndex = 6;
            this.cmb_CodeType.TextChanged += new System.EventHandler(this.cmb_CodeType_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "条码类型：";
            // 
            // btn_ClearRoi
            // 
            this.btn_ClearRoi.Location = new System.Drawing.Point(197, 11);
            this.btn_ClearRoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ClearRoi.Name = "btn_ClearRoi";
            this.btn_ClearRoi.Size = new System.Drawing.Size(87, 40);
            this.btn_ClearRoi.TabIndex = 4;
            this.btn_ClearRoi.Text = "清除ROI";
            this.btn_ClearRoi.UseVisualStyleBackColor = true;
            // 
            // btn_AddRoi
            // 
            this.btn_AddRoi.Location = new System.Drawing.Point(105, 11);
            this.btn_AddRoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_AddRoi.Name = "btn_AddRoi";
            this.btn_AddRoi.Size = new System.Drawing.Size(87, 40);
            this.btn_AddRoi.TabIndex = 3;
            this.btn_AddRoi.Text = "添加ROI";
            this.btn_AddRoi.UseVisualStyleBackColor = true;
            this.btn_AddRoi.Click += new System.EventHandler(this.btn_AddRoi_Click);
            // 
            // btn_Decode
            // 
            this.btn_Decode.Location = new System.Drawing.Point(289, 11);
            this.btn_Decode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Decode.Name = "btn_Decode";
            this.btn_Decode.Size = new System.Drawing.Size(87, 40);
            this.btn_Decode.TabIndex = 2;
            this.btn_Decode.Text = "解码";
            this.btn_Decode.UseVisualStyleBackColor = true;
            this.btn_Decode.Click += new System.EventHandler(this.btn_Decode_Click);
            // 
            // btn_loadImage
            // 
            this.btn_loadImage.Location = new System.Drawing.Point(13, 11);
            this.btn_loadImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_loadImage.Name = "btn_loadImage";
            this.btn_loadImage.Size = new System.Drawing.Size(87, 40);
            this.btn_loadImage.TabIndex = 0;
            this.btn_loadImage.Text = "加载图片";
            this.btn_loadImage.UseVisualStyleBackColor = true;
            this.btn_loadImage.Click += new System.EventHandler(this.btn_loadImage_Click);
            // 
            // gBox_CodeParam
            // 
            this.gBox_CodeParam.Controls.Add(this.panel_DecodeParam);
            this.gBox_CodeParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBox_CodeParam.Location = new System.Drawing.Point(3, 190);
            this.gBox_CodeParam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBox_CodeParam.Name = "gBox_CodeParam";
            this.gBox_CodeParam.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBox_CodeParam.Size = new System.Drawing.Size(388, 579);
            this.gBox_CodeParam.TabIndex = 4;
            this.gBox_CodeParam.TabStop = false;
            this.gBox_CodeParam.Text = "二维码参数：";
            // 
            // panel_DecodeParam
            // 
            this.panel_DecodeParam.AutoScroll = true;
            this.panel_DecodeParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_DecodeParam.Location = new System.Drawing.Point(3, 20);
            this.panel_DecodeParam.Margin = new System.Windows.Forms.Padding(4);
            this.panel_DecodeParam.Name = "panel_DecodeParam";
            this.panel_DecodeParam.Size = new System.Drawing.Size(382, 557);
            this.panel_DecodeParam.TabIndex = 0;
            // 
            // tLPanel1
            // 
            this.tLPanel1.AutoScroll = true;
            this.tLPanel1.ColumnCount = 2;
            this.tLPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tLPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel1.Controls.Add(this.hDisplay1, 1, 0);
            this.tLPanel1.Controls.Add(this.tLPanel2, 0, 0);
            this.tLPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanel1.Location = new System.Drawing.Point(0, 0);
            this.tLPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tLPanel1.Name = "tLPanel1";
            this.tLPanel1.RowCount = 1;
            this.tLPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel1.Size = new System.Drawing.Size(1252, 775);
            this.tLPanel1.TabIndex = 3;
            // 
            // hDisplay1
            // 
            this.hDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hDisplay1.HImageX = null;
            this.hDisplay1.HRegionXList = null;
            this.hDisplay1.HStringXList = null;
            this.hDisplay1.IsCancelImageMove = false;
            this.hDisplay1.Location = new System.Drawing.Point(405, 5);
            this.hDisplay1.Margin = new System.Windows.Forms.Padding(5);
            this.hDisplay1.Name = "hDisplay1";
            this.hDisplay1.Size = new System.Drawing.Size(842, 765);
            this.hDisplay1.TabIndex = 1;
            // 
            // ReadCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tLPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ReadCode";
            this.Size = new System.Drawing.Size(1252, 775);
            this.tLPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gBox_CodeParam.ResumeLayout(false);
            this.tLPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tLPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmb_CodeType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ClearRoi;
        private System.Windows.Forms.Button btn_AddRoi;
        private System.Windows.Forms.Button btn_Decode;
        private System.Windows.Forms.Button btn_loadImage;
        private System.Windows.Forms.GroupBox gBox_CodeParam;
        private System.Windows.Forms.TableLayoutPanel tLPanel1;
        private System.Windows.Forms.Panel panel_DecodeParam;
        private HalWindow.HDisplay hDisplay1;
        private System.Windows.Forms.TextBox txt_TimeUse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
