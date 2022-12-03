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

namespace College_Management_System.frmReports
{
    public partial class frmSemestersResultReport : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmSemestersResultReport()
        {
            InitializeComponent();
        }

        private void frmSemestersResultReport_Load(object sender, EventArgs e)
        {
            AutocompleteClassName();
        }
        private void AutocompleteClassName()
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
                    cmbClassName.Items.Add(rdr[0]);
                    cmbClassName2.Items.Add(rdr[0]);
                }
                con.Close();
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
            cmbFaculty.Focus();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(FacultyName) from Department where ClassName = '" + cmbClassName.Text + "'";
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
            cmbSession.Focus();
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
                    cmbSession.Items.Add(rdr[0]);
                }
                con.Close();

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
            cmbSemester.Focus();
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
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbClassName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFaculty2.Items.Clear();
            cmbFaculty2.Text = "";
            cmbFaculty2.Enabled = true;
            cmbFaculty2.Focus();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(FacultyName) from Department where ClassName = '" + cmbClassName2.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbFaculty2.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFaculty2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSession2.Items.Clear();
            cmbSession2.Text = "";
            cmbSession2.Enabled = true;
            cmbSession2.Focus();
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
                    cmbSession2.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSession2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbClassNo2.Items.Clear();
            cmbClassNo2.Text = "";
            cmbClassNo2.Enabled = true;
            cmbClassNo2.Focus();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Student.ClassNo) from SemesterResult  Inner JOin Student On Student.StudentId = SemesterResult.StudentId INNER JOIN Department On Student.DepartmentId = Department.DepartmentId INNER JOIN Session ON Session.SessionId = Student.SessionId where Department.ClassName = '" + cmbClassName2.Text.Trim() + "' AND Department.FacultyName = '" + cmbFaculty2.Text.Trim() + "' AND Session.Description = '" + cmbSession2.Text.Trim() + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbClassNo2.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            #region Validation
            if (cmbClassName.Text == "")
            {
                MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName.Focus();
                return;
            }
            if (cmbFaculty.Text == "")
            {
                MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFaculty.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbSemester.Text == "")
            {
                MessageBox.Show("Please select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSemester.Focus();
                return;
            }
            #endregion
            try
            {
                Reports.rptSingleSemesterResult rpt = new Reports.rptSingleSemesterResult();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSets.dstSingleSemesterResult myDS = new DataSets.dstSingleSemesterResult();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "Select * From SemesterResult INNER JOIN Student On Student.StudentId = SemesterResult.StudentId INNER JOIN Department On Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN Semester ON Semester.SemesterId = SemesterResult.SemesterId INNER JOIN StudentRegistration ON Student.StudentId = StudentRegistration.StudentId where ClassName = '"+cmbClassName.Text.Trim()+"' AND FacultyName = '"+cmbFaculty.Text.Trim()+"' AND Session.Description = '"+cmbSession.Text.Trim()+"' AND Semester.Description= '"+cmbSemester.Text.Trim()+"'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "SingleSemesterResult");
                rpt.SetDataSource(myDS);
                crystalReportViewer1.ReportSource = rpt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region Validation
            if (cmbClassName2.Text == "")
            {
                MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName2.Focus();
                return;
            }
            if (cmbFaculty2.Text == "")
            {
                MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFaculty2.Focus();
                return;
            }
            if (cmbSession2.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession2.Focus();
                return;
            }
            if (cmbClassNo2.Text == "")
            {
                MessageBox.Show("Please select Class No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassNo2.Focus();
                return;
            }
            #endregion
            try
            {
                Reports.rptSingleStudentResultReport rpt = new Reports.rptSingleStudentResultReport();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSets.dstSingleStudentResult myDS = new DataSets.dstSingleStudentResult();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "Select * From SemesterResult INNER JOIN Student On Student.StudentId = SemesterResult.StudentId INNER JOIN Department On Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN Semester ON Semester.SemesterId = SemesterResult.SemesterId INNER JOIN StudentRegistration ON Student.StudentId = StudentRegistration.StudentId where ClassName = '" + cmbClassName2.Text.Trim() + "' AND FacultyName = '" + cmbFaculty2.Text.Trim() + "' AND Session.Description = '" + cmbSession2.Text.Trim() + "' AND Student.ClassNo ='" + cmbClassNo2.Text.Trim()+"'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "SingleStudentResult");
                rpt.SetDataSource(myDS);
                crystalReportViewer2.ReportSource = rpt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Tab1Reset()
        {
            cmbClassName.Text = "";
            cmbFaculty.Text = "";
            cmbSession.Text = "";
            cmbSemester.Text = "";
            crystalReportViewer1.ReportSource = null;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Tab1Reset();
        }
        private void Tab2Reset()
        {
            cmbClassName2.Text = "";
            cmbFaculty2.Text = "";
            cmbSession2.Text = "";
            cmbClassNo2.Text = "";
            crystalReportViewer2.ReportSource = null;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Tab2Reset();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            Tab1Reset();
            Tab2Reset();
        }
    }
}
