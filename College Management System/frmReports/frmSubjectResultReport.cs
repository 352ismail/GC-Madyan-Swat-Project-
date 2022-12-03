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
    public partial class frmSubjectResultReport : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmSubjectResultReport()
        {
            InitializeComponent();
        }

        private void frmSubjectResultReport_Load(object sender, EventArgs e)
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
        private string ExamType = "";
        private void button5_Click(object sender, EventArgs e)
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
            try
            {
                Reports.rptSubjectResultsReport rpt = new Reports.rptSubjectResultsReport();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSets.dstSubjectResult myDS = new DataSets.dstSubjectResult();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select * From Result INNER JOIN Student ON Result.StudentId = Student.StudentId INNER JOIN Department ON Department.DepartmentId = Result.DepartmentId INNER JOIN Session ON Session.SessionId = Result.SessionId INNER JOIN Semester ON Semester.SemesterId = Result.SemesterId INNER JOIN Subject ON Subject.SubjectId = Result.SubjectId INNER JOIN ExamStatus ON ExamStatus.ExamStatusId = Result.ExamStatusId INNER JOIN Employee ON Employee.EmployeeId = Result.EmployeeId INNER JOIN StudentStatus ON StudentStatus.StudentStatusId = Result.StudentStatusId where  Department.ClassName = '" + Course.Text.Trim()+"' AND Department.FacultyName = '"+Branch.Text.Trim()+"' AND Session.Description = '"+Session.Text.Trim()+"' AND Semester.Description = '"+Semester.Text.Trim()+"'  AND Subject.SubjectName = '"+SubjectName.Text.Trim()+"' AND ExamStatus.Status = '"+ExamType.Trim()+"' Order By Student.ClassNo";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "SubjectResult");
                rpt.SetDataSource(myDS);
                crystalReportViewer1.ReportSource = rpt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Course.Text = "";
            Branch.Text = "";
            Session.Text = "";
            Semester.Text = "";
            SubjectName.Text = "";
            rdbFresh.Checked = false;
            rdbMakeup.Checked = false;
            rdbRepeat.Checked = false;
            rdbSCE.Checked = false;
            crystalReportViewer1.ReportSource = null;


        }
    }
}
