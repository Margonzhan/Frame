using DevExpress.XtraCharts;
namespace Fram.FormFolder
{
    partial class FormAuto
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.SwiftPlotDiagram swiftPlotDiagram1 = new DevExpress.XtraCharts.SwiftPlotDiagram();
            Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView1 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView2 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAuto));
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_TotalTime = new System.Windows.Forms.TextBox();
            this.txt_ReverseTime = new System.Windows.Forms.TextBox();
            this.txtReverseAngle = new System.Windows.Forms.TextBox();
            this.txt_ForwardTime = new System.Windows.Forms.TextBox();
            this.txt_RealTimeV = new System.Windows.Forms.TextBox();
            this.txt_ForwardAngle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ReverseTargetV = new System.Windows.Forms.TextBox();
            this.txt_ForwardTargetV = new System.Windows.Forms.TextBox();
            this.txt_MidV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pB_Run = new System.Windows.Forms.PictureBox();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pB_Run)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControl1
            // 
            swiftPlotDiagram1.AxisX.Title.Text = "Time";
            swiftPlotDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            swiftPlotDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram1.AxisY.Interlaced = true;
            swiftPlotDiagram1.AxisY.Title.Text = "Voltage";
            swiftPlotDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            swiftPlotDiagram1.AxisY.Visibility = DevExpress.Utils.DefaultBoolean.True;
            swiftPlotDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram1.AxisY.VisualRange.Auto = false;
            swiftPlotDiagram1.AxisY.VisualRange.MaxValueSerializable = "5";
            swiftPlotDiagram1.AxisY.VisualRange.MinValueSerializable = "0";
            swiftPlotDiagram1.AxisY.WholeRange.Auto = false;
            swiftPlotDiagram1.AxisY.WholeRange.MaxValueSerializable = "5";
            swiftPlotDiagram1.AxisY.WholeRange.MinValueSerializable = "0";
            swiftPlotDiagram1.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.True;
            swiftPlotDiagram1.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.True;
            this.chartControl1.Diagram = swiftPlotDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(227, 2);
            this.chartControl1.Margin = new System.Windows.Forms.Padding(2);
            this.chartControl1.Name = "chartControl1";
            series1.Name = "Series 1";
            series1.ShowInLegend = false;
            series1.View = swiftPlotSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl1.SeriesTemplate.View = swiftPlotSeriesView2;
            this.chartControl1.Size = new System.Drawing.Size(709, 570);
            this.chartControl1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartControl1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(938, 574);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(221, 570);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_TotalTime);
            this.groupBox2.Controls.Add(this.txt_ReverseTime);
            this.groupBox2.Controls.Add(this.txtReverseAngle);
            this.groupBox2.Controls.Add(this.txt_ForwardTime);
            this.groupBox2.Controls.Add(this.txt_RealTimeV);
            this.groupBox2.Controls.Add(this.txt_ForwardAngle);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(2, 347);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(217, 221);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输出参数：";
            // 
            // txt_TotalTime
            // 
            this.txt_TotalTime.Location = new System.Drawing.Point(102, 188);
            this.txt_TotalTime.Name = "txt_TotalTime";
            this.txt_TotalTime.Size = new System.Drawing.Size(93, 21);
            this.txt_TotalTime.TabIndex = 7;
            // 
            // txt_ReverseTime
            // 
            this.txt_ReverseTime.Location = new System.Drawing.Point(102, 155);
            this.txt_ReverseTime.Name = "txt_ReverseTime";
            this.txt_ReverseTime.Size = new System.Drawing.Size(93, 21);
            this.txt_ReverseTime.TabIndex = 7;
            // 
            // txtReverseAngle
            // 
            this.txtReverseAngle.Location = new System.Drawing.Point(102, 122);
            this.txtReverseAngle.Name = "txtReverseAngle";
            this.txtReverseAngle.Size = new System.Drawing.Size(93, 21);
            this.txtReverseAngle.TabIndex = 7;
            // 
            // txt_ForwardTime
            // 
            this.txt_ForwardTime.Location = new System.Drawing.Point(102, 89);
            this.txt_ForwardTime.Name = "txt_ForwardTime";
            this.txt_ForwardTime.Size = new System.Drawing.Size(93, 21);
            this.txt_ForwardTime.TabIndex = 7;
            // 
            // txt_RealTimeV
            // 
            this.txt_RealTimeV.Location = new System.Drawing.Point(102, 23);
            this.txt_RealTimeV.Name = "txt_RealTimeV";
            this.txt_RealTimeV.Size = new System.Drawing.Size(93, 21);
            this.txt_RealTimeV.TabIndex = 7;
            // 
            // txt_ForwardAngle
            // 
            this.txt_ForwardAngle.Location = new System.Drawing.Point(102, 57);
            this.txt_ForwardAngle.Name = "txt_ForwardAngle";
            this.txt_ForwardAngle.Size = new System.Drawing.Size(93, 21);
            this.txt_ForwardAngle.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "单次总时间:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "反转查找时间:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "正转查找时间:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "反转查找角度:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "实时电压:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "正转查找角度:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_ReverseTargetV);
            this.groupBox1.Controls.Add(this.txt_ForwardTargetV);
            this.groupBox1.Controls.Add(this.txt_MidV);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(2, 122);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(217, 221);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数设置：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "中点电压：";
            // 
            // txt_ReverseTargetV
            // 
            this.txt_ReverseTargetV.Location = new System.Drawing.Point(102, 118);
            this.txt_ReverseTargetV.Name = "txt_ReverseTargetV";
            this.txt_ReverseTargetV.Size = new System.Drawing.Size(93, 21);
            this.txt_ReverseTargetV.TabIndex = 5;
            this.txt_ReverseTargetV.Text = "1";
            // 
            // txt_ForwardTargetV
            // 
            this.txt_ForwardTargetV.Location = new System.Drawing.Point(102, 79);
            this.txt_ForwardTargetV.Name = "txt_ForwardTargetV";
            this.txt_ForwardTargetV.Size = new System.Drawing.Size(93, 21);
            this.txt_ForwardTargetV.TabIndex = 5;
            this.txt_ForwardTargetV.Text = "4";
            // 
            // txt_MidV
            // 
            this.txt_MidV.Location = new System.Drawing.Point(102, 40);
            this.txt_MidV.Name = "txt_MidV";
            this.txt_MidV.Size = new System.Drawing.Size(93, 21);
            this.txt_MidV.TabIndex = 5;
            this.txt_MidV.Text = "2.5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "正转目标电压：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "反转目标电压：\r\n";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pB_Run);
            this.groupBox3.Controls.Add(this.btn_Stop);
            this.groupBox3.Controls.Add(this.btn_Start);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(2, 2);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(217, 116);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "运行：";
            // 
            // pB_Run
            // 
            this.pB_Run.BackColor = System.Drawing.Color.Transparent;
            this.pB_Run.Image = ((System.Drawing.Image)(resources.GetObject("pB_Run.Image")));
            this.pB_Run.Location = new System.Drawing.Point(102, 18);
            this.pB_Run.Margin = new System.Windows.Forms.Padding(2);
            this.pB_Run.Name = "pB_Run";
            this.pB_Run.Size = new System.Drawing.Size(110, 94);
            this.pB_Run.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_Run.TabIndex = 6;
            this.pB_Run.TabStop = false;
            // 
            // btn_Stop
            // 
            this.btn_Stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Stop.Location = new System.Drawing.Point(28, 78);
            this.btn_Stop.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(61, 34);
            this.btn_Stop.TabIndex = 3;
            this.btn_Stop.Text = "启动";
            this.btn_Stop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Start.Location = new System.Drawing.Point(28, 18);
            this.btn_Start.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(61, 34);
            this.btn_Start.TabIndex = 3;
            this.btn_Start.Text = "启动";
            this.btn_Start.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btn_Start, "启动");
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormAuto";
            this.Size = new System.Drawing.Size(938, 574);
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pB_Run)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ChartControl chartControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_ForwardAngle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ReverseTargetV;
        private System.Windows.Forms.TextBox txt_ForwardTargetV;
        private System.Windows.Forms.TextBox txt_MidV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_TotalTime;
        private System.Windows.Forms.TextBox txt_ReverseTime;
        private System.Windows.Forms.TextBox txtReverseAngle;
        private System.Windows.Forms.TextBox txt_ForwardTime;
        private System.Windows.Forms.TextBox txt_RealTimeV;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pB_Run;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button button1;
    }
}
