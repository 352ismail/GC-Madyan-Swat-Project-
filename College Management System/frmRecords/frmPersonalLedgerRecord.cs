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

namespace College_Management_System.Forms
{
    public partial class frmPersonalLedgerRecord : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();

        public frmPersonalLedgerRecord()
        {
            InitializeComponent();
        }

        private void frmPersonalLedgerRecord_Load(object sender, EventArgs e)
        {
            AutocompleClassName();
        }
        private void AutocompleClassName()
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
            try
            {
                cmbFaculty.Items.Clear();
                cmbFaculty.Text = "";
                cmbFaculty.Enabled = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(FacultyName) from Department where ClassName = '" + cmbClassName.Text + "' ";
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
            try
            {
                cmbSession.Items.Clear();
                cmbSession.Text = "";
                cmbSession.Enabled = true;
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
            try
            {
                cmbSemester.Items.Clear();
                cmbSemester.Text = "";
                cmbSemester.Enabled = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Semester) from Personalledger";
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

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTrim(PersonalLedger.PersonalLedgerId)[Id],RTrim(Student.ClassNo)[Class No.],RTrim(Student.StudentName)[Student Name],RTrim(Student.FatherName)[FatherName Name],RTRIM(PersonalLedger.RecieptNo)[RecieptNo],(PersonalLedger.GF)[GF],(PersonalLedger.PF)[PF],(PersonalLedger.Security)[Security],(PersonalLedger.FineReciept)[Fine Reciept], RTRIM(PersonalLedger.Date)[Date] from PersonalLedger INNER JOIN Student On PersonalLedger.StudentId= Student.StudentId INNER JOIN Department On Department.DepartmentId= Student.DepartmentId INNER JOIN Session On Session.SessionId= Student.SessionId where Department.ClassName = '" + cmbClassName.Text.Trim() + "'AND Department.FacultyName='" + cmbFaculty.Text.Trim() + "' and Session.Description ='" + cmbSession.Text.Trim() + "' AND Semester = '" + cmbSemester.Text.Trim() + "'Order  by Student.ClassNo", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "PersonalLedger");
                dataGridView1.DataSource = myDataSet.Tables["PersonalLedger"].DefaultView;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Columns["Id"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTrim(PersonalLedger.PersonalLedgerId)[Id],RTrim(Student.ClassNo)[Class No.],RTrim(Department.ClassName)[Program],RTrim(Department.FacultyName)[Faculty],RTrim(Session.Description)[Session],RTrim(Student.StudentName)[Student Name],RTrim(Student.FatherName)[FatherName Name],RTRIM(PersonalLedger.Semester)[Semester],RTRIM(PersonalLedger.RecieptNo)[RecieptNo],(PersonalLedger.GF)[GF],(PersonalLedger.PF)[PF],(PersonalLedger.Security)[Security],(PersonalLedger.FineReciept)[Fine Reciept], RTRIM(PersonalLedger.Date)[Date] from PersonalLedger INNER JOIN Student On PersonalLedger.StudentId= Student.StudentId INNER JOIN Department On Department.DepartmentId= Student.DepartmentId INNER JOIN Session On Session.SessionId= Student.SessionId where date Between @date1 and @date2 Order  by Student.ClassNo", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "PersonalLedger");
                dataGridView2.DataSource = myDataSet.Tables["PersonalLedger"].DefaultView;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    dataGridView2.Columns["Id"].Visible = false;
                    dataGridView2.Columns["GF"].Visible = false;
                    dataGridView2.Columns["PF"].Visible = false;
                    dataGridView2.Columns["Security"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRecieptNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTrim(PersonalLedger.PersonalLedgerId)[Id],RTrim(Student.ClassNo)[Class No.],RTrim(Department.ClassName)[Program],RTrim(Department.FacultyName)[Faculty],RTrim(Session.Description)[Session],RTrim(Student.StudentName)[Student Name],RTrim(Student.FatherName)[FatherName Name],RTRIM(PersonalLedger.Semester)[Semester],RTRIM(PersonalLedger.RecieptNo)[RecieptNo],(PersonalLedger.GF)[GF],(PersonalLedger.PF)[PF],(PersonalLedger.Security)[Security],(PersonalLedger.FineReciept)[Fine Reciept], RTRIM(PersonalLedger.Date)[Date] from PersonalLedger INNER JOIN Student On PersonalLedger.StudentId= Student.StudentId INNER JOIN Department On Department.DepartmentId= Student.DepartmentId INNER JOIN Session On Session.SessionId= Student.SessionId where RecieptNo like '"+txtRecieptNo.Text.Trim()+"%' Order  by Student.ClassNo", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "PersonalLedger");
                dataGridView5.DataSource = myDataSet.Tables["PersonalLedger"].DefaultView;
                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
                    dataGridView5.Columns["Id"].Visible = false;
                    dataGridView5.Columns["GF"].Visible = false;
                    dataGridView5.Columns["PF"].Visible = false;
                    dataGridView5.Columns["Security"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void frmPersonalLedgerRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Forms.frmPersonalLedger frm = new frmPersonalLedger();
            frm.label1.Text = label5.Text.Trim();
            frm.Show();

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

        private void Tab1Reset()
        {
            cmbClassName.Text = "";
            cmbFaculty.Text = "";
            cmbSession.Text = "";
            dataGridView1.DataSource = null;
        }
        private void Button2_Click(object sender, EventArgs e)
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

        private void Tab2Reset()
        {
            DateFrom.Text = DateTime.Now.ToString();
            DateTo.Text = DateTime.Now.ToString();
            dataGridView2.DataSource = null;
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
            txtRecieptNo.Text = "";
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

        private void tabControl1_Click(object sender, EventArgs e)
        {
            Tab1Reset();
            Tab2Reset();
            Tab3Reset();

        }
    }
}
