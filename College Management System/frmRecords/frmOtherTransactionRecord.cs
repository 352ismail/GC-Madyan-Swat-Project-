using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
namespace College_Management_System
{
    public partial class frmOtherTransactionRecord : Form
    {
      
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();

        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();

       
        public frmOtherTransactionRecord()
        {
            InitializeComponent();
        }

        private void frmTransactionRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmOtherTransaction frm = new frmOtherTransaction();
            frm.label4.Text = label1.Text;
            frm.label6.Text = label2.Text;
            frm.Show();
        }    
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(Transactionid)[Transaction ID],RTRIM(TransactionType)[Transaction Type],RTRIM(Date)[Transaction Date],RTRIM(Amount)[Amount],RTRIM(Users.Name)[By],RTRIM(Description)[Description] FROM othertransaction  INNER JOIN Users ON Users.UserId = OtherTransaction.UserId  where date between @date1 and @date2 order by date", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, " Date").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, " Date").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "OtherTransaction");
                dataGridView1.DataSource = myDataSet.Tables["OtherTransaction"].DefaultView;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Columns["Transaction ID"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateFrom.Text= System.DateTime.Today.ToString();
            DateTo.Text = System.DateTime.Today.ToString();
            dataGridView1.DataSource = null;
        }

        private void frmTransactionRecord_Load(object sender, EventArgs e)
        {

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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            this.Hide();
            frmOtherTransaction frm = new frmOtherTransaction();
            // or simply use column name instead of index
            dr.Cells["Transaction ID"].Value.ToString();
            frm.Show();
            frm.txtTransactionID.Visible = false;
            frm.txtTransactionID.Text = dr.Cells[0].Value.ToString();
            if (dr.Cells[1].Value.ToString() == frm.rbcredit.Text)
            {
                frm.rbcredit.Checked = true;
            }
            else if (dr.Cells[1].Value.ToString() == frm.rbdebit.Text)
            {
                frm.rbdebit.Checked = true;
            }
            frm.dtp.Text = dr.Cells[2].Value.ToString();
            frm.txtamt.Text = dr.Cells[3].Value.ToString();
            frm.txtdes.Text = dr.Cells[5].Value.ToString();

            if (label1.Text == "Admin")
            {
                frm.Delete.Enabled = true;
                frm.Update_record.Enabled = true;
                frm.label4.Text = label1.Text;
                frm.label6.Text = label2.Text;
                frm.btnSave.Enabled = false;
            }
            else
            {
                frm.Delete.Enabled = false;
                frm.Update_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.label4.Text = label1.Text;
                frm.label6.Text = label2.Text;

            }
        }

        private void button3_Click(object sender, EventArgs e)
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
    }
}
