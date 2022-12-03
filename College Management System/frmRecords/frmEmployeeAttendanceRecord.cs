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

namespace College_Management_System
{
    public partial class frmEmployeeAttendanceRecord : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();

        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();



        public frmEmployeeAttendanceRecord()
        {
            InitializeComponent();
        }

        private void frmEmployeeAttendanceRecord_Load(object sender, EventArgs e)
        {
            AutocompleDesignation();
        }

        public void AutocompleDesignation()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Designation) from Employee ";
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

        private void cmbDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbEmployeeName.Items.Clear();
            cmbEmployeeName.Text = "";
            cmbEmployeeName.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(EmployeeName) from Employee where Designation = '" + cmbDesignation.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbEmployeeName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            { 
                var _with1 = listView2;
                _with1.Clear();
                _with1.Columns.Add("Staff Name", 120, HorizontalAlignment.Left);
                _with1.Columns.Add("Designation", 120, HorizontalAlignment.Center);
                _with1.Columns.Add("Total Attendance", 140, HorizontalAlignment.Center);
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  Distinct RTrim(Employee.EmployeeName)[Employee Name],RTrim(Employee.Designation)[Designation],Count(EmployeeAttendance.Status)[Status] from EmployeeAttendance  Inner JOin Employee On EmployeeAttendance.EmployeeId = Employee.EmployeeId  where AttDate Between @date1 and @date2  AND Status = 'Present' Group By EmployeeName,Designation", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " AttDate").Value = dateTimePicker1.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " AttDate").Value = dateTimePicker2.Value.Date;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var item = new ListViewItem();
                    item.Text = rdr[0].ToString();
                    item.SubItems.Add(rdr[1].ToString());
                    item.SubItems.Add(rdr[2].ToString());
                    listView2.Items.Add(item);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
        private void Tab2Reset()
        {
            dateTimePicker1.Text = DateTime.Today.ToString();
            dateTimePicker2.Text = DateTime.Today.ToString();
            listView2.Items.Clear();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            Tab2Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label20.Visible = false;
            label19.Visible = false;

            if (cmbDesignation.Text == "")
            {
                MessageBox.Show("Please select Designation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbDesignation.Focus();
                return;
            }
            if (cmbEmployeeName.Text == "")
            {
                MessageBox.Show("Please select Employee Name ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbEmployeeName.Focus();
                return;
            }
            // Calculate Total Attendance
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  Count(EmployeeAttendance.Status)[Status] from EmployeeAttendance  Inner JOin Employee On EmployeeAttendance.EmployeeId = Employee.EmployeeId  where AttDate Between @date1 and @date2 and Employee.EmployeeName ='" + cmbEmployeeName.Text.Trim() + "' and Employee.Designation = '" + cmbDesignation.Text.Trim() + "'AND Status = 'Present'", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " AttDate").Value = dateTimePicker4.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " AttDate").Value = dateTimePicker3.Value.Date;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    label19.Text = rdr.GetInt32(0).ToString();
                    label20.Visible = true;
                    label19.Visible = true;
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

            // Calculate Total Absentees
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  Count(EmployeeAttendance.Status)[Status] from EmployeeAttendance  Inner JOin Employee On EmployeeAttendance.EmployeeId = Employee.EmployeeId  where AttDate Between @date1 and @date2 and Employee.EmployeeName ='" + cmbEmployeeName.Text.Trim() + "' and Employee.Designation = '" + cmbDesignation.Text.Trim() + "'AND Status = 'Absent'", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " AttDate").Value = dateTimePicker4.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " AttDate").Value = dateTimePicker3.Value.Date;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    label11.Text = rdr.GetInt32(0).ToString();
                    label10.Visible = true;
                    label11.Visible = true;
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

        private void cmbEmployeeName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Tab1Reset()
        {
            cmbDesignation.Text = "";
            cmbEmployeeName.Text = "";
            dateTimePicker4.Text = DateTime.Today.ToString();
            dateTimePicker3.Text = DateTime.Today.ToString();
            label19.Text = "0";
            label11.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tab1Reset();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            Tab1Reset();
            Tab2Reset();
        }

        private void frmEmployeeAttendanceRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmEmployeeAttendance frm = new frmEmployeeAttendance();
            frm.label1.Text = label25.Text.Trim();
            if (label25.Text == "Admin")
            {
                frm.Update_record.Enabled = true;
                frm.Delete.Enabled = true;
            }
            else
            {
                frm.Update_record.Enabled = false;
                frm.Delete.Enabled = false;
            }
            frm.Show();
            
        }
    }
}
