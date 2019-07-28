namespace OCR.Views.Additions.Dialogs
{
    partial class ScanDeviceSelectDialog
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
            this.cbb_ScanDeviceLists = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lst_ScanProperties = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbb_ScanDeviceLists
            // 
            this.cbb_ScanDeviceLists.FormattingEnabled = true;
            this.cbb_ScanDeviceLists.Location = new System.Drawing.Point(12, 19);
            this.cbb_ScanDeviceLists.Name = "cbb_ScanDeviceLists";
            this.cbb_ScanDeviceLists.Size = new System.Drawing.Size(259, 21);
            this.cbb_ScanDeviceLists.TabIndex = 0;
            this.cbb_ScanDeviceLists.SelectedIndexChanged += new System.EventHandler(this.Cbb_ScanDeviceLists_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Exit);
            this.groupBox1.Controls.Add(this.btn_Apply);
            this.groupBox1.Controls.Add(this.cbb_ScanDeviceLists);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 53);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách máy scan";
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(379, 17);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(91, 23);
            this.btn_Exit.TabIndex = 1;
            this.btn_Exit.Text = "Huỷ";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.Btn_Exit_Click);
            // 
            // btn_Apply
            // 
            this.btn_Apply.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Apply.Location = new System.Drawing.Point(282, 17);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(91, 23);
            this.btn_Apply.TabIndex = 1;
            this.btn_Apply.Text = "Áp dụng";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.Btn_Apply_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lst_ScanProperties);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(476, 174);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cấu hình";
            // 
            // lst_ScanProperties
            // 
            this.lst_ScanProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_ScanProperties.FormattingEnabled = true;
            this.lst_ScanProperties.Location = new System.Drawing.Point(3, 16);
            this.lst_ScanProperties.Name = "lst_ScanProperties";
            this.lst_ScanProperties.Size = new System.Drawing.Size(470, 155);
            this.lst_ScanProperties.TabIndex = 0;
            // 
            // ScanDeviceSelectDialog
            // 
            this.AcceptButton = this.btn_Apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Apply;
            this.ClientSize = new System.Drawing.Size(476, 227);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ScanDeviceSelectDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn máy scan";
            this.Load += new System.EventHandler(this.ScanDeviceSelectDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb_ScanDeviceLists;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lst_ScanProperties;
    }
}