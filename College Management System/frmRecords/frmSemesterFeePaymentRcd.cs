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
    public partial class frmSemesterFeePaymentRcd : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmSemesterFeePaymentRcd()
        {
            InitializeComponent();
        }

        private void frmSemesterFeePaymentRcd_Load(object sender, EventArgs e)
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
                    cmbClassName2.Items.Add(rdr[0]);
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
                string ct = "select distinct RTRIM(Description) from Session";
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
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
                if (cmbSemester.Text == "")
                {
                    MessageBox.Show("Please select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSemester.Focus();
                    return;
                }
                #endregion

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTRIM(Student.ClassNo)[Class No],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],RTRIM(Student.Gender)[Gender],RTRIM(Student.StudentAddress)[Address],RTRIM(SemesterFeePayment.Status)[Status],RTRIM(SemesterFeePayment.DateOfPayment)[Paymant Date] from SemesterFeePayment  Inner JOin Student On Student.StudentId = SemesterFeePayment.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN SemesterFees On SemesterFeePayment.SemesterFeeId = SemesterFees.SemesterFeeId INNER JOIN Semester ON Semester.SemesterId = SemesterFees.SemesterId  where Department.ClassName = '" + cmbClassName.Text.Trim() + "' AND Department.FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "' AND Semester.Description = '" + cmbSemester.Text.Trim() + "'", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "SemesterFeePayment");
                dataGridView1.DataSource = myDataSet.Tables["SemesterFeePayment"].DefaultView;
                con.Close();
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
            cmbSemester.Text = "";
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

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void dataGridView3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView3.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView3.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void dataGridView4_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView4.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView4.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void frmSemesterFeePaymentRcd_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmSemesterFeePayment frm = new frmSemesterFeePayment();
            frm.label23.Text = label13.Text.Trim();
            frm.label24.Text = label14.Text.Trim();
            frm.Show();

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbClassName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFaculty2.Items.Clear();
            cmbFaculty2.Text = "";
            cmbFaculty2.Enabled = true;
            cmbFaculty2.Focus();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(FacultyName) from Department where ClassName = '" + cmbClassName2.Text + "'";
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
            cmbSession2.Focus();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Description) from Session";
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
            cmbClassNo2.Focus();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Student.ClassNo) from SemesterFeePayment  Inner JOin Student On Student.StudentId = SemesterFeePayment.StudentId INNER JOIN Department On Student.DepartmentId = Department.DepartmentId INNER JOIN Session ON Session.SessionId = Student.SessionId where Department.ClassName = '"+cmbClassName2.Text.Trim()+"' AND Department.FacultyName = '"+cmbFaculty2.Text.Trim()+"' AND Session.Description = '"+cmbSession2.Text.Trim()+"'";
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
                cmd = new SqlCommand("select  RTRIM(Department.ClassName)[Program], RTRIM(Department.FacultyName)[Faculty], RTRIM(Session.Description)[Session], RTRIM(Semester.Description)[Semester],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],RTRIM(Student.Gender)[Gender],RTRIM(SemesterFeePayment.Status)[Status],RTRIM(SemesterFeePayment.DateOfPayment)[PaymentDate] from SemesterFeePayment  Inner JOin Student On Student.StudentId = SemesterFeePayment.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN SemesterFees On SemesterFeePayment.SemesterFeeId = SemesterFees.SemesterFeeId INNER JOIN Semester ON Semester.SemesterId = SemesterFees.SemesterId  where Department.ClassName = '" + cmbClassName2.Text.Trim() + "' AND Department.FacultyName = '" + cmbFaculty2.Text.Trim() + "' AND Session.Description = '" + cmbSession2.Text.Trim() + "' AND Student.ClassNo = '" + cmbClassNo2.Text.Trim()+"'", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "SemesterFeePayment");
                dataGridView2.DataSource = myDataSet.Tables["SemesterFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Tab2Reset()
        {
            cmbClassName2.Text = "";
            cmbFaculty2.Text = "";
            cmbSession2.Text = "";
            cmbClassNo2.Text = "";
            dataGridView2.DataSource = null;
        }
        private void button9_Click(object sender, EventArgs e)
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

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTRIM(Department.ClassName)[Program], RTRIM(Department.FacultyName)[Faculty], RTRIM(Session.Description)[Session], RTRIM(Semester.Description)[Semester],RTRIM(Student.ClassNo)[Class No],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],RTRIM(Student.Gender)[Gender],RTRIM(SemesterFeePayment.Status)[Status],RTRIM(SemesterFeePayment.DateOfPayment)[PaymentDate] from SemesterFeePayment  Inner JOin Student On Student.StudentId = SemesterFeePayment.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN SemesterFees On SemesterFeePayment.SemesterFeeId = SemesterFees.SemesterFeeId INNER JOIN Semester ON Semester.SemesterId = SemesterFees.SemesterId  where SemesterFeePayment.DateOfPayment between @date1 ANd @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " DateOfAdmission").Value = PaymentDateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " DateOfAdmission").Value = PaymentDateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "SemesterFeePayment");
                dataGridView3.DataSource = myDataSet.Tables["SemesterFeePayment"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Tab3Reset()
        {
            PaymentDateFrom.Text = DateTime.Now.ToString();
            PaymentDateTo.Text = DateTime.Now.ToString();
            dataGridView3.DataSource = null;

        }
        private void button11_Click(object sender, EventArgs e)
        {
            Tab3Reset();
        }

        private void button8_Click(object sender, EventArgs e)
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

        private void button12_Click(object sender, EventArgs e)
        {
            if (rdbPaid.Checked == true)
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select  RTRIM(Department.ClassName)[Program], RTRIM(Department.FacultyName)[Faculty], RTRIM(Session.Description)[Session], RTRIM(Semester.Description)[Semester],RTRIM(Student.ClassNo)[Class No],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],RTRIM(Student.Gender)[Gender],RTRIM(SemesterFeePayment.Status)[Status],RTRIM(SemesterFeePayment.DateOfPayment)[PaymentDate] from SemesterFeePayment  Inner JOin Student On Student.StudentId = SemesterFeePayment.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN SemesterFees On SemesterFeePayment.SemesterFeeId = SemesterFees.SemesterFeeId INNER JOIN Semester ON Semester.SemesterId = SemesterFees.SemesterId  where SemesterFeePayment.Status = 'Paid'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " DateOfAdmission").Value = PaymentDateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " DateOfAdmission").Value = PaymentDateTo.Value.Date;
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    myDA.Fill(myDataSet, "SemesterFeePayment");
                    dataGridView4.DataSource = myDataSet.Tables["SemesterFeePayment"].DefaultView;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (rdbUnpaid.Checked == true)
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = new SqlCommand("select  RTRIM(Department.ClassName)[Program], RTRIM(Department.FacultyName)[Faculty], RTRIM(Session.Description)[Session], RTRIM(Semester.Description)[Semester],RTRIM(Student.ClassNo)[Class No],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],RTRIM(Student.Gender)[Gender],RTRIM(SemesterFeePayment.Status)[Status],RTRIM(SemesterFeePayment.DateOfPayment)[PaymentDate] from SemesterFeePayment  Inner JOin Student On Student.StudentId = SemesterFeePayment.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN SemesterFees On SemesterFeePayment.SemesterFeeId = SemesterFees.SemesterFeeId INNER JOIN Semester ON Semester.SemesterId = SemesterFees.SemesterId  where SemesterFeePayment.Status = 'UnPaid'", con);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " DateOfAdmission").Value = PaymentDateFrom.Value.Date;
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " DateOfAdmission").Value = PaymentDateTo.Value.Date;
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    myDA.Fill(myDataSet, "SemesterFeePayment");
                    dataGridView4.DataSource = myDataSet.Tables["SemesterFeePayment"].DefaultView;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Select Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Tab4Reset()
        {
            rdbPaid.Checked = false;
            rdbUnpaid.Checked = false;
            dataGridView4.DataSource = null;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            Tab4Reset();
        }

        private void button1_Click(object sender, EventArgs e)
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
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                xlApp.Columns[3].Cells.NumberFormat = "@";
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

        private void tabControl1_Click(object sender, EventArgs e)
        {
            Tab1Reset();
            Tab2Reset();
            Tab3Reset();
            Tab4Reset();
        }
    }
}
