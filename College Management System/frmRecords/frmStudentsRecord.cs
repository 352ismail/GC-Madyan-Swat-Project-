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
using Excel = Microsoft.Office.Interop.Excel;

namespace College_Management_System.frmRecords
{
    public partial class frmStudentsRecord : Form
    {

        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmStudentsRecord()
        {
            InitializeComponent();
        }

        private void frmStudentsRecord_Load(object sender, EventArgs e)
        {
            AutocompleteClass();
            AutocompleteStudentRollNo();
        }
        private void AutocompleteClass()
        {
            try
            {
                cmbCourse.Items.Clear();
                cmbCLassName2.Items.Clear();
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(ClassName) FROM Department", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                foreach (DataRow drow in dtable.Rows)
                {
                    cmbCourse.Items.Add(drow[0].ToString());
                    cmbCLassName2.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AutocompleteStudentRollNo()
        {

            try
            {


                SqlConnection CN = new SqlConnection(cs.DBConn);

                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(RollNo) FROM StudentRegistration", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                cmbRollNo.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    cmbRollNo.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBranch.Items.Clear();
            cmbBranch.Text = "";
            cmbBranch.Enabled = true;

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(FacultyName) from Department where ClassName = '" + cmbCourse.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbBranch.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSession.Items.Clear();
            cmbSession.Text = "";
            cmbSession.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Description) from Session ";

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

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validation
             
                if (cmbCourse.Text == "")
                {
                    MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbCourse.Focus();
                    return;
                }
                if (cmbBranch.Text == "")
                {
                    MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbBranch.Focus();
                    return;
                }
                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSession.Focus();
                    return;
                }
                #endregion
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(ClassNo)[Class No.], RTRIM(StudentName)[Student Name], RTRIM(FatherName)[Father Name], RTRIM(CNIC)[CNIC Number], RTRIM(FatherCNIC)[Father CNIC],RTRIM(Gender)[Gender],RTRIM(DateOfBirth)[Date Of Birth],  RTRIM(StudentAddress)[Address],RTRIM(BloodGroup)[Blood Group],   RTRIM(ContactNo)[Contact No], RTRIM(GuardianName)[Guardian Name],RTRIM(GuardianContactNo)[Guardian Contact No], RTRIM(GuardianAddress)[Guardian Address],RTRIM(DateOfAdmission)[Date Of Admission],RTRIM(AdmissionStatus.Description)[Status] from Student INNER JOIN AdmissionStatus On Student.AdmissionStatusId = AdmissionStatus.AdmissionStatusId INNER JOIN Department On Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId Where Department.ClassName = '" + cmbCourse.Text.Trim() + "' and Department.FacultyName = '" + cmbBranch.Text.Trim() + "'  and Session.Description ='" + cmbSession.Text.Trim() + "' Order By ClassNo", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Student");
                dataGridView1.DataSource = myDataSet.Tables["Student"].DefaultView;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Columns["Father CNIC"].Visible = false;
                    dataGridView1.Columns["Guardian Name"].Visible = false;
                    dataGridView1.Columns["Guardian Contact No"].Visible = false;
                    dataGridView1.Columns["Guardian Address"].Visible = false;
                    dataGridView1.Columns["Date Of Admission"].Visible = false;
                    dataGridView1.Columns["Blood Group"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tab1Reset()
        {
            cmbCourse.Text = "";
            cmbBranch.Text = "";
            cmbSession.Text = "";
            dataGridView1.DataSource = null;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            tab1Reset();
        }

        private void ExportExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            try
            {
                Microsoft.Office.Interop.Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView1.RowCount - 1;
                colsTotal = dataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView1.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            #region Validation
            if (cmbCourse.Text == "")
            {
                MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCourse.Focus();
                return;
            }
            if (cmbBranch.Text == "")
            {
                MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbBranch.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            } 

            if (dataGridView1.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            this.Hide();
            frmStudent frm = new frmStudent();
            // or simply use column name instead of index
            dr.Cells["Class No."].Value.ToString();
            frm.Show();
            frm.cmbClassName.Text = cmbCourse.Text.Trim();
            frm.cmbFaculty.Text = cmbBranch.Text.Trim();
            frm.cmbSession.Text = cmbSession.Text.Trim();
            frm.cmbRollNo.Text = dr.Cells[0].Value.ToString();
         
            if (label17.Text == "Admin")
            {
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.cmbClassName.Focus();
                frm.btnSave.Enabled = false;
                frm.label19.Text = label17.Text;
            }
            else
            {
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.cmbClassName.Focus();
                frm.label19.Text = label17.Text;

            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void frmStudentsRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmStudent frm = new frmStudent();
            frm.label19.Text = label17.Text;
            frm.Show();
        }

        private void cmbCLassName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFaculty2.Items.Clear();
            cmbFaculty2.Text = "";
            cmbFaculty2.Enabled = true;

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(FacultyName) from Department where ClassName = '" + cmbCLassName2.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbFaculty2.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFaculty2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSession2.Items.Clear();
            cmbSession2.Text = "";
            cmbSession2.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Description) from Session ";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbSession2.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSession2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbStatus2.Items.Clear();
            cmbStatus2.Text = "";
            cmbStatus2.Enabled = true;

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Description) from AdmissionStatus";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbStatus2.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Get2_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validation
                if (cmbCLassName2.Text == "")
                {
                    MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbCLassName2.Focus();
                    return;
                }
                if (cmbFaculty2.Text == "")
                {
                    MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFaculty2.Focus();
                    return;
                }
                if (cmbSession2.Text == "")
                {
                    MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSession2.Focus();
                    return;
                }
                if (cmbStatus2.Text == "")
                {
                    MessageBox.Show("Please select  Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbStatus2.Focus();
                    return;
                }
                #endregion
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTrim(ClassNo)[Class No.], RTRIM(StudentName)[Student Name], RTRIM(FatherName)[Father Name], RTRIM(CNIC)[CNIC Number], RTRIM(FatherCNIC)[Father CNIC],RTRIM(Gender)[Gender],RTRIM(DateOfBirth)[Date Of Birth],  RTRIM(StudentAddress)[Address],RTRIM(BloodGroup)[Blood Group],   RTRIM(ContactNo)[Contact No], RTRIM(GuardianName)[Guardian Name],RTRIM(GuardianContactNo)[Guardian Contact No], RTRIM(GuardianAddress)[Guardian Address],RTRIM(DateOfAdmission)[Date Of Admission],RTRIM(AdmissionStatus.Description)[Status] from Student INNER JOIN AdmissionStatus On Student.AdmissionStatusId = AdmissionStatus.AdmissionStatusId INNER JOIN Department On Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId Where Department.ClassName = '" + cmbCLassName2.Text.Trim() + "' and Department.FacultyName = '" + cmbFaculty2.Text.Trim() + "'  and Session.Description ='" + cmbSession2.Text.Trim() + "' and AdmissionStatus.Description = '" + cmbStatus2.Text.Trim() + "' Order By ClassNo", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Student");
                dataGridView5.DataSource = myDataSet.Tables["Student"].DefaultView;
                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
                    dataGridView5.Columns["Father CNIC"].Visible = false;
                    dataGridView5.Columns["Guardian Name"].Visible = false;
                    dataGridView5.Columns["Guardian Contact No"].Visible = false;
                    dataGridView5.Columns["Guardian Address"].Visible = false;
                    dataGridView5.Columns["Date Of Admission"].Visible = false;
                    dataGridView5.Columns["Blood Group"].Visible = false;
                }
                con.Close();          
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Tab2Reset()
        {
            cmbCLassName2.Text = "";
            cmbFaculty2.Text = "";
            cmbSession2.Text = "";
            cmbStatus2.Text = "";
            dataGridView5.DataSource = null;
        }
        private void Reset2_Click(object sender, EventArgs e)
        {
            Tab2Reset();
        }

        private void dataGridView5_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            #region Validation
            if (cmbCLassName2.Text == "")
            {
                MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCLassName2.Focus();
                return;
            }
            if (cmbFaculty2.Text == "")
            {
                MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFaculty2.Focus();
                return;
            }
            if (cmbSession2.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession2.Focus();
                return;
            }
            if (cmbStatus2.Text == "")
            {
                MessageBox.Show("Please select  Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbStatus2.Focus();
                return;
            }

            if (dataGridView5.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
            DataGridViewRow dr = dataGridView5.SelectedRows[0];
            this.Hide();
            frmStudent frm = new frmStudent();
            // or simply use column name instead of index
            dr.Cells["Class No."].Value.ToString();
            frm.Show();
            frm.cmbClassName.Text = cmbCLassName2.Text.Trim();
            frm.cmbFaculty.Text = cmbFaculty2.Text.Trim();
            frm.cmbSession.Text = cmbSession2.Text.Trim();
            frm.cmbRollNo.Text = dr.Cells[0].Value.ToString();

            if (label17.Text == "Admin")
            {
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.cmbClassName.Focus();
                frm.btnSave.Enabled = false;
                frm.label19.Text = label17.Text;
            }
            else
            {
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.cmbClassName.Focus();
                frm.label19.Text = label17.Text;

            }
        }

        private void Export2_Click(object sender, EventArgs e)
        {
            if (dataGridView5.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            try
            {
                Microsoft.Office.Interop.Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView5.RowCount - 1;
                colsTotal = dataGridView5.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView5.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView5.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

       

        private void dataGridView5_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }
        private void Tab3Reset()
        {
            cmbRollNo.Text = "";
            txtRollNo.Text = "";
            dataGridView4.DataSource = null;
        }

        private void Reset3_Click(object sender, EventArgs e)
        {
            Tab3Reset();
        }

        private void cmbRollNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTrim(Department.ClassName)[Program],RTrim(Department.FacultyName)[Faculty],RTrim(Session.Description)[Session], RTrim(ClassNo)[Class No.],RTrim(StudentRegistration.RollNo)[Roll No.], RTRIM(StudentName)[Student Name], RTRIM(FatherName)[Father Name], RTRIM(CNIC)[CNIC Number], RTRIM(FatherCNIC)[Father CNIC],RTRIM(Gender)[Gender],RTRIM(DateOfBirth)[Date Of Birth],  RTRIM(StudentAddress)[Address],RTRIM(BloodGroup)[Blood Group],   RTRIM(ContactNo)[Contact No], RTRIM(GuardianName)[Guardian Name],RTRIM(GuardianContactNo)[Guardian Contact No], RTRIM(GuardianAddress)[Guardian Address],RTRIM(DateOfAdmission)[Date Of Admission],RTRIM(AdmissionStatus.Description)[Status] from Student INNER JOIN AdmissionStatus On Student.AdmissionStatusId = AdmissionStatus.AdmissionStatusId INNER JOIN Department On Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN StudentRegistration On Student.StudentId = StudentRegistration.StudentId where  StudentRegistration.RollNo = '" + cmbRollNo.Text.Trim() + "' ", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Student");
                dataGridView4.DataSource = myDataSet.Tables["Student"].DefaultView;
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    dataGridView4.Columns["Father CNIC"].Visible = false;
                    dataGridView4.Columns["Address"].Visible = false;
                    dataGridView4.Columns["Father CNIC"].Visible = false;                   
                    dataGridView4.Columns["Contact No"].Visible = false;
                    dataGridView4.Columns["Guardian Name"].Visible = false;
                    dataGridView4.Columns["Guardian Contact No"].Visible = false;
                    dataGridView4.Columns["Guardian Address"].Visible = false;
                    dataGridView4.Columns["Date Of Admission"].Visible = false;
                    dataGridView4.Columns["Blood Group"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView4_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            #region Validation
            if (dataGridView4.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
            DataGridViewRow dr = dataGridView4.SelectedRows[0];
            this.Hide();
            frmStudent frm = new frmStudent();
            // or simply use column name instead of index
            dr.Cells["program"].Value.ToString();
            frm.Show();
            frm.cmbClassName.Text = dr.Cells[0].Value.ToString();
            frm.cmbFaculty.Text = dr.Cells[1].Value.ToString();
            frm.cmbSession.Text = dr.Cells[2].Value.ToString();
            frm.cmbRollNo.Text = dr.Cells[3].Value.ToString();

            if (label17.Text == "Admin")
            {
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.cmbClassName.Focus();
                frm.btnSave.Enabled = false;
                frm.label19.Text = label17.Text;
            }
            else
            {
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.cmbClassName.Focus();
                frm.label19.Text = label17.Text;

            }
        }

        private void dataGridView4_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void Export3_Click(object sender, EventArgs e)
        {
            if (dataGridView4.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            try
            {
                Microsoft.Office.Interop.Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView4.RowCount - 1;
                colsTotal = dataGridView4.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView4.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView4.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void txtRollNo_TextChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTrim(Department.ClassName)[Program],RTrim(Department.FacultyName)[Faculty],RTrim(Session.Description)[Session], RTrim(ClassNo)[Class No.],RTrim(StudentRegistration.RollNo)[Roll No.], RTRIM(StudentName)[Student Name], RTRIM(FatherName)[Father Name], RTRIM(CNIC)[CNIC Number], RTRIM(FatherCNIC)[Father CNIC],RTRIM(Gender)[Gender],RTRIM(DateOfBirth)[Date Of Birth],  RTRIM(StudentAddress)[Address],RTRIM(BloodGroup)[Blood Group],   RTRIM(ContactNo)[Contact No], RTRIM(GuardianName)[Guardian Name],RTRIM(GuardianContactNo)[Guardian Contact No], RTRIM(GuardianAddress)[Guardian Address],RTRIM(DateOfAdmission)[Date Of Admission],RTRIM(AdmissionStatus.Description)[Status] from Student INNER JOIN AdmissionStatus On Student.AdmissionStatusId = AdmissionStatus.AdmissionStatusId INNER JOIN Department On Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN StudentRegistration On Student.StudentId = StudentRegistration.StudentId where  StudentRegistration.RollNo like '" + txtRollNo.Text.Trim() + "%' ", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Student");
                dataGridView4.DataSource = myDataSet.Tables["Student"].DefaultView;
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    dataGridView4.Columns["Father CNIC"].Visible = false;
                    dataGridView4.Columns["Address"].Visible = false;
                    dataGridView4.Columns["Father CNIC"].Visible = false;
                    dataGridView4.Columns["Contact No"].Visible = false;
                    dataGridView4.Columns["Guardian Name"].Visible = false;
                    dataGridView4.Columns["Guardian Contact No"].Visible = false;
                    dataGridView4.Columns["Guardian Address"].Visible = false;
                    dataGridView4.Columns["Date Of Admission"].Visible = false;
                    dataGridView4.Columns["Blood Group"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRollNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtStudent_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtStudent_TextChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTrim(Department.ClassName)[Program],RTrim(Department.FacultyName)[Faculty],RTrim(Session.Description)[Session], RTrim(ClassNo)[Class No.], RTRIM(StudentName)[Student Name], RTRIM(FatherName)[Father Name], RTRIM(CNIC)[CNIC Number], RTRIM(FatherCNIC)[Father CNIC],RTRIM(Gender)[Gender],RTRIM(DateOfBirth)[Date Of Birth],  RTRIM(StudentAddress)[Address],RTRIM(BloodGroup)[Blood Group],   RTRIM(ContactNo)[Contact No], RTRIM(GuardianName)[Guardian Name],RTRIM(GuardianContactNo)[Guardian Contact No], RTRIM(GuardianAddress)[Guardian Address],RTRIM(DateOfAdmission)[Date Of Admission],RTRIM(AdmissionStatus.Description)[Status] from Student INNER JOIN AdmissionStatus On Student.AdmissionStatusId = AdmissionStatus.AdmissionStatusId INNER JOIN Department On Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId  where  Student.StudentName like '" + txtStudent.Text.Trim() + "%' ", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Student");
                dataGridView3.DataSource = myDataSet.Tables["Student"].DefaultView;
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {             
                    dataGridView3.Columns["Address"].Visible = false;
                    dataGridView3.Columns["Father CNIC"].Visible = false;
                    dataGridView3.Columns["Guardian Name"].Visible = false;
                    dataGridView3.Columns["Guardian Contact No"].Visible = false;
                    dataGridView3.Columns["Guardian Address"].Visible = false;
                    dataGridView3.Columns["Date Of Admission"].Visible = false;
                    dataGridView3.Columns["Blood Group"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tab4Reset()
        {
            txtStudent.Text = "";
            dataGridView3.DataSource = null;
        }
            
        private void button8_Click(object sender, EventArgs e)
        {
            Tab4Reset();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView3.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            try
            {
                Microsoft.Office.Interop.Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView3.RowCount - 1;
                colsTotal = dataGridView3.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView3.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView3.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            #region Validation
            if (dataGridView3.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
            DataGridViewRow dr = dataGridView3.SelectedRows[0];
            this.Hide();
            frmStudent frm = new frmStudent();
            // or simply use column name instead of index
            dr.Cells["program"].Value.ToString();
            frm.Show();
            frm.cmbClassName.Text = dr.Cells[0].Value.ToString();
            frm.cmbFaculty.Text = dr.Cells[1].Value.ToString();
            frm.cmbSession.Text = dr.Cells[2].Value.ToString();
            frm.cmbRollNo.Text = dr.Cells[3].Value.ToString();

            if (label17.Text == "Admin")
            {
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.cmbClassName.Focus();
                frm.btnSave.Enabled = false;
                frm.label19.Text = label17.Text;
            }
            else
            {
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.cmbClassName.Focus();
                frm.label19.Text = label17.Text;

            }

        }

        private void dataGridView3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTrim(Department.ClassName)[Program],RTrim(Department.FacultyName)[Faculty],RTrim(Session.Description)[Session], RTrim(ClassNo)[Class No.], RTRIM(StudentName)[Student Name], RTRIM(FatherName)[Father Name], RTRIM(CNIC)[CNIC Number], RTRIM(FatherCNIC)[Father CNIC],RTRIM(Gender)[Gender],RTRIM(DateOfBirth)[Date Of Birth],  RTRIM(StudentAddress)[Address],RTRIM(BloodGroup)[Blood Group],   RTRIM(ContactNo)[Contact No], RTRIM(GuardianName)[Guardian Name],RTRIM(GuardianContactNo)[Guardian Contact No], RTRIM(GuardianAddress)[Guardian Address],RTRIM(DateOfAdmission)[Date Of Admission],RTRIM(AdmissionStatus.Description)[Status] from Student INNER JOIN AdmissionStatus On Student.AdmissionStatusId = AdmissionStatus.AdmissionStatusId INNER JOIN Department On Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId  where DateOfAdmission Between @date1 and @date2 ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " DateOfAdmission").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " DateOfAdmission").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Student");
                dataGridView2.DataSource = myDataSet.Tables["Student"].DefaultView;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    dataGridView2.Columns["Address"].Visible = false;
                    dataGridView2.Columns["Father CNIC"].Visible = false;
                    dataGridView2.Columns["Guardian Name"].Visible = false;
                    dataGridView2.Columns["Guardian Contact No"].Visible = false;
                    dataGridView2.Columns["Guardian Address"].Visible = false;
                    dataGridView2.Columns["Date Of Admission"].Visible = false;
                    dataGridView2.Columns["Blood Group"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tab5Reset()
        {
            DateFrom.Text = DateTime.Now.ToString();
            DateTo.Text = DateTime.Now.ToString();
            dataGridView2.DataSource = null;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Tab5Reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            try
            {
                Microsoft.Office.Interop.Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView2.RowCount - 1;
                colsTotal = dataGridView2.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView2.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView2.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            #region Validation
            if (dataGridView2.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            this.Hide();
            frmStudent frm = new frmStudent();
            // or simply use column name instead of index
            dr.Cells["program"].Value.ToString();
            frm.Show();
            frm.cmbClassName.Text = dr.Cells[0].Value.ToString();
            frm.cmbFaculty.Text = dr.Cells[1].Value.ToString();
            frm.cmbSession.Text = dr.Cells[2].Value.ToString();
            frm.cmbRollNo.Text = dr.Cells[3].Value.ToString();

            if (label17.Text == "Admin")
            {
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.cmbClassName.Focus();
                frm.btnSave.Enabled = false;
                frm.label19.Text = label17.Text;
            }
            else
            {
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.cmbClassName.Focus();
                frm.label19.Text = label17.Text;

            }
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            tab1Reset();
            Tab2Reset();
            Tab3Reset();
            Tab4Reset();
            Tab5Reset();
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbStatus2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
