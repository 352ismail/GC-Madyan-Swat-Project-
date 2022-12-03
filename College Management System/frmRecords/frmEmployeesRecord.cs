using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace College_Management_System.frmRecords
{
    public partial class frmEmployeesRecord : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmEmployeesRecord()
        {
            InitializeComponent();
        }

        private void frmEmployeesRecord_Load(object sender, EventArgs e)
        {
            AutocompleteStaffName();
            GetEmployees();
        }



        private void GetEmployees()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTrim(EmployeeID)[Employee ID],RTRIM(EmployeeName)[Name],RTRIM(Gender)[Gender], RTRIM(ContactNo)[Contact No], RTRIM(Address)[Address], RTRIM(Email)[Email],RTRIM(Qualification)[Qualification],  RTRIM(Designation)[Designation],RTRIM(DateOfJoining)[Date Of Joining] from Employee order by EmployeeName", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Employee");
                dataGridView1.DataSource = myDataSet.Tables["Employee"].DefaultView;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Columns["Employee ID"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AutocompleteStaffName()
        {

            try
            {

                SqlConnection CN = new SqlConnection(cs.DBConn);

                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(EmployeeName) FROM Employee", CN);
                ds = new DataSet("ds");

                adp.Fill(ds);
                dtable = ds.Tables[0];
                cmbEmployeeName.Items.Clear();

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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            this.Hide();
            frmEmployeeDetails frm = new frmEmployeeDetails();
            // or simply use column name instead of index
            dr.Cells["Employee ID"].Value.ToString();
            frm.Show();
            frm.txtStaffID.Text = dr.Cells[0].Value.ToString();
            frm.txtStaffName.Text = dr.Cells[1].Value.ToString();
            if (dr.Cells[2].Value.ToString() == "Male")
            {
                frm.rdbMale.Checked = true;
            }
            if (dr.Cells[2].Value.ToString() == "Female")
            {
                frm.rdbFemale.Checked = true;
            }
            frm.txtContactNo.Text = dr.Cells[3].Value.ToString();
            frm.txtAddress.Text = dr.Cells[4].Value.ToString();
            frm.txtEmail.Text = dr.Cells[5].Value.ToString();
            frm.txtQualifications.Text = dr.Cells[6].Value.ToString();
            frm.txtDesignation.Text = dr.Cells[7].Value.ToString();
            frm.DateOfJoining.Text = dr.Cells[8].Value.ToString();

            con = new SqlConnection(cs.DBConn);
            //For Getting  Image
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "select Photo from Employee where EmployeeId = '" + dr.Cells[0].Value.ToString() + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                MemoryStream stream = new MemoryStream();
                byte[] image = (byte[])rdr["Photo"];
                stream.Write(image, 0, image.Length);
                Bitmap bitmap = new Bitmap(stream);
                frm.pictureBox1.Image = bitmap;
            }

            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }


            if (label1.Text == "Admin")
            {
                frm.Delete.Enabled = true;
                frm.Update_record.Enabled = true;
                frm.txtStaffName.Focus();
                frm.label21.Text = label1.Text;
                frm.btnSave.Enabled = false;
                frm.btnPrint.Enabled = true;
                frm.btnPrint.Enabled = true;
            }
            else
            {
                frm.Delete.Enabled = false;
                frm.Update_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.txtStaffName.Focus();
                frm.label21.Text = label1.Text;
                frm.btnPrint.Enabled = false;
                frm.btnPrint.Enabled = true;

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

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView2.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            this.Hide();
            frmEmployeeDetails frm = new frmEmployeeDetails();
            // or simply use column name instead of index
            dr.Cells["Employee ID"].Value.ToString();
            frm.Show();
            frm.txtStaffID.Text = dr.Cells[0].Value.ToString();
            frm.txtStaffName.Text = dr.Cells[1].Value.ToString();
            if (dr.Cells[2].Value.ToString() == "Male")
            {
                frm.rdbMale.Checked = true;
            }
            if (dr.Cells[2].Value.ToString() == "Female")
            {
                frm.rdbFemale.Checked = true;
            }
            frm.txtContactNo.Text = dr.Cells[3].Value.ToString();
            frm.txtAddress.Text = dr.Cells[4].Value.ToString();
            frm.txtEmail.Text = dr.Cells[5].Value.ToString();
            frm.txtQualifications.Text = dr.Cells[6].Value.ToString();
            frm.txtDesignation.Text = dr.Cells[7].Value.ToString();
            frm.DateOfJoining.Text = dr.Cells[8].Value.ToString();

            con = new SqlConnection(cs.DBConn);
            //For Getting  Image
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "select Photo from Employee where EmployeeId = '" + dr.Cells[0].Value.ToString() + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                MemoryStream stream = new MemoryStream();
                byte[] image = (byte[])rdr["Photo"];
                stream.Write(image, 0, image.Length);
                Bitmap bitmap = new Bitmap(stream);
                frm.pictureBox1.Image = bitmap;
            }

            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }


            if (label1.Text == "Admin")
            {
                frm.Delete.Enabled = true;
                frm.Update_record.Enabled = true;
                frm.txtStaffName.Focus();
                frm.label21.Text = label1.Text;
                frm.btnSave.Enabled = false;
                frm.btnPrint.Enabled = true;
            }
            else
            {
                frm.Delete.Enabled = false;
                frm.Update_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.txtStaffName.Focus();
                frm.label21.Text = label1.Text;
                frm.btnPrint.Enabled = true;
            }
        }

        private void frmEmployeesRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmEmployeeDetails frm = new frmEmployeeDetails();
            frm.label21.Text = label1.Text;
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
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

        private void cmbEmployeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTrim(EmployeeID)[Employee ID],RTRIM(EmployeeName)[Name],RTRIM(Gender)[Gender], RTRIM(ContactNo)[Contact No], RTRIM(Address)[Address], RTRIM(Email)[Email],RTRIM(Qualification)[Qualification],  RTRIM(Designation)[Designation],RTRIM(DateOfJoining)[Date Of Joining] from Employee where EmployeeName = '" + cmbEmployeeName.Text.Trim() + "' order by EmployeeName", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Employee");
                dataGridView2.DataSource = myDataSet.Tables["Employee"].DefaultView;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    dataGridView2.Columns["Employee ID"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTrim(EmployeeID)[Employee ID],RTRIM(EmployeeName)[Name],RTRIM(Gender)[Gender], RTRIM(ContactNo)[Contact No], RTRIM(Address)[Address], RTRIM(Email)[Email],RTRIM(Qualification)[Qualification],  RTRIM(Designation)[Designation],RTRIM(DateOfJoining)[Date Of Joining] from Employee where EmployeeName like  '" + txtEmployeeName.Text.Trim() + "%' order by EmployeeName", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Employee");
                dataGridView2.DataSource = myDataSet.Tables["Employee"].DefaultView;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    dataGridView2.Columns["Employee ID"].Visible = false;
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
            cmbEmployeeName.Text = "";
            txtEmployeeName.Text = "";
            dataGridView2.DataSource = null;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Tab2Reset();

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void tabControl1_Click(object sender, EventArgs e)
        {
            Tab2Reset();
            GetEmployees();
        }
    }
}
