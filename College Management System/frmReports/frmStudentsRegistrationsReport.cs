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
    public partial class frmStudentsRegistrationsReport : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmStudentsRegistrationsReport()
        {
            InitializeComponent();
        }

        private void frmStudentsRegistrationsReport_Load(object sender, EventArgs e)
        {
            AutocompleClassName();
        }
        public void AutocompleClassName()
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

        private void Button1_Click(object sender, EventArgs e)
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
            #endregion
            try
            {
                if (rdbSSC.Checked == true)
                {
                    Reports.rptStudentsRegistration rpt = new Reports.rptStudentsRegistration();
                    //The report you created.
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSets.dstStudentsRegistration myDS = new DataSets.dstStudentsRegistration();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "Select * From StudentRegistration Inner Join Student On StudentRegistration.StudentId = Student.StudentId INNER JOIN RegistrationDeficiency ON RegistrationDeficiency.RegistrationDeficiencyId = StudentRegistration.RegistrationDeficiencyId INNER JOIN RegistrationStatus ON RegistrationStatus.RegistrationStatusId = StudentRegistration.RegistrationStatusId INNER JOIN Department On Department.DepartmentId = Student.DepartmentId INNER JOin Session ON Session.SessionId = Student.SessionId Where Department.ClassName = '" + cmbClassName.Text.Trim() + "' AND Department.FacultyName ='" + cmbFaculty.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "' AND StudentRegistration.Class = 'SSC'";
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "StudentRegistration");
                    rpt.SetDataSource(myDS);
                    crystalReportViewer1.ReportSource = rpt;
                }
                else if (rdbHSSC.Checked == true)
                {
                    Reports.rptStudentsRegistration rpt = new Reports.rptStudentsRegistration();
                    //The report you created.
                    SqlConnection myConnection = default(SqlConnection);
                    SqlCommand MyCommand = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    DataSets.dstStudentsRegistration myDS = new DataSets.dstStudentsRegistration();
                    //The DataSet you created.
                    myConnection = new SqlConnection(cs.DBConn);
                    MyCommand.Connection = myConnection;
                    MyCommand.CommandText = "Select * From StudentRegistration Inner Join Student On StudentRegistration.StudentId = Student.StudentId INNER JOIN RegistrationDeficiency ON RegistrationDeficiency.RegistrationDeficiencyId = StudentRegistration.RegistrationDeficiencyId INNER JOIN RegistrationStatus ON RegistrationStatus.RegistrationStatusId = StudentRegistration.RegistrationStatusId INNER JOIN Department On Department.DepartmentId = Student.DepartmentId INNER JOin Session ON Session.SessionId = Student.SessionId Where Department.ClassName = '" + cmbClassName.Text.Trim() + "' AND Department.FacultyName ='" + cmbFaculty.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "' AND StudentRegistration.Class = 'HSSC'";
                    MyCommand.CommandType = CommandType.Text;
                    myDA.SelectCommand = MyCommand;
                    myDA.Fill(myDS, "StudentRegistration");
                    rpt.SetDataSource(myDS);
                    crystalReportViewer1.ReportSource = rpt;
                }
                else
                {
                    MessageBox.Show("Please Select SSC/HSSC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

   

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmbClassName.Text = "";
            cmbFaculty.Text = "";
            cmbSession.Text = "";
            crystalReportViewer1.ReportSource = null;
        }
    }
}
