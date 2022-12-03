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

namespace College_Management_System
{
    public partial class frmIdCardRecord : Form
    {

        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmIdCardRecord()
        {
            InitializeComponent();
        }
      
        
        private void frmIdCardDetails_Load(object sender, EventArgs e)
        {

            AutocompleteClassName();
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
                cmbClassName.Items.Clear();
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            this.Hide();
            frmIdCard frm = new frmIdCard();
            // or simply use column name instead of index
            dr.Cells["ID"].Value.ToString();
            frm.Show();  
            frm.cmbClassName.Text = cmbClassName.Text.Trim();
            frm.cmbFacultyName.Text = cmbFacultyName.Text.Trim();
            frm.cmbSession.Text = cmbSession.Text.Trim();
            frm.cmbRollNo.Text = dr.Cells[1].Value.ToString();
            frm.StudentName.Text = dr.Cells[2].Value.ToString();
            frm.FatherName.Text = dr.Cells[3].Value.ToString();
            frm.txtGender.Text = dr.Cells[4].Value.ToString();
            frm.DOB.Text = dr.Cells[5].Value.ToString();
            frm.BloodGroup.Text = dr.Cells[6].Value.ToString();
            frm.Address.Text = dr.Cells[7].Value.ToString();
            frm.ContactNo.Text = dr.Cells[8].Value.ToString();
            frm.IssueDate.Text = dr.Cells[9].Value.ToString();
            frm.ExpiryDate.Text = dr.Cells[10].Value.ToString();
            if (label3.Text == "Admin")
            {
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.labelU.Text = label3.Text;
                frm.btnSave.Enabled = false;
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.btnPrint.Enabled = true;
            }
            else
            {
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.labelU.Text = label3.Text;
                frm.btnSave.Enabled = false;
                frm.btnPrint.Enabled = true;
            }
        }

        private void cmbClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFacultyName.Items.Clear();
            cmbFacultyName.Text = "";
            cmbFacultyName.Enabled = true;

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();


                string ct = "select distinct RTRIM(FacultyName) from Department where ClassName= '" + cmbClassName.Text.Trim() + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbFacultyName.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFacultyName_SelectedIndexChanged(object sender, EventArgs e)
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
                if (cmbFacultyName.Text == "")
                {
                    MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFacultyName.Focus();
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
                cmd = new SqlCommand("select RTRIM(IdCard.IdCardId)[ID],RTRIM(Student.ClassNo)[Class No],RTRIM(Student.StudentName)[Student Name],RTRIM(Student.FatherName)[Father Name],RTRIM(Student.Gender)[Gender],RTRIM(Student.DateOfBirth)[DOB],RTRIM(Student.Bloodgroup)[Blood Group],RTRIM(Student.StudentAddress)[Adress],RTRIM(Student.ContactNo)[Contact No],RTRIM(IdCard.IssueDate)[Issue Date],RTRIM(IdCard.ExpiryDate)[Expiry Date] From IdCard INNER JOIN Student On Student.StudentId = IdCard.StudentId INNER Join Department On Student.DepartmentId = Department.DepartmentId INNER Join Session On Student.SessionId = Session.SessionId  where Department.ClassName = '" + cmbClassName.Text.Trim() + "' ANd Department.FacultyName = '" + cmbFacultyName.Text.Trim() + "' And Session.Description = '" + cmbSession.Text.Trim() + "'", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "IdCard");
                dataGridView1.DataSource = myDataSet.Tables["IdCard"].DefaultView;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.Columns["Contact No"].Visible = false;
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
            cmbClassName.Text = "";
            cmbFacultyName.Text = "";
            cmbSession.Text = "";
            dataGridView1.DataSource = null;
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

        private void frmIdCardRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmIdCard frm = new frmIdCard();
            frm.labelU.Text = label3.Text;
            frm.Show();

        }
    }
}
