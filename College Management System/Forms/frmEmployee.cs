using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
namespace College_Management_System
{
    public partial class frmEmployeeDetails : Form
    {

        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmEmployeeDetails()
        {
            InitializeComponent();
        }    

        private void EmployeeDetails_Load(object sender, EventArgs e)
        {
            txtStaffName.Focus();
        }

        private void EmployeeDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Department_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validation
                if (txtStaffName.Text == "")
                {
                    MessageBox.Show("Please enter Employee name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStaffName.Focus();
                    return;
                }

                if (rdbFemale.Checked == false && rdbMale.Checked  == false)
                {
                    MessageBox.Show("Please select gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdbMale.Focus();
                    return;
                }
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAddress.Focus();
                    return;
                }

                if (txtContactNo.Text == "")
            {
                MessageBox.Show("Please enter Contact No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContactNo.Focus();
                return;
            }
               if (txtEmail.Text == "")
                {
                    MessageBox.Show("Please enter email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }

            if (txtQualifications.Text == "")
            {
                MessageBox.Show("Please enter qualifications", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQualifications.Focus();
                return;
            }

            if (txtDesignation.Text == "")
            {
                MessageBox.Show("Please enter staff designation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDesignation.Focus();
                return;
            }
          
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please Double Click On Image & select photo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox1.Focus();
                return;
            }
                #endregion
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select EmployeeName,Designation from Employee where EmployeeName= '" + txtStaffName.Text + "' and Designation= '" + txtDesignation.Text + "'";
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
                //Saving Data To DataBase
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Employee(EmployeeName,Designation,Gender,ContactNo,DateOfJoining,Address,Email,Qualification,Photo) values(@employeename,@designation,@Gender,@contactNo,@dateofjoining,@address,@email,@qualification,@photo)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@employeename", System.Data.SqlDbType.NChar, 30, "EmployeeName"));
                cmd.Parameters.Add(new SqlParameter("@designation", System.Data.SqlDbType.VarChar, 100, "Designation"));
                cmd.Parameters.Add(new SqlParameter("@gender", System.Data.SqlDbType.NChar, 10, "Gender"));
                cmd.Parameters.Add(new SqlParameter("@contactno", System.Data.SqlDbType.NChar, 30, "ContactNo"));
                cmd.Parameters.Add(new SqlParameter("@dateofjoining", System.Data.SqlDbType.NChar, 30, "DateOfJoining"));
                cmd.Parameters.Add(new SqlParameter("@address", System.Data.SqlDbType.VarChar, 100, "Address"));
                cmd.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.NChar, 30, "Email"));
                cmd.Parameters.Add(new SqlParameter("@qualification", System.Data.SqlDbType.NChar, 70, "Qualification"));
                cmd.Parameters["@employeename"].Value = txtStaffName.Text;
                cmd.Parameters["@designation"].Value = txtDesignation.Text;
                if (rdbMale.Checked == true)
                {
                    cmd.Parameters["@gender"].Value = rdbMale.Text;
                }
                else if (rdbFemale.Checked == true)
                {
                    cmd.Parameters["@gender"].Value = rdbFemale.Text;
                }
                cmd.Parameters["@contactno"].Value = txtContactNo.Text;
                cmd.Parameters["@dateofjoining"].Value =  DateOfJoining.Text;
                cmd.Parameters["@address"].Value = txtAddress.Text;
                cmd.Parameters["@email"].Value = txtEmail.Text;
                cmd.Parameters["@qualification"].Value = txtQualifications.Text;
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(pictureBox1.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@photo", SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Information);           
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }       
        }

        private void clear()
        {
            txtStaffName.Text = "";
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            txtAddress.Text = "";
            txtContactNo.Text = "";
            txtEmail.Text = "";
            DateOfJoining.Text = System.DateTime.Today.ToString();
            txtQualifications.Text = "";
            txtDesignation.Text = "";
            pictureBox1.Image = Properties.Resources.user_120px;
            txtStaffID.Text = "";
            txtStaffID.Visible = false;
            btnSave.Enabled = true;
            Delete.Enabled = false;
            Update_record.Enabled = false;
            lblStaffId.Visible = false;
            btnPrint.Enabled = false;        
        }

        private void NewRecord_Click(object sender, EventArgs e)
        {
            clear();          
        }

        private void Update_record_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update Employee set EmployeeName=@employeename,Designation=@designation,Gender=@gender,ContactNo=@contactno,DateOfJoining=@dateofjoining,Address=@address,Email=@email,Qualification=@qualification ,Photo=@photo where EmployeeId=@employeeid";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@employeeid", System.Data.SqlDbType.NChar, 15, "EmployeeId"));
                cmd.Parameters.Add(new SqlParameter("@employeename", System.Data.SqlDbType.NChar, 60, "EmployeeName"));
                cmd.Parameters.Add(new SqlParameter("@gender", System.Data.SqlDbType.NChar, 10, "Gender"));
                cmd.Parameters.Add(new SqlParameter("@contactno", System.Data.SqlDbType.NChar, 15, "ContactNo"));
                cmd.Parameters.Add(new SqlParameter("@dateofjoining", System.Data.SqlDbType.NChar, 30, "DateOfJoining"));
                cmd.Parameters.Add(new SqlParameter("@address", System.Data.SqlDbType.VarChar, 100, "Address"));
                cmd.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.NChar, 50, "Email"));
                cmd.Parameters.Add(new SqlParameter("@qualification", System.Data.SqlDbType.NChar, 70, "Qualification"));
                cmd.Parameters.Add(new SqlParameter("@designation", System.Data.SqlDbType.VarChar, 100, "Designation"));
                cmd.Parameters["@employeeid"].Value = txtStaffID.Text;
                cmd.Parameters["@employeename"].Value = txtStaffName.Text;
                if (rdbMale.Checked == true)
                {
                    cmd.Parameters["@gender"].Value = rdbMale.Text;
                }
                else if (rdbFemale.Checked == true)
                {
                    cmd.Parameters["@gender"].Value = rdbFemale.Text;
                }
                cmd.Parameters["@contactno"].Value = txtContactNo.Text;
                cmd.Parameters["@dateofjoining"].Value = DateOfJoining.Text;
                cmd.Parameters["@address"].Value = txtAddress.Text;
                cmd.Parameters["@email"].Value = txtEmail.Text;
                cmd.Parameters["@qualification"].Value = txtQualifications.Text;
                cmd.Parameters["@designation"].Value = txtDesignation.Text;
                //Image
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(pictureBox1.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@photo", SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated", "Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            }

        private void button1_Click_1(object sender, EventArgs e)
        {
        
        }

        private void Browse_Click(object sender, EventArgs e)
        {

            
        }

        private void txtStaffName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void cmbGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
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

        private void txtYOP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRecords.frmEmployeesRecord frm = new frmRecords.frmEmployeesRecord();
            frm.label1.Text = label21.Text;
            frm.label2.Text = label23.Text;
            frm.Show();
        }

        private void txtBasicSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtLIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtIncomeTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtGrpInsurance_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtFamilyBenefitFund_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtLoans_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtOtherDeductions_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

      
        private void Delete_Click(object sender, EventArgs e)
        {
            if (txtStaffID.Text == "")
            {
                MessageBox.Show("Please Select Employee Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStaffID.Focus();
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
                #region Check In Tables 
                int RowsAffected = 0;

                // check In Event Managed By Table 
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = " select Distinct(EmployeeId) From EventManagedBy where EmployeeId = '"+txtStaffID.Text.Trim()+"'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                // check In Employee Attendance Table 
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = " select Distinct(EmployeeId) From EmployeeAttendance where EmployeeId = '" + txtStaffID.Text.Trim() + "'";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                // check In Result Table
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cm = " select Distinct(EmployeeId) From Result where EmployeeId = '"+txtStaffID.Text.Trim()+"'";
                cmd = new SqlCommand(cm);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion

                // Delete Records
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from Employee where EmployeeId=@employeeid;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@employeeid", System.Data.SqlDbType.NChar, 15, "EmployeeId"));
                cmd.Parameters["@employeeid"].Value = txtStaffID.Text;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }
                else
                {
                   MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            var _with1 = openFileDialog1;
            _with1.Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif; *.ico");
            _with1.FilterIndex = 4;
            //Clear the file name
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtQualifications_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQualifications_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtDesignation_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) ||  e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            #region Validation
            if (txtStaffID.Text == "")
            {
                MessageBox.Show("Please select Employee to print Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStaffID.Focus();
                return;
            }   
            #endregion
            PrintRecord();
        }

        private void PrintRecord()
        {
            try
            {

                frmReports.frmSingleEmployeeReport frm = new frmReports.frmSingleEmployeeReport();
                Reports.reptSingleEmployeeReport rpt = new Reports.reptSingleEmployeeReport();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSets.dstSingleEmployee myDS = new DataSets.dstSingleEmployee();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "Select * From Employee where EmployeeId = '"+txtStaffID.Text.Trim()+"'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "SingleEmployee");
                rpt.SetDataSource(myDS);
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}