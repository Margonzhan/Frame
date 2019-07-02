namespace Fram
{
    partial class FormIO
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel_IODevice = new System.Windows.Forms.TableLayoutPanel();
            this.groupCtr_OutputDevice = new DevExpress.XtraEditors.GroupControl();
            this.tLPanel_Output1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel_Output = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_OutputLastPage = new System.Windows.Forms.Button();
            this.btn_OutputNextPage = new System.Windows.Forms.Button();
            this.tLPanel_Output2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupCtr_InputDevice = new DevExpress.XtraEditors.GroupControl();
            this.tLPanel_Input1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel_Input = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_InputLastPage = new System.Windows.Forms.Button();
            this.btn_InputNextPage = new System.Windows.Forms.Button();
            this.tLPanel_Input2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_IODevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupCtr_OutputDevice)).BeginInit();
            this.groupCtr_OutputDevice.SuspendLayout();
            this.tLPanel_Output1.SuspendLayout();
            this.flowLayoutPanel_Output.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupCtr_InputDevice)).BeginInit();
            this.groupCtr_InputDevice.SuspendLayout();
            this.tLPanel_Input1.SuspendLayout();
            this.flowLayoutPanel_Input.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_IODevice
            // 
            this.tableLayoutPanel_IODevice.ColumnCount = 2;
            this.tableLayoutPanel_IODevice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_IODevice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_IODevice.Controls.Add(this.groupCtr_OutputDevice, 1, 0);
            this.tableLayoutPanel_IODevice.Controls.Add(this.groupCtr_InputDevice, 0, 0);
            this.tableLayoutPanel_IODevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_IODevice.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_IODevice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel_IODevice.Name = "tableLayoutPanel_IODevice";
            this.tableLayoutPanel_IODevice.RowCount = 1;
            this.tableLayoutPanel_IODevice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_IODevice.Size = new System.Drawing.Size(1283, 785);
            this.tableLayoutPanel_IODevice.TabIndex = 1;
            // 
            // groupCtr_OutputDevice
            // 
            this.groupCtr_OutputDevice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupCtr_OutputDevice.Controls.Add(this.tLPanel_Output1);
            this.groupCtr_OutputDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupCtr_OutputDevice.Location = new System.Drawing.Point(644, 4);
            this.groupCtr_OutputDevice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupCtr_OutputDevice.Name = "groupCtr_OutputDevice";
            this.groupCtr_OutputDevice.Size = new System.Drawing.Size(636, 777);
            this.groupCtr_OutputDevice.TabIndex = 1;
            this.groupCtr_OutputDevice.Text = "OutputDevice";
            // 
            // tLPanel_Output1
            // 
            this.tLPanel_Output1.ColumnCount = 1;
            this.tLPanel_Output1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel_Output1.Controls.Add(this.flowLayoutPanel_Output, 0, 1);
            this.tLPanel_Output1.Controls.Add(this.tLPanel_Output2, 0, 0);
            this.tLPanel_Output1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanel_Output1.Location = new System.Drawing.Point(3, 33);
            this.tLPanel_Output1.Name = "tLPanel_Output1";
            this.tLPanel_Output1.RowCount = 2;
            this.tLPanel_Output1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel_Output1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tLPanel_Output1.Size = new System.Drawing.Size(630, 741);
            this.tLPanel_Output1.TabIndex = 1;
            // 
            // flowLayoutPanel_Output
            // 
            this.flowLayoutPanel_Output.Controls.Add(this.btn_OutputLastPage);
            this.flowLayoutPanel_Output.Controls.Add(this.btn_OutputNextPage);
            this.flowLayoutPanel_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_Output.Location = new System.Drawing.Point(3, 694);
            this.flowLayoutPanel_Output.Name = "flowLayoutPanel_Output";
            this.flowLayoutPanel_Output.Size = new System.Drawing.Size(624, 44);
            this.flowLayoutPanel_Output.TabIndex = 0;
            // 
            // btn_OutputLastPage
            // 
            this.btn_OutputLastPage.Location = new System.Drawing.Point(3, 3);
            this.btn_OutputLastPage.Name = "btn_OutputLastPage";
            this.btn_OutputLastPage.Size = new System.Drawing.Size(123, 39);
            this.btn_OutputLastPage.TabIndex = 0;
            this.btn_OutputLastPage.Text = "上一页";
            this.btn_OutputLastPage.UseVisualStyleBackColor = true;
            this.btn_OutputLastPage.Click += new System.EventHandler(this.btn_OutputLastPage_Click);
            // 
            // btn_OutputNextPage
            // 
            this.btn_OutputNextPage.Location = new System.Drawing.Point(132, 3);
            this.btn_OutputNextPage.Name = "btn_OutputNextPage";
            this.btn_OutputNextPage.Size = new System.Drawing.Size(123, 39);
            this.btn_OutputNextPage.TabIndex = 1;
            this.btn_OutputNextPage.Text = "下一页";
            this.btn_OutputNextPage.UseVisualStyleBackColor = true;
            this.btn_OutputNextPage.Click += new System.EventHandler(this.btn_OutputNextPage_Click);
            // 
            // tLPanel_Output2
            // 
            this.tLPanel_Output2.ColumnCount = 2;
            this.tLPanel_Output2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPanel_Output2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPanel_Output2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanel_Output2.Location = new System.Drawing.Point(3, 3);
            this.tLPanel_Output2.Name = "tLPanel_Output2";
            this.tLPanel_Output2.RowCount = 9;
            this.tLPanel_Output2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLPanel_Output2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLPanel_Output2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLPanel_Output2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLPanel_Output2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLPanel_Output2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLPanel_Output2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLPanel_Output2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLPanel_Output2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLPanel_Output2.Size = new System.Drawing.Size(624, 685);
            this.tLPanel_Output2.TabIndex = 1;
            // 
            // groupCtr_InputDevice
            // 
            this.groupCtr_InputDevice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupCtr_InputDevice.Controls.Add(this.tLPanel_Input1);
            this.groupCtr_InputDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupCtr_InputDevice.Location = new System.Drawing.Point(3, 4);
            this.groupCtr_InputDevice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupCtr_InputDevice.Name = "groupCtr_InputDevice";
            this.groupCtr_InputDevice.Size = new System.Drawing.Size(635, 777);
            this.groupCtr_InputDevice.TabIndex = 0;
            this.groupCtr_InputDevice.Text = "InputDevice";
            // 
            // tLPanel_Input1
            // 
            this.tLPanel_Input1.ColumnCount = 1;
            this.tLPanel_Input1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel_Input1.Controls.Add(this.flowLayoutPanel_Input, 0, 1);
            this.tLPanel_Input1.Controls.Add(this.tLPanel_Input2, 0, 0);
            this.tLPanel_Input1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanel_Input1.Location = new System.Drawing.Point(3, 33);
            this.tLPanel_Input1.Name = "tLPanel_Input1";
            this.tLPanel_Input1.RowCount = 2;
            this.tLPanel_Input1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel_Input1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tLPanel_Input1.Size = new System.Drawing.Size(629, 741);
            this.tLPanel_Input1.TabIndex = 0;
            // 
            // flowLayoutPanel_Input
            // 
            this.flowLayoutPanel_Input.Controls.Add(this.btn_InputLastPage);
            this.flowLayoutPanel_Input.Controls.Add(this.btn_InputNextPage);
            this.flowLayoutPanel_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_Input.Location = new System.Drawing.Point(3, 694);
            this.flowLayoutPanel_Input.Name = "flowLayoutPanel_Input";
            this.flowLayoutPanel_Input.Size = new System.Drawing.Size(623, 44);
            this.flowLayoutPanel_Input.TabIndex = 2;
            // 
            // btn_InputLastPage
            // 
            this.btn_InputLastPage.Location = new System.Drawing.Point(3, 3);
            this.btn_InputLastPage.Name = "btn_InputLastPage";
            this.btn_InputLastPage.Size = new System.Drawing.Size(123, 39);
            this.btn_InputLastPage.TabIndex = 0;
            this.btn_InputLastPage.Text = "上一页";
            this.btn_InputLastPage.UseVisualStyleBackColor = true;
            this.btn_InputLastPage.Click += new System.EventHandler(this.btn_InputLastPage_Click);
            // 
            // btn_InputNextPage
            // 
            this.btn_InputNextPage.Location = new System.Drawing.Point(132, 3);
            this.btn_InputNextPage.Name = "btn_InputNextPage";
            this.btn_InputNextPage.Size = new System.Drawing.Size(123, 39);
            this.btn_InputNextPage.TabIndex = 1;
            this.btn_InputNextPage.Text = "下一页";
            this.btn_InputNextPage.UseVisualStyleBackColor = true;
            this.btn_InputNextPage.Click += new System.EventHandler(this.btn_InputNextPage_Click);
            // 
            // tLPanel_Input2
            // 
            this.tLPanel_Input2.ColumnCount = 2;
            this.tLPanel_Input2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPanel_Input2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPanel_Input2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanel_Input2.Location = new System.Drawing.Point(3, 3);
            this.tLPanel_Input2.Name = "tLPanel_Input2";
            this.tLPanel_Input2.RowCount = 9;
            this.tLPanel_Input2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLPanel_Input2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLPanel_Input2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLPanel_Input2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLPanel_Input2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLPanel_Input2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLPanel_Input2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLPanel_Input2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLPanel_Input2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLPanel_Input2.Size = new System.Drawing.Size(623, 685);
            this.tLPanel_Input2.TabIndex = 1;
            // 
            // FormIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 785);
            this.Controls.Add(this.tableLayoutPanel_IODevice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormIO";
            this.Text = "FormIO";
            this.tableLayoutPanel_IODevice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupCtr_OutputDevice)).EndInit();
            this.groupCtr_OutputDevice.ResumeLayout(false);
            this.tLPanel_Output1.ResumeLayout(false);
            this.flowLayoutPanel_Output.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupCtr_InputDevice)).EndInit();
            this.groupCtr_InputDevice.ResumeLayout(false);
            this.tLPanel_Input1.ResumeLayout(false);
            this.flowLayoutPanel_Input.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_IODevice;
        private DevExpress.XtraEditors.GroupControl groupCtr_OutputDevice;
        private DevExpress.XtraEditors.GroupControl groupCtr_InputDevice;
    

        private System.Windows.Forms.TableLayoutPanel tLPanel_Output1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Output;
        private System.Windows.Forms.Button btn_OutputLastPage;
        private System.Windows.Forms.Button btn_OutputNextPage;
        private System.Windows.Forms.TableLayoutPanel tLPanel_Output2;
        private System.Windows.Forms.TableLayoutPanel tLPanel_Input1;
        private System.Windows.Forms.TableLayoutPanel tLPanel_Input2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Input;
        private System.Windows.Forms.Button btn_InputLastPage;
        private System.Windows.Forms.Button btn_InputNextPage;
    }
}