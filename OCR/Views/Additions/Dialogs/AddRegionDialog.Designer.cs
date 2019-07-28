namespace OCR.Views.Additions.Dialogs
{
    partial class AddRegionDialog
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
            this.cbb_Language = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Accept = new System.Windows.Forms.Button();
            this.txt_RectRegion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Identifer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_AZaz = new System.Windows.Forms.CheckBox();
            this.checkBox_09 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_SpecialCharacter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox_AllMatch = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_09);
            this.groupBox1.Controls.Add(this.checkBox_AllMatch);
            this.groupBox1.Controls.Add(this.checkBox_AZaz);
            this.groupBox1.Controls.Add(this.cbb_Language);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_Cancel);
            this.groupBox1.Controls.Add(this.btn_Accept);
            this.groupBox1.Controls.Add(this.txt_SpecialCharacter);
            this.groupBox1.Controls.Add(this.txt_RectRegion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_Identifer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin khu vực đã chọn";
            // 
            // cbb_Language
            // 
            this.cbb_Language.FormattingEnabled = true;
            this.cbb_Language.Location = new System.Drawing.Point(93, 56);
            this.cbb_Language.Name = "cbb_Language";
            this.cbb_Language.Size = new System.Drawing.Size(151, 21);
            this.cbb_Language.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ngôn ngữ:";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(291, 159);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Huỷ";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // btn_Accept
            // 
            this.btn_Accept.Location = new System.Drawing.Point(196, 159);
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Size = new System.Drawing.Size(75, 23);
            this.btn_Accept.TabIndex = 0;
            this.btn_Accept.Text = "Xác nhận";
            this.btn_Accept.UseVisualStyleBackColor = true;
            this.btn_Accept.Click += new System.EventHandler(this.Btn_Accept_Click);
            // 
            // txt_RectRegion
            // 
            this.txt_RectRegion.Enabled = false;
            this.txt_RectRegion.Location = new System.Drawing.Point(93, 133);
            this.txt_RectRegion.Name = "txt_RectRegion";
            this.txt_RectRegion.Size = new System.Drawing.Size(273, 20);
            this.txt_RectRegion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Khu vực bao :";
            // 
            // txt_Identifer
            // 
            this.txt_Identifer.Location = new System.Drawing.Point(93, 29);
            this.txt_Identifer.Name = "txt_Identifer";
            this.txt_Identifer.Size = new System.Drawing.Size(273, 20);
            this.txt_Identifer.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Định danh :";
            // 
            // checkBox_AZaz
            // 
            this.checkBox_AZaz.AutoSize = true;
            this.checkBox_AZaz.Checked = true;
            this.checkBox_AZaz.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AZaz.Location = new System.Drawing.Point(165, 83);
            this.checkBox_AZaz.Name = "checkBox_AZaz";
            this.checkBox_AZaz.Size = new System.Drawing.Size(60, 17);
            this.checkBox_AZaz.TabIndex = 13;
            this.checkBox_AZaz.Text = "A-Z a-z";
            this.checkBox_AZaz.UseVisualStyleBackColor = true;
            // 
            // checkBox_09
            // 
            this.checkBox_09.AutoSize = true;
            this.checkBox_09.Checked = true;
            this.checkBox_09.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_09.Location = new System.Drawing.Point(231, 84);
            this.checkBox_09.Name = "checkBox_09";
            this.checkBox_09.Size = new System.Drawing.Size(41, 17);
            this.checkBox_09.TabIndex = 13;
            this.checkBox_09.Text = "0-9";
            this.checkBox_09.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ký tự đặc biệt:";
            // 
            // txt_SpecialCharacter
            // 
            this.txt_SpecialCharacter.Location = new System.Drawing.Point(93, 107);
            this.txt_SpecialCharacter.Name = "txt_SpecialCharacter";
            this.txt_SpecialCharacter.Size = new System.Drawing.Size(273, 20);
            this.txt_SpecialCharacter.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Lọc:";
            // 
            // checkBox_AllMatch
            // 
            this.checkBox_AllMatch.AutoSize = true;
            this.checkBox_AllMatch.Checked = true;
            this.checkBox_AllMatch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AllMatch.Location = new System.Drawing.Point(93, 83);
            this.checkBox_AllMatch.Name = "checkBox_AllMatch";
            this.checkBox_AllMatch.Size = new System.Drawing.Size(57, 17);
            this.checkBox_AllMatch.TabIndex = 13;
            this.checkBox_AllMatch.Text = "Tất cả";
            this.checkBox_AllMatch.UseVisualStyleBackColor = true;
            this.checkBox_AllMatch.CheckedChanged += new System.EventHandler(this.CheckBox_AllMatch_CheckedChanged);
            // 
            // AddRegionDialog
            // 
            this.AcceptButton = this.btn_Accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(378, 194);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddRegionDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm khu vực này vào danh sách";
            this.Load += new System.EventHandler(this.AddRegionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Accept;
        private System.Windows.Forms.TextBox txt_RectRegion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Identifer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbb_Language;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox_09;
        private System.Windows.Forms.CheckBox checkBox_AZaz;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_SpecialCharacter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox_AllMatch;
    }
}