using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace College_Management_System
{
    public partial class frmBatch : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null; 
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmBatch()
        {
            InitializeComponent();
        }

        private void ClearTextFields()
        {
            Session.Focus();
            lblBatchId.Visible = false;
            Session.Text = "";
            SessionId.Text = "";
            SessionId.Visible = false;
            isActive.Checked = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
        }

        private void frmBatch_Load(object sender, EventArgs e)
        {
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            ClearTextFields();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Validation
            if (Session.Text == "    -" || Session.Text == String.Empty)
            {
                MessageBox.Show("Please Enter Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Session.Focus();
                return;
            }
            #endregion
            try
            {
                #region Avoid Duplicate Data 
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Description from Session where Description= '" + Session.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Session Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearTextFields();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Session (Description,IsActive) VALUES (@description,@isactive)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@Description", System.Data.SqlDbType.NChar, 20, "Description"));
                cmd.Parameters.Add(new SqlParameter("@isactive", System.Data.SqlDbType.Bit));
                cmd.Parameters["@Description"].Value = Session.Text.Trim();
                if (isActive.Checked == true)
                {
                    cmd.Parameters["@isactive"].Value = true;
                }
                else
                {
                    cmd.Parameters["@isactive"].Value = false;
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
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
                #region Check In Tables
                //check in Student Table 
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "Select Distinct(Student.SessionId) From Student  INNER JOIN Session ON Student.SessionId=Session.SessionId where  Session.Description = '" + Session.Text.Trim() + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnDelete.Enabled = false;
                    btnUpdate_record.Enabled = false;
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                //check in SubjectDetails Table 
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct1 = "Select Distinct(SubjectDetails.SessionId) From SubjectDetails  INNER JOIN Session ON SubjectDetails.SessionId=Session.SessionId where  Session.Description = '" + Session.Text.Trim() + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnDelete.Enabled = false;
                    btnUpdate_record.Enabled = false;
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                //check in Result Table 
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "Select Distinct(Result.SessionId) From Result  INNER JOIN Session ON Result.SessionId=Session.SessionId where  Session.Description = '" + Session.Text.Trim() + "'";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnDelete.Enabled = false;
                    btnUpdate_record.Enabled = false;
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }


                //check in SemesterResult Table 
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct3 = "Select Distinct(SemesterResult.SessionId) From SemesterResult  INNER JOIN Session ON SemesterResult.SessionId=Session.SessionId where  Session.Description = '" + Session.Text.Trim() + "'";
                cmd = new SqlCommand(ct3);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnDelete.Enabled = false;
                    btnUpdate_record.Enabled = false;
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from Session where SessionId='" + SessionId.Text.Trim() + "'";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextFields();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextFields();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
                #region Avoid Duplicate Values
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Description,IsActive from Session where Description= '" + Session.Text + "' AND isActive = @isactive";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@isactive", System.Data.SqlDbType.Bit));
                if (isActive.Checked == true)
                {
                    cmd.Parameters["@isactive"].Value = true;
                }
                else
                {
                    cmd.Parameters["@isactive"].Value = false;
                }

                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Session Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearTextFields();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update Session set Description=@description , IsActive=@isactive where SessionId = @sessionid";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@Description", System.Data.SqlDbType.NChar, 20, "Description"));
                cmd.Parameters.Add(new SqlParameter("@isactive", System.Data.SqlDbType.Bit));
                cmd.Parameters.Add(new SqlParameter("@sessionid", System.Data.SqlDbType.Int, 10, "SessionId"));
                cmd.Parameters["@Description"].Value = Session.Text.Trim();
                cmd.Parameters["@sessionid"].Value = Convert.ToInt32(SessionId.Text.Trim());
                if (isActive.Checked == true)
                {
                    cmd.Parameters["@isactive"].Value = true;
                }
                else
                {
                    cmd.Parameters["@isactive"].Value = false;
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated", "Batch Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmBatchRecord frm = new frmBatchRecord();
            frm.label1.Text = label6.Text;
            frm.Show();
        }

        private void btnGetDetails_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmBatchRecord frm = new frmBatchRecord();
            frm.label1.Text = label6.Text;
            frm.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void isActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Session_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
