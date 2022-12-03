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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
namespace College_Management_System
{
    public partial class frmStudent : Form
    {
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice VideoDevices;
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmStudent()
        {
            InitializeComponent();
        }
        public void GetAllCameras()
        {
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Devices in CaptureDevice)
            {
                cmbCamInfo.Items.Add(Devices.Name);
            }
        }

        private void Student_Load(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;
            printToolStripMenuItem.Enabled = false;
            AutocompleClassName();
           
            GetAllCameras();
        }
        public void Reset()
        {

            cmbRollNo.Text = "";
            StudentName.Text = "";
            DateOfAdmission.Text = DateTime.Today.ToString();
            FatherName.Text = "";
            CNIC.Text = "";
            FatherCNIC.Text = "";
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            DOB.Text = "";
            Address.Text = "";
            cmbSession.Text = "";
            cmbClassName.Text = "";
            cmbFaculty.Text = "";
            BloodGroup.Text = "";
            ContactNo.Text = "";
            GuardianName.Text = "";
            GuardianContactNo.Text = "";
            GuardianAddress.Text = "";
            Picture.Image = Properties.Resources.user_120px;
            cmbFaculty.Enabled = false;
            btnPrint.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            deleteToolStripMenuItem1.Enabled = false;
            updateToolStripMenuItem.Enabled = false;
            printToolStripMenuItem.Enabled = false;

        }

        private void NewRecord_Click(object sender, EventArgs e)
        {
            Reset();

        }
        public void Autocomplete()
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            #region Validation
            if (cmbClassName.Text == "")
            {
                MessageBox.Show("Please select Class Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName.Focus();
                return;
            }
            if (cmbFaculty.Text == "")
            {
                MessageBox.Show("Please  Select Faculty Name ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFaculty.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbRollNo.Text == "")
            {
                MessageBox.Show("Please enter Class No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRollNo.Focus();
                return;
            }
            if (StudentName.Text == "")
            {
                MessageBox.Show("Please enter Student Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StudentName.Focus();
                return;
            }
            if (CNIC.Text == "")
            {
                MessageBox.Show("Please enter CNIC Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CNIC.Focus();
                return;
            }
            if (ContactNo.Text == "")
            {
                MessageBox.Show("Please enter Contact No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ContactNo.Focus();
                return;
            }
            if (rdbMale.Checked == false && rdbFemale.Checked == false)
            {
                MessageBox.Show("Please Select Gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rdbMale.Focus();
                return;
            }
            if (Address.Text == "")
            {
                MessageBox.Show("Please enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Address.Focus();
                return;
            }
            if (BloodGroup.Text == "")
            {
                MessageBox.Show("Please select BloodGroup", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BloodGroup.Focus();
                return;
            }

            if (DOB.Value == DateTime.Now)
            {
                MessageBox.Show("Please select DOB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DOB.Focus();
                return;
            }
            if (FatherName.Text == "")
            {
                MessageBox.Show("Please enter Father's name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FatherName.Focus();
                return;
            }
            if (FatherCNIC.Text == "")
            {
                MessageBox.Show("Please select Father CNIC Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FatherCNIC.Focus();
                return;
            }
            if (cmbStatus.Text == "")
            {
                MessageBox.Show("Please Select Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbStatus.Focus();
                return;
            }

            if (GuardianName.Text == "")
            {
                MessageBox.Show("Please select Guradian Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GuardianName.Focus();
                return;
            }
            if (GuardianContactNo.Text == "")
            {
                MessageBox.Show("Please Enter Guardian Contact Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFaculty.Focus();
                return;
            }

            if (GuardianAddress.Text == "")
            {
                MessageBox.Show("Please Enter Guardian Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GuardianAddress.Focus();
                return;
            }
            if (Picture.Image == Properties.Resources.photo)
            {
                MessageBox.Show("Double Click On Photo And Select Image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Picture.Focus();
                return;
            }
            #endregion

            try
            {
                #region Avoid Duplicate Value
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ClassNo,DepartmentId,SessionId from Student where ClassNo=@classno and DepartmentId =(Select DepartmentId From Department where ClassName = '"+cmbClassName.Text.Trim()+"' and FacultyName = '"+cmbFaculty.Text.Trim()+"')  and SessionId = (Select SessionId From Session Where Description = '"+cmbSession.Text.Trim()+"')";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@classno", System.Data.SqlDbType.NChar, 20, "ClassNo"));
                cmd.Parameters["@classno"].Value = cmbRollNo.Text;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Record  Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbRollNo.Text = "";
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Student(ClassNo,StudentName,DateOfAdmission,FatherName,CNIC,FatherCNIC,Gender,DateOfBirth,StudentAddress,BloodGroup,ContactNo,GuardianName,GuardianContactNo,GuardianAddress,Photo,AdmissionStatusId,sessionId,DepartmentId) VALUES (@classno,@studentname,@dateofadmission,@fathername,@cnic,@fathercnic,@gender,@dateofbirth,@studentaddress,@bloodgroup,@contactno,@guardianname,@gcontaactno,@gaddress,@photo,(Select AdmissionStatusId from AdmissionStatus where Description = '"+cmbStatus.Text.Trim()+"'),(Select SessionId from Session where Session.Description = '"+cmbSession.Text.Trim()+"'),(Select DepartmentId from Department where department.ClassName = '"+cmbClassName.Text.Trim()+"' and Department.FacultyName = '"+cmbFaculty.Text.Trim()+"'))";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@classno", System.Data.SqlDbType.NChar, 15, "ClassNo"));
                cmd.Parameters.Add(new SqlParameter("@studentname", System.Data.SqlDbType.NChar, 80, "StudentName"));
                cmd.Parameters.Add(new SqlParameter("@dateofadmission", System.Data.SqlDbType.NChar, 50, "DateOfAdmission"));
                cmd.Parameters.Add(new SqlParameter("@fathername", System.Data.SqlDbType.NChar, 80, "FatherName"));
                cmd.Parameters.Add(new SqlParameter("@cnic", System.Data.SqlDbType.NChar, 16, "CNIC"));
                cmd.Parameters.Add(new SqlParameter("@fathercnic", System.Data.SqlDbType.NChar, 16, "FatherCNIC"));
                cmd.Parameters.Add(new SqlParameter("@gender", System.Data.SqlDbType.NChar, 15, "Gender"));
                cmd.Parameters.Add(new SqlParameter("@dateofbirth", System.Data.SqlDbType.NChar, 50, "DateOfBirth"));
                cmd.Parameters.Add(new SqlParameter("@studentaddress", System.Data.SqlDbType.NChar, 100, "StudentAddress"));
                cmd.Parameters.Add(new SqlParameter("@bloodgroup", System.Data.SqlDbType.NChar, 30, "BloodGroup"));
                cmd.Parameters.Add(new SqlParameter("@contactno", System.Data.SqlDbType.NChar, 30, "ContactNo"));
                cmd.Parameters.Add(new SqlParameter("@guardianname", System.Data.SqlDbType.NChar, 50, "GuardianName"));
                cmd.Parameters.Add(new SqlParameter("@gcontaactno", System.Data.SqlDbType.NChar, 30, "GuardianContactNo"));
                cmd.Parameters.Add(new SqlParameter("@gaddress", System.Data.SqlDbType.NChar, 100, "GuardianAddress"));
                cmd.Parameters["@classno"].Value = cmbRollNo.Text.Trim();
                cmd.Parameters["@studentname"].Value = StudentName.Text.Trim();
                cmd.Parameters["@dateofadmission"].Value = DateOfAdmission.Text.Trim();
                cmd.Parameters["@fathername"].Value = FatherName.Text.Trim();
                cmd.Parameters["@cnic"].Value = CNIC.Text.Trim();
                cmd.Parameters["@fathercnic"].Value = FatherCNIC.Text.Trim();
                if (rdbMale.Checked == true)
                {
                    cmd.Parameters["@gender"].Value = rdbMale.Text;

                }
                else if (rdbFemale.Checked == true)
                {
                    cmd.Parameters["@gender"].Value = rdbFemale.Text;

                }
                cmd.Parameters["@dateofbirth"].Value = DOB.Text.Trim();
                cmd.Parameters["@studentaddress"].Value = Address.Text.Trim();
                cmd.Parameters["@bloodgroup"].Value = BloodGroup.Text.Trim();
                cmd.Parameters["@contactno"].Value = ContactNo.Text.Trim();
                cmd.Parameters["@guardianname"].Value = GuardianName.Text.Trim();
                cmd.Parameters["@gcontaactno"].Value = GuardianContactNo.Text.Trim();
                cmd.Parameters["@gaddress"].Value = GuardianAddress.Text.Trim();
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(Picture.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@photo", SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Student Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnPrint.Enabled = true;
                printToolStripMenuItem.Enabled = true;
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
            update();
        }
        private void update()
        {
            #region Validation 
            if (cmbClassName.Text == "")
            {
                MessageBox.Show("Please select Class Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName.Focus();
                return;
            }
            if (cmbFaculty.Text == "")
            {
                MessageBox.Show("Please  Select Faculty Name ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFaculty.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbRollNo.Text == "")
            {
                MessageBox.Show("Please enter Class No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRollNo.Focus();
                return;
            }
            #endregion
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update Student set StudentName=@studentname,DateOfAdmission=@dateofadmission,FatherName=@fathername,CNIC=@cnic,FatherCNIC=@fathercnic,Gender=@gender,DateOfBirth=@dateofbirth,StudentAddress=@studentaddress,BloodGroup=@bloodgroup,ContactNo=@contactno,GuardianName=@guardianname,GuardianContactNo=@gcontaactno,GuardianAddress=@gaddress,photo=@photo,AdmissionStatusId=(Select AdmissionStatusId From AdmissionStatus where AdmissionStatus.Description = '" + cmbStatus.Text.Trim() + "') where ClassNo = @classno and DepartmentId = (Select Departmentid from Department where ClassName ='" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "') and SessionId = (Select SessionId from Session where Session.Description ='" + cmbSession.Text.Trim() + "')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@classno", System.Data.SqlDbType.NChar, 15, "ClassNo"));
                cmd.Parameters.Add(new SqlParameter("@studentname", System.Data.SqlDbType.NChar, 80, "StudentName"));
                cmd.Parameters.Add(new SqlParameter("@dateofadmission", System.Data.SqlDbType.NChar, 50, "DateOfAdmission"));
                cmd.Parameters.Add(new SqlParameter("@fathername", System.Data.SqlDbType.NChar, 80, "FatherName"));
                cmd.Parameters.Add(new SqlParameter("@cnic", System.Data.SqlDbType.NChar, 16, "CNIC"));
                cmd.Parameters.Add(new SqlParameter("@fathercnic", System.Data.SqlDbType.NChar, 16, "FatherCNIC"));
                cmd.Parameters.Add(new SqlParameter("@gender", System.Data.SqlDbType.NChar, 15, "Gender"));
                cmd.Parameters.Add(new SqlParameter("@dateofbirth", System.Data.SqlDbType.NChar, 50, "DateOfBirth"));
                cmd.Parameters.Add(new SqlParameter("@studentaddress", System.Data.SqlDbType.NChar, 100, "StudentAddress"));
                cmd.Parameters.Add(new SqlParameter("@bloodgroup", System.Data.SqlDbType.NChar, 30, "BloodGroup"));
                cmd.Parameters.Add(new SqlParameter("@contactno", System.Data.SqlDbType.NChar, 30, "ContactNo"));
                cmd.Parameters.Add(new SqlParameter("@guardianname", System.Data.SqlDbType.NChar, 50, "GuardianName"));
                cmd.Parameters.Add(new SqlParameter("@gcontaactno", System.Data.SqlDbType.NChar, 30, "GuardianContactNo"));
                cmd.Parameters.Add(new SqlParameter("@gaddress", System.Data.SqlDbType.NChar, 100, "GuardianAddress"));
                cmd.Parameters["@classno"].Value = cmbRollNo.Text.Trim();
                cmd.Parameters["@studentname"].Value = StudentName.Text.Trim();
                cmd.Parameters["@dateofadmission"].Value = DateOfAdmission.Text.Trim();
                cmd.Parameters["@fathername"].Value = FatherName.Text.Trim();
                cmd.Parameters["@cnic"].Value = CNIC.Text.Trim();
                cmd.Parameters["@fathercnic"].Value = FatherCNIC.Text.Trim();
                if (rdbMale.Checked == true)
                {
                    cmd.Parameters["@gender"].Value = rdbMale.Text;

                }
                else if (rdbFemale.Checked == true)
                {
                    cmd.Parameters["@gender"].Value = rdbFemale.Text;

                }
                cmd.Parameters["@dateofbirth"].Value = DOB.Text.Trim();
                cmd.Parameters["@studentaddress"].Value = Address.Text.Trim();
                cmd.Parameters["@bloodgroup"].Value = BloodGroup.Text.Trim();
                cmd.Parameters["@contactno"].Value = ContactNo.Text.Trim();
                cmd.Parameters["@guardianname"].Value = GuardianName.Text.Trim();
                cmd.Parameters["@gcontaactno"].Value = GuardianContactNo.Text.Trim();
                cmd.Parameters["@gaddress"].Value = GuardianAddress.Text.Trim();
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(Picture.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@photo", SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated", "Student Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            delete();
        }
        private void delete()
        {
            #region Validation 
            if (cmbClassName.Text == "")
            {
                MessageBox.Show("Please select Class Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName.Focus();
                return;
            }
            if (cmbFaculty.Text == "")
            {
                MessageBox.Show("Please  Select Faculty Name ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFaculty.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbRollNo.Text == "")
            {
                MessageBox.Show("Please enter Class No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                #region Check In Tables 
                //check In Id Card Table
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "Select Distinct(IdCard.StudentId) From IdCard  INNER JOIN Student ON Student.StudentId=IdCard.StudentId INNER JOIN Department ON Student.DepartmentId =Department.DepartmentId INNER JOIN Session ON Student.SessionId=Session.SessionId where  Student.ClassNo = '"+cmbRollNo.Text.Trim()+"' AND Department.ClassName = '"+cmbClassName.Text.Trim()+"' AND Department.FacultyName = '"+cmbFaculty.Text.Trim()+"' AND Session.Description = '"+cmbSession.Text.Trim()+"'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Autocomplete();
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                //check Semester Fee Payment Table
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct1 = "Select Distinct(SemesterFeePayment.StudentId) From SemesterFeePayment  INNER JOIN Student ON Student.StudentId=SemesterFeePayment.StudentId INNER JOIN Department ON Student.DepartmentId =Department.DepartmentId INNER JOIN Session ON Student.SessionId=Session.SessionId where  Student.ClassNo = '" + cmbRollNo.Text.Trim() + "' AND Department.ClassName = '" + cmbClassName.Text.Trim() + "' AND Department.FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Autocomplete();
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                //check Hostelers Table
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "Select Distinct(Hostelers.StudentId) From Hostelers  INNER JOIN Student ON Student.StudentId=Hostelers.StudentId INNER JOIN Department ON Student.DepartmentId =Department.DepartmentId INNER JOIN Session ON Student.SessionId=Session.SessionId where  Student.ClassNo = '" + cmbRollNo.Text.Trim() + "' AND Department.ClassName = '" + cmbClassName.Text.Trim() + "' AND Department.FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "'";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Autocomplete();
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                //check Student Registration Table
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct3 = "Select Distinct(StudentRegistration.StudentId) From StudentRegistration  INNER JOIN Student ON Student.StudentId=StudentRegistration.StudentId INNER JOIN Department ON Student.DepartmentId =Department.DepartmentId INNER JOIN Session ON Student.SessionId=Session.SessionId where  Student.ClassNo = '" + cmbRollNo.Text.Trim() + "' AND Department.ClassName = '" + cmbClassName.Text.Trim() + "' AND Department.FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "'";
                cmd = new SqlCommand(ct3);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Autocomplete();
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                //check Personal Ledger Table
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct4 = "Select Distinct(PersonalLedger.StudentId) From PersonalLedger  INNER JOIN Student ON Student.StudentId=PersonalLedger.StudentId INNER JOIN Department ON Student.DepartmentId =Department.DepartmentId INNER JOIN Session ON Student.SessionId=Session.SessionId where  Student.ClassNo = '" + cmbRollNo.Text.Trim() + "' AND Department.ClassName = '" + cmbClassName.Text.Trim() + "' AND Department.FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "'";
                cmd = new SqlCommand(ct4);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Autocomplete();
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                //check Result Table
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct5 = "Select Distinct(Result.StudentId) From Result  INNER JOIN Student ON Student.StudentId=Result.StudentId INNER JOIN Department ON Student.DepartmentId =Department.DepartmentId INNER JOIN Session ON Student.SessionId=Session.SessionId where  Student.ClassNo = '" + cmbRollNo.Text.Trim() + "' AND Department.ClassName = '" + cmbClassName.Text.Trim() + "' AND Department.FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "'";
                cmd = new SqlCommand(ct5);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Autocomplete();
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                //check Semester Result Table
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct6 = "Select Distinct(SemesterResult.StudentId) From SemesterResult  INNER JOIN Student ON Student.StudentId=SemesterResult.StudentId INNER JOIN Department ON Student.DepartmentId =Department.DepartmentId INNER JOIN Session ON Student.SessionId=Session.SessionId where  Student.ClassNo = '" + cmbRollNo.Text.Trim() + "' AND Department.ClassName = '" + cmbClassName.Text.Trim() + "' AND Department.FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "'";
                cmd = new SqlCommand(ct6);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Autocomplete();
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion
                // Delete Record
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from student where ClassNo = '"+cmbRollNo.Text.Trim()+"' AND DepartmentId = (Select DepartmentId from Department where department.ClassName = '" + cmbClassName.Text.Trim() + "' and Department.FacultyName = '" + cmbFaculty.Text.Trim() + "') AND SessionId =(Select SessionId from Session where Session.Description = '" + cmbSession.Text.Trim() + "')";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;              
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Autocomplete();
                    Reset();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Autocomplete();
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

        private void ScholarNo_TextChanged(object sender, EventArgs e)
        {
            int selectionStart = this.cmbRollNo.SelectionStart;
            this.cmbRollNo.Text = this.cmbRollNo.Text.ToUpper();
            this.cmbRollNo.SelectionStart = selectionStart;
        }

        private void Student_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Hide();
            //frmMainMenu form2 = new frmMainMenu();
            //form2.UserType.Text = label19.Text;
            //form2.User.Text = label19.Text;
            //form2.Show();

        }

        public void timer2_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer2.Enabled = false;
        }

        private void frmStudent_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

     
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
            btnPrint.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            deleteToolStripMenuItem1.Enabled = false;
            updateToolStripMenuItem.Enabled = false;
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            update();
        }



        //private void Email_Validating(object sender, CancelEventArgs e)
        //{
        //    System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
        //    if (Email.Text.Length > 0)
        //    {
        //        if (!rEMail.IsMatch(Email.Text))
        //        {
        //            MessageBox.Show("invalid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            Email.SelectAll();
        //            e.Cancel = true;
        //        }
        //    }
        //}

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

        private void GuardianName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void HSBoard_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void HSSBoard_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void GUniy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void PGUniy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void PrintRecord()
        {
            try
            {
               
                timer2.Enabled = true;
                frmReports.frmSingleStudentRecordReport frm = new frmReports.frmSingleStudentRecordReport();
                Reports.rptSingleStudentRecord rpt = new Reports.rptSingleStudentRecord();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSets.dstSingleStudentRecord myDS = new DataSets.dstSingleStudentRecord();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "Select * From Student INNER JOIN Department On Department.DepartmentId= Student.DepartmentId INNER JOIN Session ON Session.SessionId = Student.SessionId INNER JOIN AdmissionStatus ON AdmissionStatus.AdmissionStatusId = Student.AdmissionStatusId Where ClassName = '"+cmbClassName.Text.Trim()+"' AND FacultyName ='"+cmbFaculty.Text.Trim()+"' AND Session.Description = '"+cmbSession.Text.Trim()+"' AND Student.ClassNo = '"+cmbRollNo.Text.Trim()+"'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "SingleStudentRecord");
                rpt.SetDataSource(myDS);
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cmbClassName.Text == "")
            {
                MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName.Focus();
                return;
            }
            if (cmbFaculty.Text == "")
            {
                MessageBox.Show("Please  Select Faculty Name ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFaculty.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbRollNo.Text == "")
            {
                MessageBox.Show("Please enter Class No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRollNo.Focus();
                return;
            }
            PrintRecord();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintRecord();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reset();
            frmRecords.frmStudentsRecord frm = new frmRecords.frmStudentsRecord();
            //frm.textBox1.Text = "";
            frm.dataGridView1.DataSource = null;
            frm.dataGridView2.DataSource = null;
            frm.dataGridView3.DataSource = null;
            frm.cmbCourse.Text = "";
            frm.cmbBranch.Text = "";
            frm.cmbSession.Text = "";
            frm.DateFrom.Text = DateTime.Today.ToString();
            frm.DateTo.Text = DateTime.Today.ToString();

            frm.cmbBranch.Enabled = false;
            frm.cmbSession.Enabled = false;
            frm.label17.Text =label19.Text;
            frm.Show();
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

        private void Branch_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmbSession.Items.Clear();
            cmbSession.Text = "";
            cmbSession.Enabled = true;
            cmbSession.Focus();

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();


                string ct = "select distinct RTRIM(Session) from Batch where ClassName = '" + cmbClassName.Text + "' and FacultyName = '" + cmbFaculty.Text + "' order by 1 ";

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

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private void ClearTextBoxes()
        {
            StudentName.Text = "";
            DateOfAdmission.Text = DateTime.Today.ToString();
            FatherName.Text = "";
            CNIC.Text = "";
            FatherCNIC.Text = "";
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            DOB.Text = "";
            Address.Text = "";
            BloodGroup.Text = "";
            ContactNo.Text = "";
            GuardianName.Text = "";
            GuardianContactNo.Text = "";
            GuardianAddress.Text = "";
            Picture.Image = Properties.Resources.photo;
        }
        private void cmbRollNo_TextChanged(object sender, EventArgs e)
        {

            if (cmbRollNo.Text == "")
            {
                ClearTextBoxes();
            }
            else
            {
                ClearTextBoxes();
                cmbFaculty.Enabled = false;
                btnPrint.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate_record.Enabled = false;
                deleteToolStripMenuItem1.Enabled = false;
                updateToolStripMenuItem.Enabled = false;
                printToolStripMenuItem.Enabled = false;
                try
                {
                    cmbRollNo.Text = cmbRollNo.Text.TrimEnd();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "select RTRIM(StudentName)[Student Name],RTRIM(CNIC)[CINC], RTRIM(FatherName)[Father Name], RTRIM(FatherCNIC)[Father CNIC], RTRIM(Gender)[Gender],RTRIM(BloodGroup)[BloodGroup], RTRIM(DateOfBirth)[DOB],RTRIM(StudentAddress)[Address],RTRIM(ContactNo)[Contact No.] ,RTRIM(DateOfadmission)[Date Of Admission], AdmissionStatusId [Status],RTRIM(GuardianName)[Guardian Name], RTRIM(GuardianContactNo)[Guardian Contact No.], RTRIM(GuardianAddress)[Guardian Address],Photo from Student where classNo = '" + cmbRollNo.Text + "' and departmentId = (Select Departmentid from department where className = '"+cmbClassName.Text.Trim()+"' and FacultyName = '"+cmbFaculty.Text.Trim()+"') and Sessionid = (Select Sessionid from Session where Description = '"+cmbSession.Text.Trim()+"')";
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        StudentName.Text = (rdr.GetString(0).Trim());
                        CNIC.Text = (rdr.GetString(1).Trim());
                        FatherName.Text = (rdr.GetString(2).Trim());
                        FatherCNIC.Text = (rdr.GetString(3).Trim());
                        if ((rdr.GetString(4).Trim()) == "Male")
                        {
                            rdbMale.Checked = true;
                        }   
                        else if ((rdr.GetString(4).Trim()) == "Female")
                        {
                            rdbFemale.Checked = true;
                        }
                        BloodGroup.Text = (rdr.GetString(5).Trim());
                        DOB.Text = (rdr.GetString(6).Trim());
                        Address.Text = (rdr.GetString(7).Trim());
                        ContactNo.Text = (rdr.GetString(8).Trim());
                        DateOfAdmission.Text = (rdr.GetString(9).Trim());
                        if (rdr.GetInt32(10) == 1)
                        {
                            cmbStatus.Text = ("Admit");
                        }
                        else if (rdr.GetInt32(10) == 2)
                        {
                            cmbStatus.Text = ("Cancel Admission");
                        }
                        else if (rdr.GetInt32(10) == 3)
                        {
                            cmbStatus.Text = ("Re Admit");
                        }
                        GuardianName.Text = (rdr.GetString(11).Trim());
                        GuardianContactNo.Text = (rdr.GetString(12).Trim());
                        GuardianAddress.Text = (rdr.GetString(13).Trim());
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
            if (label19.Text == "Admin"|| label19.Text == "AdmissionOfficier")
            {
                btnUpdate_record.Enabled = true;
                btnDelete.Enabled = true;
                btnPrint.Enabled = true;

            }
            else
            {
                btnUpdate_record.Enabled = false;
                btnDelete.Enabled = false;
                btnPrint.Enabled = true;
            }//end if           

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void NewVideoFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBoxCamera.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
           
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                VideoDevices.Stop();
                pictureBoxCamera.Image = Properties.Resources.camera_120px;
            }
            catch (Exception)
            {
                MessageBox.Show("Video is not started");
            }
            
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (pictureBoxCamera.Image == Properties.Resources.camera_120px)
            {
                Picture.Image = Properties.Resources.user_120px;
            }
            else
            {
                Picture.Image = pictureBoxCamera.Image;
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Picture.Image = Properties.Resources.user_120px;

        }

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

        private void FatherName_Validating(object sender, CancelEventArgs e)
        {

        }

        private void FatherCNIC_Validating(object sender, CancelEventArgs e)
        {
          
        }

 

        private void cmbRollNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void Picture_Click(object sender, EventArgs e)
        {

        }

        private void Picture_DoubleClick(object sender, EventArgs e)
        {
            var _with1 = openFileDialog1;

            _with1.Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif; *.ico");
            _with1.FilterIndex = 4;

            //Reset the file name
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Picture.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void pictureBoxCamera_DoubleClick(object sender, EventArgs e)
        {
            if (cmbCamInfo.Text == string.Empty)
            {


                MessageBox.Show("Please Select Camera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Picture.Focus();
                return;

            }
            else
            {
                try
                {
                    VideoDevices = new VideoCaptureDevice(CaptureDevice[cmbCamInfo.SelectedIndex].MonikerString);
                    VideoDevices.NewFrame += new NewFrameEventHandler(NewVideoFrame);
                    VideoDevices.Start();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBoxCamera_Click(object sender, EventArgs e)
        {

        }

    }
    }