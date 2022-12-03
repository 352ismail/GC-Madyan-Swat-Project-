using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace College_Management_System.Forms
{
    public partial class frmSemesterSubjects : Form
    {



        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
      
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmSemesterSubjects()
        {
            InitializeComponent();
        }

        private void SemesterSubjects_Load(object sender, EventArgs e)
        {
            AutocompleteClassName();
        }


        private void AutocompleteClassName()
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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
                string ct = "select distinct RTRIM(Description) from Session Where IsActive = 'true'";
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

        private void cmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSubjectName.Items.Clear();
            cmbSubjectName.Text = "";
            cmbSubjectName.Enabled = true;
            cmbSubjectName.Focus();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(SubjectName) from Subject ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbSubjectName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSubjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "select RTRIM(SubjectCode),CH from Subject where SubjectName = '" + cmbSubjectName.Text.Trim() + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    txtSubjectCode.Text = rdr.GetString(0).Trim();
                    txtcreditHour.Text = rdr.GetInt32(1).ToString();
                }
                if ((rdr != null))
                {   rdr.Close(); }
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

        private void NewRecord_Click(object sender, EventArgs e)
        {
            ResetTextFields();
           
        }
        private void ResetTextFields()
        {
            txtSubjectCode.Text = "";
            txtcreditHour.Text = "";
            cmbSubjectName.Text = "";
            txtSemesterSubjectId.Text = "";
            cmbClassName.Text = "";
            cmbFaculty.Text = "";
            cmbSession.Text = "";
            cmbSemester.Text = "";
            txtSemesterSubjectId.Visible = false;
            lblSemesterSubjectId.Visible = false;
            btnSave.Enabled = true;
            Delete.Enabled = false;
            Update_record.Enabled = false;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Validation
            if (cmbClassName.Text == "")
            {
                MessageBox.Show("Please Select Class Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName.Focus();
                return;
            }
            if (cmbFaculty.Text == "")
            {
                MessageBox.Show("Please Select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFaculty.Focus();
                return;
            }
            if (cmbSemester.Text == "")
            {
                MessageBox.Show("Please Select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSemester.Focus();
                return;
            }
            if (cmbSubjectName.Text == "")
            {
                MessageBox.Show("Please Select Subject Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSubjectName.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please Select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            #endregion
            try
            {
                #region Avoid Duplicate Data
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select SubjectId,DepartmentId,SemesterId,SessionId from SubjectDetails where SubjectId=(select SubjectId from Subject where SubjectName = '" + cmbSubjectName.Text.Trim() + "'and SubjectCode = '" + txtSubjectCode.Text.Trim() + "') and DepartmentId = (select Departmentid from Department where ClassName = '" + cmbClassName.Text.Trim() + "' and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SemesterId = (select SemesterId from Semester where Description = '" + cmbSemester.Text.Trim() + "') and SessionId = (select SessionId from Session where Session.Description = '" + cmbSession.Text.Trim() + "')";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Subject Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSubjectName.Text = "";
                    txtSubjectCode.Text = "";
                    txtcreditHour.Text = "";
                    cmbSubjectName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into SubjectDetails(DepartmentId,SubjectId,SemesterId,SessionId) VALUES ((select Departmentid from Department where ClassName = '" + cmbClassName.Text.Trim() + "' and FacultyName = '" + cmbFaculty.Text.Trim() + "'),(select SubjectId from Subject where SubjectName = '" + cmbSubjectName.Text.Trim() + "' AND SubjectCode = '" + txtSubjectCode.Text.Trim() + "') ,(select SemesterId from Semester where Description = '" + cmbSemester.Text.Trim() + "'),(select SessionId from Session where Session.Description = '" + cmbSession.Text.Trim() + "'))";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void ViewRecord_Click(object sender, EventArgs e)
        {
            this.Hide();
            Forms.frmSemesterSubjectsRecord frm = new frmSemesterSubjectsRecord();
            frm.label6.Text = label3.Text;
            frm.Show();           
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
                #region Validation
                if (txtSemesterSubjectId.Text == "")
                {
                    MessageBox.Show("Please Select Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSemesterSubjectId.Focus();
                    return;
                }
                if (cmbClassName.Text == "")
                {
                    MessageBox.Show("Please Select Class Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClassName.Focus();
                    return;
                }
                if (cmbFaculty.Text == "")
                {
                    MessageBox.Show("Please Select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFaculty.Focus();
                    return;
                }
                if (cmbSemester.Text == "")
                {
                    MessageBox.Show("Please Select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSemester.Focus();
                    return;
                }
                if (cmbSubjectName.Text == "")
                {
                    MessageBox.Show("Please Select Subject Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSubjectName.Focus();
                    return;
                }
                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please Select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSession.Focus();
                    return;
                }
                #endregion
                int RowsAffected = 0;
                // check in Result Table
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct1 = "Select Distinct(Result.SubjectId),(Result.DepartmentId),(Result.SessionId),(Result.SemesterId)  From Result INNER JOIN Subject On Result.SubjectId=Subject.SubjectId INNER JOIN Semester On Result.SemesterId=Semester.SemesterId  INNER JOIN Session On Result.SessionId=Session.SessionId   INNER JOIN Department On Result.DepartmentId=Department.DepartmentId  where Subject.SubjectName ='" + cmbSubjectName.Text.Trim() + "' AnD Subject.SubjectCode ='" + txtSubjectCode.Text.Trim() + "' AND Subject.CH = '" + txtcreditHour.Text.Trim() + "' AND Department.ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName= '" + cmbFaculty.Text.Trim() + "'AND Semester.Description = '" + cmbSemester.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetTextFields();
                    Delete.Enabled = false;
                    Update_record.Enabled = false;
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from SubjectDetails where SubjectDetailsId=@subjectdetailsid;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@subjectdetailsid", System.Data.SqlDbType.Int, 10, "SubjectDetailsId"));
                cmd.Parameters["@subjectdetailsid"].Value = Convert.ToInt32(txtSemesterSubjectId.Text);
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetTextFields();
                    
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetTextFields();
                  
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

        private void Update_record_Click(object sender, EventArgs e)
        {
            #region Validation
            if (txtSemesterSubjectId.Text == "")
            {
                MessageBox.Show("Please Select Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSemesterSubjectId.Focus();
                return;
            }
            if (cmbClassName.Text == "")
            {
                MessageBox.Show("Please Select Class Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName.Focus();
                return;
            }
            if (cmbFaculty.Text == "")
            {
                MessageBox.Show("Please Select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFaculty.Focus();
                return;
            }
            if (cmbSemester.Text == "")
            {
                MessageBox.Show("Please Select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSemester.Focus();
                return;
            }
            if (cmbSubjectName.Text == "")
            {
                MessageBox.Show("Please Select Subject Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSubjectName.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please Select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            #endregion
            try
            {
                #region Avoid Duplicate Data
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select SubjectId,DepartmentId,SemesterId,SessionId from SubjectDetails where SubjectId=(select SubjectId from Subject where SubjectName = '" + cmbSubjectName.Text.Trim() + "'and SubjectCode = '" + txtSubjectCode.Text.Trim() + "') and DepartmentId = (select Departmentid from Department where ClassName = '" + cmbClassName.Text.Trim() + "' and FacultyName = '" + cmbFaculty.Text.Trim() + "') and SemesterId = (select SemesterId from Semester where Description = '" + cmbSemester.Text.Trim() + "') and SessionId = (select SessionId from Session where Session.Description = '" + cmbSession.Text.Trim() + "')";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Subject Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSubjectName.Text = "";
                    txtSubjectCode.Text = "";
                    txtcreditHour.Text = "";
                    cmbSubjectName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update SubjectDetails set DepartmentId=(select Departmentid from Department where ClassName = '" + cmbClassName.Text.Trim() + "' and FacultyName = '" + cmbFaculty.Text.Trim() + "'),SubjectId =(select SubjectId from Subject where SubjectName = '" + cmbSubjectName.Text.Trim() + "' and SubjectCode = '" + txtSubjectCode.Text.Trim() + "'),SemesterId=(select SemesterId from Semester where Description = '" + cmbSemester.Text.Trim() + "'),SessionId=(select SessionId from Session where Description = '" + cmbSession.Text.Trim() + "') where SubjectDetailsId = '" + txtSemesterSubjectId.Text.Trim() + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSemester.Items.Clear();
            cmbSemester.Text = "";
            cmbSemester.Enabled = true;
            cmbSemester.Focus();

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();


                string ct = "select distinct RTRIM(Description) from Semester";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbSemester.Items.Add(rdr[0]);
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
