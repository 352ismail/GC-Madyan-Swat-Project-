using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace College_Management_System
{
    public partial class frmSubjectResult : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        public frmSubjectResult()
        {
            InitializeComponent();
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmbRollNo.Items.Clear();
            //cmbRollNo.Text = "";
            //cmbRollNo.Enabled = true;

            //try
            //{

            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    string ct = "select distinct RTRIM(course) from Student where session = '" + StudentName.Text + "'";
            //    cmd = new SqlCommand(ct);
            //    cmd.Connection = con;

            //    rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {
            //        cmbRollNo.Items.Add(rdr[0]);
            //    }
            //    con.Close();

            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ClassName.Items.Clear();
            //ClassName.Text = "";
            //ClassName.Enabled = true;

            //try
            //{

            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();


            //    string ct = "select distinct RTRIM(branch) from Student where course = '" + cmbRollNo.Text + "' and session='" + StudentName.Text + "'";

            //    cmd = new SqlCommand(ct);
            //    cmd.Connection = con;

            //    rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {
            //        ClassName.Items.Add(rdr[0]);
            //    }
            //    con.Close();

            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FacultyName.Items.Clear();
            //FacultyName.Text = "";
            //FacultyName.Enabled = true;

            //try
            //{

            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();


            //    string ct = "select distinct RTRIM(Semester) from batch where Course = '" + cmbRollNo.Text + "' and session='" + StudentName.Text + "'";

            //    cmd = new SqlCommand(ct);
            //    cmd.Connection = con;

            //    rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {
            //        FacultyName.Items.Add(rdr[0]);
            //    }
            //    con.Close();

            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void cmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            //AssignedTo.Text = "";
            //AssignedTo.Enabled = true;

            //try
            //{

            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();


            //    string ct = "select distinct RTRIM(Section) from Student,batch where Student.Session=Batch.session and Student.Course = '" + cmbRollNo.Text + "' and Student.Branch= '" + ClassName.Text + "' and Semester='" + FacultyName.Text + "'";

            //    cmd = new SqlCommand(ct);
            //    cmd.Connection = con;

            //    rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {
                 
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    txtSubjectName.Items.Clear();
            //    txtSubjectName.Text = "";
            //    txtSubjectName.Enabled = true;
            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();


            //    string ct = "select distinct RTRIM(SubjectCode) from SubjectInfo where CourseName = '" + cmbRollNo.Text + "' and Branch= '" + ClassName.Text + "' and semester= '" + FacultyName.Text + "'";

            //    cmd = new SqlCommand(ct);
            //    cmd.Connection = con;

            //    rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {
            //       txtSubjectName.Items.Add(rdr[0]);
            //    }
            //    con.Close();
            //   }
            //   catch (Exception ex)
            //   {
            //       MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //   }
        }
 
 
        private void cmbSubjectCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT CH,SubjectCode from Subject WHERE SubjectName = '" + txtSubjectName.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    txtCh.Text = rdr.GetInt32(0).ToString();
                    txtSubjectCode.Text = rdr.GetString(1).Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                //Get Subject Id
                #region Get Subject Id 
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select SubjectId from Subject where SubjectName ='" + txtSubjectName.Text + "'";

                cmd = new SqlCommand(ct2);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    lblSubjectId.Text = rdr.GetInt32(0).ToString();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                #endregion
                //Load Class No Of Student
                #region Load Class No 
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(ClassNo) from Student where DepartmentId=(Select DepartmentId From Department where  ClassName = '" + ClassName.Text.Trim() + "' and FacultyName ='" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Description = '" + Session.Text.Trim() + "') ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                cmbClassNo.Items.Clear();
                while (rdr.Read())
                {
                    cmbClassNo.Items.Add(rdr[0]);
                }
                con.Close();

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getData()

        {
            #region Validation 
            if (ClassName.Text == "")
            {
                MessageBox.Show("Please select Class Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClassName.Focus();
                return;
            }
            if (FacultyName.Text == "")
            {
                MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FacultyName.Focus();
                return;
            }
            if (Session.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Session.Focus();
                return;
            }

            if (cmbSemester.Text == "")
            {
                MessageBox.Show("Please select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSemester.Focus();
                return;
            }
            if (cmbExamStatus.Text == "")
            {
                MessageBox.Show("Please Select Exam Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbExamStatus.Focus();
                return;
            }
            if (txtSubjectName.Text == "")
            {
                MessageBox.Show("Please Select SubjectName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbExamStatus.Focus();
                return;
            }
            if (EmployeeName.Text == "")
            {
                MessageBox.Show("Please Select Professor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmployeeName.Focus();
                return;
            }
            #endregion
            try
            {
                dataGridView1.DataSource = null;
                //Fresh
                if (cmbExamStatus.Text == "Fresh")
                {
                    //Final Term
                    if (FinalTerm.Checked == true)
                    {
                        //With Lab
                        #region With Lab
                        if (rdbWithLab.Checked == true)
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select Student.Studentid[Id],RTRIM(ClassNo)[Class No],rtrim(StudentName)[Student Name],(Select rtrim(Mid)from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[mid], (Select rtrim(Final)from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[Final], (Select rtrim(Assignment)from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "') )[Assig:],(Select rtrim(Presentation)from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[Pres],(Select rtrim(Quizz)from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[Quiz],(Select rtrim(Lab)from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[Lab],(Select rtrim(TotalObtainedMarks)from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[Total],(Select Value from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "') )[Value],(Select GP from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[GP],(Select StudentStatusId from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[StatusId],(Select Grade from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[Grade]from Student where Student.DepartmentId = (Select DepartmentId from Department where className = '" + ClassName.Text.Trim() + "' and FacultyName = '" + FacultyName.Text.Trim() + "') and Student.SessionId = (Select SessionId from Session where Description = '" + Session.Text.Trim() + "')", con);
                            SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                            DataSet myDataSet = new DataSet();
                            myDA.Fill(myDataSet, "Student");
                            dataGridView1.DataSource = myDataSet.Tables["Student"].DefaultView;

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                dataGridView1.Columns["StatusId"].Visible = false;
                                dataGridView1.Columns["Id"].Visible = false;
                                row.Cells[9].ReadOnly = true;
                                row.Cells[10].ReadOnly = true;
                                row.Cells[11].ReadOnly = true;
                                row.Cells[0].ReadOnly = true;
                                row.Cells[1].ReadOnly = true;
                                row.Cells[2].ReadOnly = true;
                                row.Cells[3].ReadOnly = true;
                                row.Cells[13].ReadOnly = true;
                            }
                            con.Close();

                        }
                        #endregion
                        //End With Lab

                        //without lab 
                        #region Without Lab 
                        else if (rdbWithoutLab.Checked == true)
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select Student.Studentid[Id],RTRIM(ClassNo)[Class No],rtrim(StudentName)[Student Name],(Select rtrim(Mid)from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[mid], (Select rtrim(Final)from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[Final], (Select rtrim(Assignment)from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "') )[Assig:],(Select rtrim(Presentation)from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[Pres],(Select rtrim(Quizz)from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[Quiz],(Select rtrim(Lab)from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[Lab],(Select rtrim(TotalObtainedMarks)from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[Total],(Select Value from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "') )[Value],(Select GP from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[GP],(Select StudentStatusId from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[StatusId],(Select Grade from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[Grade]from Student where Student.DepartmentId = (Select DepartmentId from Department where className = '" + ClassName.Text.Trim() + "' and FacultyName = '" + FacultyName.Text.Trim() + "') and Student.SessionId = (Select SessionId from Session where Description = '" + Session.Text.Trim() + "')", con);
                            SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                            DataSet myDataSet = new DataSet();
                            myDA.Fill(myDataSet, "Student");
                            dataGridView1.DataSource = myDataSet.Tables["Student"].DefaultView;

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                dataGridView1.Columns["StatusId"].Visible = false;
                                dataGridView1.Columns["Id"].Visible = false;
                                dataGridView1.Columns["Lab"].Visible = false;
                                row.Cells[9].ReadOnly = true;
                                row.Cells[10].ReadOnly = true;
                                row.Cells[11].ReadOnly = true;
                                row.Cells[0].ReadOnly = true;
                                row.Cells[1].ReadOnly = true;
                                row.Cells[2].ReadOnly = true;
                                row.Cells[3].ReadOnly = true;
                                row.Cells[13].ReadOnly = true;
                            }
                            con.Close();

                        }
                        #endregion
                        // End Without Lab
                        else
                        {
                            MessageBox.Show("Please Select With Lab Or Without Lab.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }
                    //end Final Term

                    //Mid Term
                    else if (MidTerm.Checked == true)
                    {
                        //With Lab
                        #region With Lab
                        if (rdbWithLab.Checked == true)
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select Student.Studentid[Id],RTRIM(ClassNo)[Class No],rtrim(StudentName)[Student Name],(Select rtrim(Mid)from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[mid] from Student where Student.DepartmentId = (Select DepartmentId from Department where className = '" + ClassName.Text.Trim() + "' and FacultyName = '" + FacultyName.Text.Trim() + "') and Student.SessionId = (Select SessionId from Session where Description = '" + Session.Text.Trim() + "')", con);
                            SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                            DataSet myDataSet = new DataSet();
                            myDA.Fill(myDataSet, "Student");
                            dataGridView1.DataSource = myDataSet.Tables["Student"].DefaultView;
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                dataGridView1.Columns["Id"].Visible = false;
                            }
                            con.Close();
                        }
                        #endregion
                        //WithoutLab
                        #region With Lab
                        else if (rdbWithoutLab.Checked == true)
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select Student.Studentid[Id],RTRIM(ClassNo)[Class No],rtrim(StudentName)[Student Name],(Select rtrim(Mid)from Result WHERE Student.StudentId = Result.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "'))[mid] from Student where Student.DepartmentId = (Select DepartmentId from Department where className = '" + ClassName.Text.Trim() + "' and FacultyName = '" + FacultyName.Text.Trim() + "') and Student.SessionId = (Select SessionId from Session where Description = '" + Session.Text.Trim() + "')", con);
                            SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                            DataSet myDataSet = new DataSet();
                            myDA.Fill(myDataSet, "Student");
                            dataGridView1.DataSource = myDataSet.Tables["Student"].DefaultView;
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                dataGridView1.Columns["Id"].Visible = false;
                            }
                            con.Close();
                        }
                        #endregion
                        else
                        {
                            MessageBox.Show("Please Select With Lab Or Without Lab.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    //End Mid Term
                    else
                    {
                        MessageBox.Show("Please Select Exam Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //end Fresh
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            getData();
            if (label5.Text == "Admin")
            {
                button2.Enabled = true;
            }
            else 

            button2.Enabled = false;
        }




        private void frmInternalMarksEntry_Load(object sender, EventArgs e)
        {
            AutocompleClass();
            AutoCompleteEmployeeName();
            AutoCompleteExam();
        }

        #region AutoCompleteFunctions 
        private void AutoCompleteEmployeeName()
        {
            try
            {
                //Load Employee Name

                EmployeeName.Text = "";
                EmployeeName.Enabled = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "Select EmployeeName From Employee,Users where Employee.EmployeeName=Users.Name and UserName = '" + label6.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    EmployeeName.Text = rdr.GetString(0).Trim();
                }
                else if (rdr.Read() == false)
                {
                    MessageBox.Show("Teacher Name And User Name Does not matched. \n Add New Teacher.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Hide();
                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AutoCompleteExam()
        {
            try
            {
                //Get Exam Status
                cmbExamStatus.Enabled = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct1 = "select distinct RTRIM(Status) from ExamStatus";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbExamStatus.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public void AutocompleClass()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(ClassName) from Department ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ClassName.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion
        private void ResetDataGridView()
        {
            ClassName.Text="";
            FacultyName.Text = "";
            Session.Text = "";
            cmbExamStatus.Text = "";
            cmbSemester.Text = "";
            txtSeason.Text = "";
            txtSubjectName.Text = "";
            txtSubjectCode.Text = "";
            txtCh.Text = "";
            dtpExamDate.Text = System.DateTime.Today.ToString();
            dataGridView1.DataSource = null;
            ClassName.Focus();          
        }
        private void ResetTextFields()
        {
            ClassName.Text = "";
            FacultyName.Text = "";
            Session.Text = "";
            cmbExamStatus.Text = "";
            cmbSemester.Text = "";
            txtSeason.Text = "";
            txtSubjectName.Text = "";
            txtSubjectCode.Text = "";
            txtCh.Text = "";
            dtpExamDate.Text = System.DateTime.Today.ToString();
            dataGridView1.DataSource = null;
            cmbClassNo.Text = "";
            txtStudentName.Text = "";
            Mid.Text = "";
            Final.Text = "";
            Assignment.Text = "";
            Presentation.Text = "";
            Quizz.Text = "";
            txtLab.Text = "";
            ClassName.Focus();
        }


        private void NewRecord_Click(object sender, EventArgs e)
        {
            if (cmbExamStatus .Text == "Fresh")
            {
                ResetDataGridView();


            }
           else if (cmbExamStatus.Text == "Repeat" || cmbExamStatus.Text == "Makeup" || cmbExamStatus.Text == "SCE")
            {
                ResetTextFields();
            }
            else
            {
                ResetTextFields();
                ResetDataGridView();
            }
            Delete.Enabled = false;
            button2.Enabled = false;
            btnSave.Enabled = true;
            
        }
    
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region vaidation
                if (ClassName.Text == "")
                {
                    MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClassName.Focus();
                    return;
                }
                if (FacultyName.Text == "")
                {
                    MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FacultyName.Focus();
                    return;
                }
                if (Session.Text == "")
                {
                    MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Session.Focus();
                    return;
                }
                if (cmbExamStatus.Text == "")
                {
                    MessageBox.Show("Please select Exam Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbExamStatus.Focus();
                    return;
                }
                if (FinalTerm.Checked == false && MidTerm.Checked == false)
                {
                    MessageBox.Show("Please Select EXam Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MidTerm.Focus();
                    return;
                }
                if (cmbSemester.Text == "")
                {
                    MessageBox.Show("Please select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSemester.Focus();
                    return;
                }
                if (txtSubjectName.Text == "")
                {
                    MessageBox.Show("Please select Subject Name ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubjectName.Focus();
                    return;
                }
                if (rdbWithLab.Checked == false && rdbWithoutLab.Checked == false)
                {
                    MessageBox.Show("Please Select with Lab Or Without Lab", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdbWithoutLab.Focus();
                    return;
                }
                if (EmployeeName.Text == "")
                {
                    MessageBox.Show("Please select Teacher", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EmployeeName.Focus();
                    return;
                }
                if (cmbExamStatus.Text == "Repeat" || cmbExamStatus.Text == "Makeup" || cmbExamStatus.Text == "SCE")
                {                 
                
                    if (cmbClassNo.Text == "")
                    {
                        MessageBox.Show("Please select Class No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbClassNo.Focus();
                        return;
                    }
                    //Mid Term 
                    if (MidTerm.Checked == true)
                    {
                        //without Lab 
                        #region Without Lab
                        if (rdbWithoutLab.Checked)
                        {
                            if (Mid.Text == "")
                            {
                                MessageBox.Show("Please Enter Mid Marks ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Mid.Focus();
                                return;
                            }
                        }
                        #endregion
                        //With Lab
                        #region With Lab 
                        if (rdbWithLab.Checked)
                        {
                            if (Mid.Text == "")
                            {
                                MessageBox.Show("Please Enter Mid Marks ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Mid.Focus();
                                return;
                            }
                        }
                        #endregion
                    }
                    //Final Term
                    if (FinalTerm.Checked == true)
                    {
                        //without Lab 
                        #region Without Lab
                        if (rdbWithoutLab.Checked)
                        {
                            if (Mid.Text == "")
                            {
                                MessageBox.Show("Please Enter Mid Marks ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Mid.Focus();
                                return;
                            }
                            if (Final.Text == "")
                            {
                                MessageBox.Show("Please Enter Final Marks", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Final.Focus();
                                return;
                            }
                            if (Assignment.Text == "")
                            {
                                MessageBox.Show("Please Enter Assignment ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Assignment.Focus();
                                return;
                            }
                            if (Presentation.Text == "")
                            {
                                MessageBox.Show("Please Enter Presentation Marks ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Presentation.Focus();
                                return;
                            }
                            if (Quizz.Text == "")
                            {
                                MessageBox.Show("Please Enter Quiz Marks ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Quizz.Focus();
                                return;
                            }
                        }
                        #endregion
                        //With Lab
                        #region With Lab 
                        if (rdbWithLab.Checked)
                        {
                            if (Mid.Text == "")
                            {
                                MessageBox.Show("Please Enter Mid Marks ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Mid.Focus();
                                return;
                            }
                            if (Final.Text == "")
                            {
                                MessageBox.Show("Please Enter Final Marks", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Final.Focus();
                                return;
                            }
                            if (Assignment.Text == "")
                            {
                                MessageBox.Show("Please Enter Assignment ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Assignment.Focus();
                                return;
                            }
                            if (Presentation.Text == "")
                            {
                                MessageBox.Show("Please Enter Presentation Marks ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Presentation.Focus();
                                return;
                            }
                            if (Quizz.Text == "")
                            {
                                MessageBox.Show("Please Enter Quiz Marks ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Quizz.Focus();
                                return;
                            }
                            if (txtLab.Text == "")
                            {
                                MessageBox.Show("Please Enter Lab Marks ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtLab.Focus();
                                return;
                            }
                        }
                        #endregion
                    }//end if 

                }
                #endregion
                // Fresh Exams 
                #region Fresh Eams
                if (cmbExamStatus.Text == "Fresh")
                {
                    // Mid Term                   
                    if (MidTerm.Checked == true)
                    {
                        // Reader
                        #region Reader 
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string ct = "select DepartmentId,SessionId,SubjectId,ExamStatusId,SemesterId,StudentId from Result where DepartmentId=(Select DepartmentId from Department where ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + Session.Text.Trim() + "' )  and SubjectId= (Select SubjectId From Subject where SubjectName ='" + txtSubjectName.Text.Trim() + "') and ExamStatusId = (Select ExamStatusId From ExamStatus where Status = '" + cmbExamStatus.Text.Trim() + "') and SemesterId = (Select SemesterId From Semester where Description = '" + cmbSemester.Text.Trim() + "' ) AND StudentId = '"+row.Cells[0].Value+"'";
                                cmd = new SqlCommand(ct);
                                cmd.Connection = con;
                                rdr = cmd.ExecuteReader();
                                if (rdr.Read() == false)
                                {
                                    #region Mid Term
                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string cb = "insert into Result(ExamDate,Mid,studentId,SubjectId,SemesterId,EmployeeId,ExamStatusId,DepartmentId,SessionId) VALUES (@examdate,@mid,@studentid,@subjectid,@semesterid,@employeeid,@examstatusid, @departmentid,@sessionid)";
                                    cmd = new SqlCommand(cb);
                                    cmd.Connection = con;
                                    // Add Parameters to Command Parameters collection
                                    cmd.Parameters.Add(new SqlParameter("@examdate", System.Data.SqlDbType.NVarChar, 50, "ExamDate"));
                                    cmd.Parameters.Add(new SqlParameter("@mid", System.Data.SqlDbType.Int, 10, "Mid"));
                                    cmd.Parameters.Add(new SqlParameter("@studentid", System.Data.SqlDbType.Int, 50, "StudentId"));
                                    cmd.Parameters.Add(new SqlParameter("@subjectid", System.Data.SqlDbType.Int, 10, "SubjectId"));
                                    cmd.Parameters.Add(new SqlParameter("@semesterid", System.Data.SqlDbType.Int, 50, "SemesterId"));
                                    cmd.Parameters.Add(new SqlParameter("@employeeid", System.Data.SqlDbType.Int, 50, "EmployeeId"));
                                    cmd.Parameters.Add(new SqlParameter("@examstatusid", System.Data.SqlDbType.Int, 50, "ExamStatusId"));
                                    cmd.Parameters.Add(new SqlParameter("@departmentid", System.Data.SqlDbType.Int, 10, "DepartmentId"));
                                    cmd.Parameters.Add(new SqlParameter("@sessionid", System.Data.SqlDbType.Int, 10, "SessionId"));                                
                                            cmd.Parameters["@examdate"].Value = dtpExamDate.Text;
                                            cmd.Parameters["@mid"].Value = row.Cells[3].Value;
                                            cmd.Parameters["@studentid"].Value = row.Cells[0].Value;
                                            cmd.Parameters["@subjectid"].Value = Convert.ToInt32(lblSubjectId.Text.Trim());
                                            cmd.Parameters["@semesterid"].Value = Convert.ToInt32(lblSemesterId.Text.Trim());
                                            cmd.Parameters["@employeeid"].Value = Convert.ToInt32(lblEmployeeId.Text.Trim());
                                            cmd.Parameters["@examstatusid"].Value = Convert.ToInt32(ExamStatusId.Text.Trim());
                                            cmd.Parameters["@departmentid"].Value = Convert.ToInt32(lblDepartmentid.Text.Trim());
                                            cmd.Parameters["@sessionid"].Value = Convert.ToInt32(lblSessionId.Text.Trim());
                                            cmd.ExecuteNonQuery();
                                    con.Close();
                                    
                                    //btnSave.Enabled = false;
                                    #endregion
                                    if ((rdr != null))
                                    {
                                        rdr.Close();
                                    }                                 
                                }// end if 
                            }// end New Row                           
                        }// end For each 

                        MessageBox.Show("Successfully saved", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        #endregion
                    }
                    // Final Term
                    if (FinalTerm.Checked == true)
                    {
                        #region Final Fresh
                        // Fresh Exam Final 
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "Update Result Set ExamDate = @examdate,Presentation=@presentation,Assignment=@assignment,Quizz=@quizz,Lab=@lab,Final=@final,TotalObtainedMarks=@totalobtainedmarks,Value=@value,GP=@gp ,Grade=@grade ,StudentStatusId=@studentstatusid,EmployeeId = @employeeid    where   studentId=@studentid and SubjectId=@subjectid and SemesterId = @semesterid  and ExamStatusId = @examstatusid  and DepartmentId = @departmentid and SessionId=@sessionid";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        // Add Parameters to Command Parameters collection
                        cmd.Parameters.Add(new SqlParameter("@examdate", System.Data.SqlDbType.NVarChar, 50, "ExamDate"));
                        cmd.Parameters.Add(new SqlParameter("@presentation", System.Data.SqlDbType.Int, 15, "Presentation"));
                        cmd.Parameters.Add(new SqlParameter("@assignment", System.Data.SqlDbType.Int, 10, "Assignment"));
                        cmd.Parameters.Add(new SqlParameter("@quizz", System.Data.SqlDbType.Int, 10, "Quizz"));
                        cmd.Parameters.Add(new SqlParameter("@lab", System.Data.SqlDbType.Int, 10, "Lab"));
                        cmd.Parameters.Add(new SqlParameter("@final", System.Data.SqlDbType.Int, 10, "Final"));
                        cmd.Parameters.Add(new SqlParameter("@totalobtainedmarks", System.Data.SqlDbType.Int, 10, "TotalObtainedMarks"));
                        cmd.Parameters.Add(new SqlParameter("@value", System.Data.SqlDbType.Float, 10, "Value"));
                        cmd.Parameters.Add(new SqlParameter("@gp", System.Data.SqlDbType.Float, 10, "GP"));
                        cmd.Parameters.Add(new SqlParameter("@grade", System.Data.SqlDbType.NVarChar, 50, "Grade"));
                        cmd.Parameters.Add(new SqlParameter("@studentid", System.Data.SqlDbType.Int, 50, "StudentId"));
                        cmd.Parameters.Add(new SqlParameter("@subjectid", System.Data.SqlDbType.Int, 10, "SubjectId"));
                        cmd.Parameters.Add(new SqlParameter("@semesterid", System.Data.SqlDbType.Int, 50, "SemesterId"));
                        cmd.Parameters.Add(new SqlParameter("@employeeid", System.Data.SqlDbType.Int, 50, "EmployeeId"));
                        cmd.Parameters.Add(new SqlParameter("@examstatusid", System.Data.SqlDbType.Int, 50, "ExamStatusId"));
                        cmd.Parameters.Add(new SqlParameter("@studentstatusid", System.Data.SqlDbType.Int, 10, "StudentStatusId"));
                        cmd.Parameters.Add(new SqlParameter("@departmentid", System.Data.SqlDbType.Int, 10, "DepartmentId"));
                        cmd.Parameters.Add(new SqlParameter("@sessionid", System.Data.SqlDbType.Int, 10, "SessionId"));
                        // Data to be inserted
                        cmd.Prepare();
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                cmd.Parameters["@examdate"].Value = dtpExamDate.Text;
                                cmd.Parameters["@studentid"].Value = row.Cells[0].Value;
                                cmd.Parameters["@final"].Value = row.Cells[4].Value;
                                cmd.Parameters["@assignment"].Value = row.Cells[5].Value;
                                cmd.Parameters["@presentation"].Value = row.Cells[6].Value;
                                cmd.Parameters["@quizz"].Value = row.Cells[7].Value;
                                cmd.Parameters["@lab"].Value = row.Cells[8].Value;
                                cmd.Parameters["@totalobtainedmarks"].Value = row.Cells[9].Value;
                                cmd.Parameters["@value"].Value = row.Cells[10].Value;
                                cmd.Parameters["@gp"].Value = row.Cells[11].Value;
                                cmd.Parameters["@grade"].Value = row.Cells[13].Value;
                                cmd.Parameters["@studentstatusid"].Value = row.Cells[12].Value;
                                cmd.Parameters["@subjectid"].Value = Convert.ToInt32(lblSubjectId.Text.Trim());
                                cmd.Parameters["@semesterid"].Value = Convert.ToInt32(lblSemesterId.Text.Trim());
                                cmd.Parameters["@employeeid"].Value = Convert.ToInt32(lblEmployeeId.Text.Trim());
                                cmd.Parameters["@examstatusid"].Value = Convert.ToInt32(ExamStatusId.Text.Trim());
                                cmd.Parameters["@departmentid"].Value = Convert.ToInt32(lblDepartmentid.Text.Trim());
                                cmd.Parameters["@sessionid"].Value = Convert.ToInt32(lblSessionId.Text.Trim());
                                cmd.ExecuteNonQuery();
                            }
                        }
                        
                        con.Close();
                        MessageBox.Show("Successfully Saved", "Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                        #endregion
                    }
                }
                #endregion
                // Special Exams 
                #region Special Exams
                else if (cmbExamStatus.Text == "Repeat" || cmbExamStatus.Text == "Makeup" || cmbExamStatus.Text == "SCE")
                {
                
                    // Mid Term 
                  
                    if (MidTerm.Checked == true)
                    {
                        #region Mid Term
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "insert into Result(ExamDate,Mid,studentId,SubjectId,SemesterId,EmployeeId,ExamStatusId,DepartmentId,SessionId) VALUES (@examdate,@mid,@studentid,@subjectid,@semesterid,@employeeid,@examstatusid, @departmentid,@sessionid)";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        // Add Parameters to Command Parameters collection
                        cmd.Parameters.Add(new SqlParameter("@examdate", System.Data.SqlDbType.NVarChar, 50, "ExamDate"));
                        cmd.Parameters.Add(new SqlParameter("@mid", System.Data.SqlDbType.Int, 10, "Mid"));
                        cmd.Parameters.Add(new SqlParameter("@studentid", System.Data.SqlDbType.Int, 50, "StudentId"));
                        cmd.Parameters.Add(new SqlParameter("@subjectid", System.Data.SqlDbType.Int, 10, "SubjectId"));
                        cmd.Parameters.Add(new SqlParameter("@semesterid", System.Data.SqlDbType.Int, 50, "SemesterId"));
                        cmd.Parameters.Add(new SqlParameter("@employeeid", System.Data.SqlDbType.Int, 50, "EmployeeId"));
                        cmd.Parameters.Add(new SqlParameter("@examstatusid", System.Data.SqlDbType.Int, 50, "ExamStatusId"));
                        cmd.Parameters.Add(new SqlParameter("@departmentid", System.Data.SqlDbType.Int, 10, "DepartmentId"));
                        cmd.Parameters.Add(new SqlParameter("@sessionid", System.Data.SqlDbType.Int, 10, "SessionId"));
                        cmd.Parameters["@examdate"].Value = dtpExamDate.Text;
                        cmd.Parameters["@mid"].Value = Convert.ToInt32(Mid.Text.Trim());
                        cmd.Parameters["@studentid"].Value = Convert.ToInt32(StudentId.Text.Trim());
                        cmd.Parameters["@subjectid"].Value = Convert.ToInt32(lblSubjectId.Text.Trim());
                        cmd.Parameters["@semesterid"].Value = Convert.ToInt32(lblSemesterId.Text.Trim());
                        cmd.Parameters["@employeeid"].Value = Convert.ToInt32(lblEmployeeId.Text.Trim());
                        cmd.Parameters["@examstatusid"].Value = Convert.ToInt32(ExamStatusId.Text.Trim());
                        cmd.Parameters["@departmentid"].Value = Convert.ToInt32(lblDepartmentid.Text.Trim());
                        cmd.Parameters["@sessionid"].Value = Convert.ToInt32(lblSessionId.Text.Trim());
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Successfully saved", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        #endregion
                    }

                    // Final Term
                    #region Final Term
                    else if (FinalTerm.Checked == true)
                    {

                        if (rdbWithoutLab.Checked)
                        {
                            #region Without lab 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cb = "Update Result Set ExamDate = @examdate,Presentation=@presentation,Assignment=@assignment,Quizz=@quizz,Lab = @lab ,Final=@final ,Grade=@grade,TotalObtainedMarks=@totalobtainedmarks,Value=@value,GP=@gp,StudentStatusId=@studentstatusid , EmployeeId = @employeeid    where   studentId=@studentid and SubjectId=@subjectid and SemesterId = @semesterid  and ExamStatusId = @examstatusid  and DepartmentId = @departmentid and SessionId=@sessionid";
                            cmd = new SqlCommand(cb);
                            cmd.Connection = con;
                            // Add Parameters to Command Parameters collection
                            cmd.Parameters.Add(new SqlParameter("@examdate", System.Data.SqlDbType.NVarChar, 50, "ExamDate"));
                            cmd.Parameters.Add(new SqlParameter("@presentation", System.Data.SqlDbType.Int, 15, "Presentation"));
                            cmd.Parameters.Add(new SqlParameter("@assignment", System.Data.SqlDbType.Int, 10, "Assignment"));
                            cmd.Parameters.Add(new SqlParameter("@quizz", System.Data.SqlDbType.Int, 10, "Quizz"));
                            cmd.Parameters.Add(new SqlParameter("@lab", System.Data.SqlDbType.Int, 10, "Lab"));
                            cmd.Parameters.Add(new SqlParameter("@final", System.Data.SqlDbType.Int, 10, "Final"));
                            cmd.Parameters.Add(new SqlParameter("@grade", System.Data.SqlDbType.NVarChar, 50, "Grade"));
                            cmd.Parameters.Add(new SqlParameter("@totalobtainedmarks", System.Data.SqlDbType.Int, 10, "TotalObtainedMarks"));
                            cmd.Parameters.Add(new SqlParameter("@value", System.Data.SqlDbType.Float, 10, "Value"));
                            cmd.Parameters.Add(new SqlParameter("@gp", System.Data.SqlDbType.Float, 10, "GP"));
                            cmd.Parameters.Add(new SqlParameter("@studentid", System.Data.SqlDbType.Int, 50, "StudentId"));
                            cmd.Parameters.Add(new SqlParameter("@subjectid", System.Data.SqlDbType.Int, 10, "SubjectId"));
                            cmd.Parameters.Add(new SqlParameter("@semesterid", System.Data.SqlDbType.Int, 50, "SemesterId"));
                            cmd.Parameters.Add(new SqlParameter("@employeeid", System.Data.SqlDbType.Int, 50, "EmployeeId"));
                            cmd.Parameters.Add(new SqlParameter("@examstatusid", System.Data.SqlDbType.Int, 50, "ExamStatusId"));
                            cmd.Parameters.Add(new SqlParameter("@studentstatusid", System.Data.SqlDbType.Int, 10, "StudentStatusId"));
                            cmd.Parameters.Add(new SqlParameter("@departmentid", System.Data.SqlDbType.Int, 10, "DepartmentId"));
                            cmd.Parameters.Add(new SqlParameter("@sessionid", System.Data.SqlDbType.Int, 10, "SessionId"));
                            cmd.Parameters["@examdate"].Value = dtpExamDate.Text;
                            cmd.Parameters["@presentation"].Value = Convert.ToInt32(Presentation.Text.Trim());
                            cmd.Parameters["@assignment"].Value = Convert.ToInt32(Assignment.Text.Trim());
                            cmd.Parameters["@quizz"].Value = Convert.ToInt32(Quizz.Text.Trim());
                            cmd.Parameters["@lab"].Value = 0;
                            cmd.Parameters["@final"].Value = Convert.ToInt32(Final.Text.Trim());
                            cmd.Parameters["@grade"].Value =txtGrade.Text.Trim();
                            cmd.Parameters["@totalobtainedmarks"].Value = Convert.ToInt32(TotalMarks.Text.Trim());
                            cmd.Parameters["@value"].Value = Convert.ToDouble(Value.Text.Trim());
                            cmd.Parameters["@gp"].Value = Convert.ToDouble(GP.Text.Trim());
                            cmd.Parameters["@studentid"].Value = Convert.ToDouble(StudentId.Text.Trim());
                            cmd.Parameters["@subjectid"].Value = Convert.ToInt32(lblSubjectId.Text.Trim());
                            cmd.Parameters["@semesterid"].Value = Convert.ToInt32(lblSemesterId.Text.Trim());
                            cmd.Parameters["@employeeid"].Value = Convert.ToInt32(lblEmployeeId.Text.Trim());
                            cmd.Parameters["@examstatusid"].Value = Convert.ToInt32(ExamStatusId.Text.Trim());
                            cmd.Parameters["@departmentid"].Value = Convert.ToInt32(lblDepartmentid.Text.Trim());
                            cmd.Parameters["@sessionid"].Value = Convert.ToInt32(lblSessionId.Text.Trim());
                            cmd.Parameters["@studentstatusid"].Value = Convert.ToDouble(Status.Text.Trim()); ;
                            cmd.ExecuteNonQuery();
                            
                            con.Close();
                            MessageBox.Show("Successfully Saved", "Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                            #endregion
                        }
                        else if (rdbWithLab.Checked)
                        {
                            #region with Lab
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cb = "Update Result Set ExamDate = @examdate,Presentation=@presentation,Assignment=@assignment,Quizz=@quizz,Lab = @lab ,Final=@final ,Grade=@grade,TotalObtainedMarks=@totalobtainedmarks,Value=@value,GP=@gp,StudentStatusId=@studentstatusid,EmployeeId = @employeeid     where   studentId=@studentid and SubjectId=@subjectid and SemesterId = @semesterid  and ExamStatusId = @examstatusid  and DepartmentId = @departmentid and SessionId=@sessionid";
                            cmd = new SqlCommand(cb);
                            cmd.Connection = con;
                            // Add Parameters to Command Parameters collection
                            cmd.Parameters.Add(new SqlParameter("@examdate", System.Data.SqlDbType.NVarChar, 50, "ExamDate"));
                            cmd.Parameters.Add(new SqlParameter("@presentation", System.Data.SqlDbType.Int, 15, "Presentation"));
                            cmd.Parameters.Add(new SqlParameter("@assignment", System.Data.SqlDbType.Int, 10, "Assignment"));
                            cmd.Parameters.Add(new SqlParameter("@quizz", System.Data.SqlDbType.Int, 10, "Quizz"));
                            cmd.Parameters.Add(new SqlParameter("@lab", System.Data.SqlDbType.Int, 10, "Lab"));
                            cmd.Parameters.Add(new SqlParameter("@final", System.Data.SqlDbType.Int, 10, "Final"));
                            cmd.Parameters.Add(new SqlParameter("@grade", System.Data.SqlDbType.NVarChar, 50, "Grade"));
                            cmd.Parameters.Add(new SqlParameter("@totalobtainedmarks", System.Data.SqlDbType.Int, 10, "TotalObtainedMarks"));
                            cmd.Parameters.Add(new SqlParameter("@value", System.Data.SqlDbType.Float, 10, "Value"));
                            cmd.Parameters.Add(new SqlParameter("@gp", System.Data.SqlDbType.Float, 10, "GP"));
                            cmd.Parameters.Add(new SqlParameter("@studentid", System.Data.SqlDbType.Int, 50, "StudentId"));
                            cmd.Parameters.Add(new SqlParameter("@subjectid", System.Data.SqlDbType.Int, 10, "SubjectId"));
                            cmd.Parameters.Add(new SqlParameter("@semesterid", System.Data.SqlDbType.Int, 50, "SemesterId"));
                            cmd.Parameters.Add(new SqlParameter("@employeeid", System.Data.SqlDbType.Int, 50, "EmployeeId"));
                            cmd.Parameters.Add(new SqlParameter("@examstatusid", System.Data.SqlDbType.Int, 50, "ExamStatusId"));
                            cmd.Parameters.Add(new SqlParameter("@studentstatusid", System.Data.SqlDbType.Int, 10, "StudentStatusId"));
                            cmd.Parameters.Add(new SqlParameter("@departmentid", System.Data.SqlDbType.Int, 10, "DepartmentId"));
                            cmd.Parameters.Add(new SqlParameter("@sessionid", System.Data.SqlDbType.Int, 10, "SessionId"));
                            cmd.Parameters["@examdate"].Value = dtpExamDate.Text;
                            cmd.Parameters["@presentation"].Value = Convert.ToInt32(Presentation.Text.Trim());
                            cmd.Parameters["@assignment"].Value = Convert.ToInt32(Assignment.Text.Trim());
                            cmd.Parameters["@quizz"].Value = Convert.ToInt32(Quizz.Text.Trim());
                            cmd.Parameters["@lab"].Value = Convert.ToInt32(txtLab.Text.Trim());
                            cmd.Parameters["@final"].Value = Convert.ToInt32(Final.Text.Trim());
                            cmd.Parameters["@grade"].Value = txtGrade.Text.Trim();
                            cmd.Parameters["@totalobtainedmarks"].Value = Convert.ToInt32(TotalMarks.Text.Trim());
                            cmd.Parameters["@value"].Value = Convert.ToDouble(Value.Text.Trim());
                            cmd.Parameters["@gp"].Value = Convert.ToDouble(GP.Text.Trim());
                            cmd.Parameters["@studentid"].Value = Convert.ToDouble(StudentId.Text.Trim());
                            cmd.Parameters["@subjectid"].Value = Convert.ToInt32(lblSubjectId.Text.Trim());
                            cmd.Parameters["@semesterid"].Value = Convert.ToInt32(lblSemesterId.Text.Trim());
                            cmd.Parameters["@employeeid"].Value = Convert.ToInt32(lblEmployeeId.Text.Trim());
                            cmd.Parameters["@examstatusid"].Value = Convert.ToInt32(ExamStatusId.Text.Trim());
                            cmd.Parameters["@departmentid"].Value = Convert.ToInt32(lblDepartmentid.Text.Trim());
                            cmd.Parameters["@sessionid"].Value = Convert.ToInt32(lblSessionId.Text.Trim());
                            cmd.Parameters["@studentstatusid"].Value = Convert.ToDouble(Status.Text.Trim()); ;
                            cmd.ExecuteNonQuery();
                          
                            con.Close();
                            MessageBox.Show("Successfully Saved", "Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                            #endregion
                        }


                    }
                    #endregion
                }
                #endregion
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update_record_Click(object sender, EventArgs e)
        {
            try
            {
                #region vaidation
                if (ClassName.Text == "")
                {
                    MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClassName.Focus();
                    return;
                }
                if (FacultyName.Text == "")
                {
                    MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FacultyName.Focus();
                    return;
                }
                if (Session.Text == "")
                {
                    MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Session.Focus();
                    return;
                }
                if (cmbExamStatus.Text == "")
                {
                    MessageBox.Show("Please select Exam Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbExamStatus.Focus();
                    return;
                }
                if (FinalTerm.Checked == false && MidTerm.Checked == false)
                {
                    MessageBox.Show("Please Select Exam Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MidTerm.Focus();
                    return;
                }
                if (cmbSemester.Text == "")
                {
                    MessageBox.Show("Please select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSemester.Focus();
                    return;
                }
                if (txtSubjectName.Text == "")
                {
                    MessageBox.Show("Please select Subject Name ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubjectName.Focus();
                    return;
                }
                if (rdbWithLab.Checked == false && rdbWithoutLab.Checked == false)
                {
                    MessageBox.Show("Please Select with Lab Or Without Lab", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdbWithoutLab.Focus();
                    return;
                }
                if (EmployeeName.Text == "")
                {
                    MessageBox.Show("Please select Teacher", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EmployeeName.Focus();
                    return;
                }
                if (cmbExamStatus.Text == "Repeat" || cmbExamStatus.Text == "Makeup" || cmbExamStatus.Text == "SCE")
                {

                    if (cmbClassNo.Text == "")
                    {
                        MessageBox.Show("Please select Class No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbClassNo.Focus();
                        return;
                    }
                    //Mid Term 
                    if (MidTerm.Checked == true)
                    {
                        //without Lab 
                        #region Without Lab
                        if (rdbWithoutLab.Checked)
                        {
                            if (Mid.Text == "")
                            {
                                MessageBox.Show("Please Enter Mid Marks ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Mid.Focus();
                                return;
                            }
                        }
                        #endregion
                        //With Lab
                        #region With Lab 
                        if (rdbWithLab.Checked)
                        {
                            if (Mid.Text == "")
                            {
                                MessageBox.Show("Please Enter Mid Marks ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Mid.Focus();
                                return;
                            }
                        }
                        #endregion
                    }
                    //Final Term
                    if (FinalTerm.Checked == true)
                    {
                        //without Lab 
                        #region Without Lab
                        if (rdbWithoutLab.Checked)
                        {
                            if (Mid.Text == "")
                            {
                                MessageBox.Show("Please Enter Mid Marks ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Mid.Focus();
                                return;
                            }
                            if (Final.Text == "")
                            {
                                MessageBox.Show("Please Enter Final Marks", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Final.Focus();
                                return;
                            }
                            if (Assignment.Text == "")
                            {
                                MessageBox.Show("Please Enter Assignment ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Assignment.Focus();
                                return;
                            }
                            if (Presentation.Text == "")
                            {
                                MessageBox.Show("Please Enter Presentation Marks ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Presentation.Focus();
                                return;
                            }
                            if (Quizz.Text == "")
                            {
                                MessageBox.Show("Please Enter Quiz Marks ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Quizz.Focus();
                                return;
                            }
                        }
                        #endregion
                        //With Lab
                        #region With Lab 
                        if (rdbWithLab.Checked)
                        {
                            if (Mid.Text == "")
                            {
                                MessageBox.Show("Please Enter Mid Marks ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Mid.Focus();
                                return;
                            }
                            if (Final.Text == "")
                            {
                                MessageBox.Show("Please Enter Final Marks", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Final.Focus();
                                return;
                            }
                            if (Assignment.Text == "")
                            {
                                MessageBox.Show("Please Enter Assignment ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Assignment.Focus();
                                return;
                            }
                            if (Presentation.Text == "")
                            {
                                MessageBox.Show("Please Enter Presentation Marks ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Presentation.Focus();
                                return;
                            }
                            if (Quizz.Text == "")
                            {
                                MessageBox.Show("Please Enter Quiz Marks ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Quizz.Focus();
                                return;
                            }
                            if (txtLab.Text == "")
                            {
                                MessageBox.Show("Please Enter Lab Marks ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtLab.Focus();
                                return;
                            }
                        }
                        #endregion
                    }//end if 

                }
                #endregion
                // Fresh Exams 
                #region Fresh Eams
                if (cmbExamStatus.Text == "Fresh")
                {
                    // Mid Term                   
                    if (MidTerm.Checked == true)
                    {
                        #region Mid Term
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "Update  Result Set ExamDate=@examdate,Mid=@mid,EmployeeId=@employeeid where studentId=@studentid  AND SubjectId=@subjectid AND SemesterId=semesterid AND ExamStatusId=@examstatusid AND DepartmentId=@departmentid AND SessionId=@sessionid";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        // Add Parameters to Command Parameters collection
                        cmd.Parameters.Add(new SqlParameter("@examdate", System.Data.SqlDbType.NVarChar, 50, "ExamDate"));
                        cmd.Parameters.Add(new SqlParameter("@mid", System.Data.SqlDbType.Int, 10, "Mid"));
                        cmd.Parameters.Add(new SqlParameter("@studentid", System.Data.SqlDbType.Int, 50, "StudentId"));
                        cmd.Parameters.Add(new SqlParameter("@subjectid", System.Data.SqlDbType.Int, 10, "SubjectId"));
                        cmd.Parameters.Add(new SqlParameter("@semesterid", System.Data.SqlDbType.Int, 50, "SemesterId"));
                        cmd.Parameters.Add(new SqlParameter("@employeeid", System.Data.SqlDbType.Int, 50, "EmployeeId"));
                        cmd.Parameters.Add(new SqlParameter("@examstatusid", System.Data.SqlDbType.Int, 50, "ExamStatusId"));
                        cmd.Parameters.Add(new SqlParameter("@departmentid", System.Data.SqlDbType.Int, 10, "DepartmentId"));
                        cmd.Parameters.Add(new SqlParameter("@sessionid", System.Data.SqlDbType.Int, 10, "SessionId"));
                        // Prepare command for repeated execution
                        cmd.Prepare();
                        // Data to be inserted
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                cmd.Parameters["@examdate"].Value = dtpExamDate.Text;
                                cmd.Parameters["@mid"].Value = row.Cells[3].Value;
                                cmd.Parameters["@studentid"].Value = row.Cells[0].Value;
                                cmd.Parameters["@subjectid"].Value = Convert.ToInt32(lblSubjectId.Text.Trim());
                                cmd.Parameters["@semesterid"].Value = Convert.ToInt32(lblSemesterId.Text.Trim());
                                cmd.Parameters["@employeeid"].Value = Convert.ToInt32(lblEmployeeId.Text.Trim());
                                cmd.Parameters["@examstatusid"].Value = Convert.ToInt32(ExamStatusId.Text.Trim());
                                cmd.Parameters["@departmentid"].Value = Convert.ToInt32(lblDepartmentid.Text.Trim());
                                cmd.Parameters["@sessionid"].Value = Convert.ToInt32(lblSessionId.Text.Trim());
                                cmd.ExecuteNonQuery();
                            }
                        }
                       
                        con.Close();
                        MessageBox.Show("Successfully Updated", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                        #endregion                        
                    }
                  
                    // Final Term
                    if (FinalTerm.Checked == true)
                    {
                        #region Final Fresh
                        // Fresh Exam Final 
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "Update Result Set ExamDate = @examdate,Presentation=@presentation,Assignment=@assignment,Quizz=@quizz,Lab=@lab,Final=@final,TotalObtainedMarks=@totalobtainedmarks,Value=@value,GP=@gp ,Grade = @grade,StudentStatusId=@studentstatusid ,EmployeeId = @employeeid    where   studentId=@studentid and SubjectId=@subjectid and SemesterId = @semesterid  and ExamStatusId = @examstatusid  and DepartmentId = @departmentid and SessionId=@sessionid";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        // Add Parameters to Command Parameters collection
                        cmd.Parameters.Add(new SqlParameter("@examdate", System.Data.SqlDbType.NVarChar, 50, "ExamDate"));
                        cmd.Parameters.Add(new SqlParameter("@presentation", System.Data.SqlDbType.Int, 15, "Presentation"));
                        cmd.Parameters.Add(new SqlParameter("@assignment", System.Data.SqlDbType.Int, 10, "Assignment"));
                        cmd.Parameters.Add(new SqlParameter("@quizz", System.Data.SqlDbType.Int, 10, "Quizz"));
                        cmd.Parameters.Add(new SqlParameter("@lab", System.Data.SqlDbType.Int, 10, "Lab"));
                        cmd.Parameters.Add(new SqlParameter("@final", System.Data.SqlDbType.Int, 10, "Final"));
                        cmd.Parameters.Add(new SqlParameter("@totalobtainedmarks", System.Data.SqlDbType.Int, 10, "TotalObtainedMarks"));
                        cmd.Parameters.Add(new SqlParameter("@value", System.Data.SqlDbType.Float, 10, "Value"));
                        cmd.Parameters.Add(new SqlParameter("@gp", System.Data.SqlDbType.Float, 10, "GP"));
                        cmd.Parameters.Add(new SqlParameter("@grade", System.Data.SqlDbType.NVarChar, 50, "Grade"));
                        cmd.Parameters.Add(new SqlParameter("@studentid", System.Data.SqlDbType.Int, 50, "StudentId"));
                        cmd.Parameters.Add(new SqlParameter("@subjectid", System.Data.SqlDbType.Int, 10, "SubjectId"));
                        cmd.Parameters.Add(new SqlParameter("@semesterid", System.Data.SqlDbType.Int, 50, "SemesterId"));
                        cmd.Parameters.Add(new SqlParameter("@employeeid", System.Data.SqlDbType.Int, 50, "EmployeeId"));
                        cmd.Parameters.Add(new SqlParameter("@examstatusid", System.Data.SqlDbType.Int, 50, "ExamStatusId"));
                        cmd.Parameters.Add(new SqlParameter("@studentstatusid", System.Data.SqlDbType.Int, 10, "StudentStatusId"));
                        cmd.Parameters.Add(new SqlParameter("@departmentid", System.Data.SqlDbType.Int, 10, "DepartmentId"));
                        cmd.Parameters.Add(new SqlParameter("@sessionid", System.Data.SqlDbType.Int, 10, "SessionId"));
                        // Data to be inserted
                        cmd.Prepare();
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                cmd.Parameters["@examdate"].Value = dtpExamDate.Text;
                                cmd.Parameters["@studentid"].Value = row.Cells[0].Value;
                                cmd.Parameters["@final"].Value = row.Cells[4].Value;
                                cmd.Parameters["@assignment"].Value = row.Cells[5].Value;
                                cmd.Parameters["@presentation"].Value = row.Cells[6].Value;
                                cmd.Parameters["@quizz"].Value = row.Cells[7].Value;
                                cmd.Parameters["@lab"].Value = row.Cells[8].Value;
                                cmd.Parameters["@totalobtainedmarks"].Value = row.Cells[9].Value;
                                cmd.Parameters["@value"].Value = row.Cells[10].Value;
                                cmd.Parameters["@gp"].Value = row.Cells[11].Value;
                                cmd.Parameters["@grade"].Value = row.Cells[13].Value;
                                cmd.Parameters["@studentstatusid"].Value = row.Cells[12].Value;
                                cmd.Parameters["@subjectid"].Value = Convert.ToInt32(lblSubjectId.Text.Trim());
                                cmd.Parameters["@semesterid"].Value = Convert.ToInt32(lblSemesterId.Text.Trim());
                                cmd.Parameters["@employeeid"].Value = Convert.ToInt32(lblEmployeeId.Text.Trim());
                                cmd.Parameters["@examstatusid"].Value = Convert.ToInt32(ExamStatusId.Text.Trim());
                                cmd.Parameters["@departmentid"].Value = Convert.ToInt32(lblDepartmentid.Text.Trim());
                                cmd.Parameters["@sessionid"].Value = Convert.ToInt32(lblSessionId.Text.Trim());
                                cmd.ExecuteNonQuery();
                            }
                        }

                        con.Close();
                        MessageBox.Show("Successfully Saved", "Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                        #endregion
                    }
                    #endregion
                }

                // Special Exams 
                #region Special Exams
                else if (cmbExamStatus.Text == "Repeat" || cmbExamStatus.Text == "Makeup" || cmbExamStatus.Text == "SCE")
                {

                    // Mid Term 
                    if (MidTerm.Checked == true)
                    {
                        #region Mid Term
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "Update  Result Set ExamDate=@examdate,Mid=@mid,EmployeeId=@employeeid where studentId=@studentid  AND SubjectId=@subjectid AND SemesterId=semesterid AND ExamStatusId=@examstatusid AND DepartmentId=@departmentid AND SessionId=@sessionid";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        // Add Parameters to Command Parameters collection
                        cmd.Parameters.Add(new SqlParameter("@examdate", System.Data.SqlDbType.NVarChar, 50, "ExamDate"));
                        cmd.Parameters.Add(new SqlParameter("@mid", System.Data.SqlDbType.Int, 10, "Mid"));
                        cmd.Parameters.Add(new SqlParameter("@studentid", System.Data.SqlDbType.Int, 50, "StudentId"));
                        cmd.Parameters.Add(new SqlParameter("@subjectid", System.Data.SqlDbType.Int, 10, "SubjectId"));
                        cmd.Parameters.Add(new SqlParameter("@semesterid", System.Data.SqlDbType.Int, 50, "SemesterId"));
                        cmd.Parameters.Add(new SqlParameter("@employeeid", System.Data.SqlDbType.Int, 50, "EmployeeId"));
                        cmd.Parameters.Add(new SqlParameter("@examstatusid", System.Data.SqlDbType.Int, 50, "ExamStatusId"));
                        cmd.Parameters.Add(new SqlParameter("@departmentid", System.Data.SqlDbType.Int, 10, "DepartmentId"));
                        cmd.Parameters.Add(new SqlParameter("@sessionid", System.Data.SqlDbType.Int, 10, "SessionId"));


                        cmd.Parameters["@examdate"].Value = dtpExamDate.Text;
                        cmd.Parameters["@mid"].Value = Convert.ToInt32(Mid.Text.Trim());
                        cmd.Parameters["@studentid"].Value = Convert.ToInt32(StudentId.Text.Trim());
                        cmd.Parameters["@subjectid"].Value = Convert.ToInt32(lblSubjectId.Text.Trim());
                        cmd.Parameters["@semesterid"].Value = Convert.ToInt32(lblSemesterId.Text.Trim());
                        cmd.Parameters["@employeeid"].Value = Convert.ToInt32(lblEmployeeId.Text.Trim());
                        cmd.Parameters["@examstatusid"].Value = Convert.ToInt32(ExamStatusId.Text.Trim());
                        cmd.Parameters["@departmentid"].Value = Convert.ToInt32(lblDepartmentid.Text.Trim());
                        cmd.Parameters["@sessionid"].Value = Convert.ToInt32(lblSessionId.Text.Trim());
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Successfully Updated", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        #endregion
                    }

                    // Final Term
                    #region Final Term
                    else if (FinalTerm.Checked == true)
                    {

                        if (rdbWithoutLab.Checked)
                        {
                            #region Without lab 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cb = "Update Result Set ExamDate = @examdate,Presentation=@presentation,Assignment=@assignment,Quizz=@quizz,Lab = @lab ,Final=@final , Grade = @grade,TotalObtainedMarks=@totalobtainedmarks,Value=@value,GP=@gp,StudentStatusId=@studentstatusid,EmployeeId = @employeeid      where   studentId=@studentid and SubjectId=@subjectid and SemesterId = @semesterid and ExamStatusId = @examstatusid  and DepartmentId = @departmentid and SessionId=@sessionid";
                            cmd = new SqlCommand(cb);
                            cmd.Connection = con;
                            // Add Parameters to Command Parameters collection
                            cmd.Parameters.Add(new SqlParameter("@examdate", System.Data.SqlDbType.NVarChar, 50, "ExamDate"));
                            cmd.Parameters.Add(new SqlParameter("@presentation", System.Data.SqlDbType.Int, 15, "Presentation"));
                            cmd.Parameters.Add(new SqlParameter("@assignment", System.Data.SqlDbType.Int, 10, "Assignment"));
                            cmd.Parameters.Add(new SqlParameter("@quizz", System.Data.SqlDbType.Int, 10, "Quizz"));
                            cmd.Parameters.Add(new SqlParameter("@lab", System.Data.SqlDbType.Int, 10, "Lab"));
                            cmd.Parameters.Add(new SqlParameter("@final", System.Data.SqlDbType.Int, 10, "Final"));
                            cmd.Parameters.Add(new SqlParameter("@grade", System.Data.SqlDbType.NVarChar, 50, "Grade"));
                            cmd.Parameters.Add(new SqlParameter("@totalobtainedmarks", System.Data.SqlDbType.Int, 10, "TotalObtainedMarks"));
                            cmd.Parameters.Add(new SqlParameter("@value", System.Data.SqlDbType.Float, 10, "Value"));
                            cmd.Parameters.Add(new SqlParameter("@gp", System.Data.SqlDbType.Float, 10, "GP"));
                            cmd.Parameters.Add(new SqlParameter("@studentid", System.Data.SqlDbType.Int, 50, "StudentId"));
                            cmd.Parameters.Add(new SqlParameter("@subjectid", System.Data.SqlDbType.Int, 10, "SubjectId"));
                            cmd.Parameters.Add(new SqlParameter("@semesterid", System.Data.SqlDbType.Int, 50, "SemesterId"));
                            cmd.Parameters.Add(new SqlParameter("@employeeid", System.Data.SqlDbType.Int, 50, "EmployeeId"));
                            cmd.Parameters.Add(new SqlParameter("@examstatusid", System.Data.SqlDbType.Int, 50, "ExamStatusId"));
                            cmd.Parameters.Add(new SqlParameter("@studentstatusid", System.Data.SqlDbType.Int, 10, "StudentStatusId"));
                            cmd.Parameters.Add(new SqlParameter("@departmentid", System.Data.SqlDbType.Int, 10, "DepartmentId"));
                            cmd.Parameters.Add(new SqlParameter("@sessionid", System.Data.SqlDbType.Int, 10, "SessionId"));
                            cmd.Parameters["@examdate"].Value = dtpExamDate.Text;
                            cmd.Parameters["@presentation"].Value = Convert.ToInt32(Presentation.Text.Trim());
                            cmd.Parameters["@assignment"].Value = Convert.ToInt32(Assignment.Text.Trim());
                            cmd.Parameters["@quizz"].Value = Convert.ToInt32(Quizz.Text.Trim());
                            cmd.Parameters["@lab"].Value = 0;
                            cmd.Parameters["@final"].Value = Convert.ToInt32(Final.Text.Trim());
                            cmd.Parameters["@grade"].Value = txtGrade.Text.Trim();
                            cmd.Parameters["@totalobtainedmarks"].Value = Convert.ToInt32(TotalMarks.Text.Trim());
                            cmd.Parameters["@value"].Value = Convert.ToDouble(Value.Text.Trim());
                            cmd.Parameters["@gp"].Value = Convert.ToDouble(GP.Text.Trim());
                            cmd.Parameters["@studentid"].Value = Convert.ToDouble(StudentId.Text.Trim());
                            cmd.Parameters["@subjectid"].Value = Convert.ToInt32(lblSubjectId.Text.Trim());
                            cmd.Parameters["@semesterid"].Value = Convert.ToInt32(lblSemesterId.Text.Trim());
                            cmd.Parameters["@employeeid"].Value = Convert.ToInt32(lblEmployeeId.Text.Trim());
                            cmd.Parameters["@examstatusid"].Value = Convert.ToInt32(ExamStatusId.Text.Trim());
                            cmd.Parameters["@departmentid"].Value = Convert.ToInt32(lblDepartmentid.Text.Trim());
                            cmd.Parameters["@sessionid"].Value = Convert.ToInt32(lblSessionId.Text.Trim());
                            cmd.Parameters["@studentstatusid"].Value = Convert.ToDouble(Status.Text.Trim()); ;
                            cmd.ExecuteNonQuery();

                            con.Close();
                            MessageBox.Show("Successfully Updated", "Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                            #endregion
                        }
                        else if (rdbWithLab.Checked)
                        {
                            #region with Lab
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cb = "Update Result Set ExamDate = @examdate,Presentation=@presentation,Assignment=@assignment,Quizz=@quizz,Lab = @lab ,Final=@final ,Grade = @grade,TotalObtainedMarks=@totalobtainedmarks,Value=@value,GP=@gp,StudentStatusId=@studentstatusid , EmployeeId = @employeeid    where   studentId=@studentid and SubjectId=@subjectid and SemesterId = @semesterid  and ExamStatusId = @examstatusid  and DepartmentId = @departmentid and SessionId=@sessionid";
                            cmd = new SqlCommand(cb);
                            cmd.Connection = con;
                            // Add Parameters to Command Parameters collection
                            cmd.Parameters.Add(new SqlParameter("@examdate", System.Data.SqlDbType.NVarChar, 50, "ExamDate"));
                            cmd.Parameters.Add(new SqlParameter("@presentation", System.Data.SqlDbType.Int, 15, "Presentation"));
                            cmd.Parameters.Add(new SqlParameter("@assignment", System.Data.SqlDbType.Int, 10, "Assignment"));
                            cmd.Parameters.Add(new SqlParameter("@quizz", System.Data.SqlDbType.Int, 10, "Quizz"));
                            cmd.Parameters.Add(new SqlParameter("@lab", System.Data.SqlDbType.Int, 10, "Lab"));
                            cmd.Parameters.Add(new SqlParameter("@final", System.Data.SqlDbType.Int, 10, "Final"));
                            cmd.Parameters.Add(new SqlParameter("@grade", System.Data.SqlDbType.NVarChar, 50, "Grade"));
                            cmd.Parameters.Add(new SqlParameter("@totalobtainedmarks", System.Data.SqlDbType.Int, 10, "TotalObtainedMarks"));
                            cmd.Parameters.Add(new SqlParameter("@value", System.Data.SqlDbType.Float, 10, "Value"));
                            cmd.Parameters.Add(new SqlParameter("@gp", System.Data.SqlDbType.Float, 10, "GP"));
                            cmd.Parameters.Add(new SqlParameter("@studentid", System.Data.SqlDbType.Int, 50, "StudentId"));
                            cmd.Parameters.Add(new SqlParameter("@subjectid", System.Data.SqlDbType.Int, 10, "SubjectId"));
                            cmd.Parameters.Add(new SqlParameter("@semesterid", System.Data.SqlDbType.Int, 50, "SemesterId"));
                            cmd.Parameters.Add(new SqlParameter("@employeeid", System.Data.SqlDbType.Int, 50, "EmployeeId"));
                            cmd.Parameters.Add(new SqlParameter("@examstatusid", System.Data.SqlDbType.Int, 50, "ExamStatusId"));
                            cmd.Parameters.Add(new SqlParameter("@studentstatusid", System.Data.SqlDbType.Int, 10, "StudentStatusId"));
                            cmd.Parameters.Add(new SqlParameter("@departmentid", System.Data.SqlDbType.Int, 10, "DepartmentId"));
                            cmd.Parameters.Add(new SqlParameter("@sessionid", System.Data.SqlDbType.Int, 10, "SessionId"));
                            cmd.Parameters["@examdate"].Value = dtpExamDate.Text;
                            cmd.Parameters["@presentation"].Value = Convert.ToInt32(Presentation.Text.Trim());
                            cmd.Parameters["@assignment"].Value = Convert.ToInt32(Assignment.Text.Trim());
                            cmd.Parameters["@quizz"].Value = Convert.ToInt32(Quizz.Text.Trim());
                            cmd.Parameters["@lab"].Value = Convert.ToInt32(txtLab.Text.Trim());
                            cmd.Parameters["@final"].Value = Convert.ToInt32(Final.Text.Trim());
                            cmd.Parameters["@grade"].Value = txtGrade.Text.Trim();
                            cmd.Parameters["@totalobtainedmarks"].Value = Convert.ToInt32(TotalMarks.Text.Trim());
                            cmd.Parameters["@value"].Value = Convert.ToDouble(Value.Text.Trim());
                            cmd.Parameters["@gp"].Value = Convert.ToDouble(GP.Text.Trim());
                            cmd.Parameters["@studentid"].Value = Convert.ToDouble(StudentId.Text.Trim());
                            cmd.Parameters["@subjectid"].Value = Convert.ToInt32(lblSubjectId.Text.Trim());
                            cmd.Parameters["@semesterid"].Value = Convert.ToInt32(lblSemesterId.Text.Trim());
                            cmd.Parameters["@employeeid"].Value = Convert.ToInt32(lblEmployeeId.Text.Trim());
                            cmd.Parameters["@examstatusid"].Value = Convert.ToInt32(ExamStatusId.Text.Trim());
                            cmd.Parameters["@departmentid"].Value = Convert.ToInt32(lblDepartmentid.Text.Trim());
                            cmd.Parameters["@sessionid"].Value = Convert.ToInt32(lblSessionId.Text.Trim());
                            cmd.Parameters["@studentstatusid"].Value = Convert.ToDouble(Status.Text.Trim()); ;
                            cmd.ExecuteNonQuery();

                            con.Close();
                            MessageBox.Show("Successfully Updated", "Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                            #endregion
                        }


                    }
                    #endregion
                }
                #endregion
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmInternalMarksEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (label5.Text == "Admin")
                {
                    Record.Enabled = true;
                }
                else
                {
                    Record.Enabled = false;
                }
                //if (StudentName.Text == "")
                //{
                //    MessageBox.Show("Please select session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    StudentName.Focus();
                //    return;
                //}
                //if (cmbRollNo.Text == "")
                //{
                //    MessageBox.Show("Please select course", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    cmbRollNo.Focus();
                //    return;
                //}
                if (ClassName.Text == "")
                {
                    MessageBox.Show("Please select branch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClassName.Focus();
                    return;
                }
                if (FacultyName.Text == "")
                {
                    MessageBox.Show("Please select semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FacultyName.Focus();
                    return;
                }

                if (EmployeeName.Text == "")
                {
                    MessageBox.Show("Please select section", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EmployeeName.Focus();
                    return;
                }
                if (txtSubjectName.Text == "")
                {
                    MessageBox.Show("Please select subject code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubjectName.Focus();
                    return;
                }
                //if (cmbExamName.Text == "")
                //{
                //    MessageBox.Show("Please select exam name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    cmbExamName.Focus();
                //    return;
                //}
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string sql = "select RTrim(Student.ScholarNo)[ScholarNo],Rtrim(Enrollment_no)[Enrollment No.], RTRIM(Student_Name)[Student Name], RTRIM(MarksObtained)[Marks Obtained],examdate,MaxMarks,MinMarks from Student,InternalMarksEntry where Student.ScholarNo=InternalMarksEntry.Scholarno and InternalMarksEntry.Course= '" + /*cmbRollNo.Text +*/ "'and InternalMarksEntry.branch='" + ClassName.Text + "'and InternalMarksEntry.Session='" +/* StudentName.Text + */"' and InternalMarksEntry.Semester= '" + FacultyName.Text + "' and InternalMarksEntry.Section= '" + EmployeeName.Text + "' and SubjectCode='" + txtSubjectName.Text + "'and ExamName='"  + /*cmbExamName.Text + */"' order by Student.student_name";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //dataGridView1.Rows.Clear();
                //while (rdr.Read() == true)
                //{
                //    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2],rdr[3]);
                //    dtpExamDate.Text = (string)rdr["ExamDate"];
                //    Mid.Text = rdr.GetInt32(5).ToString();
                //    Presentation.Text = rdr.GetInt32(6).ToString();
                //}
                con.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (ClassName.Text == "")
            {
                MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClassName.Focus();
                return;
            }
            if (FacultyName.Text == "")
            {
                MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FacultyName.Focus();
                return;
            }
            if (Session.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Session.Focus();
                return;
            }
            if (cmbExamStatus.Text == "")
            {
                MessageBox.Show("Please select Exam Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbExamStatus.Focus();
                return;
            }
            if (cmbSemester.Text == "")
            {
                MessageBox.Show("Please select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSemester.Focus();
                return;
            }
            if (txtSubjectName.Text == "")
            {
                MessageBox.Show("Please select Subject Name ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSubjectName.Focus();
                return;
            }
            // Fresh Exams 
            #region Fresh Exams
            if (cmbExamStatus.Text == "Fresh")
            {
                if (lblStudentIdDlt.Text == " ")
                {
                    MessageBox.Show("Please select any Row ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubjectName.Focus();
                    return;
                }
                if (MessageBox.Show("Do you really want to delete the records?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    delete_recordsFresh();
                    btnSave.Enabled = true;
                }
            }
            #endregion
            // Special Exams 
            #region Special Exams
            else if (cmbExamStatus.Text == "Repeat" || cmbExamStatus.Text == "Makeup" || cmbExamStatus.Text == "SCE")
            {
                if (cmbClassNo.Text == "")
                {
                    MessageBox.Show("Please select Class No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClassNo.Focus();
                    return;
                }
                if (MessageBox.Show("Do you really want to delete the records?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    delete_recordsSpecialExams();
                    ResetTextbox();
                }
            }
            #endregion
            else
            {
                MessageBox.Show("Select Exam Type","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }





        }
        private void delete_recordsFresh()
        {

            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "Delete From Result where StudentId  = '"+lblStudentIdDlt.Text.Trim()+ "' AND SubjectId = (Select Subjectid From Subject where SubjectName = '"+txtSubjectName.Text.Trim()+"') AND DepartmentId = (Select DepartmentId From Department where ClassName = '" + ClassName.Text.Trim()+"' And  FacultyName = '"+FacultyName.Text.Trim()+ "') AnD SessionId = (Select SessionId From Session where Description = '"+Session.Text.Trim()+ "') AND SemesterId = (Select SemesterId From Semester where Description = '"+cmbSemester.Text.Trim()+ "') AND ExamStatusId = (Select ExamStatusId From ExamStatus where Status = '"+cmbExamStatus.Text.Trim()+"')";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Delete.Enabled = false;
                    getData();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Delete.Enabled = false;
                    getData();

                }

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delete_recordsSpecialExams()
        {

            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "Delete From Result where StudentId  = '" + StudentId.Text.Trim() + "' AND SubjectId = (Select Subjectid From Subject where SubjectName = '" + txtSubjectName.Text.Trim() + "') AND DepartmentId = (Select DepartmentId From Department where ClassName = '" + ClassName.Text.Trim() + "' And  FacultyName = '" + FacultyName.Text.Trim() + "') AnD SessionId = (Select SessionId From Session where Description = '" + Session.Text.Trim() + "') AND SemesterId = (Select SemesterId From Semester where Description = '" + cmbSemester.Text.Trim() + "') AND ExamStatusId = (Select ExamStatusId From ExamStatus where Status = '" + cmbExamStatus.Text.Trim() + "')";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Delete.Enabled = false;
                    getData();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Delete.Enabled = false;
                    getData();

                }

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void ClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FacultyName.Items.Clear();
                FacultyName.Text = "";
                FacultyName.Enabled = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(FacultyName) from Department where ClassName = '" + ClassName.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    FacultyName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FacultyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session.Items.Clear();
                Session.Text = "";
                Session.Enabled = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Description) from Session where IsActive = 'true'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Session.Items.Add(rdr[0]);
                }
                con.Close();
                #region Get Department Id
                //Get Department Id
                lblDepartmentid.Text = "";
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select DepartmentId from Department where ClassName ='" + ClassName.Text + "' and FacultyName = '" + FacultyName.Text + "'";

                cmd = new SqlCommand(ct2);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    lblDepartmentid.Text = rdr.GetInt32(0).ToString();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Session_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbSemester.Items.Clear();
                cmbSemester.Text = "";
                cmbSemester.Enabled = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Description) from Semester ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbSemester.Items.Add(rdr[0]);
                }
                con.Close();
                #region Get Session Id
                //Get Session Id
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select SessionId from Session where Description ='" + Session.Text + "'";

                cmd = new SqlCommand(ct2);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    lblSessionId.Text = rdr.GetInt32(0).ToString();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRollNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();


                string ct = "select StudentName,FatherName from Student where ClassName = '" + ClassName.Text + "'and FacultyName='" + FacultyName.Text + "'and RollNo='" +/* cmbRollNo.Text +*/ "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //StudentName.Text = rdr.GetString(0).Trim();
                    //FatherName.Text = rdr.GetString(1).Trim();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Semester_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();


                string ct = "select Season from Semester where ClassName = '" + ClassName.Text + "'and FacultyName='" + FacultyName.Text + "'and Semester='" + /*Semester.Text +*/ "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Season.Text = rdr.GetString(0).Trim();

                }
                con.Close();

                // :Load Subjetcs In Semester
                txtSubjectName.Items.Clear();
                txtSubjectName.Text = "";
                txtSubjectName.Enabled = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();


                string ct3 = "select distinct RTRIM(SubjectName) from SubjectInformation where ClassName = '" + ClassName.Text + "'and FacultyName='" + FacultyName.Text + "'and Semester='" + /*Semester.Text +*/ "' ";

                cmd = new SqlCommand(ct3);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    txtSubjectName.Items.Add(rdr[0]);
                }
                con.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbExamName_SelectedIndexChanged(object sender, EventArgs e)
        {


            //if (cmbExamName.Text == "Mid Term")
            //{
            //    Mid.Enabled = true;
            //    Presentation.Enabled = false;
            //    Assignment.Enabled = false;
            //    Quizz.Enabled = false;
            //    Lab.Enabled = false;
            //    Final.Enabled = false;
            //    Total.Enabled = false;
            //    Value.Enabled = false;
            //    GP.Enabled = false;
            //    Grade.Enabled = false;
            //    Percentage.Enabled = false;
            //    Status.Enabled = false;
            //    Remarks.Enabled = false;
            //    Presentation.Text = "";
            //    Assignment.Text = "";
            //    Quizz.Text = "";
            //    Lab.Text = "";
            //    Final.Text = "";

            //    Value.Text = "";
            //    GP.Text = "";
            //    Grade.Text = "";
            //    Percentage.Text = "";
            //    Status.Text = "";
            //    Remarks.Text = "";
            //}
            //else if (cmbExamName.Text == "Final Term")
            //{
            //    Presentation.Text = "";
            //    Assignment.Text = "";
            //    Quizz.Text = "";
            //    Lab.Text = "";
            //    Final.Text = "";

            //    Value.Text = "";
            //    GP.Text = "";
            //    Percentage.Text = "";
            //    Mid.Enabled = true;
            //    Presentation.Enabled = true;
            //    Assignment.Enabled = true;
            //    Quizz.Enabled = true;
            //    Lab.Enabled = true;
            //    Final.Enabled = true;
            //    Remarks.Enabled = true;
            //}
            //else
            //{
            //    MessageBox.Show("Select Exam", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


            //try
            //{

            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();


            //    string ct = "select  ExamDate,mid,presentation,assignment,Quizz,Lab,Final,status,Remarks from Result where ClassName = '" + ClassName.Text + "' and  FacultyName = '" + FacultyName.Text + "'and  Session = '" + Session.Text + "'and  Semester = '" + /*Semester.Text +*/ "'and  RollNo = '" + cmbRollNo.Text + "'and  SubjectName = '" + txtSubjectName.Text + "'and  Exam = '" + cmbExamName.Text + "'";

            //    cmd = new SqlCommand(ct);
            //    cmd.Connection = con;

            //    rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {

            //        dtpExamDate.Text = rdr.GetString(0).Trim();
            //        Mid.Text = rdr.GetInt32(1).ToString();
            //        Presentation.Text = rdr.GetInt32(2).ToString();
            //        Assignment.Text = rdr.GetInt32(3).ToString();
            //        Quizz.Text = rdr.GetInt32(4).ToString();
            //        Lab.Text = rdr.GetInt32(5).ToString();
            //        Final.Text = rdr.GetInt32(6).ToString();
            //        Status.Text = rdr.GetString(7).Trim();
            //        Remarks.Text = rdr.GetString(8).Trim();

            //    }
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}








         
        }




        private void Assignment_TextChanged(object sender, EventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int val3 = 0;
            int val4 = 0;
            int val5 = 0;
            int val6 = 0;
            int val7 = 0;
            int.TryParse(Mid.Text, out val1);
            int.TryParse(Presentation.Text, out val2);
            int.TryParse(Assignment.Text, out val3);
            int.TryParse(Quizz.Text, out val4);
            int.TryParse(Final.Text, out val6);
            int.TryParse(txtLab.Text, out val7);
            int I = ((val1 + val2 + val3 + val4 + val5 + val6 + val7));
            TotalMarks.Text = I.ToString();



            if (Assignment.Text == "")
            {

            }
            else if (Assignment.Text != null)
            {
                if (Convert.ToInt32(Assignment.Text) > 5 || Convert.ToInt32(Assignment.Text) < 0)
                {
                    Assignment.Text = "5";
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {

            //cmbRollNo.Text = "";
            //StudentName.Text = "";
            //FatherName.Text = "";
            //txtSubjectName.Text = "";
            ////cmbSubjectCode.Text = "";
            //SubCH.Text = "";
            //AssignedTo.Text = "";
            //dtpExamDate.Text = System.DateTime.Today.ToString();

            //Mid.Text = "";
            //Presentation.Text = "";
            //Assignment.Text = "";
            //Quizz.Text = "";
            //Lab.Text = "";
            //Final.Text = "";

            //Value.Text = "";
            //GP.Text = "";
            //Grade.Text = "";
            //Percentage.Text = "";
            //Status.Text = "";
            //Remarks.Text = "";
            //btnSave.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //cmbRollNo.Text = "";
            //StudentName.Text = "";
            //FatherName.Text = "";
            //dtpExamDate.Text = System.DateTime.Today.ToString();

            //Mid.Text = "";
            //Presentation.Text = "";
            //Assignment.Text = "";
            //Quizz.Text = "";
            //Lab.Text = "";
            //Final.Text = "";

            //Value.Text = "";
            //GP.Text = "";
            //Grade.Text = "";
            //Percentage.Text = "";
            //Status.Text = "";
            //btnSave.Enabled = true;
            //Remarks.Text = "";
        }

        private void Status_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Status_TextChanged(object sender, EventArgs e)
        {
            //if (Status.Text == "Fail")
            //{
            //    Remarks.Text = "Not Repeated";
            //}
            //else if (Status.Text == "Pass")
            //{
            //    Remarks.Text = "Null";
            //}

        }

        private void Record_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSubjectResultRecord frm = new frmSubjectResultRecord();
            frm.label10.Text = label5.Text.Trim();
            frm.label11.Text = label6.Text.Trim();
            frm.Show();

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (FinalTerm.Checked == true)
            {
                Mid.Enabled = true;
                Mid.ReadOnly = true;
                Final.Enabled = true;
                Quizz.Enabled = true;
                Presentation.Enabled = true;
                Assignment.Enabled = true;
                if (rdbWithLab.Checked)
                {
                    txtLab.Enabled = true;
                }
                else
                {
                    txtLab.Enabled = false;

                }

            }

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }
        private void first_CheckedChanged(object sender, EventArgs e)
        {

        }
       
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Mid Term
            if (MidTerm.Checked == true)
            {
                #region WitoutLab
                if (rdbWithoutLab.Checked)

                {
                    if (dataGridView1.CurrentCell.ColumnIndex == 3)
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells[3].Value != null)
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), @"^[0-9]*?$"))
                            {

                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[3].Value = 30;
                            }
                        }

                    }
                }
                #endregion
                #region With Lab
                if (rdbWithLab.Checked)

                {
                    if (dataGridView1.CurrentCell.ColumnIndex == 3)
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells[3].Value != null)
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), @"^[0-9]*?$"))
                            {

                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[3].Value = 30;
                            }
                        }

                    }
                }
                #endregion
            }
            //Final Term
            else if (FinalTerm.Checked == true)
            {
                #region WitoutLab
                if (rdbWithoutLab.Checked)
                {
                    //mid
                    if (dataGridView1.CurrentCell.ColumnIndex == 3)
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells[3].Value != null)
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), @"^[0-9]*?$"))
                            {

                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[3].Value = 30;
                            }
                        }

                    }
                    //end Mid 
                    //Final
                    if (dataGridView1.CurrentCell.ColumnIndex == 4)
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells[4].Value != null)
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(), @"^[0-9]*?$"))
                            {

                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[4].Value = 50;
                            }
                        }

                    }
                    //end Final
                    //Assignment
                    if (dataGridView1.CurrentCell.ColumnIndex == 5)
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells[5].Value != null)
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(), @"^[0-9]*?$"))
                            {

                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[5].Value = 5;
                            }
                        }

                    }
                    //end Assignment
                    //Presentation
                    if (dataGridView1.CurrentCell.ColumnIndex == 6)
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells[6].Value != null)
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(), @"^[0-9]*?$"))
                            {

                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[6].Value = 10;
                            }
                        }

                    }
                    //end Presentation
                    //Quizz
                    if (dataGridView1.CurrentCell.ColumnIndex == 7)
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells[7].Value != null)
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString(), @"^[0-9]*?$"))
                            {

                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[7].Value = 5;
                            }
                        }

                    }
                    //end Quizz
                }
                #endregion
                #region With Lab
                if (rdbWithLab.Checked)

                {
                    //mid
                    if (dataGridView1.CurrentCell.ColumnIndex == 3)
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells[3].Value != null)
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), @"^[0-9]*?$"))
                            {

                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[3].Value = 30;
                            }
                        }

                    }
                    //end Mid 
                    //Final
                    if (dataGridView1.CurrentCell.ColumnIndex == 4)
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells[4].Value != null)
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(), @"^[0-9]*?$"))
                            {

                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[4].Value = 60;
                            }
                        }

                    }
                    //end Final
                    //Assignment
                    if (dataGridView1.CurrentCell.ColumnIndex == 5)
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells[5].Value != null)
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(), @"^[0-9]*?$"))
                            {

                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[5].Value = 2;
                            }
                        }

                    }
                    //end Assignment
                    //Presentation
                    if (dataGridView1.CurrentCell.ColumnIndex == 6)
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells[6].Value != null)
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(), @"^[0-9]*?$"))
                            {

                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[6].Value = 5;
                            }
                        }

                    }
                    //end Presentation
                    //Quizz
                    if (dataGridView1.CurrentCell.ColumnIndex == 7)
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells[7].Value != null)
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString(), @"^[0-9]*?$"))
                            {

                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[7].Value = 3;
                            }
                        }

                    }
                    //end Quizz
                    //Lab
                    if (dataGridView1.CurrentCell.ColumnIndex == 8)
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells[8].Value != null)
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString(), @"^[0-9]*?$"))
                            {

                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[8].Value = 10;
                            }
                        }

                    }
                    //end Lab
                }
                #endregion
            }
            // Marks Validation 
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Without Lab 
                    #region Without Lab Work
                    if (rdbWithoutLab.Checked == true)
                    {

                        try
                        {
                            //mid
                            if (Convert.ToInt32(row.Cells[3].Value) > 30 || Convert.ToInt32(row.Cells[3].Value) < 0)
                            {
                                row.Cells[3].Value = 30;
                            }
                            //final
                            else if (Convert.ToInt32(row.Cells[4].Value) > 50 || Convert.ToInt32(row.Cells[4].Value) < 0)
                            {
                                row.Cells[4].Value = 50;
                            }
                            //assignment
                            else if (Convert.ToInt32(row.Cells[5].Value) > 5 || Convert.ToInt32(row.Cells[5].Value) < 0)
                            {
                                row.Cells[5].Value = 5;
                            }
                            //presentation
                            else if (Convert.ToInt32(row.Cells[6].Value) > 10 || Convert.ToInt32(row.Cells[6].Value) < 0)
                            {
                                row.Cells[6].Value = 10;
                            }
                            //Quiz
                            else if (Convert.ToInt32(row.Cells[7].Value) > 5 || Convert.ToInt32(row.Cells[7].Value) < 0)
                            {
                                row.Cells[7].Value = 5;
                            }
                        }
                        catch { }
                    }
                    #endregion
                    //With Lab 
                    #region With Lab
                    else if (rdbWithLab.Checked == true)
                    {
                        try
                        {
                            //mid 
                            if (Convert.ToInt32(row.Cells[3].Value) > 30 || Convert.ToInt32(row.Cells[3].Value) < 0)
                            {
                                row.Cells[3].Value = 30;
                            }
                            //final
                             if (Convert.ToInt32(row.Cells[4].Value) > 60 || Convert.ToInt32(row.Cells[4].Value) < 0)
                            {
                                row.Cells[4].Value = 60;
                            }
                             //assignemt
                            else if (Convert.ToInt32(row.Cells[5].Value) > 2 || Convert.ToInt32(row.Cells[5].Value) < 0)
                            {
                                row.Cells[5].Value = 2;
                            }
                             //presentatrion
                            else if (Convert.ToInt32(row.Cells[6].Value) > 5 || Convert.ToInt32(row.Cells[6].Value) < 0)
                            {
                                row.Cells[6].Value = 5;
                            }
                             //quizz
                            else if (Convert.ToInt32(row.Cells[7].Value) > 3 || Convert.ToInt32(row.Cells[7].Value) < 0)
                            {
                                row.Cells[7].Value = 3;
                            }
                             //lab
                            else if (Convert.ToInt32(row.Cells[8].Value) > 10 || Convert.ToInt32(row.Cells[8].Value) < 0)
                            {
                                row.Cells[8].Value = 10;
                            }
                     
                        }
                        catch { }


                    }
                    #endregion
                }//end if 
            }//end Foreach 

            try
            {
                long value1 = 0;
                // Final Term Exam 
                #region Fianl Term Exam
                if (FinalTerm.Checked == true)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (rdbWithoutLab.Checked == true)
                        {
                            row.Cells[8].Value = 0;
                        }
                        dataGridView1.Columns["StatusId"].Visible = false;
                        long.TryParse(row.Cells[3]?.Value?.ToString(), out value1);
                        long.TryParse(row.Cells[4]?.Value?.ToString(), out value1);
                        long.TryParse(row.Cells[5]?.Value?.ToString(), out value1);
                        long.TryParse(row.Cells[6]?.Value?.ToString(), out value1);
                        long.TryParse(row.Cells[7]?.Value?.ToString(), out value1);

                        row.Cells[9].Value = Convert.ToInt64(row.Cells[3]?.Value) + Convert.ToInt64(row.Cells[4]?.Value) + Convert.ToInt64(row.Cells[5]?.Value) + Convert.ToInt64(row.Cells[6]?.Value) + Convert.ToInt64(row.Cells[7]?.Value) + Convert.ToInt64(row.Cells[8]?.Value);
                        row.Cells[9].ReadOnly = true;
                        if (Convert.ToInt32(row.Cells[9].Value) > 100 || Convert.ToInt32(row.Cells[9].Value) < 0)
                        {
                            MessageBox.Show("Numbers Could not be Greater than 100");
                            row.Cells[9].Value = 0;
                            row.Cells[4].Value = 0;
                  


                        }

                        #region Grading 
                        else if (Convert.ToInt32(row.Cells[9].Value) >= 85 && Convert.ToInt32(row.Cells[9].Value) <= 100)
                        {
                            row.Cells[10].Value = 4.0;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "A";
                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 84)
                        {
                            row.Cells[10].Value = 3.9;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "B";

                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 83)
                        {
                            row.Cells[10].Value = 3.8;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "B";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 82)
                        {
                            row.Cells[10].Value = 3.7;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "B";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 81)
                        {
                            row.Cells[10].Value = 3.6;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "B";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 80)
                        {
                            row.Cells[10].Value = 3.5;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "B";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 79)
                        {
                            row.Cells[10].Value = 3.4;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "B";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 78)
                        {
                            row.Cells[10].Value = 3.4;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "B";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 77)
                        {
                            row.Cells[10].Value = 3.3;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "B";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 76)
                        {
                            row.Cells[10].Value = 3.3;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "B";




                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 75)
                        {
                            row.Cells[10].Value = 3.2;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "B";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 74)
                        {
                            row.Cells[10].Value = 3.2;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "B";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 73)
                        {
                            row.Cells[10].Value = 3.1;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "B";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 72)
                        {
                            row.Cells[10].Value = 3.0;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "B";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 71)
                        {
                            row.Cells[10].Value = 2.9;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "C";

                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 70)
                        {
                            row.Cells[10].Value = 2.8;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "C";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 69)
                        {
                            row.Cells[10].Value = 2.7;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "C";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 68)
                        {
                            row.Cells[10].Value = 2.6;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "C";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 67)
                        {
                            row.Cells[10].Value = 2.5;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "C";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 66)
                        {
                            row.Cells[10].Value = 2.5;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "C";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 65)
                        {
                            row.Cells[10].Value = 2.4;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "C";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 64)
                        {
                            row.Cells[10].Value = 2.4;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "C";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 63)
                        {
                            row.Cells[10].Value = 2.3;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "C";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 62)
                        {
                            row.Cells[10].Value = 2.2;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "C";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 61)
                        {
                            row.Cells[10].Value = 2.1;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "C";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 60)
                        {
                            row.Cells[10].Value = 2.0;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "C";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 59)
                        {
                            row.Cells[10].Value = 1.9;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "D";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 58)
                        {
                            row.Cells[10].Value = 1.8;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "D";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 57)
                        {
                            row.Cells[10].Value = 1.7;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "D";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 56)
                        {
                            row.Cells[10].Value = 1.6;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "D";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 55)
                        {
                            row.Cells[10].Value = 1.5;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "D";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 54)
                        {
                            row.Cells[10].Value = 1.4;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "D";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 53)
                        {
                            row.Cells[10].Value = 1.3;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "D";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 52)
                        {
                            row.Cells[10].Value = 1.2;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "D";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 51)
                        {
                            row.Cells[10].Value = 1.1;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "D";



                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) == 50)
                        {
                            row.Cells[10].Value = 1.0;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 1;
                            row.Cells[13].Value = "D";


                        }
                        else if (Convert.ToInt32(row.Cells[9].Value) < 50)
                        {
                            row.Cells[10].Value = 0.0;
                            row.Cells[11].Value = Math.Round(Convert.ToDouble(row.Cells[10].Value) * Convert.ToDouble(txtCh.Text), 3);
                            row.Cells[12].Value = 2;
                            row.Cells[13].Value = "F";


                        }
                        #endregion
                    }
                }
                #endregion
                // Mid Term 
                #region Mid Term
                else if (MidTerm.Checked == true)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                    }
                }
                #endregion
            }
            catch
            {

            }


        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
          
        }

        private void cmbSemester_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                txtSeason.Text = "";
                txtSeason.Enabled = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Season) from Semester where Description = '" + cmbSemester.Text.Trim() + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtSeason.Text = rdr.GetString(0).Trim();
                }
                con.Close();
                //Load Subjects 
                #region Load Subject
                txtSubjectName.Items.Clear();
                txtSubjectName.Text = "";
                txtSubjectName.Enabled = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct1 = @"select distinct Subject.SubjectName from SubjectDetails Inner Join Subject On SubjectDetails.SubjectId = Subject.SubjectId Inner Join Department On SubjectDetails.DepartmentId =Department.DepartmentId INNER JOIN Semester On Semester.SemesterId = SubjectDetails.SemesterId  where ClassName ='" + ClassName.Text.Trim() + "' and FacultyName = '" + FacultyName.Text.Trim() + "' and  Description = '" + cmbSemester.Text.Trim() + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    txtSubjectName.Items.Add(rdr[0]);

                }
                con.Close();
                #endregion
                //Get Semester Id
                #region Get Semester Id
                //Get Semester Id
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select SemesterId from Semester where Description ='" + cmbSemester.Text + "'";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblSemesterId.Text = rdr.GetInt32(0).ToString();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbExamStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                #region Get Exam Status Id
                //Get Exam Status Id
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select ExamStatusId from ExamStatus where Status ='" + cmbExamStatus.Text + "'";

                cmd = new SqlCommand(ct2);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ExamStatusId.Text = rdr.GetInt32(0).ToString();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                #endregion

                if (cmbExamStatus.Text == "Fresh")
                {
                    dataGridView1.Visible = true;
                    groupBox3.Visible = false;
                }
                else if (cmbExamStatus.Text == "SCE" || cmbExamStatus.Text == "Makeup" || cmbExamStatus.Text == "Repeat")
                {
                    groupBox3.Visible = true;
                    dataGridView1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EmployeeName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                #region Get Employee Id
                //Get Employee Id
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select EmployeeId from Employee where EmployeeName ='" + EmployeeName.Text.Trim() + "'";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblEmployeeId.Text = rdr.GetInt32(0).ToString();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                #endregion

                if (cmbExamStatus.Text == "Fresh")
                {
                    dataGridView1.Visible = true;
                    groupBox3.Visible = false;
                }
                else if (cmbExamStatus.Text == "SCE" || cmbExamStatus.Text == "MakeUp" || cmbExamStatus.Text == "Repeat")
                {
                    groupBox3.Visible = true;
                    dataGridView1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void cmbClassNo_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            try
            {
                //Get Student Name 
                #region  Get Student Name 
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT StudentName from Student where ClassNo = '"+cmbClassNo.Text.Trim()+"' and  DepartmentId=(Select DepartmentId From Department where  ClassName = '" + ClassName.Text.Trim() + "' and FacultyName ='" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Description = '" + Session.Text.Trim() + "')";
                rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    txtStudentName.Text = rdr.GetString(0).Trim();                   
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                #endregion
                // Get Student Id
                #region Get Student Id 
                //Get Student Id
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select StudentId from Student where ClassNo ='" + cmbClassNo.Text.Trim() + "' and DepartmentId = (Select DepartmentId From Department where ClassName = '"+ClassName.Text.Trim()+"' and FacultyName = '"+FacultyName.Text.Trim()+"') and SessionId = (Select SessionId From Session where Description ='"+Session.Text.Trim()+"')";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    StudentId.Text = rdr.GetInt32(0).ToString();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                #endregion


                //Final Term Exam
                if (FinalTerm.Checked == true)
                {
                    //WithLab Work
                    #region With Lab 
                    if (rdbWithLab.Checked)
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = new SqlCommand("SELECT Distinct Mid,Final,Quizz,Assignment,Presentation,Lab from Result WHERE Result.StudentId=(Select StudentId From Student where ClassNo = '" + cmbClassNo.Text.Trim() + "' and DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')) and  Result.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "' ) ", con);
                        rdr = cmd.ExecuteReader();
                        Mid.Text = "";
                        Final.Text = "";
                        Assignment.Text = "";
                        Presentation.Text = "";
                        Quizz.Text = "";
                        txtLab.Text = "";

                        if (rdr.Read())
                        {
                            Mid.Text = rdr.GetInt32(0).ToString();
                            Final.Text = rdr.GetInt32(1).ToString();
                            Assignment.Text = rdr.GetInt32(2).ToString();
                            Quizz.Text = rdr.GetInt32(3).ToString();
                            Presentation.Text = rdr.GetInt32(4).ToString();
                            txtLab.Text = rdr.GetInt32(5).ToString();
                        }

                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Close();
                    }
                    //endif 
                    #endregion

                    //Without Lab Work
                    #region Without Lab 
                    else if (rdbWithoutLab.Checked)
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = new SqlCommand("SELECT Distinct Mid,Final,Quizz,Assignment,Presentation,Lab from Result WHERE Result.StudentId=(Select StudentId From Student where ClassNo = '" + cmbClassNo.Text.Trim() + "' and DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')) and  Result.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + ClassName.Text.Trim() + "'and FacultyName = '" + FacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Session.Description = '" + Session.Text.Trim() + "')and SemesterId =(Select SemesterId From Semester where Semester.Description = '" + cmbSemester.Text.Trim() + "') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '" + txtSubjectName.Text.Trim() + "') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '" + cmbExamStatus.Text.Trim() + "' ) ", con);
                        rdr = cmd.ExecuteReader();
                        Mid.Text = "";
                        Final.Text = "";
                        Assignment.Text = "";
                        Presentation.Text = "";
                        Quizz.Text = "";
                        txtLab.Text = "";

                        if (rdr.Read())
                        {
                            Mid.Text = rdr.GetInt32(0).ToString();
                            Final.Text = rdr.GetInt32(1).ToString();
                            Assignment.Text = rdr.GetInt32(2).ToString();
                            Quizz.Text = rdr.GetInt32(3).ToString();
                            Presentation.Text = rdr.GetInt32(4).ToString();
                            txtLab.Text = "0";
                        }

                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Close();
                    } //end else if 
                    #endregion
                    else
                    {
                        MessageBox.Show("Select with Or without lab", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                //end if 
                else if (MidTerm.Checked == true)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("SELECT Distinct Mid from Result WHERE Result.StudentId=(Select StudentId From Student where ClassNo = '" + cmbClassNo.Text.Trim() + "' and DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" +ClassName.Text.Trim()+"'and FacultyName = '"+FacultyName.Text.Trim()+"') and SessionId = (Select SessionId From Session where Session.Description = '"+Session.Text.Trim()+"')) and  Result.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '"+ClassName.Text.Trim()+"'and FacultyName = '"+FacultyName.Text.Trim()+"') and SessionId = (Select SessionId From Session where Session.Description = '"+Session.Text.Trim()+"')and SemesterId =(Select SemesterId From Semester where Semester.Description = '"+cmbSemester.Text.Trim()+"') and SubjectId =(Select SubjectId From Subject where Subject.SubjectName = '"+txtSubjectName.Text.Trim()+"') and ExamStatusId =(Select ExamStatusId From ExamStatus where ExamStatus.Status = '"+cmbExamStatus.Text.Trim()+"' ) ", con);
                    rdr = cmd.ExecuteReader();
                    Mid.Text = "";
                    if (rdr.Read())
                    {
                        Mid.Text = rdr.GetInt32(0).ToString();
                    }

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                   
                } //end else if 
                else
                {
                    MessageBox.Show("Please Select Exam Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (label5.Text == "Admin")
                {
                    Delete.Enabled = true;
                }
                else
                {
                    Delete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
            }
            }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
              {
         
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

            

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
          
        }

        private void Mid_TextChanged_1(object sender, EventArgs e)
        {
          
            int val1 = 0;
            int val2 = 0;
            int val3 = 0;
            int val4 = 0;
            int val5 = 0;
            int val6 = 0;
            int val7 = 0;
            int.TryParse(Mid.Text, out val1);
            int.TryParse(Presentation.Text, out val2);
            int.TryParse(Assignment.Text, out val3);
            int.TryParse(Quizz.Text, out val4);
            int.TryParse(Final.Text, out val6);
            int.TryParse(txtLab.Text, out val7);
            int I = ((val1 + val2 + val3 + val4 + val5 + val6 +val7));
            TotalMarks.Text = I.ToString();
            if (Mid.Text == "")
            {

            }
            else if (Mid.Text != null)
            {
                if (rdbWithLab.Checked == true)
                {
                    if (Convert.ToInt32(Mid.Text) > 30 || Convert.ToInt32(Mid.Text) < 0)
                    {
                        Mid.Text = "30";
                    }
                }
               else  if (rdbWithoutLab.Checked == true)
                {
                    if (Convert.ToInt32(Mid.Text) > 30 || Convert.ToInt32(Mid.Text) < 0)
                    {
                        Mid.Text = "30";
                    }
                }
                else
                {
                    Mid.Text = "0";
                }

            }
        }

        private void Final_TextChanged_1(object sender, EventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int val3 = 0;
            int val4 = 0;
            int val5 = 0;
            int val6 = 0;
            int val7 = 0;
            int.TryParse(Mid.Text, out val1);
            int.TryParse(Presentation.Text, out val2);
            int.TryParse(Assignment.Text, out val3);
            int.TryParse(Quizz.Text, out val4);
            int.TryParse(Final.Text, out val6);
            int.TryParse(txtLab.Text, out val7);
            int I = ((val1 + val2 + val3 + val4 + val5 + val6 + val7));
            TotalMarks.Text = I.ToString();

            if (Final.Text == "")
            {

            }
            else if (Final.Text != null)
            {
                if (Convert.ToInt32(Final.Text) > 60 || Convert.ToInt32(Final.Text) < 0)
                {
                    Final.Text = "60";
                }
            }
        }

        private void Presentation_TextChanged(object sender, EventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int val3 = 0;
            int val4 = 0;
            int val5 = 0;
            int val6 = 0;
            int val7 = 0;
            int.TryParse(Mid.Text, out val1);
            int.TryParse(Presentation.Text, out val2);
            int.TryParse(Assignment.Text, out val3);
            int.TryParse(Quizz.Text, out val4);
            int.TryParse(Final.Text, out val6);
            int.TryParse(txtLab.Text, out val7);
            int I = ((val1 + val2 + val3 + val4 + val5 + val6 + val7));
            TotalMarks.Text = I.ToString();

            if (Presentation.Text == "")
            {

            }
            else if (Presentation.Text != null)
            {
                if (Convert.ToInt32(Presentation.Text) > 10 || Convert.ToInt32(Presentation.Text) < 0)
                {
                    Presentation.Text = "10";
                }
            }
        }

        private void Quizz_TextChanged(object sender, EventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int val3 = 0;
            int val4 = 0;
            int val5 = 0;
            int val6 = 0;
            int val7 = 0;
            int.TryParse(Mid.Text, out val1);
            int.TryParse(Presentation.Text, out val2);
            int.TryParse(Assignment.Text, out val3);
            int.TryParse(Quizz.Text, out val4);
            int.TryParse(Final.Text, out val6);
            int.TryParse(txtLab.Text, out val7);
            int I = ((val1 + val2 + val3 + val4 + val5 + val6+ val7));
            TotalMarks.Text = I.ToString();

            if (Quizz.Text == "")
            {

            }
            else if (Quizz.Text != null)
            {
                if (Convert.ToInt32(Quizz.Text) > 5 || Convert.ToInt32(Quizz.Text) < 0)
                {
                    Quizz.Text = "5";
                }
            }
        }
         private void TotalMarks_TextChange(object sender, EventArgs e)
        {

            if (int.Parse(TotalMarks.Text) > 100 || int.Parse(TotalMarks.Text) < 0)
            {             
                {
                    Double gpa = 0.0;
                    Final.Text = "0";
                    Value.Text = gpa.ToString();
                    MessageBox.Show("Subject numbers Cannot Be greater than 100", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            #region Special Exams Grading 
            if (int.Parse(TotalMarks.Text) >= 85 && int.Parse(TotalMarks.Text) <= 100)
            {
                double gpa = 4.0;
                Value.Text = gpa.ToString();
                txtGrade.Text = "A";


            }
            else if (int.Parse(TotalMarks.Text) == 84)
            {
                Double gpa = 3.9;
                Value.Text = gpa.ToString();
                txtGrade.Text = "B";


            }
            else if (int.Parse(TotalMarks.Text) == 83)
            {
                Double gpa = 3.8;
                Value.Text = gpa.ToString();
                txtGrade.Text = "B";



            }
            else if (int.Parse(TotalMarks.Text) == 82)
            {
                Double gpa = 3.7;
                Value.Text = gpa.ToString();
                txtGrade.Text = "B";



            }
            else if (int.Parse(TotalMarks.Text) == 81)
            {
                Double gpa = 3.6;
                Value.Text = gpa.ToString();
                txtGrade.Text = "B";



            }
            else if (int.Parse(TotalMarks.Text) == 80)
            {
                Double gpa = 3.5;
                Value.Text = gpa.ToString();
                txtGrade.Text = "B";



            }
            else if (int.Parse(TotalMarks.Text) == 79)
            {
                Double gpa = 3.4;
                Value.Text = gpa.ToString();
                txtGrade.Text = "B";


            }
            else if (int.Parse(TotalMarks.Text) == 78)
            {
                Double gpa = 3.4;
                Value.Text = gpa.ToString();
                txtGrade.Text = "B";


            }
            else if (int.Parse(TotalMarks.Text) == 77)
            {
                Double gpa = 3.3;
                Value.Text = gpa.ToString();
                txtGrade.Text = "B";


            }
            else if (int.Parse(TotalMarks.Text) == 76)
            {
                Double gpa = 3.3;
                Value.Text = gpa.ToString();
                txtGrade.Text = "B";


            }
            else if (int.Parse(TotalMarks.Text) == 75)
            {
                Double gpa = 3.2;
                Value.Text = gpa.ToString();
                txtGrade.Text = "B";


            }
            else if (int.Parse(TotalMarks.Text) == 74)
            {
                Double gpa = 3.2;
                Value.Text = gpa.ToString();
                txtGrade.Text = "B";


            }
            else if (int.Parse(TotalMarks.Text) == 73)
            {
                Double gpa = 3.1;
                Value.Text = gpa.ToString();
                txtGrade.Text = "B";


            }

            else if (int.Parse(TotalMarks.Text) == 72)
            {
                Double gpa = 3.0;
                Value.Text = gpa.ToString();
                txtGrade.Text = "B";


            }
            else if (int.Parse(TotalMarks.Text) == 71)
            {
                Double gpa = 2.9;
                Value.Text = gpa.ToString();
                txtGrade.Text = "C";


            }
            else if (int.Parse(TotalMarks.Text) == 70)
            {
                Double gpa = 2.8;
                Value.Text = gpa.ToString();
                txtGrade.Text = "C";


            }
            else if (int.Parse(TotalMarks.Text) == 69)
            {
                Double gpa = 2.7;
                Value.Text = gpa.ToString();
                txtGrade.Text = "C";



            }
            else if (int.Parse(TotalMarks.Text) == 68)
            {
                Double gpa = 2.6;
                Value.Text = gpa.ToString();
                txtGrade.Text = "C";


            }
            else if (int.Parse(TotalMarks.Text) == 67)
            {
                Double gpa = 2.5;
                Value.Text = gpa.ToString();
                txtGrade.Text = "C";


            }
            else if (int.Parse(TotalMarks.Text) == 66)
            {
                Double gpa = 2.5;
                Value.Text = gpa.ToString();
                txtGrade.Text = "C";


            }
            else if (int.Parse(TotalMarks.Text) == 65)
            {
                Double gpa = 2.4;
                Value.Text = gpa.ToString();
                txtGrade.Text = "C";


            }
            else if (int.Parse(TotalMarks.Text) == 64)
            {
                Double gpa = 2.4;
                Value.Text = gpa.ToString();
                txtGrade.Text = "C";


            }
            else if (int.Parse(TotalMarks.Text) == 63)
            {
                Double gpa = 2.3;
                Value.Text = gpa.ToString();
                txtGrade.Text = "C";


            }
            else if (int.Parse(TotalMarks.Text) == 62)
            {
                Double gpa = 2.2;
                Value.Text = gpa.ToString();
                txtGrade.Text = "C";


            }
            else if (int.Parse(TotalMarks.Text) == 61)
            {
                Double gpa = 2.1;
                Value.Text = gpa.ToString();
                txtGrade.Text = "C";


            }
            else if (int.Parse(TotalMarks.Text) == 60)
            {
                Double gpa = 2.0;
                Value.Text = gpa.ToString();
                txtGrade.Text = "C";


            }
            else if (int.Parse(TotalMarks.Text) == 59)
            {
                Double gpa = 1.9;
                Value.Text = gpa.ToString();
                txtGrade.Text = "D";


            }
            else if (int.Parse(TotalMarks.Text) == 58)
            {
                Double gpa = 1.8;
                Value.Text = gpa.ToString();
                txtGrade.Text = "D";


            }
            else if (int.Parse(TotalMarks.Text) == 57)
            {
                Double gpa = 1.7;
                Value.Text = gpa.ToString();
                txtGrade.Text = "D";


            }
            else if (int.Parse(TotalMarks.Text) == 56)
            {
                Double gpa = 1.6;
                Value.Text = gpa.ToString();
                txtGrade.Text = "D";


            }
            else if (int.Parse(TotalMarks.Text) == 55)
            {
                Double gpa = 1.5;
                Value.Text = gpa.ToString();
                txtGrade.Text = "D";


            }
            else if (int.Parse(TotalMarks.Text) == 54)
            {
                Double gpa = 1.4;
                Value.Text = gpa.ToString();
                txtGrade.Text = "D";


            }
            else if (int.Parse(TotalMarks.Text) == 53)
            {
                Double gpa = 1.3;
                Value.Text = gpa.ToString();
                txtGrade.Text = "D";


            }
            else if (int.Parse(TotalMarks.Text) == 52)
            {
                Double gpa = 1.2;
                Value.Text = gpa.ToString();
                txtGrade.Text = "D";


            }
            else if (int.Parse(TotalMarks.Text) == 51)
            {
                Double gpa = 1.1;
                Value.Text = gpa.ToString();
                txtGrade.Text = "D";


            }
            else if (int.Parse(TotalMarks.Text) == 50)
            {
                Double gpa = 1.0;
                Value.Text = gpa.ToString();
                txtGrade.Text = "D";


            }

            else if (int.Parse(TotalMarks.Text) <= 49)
            {
                Double gpa = 0.0;
                Value.Text = gpa.ToString();
                txtGrade.Text = "F";
                Status.Text = "2";


            }
  

            if (int.Parse(TotalMarks.Text) <= 100 && int.Parse(TotalMarks.Text) >= 50)
            {
                Status.Text = "1";
            }
            #endregion
        }

        private void Value_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double value = Convert.ToDouble(Value.Text);
                double CH = Convert.ToDouble(txtCh.Text);
                double Result = value * CH;
                GP.Text = Result.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void Mid_KeyPress(object sender, KeyPressEventArgs e)
        {         
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void Final_KeyPress(object sender, KeyPressEventArgs e)               
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void Assignment_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void Presentation_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void Quizz_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }
        private void txtLab_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void ResetTextbox()
        {
            txtStudentName.Text = "";
            cmbClassNo.Text = "";
            Mid.Text = "";
            Presentation.Text = "";
            Quizz.Text = "";
            Assignment.Text = "";
            Final.Text = "";
            StudentId.Text = "";
            Status.Text = "";
            txtLab.Text = "0";
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            ResetTextbox();
        }

        private void MidTerm_CheckedChanged(object sender, EventArgs e)
        {
            if (MidTerm.Checked == true)
            {
                Mid.ReadOnly = false;
                Final.Text = "";
                Quizz.Text = "";
                Presentation.Text = "";
                Assignment.Text = "";
                txtLab.Text = "";
                txtLab.Enabled = false;
                Mid.Enabled = true;
                Final.Enabled = false;
                Quizz.Enabled = false;
                Presentation.Enabled = false;
                Assignment.Enabled = false;
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
      
        }

        private void rdbWithoutLab_CheckedChanged(object sender, EventArgs e)
        {
            if (FinalTerm.Checked == true)
            {
                if (rdbWithoutLab.Checked == true)
                {

                    txtLab.Enabled = false;
                    txtLab.Text = "0";
                }
            }

            if (rdbWithLab.Checked == true)
            {
                if (Mid.Text == "")
                {

                }
                
                else if (Mid.Text != null)
                {
                    if (Convert.ToInt32(Mid.Text) > 20 || Convert.ToInt32(Mid.Text) < 0)
                    {
                        Mid.Text = "20";
                    }
                }
              
            }
            else if (rdbWithoutLab.Checked == true)
            {
                if (Mid.Text == "")
                {

                }
               
               else if (Mid.Text != null)
                {
                    if (Convert.ToInt32(Mid.Text) > 30 || Convert.ToInt32(Mid.Text) < 0)
                    {
                        Mid.Text = "30";
                    }
                }
               
            }
            else
            {
                Mid.Text = "0";
            }

        }

        private void rdbWithLab_CheckedChanged(object sender, EventArgs e)
        {

            if (FinalTerm.Checked == true)
            {
                if (rdbWithLab.Checked == true)
                {
                    txtLab.Enabled = true;
                    //txtLab.Text = "0";
                }
            }
        }

        private void txtLab_TextChanged(object sender, EventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int val3 = 0;
            int val4 = 0;
            int val5 = 0;
            int val6 = 0;
            int val7 = 0;
            int.TryParse(Mid.Text, out val1);
            int.TryParse(Presentation.Text, out val2);
            int.TryParse(Assignment.Text, out val3);
            int.TryParse(Quizz.Text, out val4);
            int.TryParse(Final.Text, out val6);
            int.TryParse(txtLab.Text, out val7);
            int I = ((val1 + val2 + val3 + val4 + val5 + val6 + val7));
            TotalMarks.Text = I.ToString();

            if (txtLab.Text == "")
            {

            }
            else if (txtLab.Text != null)
            {
                if (Convert.ToInt32(txtLab.Text) > 10 || Convert.ToInt32(txtLab.Text) < 0)
                {
                    txtLab.Text = "10";
                }
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DataGridViewRow dr = dataGridView1.SelectedRows[0];            
            // or simply use column name instead of index
            lblStudentIdDlt.Text = dr.Cells[0].Value.ToString();

            if (label5.Text == "Admin")
            {
               Delete.Enabled = true;              
                btnSave.Enabled = false;
                ClassName.Focus();
            }
            else
            {
                Delete.Enabled = false;    
                btnSave.Enabled = false;
                ClassName.Focus();
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }

