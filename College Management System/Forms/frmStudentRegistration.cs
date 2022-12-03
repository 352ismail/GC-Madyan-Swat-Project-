using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;

namespace College_Management_System
{
   
    public partial class frmStudentRegistration : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
      
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

      
        public frmStudentRegistration()
        {
            InitializeComponent();
        }
        public void Reset()
        {
            cmbClassName.Text = "";
            cmbFaculty.Text = "";
            cmbSession.Text = "";
            cmbClassNo.Text = "";
            StudentName.Text = "";
            FatherName.Text = "";
            Picture.Image = Properties.Resources.user_120px;
                 
            DOB.Value = DateTime.Now;
            RegNo.Text = "";
            txtRollNo.Text = "";           
            cmbStatus.Text = "";
            cmbDeficiency.Text = "";
            HSType.Text = "";
            Marks.Text = "";
            HSRollNo.Text = "";
            Board.Text = "";
            YOP.Text = "";
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            btnSave.Enabled = true;
        }
        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        
        }
    
        private void frmStudentRegistration_Load(object sender, EventArgs e)
        {
          
            AutocompleClassName();
            AutocompleRegistrationStatus();
            AutocompleRegistrationDeficiency();
            RegNo.Focus();
        }
        //This Function  Load Deficiency
        private void AutocompleRegistrationDeficiency()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Description) from RegistrationDeficiency ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                cmbDeficiency.Items.Clear();
                while (rdr.Read())
                {
                    cmbDeficiency.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //This Function Load Status Of registration
        private void AutocompleRegistrationStatus()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Description) from RegistrationStatus ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                cmbStatus.Items.Clear();
                while (rdr.Read())
                {
                    cmbStatus.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // This Function Load Class Name 
        public void AutocompleClassName()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(ClassName) from Department ";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();
                cmbClassName.Items.Clear();
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Validation 
            if (cmbClassName.Text == "")
            {
                MessageBox.Show("Please Select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName.Focus();
                return;
            }
            if (cmbFaculty.Text == "")
            {
                MessageBox.Show("Please Select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFaculty.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please Select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (RegNo.Text == "")
            {
                MessageBox.Show("Please Enter Registration No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RegNo.Focus();
                return;
            }
            if (txtRollNo.Text == "")
            {
                MessageBox.Show("Please Enter Roll No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRollNo.Focus();
                return;
            }
            if (cmbClassNo.Text == "")
            {
                MessageBox.Show("Please Select Class No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassNo.Focus();
                return;
            }
            if (cmbStatus.Text == "")
            {
                MessageBox.Show("Please Select Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbStatus.Focus();
                return;
            }
            if (cmbDeficiency.Text == "")
            {
                MessageBox.Show("Please Select Deficiency", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbDeficiency.Focus();
                return;
            }

            if (HSType.Text == "")
            {
                MessageBox.Show("Please Select SSC Or HSSC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HSType.Focus();
                return;
            }

            if (YOP.Text == "")
            {
                MessageBox.Show("Please Enter Year Of Passing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                YOP.Focus();
                return;
            }
            if (Marks.Text == "")
            {
                MessageBox.Show("Please Enter Obtained Marks", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Marks.Focus();
                return;
            }
            if (Percentage.Text == "")
            {
                MessageBox.Show("Percentage could not be Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Percentage.Focus();
                return;
            }
            if (Board.Text == "")
            {
                MessageBox.Show("Please Enter Board", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Board.Focus();
                return;
            }
            #endregion
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RegNo,StudentRegistration.StudentId from studentRegistration Inner Join Student On Student.StudentId = StudentRegistration.StudentId INNER JOIN Department On Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId where Department.ClassName = '"+cmbClassName.Text.Trim()+"' ANd FacultyName= '"+cmbFaculty.Text.Trim()+"' AND Session.Description = '"+cmbSession.Text.Trim()+"' AND ClassNo = '"+cmbClassNo.Text.Trim()+"' OR RegNo='"+RegNo.Text.Trim()+"' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RegNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct1 = "select RollNo from studentRegistration  where RollNo='" + txtRollNo.Text.Trim() + "' ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("RollNo Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RegNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = @"insert into StudentRegistration (RegNo,RollNo,Class,YearOfPassing,HSRollNo,HSMarks,HSPercentage,BoardName,StudentId,RegistrationDeficiencyId,RegistrationStatusid) VALUES (@regno,@rollno,@class,@yearofpassing,@hsrollno,@hsmarks,@hspercentage,@boardname, (SELECT StudentId From Student where Student.CLassNo='" + cmbClassNo.Text.Trim() + "'and DepartmentId = (select DepartmentId From Department where ClassName='" + cmbClassName.Text.Trim() + "' and FacultyName = '" + cmbFaculty.Text.Trim() + "' ) and SessionId = (Select SessionId From Session  where Session.Description = '" + cmbSession.Text.Trim() + "')),(Select RegistrationDeficiencyId from RegistrationDeficiency where Description = '" + cmbDeficiency.Text.Trim() + "'),(Select RegistrationStatusId from RegistrationStatus where Description ='" + cmbStatus.Text.Trim() + "'))";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                if (HSType.SelectedIndex == -1)
                {
                    HSType.Text = "";
                }
                cmd.Parameters.Add(new SqlParameter("@regno", System.Data.SqlDbType.NChar, 30, "RegNo"));
                cmd.Parameters.Add(new SqlParameter("@rollno", System.Data.SqlDbType.NChar, 50, "RollNo"));
                cmd.Parameters.Add(new SqlParameter("@class", System.Data.SqlDbType.NChar, 50, "Class"));
                cmd.Parameters.Add(new SqlParameter("@yearofpassing", System.Data.SqlDbType.NChar, 10, "YearOfPassing"));
                cmd.Parameters.Add(new SqlParameter("@hsrollno", System.Data.SqlDbType.NChar, 50, "HSRollNo"));
                cmd.Parameters.Add(new SqlParameter("@hsmarks", System.Data.SqlDbType.NChar, 15, "HSMarks"));
                cmd.Parameters.Add(new SqlParameter("@hspercentage", System.Data.SqlDbType.NChar, 10, "HSPercentage"));
                cmd.Parameters.Add(new SqlParameter("@boardname", System.Data.SqlDbType.NChar, 100, "BoardName"));
                cmd.Parameters["@regno"].Value = RegNo.Text.Trim();
                cmd.Parameters["@rollno"].Value = txtRollNo.Text.Trim();
                cmd.Parameters["@class"].Value = HSType.Text.Trim();
                cmd.Parameters["@yearofpassing"].Value = YOP.Text.Trim();
                cmd.Parameters["@hsrollno"].Value = HSRollNo.Text.Trim();
                cmd.Parameters["@hsmarks"].Value = Marks.Text.Trim();
                cmd.Parameters["@hspercentage"].Value = Convert.ToDouble(Percentage.Text.Trim());
                cmd.Parameters["@boardname"].Value = Board.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Registered", "Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (cmbClassName.Text == "")
                {
                    MessageBox.Show("Please Select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClassName.Focus();
                    return;
                }
                if (cmbFaculty.Text == "")
                {
                    MessageBox.Show("Please Select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFaculty.Focus();
                    return;
                }
                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please Select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSession.Focus();
                    return;
                }
                if (RegNo.Text == "")
                {
                    MessageBox.Show("Please Enter Registration No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RegNo.Focus();
                    return;
                }
                if (txtRollNo.Text == "")
                {
                    MessageBox.Show("Please Enter Roll No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRollNo.Focus();
                    return;
                }
                if (cmbClassNo.Text == "")
                {
                    MessageBox.Show("Please Select Class No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClassNo.Focus();
                    return;
                }
                if (cmbStatus.Text == "")
                {
                    MessageBox.Show("Please Select Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbStatus.Focus();
                    return;
                }
                if (cmbDeficiency.Text == "")
                {
                    MessageBox.Show("Please Select Deficiency", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbDeficiency.Focus();
                    return;
                }

                if (HSType.Text == "")
                {
                    MessageBox.Show("Please Select SSC Or HSSC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    HSType.Focus();
                    return;
                }

                if (YOP.Text == "")
                {
                    MessageBox.Show("Please Enter Year Of Passing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    YOP.Focus();
                    return;
                }
                if (Marks.Text == "")
                {
                    MessageBox.Show("Please Enter Obtained Marks", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Marks.Focus();
                    return;
                }
                if (Percentage.Text == "")
                {
                    MessageBox.Show("Percentage could not be Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Percentage.Focus();
                    return;
                }
                if (Board.Text == "")
                {
                    MessageBox.Show("Please Enter Board Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Board.Focus();
                    return;
                }
                #endregion
                try
                {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RegNo,RollNo from studentRegistration where  RegNo='" + RegNo.Text.Trim() + "' OR RollNo = '"+txtRollNo.Text.Trim()+"' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read() == false)
                {
                    MessageBox.Show("Registration No Or Roll No not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RegNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                    con.Open();                   
                    string cb = "Update  StudentRegistration Set Class=@class,YearOfPassing=@yearofpassing,HSRollNo=@hsrollno,HSMarks=@hsmarks,HSPercentage=@hspercentage,BoardName=@boardname,RegistrationDeficiencyId = (Select RegistrationDeficiencyId from RegistrationDeficiency where Description = '" + cmbDeficiency.Text.Trim() + "') ,RegistrationStatusid =(Select RegistrationStatusId from RegistrationStatus where Description ='" + cmbStatus.Text.Trim() + "') where StudentId = (SELECT StudentId From Student where Student.CLassNo='" + cmbClassNo.Text.Trim() + "'and DepartmentId = (select DepartmentId From Department where ClassName='" + cmbClassName.Text.Trim() + "' and FacultyName = '" + cmbFaculty.Text.Trim() + "' ) and SessionId = (Select SessionId From Session  where Session.Description = '" + cmbSession.Text.Trim() + "') ) AND RegNo = @regno AND  RollNo=@rollno";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    if (HSType.SelectedIndex == -1)
                    {
                        HSType.Text = "";
                    }
                    cmd.Parameters.Add(new SqlParameter("@regno", System.Data.SqlDbType.NChar, 30, "RegNo"));
                    cmd.Parameters.Add(new SqlParameter("@rollno", System.Data.SqlDbType.NChar, 50, "RollNo"));
                    cmd.Parameters.Add(new SqlParameter("@class", System.Data.SqlDbType.NChar, 50, "Class"));
                    cmd.Parameters.Add(new SqlParameter("@yearofpassing", System.Data.SqlDbType.NChar, 10, "YearOfPassing"));
                    cmd.Parameters.Add(new SqlParameter("@hsrollno", System.Data.SqlDbType.NChar, 50, "HSRollNo"));
                    cmd.Parameters.Add(new SqlParameter("@hsmarks", System.Data.SqlDbType.NChar, 15, "HSMarks"));
                    cmd.Parameters.Add(new SqlParameter("@hspercentage", System.Data.SqlDbType.NChar, 10, "HSPercentage"));
                    cmd.Parameters.Add(new SqlParameter("@boardname", System.Data.SqlDbType.NChar, 100, "BoardName"));
                    cmd.Parameters["@regno"].Value = RegNo.Text.Trim();
                    cmd.Parameters["@rollno"].Value = txtRollNo.Text.Trim();
                    cmd.Parameters["@class"].Value = HSType.Text.Trim();
                    cmd.Parameters["@yearofpassing"].Value = YOP.Text.Trim();
                    cmd.Parameters["@hsrollno"].Value = HSRollNo.Text.Trim();
                    cmd.Parameters["@hsmarks"].Value = Marks.Text.Trim();
                    cmd.Parameters["@hspercentage"].Value = Convert.ToDouble(Percentage.Text.Trim());
                    cmd.Parameters["@boardname"].Value = Board.Text.Trim();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated", "Student Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
       
        }

        private void Course_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
       
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
            
            }

            if (e.KeyCode == Keys.Enter)
            {

             
            }
        }

        private void frmStudentRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private void HSPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void HSSPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void GPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void PGpercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void StudentName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
      
        }

        private void FatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
      
        }

        private void MotherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
      
        }

        private void Nationality_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
      
        }

        private void Email_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            //if (Email.Text.Length > 0)
            //{
            //    if (!rEMail.IsMatch(Email.Text))
            //    {
            //        MessageBox.Show("invalid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        Email.SelectAll();
            //        e.Cancel = true;
            //    }
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbClassName.Text == "")
            {
                MessageBox.Show("Please Select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName.Focus();
                return;
            }
            if (cmbFaculty.Text == "")
            {
                MessageBox.Show("Please Select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFaculty.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please Select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
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
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from StudentRegistration where StudentId = (Select StudentId From Student Where ClassNo = '"+cmbClassNo.Text.Trim()+ "' AND DepartmentId =(Select DepartmentId from Department where department.ClassName = '" + cmbClassName.Text.Trim() + "' and Department.FacultyName = '" + cmbFaculty.Text.Trim() + "') AND SessionId = (Select SessionId from Session where Session.Description = '"+cmbSession.Text.Trim()+"') );";
                cmd = new SqlCommand(cq);
               cmd.Connection = con;
          
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnDelete.Enabled = false;
                    btnUpdate_record.Enabled = false;                  
                    Reset();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnDelete.Enabled = false;
                    btnUpdate_record.Enabled = false;                   
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        //this Function Load Class Name
        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbClassNo.Items.Clear();
            cmbClassNo.Text = "";
            cmbClassNo.Enabled = true;
            cmbClassNo.Focus();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(ClassNo) from Student where DepartmentId = (Select DepartmentId From Department where ClassName ='"+cmbClassName.Text.Trim()+"' and FacultyName='"+cmbFaculty.Text.Trim()+"')and SessionId=(Select SessionId From Session where Description = '"+cmbSession.Text.Trim()+"')";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbClassNo.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // This Function Load Student Information 
        private void cmbRollNo_SelectedIndexChanged(object sender, EventArgs e)
        {
           try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT StudentName,FatherName,DateOfBirth,Photo FROM Student WHERE ClassNo = '" + cmbClassNo.Text + "' and DepartmentId =(Select DepartmentId From Department where ClassName ='" + cmbClassName.Text.Trim() + "' and FacultyName='" + cmbFaculty.Text.Trim() + "') and SessionId =(Select SessionId From Session where Description = '" + cmbSession.Text.Trim() + "')";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    StudentName.Text = (String)rdr["StudentName"];
                    FatherName.Text = (String)rdr["FatherName"];
                    DOB.Text = (String)rdr["DateOfBirth"];
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

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRecords.frmStudetnsRegRecord frm = new frmRecords.frmStudetnsRegRecord();
            frm.label11.Text = label1.Text.Trim();
            frm.Show();
        }
        //this Function Load FacultyName
        private void cmbClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFaculty.Items.Clear();
            cmbFaculty.Text = "";
            cmbFaculty.Enabled = true;
            cmbFaculty.Focus();
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
                    cmbFaculty.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //This Function Load Session 
        private void cmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void GMarks_TextChanged(object sender, EventArgs e)
        {
            if (Marks.Text != String.Empty)
            {
                if (Convert.ToInt32(Marks.Text) > 1100)
                {
                    Marks.Text = "1100";
                }
                else if (Convert.ToInt32(Marks.Text) < 0)
                {
                    Marks.Text = "0";
                }
            }
          
            double val1 = 0;
            double.TryParse(Marks.Text, out val1);
            double I = Math.Round((val1 / 1100) * 100, 2);
            Percentage.Text = I.ToString();
        }
        #region Key Press Events
        private void RegNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtRollNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void YOP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void Marks_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void HSRollNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void Board_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        #endregion
    }
}

