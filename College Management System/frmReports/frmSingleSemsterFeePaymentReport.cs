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
    public partial class frmSingleSemsterFeePaymentReport : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmSingleSemsterFeePaymentReport()
        {
            InitializeComponent();
        }

        private void frmSingleSemsterFeePaymentReport_Load(object sender, EventArgs e)
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
                string ct = "select distinct RTRIM(Student.ClassNo) from SemesterFeePayment  Inner JOin Student On Student.StudentId = SemesterFeePayment.StudentId INNER JOIN Department On Student.DepartmentId = Department.DepartmentId INNER JOIN Session ON Session.SessionId = Student.SessionId where Department.ClassName = '" + cmbClassName2.Text.Trim() + "' AND Department.FacultyName = '" + cmbFaculty2.Text.Trim() + "' AND Session.Description = '" + cmbSession2.Text.Trim() + "'";
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

        private void cmbClassNo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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

                #endregion

                Reports.rptSingleStudentSemesterFeePayment rpt = new Reports.rptSingleStudentSemesterFeePayment();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSets.dstSingleSemesterFeePayment myDS = new DataSets.dstSingleSemesterFeePayment();
                //The DataSet you created.
                frmStudent frm = new frmStudent();
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from SemesterFeePayment  Inner JOin Student On Student.StudentId = SemesterFeePayment.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN SemesterFees On SemesterFeePayment.SemesterFeeId = SemesterFees.SemesterFeeId INNER JOIN Semester ON Semester.SemesterId = SemesterFees.SemesterId  where Department.ClassName = '" + cmbClassName2.Text.Trim() + "' AND Department.FacultyName = '" + cmbFaculty2.Text.Trim() + "' AND Session.Description = '" + cmbSession2.Text.Trim() + "' AND Student.ClassNo = '" + cmbClassNo2.Text.Trim() + "' ";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "SingleSemesterFeePayment");
                rpt.SetDataSource(myDS);
                crystalReportViewer2.ReportSource = rpt;

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
            cmbSession2.Text="";
            cmbClassNo2.Text = "";
            crystalReportViewer2.ReportSource = null;

        }
    }
}
