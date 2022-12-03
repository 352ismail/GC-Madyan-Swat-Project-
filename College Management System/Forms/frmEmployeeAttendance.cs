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
    public partial class frmEmployeeAttendance : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();

        public frmEmployeeAttendance()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void AttendanceDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmEmployeeAttendance_Load(object sender, EventArgs e)
        {
            AutoCompleteEmployee();
        }

        private  void AutoCompleteEmployee()
        {
            try
            {
                var _with1 = listView1;
                _with1.Clear();
                _with1.Columns.Add("Employee Id.", 120, HorizontalAlignment.Left);
                _with1.Columns.Add("Employee Name", 150, HorizontalAlignment.Center);
                _with1.Columns.Add("Designation", 150, HorizontalAlignment.Center);
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select EmployeeId,EmployeeName,Designation from Employee  order by EmployeeId", con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var item = new ListViewItem();
                    item.Text = rdr[0].ToString().Trim();
                    item.SubItems.Add(rdr[1].ToString().Trim());
                    item.SubItems.Add(rdr[2].ToString().Trim());
                    listView1.Items.Add(item);
                   

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
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(StaffName) from Employee where Designation = '" + /*cmbDesignation.Text + */"'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                   //cmbEmployeeName.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset()
        {
            AttendanceDate.Text = System.DateTime.Today.ToString();
            btnSave.Enabled = true;
      if (label1.Text == "Admin")
            {
                Update_record.Enabled = true;
                Delete.Enabled = true;
            }
            else
            {
                Update_record.Enabled = false;
                Delete.Enabled = false;
            }
        }

        private void NewRecord_Click(object sender, EventArgs e)
        {
            Reset();
            AutoCompleteEmployee();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select AttDate from EmployeeAttendance where  AttDate= '" + AttendanceDate.Text + "'";
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
                    for (int i = listView1.Items.Count - 1; i >= 0; i--)
                    {
                        con = new SqlConnection(cs.DBConn);
                        if (listView1.Items[i].Checked == true)
                        {
                            txtStatus.Text = "Present";
                        }
                        else
                        {
                            txtStatus.Text = "Absent";
                        }
                        string cd = "insert into EmployeeAttendance(AttDate,Status,EmployeeId) VALUES (@attdate,@status,@employeeid)";
                        cmd = new SqlCommand(cd);
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@employeeid", listView1.Items[i].SubItems[0].Text);
                        cmd.Parameters.AddWithValue("@Attdate",AttendanceDate.Text);
                        cmd.Parameters.AddWithValue("@status", txtStatus.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    MessageBox.Show("Successfully saved", "Emplyee Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEmployeeAttendanceRecord frm = new frmEmployeeAttendanceRecord();
            frm.label25.Text = label1.Text.Trim();
            frm.Show();
         
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }

        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                //Delete Record
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "Delete From EmployeeAttendance where AttDate = '"+AttendanceDate.Text+"'";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
              
             
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                   
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

        private void Update_record_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = listView1.Items.Count - 1; i >= 0; i--)
                {
                    con = new SqlConnection(cs.DBConn);
                    if (listView1.Items[i].Checked == true)
                    {
                        txtStatus.Text = "Present";
                    }
                    else
                    {
                        txtStatus.Text = "Absent";
                    }
                    string cd = "Update  EmployeeAttendance set Status= @status where EmployeeId =  @employeeid AND AttDate = @attdate";

                    cmd = new SqlCommand(cd);

                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@employeeid", listView1.Items[i].SubItems[0].Text);
                    cmd.Parameters.AddWithValue("@Attdate", AttendanceDate.Text);
                    cmd.Parameters.AddWithValue("@status", txtStatus.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Successfully Updated", "Employee Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
