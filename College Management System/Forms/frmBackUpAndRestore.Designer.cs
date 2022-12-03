namespace College_Management_System.Forms
{
    partial class frmBackUpAndRestore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackUpAndRestore));
            this.txtBackup = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnRestore = new Guna.UI2.WinForms.Guna2Button();
            this.txtRestore = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnRestoreBrowse = new Guna.UI2.WinForms.Guna2Button();
            this.btnBackup = new Guna.UI2.WinForms.Guna2Button();
            this.btnBackupBrowse = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBackup
            // 
            this.txtBackup.BorderRadius = 10;
            this.txtBackup.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBackup.DefaultText = "";
            this.txtBackup.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBackup.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBackup.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBackup.DisabledState.Parent = this.txtBackup;
            this.txtBackup.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBackup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.txtBackup.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBackup.FocusedState.Parent = this.txtBackup;
            this.txtBackup.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBackup.HoverState.Parent = this.txtBackup;
            this.txtBackup.Location = new System.Drawing.Point(30, 89);
            this.txtBackup.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtBackup.Name = "txtBackup";
            this.txtBackup.PasswordChar = '\0';
            this.txtBackup.PlaceholderText = "BackUp Path";
            this.txtBackup.SelectedText = "";
            this.txtBackup.ShadowDecoration.Parent = this.txtBackup;
            this.txtBackup.Size = new System.Drawing.Size(443, 45);
            this.txtBackup.TabIndex = 0;
            this.txtBackup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Controls.Add(this.btnRestore);
            this.guna2GroupBox1.Controls.Add(this.txtRestore);
            this.guna2GroupBox1.Controls.Add(this.btnRestoreBrowse);
            this.guna2GroupBox1.Controls.Add(this.btnBackup);
            this.guna2GroupBox1.Controls.Add(this.btnBackupBrowse);
            this.guna2GroupBox1.Controls.Add(this.txtBackup);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(54)))), ((int)(((byte)(76)))));
            this.guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GroupBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.Parent = this.guna2GroupBox1;
            this.guna2GroupBox1.Size = new System.Drawing.Size(746, 271);
            this.guna2GroupBox1.TabIndex = 2;
            this.guna2GroupBox1.Text = "BackUp & Restore";
            // 
            // btnRestore
            // 
            this.btnRestore.AutoRoundedCorners = true;
            this.btnRestore.BorderColor = System.Drawing.Color.White;
            this.btnRestore.BorderRadius = 21;
            this.btnRestore.BorderThickness = 1;
            this.btnRestore.CheckedState.Parent = this.btnRestore;
            this.btnRestore.CustomImages.Parent = this.btnRestore;
            this.btnRestore.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnRestore.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.HoverState.Parent = this.btnRestore;
            this.btnRestore.Location = new System.Drawing.Point(604, 171);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.PressedColor = System.Drawing.Color.Gray;
            this.btnRestore.ShadowDecoration.Parent = this.btnRestore;
            this.btnRestore.Size = new System.Drawing.Size(109, 45);
            this.btnRestore.TabIndex = 7;
            this.btnRestore.Text = "Restore";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click_1);
            // 
            // txtRestore
            // 
            this.txtRestore.BorderRadius = 10;
            this.txtRestore.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRestore.DefaultText = "";
            this.txtRestore.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRestore.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRestore.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRestore.DisabledState.Parent = this.txtRestore;
            this.txtRestore.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRestore.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.txtRestore.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRestore.FocusedState.Parent = this.txtRestore;
            this.txtRestore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRestore.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRestore.HoverState.Parent = this.txtRestore;
            this.txtRestore.Location = new System.Drawing.Point(30, 171);
            this.txtRestore.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtRestore.Name = "txtRestore";
            this.txtRestore.PasswordChar = '\0';
            this.txtRestore.PlaceholderText = "Restore Path";
            this.txtRestore.SelectedText = "";
            this.txtRestore.ShadowDecoration.Parent = this.txtRestore;
            this.txtRestore.Size = new System.Drawing.Size(452, 45);
            this.txtRestore.TabIndex = 5;
            this.txtRestore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnRestoreBrowse
            // 
            this.btnRestoreBrowse.AutoRoundedCorners = true;
            this.btnRestoreBrowse.BorderColor = System.Drawing.Color.Silver;
            this.btnRestoreBrowse.BorderRadius = 21;
            this.btnRestoreBrowse.BorderThickness = 1;
            this.btnRestoreBrowse.CheckedState.Parent = this.btnRestoreBrowse;
            this.btnRestoreBrowse.CustomImages.Parent = this.btnRestoreBrowse;
            this.btnRestoreBrowse.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnRestoreBrowse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRestoreBrowse.ForeColor = System.Drawing.Color.White;
            this.btnRestoreBrowse.HoverState.Parent = this.btnRestoreBrowse;
            this.btnRestoreBrowse.Location = new System.Drawing.Point(489, 171);
            this.btnRestoreBrowse.Name = "btnRestoreBrowse";
            this.btnRestoreBrowse.PressedColor = System.Drawing.Color.Gray;
            this.btnRestoreBrowse.ShadowDecoration.Parent = this.btnRestoreBrowse;
            this.btnRestoreBrowse.Size = new System.Drawing.Size(109, 45);
            this.btnRestoreBrowse.TabIndex = 6;
            this.btnRestoreBrowse.Text = "...";
            this.btnRestoreBrowse.Click += new System.EventHandler(this.btnRestoreBrowse_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.AutoRoundedCorners = true;
            this.btnBackup.BorderColor = System.Drawing.Color.White;
            this.btnBackup.BorderRadius = 21;
            this.btnBackup.BorderThickness = 1;
            this.btnBackup.CheckedState.Parent = this.btnBackup;
            this.btnBackup.CustomImages.Parent = this.btnBackup;
            this.btnBackup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnBackup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.HoverState.Parent = this.btnBackup;
            this.btnBackup.Location = new System.Drawing.Point(604, 89);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.ShadowDecoration.Parent = this.btnBackup;
            this.btnBackup.Size = new System.Drawing.Size(109, 45);
            this.btnBackup.TabIndex = 2;
            this.btnBackup.Text = "BackUp";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnBackupBrowse
            // 
            this.btnBackupBrowse.Animated = true;
            this.btnBackupBrowse.AutoRoundedCorners = true;
            this.btnBackupBrowse.BorderColor = System.Drawing.Color.White;
            this.btnBackupBrowse.BorderRadius = 21;
            this.btnBackupBrowse.BorderThickness = 1;
            this.btnBackupBrowse.CheckedState.Parent = this.btnBackupBrowse;
            this.btnBackupBrowse.CustomImages.Parent = this.btnBackupBrowse;
            this.btnBackupBrowse.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnBackupBrowse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBackupBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBackupBrowse.HoverState.Parent = this.btnBackupBrowse;
            this.btnBackupBrowse.Location = new System.Drawing.Point(489, 89);
            this.btnBackupBrowse.Name = "btnBackupBrowse";
            this.btnBackupBrowse.ShadowDecoration.Parent = this.btnBackupBrowse;
            this.btnBackupBrowse.Size = new System.Drawing.Size(109, 45);
            this.btnBackupBrowse.TabIndex = 1;
            this.btnBackupBrowse.Text = "...";
            this.btnBackupBrowse.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // frmBackUpAndRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(746, 269);
            this.Controls.Add(this.guna2GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackUpAndRestore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BackUp And Restore";
            this.Load += new System.EventHandler(this.frmBackUpAndRestore_Load);
            this.guna2GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtBackup;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2Button btnBackup;
        private Guna.UI2.WinForms.Guna2Button btnBackupBrowse;
        private Guna.UI2.WinForms.Guna2Button btnRestore;
        private Guna.UI2.WinForms.Guna2TextBox txtRestore;
        private Guna.UI2.WinForms.Guna2Button btnRestoreBrowse;
    }
}