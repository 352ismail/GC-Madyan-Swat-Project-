using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace College_Management_System
{
    public partial class frmHostel : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
       

        public frmHostel()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            txtHostelID.Text = "";
            lblHostelId.Visible = false;
            HostelName.Text = "";
            HostelFees.Text = "";
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            btnSave.Enabled = true;
            HostelName.Focus();
            txtHostelID.Visible = false;

        }

        private void Autocomplete()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT  distinct HostelName FROM Hostel", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Hostel");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["HostelName"].ToString());

                }
                HostelName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                HostelName.AutoCompleteCustomSource = col;
                HostelName.AutoCompleteMode = AutoCompleteMode.Suggest;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmHostel_Load(object sender, EventArgs e)
        {
            Autocomplete();
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Validation
            if (HostelName.Text == "")
            {
                MessageBox.Show("Please Enter Hostel name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HostelName.Focus();
                return;
            }
            if (HostelFees.Text == "")
            {
                MessageBox.Show("Please enter Hostel Fees", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HostelFees.Focus();
                return;
            }
            #endregion
            try
            {
                #region Avoid Duplicate Data
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select HostelName from Hostel where HostelName= '" + HostelName.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Hostel  Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    HostelName.Text = "";
                    HostelName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Hostel(HostelName,HostelFee) VALUES (@hostelname,@hostelfee)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@hostelname", System.Data.SqlDbType.VarChar, 250, "HostelName"));
                cmd.Parameters.Add(new SqlParameter("@hostelfee", System.Data.SqlDbType.Int, 10, "HostelFee"));
                cmd.Parameters["@hostelname"].Value = HostelName.Text.Trim();
                cmd.Parameters["@hostelfee"].Value = Convert.ToInt32(HostelFees.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                Autocomplete();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   

        private void btnDelete_Click(object sender, EventArgs e)
        {
            #region Validation
            if (txtHostelID.Text == "")
            {
                MessageBox.Show("Please Enter Hostel Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHostelID.Focus();
                return;
            }
            if (HostelName.Text == "")
            {
                MessageBox.Show("Please Enter Hostel name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HostelName.Focus();
                return;
            }
            if (HostelFees.Text == "")
            {
                MessageBox.Show("Please Enter Hostel Fees", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HostelFees.Focus();
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
                #region Check In Tables
                //Check in Hostelers Table
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct3 = "Select Distinct (Hostelers.HostelId)  From Hostelers INNER JOIN Hostel On Hostel.HostelId= Hostelers.HostelId  where  Hostel.HostelName = '" + HostelName.Text.Trim() + "' and Hostel.HostelFee= '" + HostelFees.Text.Trim() + "'";
                cmd = new SqlCommand(ct3);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                // check in hostelFeePayment Table
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct4 = "Select Distinct (HostelFeePayment.HostelId)  From HostelFeePayment INNER JOIN Hostel On Hostel.HostelId= HostelFeePayment.HostelId  where  Hostel.HostelName = '" + HostelName.Text.Trim() + "' and Hostel.HostelFee= '" + HostelFees.Text.Trim() + "'";
                cmd = new SqlCommand(ct4);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion
                //delete Record
                con = new SqlConnection(cs.DBConn);
                con.Open();         
                string cq = "delete from Hostel where HostelId=@hostelid;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@hostelid", System.Data.SqlDbType.Int, 10, "HostelId"));
                cmd.Parameters["@hostelid"].Value = Convert.ToInt32(txtHostelID.Text);
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

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            #region Validation
            if (txtHostelID.Text == "")
            {
                MessageBox.Show("Please Enter Hostel Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHostelID.Focus();
                return;
            }
            if (HostelName.Text == "")
            {
                MessageBox.Show("Please Enter Hostel name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HostelName.Focus();
                return;
            }
            if (HostelFees.Text == "")
            {
                MessageBox.Show("Please Enter Hostel Fees", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HostelFees.Focus();
                return;
            }
            #endregion
            try
            {
                #region Avoid Duplicate Data
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select HostelName,HostelFee from Hostel where HostelName= '" + HostelName.Text.Trim() + "' AND HostelFee = '"+HostelFees.Text.Trim()+"'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Hostel  Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    HostelName.Text = "";
                    HostelName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update hostel set HostelName=@hostelname,HostelFee=@hostelfee where HostelId=@hostelid";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@hostelid", System.Data.SqlDbType.Int, 10, "HostelId"));
                cmd.Parameters.Add(new SqlParameter("@hostelname", System.Data.SqlDbType.VarChar, 250, "HostelName"));
                cmd.Parameters.Add(new SqlParameter("@hostelfee", System.Data.SqlDbType.Int, 10, "HostelFee"));
                cmd.Parameters["@hostelid"].Value = Convert.ToInt32(txtHostelID.Text);
                cmd.Parameters["@hostelname"].Value = HostelName.Text;
                cmd.Parameters["@hostelfee"].Value = Convert.ToInt32(HostelFees.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
                Autocomplete();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetDetails_Click(object sender, EventArgs e)
        {

            this.Hide();
            frmHostelRecord frm = new frmHostelRecord();
            frm.label1.Text = label1.Text;
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void txtHostelFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void HostelName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
    }
}
