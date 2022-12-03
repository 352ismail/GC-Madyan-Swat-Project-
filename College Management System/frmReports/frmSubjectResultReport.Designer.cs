namespace College_Management_System.frmReports
{
    partial class frmSubjectResultReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubjectResultReport));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdbSCE = new System.Windows.Forms.RadioButton();
            this.rdbMakeup = new System.Windows.Forms.RadioButton();
            this.rdbRepeat = new System.Windows.Forms.RadioButton();
            this.rdbFresh = new System.Windows.Forms.RadioButton();
            this.Session = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SubjectName = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Semester = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Branch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Course = new System.Windows.Forms.ComboBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button5);
            this.groupBox6.Controls.Add(this.button6);
            this.groupBox6.Location = new System.Drawing.Point(1790, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(122, 111);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(18, 14);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 41);
            this.button5.TabIndex = 0;
            this.button5.Text = "View";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(18, 64);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(98, 41);
            this.button6.TabIndex = 1;
            this.button6.Text = "Reset";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdbSCE);
            this.groupBox5.Controls.Add(this.rdbMakeup);
            this.groupBox5.Controls.Add(this.rdbRepeat);
            this.groupBox5.Controls.Add(this.rdbFresh);
            this.groupBox5.Controls.Add(this.Session);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.SubjectName);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.Semester);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.Branch);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.Label2);
            this.groupBox5.Controls.Add(this.Course);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1772, 111);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            // 
            // rdbSCE
            // 
            this.rdbSCE.AutoSize = true;
            this.rdbSCE.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSCE.Location = new System.Drawing.Point(1681, 70);
            this.rdbSCE.Name = "rdbSCE";
            this.rdbSCE.Size = new System.Drawing.Size(72, 27);
            this.rdbSCE.TabIndex = 21;
            this.rdbSCE.TabStop = true;
            this.rdbSCE.Text = "SCE";
            this.rdbSCE.UseVisualStyleBackColor = true;
            // 
            // rdbMakeup
            // 
            this.rdbMakeup.AutoSize = true;
            this.rdbMakeup.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMakeup.Location = new System.Drawing.Point(1559, 70);
            this.rdbMakeup.Name = "rdbMakeup";
            this.rdbMakeup.Size = new System.Drawing.Size(116, 27);
            this.rdbMakeup.TabIndex = 21;
            this.rdbMakeup.TabStop = true;
            this.rdbMakeup.Text = "MakeUp";
            this.rdbMakeup.UseVisualStyleBackColor = true;
            // 
            // rdbRepeat
            // 
            this.rdbRepeat.AutoSize = true;
            this.rdbRepeat.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbRepeat.Location = new System.Drawing.Point(1445, 70);
            this.rdbRepeat.Name = "rdbRepeat";
            this.rdbRepeat.Size = new System.Drawing.Size(108, 27);
            this.rdbRepeat.TabIndex = 21;
            this.rdbRepeat.TabStop = true;
            this.rdbRepeat.Text = "Repeat";
            this.rdbRepeat.UseVisualStyleBackColor = true;
            // 
            // rdbFresh
            // 
            this.rdbFresh.AutoSize = true;
            this.rdbFresh.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbFresh.Location = new System.Drawing.Point(1355, 70);
            this.rdbFresh.Name = "rdbFresh";
            this.rdbFresh.Size = new System.Drawing.Size(84, 27);
            this.rdbFresh.TabIndex = 21;
            this.rdbFresh.TabStop = true;
            this.rdbFresh.Text = "Fresh";
            this.rdbFresh.UseVisualStyleBackColor = true;
            // 
            // Session
            // 
            this.Session.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Session.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Session.Enabled = false;
            this.Session.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Session.FormattingEnabled = true;
            this.Session.Location = new System.Drawing.Point(794, 24);
            this.Session.Name = "Session";
            this.Session.Size = new System.Drawing.Size(172, 31);
            this.Session.TabIndex = 18;
            this.Session.SelectedIndexChanged += new System.EventHandler(this.Session_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(711, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 23);
            this.label5.TabIndex = 17;
            this.label5.Text = "Session";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(174, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 23);
            this.label11.TabIndex = 20;
            this.label11.Text = "label11";
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(29, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 23);
            this.label10.TabIndex = 19;
            this.label10.Text = "label10";
            this.label10.Visible = false;
            // 
            // SubjectName
            // 
            this.SubjectName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.SubjectName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.SubjectName.Enabled = false;
            this.SubjectName.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubjectName.FormattingEnabled = true;
            this.SubjectName.Location = new System.Drawing.Point(1421, 24);
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.Size = new System.Drawing.Size(313, 31);
            this.SubjectName.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1272, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(143, 23);
            this.label13.TabIndex = 15;
            this.label13.Text = "SubjectName";
            // 
            // Semester
            // 
            this.Semester.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Semester.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Semester.Enabled = false;
            this.Semester.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Semester.FormattingEnabled = true;
            this.Semester.Location = new System.Drawing.Point(1083, 24);
            this.Semester.Name = "Semester";
            this.Semester.Size = new System.Drawing.Size(173, 31);
            this.Semester.TabIndex = 14;
            this.Semester.SelectedIndexChanged += new System.EventHandler(this.Semester_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(978, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 23);
            this.label12.TabIndex = 13;
            this.label12.Text = "Semester";
            // 
            // Branch
            // 
            this.Branch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Branch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Branch.Enabled = false;
            this.Branch.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Branch.FormattingEnabled = true;
            this.Branch.Location = new System.Drawing.Point(378, 25);
            this.Branch.Name = "Branch";
            this.Branch.Size = new System.Drawing.Size(320, 31);
            this.Branch.TabIndex = 12;
            this.Branch.SelectedIndexChanged += new System.EventHandler(this.Branch_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(290, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Faculty";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(6, 32);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(93, 23);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Program";
            // 
            // Course
            // 
            this.Course.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Course.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Course.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Course.FormattingEnabled = true;
            this.Course.Location = new System.Drawing.Point(105, 25);
            this.Course.Name = "Course";
            this.Course.Size = new System.Drawing.Size(176, 31);
            this.Course.TabIndex = 2;
            this.Course.SelectedIndexChanged += new System.EventHandler(this.Course_SelectedIndexChanged);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 129);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1924, 921);
            this.crystalReportViewer1.TabIndex = 20;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmSubjectResultReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSubjectResultReport";
            this.Text = "Subject Result";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSubjectResultReport_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox groupBox6;
        internal System.Windows.Forms.Button button5;
        internal System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rdbSCE;
        private System.Windows.Forms.RadioButton rdbMakeup;
        private System.Windows.Forms.RadioButton rdbRepeat;
        private System.Windows.Forms.RadioButton rdbFresh;
        internal System.Windows.Forms.ComboBox Session;
        internal System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label10;
        internal System.Windows.Forms.ComboBox SubjectName;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.ComboBox Semester;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.ComboBox Branch;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox Course;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}