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
    public partial class frmClassRecord : Form
    {       
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmClassRecord()
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

        private void GetDepartments()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(DepartmentId)[Department ID],RTRIM(ClassName)[Program],RTRIM(FacultyName)[Faculty] FROM Department order by DepartmentId", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Departments");
                dataGridView1.DataSource = myDataSet.Tables["Departments"].DefaultView;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Columns["Department ID"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CourseRecord_Load(object sender, EventArgs e)
        {
            GetDepartments();
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            this.Hide();
            frmCourse frm = new frmCourse();
            // or simply use column name instead of index
            dr.Cells["Department ID"].Value.ToString();
            frm.Show();
            frm.txtClassId.Visible = false;
            frm.label5.Visible = false;
            frm.txtClassId.Text = dr.Cells[0].Value.ToString();
            frm.txtClassName.Text = dr.Cells[1].Value.ToString();
            frm.txtFacultyName.Text = dr.Cells[2].Value.ToString();
 
            if (label1.Text == "Admin")
            {
                frm.btnDelete.Enabled = true;
                frm.btnUpdate_record.Enabled = true;
                frm.txtClassName.Focus();
                frm.label1.Text = label1.Text;
                frm.btnSave.Enabled = false;
            }
            else
            {
                frm.btnDelete.Enabled = false;
                frm.btnUpdate_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.txtClassName.Focus();
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

        private void frmClassRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmCourse frm = new frmCourse();
            frm.label1.Text = label1.Text;
            frm.Show();
        }
    }
}
