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
    public partial class frmTranscriptReport : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmTranscriptReport()
        {
            InitializeComponent();
        }

        private void frmTranscriptReport_Load(object sender, EventArgs e)
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
                    cmbClassName2.Items.Add(rdr[0]);
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
                string ct = "select distinct RTRIM(StudentRegistration.RollNo) from StudentRegistration  Inner JOin Student On Student.StudentId = StudentRegistration.StudentId INNER JOIN Department On Student.DepartmentId = Department.DepartmentId INNER JOIN Session ON Session.SessionId = Student.SessionId where Department.ClassName = '"+cmbClassName2.Text.Trim()+"' AND Department.FacultyName = '"+cmbFaculty2.Text.Trim()+"' AND Session.Description = '"+cmbSession2.Text.Trim()+"' ";
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
                Reports.rptTransCripts rpt = new Reports.rptTransCripts();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSets.dstTranscript myDS = new DataSets.dstTranscript();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "Select * From Student Inner JOIN Department On Department.DepartmentId = Student.DepartmentId  Inner JOIN Session On Session.SessionId = Student.SessionId INNER JOIN StudentRegistration ON StudentRegistration.StudentId = Student.StudentId   INNER JOIN Result ON Result.StudentId = Student.StudentId INNER JOIn Semester ON Semester.SemesterId = Result.SemesterId  INNER JOIN Subject On Result.SubjectId = Subject.SubjectId INNER JOIN SubjectDetails ON Subject.SubjectId = SubjectDetails.SubjectId INNER JOIN SemesterResult ON Semester.SemesterId = SemesterResult.SemesterId where ClassName = '"+cmbClassName2.Text.Trim()+"' AND FacultyName = '"+cmbFaculty2.Text.Trim()+"' AND Session.Description = '"+cmbSession2.Text.Trim()+"' AND StudentRegistration.RollNo = '"+cmbClassNo2.Text.Trim()+"' AND Result.ExamstatusId = 1";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Transcript");
                rpt.SetDataSource(myDS);
                crystalReportViewer1.ReportSource = rpt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cmbClassName2.Text = "";
            cmbFaculty2.Text = "";
            cmbSession2.Text = "";
            cmbClassNo2.Text = "";
            crystalReportViewer1.ReportSource = null;

        }
    }
}
