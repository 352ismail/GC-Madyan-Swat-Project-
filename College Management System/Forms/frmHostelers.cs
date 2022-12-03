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
    public partial class frmHostelers : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
       

        public frmHostelers()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            cmbCLassName.Text = "";
            cmbFacultyName.Text = "";
            cmbSession.Text = "";
            cmbCLassNo.Text = "";
            StudentName.Text = "";
            FatherName.Text = "";
            cmbHostelName.Text = "";
            JoiningDate.Text = DateTime.Today.ToString();
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            cmbCLassName.Focus();
        }

        private void AutocompleteHostelName()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Hostelname) from Hostel ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbHostelName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AutocompleClassName()
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
                    cmbCLassName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmHostelers_Load(object sender, EventArgs e)
        {
            AutocompleteHostelName();
            AutocompleClassName();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        #region Validation
            if (cmbCLassNo.Text == "")
            {
                MessageBox.Show("Please select Class No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCLassNo.Focus();
                return;
            }
            if (cmbHostelName.Text == "")
            {
                MessageBox.Show("Please select hostel name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbHostelName.Focus();
                return;
            }
            if (cmbCLassName.Text == "")
            {
                MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCLassName.Focus();
                return;
            }
            if (cmbFacultyName.Text == "")
            {
                MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFacultyName.Focus();
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
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select StudentId from Hostelers where StudentId = ( Select StudentId From Student where ClassNo = '" + cmbCLassNo.Text + "'and  DepartmentId = (Select DepartmentId From Department where ClassName = '"+cmbCLassName.Text.Trim()+"' and FacultyName = '"+cmbFacultyName.Text.Trim()+"') and SessionId = (Select SessionId From Session where Description = '"+cmbSession.Text.Trim()+"') ) ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Student Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbCLassNo.Text = "";
                    cmbCLassNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Hostelers(StudentId,HostelId,JoiningDate) VALUES (( Select StudentId From Student where ClassNo = '" + cmbCLassNo.Text + "'and  DepartmentId = (Select DepartmentId From Department where ClassName = '" + cmbCLassName.Text.Trim() + "' and FacultyName = '" + cmbFacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Description = '" + cmbSession.Text.Trim() + "')),(Select HostelId From Hostel WHere HOstelName = '" + cmbHostelName.Text.Trim() + "'),@joiningdate)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@joiningdate", System.Data.SqlDbType.NVarChar, 50, "JoiningDate"));
                cmd.Parameters["@joiningdate"].Value = JoiningDate.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Hostelers Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void ScholarNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT StudentName,FatherName FROM Student WHERE ClassNo = '" + cmbCLassNo.Text + "' and DepartmentId = (Select DepartmentId From Department where CLassName = '" + cmbCLassName.Text.Trim() + "' and FacultyName= '" + cmbFacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Description = '" + cmbSession.Text.Trim() + "')";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    StudentName.Text = rdr.GetString(0).Trim();
                    FatherName.Text = rdr.GetString(1).Trim();
                    cmbHostelName.Focus();
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

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            #region Validation 
            if (cmbCLassNo.Text == "")
            {
                MessageBox.Show("Please select Class No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCLassNo.Focus();
                return;
            }
            if (cmbHostelName.Text == "")
            {
                MessageBox.Show("Please select hostel name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbHostelName.Focus();
                return;
            }
            if (cmbCLassName.Text == "")
            {
                MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCLassName.Focus();
                return;
            }
            if (cmbFacultyName.Text == "")
            {
                MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFacultyName.Focus();
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
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update hostelers set HostelId = (Select Hostelid from Hostel where HostelName = '"+cmbHostelName.Text.Trim()+"') ,JoiningDate=@joiningdate where StudentId = ( Select StudentId From Student where ClassNo = '" + cmbCLassNo.Text + "'and  DepartmentId = (Select DepartmentId From Department where ClassName = '" + cmbCLassName.Text.Trim() + "' and FacultyName = '" + cmbFacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Description = '" + cmbSession.Text.Trim() + "') ) ";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@joiningdate", System.Data.SqlDbType.NChar, 50, "JoiningDate"));
                cmd.Parameters["@joiningdate"].Value = JoiningDate.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated", "Hostelers Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            frmRecords.frmHostelerRecord frm = new frmRecords.frmHostelerRecord();
            frm.label7.Text = label3.Text;
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRecords.frmHostelerRecord frm = new frmRecords.frmHostelerRecord();
            frm.label5.Text = label3.Text;
            frm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            #region Validation
            if (cmbCLassNo.Text == "")
            {
                MessageBox.Show("Please select Class No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCLassNo.Focus();
                return;
            }
            if (cmbHostelName.Text == "")
            {
                MessageBox.Show("Please select hostel name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbHostelName.Focus();
                return;
            }
            if (cmbCLassName.Text == "")
            {
                MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCLassName.Focus();
                return;
            }
            if (cmbFacultyName.Text == "")
            {
                MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFacultyName.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
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
               #region CheckInTables
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "Select  Distinct (Hostelerid) from HostelFeePayment where HostelerId = (Select HostelerId from Hostelers where StudentId = (Select StudentId from Student where ClassNo = '"+cmbCLassNo.Text.Trim()+"' AND DepartmentId =(Select DepartmentId from Department  where ClassName = '"+cmbFacultyName.Text.Trim()+"' AND FacultyName = '"+cmbFacultyName.Text.Trim()+"') AND SessionId =(Select SessionId From Session where Description = '"+cmbSession.Text.Trim()+"') ) AND HostelId = (Select HostelId from Hostel where HostelName= '"+cmbHostelName.Text.Trim()+"') )   ";
                cmd = new SqlCommand(ct);
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
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from Hostelers where StudentId = (Select StudentId from Student where ClassNo = '"+cmbCLassNo.Text.Trim()+"' AND DepartmentId =(Select DepartmentId from Department  where ClassName = '"+cmbCLassName.Text.Trim()+"' AND FacultyName = '"+cmbFacultyName.Text.Trim()+"') AND SessionId =(Select SessionId From Session where Description = '"+cmbSession.Text.Trim()+ "')) AND HostelId =  (Select HostelId from Hostel where HostelName= '" + cmbHostelName.Text.Trim() + "')";
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

        private void cmbCLassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbFacultyName.Items.Clear();
                cmbFacultyName.Text = "";
                cmbFacultyName.Enabled = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(FacultyName) from Department where ClassName = '" + cmbCLassName.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbFacultyName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFacultyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbSession.Items.Clear();
                cmbSession.Text = "";
                cmbSession.Enabled = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Description) from Session where IsActive = 'true' ";
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

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbCLassNo.Items.Clear();
                cmbCLassNo.Text = "";
                cmbCLassNo.Enabled = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(CLassNo) from Student where DepartmentId = (Select DepartmentId From Department where CLassName = '"+cmbCLassName.Text.Trim()+"' and FacultyName= '"+cmbFacultyName.Text.Trim()+ "') and SessionId = (Select SessionId From Session where Description = '" + cmbSession.Text.Trim() + "')";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbCLassNo.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
