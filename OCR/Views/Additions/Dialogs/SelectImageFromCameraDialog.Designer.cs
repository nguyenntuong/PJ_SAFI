namespace OCR.Views.Additions.Dialogs
{
    partial class SelectImageFromCameraDialog
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
            this.btn_Apply = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Capture = new System.Windows.Forms.Button();
            this.btn_SelectCapture = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox_ImgPreview = new System.Windows.Forms.PictureBox();
            this.backgroundWorkerForVideoCapture = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ImgPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Apply);
            this.groupBox1.Controls.Add(this.btn_Exit);
            this.groupBox1.Controls.Add(this.btn_Capture);
            this.groupBox1.Controls.Add(this.btn_SelectCapture);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Công cụ";
            // 
            // btn_Apply
            // 
            this.btn_Apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Apply.Location = new System.Drawing.Point(546, 20);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(113, 23);
            this.btn_Apply.TabIndex = 0;
            this.btn_Apply.Text = "Xác nhận";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.Btn_Apply_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Exit.Location = new System.Drawing.Point(665, 19);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(113, 23);
            this.btn_Exit.TabIndex = 0;
            this.btn_Exit.Text = "Thoát";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.Btn_Exit_Click);
            // 
            // btn_Capture
            // 
            this.btn_Capture.Location = new System.Drawing.Point(132, 20);
            this.btn_Capture.Name = "btn_Capture";
            this.btn_Capture.Size = new System.Drawing.Size(113, 23);
            this.btn_Capture.TabIndex = 0;
            this.btn_Capture.Text = "Chụp lại";
            this.btn_Capture.UseVisualStyleBackColor = true;
            this.btn_Capture.Click += new System.EventHandler(this.Btn_Capture_Click);
            // 
            // btn_SelectCapture
            // 
            this.btn_SelectCapture.Location = new System.Drawing.Point(13, 20);
            this.btn_SelectCapture.Name = "btn_SelectCapture";
            this.btn_SelectCapture.Size = new System.Drawing.Size(113, 23);
            this.btn_SelectCapture.TabIndex = 0;
            this.btn_SelectCapture.Text = "Chọn Camera";
            this.btn_SelectCapture.UseVisualStyleBackColor = true;
            this.btn_SelectCapture.Click += new System.EventHandler(this.Btn_SelectCapture_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox_ImgPreview);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(808, 456);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ảnh xem trước";
            // 
            // pictureBox_ImgPreview
            // 
            this.pictureBox_ImgPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_ImgPreview.Location = new System.Drawing.Point(3, 16);
            this.pictureBox_ImgPreview.Name = "pictureBox_ImgPreview";
            this.pictureBox_ImgPreview.Size = new System.Drawing.Size(802, 437);
            this.pictureBox_ImgPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_ImgPreview.TabIndex = 0;
            this.pictureBox_ImgPreview.TabStop = false;
            // 
            // backgroundWorkerForVideoCapture
            // 
            this.backgroundWorkerForVideoCapture.WorkerSupportsCancellation = true;
            this.backgroundWorkerForVideoCapture.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerForVideoCapture_DoWork);
            this.backgroundWorkerForVideoCapture.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerForVideoCapture_RunWorkerCompleted);
            // 
            // SelectImageFromCameraDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Exit;
            this.ClientSize = new System.Drawing.Size(790, 509);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SelectImageFromCameraDialog";
            this.ShowInTaskbar = false;
            this.Text = "Chọn ảnh từ máy ghi ảnh";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ImgPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorkerForVideoCapture;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Capture;
        private System.Windows.Forms.Button btn_SelectCapture;
        private System.Windows.Forms.PictureBox pictureBox_ImgPreview;
    }
}