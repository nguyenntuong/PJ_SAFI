namespace OCR.Views.Additions.Dialogs
{
    partial class SelectFromDialog
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_FileLocal = new System.Windows.Forms.Button();
            this.btn_VideoCapture = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Cancel);
            this.groupBox1.Controls.Add(this.btn_VideoCapture);
            this.groupBox1.Controls.Add(this.btn_FileLocal);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nguồn:";
            // 
            // btn_FileLocal
            // 
            this.btn_FileLocal.Location = new System.Drawing.Point(47, 19);
            this.btn_FileLocal.Name = "btn_FileLocal";
            this.btn_FileLocal.Size = new System.Drawing.Size(192, 23);
            this.btn_FileLocal.TabIndex = 0;
            this.btn_FileLocal.Text = "Tệp trên máy";
            this.btn_FileLocal.UseVisualStyleBackColor = true;
            this.btn_FileLocal.Click += new System.EventHandler(this.Btn_FileLocal_Click);
            // 
            // btn_VideoCapture
            // 
            this.btn_VideoCapture.Location = new System.Drawing.Point(47, 48);
            this.btn_VideoCapture.Name = "btn_VideoCapture";
            this.btn_VideoCapture.Size = new System.Drawing.Size(192, 23);
            this.btn_VideoCapture.TabIndex = 0;
            this.btn_VideoCapture.Text = "Từ máy ảnh";
            this.btn_VideoCapture.UseVisualStyleBackColor = true;
            this.btn_VideoCapture.Click += new System.EventHandler(this.Btn_VideoCapture_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(47, 92);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(192, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Huỷ tác vụ";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // SelectFromDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 153);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(335, 192);
            this.MinimumSize = new System.Drawing.Size(335, 192);
            this.Name = "SelectFromDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn từ";
            this.Load += new System.EventHandler(this.SelectFromDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_VideoCapture;
        private System.Windows.Forms.Button btn_FileLocal;
        private System.Windows.Forms.Button btn_Cancel;
    }
}