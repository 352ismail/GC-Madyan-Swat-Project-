using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace College_Management_System
{
    public partial class frmIdCard : Form
    {

        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();


        public frmIdCard()
        {
            InitializeComponent();
        }

        private void DOB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmIdCard_Load(object sender, EventArgs e)
        {
            AutocompleClass();
        }

        public void AutocompleClass()
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
                    cmbClassName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbClassName_SelectedIndexChanged(object sender, EventArgs e)
        {         
            cmbFacultyName.Items.Clear();
            cmbFacultyName.Text = "";
            cmbFacultyName.Enabled = true;
            cmbFacultyName.Focus();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(FacultyName) from Department where ClassName = '" + cmbClassName.Text + "'";
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
            cmbSession.Items.Clear();
            cmbSession.Text = "";
            cmbSession.Enabled = true;
            cmbSession.Focus();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Description) from Session where IsActive = 'true'";
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
            cmbRollNo.Items.Clear();
            cmbRollNo.Text = "";
            cmbRollNo.Enabled = true;
            cmbRollNo.Focus();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(ClassNo) from Student where DepartmentId= (Select DepartmentId From Department where ClassName = '" + cmbClassName.Text + "'and FacultyName = '" + cmbFacultyName.Text + "') and  SessionId = (Select SessionId From Session where Description ='"+cmbSession.Text+"')";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbRollNo.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRollNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            StudentName.Text = "";
            FatherName.Text = "";
            DOB.Value = DateTime.Now;
            txtGender.Text = "";
            BloodGroup.Text = "";
            Address.Text = "";
            ContactNo.Text = "";
            Picture.Image = Properties.Resources.photo;
            try
            {
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT StudentName,FatherName,Gender,DateOfBirth,BloodGroup,StudentAddress,ContactNo,Photo FROM Student WHERE CLassNo = '" + cmbRollNo.Text + "' and DepartmentId= (Select DepartmentId From Department where ClassName = '" + cmbClassName.Text + "'and FacultyName = '" + cmbFacultyName.Text + "') and  SessionId = (Select SessionId From Session where Description ='" + cmbSession.Text + "')";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    StudentName.Text = (String)rdr["StudentName"];
                    FatherName.Text = (String)rdr["FatherName"];
                    txtGender.Text = (String)rdr["Gender"];
                    DOB.Text = (String)rdr["DateOfBirth"];
                    BloodGroup.Text = (String)rdr["BloodGroup"];
                    Address.Text = (String)rdr["StudentAddress"];
                    ContactNo.Text = (String)rdr["ContactNo"];
                    MemoryStream stream = new MemoryStream();
                    byte[] image = (byte[])rdr["Photo"];
                    stream.Write(image, 0, image.Length);
                    Bitmap bitmap = new Bitmap(stream);
                    Picture.Image = bitmap;
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

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
           
            cmbClassName.Text = "";
            cmbFacultyName.Text = "";
            cmbSession.Text = "";
            cmbRollNo.Text = "";
            StudentName.Text = "";
            FatherName.Text = "";
            DOB.Value = DateTime.Now;
            txtGender.Text = "";
            BloodGroup.Text = "";
            Address.Text = "";
            ContactNo.Text = "";
            IssueDate.Value = DateTime.Now;
            ExpiryDate.Value = DateTime.Now;
            Picture.Image = Properties.Resources.user_120px;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            btnPrint.Enabled = false;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Validation
            if (cmbClassName.Text == "")
            {
                MessageBox.Show("Please Select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName.Focus();
                return;
            }
            if (cmbFacultyName.Text == "")
            {
                MessageBox.Show("Please Select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFacultyName.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please Select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbRollNo.Text == "")
            {
                MessageBox.Show("Please Select Class No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRollNo.Focus();
                return;
            }
            #endregion
            try
            {
                #region Avoid Duplicate Data
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select StudentId from IdCard where StudentId =(Select StudentId From Student where ClassNo = '"+cmbRollNo.Text.Trim()+"' and   DepartmentId = (Select DepartmentId From Department where   ClassName = '"+cmbClassName.Text.Trim()+"' and FacultyName = '"+cmbFacultyName.Text.Trim()+"') and SessionId = (Select SessionId From Session where Description = '"+cmbSession.Text.Trim()+"'))";
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
                #endregion
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into IdCard(IssueDate,ExpiryDate,StudentId) VALUES (@issuedate,@expirydate,(Select StudentId From Student where ClassNo = '" + cmbRollNo.Text.Trim() + "' AND  DepartmentId = (Select DepartmentId From Department where   ClassName = '" + cmbClassName.Text.Trim() + "' and FacultyName = '" + cmbFacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Description = '" + cmbSession.Text.Trim() + "')))";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@issuedate", System.Data.SqlDbType.NChar, 50, "IssueDate"));
                cmd.Parameters.Add(new SqlParameter("@expirydate", System.Data.SqlDbType.VarChar, 50, "ExpiryDate"));
                cmd.Parameters["@issuedate"].Value = IssueDate.Text.Trim();
                cmd.Parameters["@expirydate"].Value = ExpiryDate.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Saved", "Student", MessageBoxButtons.OK, MessageBoxIcon.Information);      
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            #region Validation
            if (cmbClassName.Text == "")
            {
                MessageBox.Show("Please Select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName.Focus();
                return;
            }
            if (cmbFacultyName.Text == "")
            {
                MessageBox.Show("Please Select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFacultyName.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please Select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbRollNo.Text == "")
            {
                MessageBox.Show("Please Select Class No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRollNo.Focus();
                return;
            }
            #endregion
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string ct = "Select Distinct (StudentRegistration.StudentId ) From StudentRegistration INNER JOIn Student ON Student.StudentId = StudentRegistration.StudentId INNER JOIN Department On Department.DepartmentId= Student.DepartmentId INNER JOIN Session On Session.SessionId= Student.SessionId  Where Student.ClassNo = '"+cmbRollNo.Text.Trim()+"' And  Department.ClassName='"+cmbClassName.Text.Trim()+"' ANd Department.FacultyName = '"+cmbFacultyName.Text.Trim()+"' ANd Session.Description = '"+cmbSession.Text.Trim()+"'";
            cmd = new SqlCommand(ct);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                PrintRecord();
                if ((rdr != null))
                {
                    rdr.Close();
                }
                return;
            }
            else
            {
                MessageBox.Show("Student Not Registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }

        private void PrintRecord()
        {
            try
            {
                timer2.Enabled = true;
                frmReports.frmIdCardReport frm = new frmReports.frmIdCardReport();
                Reports.rptIdCard rpt = new Reports.rptIdCard();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
               DataSets.IdCard myDS = new DataSets.IdCard();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "Select * From Idcard INNER JOIN Student On Student.StudentId = IdCard.StudentId INNER JOIN Department On Department.DepartmentId= Student.DepartmentId INNER JOIN Session On Session.SessionId= Student.SessionId INNER JOIN StudentRegistration On StudentRegistration.StudentId= Student.StudentId Where Student.ClassNo = '"+cmbRollNo.Text.Trim()+"' And  Department.ClassName='"+cmbClassName.Text.Trim()+"' ANd Department.FacultyName = '"+cmbFacultyName.Text.Trim()+"' ANd Session.Description = '"+cmbSession.Text.Trim()+"'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "IdCardDetails");
                rpt.SetDataSource(myDS);
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmIdCardRecord frm = new frmIdCardRecord();
            frm.label3.Text = labelU.Text.Trim();
            frm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            #region Validation
            if (cmbClassName.Text == "")
            {
                MessageBox.Show("Please Select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName.Focus();
                return;
            }
            if (cmbFacultyName.Text == "")
            {
                MessageBox.Show("Please Select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFacultyName.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please Select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbRollNo.Text == "")
            {
                MessageBox.Show("Please Select Class No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRollNo.Focus();
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
                string cq = "delete from IdCard where StudentId = (Select StudentId From Student Where ClassNo = '" + cmbRollNo.Text.Trim() + "' AND DepartmentId =(Select DepartmentId from Department where department.ClassName = '" + cmbClassName.Text.Trim() + "' and Department.FacultyName = '" + cmbFacultyName.Text.Trim() + "') AND SessionId = (Select SessionId from Session where Session.Description = '" + cmbSession.Text.Trim() + "') );";
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

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            #region Validation
            if (cmbClassName.Text == "")
            {
                MessageBox.Show("Please Select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName.Focus();
                return;
            }
            if (cmbFacultyName.Text == "")
            {
                MessageBox.Show("Please Select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFacultyName.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please Select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbRollNo.Text == "")
            {
                MessageBox.Show("Please Select Class No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRollNo.Focus();
                return;
            }
            #endregion
            try
            {            
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string cb = "Update IdCard Set IssueDate =@issuedate , ExpiryDate=@expirydate  where StudentId = (Select StudentId From Student where ClassNo = '" + cmbRollNo.Text.Trim() + "' AND  DepartmentId = (Select DepartmentId From Department where   ClassName = '" + cmbClassName.Text.Trim() + "' and FacultyName = '" + cmbFacultyName.Text.Trim() + "') and SessionId = (Select SessionId From Session where Description = '" + cmbSession.Text.Trim() + "'))";
            cmd = new SqlCommand(cb);
            cmd.Connection = con;
            cmd.Parameters.Add(new SqlParameter("@issuedate", System.Data.SqlDbType.NChar, 50, "IssueDate"));
            cmd.Parameters.Add(new SqlParameter("@expirydate", System.Data.SqlDbType.VarChar, 50, "ExpiryDate"));
            cmd.Parameters["@issuedate"].Value = IssueDate.Text.Trim();
            cmd.Parameters["@expirydate"].Value = ExpiryDate.Text.Trim();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated", "Id Card", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
