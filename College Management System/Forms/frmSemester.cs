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
    public partial class frmSemester : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;

        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();


        public frmSemester()
        {
            InitializeComponent();
        }
        private void clearTextFields()
        {
            txtSemesterName.Focus();
            txtSemesterID.Text = "";
            txtSemesterName.Text = "";
            cmbSeason.Text = "";
            SemesterId.Visible = false;
            txtSemesterID.Visible = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;


        }
        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            clearTextFields();
        

        }
        private void frmSemester_Load(object sender, EventArgs e)
        {
         
            
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Validation
            if (txtSemesterName.Text == "")
            {
                MessageBox.Show("Please Select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSemesterName.Focus();
                return;
            }
            if (cmbSeason.Text == "")
            {
                MessageBox.Show("Please Select Season", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSeason.Focus();
                return;
            }
            #endregion
            try
            {
                #region Avoid Duplicate Value
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Description from Semester where Description= '" + txtSemesterName.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Semester Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSemesterName.Text = "";
                    txtSemesterName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into semester(Description,Season) VALUES (@Description,@season)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@Description", System.Data.SqlDbType.NChar, 20, "Description"));
                cmd.Parameters.Add(new SqlParameter("@season", System.Data.SqlDbType.NChar, 20, "Season"));
                cmd.Parameters["@Description"].Value = txtSemesterName.Text.Trim();
                cmd.Parameters["@season"].Value = cmbSeason.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      
        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            #region Validation
            if (txtSemesterID.Text == "")
            {
                MessageBox.Show("Please Select Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSemesterID.Focus();
                return;
            }
            if (txtSemesterName.Text == "")
            {
                MessageBox.Show("Please Select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSemesterName.Focus();
                return;
            }
            if (cmbSeason.Text == "")
            {
                MessageBox.Show("Please Select Season", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSeason.Focus();
                return;
            }
            #endregion
            try
            {
                #region Avoid Duplicate Value
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Description,Season from Semester where Description= '" + txtSemesterName.Text.Trim() + "' AND Season = '"+cmbSeason.Text.Trim()+"'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Semester Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSemesterName.Text = "";
                    txtSemesterName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion


                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update semester set Description=@description,Season = @season where SemesterId=@semesterid";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@semesterid", System.Data.SqlDbType.Int, 10, "SemesterID"));
                cmd.Parameters.Add(new SqlParameter("@description", System.Data.SqlDbType.NChar, 20, "Description"));
                cmd.Parameters.Add(new SqlParameter("@season", System.Data.SqlDbType.NChar, 20, "Season"));
                cmd.Parameters["@semesterid"].Value = Convert.ToInt32(txtSemesterID.Text);
                cmd.Parameters["@description"].Value = txtSemesterName.Text.Trim();
                cmd.Parameters["@season"].Value = cmbSeason.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                //check in SubjectDetails Table
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct1 = "Select Distinct(SubjectDetails.SemesterId)  From SubjectDetails INNER JOIN Semester On SubjectDetails.SemesterId=Semester.SemesterId  where Semester.Description ='" + txtSemesterName.Text.Trim() + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearTextFields();
                    btnDelete.Enabled = false;
                    btnUpdate_record.Enabled = false;
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                //check in SemesterFees Table
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "Select Distinct(SemesterFees.SemesterId)  From SemesterFees INNER JOIN Semester On SemesterFees.SemesterId=Semester.SemesterId  where Semester.Description ='" + txtSemesterName.Text.Trim() + "'";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearTextFields();
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
                string ct3 = "Select Distinct(Result.SemesterId)  From Result INNER JOIN Semester On Result.SemesterId=Semester.SemesterId  where Semester.Description ='" + txtSemesterName.Text.Trim() + "'";
                cmd = new SqlCommand(ct3);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearTextFields();
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
                string ct4 = "Select Distinct(SemesterResult.SemesterId)  From SemesterResult INNER JOIN Semester On SemesterResult.SemesterId=Semester.SemesterId  where Semester.Description ='" + txtSemesterName.Text.Trim() + "'";
                cmd = new SqlCommand(ct4);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearTextFields();
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
                string cq = "delete from Semester where SemesterId=@semesterid;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@semesterid", System.Data.SqlDbType.Int, 10, "SemesterId"));
                cmd.Parameters["@semesterid"].Value = Convert.ToInt32(txtSemesterID.Text);
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearTextFields();
                    btnDelete.Enabled = false;
                    btnUpdate_record.Enabled = false;

                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearTextFields();
                    btnDelete.Enabled = false;
                    btnUpdate_record.Enabled = false;
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

        private void btnGetDetails_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSemesterRecord frm = new frmSemesterRecord();
            frm.label1.Text = label1.Text;
            frm.Show();
        }

        private void txtSemesterName_TextChanged(object sender, EventArgs e)
        {
            txtSemesterName.Text = txtSemesterName.Text.Trim();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }

      
    }

