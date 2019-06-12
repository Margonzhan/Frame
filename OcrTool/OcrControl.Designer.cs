namespace OcrTool
{
    partial class OcrControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.hDisplay1 = new HalWindow.HDisplay();
            this.tabC_OcrOperate = new System.Windows.Forms.TabControl();
            this.tabP_CharacterExtract = new System.Windows.Forms.TabPage();
            this.cklb_SortRegionModle = new System.Windows.Forms.CheckedListBox();
            this.btn_extract = new System.Windows.Forms.Button();
            this.btn_AddRoiModle = new System.Windows.Forms.Button();
            this.cmb_RoiModle = new System.Windows.Forms.ComboBox();
            this.nmud_GrayMax = new System.Windows.Forms.NumericUpDown();
            this.nmud_GrayMin = new System.Windows.Forms.NumericUpDown();
            this.nmud_AreaMax = new System.Windows.Forms.NumericUpDown();
            this.nmud_AreaMin = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_LoadImage = new System.Windows.Forms.Button();
            this.tabP_Train = new System.Windows.Forms.TabPage();
            this.cmb_ZoomModle = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_CombineModle = new System.Windows.Forms.Button();
            this.nmud_CharacterHidth = new System.Windows.Forms.NumericUpDown();
            this.nmud_CharacterWidth = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_TrainOcr = new System.Windows.Forms.Button();
            this.txt_CharacterTrained = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabP_Result = new System.Windows.Forms.TabPage();
            this.gBox_CharaResult = new System.Windows.Forms.GroupBox();
            this.dGV_CharacterResult = new System.Windows.Forms.DataGridView();
            this.C_Character = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Scale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ReadCharacter = new System.Windows.Forms.Button();
            this.btn_LoadCustomCharacterL = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabC_OcrOperate.SuspendLayout();
            this.tabP_CharacterExtract.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmud_GrayMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmud_GrayMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmud_AreaMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmud_AreaMin)).BeginInit();
            this.tabP_Train.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmud_CharacterHidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmud_CharacterWidth)).BeginInit();
            this.tabP_Result.SuspendLayout();
            this.gBox_CharaResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_CharacterResult)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.hDisplay1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabC_OcrOperate, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(611, 367);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // hDisplay1
            // 
            this.hDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hDisplay1.HImageX = null;
            this.hDisplay1.HRegionXList = null;
            this.hDisplay1.HStringXList = null;
            this.hDisplay1.IsCancelImageMove = false;
            this.hDisplay1.IsShowRegionNumber = true;
            this.hDisplay1.Location = new System.Drawing.Point(203, 3);
            this.hDisplay1.Name = "hDisplay1";
            this.hDisplay1.Size = new System.Drawing.Size(405, 361);
            this.hDisplay1.TabIndex = 0;
            // 
            // tabC_OcrOperate
            // 
            this.tabC_OcrOperate.Controls.Add(this.tabP_CharacterExtract);
            this.tabC_OcrOperate.Controls.Add(this.tabP_Train);
            this.tabC_OcrOperate.Controls.Add(this.tabP_Result);
            this.tabC_OcrOperate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabC_OcrOperate.Location = new System.Drawing.Point(2, 2);
            this.tabC_OcrOperate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabC_OcrOperate.Name = "tabC_OcrOperate";
            this.tabC_OcrOperate.SelectedIndex = 0;
            this.tabC_OcrOperate.Size = new System.Drawing.Size(196, 363);
            this.tabC_OcrOperate.TabIndex = 1;
            // 
            // tabP_CharacterExtract
            // 
            this.tabP_CharacterExtract.Controls.Add(this.cklb_SortRegionModle);
            this.tabP_CharacterExtract.Controls.Add(this.btn_extract);
            this.tabP_CharacterExtract.Controls.Add(this.btn_AddRoiModle);
            this.tabP_CharacterExtract.Controls.Add(this.cmb_RoiModle);
            this.tabP_CharacterExtract.Controls.Add(this.nmud_GrayMax);
            this.tabP_CharacterExtract.Controls.Add(this.nmud_GrayMin);
            this.tabP_CharacterExtract.Controls.Add(this.nmud_AreaMax);
            this.tabP_CharacterExtract.Controls.Add(this.nmud_AreaMin);
            this.tabP_CharacterExtract.Controls.Add(this.label4);
            this.tabP_CharacterExtract.Controls.Add(this.label3);
            this.tabP_CharacterExtract.Controls.Add(this.label2);
            this.tabP_CharacterExtract.Controls.Add(this.label1);
            this.tabP_CharacterExtract.Controls.Add(this.btn_LoadImage);
            this.tabP_CharacterExtract.Location = new System.Drawing.Point(4, 22);
            this.tabP_CharacterExtract.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabP_CharacterExtract.Name = "tabP_CharacterExtract";
            this.tabP_CharacterExtract.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabP_CharacterExtract.Size = new System.Drawing.Size(188, 337);
            this.tabP_CharacterExtract.TabIndex = 0;
            this.tabP_CharacterExtract.Text = "字符提取";
            this.tabP_CharacterExtract.UseVisualStyleBackColor = true;
            // 
            // cklb_SortRegionModle
            // 
            this.cklb_SortRegionModle.FormattingEnabled = true;
            this.cklb_SortRegionModle.Items.AddRange(new object[] {
            "行优先",
            "列优先"});
            this.cklb_SortRegionModle.Location = new System.Drawing.Point(6, 211);
            this.cklb_SortRegionModle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cklb_SortRegionModle.MultiColumn = true;
            this.cklb_SortRegionModle.Name = "cklb_SortRegionModle";
            this.cklb_SortRegionModle.Size = new System.Drawing.Size(75, 36);
            this.cklb_SortRegionModle.TabIndex = 6;
            this.cklb_SortRegionModle.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cklb_SortRegionModle_ItemCheck);
            // 
            // btn_extract
            // 
            this.btn_extract.Location = new System.Drawing.Point(75, 4);
            this.btn_extract.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_extract.Name = "btn_extract";
            this.btn_extract.Size = new System.Drawing.Size(76, 30);
            this.btn_extract.TabIndex = 5;
            this.btn_extract.Text = "提取字符";
            this.btn_extract.UseVisualStyleBackColor = true;
            this.btn_extract.Click += new System.EventHandler(this.btn_extract_Click);
            // 
            // btn_AddRoiModle
            // 
            this.btn_AddRoiModle.Location = new System.Drawing.Point(117, 183);
            this.btn_AddRoiModle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_AddRoiModle.Name = "btn_AddRoiModle";
            this.btn_AddRoiModle.Size = new System.Drawing.Size(55, 25);
            this.btn_AddRoiModle.TabIndex = 4;
            this.btn_AddRoiModle.Text = "添加";
            this.btn_AddRoiModle.UseVisualStyleBackColor = true;
            this.btn_AddRoiModle.Click += new System.EventHandler(this.btn_AddRoiModle_Click);
            // 
            // cmb_RoiModle
            // 
            this.cmb_RoiModle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_RoiModle.FormattingEnabled = true;
            this.cmb_RoiModle.Items.AddRange(new object[] {
            "矩形",
            "旋转矩形"});
            this.cmb_RoiModle.Location = new System.Drawing.Point(6, 187);
            this.cmb_RoiModle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmb_RoiModle.Name = "cmb_RoiModle";
            this.cmb_RoiModle.Size = new System.Drawing.Size(97, 20);
            this.cmb_RoiModle.TabIndex = 3;
            // 
            // nmud_GrayMax
            // 
            this.nmud_GrayMax.Location = new System.Drawing.Point(75, 148);
            this.nmud_GrayMax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmud_GrayMax.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nmud_GrayMax.Name = "nmud_GrayMax";
            this.nmud_GrayMax.Size = new System.Drawing.Size(80, 21);
            this.nmud_GrayMax.TabIndex = 2;
            this.nmud_GrayMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nmud_GrayMin
            // 
            this.nmud_GrayMin.Location = new System.Drawing.Point(75, 117);
            this.nmud_GrayMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmud_GrayMin.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nmud_GrayMin.Name = "nmud_GrayMin";
            this.nmud_GrayMin.Size = new System.Drawing.Size(80, 21);
            this.nmud_GrayMin.TabIndex = 2;
            this.nmud_GrayMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nmud_AreaMax
            // 
            this.nmud_AreaMax.Location = new System.Drawing.Point(75, 86);
            this.nmud_AreaMax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmud_AreaMax.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmud_AreaMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmud_AreaMax.Name = "nmud_AreaMax";
            this.nmud_AreaMax.Size = new System.Drawing.Size(80, 21);
            this.nmud_AreaMax.TabIndex = 2;
            this.nmud_AreaMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nmud_AreaMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nmud_AreaMin
            // 
            this.nmud_AreaMin.Location = new System.Drawing.Point(75, 55);
            this.nmud_AreaMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmud_AreaMin.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nmud_AreaMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmud_AreaMin.Name = "nmud_AreaMin";
            this.nmud_AreaMin.Size = new System.Drawing.Size(80, 21);
            this.nmud_AreaMin.TabIndex = 2;
            this.nmud_AreaMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nmud_AreaMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 149);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "GrayMax:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "GrayMin:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "AreaMax:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "AreaMin:";
            // 
            // btn_LoadImage
            // 
            this.btn_LoadImage.Location = new System.Drawing.Point(4, 4);
            this.btn_LoadImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_LoadImage.Name = "btn_LoadImage";
            this.btn_LoadImage.Size = new System.Drawing.Size(61, 30);
            this.btn_LoadImage.TabIndex = 0;
            this.btn_LoadImage.Text = "加载图片";
            this.btn_LoadImage.UseVisualStyleBackColor = true;
            this.btn_LoadImage.Click += new System.EventHandler(this.btn_LoadImage_Click);
            // 
            // tabP_Train
            // 
            this.tabP_Train.Controls.Add(this.cmb_ZoomModle);
            this.tabP_Train.Controls.Add(this.label8);
            this.tabP_Train.Controls.Add(this.btn_CombineModle);
            this.tabP_Train.Controls.Add(this.nmud_CharacterHidth);
            this.tabP_Train.Controls.Add(this.nmud_CharacterWidth);
            this.tabP_Train.Controls.Add(this.label7);
            this.tabP_Train.Controls.Add(this.label6);
            this.tabP_Train.Controls.Add(this.btn_TrainOcr);
            this.tabP_Train.Controls.Add(this.txt_CharacterTrained);
            this.tabP_Train.Controls.Add(this.label5);
            this.tabP_Train.Location = new System.Drawing.Point(4, 22);
            this.tabP_Train.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabP_Train.Name = "tabP_Train";
            this.tabP_Train.Size = new System.Drawing.Size(188, 337);
            this.tabP_Train.TabIndex = 2;
            this.tabP_Train.Text = "训练";
            this.tabP_Train.UseVisualStyleBackColor = true;
            // 
            // cmb_ZoomModle
            // 
            this.cmb_ZoomModle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ZoomModle.FormattingEnabled = true;
            this.cmb_ZoomModle.Items.AddRange(new object[] {
            "bilinear",
            "constant",
            "nearest_neighbor",
            "weighted"});
            this.cmb_ZoomModle.Location = new System.Drawing.Point(71, 135);
            this.cmb_ZoomModle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmb_ZoomModle.Name = "cmb_ZoomModle";
            this.cmb_ZoomModle.Size = new System.Drawing.Size(82, 20);
            this.cmb_ZoomModle.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 135);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "缩放模式：";
            // 
            // btn_CombineModle
            // 
            this.btn_CombineModle.Location = new System.Drawing.Point(88, 191);
            this.btn_CombineModle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_CombineModle.Name = "btn_CombineModle";
            this.btn_CombineModle.Size = new System.Drawing.Size(63, 29);
            this.btn_CombineModle.TabIndex = 5;
            this.btn_CombineModle.Text = "合并模板";
            this.btn_CombineModle.UseVisualStyleBackColor = true;
            this.btn_CombineModle.Click += new System.EventHandler(this.btn_CombineModle_Click);
            // 
            // nmud_CharacterHidth
            // 
            this.nmud_CharacterHidth.Location = new System.Drawing.Point(71, 108);
            this.nmud_CharacterHidth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmud_CharacterHidth.Name = "nmud_CharacterHidth";
            this.nmud_CharacterHidth.Size = new System.Drawing.Size(80, 21);
            this.nmud_CharacterHidth.TabIndex = 4;
            // 
            // nmud_CharacterWidth
            // 
            this.nmud_CharacterWidth.Location = new System.Drawing.Point(71, 81);
            this.nmud_CharacterWidth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmud_CharacterWidth.Name = "nmud_CharacterWidth";
            this.nmud_CharacterWidth.Size = new System.Drawing.Size(80, 21);
            this.nmud_CharacterWidth.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 109);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "字符高度：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 82);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "字符宽度：";
            // 
            // btn_TrainOcr
            // 
            this.btn_TrainOcr.Location = new System.Drawing.Point(4, 191);
            this.btn_TrainOcr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_TrainOcr.Name = "btn_TrainOcr";
            this.btn_TrainOcr.Size = new System.Drawing.Size(63, 29);
            this.btn_TrainOcr.TabIndex = 2;
            this.btn_TrainOcr.Text = "训练模板";
            this.btn_TrainOcr.UseVisualStyleBackColor = true;
            this.btn_TrainOcr.Click += new System.EventHandler(this.btn_TrainOcr_Click);
            // 
            // txt_CharacterTrained
            // 
            this.txt_CharacterTrained.Location = new System.Drawing.Point(2, 22);
            this.txt_CharacterTrained.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_CharacterTrained.Multiline = true;
            this.txt_CharacterTrained.Name = "txt_CharacterTrained";
            this.txt_CharacterTrained.Size = new System.Drawing.Size(188, 41);
            this.txt_CharacterTrained.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "输入训练字符（以，隔开）：";
            // 
            // tabP_Result
            // 
            this.tabP_Result.Controls.Add(this.gBox_CharaResult);
            this.tabP_Result.Controls.Add(this.btn_ReadCharacter);
            this.tabP_Result.Controls.Add(this.btn_LoadCustomCharacterL);
            this.tabP_Result.Location = new System.Drawing.Point(4, 22);
            this.tabP_Result.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabP_Result.Name = "tabP_Result";
            this.tabP_Result.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabP_Result.Size = new System.Drawing.Size(188, 337);
            this.tabP_Result.TabIndex = 1;
            this.tabP_Result.Text = "结果";
            this.tabP_Result.UseVisualStyleBackColor = true;
            // 
            // gBox_CharaResult
            // 
            this.gBox_CharaResult.Controls.Add(this.dGV_CharacterResult);
            this.gBox_CharaResult.Location = new System.Drawing.Point(4, 137);
            this.gBox_CharaResult.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBox_CharaResult.Name = "gBox_CharaResult";
            this.gBox_CharaResult.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBox_CharaResult.Size = new System.Drawing.Size(183, 203);
            this.gBox_CharaResult.TabIndex = 2;
            this.gBox_CharaResult.TabStop = false;
            this.gBox_CharaResult.Text = "读取结果";
            // 
            // dGV_CharacterResult
            // 
            this.dGV_CharacterResult.AllowUserToAddRows = false;
            this.dGV_CharacterResult.AllowUserToDeleteRows = false;
            this.dGV_CharacterResult.AllowUserToResizeColumns = false;
            this.dGV_CharacterResult.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_CharacterResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGV_CharacterResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_CharacterResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C_Character,
            this.C_Scale});
            this.dGV_CharacterResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV_CharacterResult.Location = new System.Drawing.Point(2, 16);
            this.dGV_CharacterResult.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dGV_CharacterResult.Name = "dGV_CharacterResult";
            this.dGV_CharacterResult.RowHeadersVisible = false;
            this.dGV_CharacterResult.RowTemplate.Height = 30;
            this.dGV_CharacterResult.Size = new System.Drawing.Size(179, 185);
            this.dGV_CharacterResult.TabIndex = 0;
            // 
            // C_Character
            // 
            this.C_Character.DataPropertyName = "character";
            this.C_Character.HeaderText = "字符";
            this.C_Character.Name = "C_Character";
            this.C_Character.ReadOnly = true;
            // 
            // C_Scale
            // 
            this.C_Scale.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.C_Scale.DataPropertyName = "scale";
            this.C_Scale.HeaderText = "得分";
            this.C_Scale.Name = "C_Scale";
            this.C_Scale.ReadOnly = true;
            // 
            // btn_ReadCharacter
            // 
            this.btn_ReadCharacter.Location = new System.Drawing.Point(94, 4);
            this.btn_ReadCharacter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_ReadCharacter.Name = "btn_ReadCharacter";
            this.btn_ReadCharacter.Size = new System.Drawing.Size(59, 37);
            this.btn_ReadCharacter.TabIndex = 1;
            this.btn_ReadCharacter.Text = "读取字符";
            this.btn_ReadCharacter.UseVisualStyleBackColor = true;
            this.btn_ReadCharacter.Click += new System.EventHandler(this.btn_ReadCharacter_Click);
            // 
            // btn_LoadCustomCharacterL
            // 
            this.btn_LoadCustomCharacterL.Location = new System.Drawing.Point(4, 4);
            this.btn_LoadCustomCharacterL.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_LoadCustomCharacterL.Name = "btn_LoadCustomCharacterL";
            this.btn_LoadCustomCharacterL.Size = new System.Drawing.Size(63, 37);
            this.btn_LoadCustomCharacterL.TabIndex = 0;
            this.btn_LoadCustomCharacterL.Text = "加载自定义字符库";
            this.btn_LoadCustomCharacterL.UseVisualStyleBackColor = true;
            this.btn_LoadCustomCharacterL.Click += new System.EventHandler(this.btn_LoadCustomCharacterL_Click);
            // 
            // OcrControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "OcrControl";
            this.Size = new System.Drawing.Size(611, 367);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabC_OcrOperate.ResumeLayout(false);
            this.tabP_CharacterExtract.ResumeLayout(false);
            this.tabP_CharacterExtract.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmud_GrayMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmud_GrayMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmud_AreaMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmud_AreaMin)).EndInit();
            this.tabP_Train.ResumeLayout(false);
            this.tabP_Train.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmud_CharacterHidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmud_CharacterWidth)).EndInit();
            this.tabP_Result.ResumeLayout(false);
            this.gBox_CharaResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_CharacterResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private HalWindow.HDisplay hDisplay1;
        private System.Windows.Forms.TabControl tabC_OcrOperate;
        private System.Windows.Forms.TabPage tabP_CharacterExtract;
        private System.Windows.Forms.TabPage tabP_Result;
        private System.Windows.Forms.Button btn_LoadImage;
        private System.Windows.Forms.NumericUpDown nmud_GrayMax;
        private System.Windows.Forms.NumericUpDown nmud_GrayMin;
        private System.Windows.Forms.NumericUpDown nmud_AreaMax;
        private System.Windows.Forms.NumericUpDown nmud_AreaMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_RoiModle;
        private System.Windows.Forms.Button btn_AddRoiModle;
        private System.Windows.Forms.Button btn_LoadCustomCharacterL;
        private System.Windows.Forms.Button btn_ReadCharacter;
        private System.Windows.Forms.GroupBox gBox_CharaResult;
        private System.Windows.Forms.DataGridView dGV_CharacterResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Character;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Scale;
        private System.Windows.Forms.TabPage tabP_Train;
        private System.Windows.Forms.Button btn_extract;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_TrainOcr;
        private System.Windows.Forms.TextBox txt_CharacterTrained;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nmud_CharacterHidth;
        private System.Windows.Forms.NumericUpDown nmud_CharacterWidth;
        private System.Windows.Forms.CheckedListBox cklb_SortRegionModle;
        private System.Windows.Forms.Button btn_CombineModle;
        private System.Windows.Forms.ComboBox cmb_ZoomModle;
        private System.Windows.Forms.Label label8;

    }
}
