namespace Fram.PrivateControl
{
    partial class AxisControlZd
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
            this.btn_Power = new System.Windows.Forms.Button();
            this.btn_Move = new System.Windows.Forms.Button();
            this.txt_Distance = new System.Windows.Forms.TextBox();
            this.cmB_MoveMode = new System.Windows.Forms.ComboBox();
            this.cmB_HomeDir = new System.Windows.Forms.ComboBox();
            this.btn_Home = new System.Windows.Forms.Button();
            this.label_AbsPosition = new System.Windows.Forms.Label();
            this.label_AxisName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_MaxSpeed = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Power
            // 
            this.btn_Power.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Power.Location = new System.Drawing.Point(201, 3);
            this.btn_Power.Name = "btn_Power";
            this.btn_Power.Size = new System.Drawing.Size(74, 26);
            this.btn_Power.TabIndex = 6;
            this.btn_Power.Text = "Power On";
            this.btn_Power.UseVisualStyleBackColor = true;
            this.btn_Power.Click += new System.EventHandler(this.btn_Power_Click);
            // 
            // btn_Move
            // 
            this.btn_Move.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_Move.Location = new System.Drawing.Point(763, 2);
            this.btn_Move.Margin = new System.Windows.Forms.Padding(15, 2, 2, 2);
            this.btn_Move.Name = "btn_Move";
            this.btn_Move.Size = new System.Drawing.Size(66, 27);
            this.btn_Move.TabIndex = 5;
            this.btn_Move.Text = "Move";
            this.btn_Move.UseVisualStyleBackColor = true;
            this.btn_Move.Click += new System.EventHandler(this.btn_Move_Click);
            // 
            // txt_Distance
            // 
            this.txt_Distance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_Distance.Location = new System.Drawing.Point(652, 5);
            this.txt_Distance.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Distance.Name = "txt_Distance";
            this.txt_Distance.Size = new System.Drawing.Size(94, 21);
            this.txt_Distance.TabIndex = 4;
            this.txt_Distance.Text = "0";
            this.txt_Distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmB_MoveMode
            // 
            this.cmB_MoveMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmB_MoveMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_MoveMode.FormattingEnabled = true;
            this.cmB_MoveMode.Items.AddRange(new object[] {
            "AbsMove",
            "RealMove"});
            this.cmB_MoveMode.Location = new System.Drawing.Point(457, 6);
            this.cmB_MoveMode.Margin = new System.Windows.Forms.Padding(2);
            this.cmB_MoveMode.Name = "cmB_MoveMode";
            this.cmB_MoveMode.Size = new System.Drawing.Size(92, 20);
            this.cmB_MoveMode.TabIndex = 3;
            // 
            // cmB_HomeDir
            // 
            this.cmB_HomeDir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmB_HomeDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_HomeDir.FormattingEnabled = true;
            this.cmB_HomeDir.Items.AddRange(new object[] {
            "Negative",
            "Positive"});
            this.cmB_HomeDir.Location = new System.Drawing.Point(284, 6);
            this.cmB_HomeDir.Margin = new System.Windows.Forms.Padding(2);
            this.cmB_HomeDir.Name = "cmB_HomeDir";
            this.cmB_HomeDir.Size = new System.Drawing.Size(92, 20);
            this.cmB_HomeDir.TabIndex = 3;
            // 
            // btn_Home
            // 
            this.btn_Home.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Home.Location = new System.Drawing.Point(383, 2);
            this.btn_Home.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Home.Name = "btn_Home";
            this.btn_Home.Size = new System.Drawing.Size(66, 27);
            this.btn_Home.TabIndex = 2;
            this.btn_Home.Text = "Home";
            this.btn_Home.UseVisualStyleBackColor = true;
            this.btn_Home.Click += new System.EventHandler(this.btn_Home_Click);
            // 
            // label_AbsPosition
            // 
            this.label_AbsPosition.AutoSize = true;
            this.label_AbsPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_AbsPosition.Location = new System.Drawing.Point(100, 0);
            this.label_AbsPosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_AbsPosition.Name = "label_AbsPosition";
            this.label_AbsPosition.Size = new System.Drawing.Size(94, 32);
            this.label_AbsPosition.TabIndex = 1;
            this.label_AbsPosition.Text = "AbsPosition";
            this.label_AbsPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_AxisName
            // 
            this.label_AxisName.AutoSize = true;
            this.label_AxisName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_AxisName.Location = new System.Drawing.Point(2, 0);
            this.label_AxisName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_AxisName.Name = "label_AxisName";
            this.label_AxisName.Size = new System.Drawing.Size(94, 32);
            this.label_AxisName.TabIndex = 0;
            this.label_AxisName.Text = "AxisName";
            this.label_AxisName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.Controls.Add(this.label_AxisName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_AbsPosition, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Home, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmB_HomeDir, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmB_MoveMode, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_Distance, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Move, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Power, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_MaxSpeed, 6, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(846, 32);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txt_MaxSpeed
            // 
            this.txt_MaxSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_MaxSpeed.Location = new System.Drawing.Point(554, 5);
            this.txt_MaxSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.txt_MaxSpeed.Name = "txt_MaxSpeed";
            this.txt_MaxSpeed.Size = new System.Drawing.Size(94, 21);
            this.txt_MaxSpeed.TabIndex = 4;
            this.txt_MaxSpeed.Text = "0";
            this.txt_MaxSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AxisControlZd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AxisControlZd";
            this.Size = new System.Drawing.Size(846, 32);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Power;
        private System.Windows.Forms.Button btn_Move;
        private System.Windows.Forms.TextBox txt_Distance;
        private System.Windows.Forms.ComboBox cmB_MoveMode;
        private System.Windows.Forms.ComboBox cmB_HomeDir;
        private System.Windows.Forms.Button btn_Home;
        private System.Windows.Forms.Label label_AbsPosition;
        private System.Windows.Forms.Label label_AxisName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txt_MaxSpeed;
    }
}
