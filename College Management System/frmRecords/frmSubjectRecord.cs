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
    public partial class frmSubjectInfoRecord : Form
    {
  
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmSubjectInfoRecord()
        {
            InitializeComponent();
        }
        private void frmSubjectInfoRecord_Load(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = new SqlCommand("Select Subject.SubjectId[Subject ID],Subject.SubjectCode[Subject Code],Subject.SubjectName[Subject Name],Subject.CH[Credit Hour] From Subject order by SubjectName", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Subject");
                dataGridView1.DataSource = myDataSet.Tables["Subject"].DefaultView;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Columns["Subject ID"].Visible = false;
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
            if (dataGridView1.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            this.Hide();
            frmSubjectInfo frm = new frmSubjectInfo();
            // or simply use column name instead of index
            dr.Cells["Subject ID"].Value.ToString();
            frm.Show();
            frm.subjectId.Visible = false;
            frm.lblSubjectId.Visible = false;
            frm.subjectId.Text = dr.Cells[0].Value.ToString();
            frm.txtSubjectCode.Text = dr.Cells[1].Value.ToString();
            frm.SubjectName.Text = dr.Cells[2].Value.ToString();
            frm.cmbCreditHour.Text = dr.Cells[3].Value.ToString();
            if (label1.Text == "Admin")
            {
                frm.Delete.Enabled = true;
                frm.Update_record.Enabled = true;
                frm.SubjectName.Focus();
                frm.btnSave.Enabled = false;
                frm.label1.Text = label1.Text;
            }
            else
            {
                frm.Delete.Enabled = false;
                frm.Update_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.SubjectName.Focus();
                frm.label1.Text = label1.Text;

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

        private void frmSubjectInfoRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmSubjectInfo frm = new frmSubjectInfo();
            frm.label1.Text = label1.Text;
            frm.Show();
        }
    }
}
