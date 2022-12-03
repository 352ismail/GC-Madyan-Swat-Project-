using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace College_Management_System
{
    public partial class frmLogin : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection myConnection = null;
        //SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand myCommand = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            //ProgressBar1.Visible = false;
            txtUserName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            try { Application.Exit(); } catch
            {
                MessageBox.Show("Error While Exitting Application","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            return;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmChangePassword frm = new frmChangePassword();
            frm.Show();
            frm.txtUserName.Text = "";
            frm.txtNewPassword.Text = "";
            frm.txtOldPassword.Text = "";
            frm.txtConfirmPassword.Text = "";
        }

      

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (chkRememeberME.Checked == true)
            {
                Properties.Settings.Default.UserName = txtUserName.Text.Trim();
                Properties.Settings.Default.Password = txtPassword.Text.Trim();
                Properties.Settings.Default.Save();
            }
            else if (chkRememeberME.Checked == false)
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Save();
            }
            {
                if (txtUserName.Text == "")
                {
                    MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserName.Focus();
                    return;
                }
                if (txtPassword.Text == "")
                {
                    MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                    return;
                }
                try
                {
                    myConnection = new SqlConnection(cs.DBConn);
                    myConnection.Open();
                    frmMainMenu frm = new frmMainMenu();
                    myCommand = new SqlCommand("SELECT UserName,Password,(Role.Description)[UserType] FROM Users INNER JOIN ROle On Users.RoleId = Role.RoleId WHERE UserName = @username AND Password = @Userpassword", myConnection);
                    SqlParameter uName = new SqlParameter("@username", SqlDbType.NChar);
                    SqlParameter uPassword = new SqlParameter("@UserPassword", SqlDbType.NChar);
                    uName.Value = txtUserName.Text;
                    uPassword.Value = txtPassword.Text;
                    myCommand.Parameters.Add(uName);
                    myCommand.Parameters.Add(uPassword);
                    myCommand = myConnection.CreateCommand();
                    myCommand.CommandText = "SELECT (Role.Description)[UserType] FROM Users INNER JOIN ROle On Users.RoleId = Role.RoleId WHERE UserName = '" + txtUserName.Text.Trim() + "' AND Password = '" + txtPassword.Text.Trim() + "'";
                    rdr = myCommand.ExecuteReader();

                    if (rdr.Read())
                    {
                        frm.UserType.Text = rdr.GetString(0).Trim();
                    }
                    if ((rdr != null))
                    { rdr.Close(); }
                    SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read() == true)
                    {
                        int i;
                        progressBar1.Visible = true;
                        progressBar1.Maximum = 5000;
                        progressBar1.Minimum = 0;
                        progressBar1.Value = 4;
                        progressBar1.Step = 1;
                        for (i = 0; i <= 5000; i++)
                        {
                            progressBar1.PerformStep();
                        }
                        if (frm.UserType.Text == "Professor" || frm.UserType.Text == "Lecturer")
                        {
                            this.Hide();
                            frm.User.Text = txtUserName.Text;
                            frm.lblUserName.Text = txtUserName.Text.Trim();
                            frm.Show();
                            #region ROLES 
                            //Master Entry Menu
                            frm.Master_entryMenu.Enabled = false;
                            frm.DepartmentToolStripMenuItem.Enabled = false;
                            frm.semesterToolStripMenuItem.Enabled = false;
                            frm.batchToolStripMenuItem.Enabled = false;
                            frm.subjectsToolStripMenuItem.Enabled = false;
                            frm.SubjectDetailsToolStripMenuItem.Enabled = false;
                            frm.SemesterfeesDetailsToolStripMenuItem.Enabled = false;
                            frm.eventToolStripMenuItem.Enabled = false;
                            frm.hostelToolStripMenuItem.Enabled = false;
                            //Master Entry Menu


                            // Users Menu
                            frm.usersToolStripMenuItem.Enabled = false;
                            frm.loginDetailsToolStripMenuItem.Enabled = false;
                            frm.UserRegistrationToolStripMenuItemTop.Enabled = false;
                            // Users Menu


                            //Student Menu
                            frm.studentToolStripMenuItem.Enabled = false;
                            frm.studentProfileEntryToolStripMenuItem.Enabled = false;
                            frm.StudentRegistrationToolStripMenuItem2.Enabled = false;
                            frm.iDCardToolStripMenuItem.Enabled = false;
                            frm.PersonalLedgerToolStripMenuItem.Enabled = false;
                            frm.hostelersToolStripMenuItem.Enabled = false;
                            //Student Menu


                            //Employee Menu
                            frm.employeeToolStripMenuItem.Enabled = false;
                            frm.employeeProfileToolStripMenuItem.Enabled = false;
                            frm.employeeAttendanceToolStripMenuItem.Enabled = false;
                            frm.manageEventToolStripMenuItem.Enabled = false;
                            //Employee Menu

                            // Result Menu
                            frm.resultToolStripMenuItem1.Enabled = true;
                            frm.subjectMarksEntryToolStripMenuItem.Enabled = true;
                            frm.semesterResultToolStripMenuItem2.Enabled = false;
                            // Result Menu


                            // Transaction Menu
                            frm.transactionToolStripMenuItem.Enabled = false;
                            frm.SemesterfeePaymentToolStripMenuItem.Enabled = false;
                            frm.hostelFeesPaymentToolStripMenuItem.Enabled = false;
                            frm.othersTransactionToolStripMenuItem.Enabled = false;
                            // Transaction Menu


                            // Reports Menu
                            frm.reportsToolStripMenuItem.Enabled = true;
                            frm.ClearanceChitReportToolStripMenuItem2.Enabled = false;
                            frm.EmployeesReportToolStripMenuItem2.Enabled = false;
                            frm.feeCardReportToolStripMenuItem.Enabled = false;
                            frm.hostelFeePaymentReportToolStripMenuItem.Enabled = false;
                            frm.PersonalLedgerReportToolStripMenuItem2.Enabled = false;
                            frm.SemesterResultReportToolStripMenuItem.Enabled = true;
                            frm.SemesterfeePaymentReportToolStripMenuItem2.Enabled = false;
                            frm.studentsRegistrationReportToolStripMenuItem.Enabled = true;
                            frm.studentsReportToolStripMenuItem.Enabled = true;
                            frm.SubjectResultReportToolStripMenuItem1.Enabled = true;
                            frm.TranscriptReportToolStripMenuItem.Enabled = true;
                            frm.AdmissionAndWithdrawalReportToolStripMenuItem.Enabled = false;
                            // Reports Menu 


                            //Tools Menu 
                            frm.toolsMenu.Enabled = true;
                            //Tools Menu 


                            // Help Menu
                            frm.helpMenu.Enabled = true;
                            // Help Menu


                            // Menu On Form                             
                            frm.userRegistrationToolStripMenuItem.Enabled = false;
                            frm.StudentProfileEntryToolStripMenuItem1.Enabled = false;
                            frm.SubjectMarksEntryToolStripMenuItem1.Enabled = true;
                            frm.employeeToolStripMenuItem1.Enabled = false;
                            frm.SemesterfeePaymentToolStripMenuItem1.Enabled = false;
                            frm.AdmissionFormtoolStripMenuItem.Enabled = false;
                            frm.databaseToolStripMenuItem.Enabled = true;
                            frm.logoutToolStripMenuItem.Enabled = true;
                            // Menu On Form
                            #endregion
                        }

                        if (frm.UserType.Text == "Admin")
                        {
                            this.Hide();
                            frm.User.Text = txtUserName.Text;
                            frm.Show();
                            #region ROLES 
                            //Master Entry Menu
                            frm.Master_entryMenu.Enabled = true;
                            frm.DepartmentToolStripMenuItem.Enabled = true;
                            frm.semesterToolStripMenuItem.Enabled = true;
                            frm.batchToolStripMenuItem.Enabled = true;
                            frm.subjectsToolStripMenuItem.Enabled = true;
                            frm.SubjectDetailsToolStripMenuItem.Enabled = true;
                            frm.SemesterfeesDetailsToolStripMenuItem.Enabled = true;
                            frm.eventToolStripMenuItem.Enabled = true;
                            frm.hostelToolStripMenuItem.Enabled = true;
                            //Master Entry Menu


                            // Users Menu
                            frm.usersToolStripMenuItem.Enabled = true;
                            frm.loginDetailsToolStripMenuItem.Enabled = true;
                            frm.UserRegistrationToolStripMenuItemTop.Enabled = true;
                            // Users Menu


                            //Student Menu
                            frm.studentToolStripMenuItem.Enabled = true;
                            frm.studentProfileEntryToolStripMenuItem.Enabled = true;
                            frm.StudentRegistrationToolStripMenuItem2.Enabled = true;
                            frm.iDCardToolStripMenuItem.Enabled = true;
                            frm.PersonalLedgerToolStripMenuItem.Enabled = true;
                            frm.hostelersToolStripMenuItem.Enabled = true;
                            //Student Menu


                            //Employee Menu
                            frm.employeeToolStripMenuItem.Enabled = true;
                            frm.employeeProfileToolStripMenuItem.Enabled = true;
                            frm.employeeAttendanceToolStripMenuItem.Enabled = true;
                            frm.manageEventToolStripMenuItem.Enabled = true;
                            //Employee Menu

                            // Result Menu
                            frm.resultToolStripMenuItem1.Enabled = true;
                            frm.subjectMarksEntryToolStripMenuItem.Enabled = true;
                            frm.semesterResultToolStripMenuItem2.Enabled = true;
                            // Result Menu


                            // Transaction Menu
                            frm.transactionToolStripMenuItem.Enabled = true;
                            frm.SemesterfeePaymentToolStripMenuItem.Enabled = true;
                            frm.hostelFeesPaymentToolStripMenuItem.Enabled = true;
                            frm.othersTransactionToolStripMenuItem.Enabled = true;
                            // Transaction Menu


                            // Reports Menu
                            frm.reportsToolStripMenuItem.Enabled = true;
                            frm.ClearanceChitReportToolStripMenuItem2.Enabled = true;
                            frm.EmployeesReportToolStripMenuItem2.Enabled = true;
                            frm.feeCardReportToolStripMenuItem.Enabled = true;
                            frm.hostelFeePaymentReportToolStripMenuItem.Enabled = true;
                            frm.PersonalLedgerReportToolStripMenuItem2.Enabled = true;
                            frm.SemesterResultReportToolStripMenuItem.Enabled = true;
                            frm.SemesterfeePaymentReportToolStripMenuItem2.Enabled = true;
                            frm.studentsRegistrationReportToolStripMenuItem.Enabled = true;
                            frm.studentsReportToolStripMenuItem.Enabled = true;
                            frm.SubjectResultReportToolStripMenuItem1.Enabled = true;
                            frm.TranscriptReportToolStripMenuItem.Enabled = true;
                            frm.AdmissionAndWithdrawalReportToolStripMenuItem.Enabled = true;
                            // Reports Menu 


                            //Tools Menu 
                            frm.toolsMenu.Enabled = true;
                            //Tools Menu 


                            // Help Menu
                            frm.helpMenu.Enabled = true;
                            // Help Menu


                            // Menu On Form                             
                            frm.userRegistrationToolStripMenuItem.Enabled = true;
                            frm.StudentProfileEntryToolStripMenuItem1.Enabled = true;
                            frm.SubjectMarksEntryToolStripMenuItem1.Enabled = true;
                            frm.employeeToolStripMenuItem1.Enabled = true;
                            frm.SemesterfeePaymentToolStripMenuItem1.Enabled = true;
                            frm.AdmissionFormtoolStripMenuItem.Enabled = true;
                            frm.databaseToolStripMenuItem.Enabled = true;
                            frm.logoutToolStripMenuItem.Enabled = true;
                            // Menu On Form
                            #endregion                      
                        }

                        if (frm.UserType.Text == "Admission Officier")
                        {
                            this.Hide();
                            frm.User.Text = txtUserName.Text;
                            frm.Show();
                            #region ROLES 
                            //Master Entry Menu
                            frm.Master_entryMenu.Enabled = true;
                            frm.DepartmentToolStripMenuItem.Enabled = true;
                            frm.semesterToolStripMenuItem.Enabled = true;
                            frm.batchToolStripMenuItem.Enabled = true;
                            frm.subjectsToolStripMenuItem.Enabled = false;
                            frm.SubjectDetailsToolStripMenuItem.Enabled = false;
                            frm.SemesterfeesDetailsToolStripMenuItem.Enabled = false;
                            frm.eventToolStripMenuItem.Enabled = false;
                            frm.hostelToolStripMenuItem.Enabled = false;
                            //Master Entry Menu


                            // Users Menu
                            frm.usersToolStripMenuItem.Enabled = false;
                            frm.loginDetailsToolStripMenuItem.Enabled = false;
                            frm.UserRegistrationToolStripMenuItemTop.Enabled = false;
                            // Users Menu


                            //Student Menu
                            frm.studentToolStripMenuItem.Enabled = false;
                            frm.studentProfileEntryToolStripMenuItem.Enabled = false;
                            frm.StudentRegistrationToolStripMenuItem2.Enabled = false;
                            frm.iDCardToolStripMenuItem.Enabled = false;
                            frm.PersonalLedgerToolStripMenuItem.Enabled = false;
                            frm.hostelersToolStripMenuItem.Enabled = false;
                            //Student Menu


                            //Employee Menu
                            frm.employeeToolStripMenuItem.Enabled = false;
                            frm.employeeProfileToolStripMenuItem.Enabled = false;
                            frm.employeeAttendanceToolStripMenuItem.Enabled = false;
                            frm.manageEventToolStripMenuItem.Enabled = false;
                            //Employee Menu

                            // Result Menu
                            frm.resultToolStripMenuItem1.Enabled = false;
                            frm.subjectMarksEntryToolStripMenuItem.Enabled = false;
                            frm.semesterResultToolStripMenuItem2.Enabled = false;
                            // Result Menu


                            // Transaction Menu
                            frm.transactionToolStripMenuItem.Enabled = false;
                            frm.SemesterfeePaymentToolStripMenuItem.Enabled = false;
                            frm.hostelFeesPaymentToolStripMenuItem.Enabled = false;
                            frm.othersTransactionToolStripMenuItem.Enabled = false;
                            // Transaction Menu


                            // Reports Menu
                            frm.reportsToolStripMenuItem.Enabled = true;
                            frm.ClearanceChitReportToolStripMenuItem2.Enabled = true;
                            frm.EmployeesReportToolStripMenuItem2.Enabled = false;
                            frm.feeCardReportToolStripMenuItem.Enabled = false;
                            frm.hostelFeePaymentReportToolStripMenuItem.Enabled = false;
                            frm.PersonalLedgerReportToolStripMenuItem2.Enabled = false;
                            frm.SemesterResultReportToolStripMenuItem.Enabled = false;
                            frm.SemesterfeePaymentReportToolStripMenuItem2.Enabled = false;
                            frm.studentsRegistrationReportToolStripMenuItem.Enabled = true;
                            frm.studentsReportToolStripMenuItem.Enabled = true;
                            frm.SubjectResultReportToolStripMenuItem1.Enabled = false;
                            frm.TranscriptReportToolStripMenuItem.Enabled = false;
                            frm.AdmissionAndWithdrawalReportToolStripMenuItem.Enabled = true;
                            // Reports Menu 


                            //Tools Menu 
                            frm.toolsMenu.Enabled = true;
                            //Tools Menu 


                            // Help Menu
                            frm.helpMenu.Enabled = true;
                            // Help Menu


                            // Menu On Form                             
                            frm.userRegistrationToolStripMenuItem.Enabled = false;
                            frm.StudentProfileEntryToolStripMenuItem1.Enabled = true;
                            frm.SubjectMarksEntryToolStripMenuItem1.Enabled = false;
                            frm.employeeToolStripMenuItem1.Enabled = false;
                            frm.SemesterfeePaymentToolStripMenuItem1.Enabled = false;
                            frm.AdmissionFormtoolStripMenuItem.Enabled = true;
                            frm.databaseToolStripMenuItem.Enabled = true;
                            frm.logoutToolStripMenuItem.Enabled = true;
                            // Menu On Form
                            #endregion                      

                        }
                        if (frm.UserType.Text == "Clerk")
                        {
                            this.Hide();
                            frm.User.Text = txtUserName.Text;
                            frm.Show();
                            #region ROLES 
                            //Master Entry Menu
                            frm.Master_entryMenu.Enabled = true;
                            frm.DepartmentToolStripMenuItem.Enabled = true;
                            frm.semesterToolStripMenuItem.Enabled = true;
                            frm.batchToolStripMenuItem.Enabled = true;
                            frm.subjectsToolStripMenuItem.Enabled = true;
                            frm.SubjectDetailsToolStripMenuItem.Enabled = true;
                            frm.SemesterfeesDetailsToolStripMenuItem.Enabled = true;
                            frm.eventToolStripMenuItem.Enabled = true;
                            frm.hostelToolStripMenuItem.Enabled = true;
                            //Master Entry Menu


                            // Users Menu
                            frm.usersToolStripMenuItem.Enabled = false;
                            frm.loginDetailsToolStripMenuItem.Enabled = false;
                            frm.UserRegistrationToolStripMenuItemTop.Enabled = false;
                            // Users Menu


                            //Student Menu
                            frm.studentToolStripMenuItem.Enabled = true;
                            frm.studentProfileEntryToolStripMenuItem.Enabled = true;
                            frm.StudentRegistrationToolStripMenuItem2.Enabled = true;
                            frm.iDCardToolStripMenuItem.Enabled = true;
                            frm.PersonalLedgerToolStripMenuItem.Enabled = true;
                            frm.hostelersToolStripMenuItem.Enabled = true;
                            //Student Menu


                            //Employee Menu
                            frm.employeeToolStripMenuItem.Enabled = true;
                            frm.employeeProfileToolStripMenuItem.Enabled = false;
                            frm.employeeAttendanceToolStripMenuItem.Enabled = false;
                            frm.manageEventToolStripMenuItem.Enabled = true;
                            //Employee Menu

                            // Result Menu
                            frm.resultToolStripMenuItem1.Enabled = true;
                            frm.subjectMarksEntryToolStripMenuItem.Enabled = true;
                            frm.semesterResultToolStripMenuItem2.Enabled = true;
                            // Result Menu


                            // Transaction Menu
                            frm.transactionToolStripMenuItem.Enabled = true;
                            frm.SemesterfeePaymentToolStripMenuItem.Enabled = true;
                            frm.hostelFeesPaymentToolStripMenuItem.Enabled = true;
                            frm.othersTransactionToolStripMenuItem.Enabled = true;
                            // Transaction Menu


                            // Reports Menu
                            frm.reportsToolStripMenuItem.Enabled = true;
                            frm.ClearanceChitReportToolStripMenuItem2.Enabled = true;
                            frm.EmployeesReportToolStripMenuItem2.Enabled = true;
                            frm.feeCardReportToolStripMenuItem.Enabled = true;
                            frm.hostelFeePaymentReportToolStripMenuItem.Enabled = true;
                            frm.PersonalLedgerReportToolStripMenuItem2.Enabled = true;
                            frm.SemesterResultReportToolStripMenuItem.Enabled = true;
                            frm.SemesterfeePaymentReportToolStripMenuItem2.Enabled = true;
                            frm.studentsRegistrationReportToolStripMenuItem.Enabled = true;
                            frm.studentsReportToolStripMenuItem.Enabled = true;
                            frm.SubjectResultReportToolStripMenuItem1.Enabled = true;
                            frm.TranscriptReportToolStripMenuItem.Enabled = true;
                            frm.AdmissionAndWithdrawalReportToolStripMenuItem.Enabled = true;
                            // Reports Menu 


                            //Tools Menu 
                            frm.toolsMenu.Enabled = true;
                            //Tools Menu 


                            // Help Menu
                            frm.helpMenu.Enabled = true;
                            // Help Menu


                            // Menu On Form                             
                            frm.userRegistrationToolStripMenuItem.Enabled = true;
                            frm.StudentProfileEntryToolStripMenuItem1.Enabled = true;
                            frm.SubjectMarksEntryToolStripMenuItem1.Enabled = true;
                            frm.employeeToolStripMenuItem1.Enabled = false;
                            frm.SemesterfeePaymentToolStripMenuItem1.Enabled = true;
                            frm.AdmissionFormtoolStripMenuItem.Enabled = true;
                            frm.databaseToolStripMenuItem.Enabled = true;
                            frm.logoutToolStripMenuItem.Enabled = true;
                            // Menu On Form
                            #endregion
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (myConnection.State == ConnectionState.Open)
                    {
                        myConnection.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(cs.DBConn);
                myConnection.Open();
                myCommand = myConnection.CreateCommand();
                myCommand.CommandText = "select RTRIM(Password) from Users where UserName = '"+Properties.Settings.Default.UserName.Trim()+"'";
                rdr = myCommand.ExecuteReader();
                if (rdr.Read())
                {
                    txtPassword.Text = (rdr.GetString(0).Trim());
                    chkRememeberME.Checked = true;          
                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            if (chkShowPassword.Checked == false)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
