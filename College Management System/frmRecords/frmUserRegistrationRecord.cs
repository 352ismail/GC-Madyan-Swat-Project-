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
    public partial class frmUserRegistrationRecord : Form
    {

        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;

        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmUserRegistrationRecord()
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
        public DataView GetData()
        {
            dynamic SelectQry = "SELECT RTRIM(Username)[User Name],RTRIM(Password)[Password],RTRIM(Name)[Name],RTRIM(ContactNo)[Contact No.],RTRIM(Email)[Email],RTRIM(Dateofjoining)[Date Of Joining] FROM Users  INNER JOIN  Role On Role.RoleId = Users.RoleId where Role.Description = '"+usertype.Text.Trim()+"'";
            DataSet SampleSource = new DataSet();
            DataView TableView = null;
            try
            {
                SqlCommand SampleCommand = new SqlCommand();
                dynamic SampleDataAdapter = new SqlDataAdapter();
                SampleCommand.CommandText = SelectQry;
                SampleCommand.Connection = Connection;
                SampleDataAdapter.SelectCommand = SampleCommand;
                SampleDataAdapter.Fill(SampleSource);
                TableView = SampleSource.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return TableView;
        }
        private void frmRegisteredUsersDetails_Load(object sender, EventArgs e)
        {
            AutoCompleteUsers();
        }
        private void AutoCompleteUsers()
        {
            try
            {
                usertype.Items.Clear();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Description) from Role ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    usertype.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void usertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetData();
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
            frmUserRegistration frm = new frmUserRegistration();
            // or simply use column name instead of index
            dr.Cells["User Name"].Value.ToString();
            frm.Show();       
            frm.txtUsername.Text = dr.Cells[0].Value.ToString();
            frm.btnRegister.Enabled = false;
            if (label8.Text =="Admin")
            {
                frm.btnUpdate_record.Enabled = true;
                frm.btnDelete.Enabled = true;
            }
            else
            {
                frm.btnUpdate_record.Enabled = false;
                frm.btnDelete.Enabled = false;
            }
            frm.label8.Text = label8.Text.Trim();

        }

        private void frmUserRegistrationRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmUserRegistration frm = new frmUserRegistration();
            frm.label8.Text = label8.Text.Trim();
            frm.btnRegister.Enabled = true;
            frm.Show();

        }
    }
}
