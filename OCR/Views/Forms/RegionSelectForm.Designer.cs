namespace OCR.Views.Forms
{
    partial class RegionSelectForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstBoxRectangles = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip_btnChangeRegionName = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_btnDeleteRect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_btnClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatuslabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelImgSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.pictureBox_ImgSample = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbb_RegionProfile = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_PaperSize = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ManageProfile = new System.Windows.Forms.Button();
            this.btn_SaveAs = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.btn_Preview = new System.Windows.Forms.Button();
            this.btn_LoadImage = new System.Windows.Forms.Button();
            this.backgroundWorkerLoadImage = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ImgSample)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chứcNăngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1069, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thoátToolStripMenuItem});
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.chứcNăngToolStripMenuItem.Text = "Chức năng";
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.ThoátToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1069, 616);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1069, 584);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ảnh mẫu";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstBoxRectangles);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox_ImgSample);
            this.splitContainer1.Size = new System.Drawing.Size(1063, 565);
            this.splitContainer1.SplitterDistance = 245;
            this.splitContainer1.TabIndex = 0;
            // 
            // lstBoxRectangles
            // 
            this.lstBoxRectangles.ContextMenuStrip = this.contextMenuStrip1;
            this.lstBoxRectangles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoxRectangles.FormattingEnabled = true;
            this.lstBoxRectangles.Location = new System.Drawing.Point(0, 0);
            this.lstBoxRectangles.Name = "lstBoxRectangles";
            this.lstBoxRectangles.Size = new System.Drawing.Size(245, 565);
            this.lstBoxRectangles.TabIndex = 0;
            this.lstBoxRectangles.SelectedIndexChanged += new System.EventHandler(this.LstBoxRectangles_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_btnChangeRegionName,
            this.toolStrip_btnDeleteRect,
            this.toolStrip_btnClearAll});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(208, 92);
            // 
            // toolStrip_btnChangeRegionName
            // 
            this.toolStrip_btnChangeRegionName.Name = "toolStrip_btnChangeRegionName";
            this.toolStrip_btnChangeRegionName.Size = new System.Drawing.Size(207, 22);
            this.toolStrip_btnChangeRegionName.Text = "Sửa định danh";
            // 
            // toolStrip_btnDeleteRect
            // 
            this.toolStrip_btnDeleteRect.Name = "toolStrip_btnDeleteRect";
            this.toolStrip_btnDeleteRect.Size = new System.Drawing.Size(207, 22);
            this.toolStrip_btnDeleteRect.Text = "Xoá";
            // 
            // toolStrip_btnClearAll
            // 
            this.toolStrip_btnClearAll.Name = "toolStrip_btnClearAll";
            this.toolStrip_btnClearAll.Size = new System.Drawing.Size(207, 22);
            this.toolStrip_btnClearAll.Text = "Xoá hết tạo cấu hình mới";
            this.toolStrip_btnClearAll.Click += new System.EventHandler(this.ToolStrip_btnClearAll_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatuslabel,
            this.toolStripStatusLabelImgSize,
            this.toolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 543);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(814, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatuslabel
            // 
            this.toolStripStatuslabel.AutoSize = false;
            this.toolStripStatuslabel.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
            this.toolStripStatuslabel.Name = "toolStripStatuslabel";
            this.toolStripStatuslabel.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatuslabel.Text = "Status";
            this.toolStripStatuslabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelImgSize
            // 
            this.toolStripStatusLabelImgSize.AutoSize = false;
            this.toolStripStatusLabelImgSize.Name = "toolStripStatusLabelImgSize";
            this.toolStripStatusLabelImgSize.Size = new System.Drawing.Size(250, 17);
            this.toolStripStatusLabelImgSize.Text = "Image size";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Enabled = false;
            this.toolStripProgressBar.MarqueeAnimationSpeed = 25;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar.Visible = false;
            // 
            // pictureBox_ImgSample
            // 
            this.pictureBox_ImgSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_ImgSample.Enabled = false;
            this.pictureBox_ImgSample.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_ImgSample.Name = "pictureBox_ImgSample";
            this.pictureBox_ImgSample.Size = new System.Drawing.Size(814, 565);
            this.pictureBox_ImgSample.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_ImgSample.TabIndex = 0;
            this.pictureBox_ImgSample.TabStop = false;
            this.pictureBox_ImgSample.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicBox_MouseDown);
            this.pictureBox_ImgSample.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicBox_MouseMove);
            this.pictureBox_ImgSample.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicBox_MouseUp);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbb_RegionProfile);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbb_PaperSize);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btn_ManageProfile);
            this.panel2.Controls.Add(this.btn_SaveAs);
            this.panel2.Controls.Add(this.btn_Save);
            this.panel2.Controls.Add(this.btn_Apply);
            this.panel2.Controls.Add(this.btn_Preview);
            this.panel2.Controls.Add(this.btn_LoadImage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1069, 32);
            this.panel2.TabIndex = 0;
            // 
            // cbb_RegionProfile
            // 
            this.cbb_RegionProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbb_RegionProfile.FormattingEnabled = true;
            this.cbb_RegionProfile.Location = new System.Drawing.Point(743, 5);
            this.cbb_RegionProfile.Name = "cbb_RegionProfile";
            this.cbb_RegionProfile.Size = new System.Drawing.Size(121, 21);
            this.cbb_RegionProfile.TabIndex = 5;
            this.cbb_RegionProfile.SelectedIndexChanged += new System.EventHandler(this.Cbb_Profile_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(667, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên cấu hình:";
            // 
            // cbb_PaperSize
            // 
            this.cbb_PaperSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbb_PaperSize.FormattingEnabled = true;
            this.cbb_PaperSize.Location = new System.Drawing.Point(930, 5);
            this.cbb_PaperSize.Name = "cbb_PaperSize";
            this.cbb_PaperSize.Size = new System.Drawing.Size(136, 21);
            this.cbb_PaperSize.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(870, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Khổ giấy:";
            // 
            // btn_ManageProfile
            // 
            this.btn_ManageProfile.Location = new System.Drawing.Point(524, 3);
            this.btn_ManageProfile.Name = "btn_ManageProfile";
            this.btn_ManageProfile.Size = new System.Drawing.Size(118, 23);
            this.btn_ManageProfile.TabIndex = 0;
            this.btn_ManageProfile.Text = "Quản lý cấu hình";
            this.btn_ManageProfile.UseVisualStyleBackColor = true;
            this.btn_ManageProfile.Click += new System.EventHandler(this.Btn_ManageProfile_Click);
            // 
            // btn_SaveAs
            // 
            this.btn_SaveAs.Location = new System.Drawing.Point(422, 3);
            this.btn_SaveAs.Name = "btn_SaveAs";
            this.btn_SaveAs.Size = new System.Drawing.Size(96, 23);
            this.btn_SaveAs.TabIndex = 0;
            this.btn_SaveAs.Text = "Lưu mới";
            this.btn_SaveAs.UseVisualStyleBackColor = true;
            this.btn_SaveAs.Click += new System.EventHandler(this.Btn_SaveAs_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Enabled = false;
            this.btn_Save.Location = new System.Drawing.Point(332, 3);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(84, 23);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "Lưu";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // btn_Apply
            // 
            this.btn_Apply.Enabled = false;
            this.btn_Apply.Location = new System.Drawing.Point(217, 3);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(109, 23);
            this.btn_Apply.TabIndex = 0;
            this.btn_Apply.Text = "Lưu && Áp dụng";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // btn_Preview
            // 
            this.btn_Preview.Enabled = false;
            this.btn_Preview.Location = new System.Drawing.Point(115, 3);
            this.btn_Preview.Name = "btn_Preview";
            this.btn_Preview.Size = new System.Drawing.Size(96, 23);
            this.btn_Preview.TabIndex = 0;
            this.btn_Preview.Text = "Xem trước";
            this.btn_Preview.UseVisualStyleBackColor = true;
            this.btn_Preview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // btn_LoadImage
            // 
            this.btn_LoadImage.Location = new System.Drawing.Point(13, 3);
            this.btn_LoadImage.Name = "btn_LoadImage";
            this.btn_LoadImage.Size = new System.Drawing.Size(96, 23);
            this.btn_LoadImage.TabIndex = 0;
            this.btn_LoadImage.Text = "Tải ảnh lên";
            this.btn_LoadImage.UseVisualStyleBackColor = true;
            this.btn_LoadImage.Click += new System.EventHandler(this.BtnLoadImage_Click);
            // 
            // backgroundWorkerLoadImage
            // 
            this.backgroundWorkerLoadImage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerLoadImage_DoWork);
            this.backgroundWorkerLoadImage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerLoadImage_RunWorkerCompleted);
            // 
            // RegionSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 640);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RegionSelectForm";
            this.ShowInTaskbar = false;
            this.Text = "Chọn khu vực nhận dạng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RegionSelectForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ImgSample)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbb_PaperSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_LoadImage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstBoxRectangles;
        private System.Windows.Forms.PictureBox pictureBox_ImgSample;
        private System.Windows.Forms.Button btn_Preview;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatuslabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelImgSize;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoadImage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_btnDeleteRect;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_btnChangeRegionName;
        private System.Windows.Forms.Button btn_SaveAs;
        private System.Windows.Forms.ComboBox cbb_RegionProfile;
        private System.Windows.Forms.Button btn_ManageProfile;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_btnClearAll;
        private System.Windows.Forms.Button btn_Save;
    }
}