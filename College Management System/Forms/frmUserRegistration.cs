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
    public partial class frmUserRegistration : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;

        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();


        public frmUserRegistration()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutocompleteUserName();
            autoRoleCompleteRole();

        }
        private void  autoRoleCompleteRole()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();


                string ct = "select distinct RTRIM(Description) from Role ";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmbUsertype.Items.Clear();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbUsertype.Items.Add(rdr[0]);
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
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtContactNo.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            btnRegister.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            cmbUsertype.Text = "";
        }
        private void NewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            #region Validation
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Please enter username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }
            if (cmbUsertype.Text == "")
            {
                MessageBox.Show("Please select user type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            if (txtContactNo.Text == "")
            {
                MessageBox.Show("Please enter contact no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContactNo.Focus();
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Please enter email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
            #endregion
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select username from Users where Username=@username";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@username", System.Data.SqlDbType.NChar, 50, "Username"));
                cmd.Parameters["@username"].Value = txtUsername.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Username Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();

                string cb = "insert into Users(UserName,Password,ContactNo,Email,Name,DateOfJoining,RoleId) VALUES (@username,@password,@contactno,@email,@name,@dateofjoining,(Select RoleId From Role Where Description = '"+cmbUsertype.Text.Trim()+"'))";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@username", System.Data.SqlDbType.NChar, 70, "UserName"));
                cmd.Parameters.Add(new SqlParameter("@password", System.Data.SqlDbType.NChar, 50, "Password"));
                cmd.Parameters.Add(new SqlParameter("@contactno", System.Data.SqlDbType.NChar, 20, "ContactNo"));
                cmd.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.NChar, 50, "Email"));
                cmd.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.NChar, 70, "Name"));
                cmd.Parameters.Add(new SqlParameter("@dateofjoining", System.Data.SqlDbType.NChar, 50, "DateOfJoining"));
                cmd.Parameters["@username"].Value = txtUsername.Text.Trim();
                cmd.Parameters["@password"].Value = txtPassword.Text;
                cmd.Parameters["@contactno"].Value = txtContactNo.Text;
                cmd.Parameters["@email"].Value = txtEmail.Text;
                cmd.Parameters["@name"].Value = txtName.Text;
                cmd.Parameters["@dateofjoining"].Value = DateTime.Now;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Sucessfully Register", "User Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AutocompleteUserName();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUserRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

     
    

        private void Name_Of_User_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void Username_Validating(object sender, CancelEventArgs e)
        {
       
        }

        private void GetDetails_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUserRegistrationRecord frm = new frmUserRegistrationRecord();
            frm.label8.Text = label8.Text;
            frm.Show();

        }

        private void AutocompleteUserName()
        {

            con = new SqlConnection(cs.DBConn);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT UserName FROM Users", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Users");


            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            int i = 0;
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                col.Add(ds.Tables[0].Rows[i]["UserName"].ToString());

            }
            txtUsername.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtUsername.AutoCompleteCustomSource = col;
            txtUsername.AutoCompleteMode = AutoCompleteMode.Suggest;

            con.Close();
        }

        private void Update_record_Click(object sender, EventArgs e)
        {
            #region Validation
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Please enter username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }
            if (cmbUsertype.Text == "")
            {
                MessageBox.Show("Please select user type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            if (txtContactNo.Text == "")
            {
                MessageBox.Show("Please enter contact no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContactNo.Focus();
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Please enter email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
            #endregion
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();

                string cb = "update Users set Password=@password,ContactNo=@contactno,Email=@email,Name=@name,RoleId = (Select RoleId From Role Where Description = '" + cmbUsertype.Text.Trim() + "') where UserName=@username";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@username", System.Data.SqlDbType.NChar, 50, "UserName"));
                cmd.Parameters.Add(new SqlParameter("@password", System.Data.SqlDbType.NChar, 50, "Password"));
                cmd.Parameters.Add(new SqlParameter("@contactno", System.Data.SqlDbType.NChar, 20, "ContactNo"));
                cmd.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.NChar, 70, "Email"));
                cmd.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.NChar, 50, "Name"));
                cmd.Parameters["@username"].Value = txtUsername.Text.Trim();
                cmd.Parameters["@password"].Value = txtPassword.Text;
                cmd.Parameters["@contactno"].Value = txtContactNo.Text;
                cmd.Parameters["@email"].Value = txtEmail.Text;
                cmd.Parameters["@name"].Value = txtName.Text;
                cmd.ExecuteReader();
                con.Close();              
                MessageBox.Show("Successfully updated", "User Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AutocompleteUserName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                //check In Hostel Fee Payment Table
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "Select Distinct(HostelFeePayment.UserId) From HostelFeePayment  INNER JOIN Users ON Users.UserId=HostelFeePayment.UserId  where Users.UserName = '"+txtUsername.Text.Trim()+"'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AutocompleteUserName();
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                //check In Other Transaction Table
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct1 = "Select Distinct(OtherTransaction.UserId) From OtherTransaction  INNER JOIN Users ON Users.UserId=OtherTransaction.UserId  where Users.UserName = '"+txtUsername.Text.Trim()+"'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AutocompleteUserName();
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }


                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from Users where UserName='" + txtUsername.Text + "'";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AutocompleteUserName();
                    Reset();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    AutocompleteUserName();
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

        private void cmbUsertype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "Admin")
            {
                btnDelete.Enabled = true;
                btnUpdate_record.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnUpdate_record.Enabled = false;
            }
            btnDelete.Enabled = true;
            btnUpdate_record.Enabled = true;
            try
            {
                txtUsername.Text = txtUsername.Text.TrimEnd();
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT Password,Name,ContactNo,Email,Role.Description FROM Users INNER JOin ROle On Role.RoleId = Users.RoleId WHERE UserName = '" + txtUsername.Text.Trim() + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    txtPassword.Text = (rdr.GetString(0).Trim());
                    txtName.Text = (rdr.GetString(1).Trim());
                    txtContactNo.Text = (rdr.GetString(2).Trim());
                    txtEmail.Text = (rdr.GetString(3).Trim());
                    cmbUsertype.Text = (rdr.GetString(4).Trim());
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

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[0-9a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtEmail.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtEmail.Text))
                {
                    MessageBox.Show("invalid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9_]");
            if (txtUsername.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtUsername.Text))
                {
                    MessageBox.Show("only letters,numbers and underscore is allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        private void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "")
                {
                    MessageBox.Show("Please enter username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select UserName from Users where UserName=@find";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 30, "UserName"));
                cmd.Parameters["@find"].Value = txtUsername.Text;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Username not available", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!rdr.Read())
                {
                    MessageBox.Show("Username available", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername.Focus();

                }
                if ((rdr != null))
                {
                    rdr.Close();
                }






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
    }
}