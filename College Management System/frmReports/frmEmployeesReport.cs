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
    public partial class frmEmployeesReport : Form
    {


        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
 
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmEmployeesReport()
        {
            InitializeComponent();
        }

        private void frmEmployeesReport_Load(object sender, EventArgs e)
        {
            AutocompleteDesignation();
        }

        private void AutocompleteDesignation()
        {
            try
            {
                cmbDesignation.Items.Clear();
                cmbDesignation.Text = "";
                cmbDesignation.Enabled = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "SELECT distinct RTRIM(Designation) FROM Employee";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbDesignation.Items.Add(rdr[0]);
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
            if (cmbDesignation.Text == "")
            {
                MessageBox.Show("Please select Designaion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbDesignation.Focus();
                return;
            }

            try
            {

           
                Reports.rptEmployees rpt = new Reports.rptEmployees();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSets.dstEmployees myDS = new DataSets.dstEmployees();
                //The DataSet you created.


                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select *  from Employee where  Designation = '" + cmbDesignation.Text + "'Order By EmployeeName";

                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Employee");
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
            cmbDesignation.Text = "";
            crystalReportViewer1.ReportSource = null;
        }
    }
}
