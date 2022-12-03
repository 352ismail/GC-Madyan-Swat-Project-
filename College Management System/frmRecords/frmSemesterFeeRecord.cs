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
    public partial class frmSemesterFeeRecord : Form
    {


        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;

        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();


        public frmSemesterFeeRecord()
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
            dynamic SelectQry = "Select RTRIM(SemesterFees.SemesterFeeId)[ID],RTRIM(Department.ClassName)[Class Name],Rtrim(Department.FacultyName)[Faculty],RTRIM(Semester.Description)[Semester],RTRIM(Semester.Season)[Season],RTRIM(SemesterFees.SemesterFee)[SemesterFee],RTRIM(SemesterFees.OtherFee)[OtherFee],RTRIM(SemesterFees.TotalFee)[TotalFee] from SemesterFees INNER JOIN Department On SemesterFees.DepartmentId = Department.DepartmentId INNER JOIN  Semester On SemesterFees.SemesterId = Semester.SemesterId ";
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
        private void FeesDetailsRecord_Load(object sender, EventArgs e)
        {
            AutocompleteClassName();
        
        }

        private void AutocompleteClassName()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(ClassName) from Department ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbClassName.Items.Add(rdr[0]);
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
            try
            {
                if (cmbClassName.Text == "")
                {
                    MessageBox.Show("Please select Class Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClassName.Focus();
                    return;
                }
                if (cmbFaculty.Text == "")
                {
                    MessageBox.Show("Please select Faculty Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFaculty.Focus();
                    return;
                }

                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                    this.Hide();
                    frmSemesterFee frm = new frmSemesterFee();
                    frm.Show();
                    frm.FeeID.Visible = false;
                    frm.lblFeeId.Visible = false;
                frm.cmbClassName.Text = cmbClassName.Text.Trim();
                    frm.cmbFacultyName.Text = cmbFaculty.Text.Trim();
                    frm.FeeID.Text = dr.Cells[0].Value.ToString();
                    frm.cmbSemester.Text = dr.Cells[1].Value.ToString();
                    frm.txtSeason.Text = dr.Cells[2].Value.ToString();
                    frm.SemesterFee.Text = dr.Cells[3].Value.ToString();
                    frm.OtherFees.Text = dr.Cells[4].Value.ToString();
                    if (label1.Text == "Admin")
                    {
                        frm.Delete.Enabled = true;
                        frm.Update_record.Enabled = true;
                        frm.btnSave.Enabled = false;
                        frm.label13.Text = label1.Text;
                    }
                    else
                    {
                        frm.Delete.Enabled = false;
                        frm.Update_record.Enabled = false;
                        frm.btnSave.Enabled = false;
                        frm.label13.Text = label1.Text;
                    }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmFeesDetailsRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmSemesterFee frm = new frmSemesterFee();
            frm.label13.Text = label1.Text;
            frm.Show();
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

        private void cmbClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFaculty.Items.Clear();
            cmbFaculty.Text = "";
            cmbFaculty.Enabled = true;
            cmbFaculty.Focus();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(FacultyName) from Department where ClassName = '" + cmbClassName.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbFaculty.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbClassName.Text == "")
                {
                    MessageBox.Show("Please select Class Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClassName.Focus();
                    return;
                }
                if (cmbFaculty.Text == "")
                {
                    MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFaculty.Focus();
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("Select RTRIM(SemesterFees.SemesterFeeId)[Semester Fee ID],RTRIM(Semester.Description)[Semester],RTRIM(Semester.Season)[Season],RTRIM(SemesterFees.SemesterFee)[SemesterFee],RTRIM(SemesterFees.OtherFee)[OtherFee],RTRIM(SemesterFees.TotalFee)[TotalFee] from SemesterFees INNER JOIN Department On SemesterFees.DepartmentId = Department.DepartmentId INNER JOIN  Semester On SemesterFees.SemesterId = Semester.SemesterId where ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "'Order By Semester.Description ", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "SemesterFee");
                dataGridView1.DataSource = myDataSet.Tables["SemesterFee"].DefaultView;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Columns["Semester Fee ID"].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            cmbClassName.Text = "";
            cmbFaculty.Text = "";
            dataGridView1.DataSource = null;
        }
    }
}
