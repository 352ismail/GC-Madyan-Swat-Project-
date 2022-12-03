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

namespace College_Management_System.frmRecords
{
    public partial class frmEventsRecord : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmEventsRecord()
        {
            InitializeComponent();
        }

        private void frmEventsRecord_Load(object sender, EventArgs e)
        {
            GetEvents();
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
        private void GetEvents()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(EventID)[Event ID],RTRIM(EventName)[Event Name],RTRIM(StartingDate)[Starting Date],RTRIM(StartingTime)[Starting Time],RTRIM(EndingDate)[Ending Date],RTRIM(EndingTime)[Ending Time],(Activities)[Activities] FROM Event order by EventName,StartingDate", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Events");
                dataGridView1.DataSource = myDataSet.Tables["Events"].DefaultView;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Columns["Event ID"].Visible = false;
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            this.Hide();
            frmEvent frm = new frmEvent();
            // or simply use column name instead of index
            dr.Cells["Event ID"].Value.ToString();
            frm.Show();
            frm.txtEventID.Visible = false;
            frm.txtEventID.Text = dr.Cells[0].Value.ToString();
            frm.EventName.Text = dr.Cells[1].Value.ToString();
            frm.StartingDate.Text = dr.Cells[2].Value.ToString();
            frm.StartingTime.Text = dr.Cells[3].Value.ToString();
            frm.EndingDate.Text = dr.Cells[4].Value.ToString();
            frm.EndingTime.Text = dr.Cells[5].Value.ToString();
            frm.Activities.Text = dr.Cells[6].Value.ToString();
            if (label1.Text == "Admin")
            {
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.EventName.Focus();
                frm.label6.Text = label1.Text;
                frm.btnSave.Enabled = false;
            }
            else
            {
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.EventName.Focus();
                frm.label6.Text = label1.Text;
            }
        }

        private void frmEventsRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmEvent frm = new frmEvent();
            frm.label6.Text = label1.Text;
            frm.Show();
        }

    }
}
