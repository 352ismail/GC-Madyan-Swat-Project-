namespace College_Management_System.frmReports
{
    partial class frmTranscriptReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTranscriptReport));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbSession2 = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbClassNo2 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbFaculty2 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbClassName2 = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbSession2);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.cmbClassNo2);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.cmbFaculty2);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.cmbClassName2);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1278, 79);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            // 
            // cmbSession2
            // 
            this.cmbSession2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSession2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSession2.Enabled = false;
            this.cmbSession2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSession2.FormattingEnabled = true;
            this.cmbSession2.Location = new System.Drawing.Point(774, 26);
            this.cmbSession2.Name = "cmbSession2";
            this.cmbSession2.Size = new System.Drawing.Size(169, 31);
            this.cmbSession2.TabIndex = 18;
            this.cmbSession2.SelectedIndexChanged += new System.EventHandler(this.cmbSession2_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(691, 30);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 23);
            this.label18.TabIndex = 17;
            this.label18.Text = "Session";
            // 
            // cmbClassNo2
            // 
            this.cmbClassNo2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbClassNo2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClassNo2.Enabled = false;
            this.cmbClassNo2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClassNo2.FormattingEnabled = true;
            this.cmbClassNo2.Location = new System.Drawing.Point(1043, 26);
            this.cmbClassNo2.Name = "cmbClassNo2";
            this.cmbClassNo2.Size = new System.Drawing.Size(212, 31);
            this.cmbClassNo2.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(958, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 23);
            this.label14.TabIndex = 15;
            this.label14.Text = "Roll No";
            // 
            // cmbFaculty2
            // 
            this.cmbFaculty2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbFaculty2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFaculty2.Enabled = false;
            this.cmbFaculty2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFaculty2.FormattingEnabled = true;
            this.cmbFaculty2.Location = new System.Drawing.Point(426, 26);
            this.cmbFaculty2.Name = "cmbFaculty2";
            this.cmbFaculty2.Size = new System.Drawing.Size(259, 31);
            this.cmbFaculty2.TabIndex = 12;
            this.cmbFaculty2.SelectedIndexChanged += new System.EventHandler(this.cmbFaculty2_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(338, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 23);
            this.label16.TabIndex = 11;
            this.label16.Text = "Faculty";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(93, 23);
            this.label17.TabIndex = 6;
            this.label17.Text = "Program";
            // 
            // cmbClassName2
            // 
            this.cmbClassName2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbClassName2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClassName2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClassName2.FormattingEnabled = true;
            this.cmbClassName2.Location = new System.Drawing.Point(112, 24);
            this.cmbClassName2.Name = "cmbClassName2";
            this.cmbClassName2.Size = new System.Drawing.Size(205, 31);
            this.cmbClassName2.TabIndex = 2;
            this.cmbClassName2.SelectedIndexChanged += new System.EventHandler(this.cmbClassName2_SelectedIndexChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button2);
            this.groupBox7.Controls.Add(this.button9);
            this.groupBox7.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(1296, 7);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(256, 84);
            this.groupBox7.TabIndex = 22;
            this.groupBox7.TabStop = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(7, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 51);
            this.button2.TabIndex = 1;
            this.button2.Text = "View";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(126, 22);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(113, 51);
            this.button9.TabIndex = 1;
            this.button9.Text = "Reset";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 114);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1924, 936);
            this.crystalReportViewer1.TabIndex = 24;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmTranscriptReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox7);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTranscriptReport";
            this.Text = "Transcript";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTranscriptReport_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.ComboBox cmbSession2;
        internal System.Windows.Forms.Label label18;
        internal System.Windows.Forms.ComboBox cmbClassNo2;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.ComboBox cmbFaculty2;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.ComboBox cmbClassName2;
        internal System.Windows.Forms.GroupBox groupBox7;
        internal System.Windows.Forms.Button button2;
        internal System.Windows.Forms.Button button9;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}