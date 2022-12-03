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
    public partial class frmSubjectInfo : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
       

        public frmSubjectInfo()
        {
            InitializeComponent();
        }
        private void ClearTextFields()
        {
            SubjectName.Focus();
            SubjectName.Text = "";         
            cmbCreditHour.Text = "";
            subjectId.Text = "";
            txtSubjectCode.Text = "";
            subjectId.Visible = false;
            lblSubjectId.Visible = false;
            btnSave.Enabled = true;
            Delete.Enabled = false;
            Update_record.Enabled = false;      
        }
        private void NewRecord_Click(object sender, EventArgs e)
        {
            ClearTextFields();
        }
    
        private void frmSubjectInfo_Load(object sender, EventArgs e)
        {
            Autocomplete();

        }

        private void Autocomplete()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT SubjectName FROM Subject", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Subject");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["Subjectname"].ToString());
                }
                SubjectName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                SubjectName.AutoCompleteCustomSource = col;
                SubjectName.AutoCompleteMode = AutoCompleteMode.Suggest;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Validation
            if (txtSubjectCode.Text == "")
            {
                MessageBox.Show("Please Enter Subject Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSubjectCode.Focus();
                return;
            }
            if (SubjectName.Text == "")
            {
                MessageBox.Show("Please enter Subject Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SubjectName.Focus();
                return;
            }

            if (cmbCreditHour.Text == "")
            {
                MessageBox.Show("Please select Credit Hours", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCreditHour.Focus();
                return;
            }
            #endregion
            try
            {
                #region Avoid Duplicate Values
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select SubjectName,SubjectCode from Subject where SubjectName='" + SubjectName.Text + "' and SubjectCode = '" + txtSubjectCode.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Subject Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SubjectName.Text = "";
                    txtSubjectCode.Text = "";
                    cmbCreditHour.Text = "";
                    SubjectName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Subject(SubjectName,CH,SubjectCode) VALUES (@subjectName,@ch,@subjectcode)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@subjectName", System.Data.SqlDbType.VarChar, 150, "SubjectName"));
                cmd.Parameters.Add(new SqlParameter("@subjectcode", System.Data.SqlDbType.VarChar, 100, "SubjectCode"));
                cmd.Parameters.Add(new SqlParameter("@ch", System.Data.SqlDbType.Int, 10, "CH"));
                cmd.Parameters["@subjectName"].Value = SubjectName.Text.Trim();
                cmd.Parameters["@subjectcode"].Value = txtSubjectCode.Text.Trim();
                cmd.Parameters["@ch"].Value = cmbCreditHour.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Autocomplete();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update_record_Click(object sender, EventArgs e)
        {
            #region Validation
            if (txtSubjectCode.Text == "")
            {
                MessageBox.Show("Please Enter Subject Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSubjectCode.Focus();
                return;
            }
            if (subjectId.Text == "")
            {
                MessageBox.Show("Please Enter Subject Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                subjectId.Focus();
                return;
            }
            if (SubjectName.Text == "")
            {
                MessageBox.Show("Please enter Subject name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SubjectName.Focus();
                return;
            }

            if (cmbCreditHour.Text == "")
            {
                MessageBox.Show("Please select Credit Hours", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCreditHour.Focus();
                return;
            }
            #endregion
            try
            {
                #region Avoid Duplicate Values
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select SubjectName,SubjectCode,CH from Subject where SubjectName='" + SubjectName.Text + "' and SubjectCode = '" + txtSubjectCode.Text + "' AND CH = '" + Convert.ToInt32(cmbCreditHour.Text.Trim()) + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Subject Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SubjectName.Text = "";
                    txtSubjectCode.Text = "";
                    cmbCreditHour.Text = "";
                    SubjectName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update Subject set SubjectName=@subjectname,CH=@ch,SubjectCode=@subjectcode where subjectId = @subjectid";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@subjectname", System.Data.SqlDbType.VarChar, 250, "SubjectName"));
                cmd.Parameters.Add(new SqlParameter("@subjectcode", System.Data.SqlDbType.VarChar, 100, "SubjectCode"));
                cmd.Parameters.Add(new SqlParameter("@ch", System.Data.SqlDbType.NChar, 10, "CH"));
                cmd.Parameters.Add(new SqlParameter("@subjectid", System.Data.SqlDbType.NChar, 10, "SubjectId"));
                cmd.Parameters["@subjectname"].Value = SubjectName.Text.Trim();
                cmd.Parameters["@subjectcode"].Value = txtSubjectCode.Text.Trim();
                cmd.Parameters["@ch"].Value = cmbCreditHour.Text.Trim();
                cmd.Parameters["@subjectid"].Value = Convert.ToInt32(subjectId.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Autocomplete();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (subjectId.Text == "")
            {
                MessageBox.Show("Please Enter subject Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                subjectId.Focus();
                return;
            }

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
                //Check in SubjectDetails Table
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "Select Distinct(SubjectDetails.SubjectId)  From SubjectDetails INNER JOIN Subject On SubjectDetails.SubjectId=Subject.SubjectId  where Subject.SubjectName ='" + SubjectName.Text.Trim() + "' AnD Subject.SubjectCode ='" + txtSubjectCode.Text.Trim() + "' AND Subject.CH = '" + cmbCreditHour.Text.Trim() + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearTextFields();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                //Check in Result Table
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct1 = "Select Distinct(Result.SubjectId)  From Result INNER JOIN Subject On Result.SubjectId=Subject.SubjectId  where Subject.SubjectName ='" + SubjectName.Text.Trim() + "' AnD Subject.SubjectCode ='" + txtSubjectCode.Text.Trim() + "' AND Subject.CH = '" + cmbCreditHour.Text.Trim() + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearTextFields();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion
                //Delete Data From Subject
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from Subject where SubjectName ='" + SubjectName.Text.Trim() + "'";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextFields();
                    Autocomplete();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextFields();
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

        private void ViewRecord_Click(object sender, EventArgs e)
             {
                
            this.Hide();
            frmSubjectInfoRecord frm = new frmSubjectInfoRecord();
            frm.label1.Text = label1.Text;
            frm.Show();



        } 

        private void button1_Click(object sender, EventArgs e)
        {
 
            SubjectName.Text = "";
            cmbCreditHour.Text = "";
            btnSave.Enabled = true;
            SubjectName.Focus();

        }

        private void SubjectName_TextChanged(object sender, EventArgs e)
        {

        }

        private void SubjectName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtSubjectCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar)|| char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);

        }

        private void cmbCreditHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
    }
    }

