using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace College_Management_System
{
    public partial class frmBatchRecord : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
    

        public frmBatchRecord()
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
        private void GetSessions()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(SessionId)[Session ID],RTRIM(Description)[Session],IsActive[IsActive] FROM Session order by Description", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Sessions");
                dataGridView1.DataSource = myDataSet.Tables["Sessions"].DefaultView;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Columns["Session ID"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void frmBatchRecord_Load(object sender, EventArgs e)
        {
            GetSessions();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            this.Hide();
            frmBatch frm = new frmBatch();
            // or simply use column name instead of index
            dr.Cells["Session ID"].Value.ToString();
            frm.Show();
            frm.lblBatchId.Visible = false;
            frm.SessionId.Visible = false;
            frm.SessionId.Text = dr.Cells[0].Value.ToString();
            frm.Session.Text = dr.Cells[1].Value.ToString();
            if (dr.Cells[2].Value.ToString() == "True")
            {
                frm.isActive.Checked = true;
            }
            else
            {
                frm.isActive.Checked = false;

            }
            if (label1.Text == "Admin")
            {
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.label6.Text = label1.Text;
                frm.btnSave.Enabled = false;
                
            }
            else
            {
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.label6.Text = label1.Text;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmBatchRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmBatch frm = new frmBatch();
            frm.label6.Text = label1.Text;
            frm.Show();
        }
    }
}
