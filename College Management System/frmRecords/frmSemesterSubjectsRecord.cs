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

namespace College_Management_System.Forms
{
    public partial class frmSemesterSubjectsRecord : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
  
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmSemesterSubjectsRecord()
        {
            InitializeComponent();
        }

        private void frmSemesterSubjectsRecord_Load(object sender, EventArgs e)
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

        private void cmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSession.Items.Clear();
            cmbSession.Text = "";
            cmbSession.Enabled = true;
            cmbSession.Focus();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Description) from Session";
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

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validation
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
                if (cmbSemester.Text == "")
                {
                    MessageBox.Show("Please select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSemester.Focus();
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
                cmd = new SqlCommand("Select RTRIM(SubjectDetails.SubjectDetailsId)[Subject Details ID],RTRIM(Subject.SubjectCode)[Subject Code],Rtrim(Subject.SubjectName)[Subject Name],(Subject.CH)[CreditHours] from SubjectDetails INNER JOIN Subject On SubjectDetails.SubjectId = Subject.SubjectId INNER JOIN Department On SubjectDetails.DepartmentId = Department.DepartmentId INNER JOIN Session On SubjectDetails.SessionId = Session.SessionId INNER JOIN Semester On SubjectDetails.SemesterId = Semester.SemesterId  where Semester.Description = '" + cmbSemester.Text.Trim() + "' and Department.ClassName = '" + cmbClassName.Text.Trim() + "' and Department.FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Session.Description= '" + cmbSession.Text.Trim() + "' ", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "SubjectDetails");
                dataGridView1.DataSource = myDataSet.Tables["SubjectDetails"].DefaultView;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Columns["Subject Details ID"].Visible = false;
                }
                con.Close();
                //Count Subjects 
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("Select Count(Subject.SubjectName) from SubjectDetails INNER JOIN Subject On SubjectDetails.SubjectId = Subject.SubjectId INNER JOIN Department On SubjectDetails.DepartmentId = Department.DepartmentId INNER JOIN Session On SubjectDetails.SessionId = Session.SessionId INNER JOIN Semester On SubjectDetails.SemesterId = Semester.SemesterId  where Semester.Description = '" + cmbSemester.Text.Trim() + "' and Department.ClassName = '" + cmbClassName.Text.Trim() + "' and Department.FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Session.Description= '" + cmbSession.Text.Trim() + "' ", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    TotalSub.Text = rdr.GetInt32(0).ToString();
                    label5.Visible = true;
                    TotalSub.Visible = true;
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            this.Hide();
            #region Validation 
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
            if (cmbSemester.Text == "")
            {
                MessageBox.Show("Please select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSemester.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            #endregion
            frmSemesterSubjects frm = new frmSemesterSubjects();
            // or simply use column name instead of index
            dr.Cells["Subject Code"].Value.ToString();
            frm.Show();
            frm.txtSemesterSubjectId.Visible = false;
            frm.lblSemesterSubjectId.Visible = false;
            frm.cmbClassName.Text = cmbClassName.Text.Trim();
            frm.cmbFaculty.Text = cmbFaculty.Text.Trim();
            frm.cmbSession.Text = cmbSession.Text.Trim();
            frm.cmbSemester.Text = cmbSemester.Text.Trim();
            frm.txtSemesterSubjectId.Text = dr.Cells[0].Value.ToString();
            frm.txtSubjectCode.Text = dr.Cells[1].Value.ToString();
            frm.cmbSubjectName.Text = dr.Cells[2].Value.ToString();
            frm.txtcreditHour.Text = dr.Cells[3].Value.ToString();
            if (label6.Text == "Admin")
            {
                frm.Delete.Enabled = true;
                frm.Update_record.Enabled = true;
                frm.cmbSubjectName.Focus();
                frm.label3.Text = label6.Text;
                frm.btnSave.Enabled = false;
            }
            else
            {
                frm.Delete.Enabled = false;
                frm.Update_record.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.cmbSubjectName.Focus();
                frm.label3.Text = label6.Text;
            }
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSemester.Items.Clear();
            cmbSemester.Text = "";
            cmbSemester.Enabled = true;
            cmbSemester.Focus();

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();


                string ct = "select distinct RTRIM(Description) from Semester";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbSemester.Items.Add(rdr[0]);
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

        private void frmSemesterSubjectsRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmSemesterSubjects frm = new frmSemesterSubjects();
            frm.label3.Text = label6.Text;
            frm.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            cmbClassName.Text = "";
            cmbFaculty.Text = "";
            cmbSession.Text = "";
            cmbSemester.Text = "";
            TotalSub.Text = "0";
            TotalSub.Visible = false;
            label5.Visible = false;

            dataGridView1.DataSource = null;


        }
    }
}
