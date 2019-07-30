namespace OCR.Views.Forms
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.kêtNôiThiêtSbijGhiHinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spellCheckEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locAnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regionProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paperProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chonVungNhânDangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.imageBoxPanel = new System.Windows.Forms.Panel();
            this.pictureBox_ScanImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Scan = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_Prev = new System.Windows.Forms.Button();
            this.txt_BoxPage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_RegionProfile = new System.Windows.Forms.ComboBox();
            this.cbb_Lang = new System.Windows.Forms.ComboBox();
            this.btn_ActivePictureBox = new System.Windows.Forms.Button();
            this.btn_DeSelectedRegion = new System.Windows.Forms.Button();
            this.btn_RotateRight = new System.Windows.Forms.Button();
            this.btn_RotateLeft = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatuslabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelImgSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Result = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_ClearResult = new System.Windows.Forms.Button();
            this.btn_ExtractBaseOnROIProfile = new System.Windows.Forms.Button();
            this.btn_ExtractCurrentImageBaseOnRegionProfile = new System.Windows.Forms.Button();
            this.btn_ExtractText = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.backgroundWorkerForOCRFullCharacterOrROI = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerForLoadImage = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerForScan = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerVideoCapture = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerForOCRROISingleImage = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerForOCRROIAllImage = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.imageBoxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ScanImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.openFolderToolStripMenuItem,
            this.toolStripSeparator1,
            this.kêtNôiThiêtSbijGhiHinhToolStripMenuItem,
            this.scanConnectToolStripMenuItem,
            this.toolStripSeparator,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "&File";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(198, 22);
            this.openToolStripMenuItem1.Text = "&Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.openFolderToolStripMenuItem.Text = "Open &Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(195, 6);
            // 
            // kêtNôiThiêtSbijGhiHinhToolStripMenuItem
            // 
            this.kêtNôiThiêtSbijGhiHinhToolStripMenuItem.Name = "kêtNôiThiêtSbijGhiHinhToolStripMenuItem";
            this.kêtNôiThiêtSbijGhiHinhToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.kêtNôiThiêtSbijGhiHinhToolStripMenuItem.Text = "Kết nối thiết bị ghi hình";
            this.kêtNôiThiêtSbijGhiHinhToolStripMenuItem.Click += new System.EventHandler(this.ConnectVideoCaptureToolStripMenuItem_Click);
            // 
            // scanConnectToolStripMenuItem
            // 
            this.scanConnectToolStripMenuItem.Name = "scanConnectToolStripMenuItem";
            this.scanConnectToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.scanConnectToolStripMenuItem.Text = "Kết nối máy scan";
            this.scanConnectToolStripMenuItem.Click += new System.EventHandler(this.ScanConnectToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(195, 6);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(195, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(198, 22);
            this.exitToolStripMenuItem1.Text = "E&xit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spellCheckEditToolStripMenuItem,
            this.locAnhToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // spellCheckEditToolStripMenuItem
            // 
            this.spellCheckEditToolStripMenuItem.Name = "spellCheckEditToolStripMenuItem";
            this.spellCheckEditToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.spellCheckEditToolStripMenuItem.Text = "Spell Check & Edit";
            this.spellCheckEditToolStripMenuItem.Click += new System.EventHandler(this.SpellCheckEditToolStripMenuItem_Click);
            // 
            // locAnhToolStripMenuItem
            // 
            this.locAnhToolStripMenuItem.Name = "locAnhToolStripMenuItem";
            this.locAnhToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.locAnhToolStripMenuItem.Text = "Lọc ảnh";
            this.locAnhToolStripMenuItem.Click += new System.EventHandler(this.ThresholdToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regionProfileToolStripMenuItem,
            this.paperProfileToolStripMenuItem,
            this.chonVungNhânDangToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // regionProfileToolStripMenuItem
            // 
            this.regionProfileToolStripMenuItem.Name = "regionProfileToolStripMenuItem";
            this.regionProfileToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.regionProfileToolStripMenuItem.Text = "Quản lý cấu hình";
            this.regionProfileToolStripMenuItem.Click += new System.EventHandler(this.RegionProfileToolStripMenuItem_Click);
            // 
            // paperProfileToolStripMenuItem
            // 
            this.paperProfileToolStripMenuItem.Name = "paperProfileToolStripMenuItem";
            this.paperProfileToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.paperProfileToolStripMenuItem.Text = "Quảm lý loại giấy";
            this.paperProfileToolStripMenuItem.Click += new System.EventHandler(this.AddPaperProfileToolStripMenuItem_Click);
            // 
            // chonVungNhânDangToolStripMenuItem
            // 
            this.chonVungNhânDangToolStripMenuItem.Name = "chonVungNhânDangToolStripMenuItem";
            this.chonVungNhânDangToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.chonVungNhânDangToolStripMenuItem.Text = "Chọn vùng nhận dạng";
            this.chonVungNhânDangToolStripMenuItem.Click += new System.EventHandler(this.ChoseRegionInPageToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.imageBoxPanel);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 501);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scan Image";
            // 
            // imageBoxPanel
            // 
            this.imageBoxPanel.AutoScroll = true;
            this.imageBoxPanel.Controls.Add(this.pictureBox_ScanImage);
            this.imageBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBoxPanel.Location = new System.Drawing.Point(3, 70);
            this.imageBoxPanel.Name = "imageBoxPanel";
            this.imageBoxPanel.Size = new System.Drawing.Size(684, 428);
            this.imageBoxPanel.TabIndex = 4;
            // 
            // pictureBox_ScanImage
            // 
            this.pictureBox_ScanImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_ScanImage.Enabled = false;
            this.pictureBox_ScanImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_ScanImage.Name = "pictureBox_ScanImage";
            this.pictureBox_ScanImage.Size = new System.Drawing.Size(684, 428);
            this.pictureBox_ScanImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_ScanImage.TabIndex = 0;
            this.pictureBox_ScanImage.TabStop = false;
            this.pictureBox_ScanImage.EnabledChanged += new System.EventHandler(this.PictureBox_ScanImage_EnabledChanged);
            this.pictureBox_ScanImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcBoxScanImage_MouseDown);
            this.pictureBox_ScanImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcBoxScanImage_MouseMove);
            this.pictureBox_ScanImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pcBoxScanImage_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Scan);
            this.panel1.Controls.Add(this.btn_Next);
            this.panel1.Controls.Add(this.btn_Prev);
            this.panel1.Controls.Add(this.txt_BoxPage);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbb_RegionProfile);
            this.panel1.Controls.Add(this.cbb_Lang);
            this.panel1.Controls.Add(this.btn_ActivePictureBox);
            this.panel1.Controls.Add(this.btn_DeSelectedRegion);
            this.panel1.Controls.Add(this.btn_RotateRight);
            this.panel1.Controls.Add(this.btn_RotateLeft);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 54);
            this.panel1.TabIndex = 3;
            // 
            // btn_Scan
            // 
            this.btn_Scan.Enabled = false;
            this.btn_Scan.Location = new System.Drawing.Point(9, 4);
            this.btn_Scan.Name = "btn_Scan";
            this.btn_Scan.Size = new System.Drawing.Size(71, 47);
            this.btn_Scan.TabIndex = 0;
            this.btn_Scan.Text = "Scan/Capture";
            this.btn_Scan.UseVisualStyleBackColor = true;
            this.btn_Scan.Click += new System.EventHandler(this.Btn_Scan_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.Enabled = false;
            this.btn_Next.Location = new System.Drawing.Point(279, 30);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(89, 23);
            this.btn_Next.TabIndex = 4;
            this.btn_Next.Text = "Sau";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // btn_Prev
            // 
            this.btn_Prev.Enabled = false;
            this.btn_Prev.Location = new System.Drawing.Point(86, 29);
            this.btn_Prev.Name = "btn_Prev";
            this.btn_Prev.Size = new System.Drawing.Size(89, 23);
            this.btn_Prev.TabIndex = 4;
            this.btn_Prev.Text = "Trước";
            this.btn_Prev.UseVisualStyleBackColor = true;
            this.btn_Prev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // txt_BoxPage
            // 
            this.txt_BoxPage.Enabled = false;
            this.txt_BoxPage.Location = new System.Drawing.Point(182, 31);
            this.txt_BoxPage.Name = "txt_BoxPage";
            this.txt_BoxPage.Size = new System.Drawing.Size(90, 20);
            this.txt_BoxPage.TabIndex = 3;
            this.txt_BoxPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(497, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cấu hình:";
            this.label2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label2_MouseClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(497, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ngôn ngữ:";
            this.label1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label2_MouseClick);
            // 
            // cbb_RegionProfile
            // 
            this.cbb_RegionProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbb_RegionProfile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbb_RegionProfile.FormattingEnabled = true;
            this.cbb_RegionProfile.Location = new System.Drawing.Point(560, 27);
            this.cbb_RegionProfile.Name = "cbb_RegionProfile";
            this.cbb_RegionProfile.Size = new System.Drawing.Size(121, 21);
            this.cbb_RegionProfile.TabIndex = 9;
            this.cbb_RegionProfile.SelectedIndexChanged += new System.EventHandler(this.Cbb_RegionProfile_SelectedIndexChanged);
            // 
            // cbb_Lang
            // 
            this.cbb_Lang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbb_Lang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbb_Lang.FormattingEnabled = true;
            this.cbb_Lang.Location = new System.Drawing.Point(560, 4);
            this.cbb_Lang.Name = "cbb_Lang";
            this.cbb_Lang.Size = new System.Drawing.Size(121, 21);
            this.cbb_Lang.TabIndex = 10;
            this.cbb_Lang.SelectedIndexChanged += new System.EventHandler(this.LangComboBox_SelectedIndexChanged);
            // 
            // btn_ActivePictureBox
            // 
            this.btn_ActivePictureBox.Enabled = false;
            this.btn_ActivePictureBox.Location = new System.Drawing.Point(374, 5);
            this.btn_ActivePictureBox.Name = "btn_ActivePictureBox";
            this.btn_ActivePictureBox.Size = new System.Drawing.Size(103, 23);
            this.btn_ActivePictureBox.TabIndex = 0;
            this.btn_ActivePictureBox.Text = "Kích hoạt cắt ảnh";
            this.btn_ActivePictureBox.UseVisualStyleBackColor = true;
            this.btn_ActivePictureBox.Click += new System.EventHandler(this.Btn_ActivePictureBox_Click);
            // 
            // btn_DeSelectedRegion
            // 
            this.btn_DeSelectedRegion.Enabled = false;
            this.btn_DeSelectedRegion.Location = new System.Drawing.Point(278, 4);
            this.btn_DeSelectedRegion.Name = "btn_DeSelectedRegion";
            this.btn_DeSelectedRegion.Size = new System.Drawing.Size(90, 23);
            this.btn_DeSelectedRegion.TabIndex = 0;
            this.btn_DeSelectedRegion.Text = "Bỏ chọn";
            this.btn_DeSelectedRegion.UseVisualStyleBackColor = true;
            this.btn_DeSelectedRegion.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btn_RotateRight
            // 
            this.btn_RotateRight.Enabled = false;
            this.btn_RotateRight.Location = new System.Drawing.Point(182, 4);
            this.btn_RotateRight.Name = "btn_RotateRight";
            this.btn_RotateRight.Size = new System.Drawing.Size(90, 23);
            this.btn_RotateRight.TabIndex = 0;
            this.btn_RotateRight.Text = "Xoay phải";
            this.btn_RotateRight.UseVisualStyleBackColor = true;
            this.btn_RotateRight.Click += new System.EventHandler(this.btnRotateRight_Click);
            // 
            // btn_RotateLeft
            // 
            this.btn_RotateLeft.Enabled = false;
            this.btn_RotateLeft.Location = new System.Drawing.Point(86, 4);
            this.btn_RotateLeft.Name = "btn_RotateLeft";
            this.btn_RotateLeft.Size = new System.Drawing.Size(90, 23);
            this.btn_RotateLeft.TabIndex = 0;
            this.btn_RotateLeft.Text = "Xoay trái";
            this.btn_RotateLeft.UseVisualStyleBackColor = true;
            this.btn_RotateLeft.Click += new System.EventHandler(this.btnRotateLeft_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatuslabel,
            this.toolStripStatusLabelImgSize,
            this.toolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 525);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1370, 22);
            this.statusStrip1.TabIndex = 2;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_Result);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(676, 501);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Text";
            // 
            // dataGridView_Result
            // 
            this.dataGridView_Result.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Result.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_Result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Result.Location = new System.Drawing.Point(3, 59);
            this.dataGridView_Result.Name = "dataGridView_Result";
            this.dataGridView_Result.RowHeadersVisible = false;
            this.dataGridView_Result.Size = new System.Drawing.Size(670, 439);
            this.dataGridView_Result.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_ClearResult);
            this.panel2.Controls.Add(this.btn_ExtractBaseOnROIProfile);
            this.panel2.Controls.Add(this.btn_ExtractCurrentImageBaseOnRegionProfile);
            this.panel2.Controls.Add(this.btn_ExtractText);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(670, 43);
            this.panel2.TabIndex = 1;
            // 
            // btn_ClearResult
            // 
            this.btn_ClearResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ClearResult.Location = new System.Drawing.Point(577, 4);
            this.btn_ClearResult.Name = "btn_ClearResult";
            this.btn_ClearResult.Size = new System.Drawing.Size(90, 33);
            this.btn_ClearResult.TabIndex = 0;
            this.btn_ClearResult.Text = "Xoá kết quả";
            this.btn_ClearResult.UseVisualStyleBackColor = true;
            this.btn_ClearResult.Click += new System.EventHandler(this.btnClearTxt_Click);
            // 
            // btn_ExtractBaseOnRegionProfile
            // 
            this.btn_ExtractBaseOnROIProfile.Enabled = false;
            this.btn_ExtractBaseOnROIProfile.Location = new System.Drawing.Point(249, 3);
            this.btn_ExtractBaseOnROIProfile.Name = "btn_ExtractBaseOnRegionProfile";
            this.btn_ExtractBaseOnROIProfile.Size = new System.Drawing.Size(131, 37);
            this.btn_ExtractBaseOnROIProfile.TabIndex = 2;
            this.btn_ExtractBaseOnROIProfile.Text = "Trích xuất tất cả ảnh theo cấu hình";
            this.btn_ExtractBaseOnROIProfile.UseVisualStyleBackColor = true;
            this.btn_ExtractBaseOnROIProfile.Click += new System.EventHandler(this.Btn_ExtractBaseOnROIAllImage_Click);
            // 
            // btn_ExtractCurrentImageBaseOnRegionProfile
            // 
            this.btn_ExtractCurrentImageBaseOnRegionProfile.Enabled = false;
            this.btn_ExtractCurrentImageBaseOnRegionProfile.Location = new System.Drawing.Point(89, 3);
            this.btn_ExtractCurrentImageBaseOnRegionProfile.Name = "btn_ExtractCurrentImageBaseOnRegionProfile";
            this.btn_ExtractCurrentImageBaseOnRegionProfile.Size = new System.Drawing.Size(154, 37);
            this.btn_ExtractCurrentImageBaseOnRegionProfile.TabIndex = 1;
            this.btn_ExtractCurrentImageBaseOnRegionProfile.Text = "Trích xuất ảnh hiện tại theo cấu hình";
            this.btn_ExtractCurrentImageBaseOnRegionProfile.UseVisualStyleBackColor = true;
            this.btn_ExtractCurrentImageBaseOnRegionProfile.Click += new System.EventHandler(this.btnExtractROISingleImage_Click);
            // 
            // btn_ExtractText
            // 
            this.btn_ExtractText.Enabled = false;
            this.btn_ExtractText.Location = new System.Drawing.Point(8, 2);
            this.btn_ExtractText.Name = "btn_ExtractText";
            this.btn_ExtractText.Size = new System.Drawing.Size(75, 38);
            this.btn_ExtractText.TabIndex = 0;
            this.btn_ExtractText.Text = "Trích xuất văn bản";
            this.btn_ExtractText.UseVisualStyleBackColor = true;
            this.btn_ExtractText.Click += new System.EventHandler(this.BtnOCRProcess_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1370, 501);
            this.splitContainer1.SplitterDistance = 690;
            this.splitContainer1.TabIndex = 3;
            // 
            // backgroundWorkerForOCRFullCharacterOrROI
            // 
            this.backgroundWorkerForOCRFullCharacterOrROI.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerForOCRFullCharacterOrROI_DoWork);
            this.backgroundWorkerForOCRFullCharacterOrROI.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerForOCR_RunWorkerCompleted);
            // 
            // backgroundWorkerForLoadImage
            // 
            this.backgroundWorkerForLoadImage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerForLoadImage_DoWork);
            this.backgroundWorkerForLoadImage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerForLoadImage_RunWorkerCompleted);
            // 
            // backgroundWorkerForScan
            // 
            this.backgroundWorkerForScan.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerForScanner_DoWork);
            this.backgroundWorkerForScan.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerForScanner_RunWorkerCompleted);
            // 
            // backgroundWorkerVideoCapture
            // 
            this.backgroundWorkerVideoCapture.WorkerSupportsCancellation = true;
            this.backgroundWorkerVideoCapture.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerVideoCapture_DoWork);
            this.backgroundWorkerVideoCapture.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerVideoCapture_RunWorkerCompleted);
            // 
            // backgroundWorkerForOCRROISingleImage
            // 
            this.backgroundWorkerForOCRROISingleImage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerForOCRROISingleImage_DoWork);
            this.backgroundWorkerForOCRROISingleImage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerForOCR_RunWorkerCompleted);
            // 
            // backgroundWorkerForOCRROIAllImage
            // 
            this.backgroundWorkerForOCRROIAllImage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerForOCRROIAllImage_DoWork);
            this.backgroundWorkerForOCRROIAllImage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerForOCR_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 547);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Scan to Text";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.imageBoxPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ScanImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result)).EndInit();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatuslabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerForOCRFullCharacterOrROI;
        private System.Windows.Forms.ToolStripMenuItem spellCheckEditToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_RotateRight;
        private System.Windows.Forms.Button btn_RotateLeft;
        private System.Windows.Forms.Button btn_ClearResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbb_Lang;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelImgSize;
        private System.ComponentModel.BackgroundWorker backgroundWorkerForLoadImage;
        private System.Windows.Forms.Panel imageBoxPanel;
        private System.Windows.Forms.Button btn_DeSelectedRegion;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btn_Prev;
        private System.Windows.Forms.TextBox txt_BoxPage;
        private System.Windows.Forms.ToolStripMenuItem paperProfileToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_RegionProfile;
        private System.Windows.Forms.PictureBox pictureBox_ScanImage;
        private System.Windows.Forms.ToolStripMenuItem locAnhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chonVungNhânDangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regionProfileToolStripMenuItem;
        private System.Windows.Forms.Button btn_ExtractBaseOnROIProfile;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView_Result;
        private System.Windows.Forms.Button btn_ExtractCurrentImageBaseOnRegionProfile;
        private System.Windows.Forms.Button btn_ExtractText;
        private System.Windows.Forms.Button btn_ActivePictureBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem scanConnectToolStripMenuItem;
        private System.Windows.Forms.Button btn_Scan;
        private System.ComponentModel.BackgroundWorker backgroundWorkerForScan;
        private System.Windows.Forms.ToolStripMenuItem kêtNôiThiêtSbijGhiHinhToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerVideoCapture;
        private System.ComponentModel.BackgroundWorker backgroundWorkerForOCRROISingleImage;
        private System.ComponentModel.BackgroundWorker backgroundWorkerForOCRROIAllImage;
    }
}

