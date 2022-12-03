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

namespace College_Management_System.frmRecords
{
    public partial class frmEventManagedBy : Form
    {

        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();


        public frmEventManagedBy()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            cmbEmployeeName.Text = "";
            cmbDesignation.Text = "";
            btnSave.Enabled = true;
            cmbEmployeeName.Text = "";
            DateFrom.Text = DateTime.Now.ToString();
            DateTo.Text = DateTime.Now.ToString();
            listView1.Items.Clear();
            if (label5.Text == "Admin")
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
        }

        private void frmEventManagedBy_Load(object sender, EventArgs e)
        {
            AutoCompleteDesignation();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AutoCompleteDesignation()
        {
            try
            {
                cmbDesignation.Items.Clear();
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

        private void AutoCompleteEVents()
        {
            try
            {
                var _with1 = listView1;
                _with1.Clear();
                _with1.Columns.Add("Event Id.", 80, HorizontalAlignment.Left);
                _with1.Columns.Add("Event Name", 150, HorizontalAlignment.Center);
                _with1.Columns.Add("Starting Date", 100, HorizontalAlignment.Center);
                _with1.Columns.Add("Ending Date", 100, HorizontalAlignment.Center);
                _with1.Columns.Add("Activities", 200, HorizontalAlignment.Center);
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select EventId,EventName,StartingDate,EndingDate,Activities  from Event where StartingDate Between @date1 and @date2 Order By EventName ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " Date").Value = DateTo.Value.Date;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var item = new ListViewItem();
                    item.Text = rdr[0].ToString().Trim();
                    item.SubItems.Add(rdr[1].ToString().Trim());
                    item.SubItems.Add(rdr[2].ToString().Trim());
                    item.SubItems.Add(rdr[3].ToString().Trim());
                    item.SubItems.Add(rdr[4].ToString().Trim());
                    listView1.Items.Add(item);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AutoCompleteEVents();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Validation 
            if (cmbDesignation.Text == "")
            {
                MessageBox.Show("Please Select Designation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbDesignation.Focus();
                return;
            }
            if (cmbEmployeeName.Text == "")
            {
                MessageBox.Show("Please select Employee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbEmployeeName.Focus();
                return;
            }
            #endregion
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select EmployeeId from EventManagedBy  where EmployeeId =(Select EmployeeId From Employee Where EmployeeName = '"+cmbEmployeeName.Text.Trim()+"' ANd Designation = '"+cmbDesignation.Text.Trim()+"')";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Employee Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                  string cd = "insert into EventManagedBy(EventId,EmployeeId) VALUES (@eventid,(Select EmployeeId From Employee Where EmployeeName = '" + cmbEmployeeName.Text.Trim() + "' AND Designation= '"+cmbDesignation.Text.Trim()+"'))";
                                  cmd = new SqlCommand(cd);
                                  cmd.Connection = con;
                                  cmd.Parameters.AddWithValue("@eventid", listView1.Items[i].SubItems[0].Text);
                                  con.Open();
                                  cmd.ExecuteNonQuery();
                                  con.Close();
                                     
                             }           
                         }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                MessageBox.Show("Successfully saved", "Event Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Delete_Click(object sender, EventArgs e)
        {
            #region Validation
            if (cmbDesignation.Text == "")
            {
                MessageBox.Show("Please Select Designation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbDesignation.Focus();
                return;
            }
            if (cmbEmployeeName.Text == "")
            {
                MessageBox.Show("Please Select Employee Name ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbEmployeeName.Focus();
                return;
            }
            #endregion
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
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from EventManagedBy  where EmployeeId  = (Select EmployeeId From Employee Where EmployeeName = '" + cmbEmployeeName.Text.Trim() + "' AND Employee.Designation = '"+cmbDesignation.Text.Trim()+"')";
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
            #region Validation
            if (cmbDesignation.Text == "")
            {
                MessageBox.Show("Please Select Designation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbDesignation.Focus();
                return;
            }
            if (cmbEmployeeName.Text == "")
            {
                MessageBox.Show("Please select Employee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbEmployeeName.Focus();
                return;
            }
            #endregion
            try
            {
                for (int i = listView1.Items.Count - 1; i >= 0; i--)
                {
                    con = new SqlConnection(cs.DBConn);
                    if (listView1.Items[i].Checked == true)
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct = "select EventId from EventManagedBy  where EmployeeId =(Select EmployeeId From Employee Where EmployeeName = '" + cmbEmployeeName.Text.Trim() + "' ANd Designation = '" + cmbDesignation.Text.Trim() + "') AND EventId = '"+ listView1.Items[i].SubItems[0].Text +"'";
                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {                          
                            if ((rdr != null))
                            {
                                rdr.Close();
                            }
                            continue;
                        }
                        con.Close();

                        con = new SqlConnection(cs.DBConn);
                        string cd = "insert into EventManagedBy(EventId,EmployeeId) VALUES (@eventid,(Select EmployeeId From Employee Where EmployeeName = '" + cmbEmployeeName.Text.Trim() + "' AND Designation= '" + cmbDesignation.Text.Trim() + "'))";
                        cmd = new SqlCommand(cd);
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@eventid", listView1.Items[i].SubItems[0].Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    
                        con.Close();
                    }
                    else if (listView1.Items[i].Checked == false)
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct = "select EventId from EventManagedBy  where EmployeeId =(Select EmployeeId From Employee Where EmployeeName = '" + cmbEmployeeName.Text.Trim() + "' ANd Designation = '" + cmbDesignation.Text.Trim() + "') AND EventId = '" + listView1.Items[i].SubItems[0].Text + "'";
                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cq = "delete from EventManagedBy  where EmployeeId  = (Select EmployeeId From Employee Where EmployeeName = '" + cmbEmployeeName.Text.Trim() + "' AND Employee.Designation = '" + cmbDesignation.Text.Trim() + "') AND EventId = '" + listView1.Items[i].SubItems[0].Text + "'";
                            cmd = new SqlCommand(cq);
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();

                            if ((rdr != null))
                            {
                                rdr.Close();
                            }
                            continue;
                        }
                        con.Close();
                    }
                }
                MessageBox.Show("Successfully Updated", "Event Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewRecord_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRecords.frmEventManagedByRecord frm = new frmEventManagedByRecord();
            frm.label25.Text = label5.Text.Trim();
            frm.Show();
        }
    }
}
