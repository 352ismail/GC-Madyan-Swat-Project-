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
using Excel = Microsoft.Office.Interop.Excel;

namespace College_Management_System
{
    public partial class frmSubjectResultRecord : Form
    {


        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmSubjectResultRecord()
        {
            InitializeComponent();
        }

        private void frmSubjectResultRecord_Load(object sender, EventArgs e)
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
                Course.Items.Clear();

                foreach (DataRow drow in dtable.Rows)
                {
                    Course.Items.Add(drow[0].ToString());
                    Course1.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            Branch.Items.Clear();
            Branch.Text = "";
            Branch.Enabled = true;

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(FacultyName) from Department where ClassName= '" + Course.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Branch.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Items.Clear();
            Session.Text = "";
            Session.Enabled = true;

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Description) from Session";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Session.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Session_SelectedIndexChanged(object sender, EventArgs e)
        {
            Semester.Items.Clear();
            Semester.Text = "";
            Semester.Enabled = true;

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();


                string ct = "select distinct RTRIM(Description) from Semester ";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Semester.Items.Add(rdr[0]);
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
            SubjectName.Items.Clear();
            SubjectName.Text = "";
            SubjectName.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct Subject.SubjectName from SubjectDetails Inner Join Subject On SubjectDetails.SubjectId = Subject.SubjectId Inner Join Department On SubjectDetails.DepartmentId =Department.DepartmentId INNER JOIN Semester On Semester.SemesterId = SubjectDetails.SemesterId  where ClassName ='" + Course.Text.Trim() + "' and FacultyName = '" + Branch.Text.Trim() + "' and  Description = '" + Semester.Text.Trim() + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SubjectName.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string ExamType = "";
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validation 
                if (Course.Text == "")
                {
                    MessageBox.Show("Please select Class Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Course.Focus();
                    return;
                }
                if (Branch.Text == "")
                {
                    MessageBox.Show("Please select FacultyName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Branch.Focus();
                    return;
                }
                if (Semester.Text == "")
                {
                    MessageBox.Show("Please select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Semester.Focus();
                    return;
                }
                if (SubjectName.Text == "")
                {
                    MessageBox.Show("Please select SubjectName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SubjectName.Focus();
                    return;
                }
                if (Session.Text == "")
                {
                    MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Session.Focus();
                    return;
                }
                if (rdbFresh.Checked == false && rdbRepeat.Checked == false && rdbMakeup.Checked == false && rdbSCE.Checked == false)
                {
                    MessageBox.Show("Please select Exam Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Session.Focus();
                    return;
                }

                if (rdbFresh.Checked == true)
                {
                    ExamType = "Fresh";
                }
                else if (rdbRepeat.Checked == true)
                {
                    ExamType = "Repeat";
                }
                else if (rdbMakeup.Checked == true)
                {
                    ExamType = "Makeup";
                }
                else if (rdbSCE.Checked == true)
                {
                    ExamType = "SCE";
                }
                #endregion
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(Student.ClassNo)[Class No], RTrim(Student.StudentName)[Student Name],RTrim(Mid)[Mid], RTRIM(Presentation)[Pres:],RTRIM(Assignment)[Assignment],RTRIM(Quizz)[Quizz],RTRIM(Lab)[Lab],RTRIM(Final)[Final],RTRIM(TotalObtainedMarks)[Total Marks],RTRIM(Grade)[Grade] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Department.DepartmentId = Result.DepartmentId INNER JOIN Session ON Session.SessionId = Result.SessionId INNER JOIN Semester ON Semester.SemesterId = Result.SemesterId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId INNER JOIN ExamStatus ON ExamStatus.ExamStatusId = Result.ExamStatusId where  Department.ClassName = '" + Course.Text.Trim() + "' AND Department.FacultyName = '" + Branch.Text.Trim() + "' AND Session.Description = '" + Session.Text.Trim() + "' AND Semester.Description = '" + Semester.Text.Trim() + "'  AND Subject.SubjectName = '" + SubjectName.Text.Trim() + "' AND ExamStatus.Status = '" + ExamType.Trim() + "' Order By Student.ClassNo", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Result");
                dataGridView1.DataSource = myDataSet.Tables["Result"].DefaultView;
                con.Close();
                // count Total Students
                #region Total Students
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Count(Result.StudentId) From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Department.DepartmentId = Result.DepartmentId INNER JOIN Session ON Session.SessionId = Result.SessionId INNER JOIN Semester ON Semester.SemesterId = Result.SemesterId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId INNER JOIN ExamStatus ON ExamStatus.ExamStatusId = Result.ExamStatusId   where  Department.ClassName = '" + Course.Text.Trim() + "' AND Department.FacultyName = '" + Branch.Text.Trim() + "' AND Session.Description = '" + Session.Text.Trim() + "' AND Semester.Description = '" + Semester.Text.Trim() + "'  AND Subject.SubjectName = '" + SubjectName.Text.Trim() + "' AND ExamStatus.Status = '" + ExamType.Trim() + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    lblTotalStudents.Text = rdr.GetInt32(0).ToString();
                    label19.Visible = true;
                    lblTotalStudents.Visible = true;
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
                // count Pass Students
                #region Pass Students
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Count(Result.StudentId) From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Department.DepartmentId = Result.DepartmentId INNER JOIN Session ON Session.SessionId = Result.SessionId INNER JOIN Semester ON Semester.SemesterId = Result.SemesterId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId INNER JOIN ExamStatus ON ExamStatus.ExamStatusId = Result.ExamStatusId   where  Department.ClassName = '" + Course.Text.Trim() + "' AND Department.FacultyName = '" + Branch.Text.Trim() + "' AND Session.Description = '" + Session.Text.Trim() + "' AND Semester.Description = '" + Semester.Text.Trim() + "'  AND Subject.SubjectName = '" + SubjectName.Text.Trim() + "' AND ExamStatus.Status = '" + ExamType.Trim() + "' AND StudentStatusId = 1", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    lblPassedStudents.Text = rdr.GetInt32(0).ToString();
                    label21.Visible = true;
                    lblPassedStudents.Visible = true;
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
                //Count Fail Students
                #region Fail Students
                con = new SqlConnection(cs.DBConn);
                con.Open();              
                cmd = new SqlCommand("select Count(Result.StudentId) From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Department.DepartmentId = Result.DepartmentId INNER JOIN Session ON Session.SessionId = Result.SessionId INNER JOIN Semester ON Semester.SemesterId = Result.SemesterId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId INNER JOIN ExamStatus ON ExamStatus.ExamStatusId = Result.ExamStatusId   where  Department.ClassName = '" + Course.Text.Trim() + "' AND Department.FacultyName = '" + Branch.Text.Trim() + "' AND Session.Description = '" + Session.Text.Trim() + "' AND Semester.Description = '" + Semester.Text.Trim() + "'  AND Subject.SubjectName = '" + SubjectName.Text.Trim() + "' AND ExamStatus.Status = '" + ExamType.Trim() + "' AND StudentStatusId = 2", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Fail.Text = rdr.GetInt32(0).ToString();
                    label23.Visible = true;
                    Fail.Visible = true;
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
        private void Tab1Reset()
        {
            Course.Text = "";
            Branch.Text = "";
            Session.Text = "";
            Semester.Text = "";
            SubjectName.Text = "";
            dataGridView1.DataSource = null;
            label19.Visible = false;
            label21.Visible = false;
            label23.Visible = false;
            lblTotalStudents.Visible = false;
            lblPassedStudents.Visible = false;
            Fail.Visible = false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Tab1Reset();
        }

        private void Course1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Branch1.Items.Clear();
            Branch1.Text = "";
            Branch1.Enabled = true;

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();


                string ct = "select distinct RTRIM(FacultyName) from Department where ClassName= '" + Course1.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Branch1.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Branch1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session1.Items.Clear();
            Session1.Text = "";
            Session1.Enabled = true;

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
                    Session1.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Session1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Semester1.Items.Clear();
            Semester1.Text = "";
            Semester1.Enabled = true;
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
                    Semester1.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Semester1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassNo.Items.Clear();
            ClassNo.Text = "";
            ClassNo.Enabled = true;

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(ClassNo) from Student where DepartmentId=(Select DepartmentId From Department where  ClassName = '" + Course1.Text.Trim() + "' and FacultyName ='" + Branch1.Text.Trim() + "') and SessionId = (Select SessionId From Session where Description = '" + Session1.Text.Trim() + "') ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ClassNo.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string ExamType1 = "";
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                #region Validation
                if (Course1.Text == "")
                {
                    MessageBox.Show("Please select Class Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Course1.Focus();
                    return;
                }
                if (Branch1.Text == "")
                {
                    MessageBox.Show("Please select FacultyName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Branch1.Focus();
                    return;
                }
                if (Semester1.Text == "")
                {
                    MessageBox.Show("Please select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Semester1.Focus();
                    return;
                }
                if (Session1.Text == "")
                {
                    MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Session1.Focus();
                    return;
                }
                if (ClassNo.Text == "")
                {
                    MessageBox.Show("Please select class No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClassNo.Focus();
                    return;
                }
                if (rdbFresh1.Checked == false && rdbRepeat1.Checked == false && rdbMakeup1.Checked == false && rdbSCE1.Checked == false)
                {
                    MessageBox.Show("Please select Exam Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Session.Focus();
                    return;
                }
                if (rdbFresh1.Checked == true)
                {
                    ExamType1 = "Fresh";
                }
                else if (rdbRepeat1.Checked == true)
                {
                    ExamType1 = "Repeat";
                }
                else if (rdbMakeup1.Checked == true)
                {
                    ExamType1 = "Makeup";
                }
                else if (rdbSCE1.Checked == true)
                {
                    ExamType1 = "SCE";
                }
                #endregion
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(Subject.SubjectName)[SubjectName],RTrim(Result.Mid)[Mid], RTRIM(Result.Presentation)[Pres:],RTRIM(Assignment)[Assignment],RTRIM(Quizz)[Quizz],RTRIM(Final)[Final],RTRIM(TotalObtainedMarks)[Total Marks] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId  where  ClassName = '" + Course1.Text.Trim() + "' AND FacultyName = '" + Branch1.Text.Trim() + "' AND Semester.Description='" + Semester1.Text.Trim() + "' AND Session.Description = '" + Session1.Text.Trim() + "' AND ClassNo = '" + ClassNo.Text.Trim() + "' AND Status = '" + ExamType1.Trim() + "' ", con);
                SqlDataAdapter myDA1 = new SqlDataAdapter(cmd);
                DataSet myDataSet1 = new DataSet();
                myDA1.Fill(myDataSet1, "Result");
                dataGridView022.DataSource = myDataSet1.Tables["Result"].DefaultView;
                con.Close();
                #region Count  Fails Subjects
                try
                {
                    FailSub.Text = "0";
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select Count (Subject.SubjectName) From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId  where ClassName = '" + Course1.Text.Trim() + "' AND FacultyName = '" + Branch1.Text.Trim() + "' AND Semester.Description='" + Semester1.Text.Trim() + "' AND Session.Description = '" + Session1.Text.Trim() + "' AND ClassNo = '" + ClassNo.Text.Trim() + "' AND Status = '" + ExamType1.Trim() + "' AND StudentStatusId = 2 ", con);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FailSub.Text = rdr.GetInt32(0).ToString();
                        label33.Visible = true;
                        FailSub.Visible = true;
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
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
                #region Calculate  GPA 
                GPA.Text = "0";
                if (rdbFresh1.Checked == true)
                {
                    try
                    {

                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = new SqlCommand("select (Sum (GP)/Sum (Subject.CH))[GPA] From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Result.DepartmentId = Department.DepartmentId INNER JOIN Session ON Result.SessionId = Session.SessionId INNER JOIN Semester ON Result.SemesterId = Semester.SemesterId INNER JOIN ExamStatus ON Result.ExamStatusId = ExamStatus.ExamStatusId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId  where  ClassName = '" + Course1.Text.Trim() + "' AND FacultyName = '" + Branch1.Text.Trim() + "' AND Semester.Description='" + Semester1.Text.Trim() + "' AND Session.Description = '" + Session1.Text.Trim() + "' AND ClassNo = '" + ClassNo.Text.Trim() + "' AND Status = '" + ExamType1.Trim() + "' ", con);
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            GPA.Text = Math.Round(rdr.GetDouble(0), 2).ToString();
                            label3.Visible = true;
                            GPA.Visible = true;
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
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tab2Reset()
        {
            Course1.Text = "";
            Branch1.Text = "";
            Session1.Text = "";
            Semester1.Text = "";
            ClassNo.Text = "";
            GPA.Text = "0";
            FailSub.Text = "0";
            dataGridView022.DataSource = null;
            Branch1.Enabled = false;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Tab2Reset();
        }

        private void frmSubjectResultRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmSubjectResult frm = new frmSubjectResult();
            frm.label5.Text = label10.Text;
            frm.label6.Text = label11.Text;
            frm.Show();
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

        private void dataGridView022_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView022.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView022.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void ExportExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                xlApp.Columns[3].Cells.NumberFormat = "@";
                rowsTotal = dataGridView1.RowCount - 1;
                colsTotal = dataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView1.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView022.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                xlApp.Columns[3].Cells.NumberFormat = "@";
                rowsTotal = dataGridView022.RowCount - 1;
                colsTotal = dataGridView022.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView022.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView022.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            Tab1Reset();
            Tab2Reset();
        }
    }


    
}
