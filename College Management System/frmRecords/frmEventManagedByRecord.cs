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
    public partial class frmEventManagedByRecord : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlDataAdapter adp = null;
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        public frmEventManagedByRecord()
        {
            InitializeComponent();
        }

        private void frmEventManagedByRecord_Load(object sender, EventArgs e)
        {
            AutocompleteDesignation();
            AutoCompleteEventName();
        }
        private void AutocompleteDesignation()
        {

            try
            {

                SqlConnection CN = new SqlConnection(cs.DBConn);

                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(Designation) FROM Employee", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                cmbDesignation.Items.Clear();

                foreach (DataRow drow in dtable.Rows)
                {
                    cmbDesignation.Items.Add(drow[0].ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AutoCompleteEventName()
        {
            try
            {
                cmbEventName.Items.Clear();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(EventName) from Event";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbEventName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
     
        }

        private void cmbEventName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("Select  RTRIM(Employee.EmployeeName)[Managed By],RTRIM(Employee.Designation)[Designation],RTRIM(Employee.Gender)[Gender],RTRIM(Event.StartingTime)[Starting Time],RTRIM(Event.StartingDate)[Starting Date],RTRIM(Event.EndingTime)[Ending Time],RTRIM(Event.EndingDate)[Ending Date] From EventManagedBy INNER JOIN Event ON  EventManagedBy.EventId = Event.EventId INNER JOIN Employee ON EventManagedBy.EmployeeId = Employee.EmployeeId AND Event.EventName  = '" + cmbEventName.Text.Trim() + "'", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "EventManagedBy");
                dataGridView1.DataSource = myDataSet.Tables["EventManagedBy"].DefaultView;
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
            if (dataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }
        private void Tab11Reset()
        {
            cmbEventName.Text = "";
            dataGridView1.DataSource = null;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            Tab11Reset();
        }

        private void btnExport_Click(object sender, EventArgs e)
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

        private void frmEventManagedByRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmRecords.frmEventManagedBy frm = new frmRecords.frmEventManagedBy();
            if (label25.Text == "Admin")
            {
                frm.label5.Text = label25.Text;
                frm.Delete.Enabled = true;
                frm.Update_record.Enabled = true;
                frm.Show();
            }
            else
            {
                frm.label5.Text = label25.Text;
                frm.Delete.Enabled = false;
                frm.Update_record.Enabled = false;
                frm.Show();
            }
        }

        private void cmbDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbEmployeeName.Items.Clear();
            cmbEmployeeName.Text = "";
            cmbEmployeeName.Enabled = true;
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(EmployeeName) FROM Employee where Designation = '"+cmbDesignation.Text.Trim()+"'", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
            

                foreach (DataRow drow in dtable.Rows)
                {
                    cmbEmployeeName.Items.Add(drow[0].ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Validation
            if (cmbDesignation.Text == "")
            {
                MessageBox.Show("Please select Designation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbDesignation.Focus();
                return;
            }
            if (cmbEmployeeName.Text == "")
            {
                MessageBox.Show("Please select Employee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbEmployeeName.Focus();
                return;
            }
            #endregion
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("Select  RTRIM(Event.EventName)[Event Name],RTRIM(Event.StartingTime)[Starting Time],RTRIM(Event.StartingDate)[Starting Date],RTRIM(Event.EndingTime)[Ending Time],RTRIM(Event.EndingDate)[Ending Date] From EventManagedBy INNER JOIN Event ON  EventManagedBy.EventId = Event.EventId INNER JOIN Employee ON EventManagedBy.EmployeeId = Employee.EmployeeId where  Employee.EmployeeName  = '" + cmbEmployeeName.Text.Trim() + "'  AND Employee.Designation  = '" + cmbDesignation.Text.Trim() + "'", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "EventManagedBy");
                dataGridView2.DataSource = myDataSet.Tables["EventManagedBy"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (dataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }
        private void Tab2Reset()
        {
            cmbEmployeeName.Text = "";
            cmbDesignation.Text = "";
            dataGridView2.DataSource = null;
        }
        private void button2_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("Select  RTRIM(Employee.EmployeeName)[Managed By],RTRIM(Employee.Designation)[Designation],RTRIM(Event.EventName)[Event Name],RTRIM(Event.StartingTime)[Starting Time],RTRIM(Event.StartingDate)[Starting Date],RTRIM(Event.EndingDate)[Ending Date] From EventManagedBy INNER JOIN Event ON  EventManagedBy.EventId = Event.EventId INNER JOIN Employee ON EventManagedBy.EmployeeId = Employee.EmployeeId where Startingdate Between @date1 and @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " DateOfAdmission").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " DateOfAdmission").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "EventManagedBy");
                dataGridView3.DataSource = myDataSet.Tables["EventManagedBy"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Tab3Reset()
        {
            DateFrom.Text = DateTime.Now.ToString();
            DateTo.Text = DateTime.Now.ToString();
            dataGridView3.DataSource = null; 
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Tab3Reset();
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void tabControl1_Click(object sender, EventArgs e)
        {
            Tab11Reset();
            Tab2Reset();
            Tab3Reset();

        }
    }
}
