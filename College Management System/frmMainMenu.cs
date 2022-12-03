using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
namespace College_Management_System
{
    public partial class frmMainMenu : Form
    {

        DataTable dtable = new DataTable();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
    
        public frmMainMenu()
        {
            InitializeComponent();
        }

      
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmCourse frm = new frmCourse();
            if (UserType.Text == "Admin")
            {              
                frm.label1.Text = UserType.Text;          
                frm.Show();
            }
            else
            {
                frm.label1.Text = UserType.Text;               
                frm.Show();
            }          
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout form2 = new frmAbout();
            form2.Show();
        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        frmContact form2 = new frmContact();
       
            form2.Show();
        }

        private void studentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            frmStudent form2 = new frmStudent();
            if (UserType.Text == "Admin")
            {          
                form2.label19.Text = UserType.Text;             
                form2.Show();
            }
            else
            {  
                form2.label19.Text = UserType.Text;             
                form2.Show();
            }
          
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

      
       

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void employeeProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmEmployeeDetails form2 = new frmEmployeeDetails();
            form2.label21.Text = UserType.Text;
            form2.label23.Text = User.Text;
            form2.Show();
        }

        private void feesDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
    
            frmSemesterFee frm = new frmSemesterFee();
            if (UserType.Text == "Admin")
            {
                frm.label13.Text = UserType.Text;
                frm.Show();
            }
            else
            {
                frm.label13.Text = UserType.Text;
                frm.Show();
            }
        }

        private void FeesMenu_Click(object sender, EventArgs e)
        {

        }

        private void feePaymentRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        
        }

        private void studentRecordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
           frmRecords. frmStudentsRecord form2 = new frmRecords.frmStudentsRecord();
            form2.txtStudent.Text = "";
            form2.dataGridView1.DataSource = null;
            form2.dataGridView2.DataSource = null;
            form2.dataGridView3.DataSource = null;
            form2.cmbCourse.Text = "";
            form2.cmbBranch.Text = "";
            form2.cmbSession.Text = "";      
            form2.DateFrom.Text = DateTime.Today.ToString();
            form2.DateTo.Text = DateTime.Today.ToString();
            form2.cmbBranch.Enabled = false;
            form2.cmbSession.Enabled = false;
            form2.label10.Text = UserType.Text;
            form2.label11.Text = User.Text;
            form2.Show();
        }

        private void feePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmSemesterFeePayment form2 = new frmSemesterFeePayment();
            form2.label23.Text = UserType.Text;
            form2.label24.Text = User.Text;
            form2.Show();
        }

       



        private void othersTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            frmOtherTransaction frm = new frmOtherTransaction();
            frm.label4.Text = UserType.Text;
            frm.label6.Text = User.Text;
            frm.Show();
        }

        private void scholarshipPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void internalMarksEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
           
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString();
            timer1.Start();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {       
            Time.Text= DateTime.Now.ToString();         
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void subjectInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubjectInfo frm = new frmSubjectInfo();
            if (UserType.Text == "Admin")
            {
                frm.label1.Text = UserType.Text;
                frm.Show();
            }
            else
            {
                frm.label1.Text = UserType.Text;
                frm.Show();
            }
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserRegistration frm = new frmUserRegistration();
            frm.label8.Text = UserType.Text;
            frm.label9.Text = User.Text;
            frm.Show();
          
           
        }

        private void loginDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoginDetails frm = new frmLoginDetails();
            frm.Show();
        }

        private void userRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserRegistration frm = new frmUserRegistration();
            frm.label8.Text = UserType.Text;
            frm.label9.Text = User.Text;
            frm.Show();
        }

        private void employeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEmployeeDetails form2 = new frmEmployeeDetails();
            form2.label21.Text = UserType.Text;
            form2.label23.Text = User.Text;
            form2.Show();
        }

        private void taskManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("TaskMgr.exe");
        }

        private void mSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Winword.exe");
        }


     

 

   

        private void wordpadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Wordpad.exe");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            frmReports.frmStudentsReport frm = new frmReports.frmStudentsReport();
            frm.Show();
        }

      
     



        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void semesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSemester frm = new frmSemester();
            if (UserType.Text == "Admin")
            {
                frm.label1.Text = UserType.Text;

                frm.Show();
            }
            else
            {


                frm.label1.Text = UserType.Text;

                frm.Show();
            }
        }

    

        private void registrationToolStripMenuItem2_Click(object sender, EventArgs e)
        {           
            frmStudentRegistration frm = new frmStudentRegistration();         
            if (UserType.Text == "Admin")
            {
                frm.label1.Text = UserType.Text;
                frm.Show();
            }
            else
            {
                frm.label1.Text = UserType.Text;
                frm.Show();
            }
           
        }

        private void registrationFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void studentRegistrationRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

      

      
        private void employeeRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void feePaymentToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmReports.frmSingleSemsterFeePaymentReport frm = new frmReports.frmSingleSemsterFeePaymentReport();
            frm.Show();
        }

        private void attendanceToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmReports.frmclearancechit frm = new frmReports.frmclearancechit();
            frm.Show();
          
        }

        private void employeeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
          
            frmReports.frmEmployeesReport frm = new frmReports.frmEmployeesReport();
            frm.Show();
        }

        private void otherTransactionRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmOtherTransactionRecord frm = new frmOtherTransactionRecord();
            frm.label1.Text = UserType.Text;
            frm.label2.Text = User.Text;
            frm.Show();
        }




        private void studentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmStudent form2 = new frmStudent();
            if (UserType.Text == "Admin")
            {
                form2.label19.Text = UserType.Text;
                form2.Show();
            }
            else
            {
                form2.label19.Text = UserType.Text;
                form2.Show();
            }
        }

        private void studentsRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
            frmReports.frmStudentsRegistrationsReport frm = new frmReports.frmStudentsRegistrationsReport();
            frm.Show();
        }

        private void salaryPaymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReports.frmSubjectResultReport frm = new frmReports.frmSubjectResultReport();
            frm.Show();
        }


        private void internalMarksEntryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSubjectResult frm = new frmSubjectResult();
            frm.label5.Text = UserType.Text;
            frm.label6.Text = User.Text;
            frm.Show();
        }

  

        private void feePaymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSemesterFeePayment form2 = new frmSemesterFeePayment();
            form2.label23.Text = UserType.Text;
            form2.label24.Text = User.Text;
            form2.Show();
        }

 

   


        private void hostelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmHostel frm = new frmHostel();
            if (UserType.Text == "Admin")
            {
                frm.label1.Text = UserType.Text;
                frm.Show();
            }
            else
            {
                frm.label1.Text = UserType.Text;
                frm.Show();
            }
        }

        private void hostelFeesPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmHostelFeePayment frm = new frmHostelFeePayment();
            if (UserType.Text == "Admin")
            {
                frm.label3.Text = UserType.Text;
                frm.label4.Text = User.Text;
                frm.Update_record.Enabled = false;
                frm.Delete.Enabled = false;
                frm.Show();
            }
            else
            {
                frm.label3.Text = UserType.Text;
                frm.label4.Text = User.Text;
                frm.Update_record.Enabled = false;
                frm.Delete.Enabled = false;
                frm.Show();
            }           
        }

      

       

      

        private void salarySlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReports.frmWithdrawalAndAdmission frm = new frmReports.frmWithdrawalAndAdmission();
            frm.Show();
        }

     

        private void hostelersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHostelers frm = new frmHostelers();
          
            if (UserType.Text == "Admin")
            {
                frm.label3.Text = UserType.Text;
                frm.Show();
            }
            else
            {
                frm.label3.Text = UserType.Text;
                frm.Show();
            }
        }

        private void hostelersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void hostlersToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            frmReports.frmSemestersResultReport frm = new frmReports.frmSemestersResultReport();            
            frm.Show();
        }

        private void hostelFeePaymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

        private void hostelFeePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            frmReports.frmHostelFeePaymentsReport frm = new frmReports.frmHostelFeePaymentsReport();
            frm.Show();
        }

     

    

       



        private void transportationChargesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReports.frmTranscriptReport frm = new frmReports.frmTranscriptReport();
            frm.Show();
        }

  


    

      

        private void busHoldersToolStripMenuItem2_Click(object sender, EventArgs e)
        {
          
            frmReports.frmPersonalLedgerReport frm = new frmReports.frmPersonalLedgerReport();
            frm.Show();
        }

      

    

     

        private void eventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEvent frm = new frmEvent();
            if (UserType.Text == "Admin")
            {

                frm.label6.Text = UserType.Text;

                frm.Show();
            }
            else
            {

                frm.label6.Text = UserType.Text;

                frm.Show();
            }

        }

        private void batchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBatch frm = new frmBatch();
            if (UserType.Text == "Admin")
            {
                frm.label6.Text = UserType.Text;
                frm.Show();
            }
            else
            {

                frm.label6.Text = UserType.Text;
                frm.Show();
            }
        }

      

        private void EventtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {

         
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer2.Enabled = false;
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmBackUpAndRestore frm = new Forms.frmBackUpAndRestore();
            frm.Show();
        }

        private void helpMenu_Click(object sender, EventArgs e)
        {

        }

        private void Time_Click(object sender, EventArgs e)
        {

        }

        private void User_Click(object sender, EventArgs e)
        {

        }

        private void iDCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIdCard frm = new frmIdCard();
            if (UserType.Text == "Admin")
            {
                frm.labelU.Text = UserType.Text;
                frm.Show();
            }
            else
            {
                frm.labelU.Text = UserType.Text;
                frm.Show();
            }
        }

        private void employeeAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmEmployeeAttendance frm = new frmEmployeeAttendance();

            if (UserType.Text == "Admin")
            {
                frm.label1.Text = UserType.Text;
                frm.Update_record.Enabled = true;
                frm.Delete.Enabled = true;
                frm.Show();
            }
            else
            {
                frm.label1.Text = UserType.Text;
                frm.Update_record.Enabled = false;
                frm.Delete.Enabled = false;
                frm.Show();
            }
            
        }

        private void employeeClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void frmMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.txtUserName.Text = "";
            frm.txtPassword.Text = "";
            frm.txtUserName.Focus();
            frm.Show();
        }

        private void semesterResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmPersonalLedger frm = new Forms.frmPersonalLedger();
            if (UserType.Text == "Admin")
            {
                frm.label1.Text = UserType.Text;
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = true;
                frm.Show();
            }
            else
            {
                frm.label1.Text = UserType.Text;
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = true;
                frm.Show();
            }
        }

        private void gPACalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGPACalculator frm = new frmGPACalculator();
            frm.Show();
        }

        private void semesterSubjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmSemesterSubjects frm = new Forms.frmSemesterSubjects();
            if (UserType.Text == "Admin")
            {
                frm.label3.Text = UserType.Text;
                frm.Show();
            }
            else
            {
                frm.label3.Text = UserType.Text;
                frm.Show();
            }            
        }

        private void examsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Master_entryMenu_Click(object sender, EventArgs e)
        {

        }

        private void manageEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRecords.frmEventManagedBy frm = new frmRecords.frmEventManagedBy();
            if (UserType.Text == "Admin")
            {
                frm.label5.Text = UserType.Text;
                frm.Delete.Enabled = true;
                frm.Update_record.Enabled = true;
                frm.Show();
            }
            else
            {
                frm.label5.Text = UserType.Text;
                frm.Delete.Enabled = false;
                frm.Update_record.Enabled = false;
                frm.Show();
            }
        }

        private void assignedClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void semesterResultToolStripMenuItem1_Click(object sender, EventArgs e)
        {
         
        }

        private void menuStrip_MouseHover(object sender, EventArgs e)
        {
            this.ForeColor = Color.Black;
        }

        private void menuStrip1_MouseHover(object sender, EventArgs e)
        {
            ForeColor = Color.Black;
        }

        private void subjectMarksEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubjectResult frm = new frmSubjectResult();
            frm.label5.Text = UserType.Text;
            frm.label6.Text = User.Text;
            frm.Show();
        }

        private void semesterResultToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Forms.frmSemesterResult frm = new Forms.frmSemesterResult();
            if (UserType.Text == "Admin")
            {
                frm.label1.Text = UserType.Text;
                frm.button1.Enabled = false;
                frm.Delete.Enabled = false;
                frm.Show();
            }
            else
            {
                frm.label1.Text = UserType.Text;
                frm.button1.Enabled = false;
                frm.Delete.Enabled = false;
                frm.Show();
            }
        }

        private void feeCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReports.frmFeeCardReport frm = new frmReports.frmFeeCardReport();
            frm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.frmRegistrationFrom frm = new Forms.frmRegistrationFrom();
            frm.Show();
        }

        private void frmMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
          
}

      

     

       
      

      

      

      

       

      


       

       
   

