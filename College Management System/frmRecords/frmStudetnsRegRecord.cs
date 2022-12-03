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
    public partial class frmStudetnsRegRecord : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmStudetnsRegRecord()
        {
            InitializeComponent();
        }

        private void frmStudetnsRegRecord_Load(object sender, EventArgs e)
        {
            AutocompleteClass();
            AutocompleteRollNo();
        }

        private void AutocompleteClass()
        {
            try
            {
                cmbClassName.Items.Clear();
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(ClassName) FROM Department", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                foreach (DataRow drow in dtable.Rows)
                {
                    cmbClassName.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void AutocompleteRollNo()
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

        private void cmbClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFaculty.Items.Clear();
            cmbFaculty.Text = "";
            cmbFaculty.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(FacultyName) from Department where ClassName = '" + cmbClassName.Text.Trim() + "'";
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

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbStatus.Items.Clear();
            cmbStatus.Text = "";
            cmbStatus.Enabled = true;

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Description) from RegistrationStatus";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
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

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validation 
                if (cmbClassName.Text == "")
                {
                    MessageBox.Show("Please select Pogram", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClassName.Focus();
                    return;
                }
                if (cmbFaculty.Text == "")
                {
                    MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFaculty.Focus();
                    return;
                }
                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSession.Focus();
                    return;
                }
                if (cmbStatus.Text == "")
                {
                    MessageBox.Show("Please select Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbStatus.Focus();
                    return;
                }
                #endregion
                if (rdbSSC.Checked == true)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select RTrim(StudentRegistration.RegNo)[RegNo],RTrim(StudentRegistration.RollNo)[RollNo],RTrim(Student.ClassNo)[Class No.], RTRIM(StudentName)[Student Name], RTRIM(FatherName)[Father Name],RTRIM(RegistrationDeficiency.Description)[Deficiency],RTRIM(StudentRegistration.YearOfPassing)[Passing Year],RTRIM(StudentRegistration.HSMarks)[Marks],RTRIM(StudentRegistration.HSPercentage)[Percentage],RTRIM(StudentRegistration.HSRollNo)[High School RollNo],RTRIM(StudentRegistration.BoardName)[BoardName] from StudentRegistration INNER JOIN RegistrationDeficiency On StudentRegistration.RegistrationDeficiencyId = RegistrationDeficiency.RegistrationDeficiencyId INNER JOIN Student On Student.StudentId = StudentRegistration.StudentId INNER JOIN RegistrationStatus On StudentRegistration.RegistrationStatusId = RegistrationStatus.RegistrationStatusId INNER JOIN Department On Student.DepartmentId = .Department.DepartmentId INNER JOIN Session On Student.SessionId = .Session.SessionId Where Department.ClassName = '" + cmbClassName.Text.Trim() + "' and Department.FacultyName = '" + cmbFaculty.Text.Trim() + "'  and Session.Description ='" + cmbSession.Text.Trim() + "' and RegistrationStatus.Description = '" + cmbStatus.Text.Trim() + "' AND StudentRegistration.Class = 'SSC'  Order By Student.ClassNo", con);
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    myDA.Fill(myDataSet, "StudentRegistration");
                    dataGridView1.DataSource = myDataSet.Tables["StudentRegistration"].DefaultView;
                    con.Close();
                }
                else if (rdbHSSC.Checked == true)
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select RTrim(StudentRegistration.RegNo)[RegNo],RTrim(StudentRegistration.RollNo)[RollNo],RTrim(Student.ClassNo)[Class No.], RTRIM(StudentName)[Student Name], RTRIM(FatherName)[Father Name],RTRIM(RegistrationDeficiency.Description)[Deficiency],RTRIM(StudentRegistration.YearOfPassing)[Passing Year],RTRIM(StudentRegistration.HSMarks)[Marks],RTRIM(StudentRegistration.HSPercentage)[Percentage],RTRIM(StudentRegistration.HSRollNo)[High School RollNo],RTRIM(StudentRegistration.BoardName)[BoardName] from StudentRegistration INNER JOIN RegistrationDeficiency On StudentRegistration.RegistrationDeficiencyId = RegistrationDeficiency.RegistrationDeficiencyId INNER JOIN Student On Student.StudentId = StudentRegistration.StudentId INNER JOIN RegistrationStatus On StudentRegistration.RegistrationStatusId = RegistrationStatus.RegistrationStatusId INNER JOIN Department On Student.DepartmentId = .Department.DepartmentId INNER JOIN Session On Student.SessionId = .Session.SessionId Where Department.ClassName = '" + cmbClassName.Text.Trim() + "' and Department.FacultyName = '" + cmbFaculty.Text.Trim() + "'  and Session.Description ='" + cmbSession.Text.Trim() + "' and RegistrationStatus.Description = '" + cmbStatus.Text.Trim() + "' AND StudentRegistration.Class = 'HSSC'  Order By Student.ClassNo", con);
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    myDA.Fill(myDataSet, "Student");
                    dataGridView1.DataSource = myDataSet.Tables["Student"].DefaultView;
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Please select Class (SSC HSSC)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdbSSC.Focus();
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tab1Reset()
        {
            cmbClassName.Text = "";
            cmbFaculty.Text = "";
            cmbSession.Text = "";
            cmbStatus.Text = "";
            rdbHSSC.Checked = false;
            rdbSSC.Checked = false;
            dataGridView1.DataSource = null;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Tab1Reset();
        }

        private void button7_Click(object sender, EventArgs e)
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
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                xlApp.Columns[3].Cells.NumberFormat = "@";
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
            if (cmbClassName.Text == "")
            {
                MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName.Focus();
                return;
            }
            if (cmbFaculty.Text == "")
            {
                MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFaculty.Focus();
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
            frmStudentRegistration frm = new frmStudentRegistration();
            // or simply use column name instead of index
            dr.Cells["RegNo"].Value.ToString();
            frm.Show();
            frm.cmbClassName.Text = cmbClassName.Text.Trim();
            frm.cmbFaculty.Text = cmbFaculty.Text.Trim();
            frm.cmbSession.Text = cmbSession.Text.Trim();
            frm.cmbStatus.Text = cmbStatus.Text.Trim();
            if (rdbSSC.Checked == true)
            {
                frm.HSType.Text = rdbSSC.Text.Trim();
            }
            else if (rdbHSSC.Checked == true)
            {
                frm.HSType.Text = rdbHSSC.Text.Trim();
            }
            else
            {
                MessageBox.Show("Select class (HSSC SSC)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frm.RegNo.Text = dr.Cells[0].Value.ToString();
            frm.txtRollNo.Text = dr.Cells[1].Value.ToString();
            frm.cmbClassNo.Text = dr.Cells[2].Value.ToString();
            frm.StudentName.Text = dr.Cells[3].Value.ToString();
            frm.FatherName.Text = dr.Cells[4].Value.ToString();
            frm.cmbDeficiency.Text = dr.Cells[5].Value.ToString();
            frm.YOP.Text = dr.Cells[6].Value.ToString();
            frm.Marks.Text = dr.Cells[7].Value.ToString();
            frm.Percentage.Text = dr.Cells[8].Value.ToString();
            frm.HSRollNo.Text = dr.Cells[9].Value.ToString();
            frm.Board.Text = dr.Cells[10].Value.ToString();
          

            if (label11.Text == "Admin")
            {
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.cmbClassName.Focus();
                frm.btnSave.Enabled = false;
                frm.label1.Text = label11.Text;
            }
            else
            {
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.cmbClassName.Focus();
                frm.label1.Text = label11.Text;

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

        private void frmStudetnsRegRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmStudentRegistration frm = new frmStudentRegistration();
            frm.label1.Text = label11.Text;
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = new SqlCommand("select RTRIM(Department.ClassName)[Program],RTRIM(Department.FacultyName)[Faculty],RTRIM(Session.Description)[Session],RTrim(StudentRegistration.RegNo)[RegNo],RTrim(StudentRegistration.RollNo)[RollNo],RTrim(Student.ClassNo)[Class No.], RTRIM(StudentName)[Student Name], RTRIM(FatherName)[Father Name],RTRIM(RegistrationStatus.Description)[Status],RTRIM(StudentRegistration.Class)[SSC/HSSC],RTRIM(RegistrationDeficiency.Description)[Deficiency],RTRIM(StudentRegistration.YearOfPassing)[Passing Year],RTRIM(StudentRegistration.HSMarks)[Marks],RTRIM(StudentRegistration.HSPercentage)[Percentage],RTRIM(StudentRegistration.HSRollNo)[High School RollNo],RTRIM(StudentRegistration.BoardName)[BoardName] from StudentRegistration  INNER JOIN Student on Student.StudentId= StudentRegistration.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session ON Session.SessionId = Student.SessionId INNER JOIN RegistrationStatus ON RegistrationStatus.RegistrationStatusId = StudentRegistration.RegistrationStatusId INNER JOIN RegistrationDeficiency ON RegistrationDeficiency.RegistrationDeficiencyId = StudentRegistration.RegistrationDeficiencyId where DateOfAdmission between @date1 and @date2 order by DateOfAdmission", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " DateOfAdmission").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " DateOfAdmission").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "StudentRegistration");
                dataGridView2.DataSource = myDataSet.Tables["StudentRegistration"].DefaultView;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    dataGridView2.Columns["Father Name"].Visible = false;
                    dataGridView2.Columns["Passing Year"].Visible = false;
               
                    dataGridView2.Columns["Percentage"].Visible = false;
                    dataGridView2.Columns["High School RollNo"].Visible = false;
                    dataGridView2.Columns["BoardName"].Visible = false;
                    
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
            dataGridView2.DataSource = null;
            DateFrom.Text = DateTime.Now.ToString();
            DateTo.Text = DateTime.Now.ToString();

        }
        private void button5_Click(object sender, EventArgs e)
        {
            Tab2Reset();
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
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                xlApp.Columns[3].Cells.NumberFormat = "@";
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
            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            this.Hide();
            frmStudentRegistration frm = new frmStudentRegistration();
            // or simply use column name instead of index
            dr.Cells["Program"].Value.ToString();
            frm.Show();
            frm.cmbClassName.Text = dr.Cells[0].Value.ToString();
            frm.cmbFaculty.Text = dr.Cells[1].Value.ToString();
            frm.cmbSession.Text = dr.Cells[2].Value.ToString();
            frm.RegNo.Text = dr.Cells[3].Value.ToString();
            frm.txtRollNo.Text = dr.Cells[4].Value.ToString();
            frm.cmbClassNo.Text = dr.Cells[5].Value.ToString();
            frm.StudentName.Text = dr.Cells[6].Value.ToString();
            frm.FatherName.Text = dr.Cells[7].Value.ToString();
            frm.cmbStatus.Text = dr.Cells[8].Value.ToString();
            frm.HSType.Text = dr.Cells[9].Value.ToString();
            frm.cmbDeficiency.Text = dr.Cells[10].Value.ToString();
            frm.YOP.Text = dr.Cells[11].Value.ToString();
            frm.Marks.Text = dr.Cells[12].Value.ToString();
            frm.Percentage.Text = dr.Cells[13].Value.ToString();
            frm.HSRollNo.Text = dr.Cells[14].Value.ToString();
            frm.Board.Text = dr.Cells[15].Value.ToString();


            if (label11.Text == "Admin")
            {
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.cmbClassName.Focus();
                frm.btnSave.Enabled = false;
                frm.label1.Text = label11.Text;
            }
            else
            {
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.cmbClassName.Focus();
                frm.label1.Text = label11.Text;

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

        private void cmbRollNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Department.ClassName)[Program],RTRIM(Department.FacultyName)[Faculty],RTRIM(Session.Description)[Session],RTrim(StudentRegistration.RegNo)[RegNo],RTrim(StudentRegistration.RollNo)[RollNo],RTrim(Student.ClassNo)[Class No.], RTRIM(StudentName)[Student Name], RTRIM(FatherName)[Father Name],RTRIM(RegistrationStatus.Description)[Status],RTRIM(StudentRegistration.Class)[SSC/HSSC],RTRIM(RegistrationDeficiency.Description)[Deficiency],RTRIM(StudentRegistration.YearOfPassing)[Passing Year],RTRIM(StudentRegistration.HSMarks)[Marks],RTRIM(StudentRegistration.HSPercentage)[Percentage],RTRIM(StudentRegistration.HSRollNo)[High School RollNo],RTRIM(StudentRegistration.BoardName)[BoardName] from StudentRegistration  INNER JOIN Student on Student.StudentId= StudentRegistration.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session ON Session.SessionId = Student.SessionId INNER JOIN RegistrationStatus ON RegistrationStatus.RegistrationStatusId = StudentRegistration.RegistrationStatusId INNER JOIN RegistrationDeficiency ON RegistrationDeficiency.RegistrationDeficiencyId = StudentRegistration.RegistrationDeficiencyId where StudentRegistration.RollNo = '"+cmbRollNo.Text.Trim()+"'", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "StudentRegistration");
                dataGridView5.DataSource = myDataSet.Tables["StudentRegistration"].DefaultView;
                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
                    dataGridView5.Columns["Father Name"].Visible = false;
                    dataGridView5.Columns["Passing Year"].Visible = false;
                    dataGridView5.Columns["Percentage"].Visible = false;
                    dataGridView5.Columns["High School RollNo"].Visible = false;
                    dataGridView5.Columns["BoardName"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRollNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Department.ClassName)[Program],RTRIM(Department.FacultyName)[Faculty],RTRIM(Session.Description)[Session],RTrim(StudentRegistration.RegNo)[RegNo],RTrim(StudentRegistration.RollNo)[RollNo],RTrim(Student.ClassNo)[Class No.], RTRIM(StudentName)[Student Name], RTRIM(FatherName)[Father Name],RTRIM(RegistrationStatus.Description)[Status],RTRIM(StudentRegistration.Class)[SSC/HSSC],RTRIM(RegistrationDeficiency.Description)[Deficiency],RTRIM(StudentRegistration.YearOfPassing)[Passing Year],RTRIM(StudentRegistration.HSMarks)[Marks],RTRIM(StudentRegistration.HSPercentage)[Percentage],RTRIM(StudentRegistration.HSRollNo)[High School RollNo],RTRIM(StudentRegistration.BoardName)[BoardName] from StudentRegistration  INNER JOIN Student on Student.StudentId= StudentRegistration.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session ON Session.SessionId = Student.SessionId INNER JOIN RegistrationStatus ON RegistrationStatus.RegistrationStatusId = StudentRegistration.RegistrationStatusId INNER JOIN RegistrationDeficiency ON RegistrationDeficiency.RegistrationDeficiencyId = StudentRegistration.RegistrationDeficiencyId where StudentRegistration.RollNo like '" + txtRollNo.Text.Trim() + "%'", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "StudentRegistration");
                dataGridView5.DataSource = myDataSet.Tables["StudentRegistration"].DefaultView;
                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
                    dataGridView5.Columns["Father Name"].Visible = false;
                    dataGridView5.Columns["Passing Year"].Visible = false;
                    dataGridView5.Columns["Percentage"].Visible = false;
                    dataGridView5.Columns["High School RollNo"].Visible = false;
                    dataGridView5.Columns["BoardName"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView5_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView5.SelectedRows[0];
            this.Hide();
            frmStudentRegistration frm = new frmStudentRegistration();
            // or simply use column name instead of index
            dr.Cells["Program"].Value.ToString();
            frm.Show();
            frm.cmbClassName.Text = dr.Cells[0].Value.ToString();
            frm.cmbFaculty.Text = dr.Cells[1].Value.ToString();
            frm.cmbSession.Text = dr.Cells[2].Value.ToString();
            frm.RegNo.Text = dr.Cells[3].Value.ToString();
            frm.txtRollNo.Text = dr.Cells[4].Value.ToString();
            frm.cmbClassNo.Text = dr.Cells[5].Value.ToString();
            frm.StudentName.Text = dr.Cells[6].Value.ToString();
            frm.FatherName.Text = dr.Cells[7].Value.ToString();
            frm.cmbStatus.Text = dr.Cells[8].Value.ToString();
            frm.HSType.Text = dr.Cells[9].Value.ToString();
            frm.cmbDeficiency.Text = dr.Cells[10].Value.ToString();
            frm.YOP.Text = dr.Cells[11].Value.ToString();
            frm.Marks.Text = dr.Cells[12].Value.ToString();
            frm.Percentage.Text = dr.Cells[13].Value.ToString();
            frm.HSRollNo.Text = dr.Cells[14].Value.ToString();
            frm.Board.Text = dr.Cells[15].Value.ToString();


            if (label11.Text == "Admin")
            {
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.cmbClassName.Focus();
                frm.btnSave.Enabled = false;
                frm.label1.Text = label11.Text;
            }
            else
            {
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.cmbClassName.Focus();
                frm.label1.Text = label11.Text;

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

        private void Tab3Reset()
        {
            txtRollNo.Text = "";
            cmbRollNo.Text = "";
            dataGridView5.DataSource = null;
        }
        private void button12_Click(object sender, EventArgs e)
        {

            Tab3Reset();
        }

        private void button11_Click(object sender, EventArgs e)
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
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                xlApp.Columns[3].Cells.NumberFormat = "@";
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
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                xlApp.Columns[3].Cells.NumberFormat = "@";
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

        private void txtRollNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
        private void Tab4Reset()
        {
            txtStudentName.Text = "";
            dataGridView3.DataSource = null;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Tab4Reset();
        }

        private void txtStudentName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select RTRIM(Department.ClassName)[Program],RTRIM(Department.FacultyName)[Faculty],RTRIM(Session.Description)[Session],RTrim(StudentRegistration.RegNo)[RegNo],RTrim(StudentRegistration.RollNo)[RollNo],RTrim(Student.ClassNo)[Class No.], RTRIM(StudentName)[Student Name], RTRIM(FatherName)[Father Name],RTRIM(RegistrationStatus.Description)[Status],RTRIM(StudentRegistration.Class)[SSC/HSSC],RTRIM(RegistrationDeficiency.Description)[Deficiency],RTRIM(StudentRegistration.YearOfPassing)[Passing Year],RTRIM(StudentRegistration.HSMarks)[Marks],RTRIM(StudentRegistration.HSPercentage)[Percentage],RTRIM(StudentRegistration.HSRollNo)[High School RollNo],RTRIM(StudentRegistration.BoardName)[BoardName] from StudentRegistration  INNER JOIN Student on Student.StudentId= StudentRegistration.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session ON Session.SessionId = Student.SessionId INNER JOIN RegistrationStatus ON RegistrationStatus.RegistrationStatusId = StudentRegistration.RegistrationStatusId INNER JOIN RegistrationDeficiency ON RegistrationDeficiency.RegistrationDeficiencyId = StudentRegistration.RegistrationDeficiencyId where Student.StudentName like '" + txtStudentName.Text.Trim() + "%'", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "StudentRegistration");
                dataGridView3.DataSource = myDataSet.Tables["StudentRegistration"].DefaultView;
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    dataGridView3.Columns["Father Name"].Visible = false;
                    dataGridView3.Columns["Passing Year"].Visible = false;
                    dataGridView3.Columns["Percentage"].Visible = false;
                    dataGridView3.Columns["High School RollNo"].Visible = false;
                    dataGridView3.Columns["BoardName"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView3.SelectedRows[0];
            this.Hide();
            frmStudentRegistration frm = new frmStudentRegistration();
            // or simply use column name instead of index
            dr.Cells["Program"].Value.ToString();
            frm.Show();
            frm.cmbClassName.Text = dr.Cells[0].Value.ToString();
            frm.cmbFaculty.Text = dr.Cells[1].Value.ToString();
            frm.cmbSession.Text = dr.Cells[2].Value.ToString();
            frm.RegNo.Text = dr.Cells[3].Value.ToString();
            frm.txtRollNo.Text = dr.Cells[4].Value.ToString();
            frm.cmbClassNo.Text = dr.Cells[5].Value.ToString();
            frm.StudentName.Text = dr.Cells[6].Value.ToString();
            frm.FatherName.Text = dr.Cells[7].Value.ToString();
            frm.cmbStatus.Text = dr.Cells[8].Value.ToString();
            frm.HSType.Text = dr.Cells[9].Value.ToString();
            frm.cmbDeficiency.Text = dr.Cells[10].Value.ToString();
            frm.YOP.Text = dr.Cells[11].Value.ToString();
            frm.Marks.Text = dr.Cells[12].Value.ToString();
            frm.Percentage.Text = dr.Cells[13].Value.ToString();
            frm.HSRollNo.Text = dr.Cells[14].Value.ToString();
            frm.Board.Text = dr.Cells[15].Value.ToString();


            if (label11.Text == "Admin")
            {
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.cmbClassName.Focus();
                frm.btnSave.Enabled = false;
                frm.label1.Text = label11.Text;
            }
            else
            {
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.cmbClassName.Focus();
                frm.label1.Text = label11.Text;

            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            Tab1Reset();
            Tab2Reset();
            Tab3Reset();
            Tab4Reset();

        }
    }
}
