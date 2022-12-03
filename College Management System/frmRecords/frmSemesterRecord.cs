using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace College_Management_System
{
    public partial class frmSemesterRecord : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmSemesterRecord()
        {
            InitializeComponent();
        }
      
        private SqlConnection Connection
        {
            get
            {
                SqlConnection ConnectionToFetch = new SqlConnection(cs.DBConn);
                ConnectionToFetch.Open();
                return ConnectionToFetch;
            }
        }
        private void GetSemesters()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(SemesterId)[Semester ID],RTRIM(Description)[Description],RTRIM(Season)[Season] FROM Semester order by Description", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Semesters");
                dataGridView1.DataSource = myDataSet.Tables["Semesters"].DefaultView;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Columns["Semester ID"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
 
        private void frmSemesterRecord_Load(object sender, EventArgs e)
        {
            GetSemesters();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            this.Hide();
            frmSemester frm = new frmSemester();
            // or simply use column name instead of index
            dr.Cells["Semester ID"].Value.ToString();
            frm.Show();
            frm.txtSemesterID.Visible = false;
            frm.txtSemesterID.Text = dr.Cells[0].Value.ToString();
            frm.txtSemesterName.Text = dr.Cells[1].Value.ToString();
            frm.cmbSeason.Text = dr.Cells[2].Value.ToString();

            if (label1.Text == "Admin")
            {
                frm.label1.Text = label1.Text;
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.btnSave.Enabled = false;
                frm.txtSemesterName.Focus();
            }
            else
            {
                frm.label1.Text = label1.Text;
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.txtSemesterName.Focus();
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

        private void frmSemesterRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmSemester frm = new frmSemester();
            frm.label1.Text = label1.Text;
            frm.Show();
        }
    }
}
