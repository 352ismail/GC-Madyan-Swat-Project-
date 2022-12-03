namespace College_Management_System.Forms
{
    partial class frmSemesterSubjects
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSemesterSubjects));
            this.Update_record = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ViewRecord = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.NewRecord = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.cmbSession = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSubjectName = new System.Windows.Forms.ComboBox();
            this.cmbFaculty = new System.Windows.Forms.ComboBox();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSemesterSubjectId = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.cmbClassName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtcreditHour = new System.Windows.Forms.TextBox();
            this.txtSubjectCode = new System.Windows.Forms.TextBox();
            this.txtSemesterSubjectId = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Update_record
            // 
            this.Update_record.Enabled = false;
            this.Update_record.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Update_record.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update_record.ForeColor = System.Drawing.Color.White;
            this.Update_record.Location = new System.Drawing.Point(4, 164);
            this.Update_record.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Update_record.Name = "Update_record";
            this.Update_record.Size = new System.Drawing.Size(150, 42);
            this.Update_record.TabIndex = 3;
            this.Update_record.Text = "Update";
            this.Update_record.UseVisualStyleBackColor = true;
            this.Update_record.Click += new System.EventHandler(this.Update_record_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ViewRecord);
            this.panel1.Controls.Add(this.Update_record);
            this.panel1.Controls.Add(this.Delete);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(961, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 316);
            this.panel1.TabIndex = 1;
            // 
            // ViewRecord
            // 
            this.ViewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ViewRecord.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewRecord.ForeColor = System.Drawing.Color.White;
            this.ViewRecord.Location = new System.Drawing.Point(4, 216);
            this.ViewRecord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ViewRecord.Name = "ViewRecord";
            this.ViewRecord.Size = new System.Drawing.Size(151, 42);
            this.ViewRecord.TabIndex = 4;
            this.ViewRecord.Text = "Record";
            this.ViewRecord.UseVisualStyleBackColor = true;
            this.ViewRecord.Click += new System.EventHandler(this.ViewRecord_Click);
            // 
            // Delete
            // 
            this.Delete.Enabled = false;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Delete.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.ForeColor = System.Drawing.Color.White;
            this.Delete.Location = new System.Drawing.Point(4, 112);
            this.Delete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(150, 42);
            this.Delete.TabIndex = 2;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(4, 60);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 42);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // NewRecord
            // 
            this.NewRecord.FlatAppearance.BorderSize = 0;
            this.NewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewRecord.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewRecord.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.NewRecord.Location = new System.Drawing.Point(801, 279);
            this.NewRecord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NewRecord.Name = "NewRecord";
            this.NewRecord.Size = new System.Drawing.Size(113, 42);
            this.NewRecord.TabIndex = 0;
            this.NewRecord.Text = "Clear";
            this.NewRecord.UseVisualStyleBackColor = true;
            this.NewRecord.Click += new System.EventHandler(this.NewRecord_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(414, 240);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 23);
            this.label9.TabIndex = 65;
            this.label9.Text = "Credit Hours";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(39, 179);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 23);
            this.label5.TabIndex = 32;
            this.label5.Text = "Subject Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.guna2Separator2);
            this.groupBox1.Controls.Add(this.guna2Separator1);
            this.groupBox1.Controls.Add(this.cmbSession);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbSubjectName);
            this.groupBox1.Controls.Add(this.cmbFaculty);
            this.groupBox1.Controls.Add(this.NewRecord);
            this.groupBox1.Controls.Add(this.cmbSemester);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblSemesterSubjectId);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.cmbClassName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtcreditHour);
            this.groupBox1.Controls.Add(this.txtSubjectCode);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSemesterSubjectId);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(31, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(923, 329);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.Location = new System.Drawing.Point(552, 260);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(173, 10);
            this.guna2Separator2.TabIndex = 134;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(213, 259);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(179, 10);
            this.guna2Separator1.TabIndex = 133;
            // 
            // cmbSession
            // 
            this.cmbSession.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSession.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSession.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.cmbSession.Enabled = false;
            this.cmbSession.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSession.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSession.ForeColor = System.Drawing.Color.White;
            this.cmbSession.FormattingEnabled = true;
            this.cmbSession.Location = new System.Drawing.Point(215, 120);
            this.cmbSession.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(230, 29);
            this.cmbSession.TabIndex = 2;
            this.cmbSession.SelectedIndexChanged += new System.EventHandler(this.cmbSession_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 122);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 23);
            this.label1.TabIndex = 132;
            this.label1.Text = "Session";
            // 
            // cmbSubjectName
            // 
            this.cmbSubjectName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSubjectName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSubjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.cmbSubjectName.Enabled = false;
            this.cmbSubjectName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSubjectName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubjectName.ForeColor = System.Drawing.Color.White;
            this.cmbSubjectName.FormattingEnabled = true;
            this.cmbSubjectName.Location = new System.Drawing.Point(215, 179);
            this.cmbSubjectName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSubjectName.Name = "cmbSubjectName";
            this.cmbSubjectName.Size = new System.Drawing.Size(700, 29);
            this.cmbSubjectName.TabIndex = 4;
            this.cmbSubjectName.SelectedIndexChanged += new System.EventHandler(this.cmbSubjectName_SelectedIndexChanged);
            // 
            // cmbFaculty
            // 
            this.cmbFaculty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFaculty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFaculty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.cmbFaculty.Enabled = false;
            this.cmbFaculty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbFaculty.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFaculty.ForeColor = System.Drawing.Color.White;
            this.cmbFaculty.FormattingEnabled = true;
            this.cmbFaculty.Location = new System.Drawing.Point(607, 72);
            this.cmbFaculty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbFaculty.Name = "cmbFaculty";
            this.cmbFaculty.Size = new System.Drawing.Size(307, 29);
            this.cmbFaculty.TabIndex = 1;
            this.cmbFaculty.SelectedIndexChanged += new System.EventHandler(this.cmbFaculty_SelectedIndexChanged);
            // 
            // cmbSemester
            // 
            this.cmbSemester.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSemester.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSemester.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.cmbSemester.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSemester.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSemester.ForeColor = System.Drawing.Color.White;
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Location = new System.Drawing.Point(607, 122);
            this.cmbSemester.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(307, 29);
            this.cmbSemester.TabIndex = 3;
            this.cmbSemester.SelectedIndexChanged += new System.EventHandler(this.cmbSemester_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(485, 127);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 23);
            this.label2.TabIndex = 125;
            this.label2.Text = "Semester";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(485, 74);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(82, 23);
            this.label25.TabIndex = 129;
            this.label25.Text = "Faculty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(839, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 23);
            this.label3.TabIndex = 130;
            this.label3.Text = "Label3";
            this.label3.Visible = false;
            // 
            // lblSemesterSubjectId
            // 
            this.lblSemesterSubjectId.AutoSize = true;
            this.lblSemesterSubjectId.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemesterSubjectId.ForeColor = System.Drawing.Color.White;
            this.lblSemesterSubjectId.Location = new System.Drawing.Point(41, 31);
            this.lblSemesterSubjectId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSemesterSubjectId.Name = "lblSemesterSubjectId";
            this.lblSemesterSubjectId.Size = new System.Drawing.Size(95, 23);
            this.lblSemesterSubjectId.TabIndex = 130;
            this.lblSemesterSubjectId.Text = "Subjet ID";
            this.lblSemesterSubjectId.Visible = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(39, 67);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(93, 23);
            this.label26.TabIndex = 130;
            this.label26.Text = "Program";
            // 
            // cmbClassName
            // 
            this.cmbClassName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbClassName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClassName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.cmbClassName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbClassName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClassName.ForeColor = System.Drawing.Color.White;
            this.cmbClassName.FormattingEnabled = true;
            this.cmbClassName.Location = new System.Drawing.Point(215, 67);
            this.cmbClassName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbClassName.Name = "cmbClassName";
            this.cmbClassName.Size = new System.Drawing.Size(230, 29);
            this.cmbClassName.TabIndex = 0;
            this.cmbClassName.SelectedIndexChanged += new System.EventHandler(this.cmbClassName_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(38, 240);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 23);
            this.label4.TabIndex = 73;
            this.label4.Text = "Subject Code";
            // 
            // txtcreditHour
            // 
            this.txtcreditHour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcreditHour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.txtcreditHour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtcreditHour.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcreditHour.ForeColor = System.Drawing.Color.White;
            this.txtcreditHour.Location = new System.Drawing.Point(552, 238);
            this.txtcreditHour.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtcreditHour.Name = "txtcreditHour";
            this.txtcreditHour.ReadOnly = true;
            this.txtcreditHour.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtcreditHour.Size = new System.Drawing.Size(174, 23);
            this.txtcreditHour.TabIndex = 6;
            this.txtcreditHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSubjectCode
            // 
            this.txtSubjectCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubjectCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.txtSubjectCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubjectCode.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubjectCode.ForeColor = System.Drawing.Color.White;
            this.txtSubjectCode.Location = new System.Drawing.Point(213, 238);
            this.txtSubjectCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSubjectCode.Name = "txtSubjectCode";
            this.txtSubjectCode.ReadOnly = true;
            this.txtSubjectCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSubjectCode.Size = new System.Drawing.Size(179, 23);
            this.txtSubjectCode.TabIndex = 5;
            this.txtSubjectCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSemesterSubjectId
            // 
            this.txtSemesterSubjectId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSemesterSubjectId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.txtSemesterSubjectId.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSemesterSubjectId.ForeColor = System.Drawing.Color.White;
            this.txtSemesterSubjectId.Location = new System.Drawing.Point(215, 31);
            this.txtSemesterSubjectId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSemesterSubjectId.Name = "txtSemesterSubjectId";
            this.txtSemesterSubjectId.ReadOnly = true;
            this.txtSemesterSubjectId.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSemesterSubjectId.Size = new System.Drawing.Size(177, 30);
            this.txtSemesterSubjectId.TabIndex = 7;
            this.txtSemesterSubjectId.Visible = false;
            // 
            // frmSemesterSubjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1135, 355);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSemesterSubjects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subject Details";
            this.Load += new System.EventHandler(this.SemesterSubjects_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtSubjectCode;
        public System.Windows.Forms.TextBox txtSemesterSubjectId;
        public System.Windows.Forms.ComboBox cmbSubjectName;
        public System.Windows.Forms.ComboBox cmbFaculty;
        public System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        public System.Windows.Forms.ComboBox cmbClassName;
        public System.Windows.Forms.TextBox txtcreditHour;
        public System.Windows.Forms.ComboBox cmbSession;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblSemesterSubjectId;
        public System.Windows.Forms.Button Update_record;
        public System.Windows.Forms.Button ViewRecord;
        public System.Windows.Forms.Button Delete;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button NewRecord;
        public System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
    }
}