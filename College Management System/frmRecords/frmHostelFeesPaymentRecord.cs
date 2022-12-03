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
    public partial class frmHostelFeesPaymentRecord : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmHostelFeesPaymentRecord()
        {
            InitializeComponent();
        }
        private void frmHostelFeesPaymentRecord_Load(object sender, EventArgs e)
        {
            AutocompleteClass();
            AutocompleteHostelName();
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

        private void AutocompleteClass()
        {
            try
            {
                cmbCourse.Items.Clear();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AutocompleteHostelName()
        {
            try
            {
                cmbHostelName.Items.Clear();
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(HostelName) FROM Hostel", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
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

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbYear.Items.Clear();
            cmbYear.Text = "";
            cmbYear.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Year) from HostelFeePayment ";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbYear.Items.Add(rdr[0]);
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
            if (cmbYear.Text == "")
            {
                MessageBox.Show("Please select Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbYear.Focus();
                return;
            }

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTRIM(Student.ClassNo)[Class No],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],RTRIM(HostelFeePayment.DateOfPayment)[Date Of Payment],RTRIM(HostelFeePayment.ModeOfPayment)[Mode Of Payment],RTRIM(HostelFeePayment.TotalPaid)[Total Paid],RTRIM(HostelFeePayment.Fine)[Fine],RTRIM(HostelFeePayment.DueFee)[Due Fees],RTRIM(Users.Name)[Paid By],RTRIM(Hostel.HostelName)[Hostel Name],RTRIM(Hostel.HostelFee)[Hostel Fees] from HostelFeePayment  Inner JOin Hostelers On HostelFeePayment.HostelerId = Hostelers.HostelerId Inner JOin Student On Student.StudentId = Hostelers.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN Users On Users.UserId = HostelFeePayment.UserId INNER JOIN Hostel On Hostelers.HostelId = Hostel.HostelId   where Department.ClassName = '" + cmbCourse.Text.Trim() + "' AND Department.FacultyName = '" + cmbBranch.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "' AND HostelFeePayment.Year = '" + cmbYear.Text.Trim()+"'", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " DateOfAdmission").Value = DateFrom3.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " DateOfAdmission").Value = DateTo3.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "HostelFeePayment");
                dataGridView1.DataSource = myDataSet.Tables["HostelFeePayment"].DefaultView;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Columns["Hostel Name"].Visible = false;                
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (cmbYear.Text == "")
            {
                MessageBox.Show("Please select Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbYear.Focus();
                return;
            }

            if (dataGridView1.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            this.Hide();
            frmHostelFeePayment frm = new frmHostelFeePayment();
            // or simply use column name instead of index
            dr.Cells["Class No"].Value.ToString();
            frm.Show();
            frm.cmbClassName.Text = cmbCourse.Text.Trim();
            frm.cmbFaculty.Text = cmbBranch.Text.Trim();
            frm.cmbSession.Text = cmbSession.Text.Trim();
            frm.cmbYear.Text = cmbYear.Text.Trim();
            frm.txtStudentName.Text = dr.Cells[1].Value.ToString();
            frm.txtFatherName.Text = dr.Cells[2].Value.ToString();
            frm.PaymentDate.Text = dr.Cells[3].Value.ToString();
            frm.cmbModeOfPayment.Text = dr.Cells[4].Value.ToString();
            frm.txtTotalPaid.Text = dr.Cells[5].Value.ToString();
            frm.txtDueFees.Text = dr.Cells[7].Value.ToString();
            frm.txtFine.Text = dr.Cells[6].Value.ToString();
            frm.cmbHostelName.Text = dr.Cells[9].Value.ToString();
            frm.txtHostelFees.Text = dr.Cells[10].Value.ToString();
            frm.CmbClassNo.Text = dr.Cells[0].Value.ToString();
            if (label17.Text == "Admin")
            {
                frm.Delete.Enabled = true;
                frm.Update_record.Enabled = true;
                frm.cmbClassName.Focus();
                frm.btnSave.Enabled = false;
                frm.label3.Text = label17.Text;
                frm.label4.Text = label18.Text;
            }
            else
            {
                frm.Delete.Enabled = false;
                frm.Update_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.cmbClassName.Focus();
                frm.label3.Text = label17.Text;
                frm.label4.Text = label18.Text;

            }
            frm.Print.Enabled = true;
        }

        private void frmHostelFeesPaymentRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmHostelFeePayment frm = new frmHostelFeePayment();
            frm.label3.Text = label17.Text;
            frm.label4.Text = label18.Text;
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
            cmbCourse.Text = "";
            cmbBranch.Text = "";
            cmbSession.Text = "";
            cmbYear.Text = "";
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

        private void cmbHostelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTRIM(Department.ClassName)[Program],RTRIM(Department.FacultyName)[Faculty],RTRIM(Session.Description)[Session],RTRIM(Student.ClassNo)[Class No],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],RTRIM(HostelFeePayment.Year)[Year],RTRIM(HostelFeePayment.DateOfPayment)[Date Of Payment],RTRIM(HostelFeePayment.ModeOfPayment)[Mode Of Payment],RTRIM(HostelFeePayment.TotalPaid)[Total Paid],RTRIM(HostelFeePayment.Fine)[Fine],RTRIM(HostelFeePayment.DueFee)[Due Fees],RTRIM(Users.Name)[Paid By],RTRIM(Hostel.HostelName)[Hostel Name],RTRIM(Hostel.HostelFee)[Hostel Fees] from HostelFeePayment  Inner JOin Hostelers On HostelFeePayment.HostelerId = Hostelers.HostelerId Inner JOin Student On Student.StudentId = Hostelers.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN Users On Users.UserId = HostelFeePayment.UserId INNER JOIN Hostel On Hostelers.HostelId = Hostel.HostelId   where Hostel.HostelName= '" + cmbHostelName.Text.Trim()+"'", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "HostelFeePayment");
                dataGridView5.DataSource = myDataSet.Tables["HostelFeePayment"].DefaultView;
                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
                    dataGridView5.Columns["Hostel Name"].Visible = false;
                    dataGridView5.Columns["Mode Of Payment"].Visible = false;
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
            if (dataGridView5.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DataGridViewRow dr = dataGridView5.SelectedRows[0];
            this.Hide();
            frmHostelFeePayment frm = new frmHostelFeePayment();
            // or simply use column name instead of index
            dr.Cells["Class No"].Value.ToString();
            frm.Show();
            frm.cmbClassName.Text = dr.Cells[0].Value.ToString();
            frm.cmbFaculty.Text = dr.Cells[1].Value.ToString();
            frm.cmbSession.Text = dr.Cells[2].Value.ToString();
            frm.cmbHostelName.Text = dr.Cells[13].Value.ToString();
            frm.txtHostelFees.Text = dr.Cells[14].Value.ToString();
            frm.CmbClassNo.Text = dr.Cells[3].Value.ToString();
            frm.txtStudentName.Text = dr.Cells[4].Value.ToString();
            frm.txtFatherName.Text = dr.Cells[5].Value.ToString();
            frm.cmbYear.Text = dr.Cells[6].Value.ToString();
            frm.PaymentDate.Text = dr.Cells[7].Value.ToString();
            frm.cmbModeOfPayment.Text = dr.Cells[8].Value.ToString();
            frm.txtFine.Text = dr.Cells[10].Value.ToString();
            frm.txtTotalPaid.Text = dr.Cells[9].Value.ToString();
            frm.txtDueFees.Text = dr.Cells[11].Value.ToString();
            if (label17.Text == "Admin")
            {
                frm.Delete.Enabled = true;
                frm.Update_record.Enabled = true;
                frm.cmbClassName.Focus();
                frm.btnSave.Enabled = false;
                frm.label3.Text = label17.Text;
                frm.label4.Text = label18.Text;
            }
            else
            {
                frm.Delete.Enabled = false;
                frm.Update_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.cmbClassName.Focus();
                frm.label3.Text = label17.Text;
                frm.label4.Text = label18.Text;

            }
            frm.Print.Enabled = true;
        }

        private void dataGridView5_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView5.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView5.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTRIM(Department.ClassName)[Program],RTRIM(Department.FacultyName)[Faculty],RTRIM(Session.Description)[Session],RTRIM(Student.ClassNo)[Class No],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],RTRIM(HostelFeePayment.Year)[Year],RTRIM(HostelFeePayment.DateOfPayment)[Date Of Payment],RTRIM(HostelFeePayment.ModeOfPayment)[Mode Of Payment],RTRIM(HostelFeePayment.TotalPaid)[Total Paid],RTRIM(HostelFeePayment.Fine)[Fine],RTRIM(HostelFeePayment.DueFee)[Due Fees],RTRIM(Users.Name)[Paid By],RTRIM(Hostel.HostelName)[Hostel Name],RTRIM(Hostel.HostelFee)[Hostel Fees] from HostelFeePayment  Inner JOin Hostelers On HostelFeePayment.HostelerId = Hostelers.HostelerId Inner JOin Student On Student.StudentId = Hostelers.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN Users On Users.UserId = HostelFeePayment.UserId INNER JOIN Hostel On Hostelers.HostelId = Hostel.HostelId   where Hostel.HostelName like  '" + txtHostelName.Text.Trim() + "%'", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "HostelFeePayment");
                dataGridView5.DataSource = myDataSet.Tables["HostelFeePayment"].DefaultView;
                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
                    dataGridView5.Columns["Hostel Name"].Visible = false;
                    dataGridView5.Columns["Mode Of Payment"].Visible = false;
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
            cmbHostelName.Text = "";
            txtHostelName.Text = "";
            dataGridView5.DataSource = null;
        }
        private void Reset2_Click(object sender, EventArgs e)
        {
            Tab2Reset();
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

        private void button4_Click(object sender, EventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTRIM(Department.ClassName)[Program],RTRIM(Department.FacultyName)[Faculty],RTRIM(Session.Description)[Session],RTRIM(Student.ClassNo)[Class No],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],RTRIM(HostelFeePayment.Year)[Year],RTRIM(HostelFeePayment.DateOfPayment)[Date Of Payment],RTRIM(HostelFeePayment.ModeOfPayment)[Mode Of Payment],RTRIM(HostelFeePayment.TotalPaid)[Total Paid],RTRIM(HostelFeePayment.Fine)[Fine],RTRIM(HostelFeePayment.DueFee)[Due Fees],RTRIM(Users.Name)[Paid By],RTRIM(Hostel.HostelName)[Hostel Name],RTRIM(Hostel.HostelFee)[Hostel Fees] from HostelFeePayment  Inner JOin Hostelers On HostelFeePayment.HostelerId = Hostelers.HostelerId Inner JOin Student On Student.StudentId = Hostelers.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN Users On Users.UserId = HostelFeePayment.UserId INNER JOIN Hostel On Hostelers.HostelId = Hostel.HostelId   where HostelFeePayment.DateOfPayment between @date1 AND @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " DateOfAdmission").Value = DateFrom1.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " DateOfAdmission").Value = DateTo1.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "HostelFeePayment");
                dataGridView4.DataSource = myDataSet.Tables["HostelFeePayment"].DefaultView;
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    dataGridView4.Columns["Hostel Name"].Visible = false;
                    dataGridView4.Columns["Mode Of Payment"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTRIM(Department.ClassName)[Program],RTRIM(Department.FacultyName)[Faculty],RTRIM(Session.Description)[Session],RTRIM(Student.ClassNo)[Class No],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],RTRIM(HostelFeePayment.Year)[Year],RTRIM(HostelFeePayment.DateOfPayment)[Date Of Payment],RTRIM(HostelFeePayment.ModeOfPayment)[Mode Of Payment],RTRIM(HostelFeePayment.TotalPaid)[Total Paid],RTRIM(HostelFeePayment.Fine)[Fine],RTRIM(HostelFeePayment.DueFee)[Due Fees],RTRIM(Users.Name)[Paid By],RTRIM(Hostel.HostelName)[Hostel Name],RTRIM(Hostel.HostelFee)[Hostel Fees] from HostelFeePayment  Inner JOin Hostelers On HostelFeePayment.HostelerId = Hostelers.HostelerId Inner JOin Student On Student.StudentId = Hostelers.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN Users On Users.UserId = HostelFeePayment.UserId INNER JOIN Hostel On Hostelers.HostelId = Hostel.HostelId   where HostelFeePayment.DateOfPayment between @date1 AND @date2 AND HostelFeePayment.DueFee > 0", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " DateOfAdmission").Value = DateFrom2.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " DateOfAdmission").Value = DateTo2.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "HostelFeePayment");
                dataGridView3.DataSource = myDataSet.Tables["HostelFeePayment"].DefaultView;
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    dataGridView3.Columns["Hostel Name"].Visible = false;
                    dataGridView3.Columns["Mode Of Payment"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTRIM(Department.ClassName)[Program],RTRIM(Department.FacultyName)[Faculty],RTRIM(Session.Description)[Session],RTRIM(Student.ClassNo)[Class No],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],RTRIM(HostelFeePayment.Year)[Year],RTRIM(HostelFeePayment.DateOfPayment)[Date Of Payment],RTRIM(HostelFeePayment.ModeOfPayment)[Mode Of Payment],RTRIM(HostelFeePayment.TotalPaid)[Total Paid],RTRIM(HostelFeePayment.Fine)[Fine],RTRIM(HostelFeePayment.DueFee)[Due Fees],RTRIM(Users.Name)[Paid By],RTRIM(Hostel.HostelName)[Hostel Name],RTRIM(Hostel.HostelFee)[Hostel Fees] from HostelFeePayment  Inner JOin Hostelers On HostelFeePayment.HostelerId = Hostelers.HostelerId Inner JOin Student On Student.StudentId = Hostelers.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN Users On Users.UserId = HostelFeePayment.UserId INNER JOIN Hostel On Hostelers.HostelId = Hostel.HostelId   where HostelFeePayment.DateOfPayment between @date1 AND @date2 AND HostelFeePayment.Fine > 0", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " DateOfAdmission").Value = DateFrom2.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " DateOfAdmission").Value = DateTo2.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "HostelFeePayment");
                dataGridView2.DataSource = myDataSet.Tables["HostelFeePayment"].DefaultView;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    dataGridView2.Columns["Hostel Name"].Visible = false;
                    dataGridView2.Columns["Mode Of Payment"].Visible = false;
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
            if (dataGridView4.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DataGridViewRow dr = dataGridView4.SelectedRows[0];
            this.Hide();
            frmHostelFeePayment frm = new frmHostelFeePayment();
            // or simply use column name instead of index
            dr.Cells["Class No"].Value.ToString();
            frm.Show();
            frm.cmbClassName.Text = dr.Cells[0].Value.ToString();
            frm.cmbFaculty.Text = dr.Cells[1].Value.ToString();
            frm.cmbSession.Text = dr.Cells[2].Value.ToString();
            frm.cmbHostelName.Text = dr.Cells[13].Value.ToString();
            frm.txtHostelFees.Text = dr.Cells[14].Value.ToString();
            frm.CmbClassNo.Text = dr.Cells[3].Value.ToString();
            frm.txtStudentName.Text = dr.Cells[4].Value.ToString();
            frm.txtFatherName.Text = dr.Cells[5].Value.ToString();
            frm.cmbYear.Text = dr.Cells[6].Value.ToString();
            frm.PaymentDate.Text = dr.Cells[7].Value.ToString();
            frm.cmbModeOfPayment.Text = dr.Cells[8].Value.ToString();
            frm.txtFine.Text = dr.Cells[10].Value.ToString();
            frm.txtTotalPaid.Text = dr.Cells[9].Value.ToString();
            frm.txtDueFees.Text = dr.Cells[11].Value.ToString();
            if (label17.Text == "Admin")
            {
                frm.Delete.Enabled = true;
                frm.Update_record.Enabled = true;
                frm.cmbClassName.Focus();
                frm.btnSave.Enabled = false;
                frm.label3.Text = label17.Text;
                frm.label4.Text = label18.Text;
            }
            else
            {
                frm.Delete.Enabled = false;
                frm.Update_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.cmbClassName.Focus();
                frm.label3.Text = label17.Text;
                frm.label4.Text = label18.Text;

            }
            frm.Print.Enabled = true;
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView3.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DataGridViewRow dr = dataGridView3.SelectedRows[0];
            this.Hide();
            frmHostelFeePayment frm = new frmHostelFeePayment();
            // or simply use column name instead of index
            dr.Cells["Class No"].Value.ToString();
            frm.Show();
            frm.cmbClassName.Text = dr.Cells[0].Value.ToString();
            frm.cmbFaculty.Text = dr.Cells[1].Value.ToString();
            frm.cmbSession.Text = dr.Cells[2].Value.ToString();
            frm.cmbHostelName.Text = dr.Cells[13].Value.ToString();
            frm.txtHostelFees.Text = dr.Cells[14].Value.ToString();
            frm.CmbClassNo.Text = dr.Cells[3].Value.ToString();
            frm.txtStudentName.Text = dr.Cells[4].Value.ToString();
            frm.txtFatherName.Text = dr.Cells[5].Value.ToString();
            frm.cmbYear.Text = dr.Cells[6].Value.ToString();
            frm.PaymentDate.Text = dr.Cells[7].Value.ToString();
            frm.cmbModeOfPayment.Text = dr.Cells[8].Value.ToString();
            frm.txtFine.Text = dr.Cells[10].Value.ToString();
            frm.txtTotalPaid.Text = dr.Cells[9].Value.ToString();
            frm.txtDueFees.Text = dr.Cells[11].Value.ToString();
            if (label17.Text == "Admin")
            {
                frm.Delete.Enabled = true;
                frm.Update_record.Enabled = true;
                frm.cmbClassName.Focus();
                frm.btnSave.Enabled = false;
                frm.label3.Text = label17.Text;
                frm.label4.Text = label18.Text;
            }
            else
            {
                frm.Delete.Enabled = false;
                frm.Update_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.cmbClassName.Focus();
                frm.label3.Text = label17.Text;
                frm.label4.Text = label18.Text;

            }
            frm.Print.Enabled = true;
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView2.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            this.Hide();
            frmHostelFeePayment frm = new frmHostelFeePayment();
            // or simply use column name instead of index
            dr.Cells["Class No"].Value.ToString();
            frm.Show();
            frm.cmbClassName.Text = dr.Cells[0].Value.ToString();
            frm.cmbFaculty.Text = dr.Cells[1].Value.ToString();
            frm.cmbSession.Text = dr.Cells[2].Value.ToString();
            frm.cmbHostelName.Text = dr.Cells[13].Value.ToString();
            frm.txtHostelFees.Text = dr.Cells[14].Value.ToString();
            frm.CmbClassNo.Text = dr.Cells[3].Value.ToString();
            frm.txtStudentName.Text = dr.Cells[4].Value.ToString();
            frm.txtFatherName.Text = dr.Cells[5].Value.ToString();
            frm.cmbYear.Text = dr.Cells[6].Value.ToString();
            frm.PaymentDate.Text = dr.Cells[7].Value.ToString();
            frm.cmbModeOfPayment.Text = dr.Cells[8].Value.ToString();
            frm.txtFine.Text = dr.Cells[10].Value.ToString();
            frm.txtTotalPaid.Text = dr.Cells[9].Value.ToString();
            frm.txtDueFees.Text = dr.Cells[11].Value.ToString();
            if (label17.Text == "Admin")
            {
                frm.Delete.Enabled = true;
                frm.Update_record.Enabled = true;
                frm.cmbClassName.Focus();
                frm.btnSave.Enabled = false;
                frm.label3.Text = label17.Text;
                frm.label4.Text = label18.Text;
            }
            else
            {
                frm.Delete.Enabled = false;
                frm.Update_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.cmbClassName.Focus();
                frm.label3.Text = label17.Text;
                frm.label4.Text = label18.Text;

            }
            frm.Print.Enabled = true;
        }
        private void Tab3Reset()
        {
            DateFrom1.Text = DateTime.Now.ToString();
            DateTo1.Text = DateTime.Now.ToString();
            dataGridView4.DataSource = null; 
        }
        private void Reset3_Click(object sender, EventArgs e)
        {
            Tab3Reset();
        }

        private void Tab4Reset()
        {
            DateFrom2.Text = DateTime.Now.ToString();
            DateTo2.Text = DateTime.Now.ToString();
            dataGridView3.DataSource = null;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Tab4Reset();
        }
        private void Tab5Reset()
        {
            DateFrom3.Text = DateTime.Now.ToString();
            DateTo3.Text = DateTime.Now.ToString();
            dataGridView2.DataSource = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Tab5Reset();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            Tab1Reset();
            Tab2Reset();
            Tab3Reset();
            Tab4Reset();
            Tab5Reset();
        }
    }
}
