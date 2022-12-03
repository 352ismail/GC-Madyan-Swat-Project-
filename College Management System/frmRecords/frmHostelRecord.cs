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
    public partial class frmHostelRecord : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmHostelRecord()
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
        private void GetHostels()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(HostelId)[Hostel ID],RTRIM(HostelName)[Hostel Name],RTRIM(HostelFee)[HostelFee] FROM Hostel order by Hostelname", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Hostels");
                dataGridView1.DataSource = myDataSet.Tables["Hostels"].DefaultView;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Columns["Hostel ID"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
        private void frmHostelRecord_Load(object sender, EventArgs e)
        {
            GetHostels();
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
            frmHostel frm = new frmHostel();
            // or simply use column name instead of index
            dr.Cells["Hostel ID"].Value.ToString();
            frm.Show();
            frm.txtHostelID.Visible = false;
            frm.lblHostelId.Visible = false;
            frm.txtHostelID.Text = dr.Cells[0].Value.ToString();
            frm.HostelName.Text = dr.Cells[1].Value.ToString();
            frm.HostelFees.Text = dr.Cells[2].Value.ToString();
            if (label1.Text == "Admin")
            {
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.btnSave.Enabled = false;
                frm.HostelName.Focus();
                frm.label1.Text = label1.Text;
            }
            else
            {
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.HostelName.Focus();
                frm.label1.Text = label1.Text;
            }
        }

        private void frmHostelRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmHostel frm = new frmHostel();
            frm.label1.Text = label1.Text;
            frm.Show();

        }
    }
}
