namespace College_Management_System
{
    partial class frmSubjectInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubjectInfo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ViewRecord = new System.Windows.Forms.Button();
            this.Update_record = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.NewRecord = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCreditHour = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubjectCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSubjectId = new System.Windows.Forms.Label();
            this.subjectId = new System.Windows.Forms.TextBox();
            this.SubjectName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.Location = new System.Drawing.Point(849, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 213);
            this.panel1.TabIndex = 1;
            // 
            // ViewRecord
            // 
            this.ViewRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ViewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewRecord.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewRecord.ForeColor = System.Drawing.Color.White;
            this.ViewRecord.Location = new System.Drawing.Point(4, 161);
            this.ViewRecord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ViewRecord.Name = "ViewRecord";
            this.ViewRecord.Size = new System.Drawing.Size(132, 42);
            this.ViewRecord.TabIndex = 7;
            this.ViewRecord.Text = "Record";
            this.ViewRecord.UseVisualStyleBackColor = false;
            this.ViewRecord.Click += new System.EventHandler(this.ViewRecord_Click);
            // 
            // Update_record
            // 
            this.Update_record.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.Update_record.Enabled = false;
            this.Update_record.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Update_record.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update_record.ForeColor = System.Drawing.Color.White;
            this.Update_record.Location = new System.Drawing.Point(4, 109);
            this.Update_record.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Update_record.Name = "Update_record";
            this.Update_record.Size = new System.Drawing.Size(132, 42);
            this.Update_record.TabIndex = 6;
            this.Update_record.Text = "&Update";
            this.Update_record.UseVisualStyleBackColor = false;
            this.Update_record.Click += new System.EventHandler(this.Update_record_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.Delete.Enabled = false;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.ForeColor = System.Drawing.Color.White;
            this.Delete.Location = new System.Drawing.Point(4, 57);
            this.Delete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(132, 42);
            this.Delete.TabIndex = 5;
            this.Delete.Text = "&Delete";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(4, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 42);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // NewRecord
            // 
            this.NewRecord.FlatAppearance.BorderSize = 0;
            this.NewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewRecord.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewRecord.ForeColor = System.Drawing.Color.White;
            this.NewRecord.Location = new System.Drawing.Point(710, 176);
            this.NewRecord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NewRecord.Name = "NewRecord";
            this.NewRecord.Size = new System.Drawing.Size(113, 42);
            this.NewRecord.TabIndex = 3;
            this.NewRecord.Text = "Clear";
            this.NewRecord.UseVisualStyleBackColor = true;
            this.NewRecord.Click += new System.EventHandler(this.NewRecord_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(40, 80);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 23);
            this.label5.TabIndex = 32;
            this.label5.Text = "Subject Name";
            // 
            // cmbCreditHour
            // 
            this.cmbCreditHour.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCreditHour.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCreditHour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.cmbCreditHour.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCreditHour.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCreditHour.ForeColor = System.Drawing.Color.White;
            this.cmbCreditHour.FormattingEnabled = true;
            this.cmbCreditHour.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            ""});
            this.cmbCreditHour.Location = new System.Drawing.Point(609, 130);
            this.cmbCreditHour.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbCreditHour.Name = "cmbCreditHour";
            this.cmbCreditHour.Size = new System.Drawing.Size(129, 31);
            this.cmbCreditHour.TabIndex = 2;
            this.cmbCreditHour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCreditHour_KeyPress);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(468, 132);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 23);
            this.label9.TabIndex = 65;
            this.label9.Text = "Credit Hours";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.guna2Separator2);
            this.groupBox1.Controls.Add(this.guna2Separator1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSubjectCode);
            this.groupBox1.Controls.Add(this.cmbCreditHour);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.NewRecord);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblSubjectId);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.subjectId);
            this.groupBox1.Controls.Add(this.SubjectName);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(830, 226);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.Location = new System.Drawing.Point(215, 153);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(220, 10);
            this.guna2Separator2.TabIndex = 75;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(215, 102);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(590, 13);
            this.guna2Separator1.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(40, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 23);
            this.label4.TabIndex = 73;
            this.label4.Text = "Subject Code";
            // 
            // txtSubjectCode
            // 
            this.txtSubjectCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubjectCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.txtSubjectCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubjectCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSubjectCode.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubjectCode.ForeColor = System.Drawing.Color.White;
            this.txtSubjectCode.Location = new System.Drawing.Point(215, 129);
            this.txtSubjectCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSubjectCode.MaxLength = 7;
            this.txtSubjectCode.Name = "txtSubjectCode";
            this.txtSubjectCode.Size = new System.Drawing.Size(219, 25);
            this.txtSubjectCode.TabIndex = 1;
            this.txtSubjectCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSubjectCode_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(670, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 32;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // lblSubjectId
            // 
            this.lblSubjectId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubjectId.AutoSize = true;
            this.lblSubjectId.BackColor = System.Drawing.Color.Transparent;
            this.lblSubjectId.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectId.ForeColor = System.Drawing.Color.White;
            this.lblSubjectId.Location = new System.Drawing.Point(40, 28);
            this.lblSubjectId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubjectId.Name = "lblSubjectId";
            this.lblSubjectId.Size = new System.Drawing.Size(108, 23);
            this.lblSubjectId.TabIndex = 32;
            this.lblSubjectId.Text = "Subject ID";
            this.lblSubjectId.Visible = false;
            // 
            // subjectId
            // 
            this.subjectId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.subjectId.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectId.ForeColor = System.Drawing.Color.White;
            this.subjectId.Location = new System.Drawing.Point(215, 26);
            this.subjectId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.subjectId.Name = "subjectId";
            this.subjectId.ReadOnly = true;
            this.subjectId.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.subjectId.Size = new System.Drawing.Size(195, 30);
            this.subjectId.TabIndex = 4;
            this.subjectId.Visible = false;
            // 
            // SubjectName
            // 
            this.SubjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.SubjectName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SubjectName.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubjectName.ForeColor = System.Drawing.Color.White;
            this.SubjectName.Location = new System.Drawing.Point(215, 78);
            this.SubjectName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SubjectName.Size = new System.Drawing.Size(591, 25);
            this.SubjectName.TabIndex = 0;
            this.SubjectName.TextChanged += new System.EventHandler(this.SubjectName_TextChanged);
            this.SubjectName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SubjectName_KeyPress);
            // 
            // frmSubjectInfo
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1004, 250);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSubjectInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subjects ";
            this.Load += new System.EventHandler(this.frmSubjectInfo_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox cmbCreditHour;
        public System.Windows.Forms.TextBox SubjectName;
        public System.Windows.Forms.TextBox subjectId;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtSubjectCode;
        public System.Windows.Forms.Label lblSubjectId;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button ViewRecord;
        public System.Windows.Forms.Button Update_record;
        public System.Windows.Forms.Button Delete;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button NewRecord;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
    }
}