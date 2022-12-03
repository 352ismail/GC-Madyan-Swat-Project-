using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace College_Management_System.Forms
{
    public partial class frmSemesterResult : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmSemesterResult()
        {
            InitializeComponent();
        }

        private void frmSemesterResult_Load(object sender, EventArgs e)
        {
            AutocompleteClassName();
        }
        private void AutocompleteClassName()
        {

            try
            {


                SqlConnection CN = new SqlConnection(cs.DBConn);

                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(ClassName) FROM Department", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                cmbClassName.Items.Clear();

                foreach (DataRow drow in dtable.Rows)
                {
                    cmbClassName.Items.Add(drow[0].ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFaculty.Items.Clear();
            cmbFaculty.Text = "";
            cmbFaculty.Enabled = true;

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();


                string ct = "select distinct RTRIM(FacultyName) from Department where ClassName= '" + cmbClassName.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbFaculty.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSession.Items.Clear();
            cmbSession.Text = "";
            cmbSession.Enabled = true;

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Description) from Session ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbSession.Items.Add(rdr[0]);
                }

                con.Close();
                #region Get Department Id
                //Get Department Id
                lblDepartmentId.Text = "";
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select DepartmentId from Department where ClassName ='" + cmbClassName.Text + "' and FacultyName = '" + cmbFaculty.Text + "'";

                cmd = new SqlCommand(ct2);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    lblDepartmentId.Text = rdr.GetInt32(0).ToString();
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

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSemester.Items.Clear();
            cmbSemester.Text = "";
            cmbSemester.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Description) from Semester";
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
                string ct2 = "select SessionId from Session where Description ='" + cmbSession.Text + "'";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    lblSessionid.Text = rdr.GetInt32(0).ToString();
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

        private void cmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
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

                if (label1.Text == "Admin")
                {
                    Delete.Enabled = true;
                    cmbClassName.Focus();
                }
                else
                {
                    Delete.Enabled = false;
                    cmbClassName.Focus();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getData()
        {
            try
            {
                #region Validation
                if (cmbClassName.Text == "")
                {
                    MessageBox.Show("Please select Class Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClassName.Focus();
                    return;
                }
                if (cmbFaculty.Text == "")
                {
                    MessageBox.Show("Please select FacultyName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFaculty.Focus();
                    return;
                }
                if (cmbSemester.Text == "")
                {
                    MessageBox.Show("Please select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSemester.Focus();
                    return;
                }
                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSession.Focus();
                    return;
                }
                #endregion
                #region 1st Semester
                if (cmbSemester.Text == "1st")
                {
                    #region Check Semester In Result Table
                    //check theat the Result of the Semester is Exist or not
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string sm1 = "Select Distinct(Departmentid),Sessionid,SemesterId From Result where Departmentid = (Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '1st' )";
                    cmd = new SqlCommand(sm1);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == false)
                    {
                        MessageBox.Show("Semester Result Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;

                    }
                    #endregion
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select  RTRIM(Student.StudentId)[ID], RTRIM(Student.ClassNo)[Class No],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],                       (select (Sum (GP)/Sum (Subject.CH))[GPA] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId  where  ClassName = '' AND FacultyName = '' AND Semester.Description='' AND Session.Description = '' AND ClassNo = '' AND Status = 'fresh')[GPA],                              Round(Sum(GP),2)[CGP],Round(Sum(Subject.CH),2)[CCH],Round(Sum (GP)/Sum (Subject.CH),2)[CGPA],(Select SemesterResult.Status From SemesterResult where Student.StudentId= SemesterResult.StudentId and DepartmentId = (Select DepartmentId From Department WHere Department.ClassName = '" + cmbClassName.Text.Trim() + "' ANd Department.FacultyName ='" + cmbFaculty.Text.Trim() + "') ANd SessionId = (Select SessionId From Session Where Session.Description = '" + cmbSession.Text.Trim() + "') AND SemesterId = (Select SemesterId From Semester Where Semester.Description = '" + cmbSemester.Text.Trim() + "'))[Status] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId where  ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "'  AND ExamStatus.Status = 'Fresh'  AND Semester.Description='1st' Group By ClassNo ,StudentName,FatherName,Student.StudentId", con);
                    SqlDataAdapter myDA1 = new SqlDataAdapter(cmd);
                    DataSet myDataSet1 = new DataSet();
                    myDA1.Fill(myDataSet1, "SemesterResult");
                    dataGridView1.DataSource = myDataSet1.Tables["SemesterResult"].DefaultView;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            // Calculate GPA Of Each Semster
                            #region Calculate GPA Of Individual Semester
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select (Sum (GP)/Sum (Subject.CH))[GPA] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId  where  ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Semester.Description='" + cmbSemester.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "' AND ClassNo = '" + row.Cells[1].Value + "' AND Status = 'Fresh' ", con);
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[4].Value = Math.Round(rdr.GetDouble(0), 2).ToString();

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
                            //check the status if the student has First probation 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '1st' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'FP & Promoted' ";
                            cmd = new SqlCommand(ct);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[8].Value = "FP & Promoted";

                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }

                            }
                            else if (rdr.Read() == false)
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "Promoted";

                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "FP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            else
                            {
                                row.Cells[7].Value = "Promoted";
                            }

                            dataGridView1.Columns["ID"].Visible = false;
                            row.Cells[0].ReadOnly = true;
                            row.Cells[1].ReadOnly = true;
                            row.Cells[2].ReadOnly = true;
                            row.Cells[3].ReadOnly = true;
                            row.Cells[4].ReadOnly = true;
                            row.Cells[5].ReadOnly = true;
                            row.Cells[6].ReadOnly = true;
                            row.Cells[7].ReadOnly = true;

                        }
                    }
                    con.Close();
                }
                #endregion
                #region 2nd Semester

                else if (cmbSemester.Text == "2nd")
                {

                    #region Check Previous  Semester Result
                    //check theat the Result of Previous Semester is Exist or not
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string sm1 = "Select Distinct(Departmentid),Sessionid,SemesterId From SemesterResult where Departmentid = (Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '1st' )";
                    cmd = new SqlCommand(sm1);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == false)
                    {
                        MessageBox.Show("1st Semester Result Not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;

                    }
                    #endregion
                    #region Check Semester In Result Table
                    //check that the Result of the Semester is Exist or not
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string sm = "Select Distinct(Departmentid),Sessionid,SemesterId From Result where Departmentid = (Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '2nd' )";
                    cmd = new SqlCommand(sm);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == false)
                    {
                        MessageBox.Show("Semester Result Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;

                    }
                    #endregion
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select  RTRIM(Student.StudentId)[ID], RTRIM(Student.ClassNo)[Class No],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],                       (select (Sum (GP)/Sum (Subject.CH))[GPA] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId  where  ClassName = '' AND FacultyName = '' AND Semester.Description='' AND Session.Description = '' AND ClassNo = '' AND Status = 'fresh')[GPA],                              Round(Sum(GP),2)[CGP],Round(Sum(Subject.CH),2)[CCH],Round(Sum (GP)/Sum (Subject.CH),2)[CGPA],(Select SemesterResult.Status From SemesterResult where Student.StudentId= SemesterResult.StudentId and DepartmentId = (Select DepartmentId From Department WHere Department.ClassName = '" + cmbClassName.Text.Trim() + "' ANd Department.FacultyName ='" + cmbFaculty.Text.Trim() + "') ANd SessionId = (Select SessionId From Session Where Session.Description = '" + cmbSession.Text.Trim() + "') AND SemesterId = (Select SemesterId From Semester Where Semester.Description = '" + cmbSemester.Text.Trim() + "'))[Status] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId where  ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "'  AND ExamStatus.Status = 'Fresh'  AND Semester.Description='1st' Or Semester.Description = '2nd' Group By ClassNo ,StudentName,FatherName,Student.StudentId", con);
                    SqlDataAdapter myDA1 = new SqlDataAdapter(cmd);
                    DataSet myDataSet1 = new DataSet();
                    myDA1.Fill(myDataSet1, "SemesterResult");
                    dataGridView1.DataSource = myDataSet1.Tables["SemesterResult"].DefaultView;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            // Calculate GPA Of Each Semster
                            #region Calculate GPA Of Individual Semester
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select (Sum (GP)/Sum (Subject.CH))[GPA] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId  where  ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Semester.Description='" + cmbSemester.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "' AND ClassNo = '" + row.Cells[1].Value + "' AND Status = 'Fresh' ", con);
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[4].Value = Math.Round(rdr.GetDouble(0), 2).ToString();

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

                            #region Previous Result
                            //check first semester Promoted
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '1st' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'Promoted' ";
                            cmd = new SqlCommand(ct);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "FP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            //check first Semester First Probation 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct2 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '1st' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'FP & Promoted' ";
                            cmd = new SqlCommand(ct2);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "FP & Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "SP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            #endregion

                            //Current Record
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct3 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '2nd' ) and StudentId = '" + row.Cells[0].Value + "' ";
                            cmd = new SqlCommand(ct3);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[8].Value = rdr.GetString(0);
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }

                            dataGridView1.Columns["ID"].Visible = false;
                            row.Cells[0].ReadOnly = true;
                            row.Cells[1].ReadOnly = true;
                            row.Cells[2].ReadOnly = true;
                            row.Cells[3].ReadOnly = true;
                            row.Cells[4].ReadOnly = true;
                            row.Cells[5].ReadOnly = true;
                            row.Cells[6].ReadOnly = true;
                            row.Cells[7].ReadOnly = true;
                            row.Cells[8].ReadOnly = true;
                        }
                    }
                    con.Close();


                }
                #endregion
                #region 3rd Semester
                else if (cmbSemester.Text == "3rd")
                {
                    #region Check Previous  Semester Result
                    //check theat the Result of Previous Semester is Exist or not
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string sm1 = "Select Distinct(Departmentid),Sessionid,SemesterId From SemesterResult where Departmentid = (Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '2nd' )";
                    cmd = new SqlCommand(sm1);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == false)
                    {
                        MessageBox.Show("2nd Semester Result not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;

                    }
                    #endregion
                    #region Check Semester In Result Table
                    //check theat the Result of the Semester is Exist or not
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string sm = "Select Distinct(Departmentid),Sessionid,SemesterId From Result where Departmentid = (Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '3rd' )";
                    cmd = new SqlCommand(sm);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == false)
                    {
                        MessageBox.Show("Semester Result Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;

                    }
                    #endregion
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select  RTRIM(Student.StudentId)[ID], RTRIM(Student.ClassNo)[Class No],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name] ,(select (Sum (GP)/Sum (Subject.CH))[GPA] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId  where  ClassName = '' AND FacultyName = '' AND Semester.Description='' AND Session.Description = '' AND ClassNo = '' AND Status = 'fresh')[GPA]   ,Round(Sum(GP),2)[CGP] ,Round(Sum(Subject.CH),2)[CCH]    ,Round(Sum (GP)/Sum (Subject.CH),2)[CGPA],(Select SemesterResult.Status From SemesterResult where Student.StudentId= SemesterResult.StudentId and DepartmentId = (Select DepartmentId From Department WHere Department.ClassName = '" + cmbClassName.Text.Trim() + "' ANd Department.FacultyName ='" + cmbFaculty.Text.Trim() + "') ANd SessionId = (Select SessionId From Session Where Session.Description = '" + cmbSession.Text.Trim() + "') AND SemesterId = (Select SemesterId From Semester Where Semester.Description = '" + cmbSemester.Text.Trim() + "'))[Status] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId where  ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "'  AND Session.Description = '" + cmbSession.Text.Trim() + "'  AND ExamStatus.Status = 'Fresh'  AND Semester.Description='1st' OR Semester.Description='2nd' OR Semester.Description='3rd' Group By ClassNo ,StudentName,FatherName,Student.StudentId", con);
                    SqlDataAdapter myDA1 = new SqlDataAdapter(cmd);
                    DataSet myDataSet1 = new DataSet();
                    myDA1.Fill(myDataSet1, "SemesterResult");
                    dataGridView1.DataSource = myDataSet1.Tables["SemesterResult"].DefaultView;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            // Calculate GPA Of Each Semster
                            #region Calculate GPA Of Individual Semester
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select (Sum (GP)/Sum (Subject.CH))[GPA] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId  where  ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Semester.Description='" + cmbSemester.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "' AND ClassNo = '" + row.Cells[1].Value + "' AND Status = 'Fresh' ", con);
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[4].Value = Math.Round(rdr.GetDouble(0), 2).ToString();

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

                            #region Previous Result
                            //check Second semester Promoted
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '2nd' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'Promoted' ";
                            cmd = new SqlCommand(ct);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "FP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            //check Second Semester First Probation 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct2 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '2nd' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'FP & Promoted' ";
                            cmd = new SqlCommand(ct2);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "FP & Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "SP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            //check Second Semester Second Probation 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct6 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '2nd' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'SP & Promoted' ";
                            cmd = new SqlCommand(ct6);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "SP & Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "LP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            #endregion

                            //Currrent Record
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct3 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '3rd' ) and StudentId = '" + row.Cells[0].Value + "'";
                            cmd = new SqlCommand(ct3);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[8].Value = rdr.GetString(0);
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }

                            dataGridView1.Columns["ID"].Visible = false;
                            row.Cells[0].ReadOnly = true;
                            row.Cells[1].ReadOnly = true;
                            row.Cells[2].ReadOnly = true;
                            row.Cells[3].ReadOnly = true;
                            row.Cells[4].ReadOnly = true;
                            row.Cells[5].ReadOnly = true;
                            row.Cells[6].ReadOnly = true;
                            row.Cells[7].ReadOnly = true;
                            row.Cells[8].ReadOnly = true;
                        }
                    }
                    con.Close();



                }
                #endregion
                #region 4th Semester 
                else if (cmbSemester.Text == "4th")
                {
                    #region Check Previous  Semester Result
                    //check that the Result of Previous Semester is Exist or not
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string sm1 = "Select Distinct(Departmentid),Sessionid,SemesterId From SemesterResult where Departmentid = (Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '3rd' )";
                    cmd = new SqlCommand(sm1);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == false)
                    {
                        MessageBox.Show("3rd Semester Result not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;

                    }
                    #endregion
                    #region Check Semester In Result Table
                    //check theat the Result of the Semester is Exist or not
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string sm = "Select Distinct(Departmentid),Sessionid,SemesterId From Result where Departmentid = (Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '4th' )";
                    cmd = new SqlCommand(sm);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == false)
                    {
                        MessageBox.Show("Semester Result Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;

                    }
                    #endregion

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select  RTRIM(Student.StudentId)[ID], RTRIM(Student.ClassNo)[Class No],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name] ,(select (Sum (GP)/Sum (Subject.CH))[GPA] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId  where  ClassName = '' AND FacultyName = '' AND Semester.Description='' AND Session.Description = '' AND ClassNo = '' AND Status = 'fresh')[GPA]   ,Round(Sum(GP),2)[CGP] ,Round(Sum(Subject.CH),2)[CCH]    ,Round(Sum (GP)/Sum (Subject.CH),2)[CGPA],(Select SemesterResult.Status From SemesterResult where Student.StudentId= SemesterResult.StudentId and DepartmentId = (Select DepartmentId From Department WHere Department.ClassName = '" + cmbClassName.Text.Trim() + "' ANd Department.FacultyName ='" + cmbFaculty.Text.Trim() + "') ANd SessionId = (Select SessionId From Session Where Session.Description = '" + cmbSession.Text.Trim() + "') AND SemesterId = (Select SemesterId From Semester Where Semester.Description = '" + cmbSemester.Text.Trim() + "'))[Status] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId where  ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "'  AND Session.Description = '" + cmbSession.Text.Trim() + "'  AND ExamStatus.Status = 'Fresh'  AND Semester.Description='1st' OR Semester.Description='2nd' OR Semester.Description='3rd' OR Semester.Description='4th' Group By ClassNo ,StudentName,FatherName,Student.StudentId", con);
                    SqlDataAdapter myDA1 = new SqlDataAdapter(cmd);
                    DataSet myDataSet1 = new DataSet();
                    myDA1.Fill(myDataSet1, "SemesterResult");
                    dataGridView1.DataSource = myDataSet1.Tables["SemesterResult"].DefaultView;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {

                            // Calculate GPA Of Each Semster
                            #region Calculate GPA Of Individual Semester
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select (Sum (GP)/Sum (Subject.CH))[GPA] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId  where  ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Semester.Description='" + cmbSemester.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "' AND ClassNo = '" + row.Cells[1].Value + "' AND Status = 'Fresh' ", con);
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[4].Value = Math.Round(rdr.GetDouble(0), 2).ToString();

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

                            #region Previous Result
                            //check third semester Promoted
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '3rd' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'Promoted' ";
                            cmd = new SqlCommand(ct);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "FP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            //check third Semester First Probation 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct2 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '3rd' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'FP & Promoted' ";
                            cmd = new SqlCommand(ct2);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "FP & Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "SP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            //check third Semester Second Probation 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct6 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '3rd' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'SP & Promoted' ";
                            cmd = new SqlCommand(ct6);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "SP & Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "LP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }

                            //check third Semester Last Probation 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct8 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '3rd' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'LP & Promoted' ";
                            cmd = new SqlCommand(ct8);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "LP & Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "Dropped from Program";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            #endregion

                            //Current Record
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct3 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '4th' ) and StudentId = '" + row.Cells[0].Value + "' ";
                            cmd = new SqlCommand(ct3);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[8].Value = rdr.GetString(0).Trim();
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            dataGridView1.Columns["ID"].Visible = false;
                            row.Cells[0].ReadOnly = true;
                            row.Cells[1].ReadOnly = true;
                            row.Cells[2].ReadOnly = true;
                            row.Cells[3].ReadOnly = true;
                            row.Cells[4].ReadOnly = true;
                            row.Cells[5].ReadOnly = true;
                            row.Cells[6].ReadOnly = true;
                            row.Cells[7].ReadOnly = true;
                            row.Cells[8].ReadOnly = true;
                        }
                    }
                    con.Close();
                }
                #endregion
                #region 5th Semester
                else if (cmbSemester.Text == "5th")
                {
                    #region Check Previous  Semester Result
                    //check that the Result of Previous Semester is Exist or not
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string sm1 = "Select Distinct(Departmentid),Sessionid,SemesterId From SemesterResult where Departmentid = (Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '4th' )";
                    cmd = new SqlCommand(sm1);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == false)
                    {
                        MessageBox.Show("4th Semester Result not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;

                    }
                    #endregion
                    #region Check Semester In Result Table
                    //check theat the Result of the Semester is Exist or not
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string sm = "Select Distinct(Departmentid),Sessionid,SemesterId From Result where Departmentid = (Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '5th' )";
                    cmd = new SqlCommand(sm);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == false)
                    {
                        MessageBox.Show("Semester Result Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;

                    }
                    #endregion
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select  RTRIM(Student.StudentId)[ID], RTRIM(Student.ClassNo)[Class No],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name] ,(select (Sum (GP)/Sum (Subject.CH))[GPA] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId  where  ClassName = '' AND FacultyName = '' AND Semester.Description='' AND Session.Description = '' AND ClassNo = '' AND Status = 'fresh')[GPA]   ,Round(Sum(GP),2)[CGP] ,Round(Sum(Subject.CH),2)[CCH]    ,Round(Sum (GP)/Sum (Subject.CH),2)[CGPA],(Select SemesterResult.Status From SemesterResult where Student.StudentId= SemesterResult.StudentId and DepartmentId = (Select DepartmentId From Department WHere Department.ClassName = '" + cmbClassName.Text.Trim() + "' ANd Department.FacultyName ='" + cmbFaculty.Text.Trim() + "') ANd SessionId = (Select SessionId From Session Where Session.Description = '" + cmbSession.Text.Trim() + "') AND SemesterId = (Select SemesterId From Semester Where Semester.Description = '" + cmbSemester.Text.Trim() + "'))[Status] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId where  ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "'  AND Session.Description = '" + cmbSession.Text.Trim() + "'  AND ExamStatus.Status = 'Fresh'  AND Semester.Description='1st' OR Semester.Description='2nd' OR Semester.Description='3rd' OR Semester.Description='4th' OR Semester.Description='5th' Group By ClassNo ,StudentName,FatherName,Student.StudentId", con);
                    SqlDataAdapter myDA1 = new SqlDataAdapter(cmd);
                    DataSet myDataSet1 = new DataSet();
                    myDA1.Fill(myDataSet1, "SemesterResult");
                    dataGridView1.DataSource = myDataSet1.Tables["SemesterResult"].DefaultView;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            // Calculate GPA Of Each Semster
                            #region Calculate GPA Of Individual Semester
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select (Sum (GP)/Sum (Subject.CH))[GPA] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId  where  ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Semester.Description='" + cmbSemester.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "' AND ClassNo = '" + row.Cells[1].Value + "' AND Status = 'Fresh' ", con);
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[4].Value = Math.Round(rdr.GetDouble(0), 2).ToString();

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


                            #region Previous Result
                            //check Fourth semester Promoted
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '4th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'Promoted' ";
                            cmd = new SqlCommand(ct);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "FP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            //check Fourth Semester First Probation 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct2 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '4th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'FP & Promoted' ";
                            cmd = new SqlCommand(ct2);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "FP & Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "SP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            //check Fourth Semester Second Probation 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct6 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '4th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'SP & Promoted' ";
                            cmd = new SqlCommand(ct6);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "SP & Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "LP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }

                            //check Fourth Semester Last Probation 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct8 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '4th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'LP & Promoted' ";
                            cmd = new SqlCommand(ct8);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "LP & Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "Dropped from Program";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }


                            //check Fourth Semester Dropped From Program 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct9 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '4th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'Dropped from Program' ";
                            cmd = new SqlCommand(ct9);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[8].Value = "Dropped from Program";

                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            #endregion

                            //Current Record 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct10 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '5th' ) and StudentId = '" + row.Cells[0].Value + "' ";
                            cmd = new SqlCommand(ct10);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[8].Value = rdr.GetString(0).Trim();
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            dataGridView1.Columns["ID"].Visible = false;
                            row.Cells[0].ReadOnly = true;
                            row.Cells[1].ReadOnly = true;
                            row.Cells[2].ReadOnly = true;
                            row.Cells[3].ReadOnly = true;
                            row.Cells[4].ReadOnly = true;
                            row.Cells[5].ReadOnly = true;
                            row.Cells[6].ReadOnly = true;
                            row.Cells[7].ReadOnly = true;
                            row.Cells[8].ReadOnly = true;
                        }
                    }
                    con.Close();

                }
                #endregion
                #region 6th Semester
                else if (cmbSemester.Text == "6th")
                {
                    #region Check Previous  Semester Result
                    //check that the Result of Previous Semester is Exist or not
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string sm1 = "Select Distinct(Departmentid),Sessionid,SemesterId From SemesterResult where Departmentid = (Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '5th' )";
                    cmd = new SqlCommand(sm1);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == false)
                    {
                        MessageBox.Show("5th Semester Result not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;

                    }
                    #endregion
                    #region Check Semester In Result Table
                    //check theat the Result of the Semester is Exist or not
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string sm = "Select Distinct(Departmentid),Sessionid,SemesterId From Result where Departmentid = (Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '6th' )";
                    cmd = new SqlCommand(sm);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == false)
                    {
                        MessageBox.Show("Semester Result Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;

                    }
                    #endregion





                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select  RTRIM(Student.StudentId)[ID], RTRIM(Student.ClassNo)[Class No],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name] ,(select (Sum (GP)/Sum (Subject.CH))[GPA] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId  where  ClassName = '' AND FacultyName = '' AND Semester.Description='' AND Session.Description = '' AND ClassNo = '' AND Status = 'fresh')[GPA]   ,Round(Sum(GP),2)[CGP] ,Round(Sum(Subject.CH),2)[CCH]    ,Round(Sum (GP)/Sum (Subject.CH),2)[CGPA],(Select SemesterResult.Status From SemesterResult where Student.StudentId= SemesterResult.StudentId and DepartmentId = (Select DepartmentId From Department WHere Department.ClassName = '" + cmbClassName.Text.Trim() + "' ANd Department.FacultyName ='" + cmbFaculty.Text.Trim() + "') ANd SessionId = (Select SessionId From Session Where Session.Description = '" + cmbSession.Text.Trim() + "') AND SemesterId = (Select SemesterId From Semester Where Semester.Description = '" + cmbSemester.Text.Trim() + "'))[Status] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId where  ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "'  AND Session.Description = '" + cmbSession.Text.Trim() + "'  AND ExamStatus.Status = 'Fresh'  AND Semester.Description='1st' OR Semester.Description='2nd' OR Semester.Description='3rd' OR Semester.Description='4th' OR Semester.Description='5th'  OR Semester.Description='6th' Group By ClassNo ,StudentName,FatherName,Student.StudentId", con);
                    SqlDataAdapter myDA1 = new SqlDataAdapter(cmd);
                    DataSet myDataSet1 = new DataSet();
                    myDA1.Fill(myDataSet1, "SemesterResult");
                    dataGridView1.DataSource = myDataSet1.Tables["SemesterResult"].DefaultView;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            #region Calculate GPA Of Individual Semester
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select (Sum (GP)/Sum (Subject.CH))[GPA] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId  where  ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Semester.Description='" + cmbSemester.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "' AND ClassNo = '" + row.Cells[1].Value + "' AND Status = 'Fresh' ", con);
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[4].Value = Math.Round(rdr.GetDouble(0), 2).ToString();

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

                            #region Previous Result
                            //check Fifth semester Promoted
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '5th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'Promoted' ";
                            cmd = new SqlCommand(ct);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "FP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            //check Fifth Semester First Probation 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct2 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '5th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'FP & Promoted' ";
                            cmd = new SqlCommand(ct2);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "FP & Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "SP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            //check Fifth Semester Second Probation 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct6 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '5th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'SP & Promoted' ";
                            cmd = new SqlCommand(ct6);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "SP & Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "LP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }

                            //check fifth Semester Last Probation 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct8 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '5th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'LP & Promoted' ";
                            cmd = new SqlCommand(ct8);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "LP & Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "Dropped from Program";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }


                            //check Fifth Semester Dropped From Program 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct9 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '5th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'Dropped from Program' ";
                            cmd = new SqlCommand(ct9);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[8].Value = "Dropped from Program";

                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            #endregion

                            //Current Record 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct10 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '6th' ) and StudentId = '" + row.Cells[0].Value + "' ";
                            cmd = new SqlCommand(ct10);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[8].Value = rdr.GetString(0).Trim();
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            dataGridView1.Columns["ID"].Visible = false;
                            row.Cells[0].ReadOnly = true;
                            row.Cells[1].ReadOnly = true;
                            row.Cells[2].ReadOnly = true;
                            row.Cells[3].ReadOnly = true;
                            row.Cells[4].ReadOnly = true;
                            row.Cells[5].ReadOnly = true;
                            row.Cells[6].ReadOnly = true;
                            row.Cells[7].ReadOnly = true;
                            row.Cells[8].ReadOnly = true;

                        }
                    }
                    con.Close();
                }
                #endregion
                #region 7th Semester
                else if (cmbSemester.Text == "7th")
                {
                    #region Check Previous  Semester Result
                    //check that the Result of Previous Semester is Exist or not
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string sm1 = "Select Distinct(Departmentid),Sessionid,SemesterId From SemesterResult where Departmentid = (Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '6th' )";
                    cmd = new SqlCommand(sm1);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == false)
                    {
                        MessageBox.Show("6th Semester Result not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;

                    }
                    #endregion
                    #region Check Semester In Result Table
                    //check theat the Result of the Semester is Exist or not
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string sm = "Select Distinct(Departmentid),Sessionid,SemesterId From Result where Departmentid = (Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '7th' )";
                    cmd = new SqlCommand(sm);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == false)
                    {
                        MessageBox.Show("Semester Result Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;

                    }
                    #endregion





                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select  RTRIM(Student.StudentId)[ID], RTRIM(Student.ClassNo)[Class No],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name] ,(select (Sum (GP)/Sum (Subject.CH))[GPA] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId  where  ClassName = '' AND FacultyName = '' AND Semester.Description='' AND Session.Description = '' AND ClassNo = '' AND Status = 'fresh')[GPA]   ,Round(Sum(GP),2)[CGP] ,Round(Sum(Subject.CH),2)[CCH]    ,Round(Sum (GP)/Sum (Subject.CH),2)[CGPA],(Select SemesterResult.Status From SemesterResult where Student.StudentId= SemesterResult.StudentId and DepartmentId = (Select DepartmentId From Department WHere Department.ClassName = '" + cmbClassName.Text.Trim() + "' ANd Department.FacultyName ='" + cmbFaculty.Text.Trim() + "') ANd SessionId = (Select SessionId From Session Where Session.Description = '" + cmbSession.Text.Trim() + "') AND SemesterId = (Select SemesterId From Semester Where Semester.Description = '" + cmbSemester.Text.Trim() + "'))[Status] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId where  ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "'  AND Session.Description = '" + cmbSession.Text.Trim() + "'  AND ExamStatus.Status = 'Fresh'  AND Semester.Description='1st' OR Semester.Description='2nd' OR Semester.Description='3rd' OR Semester.Description='4th' OR Semester.Description='5th'  OR Semester.Description='6th' OR Semester.Description='7th' Group By ClassNo ,StudentName,FatherName,Student.StudentId", con);
                    SqlDataAdapter myDA1 = new SqlDataAdapter(cmd);
                    DataSet myDataSet1 = new DataSet();
                    myDA1.Fill(myDataSet1, "SemesterResult");
                    dataGridView1.DataSource = myDataSet1.Tables["SemesterResult"].DefaultView;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            #region Calculate GPA Of Individual Semester
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select (Sum (GP)/Sum (Subject.CH))[GPA] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId  where  ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Semester.Description='" + cmbSemester.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "' AND ClassNo = '" + row.Cells[1].Value + "' AND Status = 'Fresh' ", con);
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[4].Value = Math.Round(rdr.GetDouble(0), 2).ToString();

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

                            #region Previous Result
                            //check Sixth semester Promoted
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '6th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'Promoted' ";
                            cmd = new SqlCommand(ct);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "FP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            //check Sixth Semester First Probation 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct2 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '6th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'FP & Promoted' ";
                            cmd = new SqlCommand(ct2);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "FP & Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "SP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            //check Sixth Semester Second Probation 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct6 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '6th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'SP & Promoted' ";
                            cmd = new SqlCommand(ct6);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "SP & Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "LP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }

                            //check Sixth Semester Last Probation 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct8 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '6th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'LP & Promoted' ";
                            cmd = new SqlCommand(ct8);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "LP & Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "Dropped from Program";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }


                            //check Sixth Semester Dropped From Program 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct9 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '6th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'Dropped from Program' ";
                            cmd = new SqlCommand(ct9);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[8].Value = "Dropped from Program";

                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            #endregion

                            //Current Record 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct10 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '7th' ) and StudentId = '" + row.Cells[0].Value + "' ";
                            cmd = new SqlCommand(ct10);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[8].Value = rdr.GetString(0).Trim();
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            dataGridView1.Columns["ID"].Visible = false;
                            row.Cells[0].ReadOnly = true;
                            row.Cells[1].ReadOnly = true;
                            row.Cells[2].ReadOnly = true;
                            row.Cells[3].ReadOnly = true;
                            row.Cells[4].ReadOnly = true;
                            row.Cells[5].ReadOnly = true;
                            row.Cells[6].ReadOnly = true;
                            row.Cells[7].ReadOnly = true;
                            row.Cells[8].ReadOnly = true;

                        }
                    }
                    con.Close();
                }
                #endregion
                #region 8th Semester
                else if (cmbSemester.Text == "8th")
                {
                    #region Check Previous  Semester Result
                    //check that the Result of Previous Semester is Exist or not
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string sm1 = "Select Distinct(Departmentid),Sessionid,SemesterId From SemesterResult where Departmentid = (Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '7th' )";
                    cmd = new SqlCommand(sm1);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == false)
                    {
                        MessageBox.Show("7th Semester Result not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;

                    }
                    #endregion
                    #region Check Semester In Result Table
                    //check theat the Result of the Semester is Exist or not
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string sm = "Select Distinct(Departmentid),Sessionid,SemesterId From Result where Departmentid = (Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '8th' )";
                    cmd = new SqlCommand(sm);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() == false)
                    {
                        MessageBox.Show("Semester Result Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;

                    }
                    #endregion





                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select  RTRIM(Student.StudentId)[ID], RTRIM(Student.ClassNo)[Class No],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name] ,(select (Sum (GP)/Sum (Subject.CH))[GPA] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId  where  ClassName = '' AND FacultyName = '' AND Semester.Description='' AND Session.Description = '' AND ClassNo = '' AND Status = 'fresh')[GPA]   ,Round(Sum(GP),2)[CGP] ,Round(Sum(Subject.CH),2)[CCH]    ,Round(Sum (GP)/Sum (Subject.CH),2)[CGPA],(Select SemesterResult.Status From SemesterResult where Student.StudentId= SemesterResult.StudentId and DepartmentId = (Select DepartmentId From Department WHere Department.ClassName = '" + cmbClassName.Text.Trim() + "' ANd Department.FacultyName ='" + cmbFaculty.Text.Trim() + "') ANd SessionId = (Select SessionId From Session Where Session.Description = '" + cmbSession.Text.Trim() + "') AND SemesterId = (Select SemesterId From Semester Where Semester.Description = '" + cmbSemester.Text.Trim() + "'))[Status] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId where  ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "'  AND Session.Description = '" + cmbSession.Text.Trim() + "'  AND ExamStatus.Status = 'Fresh'  AND Semester.Description='1st' OR Semester.Description='2nd' OR Semester.Description='3rd' OR Semester.Description='4th' OR Semester.Description='5th'  OR Semester.Description='6th' OR Semester.Description='7th' OR Semester.Description='8th' Group By ClassNo ,StudentName,FatherName,Student.StudentId", con);
                    SqlDataAdapter myDA1 = new SqlDataAdapter(cmd);
                    DataSet myDataSet1 = new DataSet();
                    myDA1.Fill(myDataSet1, "SemesterResult");
                    dataGridView1.DataSource = myDataSet1.Tables["SemesterResult"].DefaultView;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            #region Calculate GPA Of Individual Semester
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            cmd = new SqlCommand("select (Sum (GP)/Sum (Subject.CH))[GPA] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId  where  ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Semester.Description='" + cmbSemester.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "' AND ClassNo = '" + row.Cells[1].Value + "' AND Status = 'Fresh' ", con);
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[4].Value = Math.Round(rdr.GetDouble(0), 2).ToString();

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

                            #region Previous Result
                            //check Seventh semester Promoted
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '7th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'Promoted' ";
                            cmd = new SqlCommand(ct);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "FP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            //check Seventh Semester First Probation 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct2 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '7th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'FP & Promoted' ";
                            cmd = new SqlCommand(ct2);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "FP & Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "SP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            //check Seventh Semester Second Probation 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct6 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '7th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'SP & Promoted' ";
                            cmd = new SqlCommand(ct6);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "SP & Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "LP & Promoted";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }

                            //check Seventh Semester Last Probation 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct8 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '7th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'LP & Promoted' ";
                            cmd = new SqlCommand(ct8);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                if (Convert.ToDouble(row.Cells[7].Value) >= 2.0)
                                {
                                    row.Cells[8].Value = "LP & Promoted";
                                }
                                else if (Convert.ToDouble(row.Cells[7].Value) < 2.0)
                                {
                                    row.Cells[8].Value = "Dropped from Program";
                                }
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }


                            //check Seventh Semester Dropped From Program 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct9 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '7th' ) and StudentId = '" + row.Cells[0].Value + "' and Status = 'Dropped from Program' ";
                            cmd = new SqlCommand(ct9);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[8].Value = "Dropped from Program";

                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            #endregion

                            //Current Record 
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string ct10 = "select Status from SemesterResult where  DepartmentId=(Select DepartmentId from Department where ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId=(Select Sessionid From Session where description = '" + cmbSession.Text.Trim() + "' )  and SemesterId = (Select SemesterId From Semester where Description = '8th' ) and StudentId = '" + row.Cells[0].Value + "' ";
                            cmd = new SqlCommand(ct10);
                            cmd.Connection = con;
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read())
                            {
                                row.Cells[8].Value = rdr.GetString(0).Trim();
                                if ((rdr != null))
                                {
                                    rdr.Close();
                                }
                            }
                            dataGridView1.Columns["ID"].Visible = false;
                            row.Cells[0].ReadOnly = true;
                            row.Cells[1].ReadOnly = true;
                            row.Cells[2].ReadOnly = true;
                            row.Cells[3].ReadOnly = true;
                            row.Cells[4].ReadOnly = true;
                            row.Cells[5].ReadOnly = true;
                            row.Cells[6].ReadOnly = true;
                            row.Cells[7].ReadOnly = true;
                            row.Cells[8].ReadOnly = true;

                        }
                    }
                    con.Close();
                }
                #endregion                           

                if (label1.Text == "Admin")
                {
                    Delete.Enabled = true;
                    button1.Enabled = true;

                }
                else
                {
                    Delete.Enabled = false;
                    button1.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region Avoid Duplicate Data
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select DepartmentId,SessionId,SemesterId from SemesterResult where   DepartmentId = '" + lblDepartmentId.Text.Trim() + "' and sessionid= '" + lblSessionid.Text.Trim() + "' and semesterid='" + lblSemesterId.Text.Trim() + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion
                #region Validation
                if (cmbClassName.Text == "")
                {
                    MessageBox.Show("Please Select Class Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClassName.Focus();
                    return;
                }
                if (cmbFaculty.Text == "")
                {
                    MessageBox.Show("Please Select  Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFaculty.Focus();
                    return;
                }
                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please Select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSession.Focus();
                    return;
                }
                if (cmbSemester.Text == "")
                {
                    MessageBox.Show("Please Select Semester ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSemester.Focus();
                    return;
                }
                #endregion
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into SemesterResult(Status,CGPA,CCH,CGP,GPA,studentId,DepartmentId,SessionId,SemesterId) VALUES (@status,@cgpa,@cch,@cgp,@gpa,@studentid,@departmentid,@sessionid,@semesterid)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                // Add Parameters to Command Parameters collection
                cmd.Parameters.Add(new SqlParameter("@status", System.Data.SqlDbType.NVarChar, 50, "Status"));
                cmd.Parameters.Add(new SqlParameter("@cgpa", System.Data.SqlDbType.Float, 10, "CGPA"));
                cmd.Parameters.Add(new SqlParameter("@cch", System.Data.SqlDbType.Int, 10, "CCH"));
                cmd.Parameters.Add(new SqlParameter("@cgp", System.Data.SqlDbType.Float, 10, "CGP"));
                cmd.Parameters.Add(new SqlParameter("@gpa", System.Data.SqlDbType.Float, 10, "GPA"));
                cmd.Parameters.Add(new SqlParameter("@studentid", System.Data.SqlDbType.Int, 50, "StudentId"));
                cmd.Parameters.Add(new SqlParameter("@departmentid", System.Data.SqlDbType.Int, 10, "DepartmentId"));
                cmd.Parameters.Add(new SqlParameter("@sessionid", System.Data.SqlDbType.Int, 10, "SessionId"));
                cmd.Parameters.Add(new SqlParameter("@semesterid", System.Data.SqlDbType.Int, 50, "SemesterId"));
                // Prepare command for repeated execution
                cmd.Prepare();
                // Data to be inserted
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {


                        cmd.Parameters["@status"].Value = row.Cells[8].Value;
                        cmd.Parameters["@cch"].Value = row.Cells[6].Value;
                        cmd.Parameters["@cgp"].Value = row.Cells[5].Value;
                        cmd.Parameters["@gpa"].Value = row.Cells[4].Value;
                        cmd.Parameters["@cgpa"].Value = row.Cells[7].Value;
                        cmd.Parameters["@studentid"].Value = row.Cells[0].Value;
                        cmd.Parameters["@departmentid"].Value = Convert.ToInt32(lblDepartmentId.Text.Trim());
                        cmd.Parameters["@sessionid"].Value = Convert.ToInt32(lblSessionid.Text.Trim());
                        cmd.Parameters["@semesterid"].Value = Convert.ToInt32(lblSemesterId.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }

                }
                con.Close();
                MessageBox.Show("Successfully saved", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Record_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRecords.frmSemesterResultRecord frm = new frmRecords.frmSemesterResultRecord();
            frm.label10.Text = label1.Text.Trim();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validation
                if (cmbClassName.Text == "")
                {
                    MessageBox.Show("Please Select Class Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClassName.Focus();
                    return;
                }
                if (cmbFaculty.Text == "")
                {
                    MessageBox.Show("Please Select  Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFaculty.Focus();
                    return;
                }
                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please Select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSession.Focus();
                    return;
                }
                if (cmbSemester.Text == "")
                {
                    MessageBox.Show("Please Select Semester ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSemester.Focus();
                    return;
                }
                if (dataGridView1.DataSource == null)
                {
                    MessageBox.Show("Please Select Record First ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSemester.Focus();
                    return;
                }
                #endregion
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update   SemesterResult Set Status= @status,CGPA=@cgpa,CCH=@cch,CGP=@cgp,GPA=@gpa    where studentId=@studentid AND DepartmentId=@departmentid AND SessionId=@sessionid AND SemesterId=@semesterid ";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                // Add Parameters to Command Parameters collection
                cmd.Parameters.Add(new SqlParameter("@status", System.Data.SqlDbType.NVarChar, 50, "Status"));
                cmd.Parameters.Add(new SqlParameter("@cgpa", System.Data.SqlDbType.Float, 10, "CGPA"));
                cmd.Parameters.Add(new SqlParameter("@cch", System.Data.SqlDbType.Int, 10, "CCH"));
                cmd.Parameters.Add(new SqlParameter("@cgp", System.Data.SqlDbType.Float, 10, "CGP"));
                cmd.Parameters.Add(new SqlParameter("@gpa", System.Data.SqlDbType.Float, 10, "GPA"));
                cmd.Parameters.Add(new SqlParameter("@studentid", System.Data.SqlDbType.Int, 50, "StudentId"));
                cmd.Parameters.Add(new SqlParameter("@departmentid", System.Data.SqlDbType.Int, 10, "DepartmentId"));
                cmd.Parameters.Add(new SqlParameter("@sessionid", System.Data.SqlDbType.Int, 10, "SessionId"));
                cmd.Parameters.Add(new SqlParameter("@semesterid", System.Data.SqlDbType.Int, 50, "SemesterId"));
                // Prepare command for repeated execution
                cmd.Prepare();
                // Data to be inserted
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {


                        cmd.Parameters["@status"].Value = row.Cells[8].Value;
                        cmd.Parameters["@cch"].Value = row.Cells[6].Value;
                        cmd.Parameters["@cgp"].Value = row.Cells[5].Value;
                        cmd.Parameters["@gpa"].Value = row.Cells[4].Value;
                        cmd.Parameters["@cgpa"].Value = row.Cells[7].Value;
                        cmd.Parameters["@studentid"].Value = row.Cells[0].Value;
                        cmd.Parameters["@departmentid"].Value = Convert.ToInt32(lblDepartmentId.Text.Trim());
                        cmd.Parameters["@sessionid"].Value = Convert.ToInt32(lblSessionid.Text.Trim());
                        cmd.Parameters["@semesterid"].Value = Convert.ToInt32(lblSemesterId.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }

                }
                con.Close();
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
  

        private void Delete_Click(object sender, EventArgs e)
        {
            #region Validation
            if (cmbClassName.Text == "")
            {
                MessageBox.Show("Please Select Class Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName.Focus();
                return;
            }
            if (cmbFaculty.Text == "")
            {
                MessageBox.Show("Please Select  Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFaculty.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please Select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbSemester.Text == "")
            {
                MessageBox.Show("Please Select Semester ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSemester.Focus();
                return;
            }
      
            #endregion

            if (MessageBox.Show("Do you really want to delete the records?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
               
            }
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "Delete From SemesterResult where DepartmentId = (Select DepartmentId From Department where ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '"+cmbFaculty.Text.Trim()+"')  AnD SessionId = (Select SessionId From Session where Description = '" + cmbSession.Text.Trim() + "') AND SemesterId = (Select SemesterId From Semester where Description = '" + cmbSemester.Text.Trim() + "')";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Delete.Enabled = false;
                    ResetTextFields();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Delete.Enabled = false;
                    ResetTextFields();

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

        private void NewRecord_Click(object sender, EventArgs e)
        {
            ResetTextFields();
        }
        private void ResetTextFields()
        {
            cmbClassName.Text = "";
            cmbFaculty.Text = "";
            cmbSession.Text = "";
            cmbSemester.Text = "";
            dataGridView1.DataSource = null;
            Delete.Enabled = false;
            button1.Enabled = false;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
   

         
        }
    }
}
