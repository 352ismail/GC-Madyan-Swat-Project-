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
    public partial class frmHostelFeePaymentsReport : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmHostelFeePaymentsReport()
        {
            InitializeComponent();
        }

        private void HostelFeePaymentReport_Load(object sender, EventArgs e)
        {
            AutocompleteClass();
            AutocompleteHostelName();
        }

        private void AutocompleteClass()
        {
            try
            {
                cmbCourse.Items.Clear();
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(ClassName) FROM Department", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                foreach (DataRow drow in dtable.Rows)
                {
                    cmbCourse.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AutocompleteHostelName()
        {
            try
            {
                cmbHostelName.Items.Clear();
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(HostelName) FROM Hostel", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                foreach (DataRow drow in dtable.Rows)
                {
                    cmbHostelName.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBranch.Items.Clear();
            cmbBranch.Text = "";
            cmbBranch.Enabled = true;

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(FacultyName) from Department where ClassName = '" + cmbCourse.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbBranch.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbYear.Items.Clear();
            cmbYear.Text = "";
            cmbYear.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Year) from HostelFeePayment ";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbYear.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            #region Validation
            if (cmbCourse.Text == "")
            {
                MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCourse.Focus();
                return;
            }
            if (cmbBranch.Text == "")
            {
                MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbBranch.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbYear.Text == "")
            {
                MessageBox.Show("Please select Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbYear.Focus();
                return;
            }
            #endregion

            try
            {


                Reports.rptHostelFeePaymentReportYear rpt = new Reports.rptHostelFeePaymentReportYear();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSets.dstHostelFeePaymentYear myDS = new DataSets.dstHostelFeePaymentYear();
                //The DataSet you created.


                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from HostelFeePayment  Inner JOin Hostelers On HostelFeePayment.HostelerId = Hostelers.HostelerId Inner JOin Student On Student.StudentId = Hostelers.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN Users On Users.UserId = HostelFeePayment.UserId INNER JOIN Hostel On Hostelers.HostelId = Hostel.HostelId   where Department.ClassName = '" + cmbCourse.Text.Trim() + "' AND Department.FacultyName = '" + cmbBranch.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "' AND HostelFeePayment.Year = '" + cmbYear.Text.Trim()+"'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "HostelFeePaymentYear");
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

        }

        private void cmbHostelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Reports.rptHostelFeePaymentReportDueFee rpt = new Reports.rptHostelFeePaymentReportDueFee();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSets.dstHostelFeePaymentYear myDS = new DataSets.dstHostelFeePaymentYear();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from HostelFeePayment  Inner JOin Hostelers On HostelFeePayment.HostelerId = Hostelers.HostelerId Inner JOin Student On Student.StudentId = Hostelers.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN Users On Users.UserId = HostelFeePayment.UserId INNER JOIN Hostel On Hostelers.HostelId = Hostel.HostelId   where Hostel.HostelName = '" + cmbHostelName.Text.Trim() + "' AND DueFee > 0";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "HostelFeePaymentYear");
                rpt.SetDataSource(myDS);
                crystalReportViewer2.ReportSource = rpt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Tab1Reset();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Tab2Reset();
        }
        private void Tab2Reset()
        {
            cmbHostelName.Text = "";
            crystalReportViewer2.ReportSource = null;
        }
        private void Tab1Reset()
        {
            cmbCourse.Text = "";
            cmbBranch.Text = "";
            cmbSession.Text = "";
            cmbYear.Text = "";
            crystalReportViewer1.ReportSource = null;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            Tab1Reset();
            Tab2Reset();
        }
    }
}
