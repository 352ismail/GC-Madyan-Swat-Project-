namespace College_Management_System
{
    partial class frmSemesterFee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSemesterFee));
            this.panel1 = new System.Windows.Forms.Panel();
            this.GetDetails = new System.Windows.Forms.Button();
            this.Update_record = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.NewRecord = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.guna2Separator4 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.label13 = new System.Windows.Forms.Label();
            this.FeeID = new System.Windows.Forms.TextBox();
            this.lblFeeId = new System.Windows.Forms.Label();
            this.TotalFees = new System.Windows.Forms.TextBox();
            this.txtSeason = new System.Windows.Forms.TextBox();
            this.OtherFees = new System.Windows.Forms.TextBox();
            this.SemesterFee = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.cmbFacultyName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbClassName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.GetDetails);
            this.panel1.Controls.Add(this.Update_record);
            this.panel1.Controls.Add(this.Delete);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(736, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 277);
            this.panel1.TabIndex = 1;
            // 
            // GetDetails
            // 
            this.GetDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.GetDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GetDetails.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetDetails.Location = new System.Drawing.Point(12, 185);
            this.GetDetails.Name = "GetDetails";
            this.GetDetails.Size = new System.Drawing.Size(135, 44);
            this.GetDetails.TabIndex = 4;
            this.GetDetails.Text = "Record";
            this.GetDetails.UseVisualStyleBackColor = false;
            this.GetDetails.Click += new System.EventHandler(this.GetDetails_Click);
            // 
            // Update_record
            // 
            this.Update_record.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.Update_record.Enabled = false;
            this.Update_record.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Update_record.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update_record.Location = new System.Drawing.Point(12, 135);
            this.Update_record.Name = "Update_record";
            this.Update_record.Size = new System.Drawing.Size(135, 44);
            this.Update_record.TabIndex = 3;
            this.Update_record.Text = "Update";
            this.Update_record.UseVisualStyleBackColor = false;
            this.Update_record.Click += new System.EventHandler(this.Update_record_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.Delete.Enabled = false;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.Location = new System.Drawing.Point(12, 86);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(135, 44);
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
            this.btnSave.Location = new System.Drawing.Point(12, 37);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 44);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(853, 299);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 25);
            this.label12.TabIndex = 13;
            this.label12.Text = "admin";
            this.label12.Visible = false;
            // 
            // NewRecord
            // 
            this.NewRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.NewRecord.FlatAppearance.BorderSize = 0;
            this.NewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewRecord.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewRecord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.NewRecord.Location = new System.Drawing.Point(577, 228);
            this.NewRecord.Name = "NewRecord";
            this.NewRecord.Size = new System.Drawing.Size(135, 44);
            this.NewRecord.TabIndex = 0;
            this.NewRecord.Text = "Clear";
            this.NewRecord.UseVisualStyleBackColor = false;
            this.NewRecord.Click += new System.EventHandler(this.NewRecord_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.guna2Separator4);
            this.groupBox1.Controls.Add(this.guna2Separator3);
            this.groupBox1.Controls.Add(this.guna2Separator1);
            this.groupBox1.Controls.Add(this.guna2Separator2);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.FeeID);
            this.groupBox1.Controls.Add(this.lblFeeId);
            this.groupBox1.Controls.Add(this.TotalFees);
            this.groupBox1.Controls.Add(this.NewRecord);
            this.groupBox1.Controls.Add(this.txtSeason);
            this.groupBox1.Controls.Add(this.OtherFees);
            this.groupBox1.Controls.Add(this.SemesterFee);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbSemester);
            this.groupBox1.Controls.Add(this.cmbFacultyName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbClassName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(718, 288);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // guna2Separator4
            // 
            this.guna2Separator4.Location = new System.Drawing.Point(145, 257);
            this.guna2Separator4.Name = "guna2Separator4";
            this.guna2Separator4.Size = new System.Drawing.Size(186, 10);
            this.guna2Separator4.TabIndex = 138;
            // 
            // guna2Separator3
            // 
            this.guna2Separator3.Location = new System.Drawing.Point(427, 187);
            this.guna2Separator3.Name = "guna2Separator3";
            this.guna2Separator3.Size = new System.Drawing.Size(107, 15);
            this.guna2Separator3.TabIndex = 137;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(179, 190);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(95, 12);
            this.guna2Separator1.TabIndex = 136;
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.Location = new System.Drawing.Point(428, 136);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(249, 11);
            this.guna2Separator2.TabIndex = 135;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(496, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 24);
            this.label13.TabIndex = 57;
            this.label13.Text = "label13";
            this.label13.Visible = false;
            // 
            // FeeID
            // 
            this.FeeID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.FeeID.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeeID.Location = new System.Drawing.Point(156, 24);
            this.FeeID.Name = "FeeID";
            this.FeeID.ReadOnly = true;
            this.FeeID.Size = new System.Drawing.Size(154, 30);
            this.FeeID.TabIndex = 7;
            this.FeeID.Visible = false;
            // 
            // lblFeeId
            // 
            this.lblFeeId.AutoSize = true;
            this.lblFeeId.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeeId.Location = new System.Drawing.Point(29, 26);
            this.lblFeeId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFeeId.Name = "lblFeeId";
            this.lblFeeId.Size = new System.Drawing.Size(72, 23);
            this.lblFeeId.TabIndex = 64;
            this.lblFeeId.Text = "Fee ID";
            this.lblFeeId.Visible = false;
            // 
            // TotalFees
            // 
            this.TotalFees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.TotalFees.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TotalFees.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalFees.ForeColor = System.Drawing.Color.White;
            this.TotalFees.Location = new System.Drawing.Point(145, 232);
            this.TotalFees.Margin = new System.Windows.Forms.Padding(4);
            this.TotalFees.Name = "TotalFees";
            this.TotalFees.ReadOnly = true;
            this.TotalFees.Size = new System.Drawing.Size(185, 23);
            this.TotalFees.TabIndex = 6;
            this.TotalFees.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSeason
            // 
            this.txtSeason.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.txtSeason.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSeason.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeason.ForeColor = System.Drawing.Color.White;
            this.txtSeason.Location = new System.Drawing.Point(428, 115);
            this.txtSeason.Name = "txtSeason";
            this.txtSeason.ReadOnly = true;
            this.txtSeason.Size = new System.Drawing.Size(249, 23);
            this.txtSeason.TabIndex = 3;
            this.txtSeason.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSeason.TextChanged += new System.EventHandler(this.OtherFees_TextChanged);
            this.txtSeason.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OtherFees_KeyPress);
            // 
            // OtherFees
            // 
            this.OtherFees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.OtherFees.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OtherFees.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OtherFees.ForeColor = System.Drawing.Color.White;
            this.OtherFees.Location = new System.Drawing.Point(428, 168);
            this.OtherFees.MaxLength = 6;
            this.OtherFees.Name = "OtherFees";
            this.OtherFees.Size = new System.Drawing.Size(106, 23);
            this.OtherFees.TabIndex = 5;
            this.OtherFees.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OtherFees.TextChanged += new System.EventHandler(this.OtherFees_TextChanged);
            this.OtherFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OtherFees_KeyPress);
            // 
            // SemesterFee
            // 
            this.SemesterFee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.SemesterFee.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SemesterFee.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SemesterFee.ForeColor = System.Drawing.Color.White;
            this.SemesterFee.Location = new System.Drawing.Point(179, 168);
            this.SemesterFee.MaxLength = 6;
            this.SemesterFee.Name = "SemesterFee";
            this.SemesterFee.Size = new System.Drawing.Size(95, 23);
            this.SemesterFee.TabIndex = 4;
            this.SemesterFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SemesterFee.TextChanged += new System.EventHandler(this.SemesterFee_TextChanged);
            this.SemesterFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UDFees_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(30, 234);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 23);
            this.label9.TabIndex = 63;
            this.label9.Text = "Total Fees";
            // 
            // cmbSemester
            // 
            this.cmbSemester.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSemester.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSemester.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.cmbSemester.Enabled = false;
            this.cmbSemester.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSemester.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSemester.ForeColor = System.Drawing.Color.White;
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Location = new System.Drawing.Point(155, 113);
            this.cmbSemester.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(176, 31);
            this.cmbSemester.TabIndex = 2;
            this.cmbSemester.SelectedIndexChanged += new System.EventHandler(this.cmbSemester_SelectedIndexChanged);
            // 
            // cmbFacultyName
            // 
            this.cmbFacultyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFacultyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFacultyName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.cmbFacultyName.Enabled = false;
            this.cmbFacultyName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbFacultyName.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFacultyName.ForeColor = System.Drawing.Color.White;
            this.cmbFacultyName.FormattingEnabled = true;
            this.cmbFacultyName.Location = new System.Drawing.Point(428, 63);
            this.cmbFacultyName.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFacultyName.Name = "cmbFacultyName";
            this.cmbFacultyName.Size = new System.Drawing.Size(249, 31);
            this.cmbFacultyName.TabIndex = 1;
            this.cmbFacultyName.SelectedIndexChanged += new System.EventHandler(this.cmbFacultyName_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 115);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 23);
            this.label8.TabIndex = 61;
            this.label8.Text = "Semester";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 175);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 23);
            this.label5.TabIndex = 55;
            this.label5.Text = "Semester Fee";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(340, 115);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 51;
            this.label4.Text = "Season";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(305, 170);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 23);
            this.label3.TabIndex = 51;
            this.label3.Text = "Other Fees";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(338, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 23);
            this.label2.TabIndex = 49;
            this.label2.Text = "Faculty";
            // 
            // cmbClassName
            // 
            this.cmbClassName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbClassName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClassName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.cmbClassName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbClassName.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClassName.ForeColor = System.Drawing.Color.White;
            this.cmbClassName.Location = new System.Drawing.Point(157, 63);
            this.cmbClassName.Name = "cmbClassName";
            this.cmbClassName.Size = new System.Drawing.Size(174, 31);
            this.cmbClassName.TabIndex = 0;
            this.cmbClassName.SelectedIndexChanged += new System.EventHandler(this.Course_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 23);
            this.label1.TabIndex = 44;
            this.label1.Text = "Program";
            // 
            // frmSemesterFee
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(912, 309);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label12);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSemesterFee";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Semester Fees";
            this.Load += new System.EventHandler(this.FeesDetails_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button GetDetails;
        private System.Windows.Forms.Button NewRecord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox TotalFees;
        public System.Windows.Forms.TextBox OtherFees;
        public System.Windows.Forms.TextBox SemesterFee;
        public System.Windows.Forms.ComboBox cmbSemester;
        public System.Windows.Forms.ComboBox cmbFacultyName;
        public System.Windows.Forms.ComboBox cmbClassName;
        public System.Windows.Forms.TextBox FeeID;
        public System.Windows.Forms.Button Update_record;
        public System.Windows.Forms.Button Delete;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.TextBox txtSeason;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblFeeId;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator4;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
    }
}