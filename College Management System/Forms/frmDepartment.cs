using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace College_Management_System
{
    public partial class frmCourse : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();


        public frmCourse()
        {
            InitializeComponent();
        }

        private void clearTextFields()
        {
            txtClassId.Text = "";
            txtClassName.Text = "";
            txtFacultyName.Text = "";
            txtClassName.Focus();
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            txtClassId.Visible = false;
            label5.Visible = false;
            btnSave.Enabled = true;
        }

        private void NewRecord_Click(object sender, EventArgs e)
        {
            clearTextFields();
           
        }

        private void AutocompleteClassName()
        {
            try{
            con = new SqlConnection(cs.DBConn);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT distinct ClassName FROM Department", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Class");
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            int i = 0;
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                col.Add(ds.Tables[0].Rows[i]["ClassName"].ToString());
            }
                txtClassName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtClassName.AutoCompleteCustomSource = col;
                txtClassName.AutoCompleteMode = AutoCompleteMode.Suggest;
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
            if (txtClassName.Text == "")
            {
                MessageBox.Show("Please enter Class name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClassName.Focus();
                return;
            }
            if (txtFacultyName.Text == "")
            {
                MessageBox.Show("Please enter Faculty name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFacultyName.Focus();
                return;
            }
            #endregion
            try
            {
                #region Avoid Duplicate Data
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ClassName,FacultyName from Department where ClassName= '" + txtClassName.Text + "' and FacultyName= '" + txtFacultyName.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Department Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClassName.Text = "";
                    txtFacultyName.Text = "";
                    txtClassName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Department(ClassName,FacultyName) VALUES (@classname,@facultyname)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@classname", System.Data.SqlDbType.NChar, 50, "ClassName"));
                cmd.Parameters.Add(new SqlParameter("@facultyname", System.Data.SqlDbType.NChar, 50, "FacultyName"));
                cmd.Parameters["@classname"].Value = txtClassName.Text.Trim();
                cmd.Parameters["@facultyname"].Value = txtFacultyName.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Department Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AutocompleteClassName();
                AutocompleteFacultyName();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update_record_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (txtClassId.Text == "")
                {
                    #region Validation
                    MessageBox.Show("Please enter Department Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClassId.Focus();
                    return;
                    #endregion
                }
                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "update Department set ClassName=@classname,FacultyName=@facultyname where DepartmentId=@departmentId";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@departmentId", System.Data.SqlDbType.Int, 20, "DepartmentId"));
                    cmd.Parameters.Add(new SqlParameter("@classname", System.Data.SqlDbType.NChar, 20, "ClassName"));
                    cmd.Parameters.Add(new SqlParameter("@facultyname", System.Data.SqlDbType.NChar, 30, "FacultyName"));
                    cmd.Parameters["@departmentId"].Value = Convert.ToInt32(txtClassId.Text);
                    cmd.Parameters["@classname"].Value = txtClassName.Text.Trim();
                    cmd.Parameters["@facultyname"].Value = txtFacultyName.Text.Trim();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnUpdate_record.Enabled = false;
                    AutocompleteClassName();
                    AutocompleteFacultyName();
                    con.Close();
                }

            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                //check in Student Table 
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "Select Distinct(Student.DepartmentId)  From Student INNER JOIN Department On Student.DepartmentId=Department.DepartmentId  where   Department.ClassName = '" + txtClassName.Text.Trim() + "' and Department.FacultyName= '" + txtFacultyName.Text.Trim() + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnDelete.Enabled = false;
                    btnUpdate_record.Enabled = false;
                    AutocompleteClassName();
                    AutocompleteFacultyName();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                //check in SubjectDetails Table 
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct1 = "Select Distinct(SubjectDetails.DepartmentId)  From SubjectDetails INNER JOIN Department On SubjectDetails.DepartmentId=Department.DepartmentId  where  Department.ClassName = '" + txtClassName.Text.Trim() + "' and Department.FacultyName= '" + txtFacultyName.Text.Trim() + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnDelete.Enabled = false;
                    btnUpdate_record.Enabled = false;
                    AutocompleteClassName();
                    AutocompleteFacultyName();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                //check in SemesterFees Table 
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "Select Distinct(SemesterFees.DepartmentId)  From SemesterFees INNER JOIN Department On SemesterFees.DepartmentId=Department.DepartmentId  where Department.ClassName = '" + txtClassName.Text.Trim() + "' and Department.FacultyName= '" + txtFacultyName.Text.Trim() + "'";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnDelete.Enabled = false;
                    btnUpdate_record.Enabled = false;
                    AutocompleteClassName();
                    AutocompleteFacultyName();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                //check in Result Table 
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct3 = "Select Distinct(Result.DepartmentId)  From Result INNER JOIN Department On Result.DepartmentId=Department.DepartmentId  where  Department.ClassName = '" + txtClassName.Text.Trim() + "' and Department.FacultyName= '" + txtFacultyName.Text.Trim() + "'";
                cmd = new SqlCommand(ct3);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnDelete.Enabled = false;
                    btnUpdate_record.Enabled = false;
                    AutocompleteClassName();
                    AutocompleteFacultyName();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                //check in SemesterResult Table 
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct4 = "Select Distinct(SemesterResult.DepartmentId)  From SemesterResult INNER JOIN Department On SemesterResult.DepartmentId=Department.DepartmentId  where  Department.ClassName = '" + txtClassName.Text.Trim() + "' and Department.FacultyName= '" + txtFacultyName.Text.Trim() + "'";
                cmd = new SqlCommand(ct4);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnDelete.Enabled = false;
                    btnUpdate_record.Enabled = false;
                    AutocompleteClassName();
                    AutocompleteFacultyName();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                //Delete Record
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from Department where Departmentid=@departmentid;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@departmentid", System.Data.SqlDbType.Int, 15, "DepartmentId"));
                cmd.Parameters["@departmentid"].Value = Convert.ToInt32(txtClassId.Text);
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearTextFields();
                    btnDelete.Enabled = false;
                    btnUpdate_record.Enabled = false;
                    AutocompleteClassName();
                    AutocompleteFacultyName();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearTextFields();
                    btnDelete.Enabled = false;
                    btnUpdate_record.Enabled = false;
                    AutocompleteClassName();
                    AutocompleteFacultyName();
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

        private void AutocompleteFacultyName()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT distinct FacultyName FROM Department", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "My List");
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            int i;
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                col.Add(ds.Tables[0].Rows[i]["FacultyName"].ToString());
            }
            txtFacultyName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtFacultyName.AutoCompleteCustomSource = col;
            txtFacultyName.AutoCompleteMode = AutoCompleteMode.Suggest;
            con.Close();
        }

        private void Course_Load(object sender, EventArgs e)
        {
            AutocompleteClassName();
            AutocompleteFacultyName();
            txtClassName.Focus();
        }

        public void GetDetails_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmClassRecord form2 = new frmClassRecord();
            form2.label1.Text = label1.Text;
            form2.Show();
        }

        private void CourseName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void BranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtCourseName_TextChanged(object sender, EventArgs e)
        {
            txtClassName.Text = txtClassName.Text.Trim();
        }

        private void txtBranchName_TextChanged(object sender, EventArgs e)
        {
            txtFacultyName.Text = txtFacultyName.Text.Trim();
        }

    }
}
