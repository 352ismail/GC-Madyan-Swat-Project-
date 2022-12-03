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
    public partial class frmHostelerRecord : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmHostelerRecord()
        {
            InitializeComponent();
        }

        private void frmHostelerRecord_Load(object sender, EventArgs e)
        {
            AutocompleteClassName();
            AutocompleteHostelname();
        }

        private void AutocompleteClassName()
        {

            try
            {

                SqlConnection CN = new SqlConnection(cs.DBConn);

                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(ClassName) FROM Department", CN);
                ds = new DataSet("ds");

                adp.Fill(ds);
                dtable = ds.Tables[0];
                Course.Items.Clear();

                foreach (DataRow drow in dtable.Rows)
                {
                    Course.Items.Add(drow[0].ToString());
                    cmbClassName2.Items.Add(drow[0].ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AutocompleteHostelname()
        {

            try
            {

                SqlConnection CN = new SqlConnection(cs.DBConn);

                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(hostelname) FROM Hostel ", CN);
                ds = new DataSet("ds");

                adp.Fill(ds);
                dtable = ds.Tables[0];
                cmbHostelName.Items.Clear();

                foreach (DataRow drow in dtable.Rows)
                {
                    cmbHostelName.Items.Add(drow[0].ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            Branch.Items.Clear();
            Branch.Text = "";
            Branch.Enabled = true;

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();


                string ct = "select distinct RTRIM(FacultyNAme) from Department where ClassName= '" + Course.Text.Trim() + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Branch.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSession1.Items.Clear();
            cmbSession1.Text = "";
            cmbSession1.Enabled = true;

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
                    cmbSession1.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validation
                if (Course.Text == "")
                {
                    MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Course.Focus();
                    return;
                }
                if (Branch.Text == "")
                {
                    MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Branch.Focus();
                    return;
                }

                if (cmbSession1.Text == "")
                {
                    MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSession1.Focus();
                    return;
                }
                #endregion

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTrim(Student.ClassNo)[ClassNo],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],RTRIM(Department.ClassName)[Class Name],RTRIM(Department.FacultyName)[Faculty Name],RTRIM(Session.Description)[Session],RTRIM(Hostel.HostelName)[Hostel Name], RTRIM(Hostelers.JoiningDate)[Joining Date]  from Hostelers INNER JOIN Student On Student.StudentId = Hostelers.StudentId INNER JOIN Department On Department.DepartmentId = Student.DepartmentId INNER JOin Session On Student.SessionId = Session.SessionId INNER JOIN Hostel ON Hostel.HostelId = Hostelers.HostelId WHERE Hostelers.JoiningDate  BETWEEN @date1 AND @date2 ANd Department.ClassName = '" + Course.Text.Trim() + "' and Department.FacultyName = '" + Branch.Text.Trim() + "' ANd Session.Description = '" + cmbSession1.Text.Trim() + "'", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "JoiningDate").Value = Date_from.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "JoiningDate").Value = Date_to.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Hostelers");
                dataGridView1.DataSource = myDataSet.Tables["Hostelers"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            this.Hide();
            frmHostelers frm = new frmHostelers();
            // or simply use column name instead of index
            dr.Cells["ClassNo"].Value.ToString();
            frm.Show();
            frm.cmbCLassName.Text = dr.Cells[3].Value.ToString();
            frm.cmbFacultyName.Text = dr.Cells[4].Value.ToString();
            frm.cmbSession.Text = dr.Cells[5].Value.ToString();
            frm.cmbCLassNo.Text = dr.Cells[0].Value.ToString();
            frm.StudentName.Text = dr.Cells[1].Value.ToString();
            frm.FatherName.Text = dr.Cells[2].Value.ToString();
            frm.cmbHostelName.Text = dr.Cells[6].Value.ToString();
            frm.JoiningDate.Text = dr.Cells[7].Value.ToString();
            if (label7.Text == "Admin")
            {
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.cmbCLassNo.Focus();
                frm.label3.Text = label7.Text;
                frm.btnSave.Enabled = false;
            }
            else
            {
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.cmbCLassNo.Focus();
                frm.label3.Text = label7.Text;
            }
        }

        private void frmHostelerRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmHostelers frm = new frmHostelers();
            frm.label3.Text = label7.Text;
            frm.Show();
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
        private void Tab1Reset()
        {
            Course.Text = "";
            Branch.Text = "";
            cmbSession1.Text = "";
            Date_from.Text = DateTime.Now.ToString();
            Date_to.Text = DateTime.Now.ToString();
            dataGridView1.DataSource = null;
            
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Tab1Reset();
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

        private void cmbClassName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFaculty2.Items.Clear();
            cmbFaculty2.Text = "";
            cmbFaculty2.Enabled = true;

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(FacultyNAme) from Department where ClassName= '" + cmbClassName2.Text.Trim() + "'";
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
                string ct = "select distinct RTRIM(Description) from Session where IsActive = 'true'";
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
            cmbClassNo2.Items.Clear();
            cmbClassNo2.Text = "";
            cmbClassNo2.Enabled = true;

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(ClassNo) from Student where DepartmentId = (Select DepartmentId From Department where ClassName = '" + cmbClassName2.Text.Trim() + "' and FacultyName = '" + cmbFaculty2.Text.Trim() + "') and SessionId = (Select SessionId From Session WHere description = '" + cmbSession2.Text.Trim() + "')";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbClassNo2.Items.Add(rdr[0]);
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
                if (Course.Text == "")
                {
                    MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Course.Focus();
                    return;
                }
                if (Branch.Text == "")
                {
                    MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Branch.Focus();
                    return;
                }

                if (cmbSession1.Text == "")
                {
                    MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSession1.Focus();
                    return;
                }
                #endregion

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTrim(Student.ClassNo)[ClassNo],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],RTRIM(Department.ClassName)[Class Name],RTRIM(Department.FacultyName)[Faculty Name],RTRIM(Session.Description)[Session],RTRIM(Hostel.HostelName)[Hostel Name], RTRIM(Hostelers.JoiningDate)[Joining Date]  from Hostelers INNER JOIN Student On Student.StudentId = Hostelers.StudentId INNER JOIN Department On Department.DepartmentId = Student.DepartmentId INNER JOin Session On Student.SessionId = Session.SessionId INNER JOIN Hostel ON Hostel.HostelId = Hostelers.HostelId WHERE Hostelers.JoiningDate  BETWEEN @date1 AND @date2 ANd Department.ClassName = '" + Course.Text.Trim() + "' and Department.FacultyName = '" + Branch.Text.Trim() + "' ANd Session.Description = '" + cmbSession1.Text.Trim() + "'", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "JoiningDate").Value = Date_from.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "JoiningDate").Value = Date_to.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Hostelers");
                dataGridView1.DataSource = myDataSet.Tables["Hostelers"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbClassNo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                #region Validation
                if (cmbClassName2.Text == "")
                {
                    MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClassName2.Focus();
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
           
                #endregion

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTrim(Student.ClassNo)[ClassNo],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],RTRIM(Department.ClassName)[Class Name],RTRIM(Department.FacultyName)[Faculty Name],RTRIM(Session.Description)[Session],RTRIM(Hostel.HostelName)[Hostel Name], RTRIM(Hostelers.JoiningDate)[Joining Date]  from Hostelers INNER JOIN Student On Student.StudentId = Hostelers.StudentId INNER JOIN Department On Department.DepartmentId = Student.DepartmentId INNER JOin Session On Student.SessionId = Session.SessionId INNER JOIN Hostel ON Hostel.HostelId = Hostelers.HostelId WHERE Student.ClassNo='" + cmbClassNo2.Text.Trim() + "' ANd Department.ClassName = '" + cmbClassName2.Text.Trim() + "' and Department.FacultyName = '" + cmbFaculty2.Text.Trim() + "' ANd Session.Description = '" + cmbSession2.Text.Trim() + "'", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "JoiningDate").Value = Date_from.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "JoiningDate").Value = Date_to.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Hostelers");
                dataGridView2.DataSource = myDataSet.Tables["Hostelers"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView2.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            this.Hide();
            frmHostelers frm = new frmHostelers();
            // or simply use column name instead of index
            dr.Cells["ClassNo"].Value.ToString();
            frm.Show();
            frm.cmbCLassName.Text = dr.Cells[3].Value.ToString();
            frm.cmbFacultyName.Text = dr.Cells[4].Value.ToString();
            frm.cmbSession.Text = dr.Cells[5].Value.ToString();
            frm.cmbCLassNo.Text = dr.Cells[0].Value.ToString();
            frm.StudentName.Text = dr.Cells[1].Value.ToString();
            frm.FatherName.Text = dr.Cells[2].Value.ToString();
            frm.cmbHostelName.Text = dr.Cells[6].Value.ToString();
            frm.JoiningDate.Text = dr.Cells[7].Value.ToString();
            if (label7.Text == "Admin")
            {
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.cmbCLassNo.Focus();
                frm.label3.Text = label7.Text;
                frm.btnSave.Enabled = false;
            }
            else
            {
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.cmbCLassNo.Focus();
                frm.label3.Text = label7.Text;
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

        private void Tab2Reset()
        {
            cmbClassName2.Text = "";
            cmbFaculty2.Text = "";
            cmbSession2.Text = "";
            cmbClassNo2.Text = "";
            dataGridView2.DataSource = null;
        }

        private void btnReset2_Click(object sender, EventArgs e)
        {
            Tab2Reset();
        }

        private void button7_Click(object sender, EventArgs e)
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
        private void Tab3Reset()
        {
            txtStudentName3.Text = "";
            dataGridView3.DataSource = null;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Tab3Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
        }

        private void txtStudentName3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTrim(Student.ClassNo)[ClassNo],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],RTRIM(Department.ClassName)[Class Name],RTRIM(Department.FacultyName)[Faculty Name],RTRIM(Session.Description)[Session],RTRIM(Hostel.HostelName)[Hostel Name], RTRIM(Hostelers.JoiningDate)[Joining Date]  from Hostelers INNER JOIN Student On Student.StudentId = Hostelers.StudentId INNER JOIN Department On Department.DepartmentId = Student.DepartmentId INNER JOin Session On Student.SessionId = Session.SessionId INNER JOIN Hostel ON Hostel.HostelId = Hostelers.HostelId WHERE Student.StudentName like '" + txtStudentName3.Text.Trim() + "%'", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "JoiningDate").Value = Date_from.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "JoiningDate").Value = Date_to.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Hostelers");
                dataGridView3.DataSource = myDataSet.Tables["Hostelers"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView3.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DataGridViewRow dr = dataGridView3.SelectedRows[0];
            this.Hide();
            frmHostelers frm = new frmHostelers();
            // or simply use column name instead of index
            dr.Cells["ClassNo"].Value.ToString();
            frm.Show();
            frm.cmbCLassName.Text = dr.Cells[3].Value.ToString();
            frm.cmbFacultyName.Text = dr.Cells[4].Value.ToString();
            frm.cmbSession.Text = dr.Cells[5].Value.ToString();
            frm.cmbCLassNo.Text = dr.Cells[0].Value.ToString();
            frm.StudentName.Text = dr.Cells[1].Value.ToString();
            frm.FatherName.Text = dr.Cells[2].Value.ToString();
            frm.cmbHostelName.Text = dr.Cells[6].Value.ToString();
            frm.JoiningDate.Text = dr.Cells[7].Value.ToString();
            if (label7.Text == "Admin")
            {
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.cmbCLassNo.Focus();
                frm.label3.Text = label7.Text;
                frm.btnSave.Enabled = false;
            }
            else
            {
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.cmbCLassNo.Focus();
                frm.label3.Text = label7.Text;
            }
        }

        private void cmbHostelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTrim(Student.ClassNo)[ClassNo],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],RTRIM(Department.ClassName)[Class Name],RTRIM(Department.FacultyName)[Faculty Name],RTRIM(Session.Description)[Session],RTRIM(Hostel.HostelName)[Hostel Name], RTRIM(Hostelers.JoiningDate)[Joining Date]  from Hostelers INNER JOIN Student On Student.StudentId = Hostelers.StudentId INNER JOIN Department On Department.DepartmentId = Student.DepartmentId INNER JOin Session On Student.SessionId = Session.SessionId INNER JOIN Hostel ON Hostel.HostelId = Hostelers.HostelId WHERE Hostel.HostelName = '" + cmbHostelName.Text.Trim() + "'", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "JoiningDate").Value = Date_from.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "JoiningDate").Value = Date_to.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Hostelers");
                dataGridView5.DataSource = myDataSet.Tables["Hostelers"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtHostelName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTrim(Student.ClassNo)[ClassNo],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],RTRIM(Department.ClassName)[Class Name],RTRIM(Department.FacultyName)[Faculty Name],RTRIM(Session.Description)[Session],RTRIM(Hostel.HostelName)[Hostel Name], RTRIM(Hostelers.JoiningDate)[Joining Date]  from Hostelers INNER JOIN Student On Student.StudentId = Hostelers.StudentId INNER JOIN Department On Department.DepartmentId = Student.DepartmentId INNER JOin Session On Student.SessionId = Session.SessionId INNER JOIN Hostel ON Hostel.HostelId = Hostelers.HostelId WHERE Hostel.HostelName like '" + txtHostelName.Text.Trim() + "%'", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "JoiningDate").Value = Date_from.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "JoiningDate").Value = Date_to.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Hostelers");
                dataGridView5.DataSource = myDataSet.Tables["Hostelers"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView5_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView5.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DataGridViewRow dr = dataGridView5.SelectedRows[0];
            this.Hide();
            frmHostelers frm = new frmHostelers();
            // or simply use column name instead of index
            dr.Cells["ClassNo"].Value.ToString();
            frm.Show();
            frm.cmbCLassName.Text = dr.Cells[3].Value.ToString();
            frm.cmbFacultyName.Text = dr.Cells[4].Value.ToString();
            frm.cmbSession.Text = dr.Cells[5].Value.ToString();
            frm.cmbCLassNo.Text = dr.Cells[0].Value.ToString();
            frm.StudentName.Text = dr.Cells[1].Value.ToString();
            frm.FatherName.Text = dr.Cells[2].Value.ToString();
            frm.cmbHostelName.Text = dr.Cells[6].Value.ToString();
            frm.JoiningDate.Text = dr.Cells[7].Value.ToString();
            if (label7.Text == "Admin")
            {
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.cmbCLassNo.Focus();
                frm.label3.Text = label7.Text;
                frm.btnSave.Enabled = false;
            }
            else
            {
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.cmbCLassNo.Focus();
                frm.label3.Text = label7.Text;
            }
        }
        private void Tab4Reset()
        {
            cmbHostelName.Text = "";
            txtHostelName.Text = "";
            dataGridView5.DataSource = null;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            Tab4Reset();
        }

        private void button10_Click(object sender, EventArgs e)
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

        private void tabControl1_Click(object sender, EventArgs e)
        {
            Tab1Reset();
            Tab2Reset();
            Tab3Reset();
            Tab4Reset();
        }
    }
}
