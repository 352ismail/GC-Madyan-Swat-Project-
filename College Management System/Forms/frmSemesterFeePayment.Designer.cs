namespace College_Management_System
{
    partial class frmSemesterFeePayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSemesterFeePayment));
            this.label22 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmnStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clmnDateOfPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbSession = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblStudentId = new System.Windows.Forms.Label();
            this.lblSemesterFeeId = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.ClassName = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.cmbSemseter = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.FacultyName = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRecord = new System.Windows.Forms.Button();
            this.Print = new System.Windows.Forms.Button();
            this.Update_record = new System.Windows.Forms.Button();
            this.NewRecord = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.ForeColor = System.Drawing.Color.Gray;
            this.label22.Location = new System.Drawing.Point(1442, 1011);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(13, 20);
            this.label22.TabIndex = 26;
            this.label22.Text = ".";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnStatus,
            this.clmnDateOfPayment});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(0, 270);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 40;
            this.dataGridView1.Size = new System.Drawing.Size(1180, 512);
            this.dataGridView1.TabIndex = 108;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // clmnStatus
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.clmnStatus.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clmnStatus.HeaderText = "Paid/Unpaid";
            this.clmnStatus.Items.AddRange(new object[] {
            "Paid",
            "Unpaid"});
            this.clmnStatus.MinimumWidth = 72;
            this.clmnStatus.Name = "clmnStatus";
            this.clmnStatus.Visible = false;
            this.clmnStatus.Width = 136;
            // 
            // clmnDateOfPayment
            // 
            this.clmnDateOfPayment.HeaderText = "DateOfPayment";
            this.clmnDateOfPayment.MaxInputLength = 9;
            this.clmnDateOfPayment.Name = "clmnDateOfPayment";
            this.clmnDateOfPayment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnDateOfPayment.Visible = false;
            this.clmnDateOfPayment.Width = 201;
            // 
            // cmbSession
            // 
            this.cmbSession.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSession.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSession.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.cmbSession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSession.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSession.ForeColor = System.Drawing.Color.White;
            this.cmbSession.FormattingEnabled = true;
            this.cmbSession.Location = new System.Drawing.Point(711, 17);
            this.cmbSession.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(165, 31);
            this.cmbSession.TabIndex = 2;
            this.cmbSession.SelectedIndexChanged += new System.EventHandler(this.cmbSession_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(626, 20);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 23);
            this.label13.TabIndex = 54;
            this.label13.Text = "Session";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblStudentId);
            this.panel3.Controls.Add(this.lblSemesterFeeId);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Controls.Add(this.ClassName);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.cmbSession);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label25);
            this.panel3.Controls.Add(this.cmbSemseter);
            this.panel3.Controls.Add(this.label26);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.FacultyName);
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(13, 14);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1167, 71);
            this.panel3.TabIndex = 0;
            // 
            // lblStudentId
            // 
            this.lblStudentId.AutoSize = true;
            this.lblStudentId.Location = new System.Drawing.Point(44, 84);
            this.lblStudentId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Size = new System.Drawing.Size(95, 20);
            this.lblStudentId.TabIndex = 107;
            this.lblStudentId.Text = "lblStudentId";
            this.lblStudentId.Visible = false;
            // 
            // lblSemesterFeeId
            // 
            this.lblSemesterFeeId.AutoSize = true;
            this.lblSemesterFeeId.Location = new System.Drawing.Point(44, 53);
            this.lblSemesterFeeId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSemesterFeeId.Name = "lblSemesterFeeId";
            this.lblSemesterFeeId.Size = new System.Drawing.Size(120, 20);
            this.lblSemesterFeeId.TabIndex = 106;
            this.lblSemesterFeeId.Text = "SemesterFeeId";
            this.lblSemesterFeeId.Visible = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(44, 112);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(60, 20);
            this.label24.TabIndex = 58;
            this.label24.Text = "label24";
            this.label24.Visible = false;
            // 
            // ClassName
            // 
            this.ClassName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ClassName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ClassName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClassName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClassName.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassName.ForeColor = System.Drawing.Color.White;
            this.ClassName.FormattingEnabled = true;
            this.ClassName.Location = new System.Drawing.Point(111, 17);
            this.ClassName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ClassName.Name = "ClassName";
            this.ClassName.Size = new System.Drawing.Size(135, 31);
            this.ClassName.TabIndex = 0;
            this.ClassName.SelectedIndexChanged += new System.EventHandler(this.ClassName_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(104, 112);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(60, 20);
            this.label23.TabIndex = 57;
            this.label23.Text = "label23";
            this.label23.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(886, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 23);
            this.label8.TabIndex = 61;
            this.label8.Text = "Semester";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(261, 20);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(82, 23);
            this.label25.TabIndex = 21;
            this.label25.Text = "Faculty";
            // 
            // cmbSemseter
            // 
            this.cmbSemseter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSemseter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSemseter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.cmbSemseter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSemseter.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSemseter.ForeColor = System.Drawing.Color.White;
            this.cmbSemseter.FormattingEnabled = true;
            this.cmbSemseter.Location = new System.Drawing.Point(1006, 17);
            this.cmbSemseter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSemseter.Name = "cmbSemseter";
            this.cmbSemseter.Size = new System.Drawing.Size(121, 31);
            this.cmbSemseter.TabIndex = 3;
            this.cmbSemseter.SelectedIndexChanged += new System.EventHandler(this.cmbSemseter_SelectedIndexChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(10, 20);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(93, 23);
            this.label26.TabIndex = 22;
            this.label26.Text = "Program";
            // 
            // FacultyName
            // 
            this.FacultyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.FacultyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.FacultyName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.FacultyName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FacultyName.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FacultyName.ForeColor = System.Drawing.Color.White;
            this.FacultyName.FormattingEnabled = true;
            this.FacultyName.Location = new System.Drawing.Point(360, 17);
            this.FacultyName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FacultyName.Name = "FacultyName";
            this.FacultyName.Size = new System.Drawing.Size(258, 31);
            this.FacultyName.TabIndex = 1;
            this.FacultyName.SelectedIndexChanged += new System.EventHandler(this.FacultyName_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(832, 104);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(1520, 1036);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 20);
            this.label1.TabIndex = 106;
            this.label1.Text = ".";
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecord.ForeColor = System.Drawing.Color.White;
            this.btnRecord.Location = new System.Drawing.Point(461, 10);
            this.btnRecord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(142, 46);
            this.btnRecord.TabIndex = 4;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // Print
            // 
            this.Print.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.Print.Enabled = false;
            this.Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Print.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Print.ForeColor = System.Drawing.Color.White;
            this.Print.Location = new System.Drawing.Point(611, 10);
            this.Print.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(142, 44);
            this.Print.TabIndex = 5;
            this.Print.Text = "Print";
            this.Print.UseVisualStyleBackColor = false;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // Update_record
            // 
            this.Update_record.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.Update_record.Enabled = false;
            this.Update_record.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Update_record.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update_record.ForeColor = System.Drawing.Color.White;
            this.Update_record.Location = new System.Drawing.Point(311, 10);
            this.Update_record.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Update_record.Name = "Update_record";
            this.Update_record.Size = new System.Drawing.Size(142, 46);
            this.Update_record.TabIndex = 3;
            this.Update_record.Text = "Update";
            this.Update_record.UseVisualStyleBackColor = false;
            this.Update_record.Click += new System.EventHandler(this.Update_record_Click);
            // 
            // NewRecord
            // 
            this.NewRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.NewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewRecord.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewRecord.ForeColor = System.Drawing.Color.White;
            this.NewRecord.Location = new System.Drawing.Point(990, 106);
            this.NewRecord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NewRecord.Name = "NewRecord";
            this.NewRecord.Size = new System.Drawing.Size(142, 44);
            this.NewRecord.TabIndex = 2;
            this.NewRecord.Text = "Clear";
            this.NewRecord.UseVisualStyleBackColor = false;
            this.NewRecord.Click += new System.EventHandler(this.NewRecord_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.Delete.Enabled = false;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.ForeColor = System.Drawing.Color.White;
            this.Delete.Location = new System.Drawing.Point(161, 10);
            this.Delete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(142, 46);
            this.Delete.TabIndex = 2;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(11, 10);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(142, 46);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnRecord);
            this.panel1.Controls.Add(this.Print);
            this.panel1.Controls.Add(this.Update_record);
            this.panel1.Controls.Add(this.Delete);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(13, 93);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(779, 70);
            this.panel1.TabIndex = 3;
            // 
            // frmSemesterFeePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1180, 782);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NewRecord);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSemesterFeePayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Semester Fees Payment";
            this.Load += new System.EventHandler(this.frmSemesterFeePayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label label22;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.ComboBox cmbSession;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label label24;
        public System.Windows.Forms.ComboBox ClassName;
        public System.Windows.Forms.Label label23;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label25;
        public System.Windows.Forms.ComboBox cmbSemseter;
        private System.Windows.Forms.Label label26;
        public System.Windows.Forms.ComboBox FacultyName;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnRecord;
        public System.Windows.Forms.Button Print;
        public System.Windows.Forms.Button Update_record;
        public System.Windows.Forms.Button NewRecord;
        public System.Windows.Forms.Button Delete;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblSemesterFeeId;
        public System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDateOfPayment;
    }
}