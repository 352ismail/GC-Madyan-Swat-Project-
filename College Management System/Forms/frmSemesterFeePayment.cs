using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Security.Cryptography;
namespace College_Management_System
{
    public partial class frmSemesterFeePayment : Form
    {

        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();

        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();


        public frmSemesterFeePayment()
        {
            InitializeComponent();
        }
        private void frmSemesterFeePayment_Load(object sender, EventArgs e)
        {
            AutocompleClass();

        }
        private void AutocompleClass()
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
                    ClassName.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClassName_SelectedIndexChanged(object sender, EventArgs e)
        {

            FacultyName.Items.Clear();
            FacultyName.Text = "";
            FacultyName.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(FacultyName) from Department where ClassName = '" + ClassName.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    FacultyName.Items.Add(rdr[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void FacultyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSession.Items.Clear();
            cmbSession.Text = "";
            cmbSession.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Description) from Session where IsActive = 'true'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbSession.Items.Add(rdr[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSemseter.Items.Clear();
            cmbSemseter.Text = "";
            cmbSemseter.Enabled = true;
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
                    cmbSemseter.Items.Add(rdr[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetDGVData()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Student.Studentid[Id],RTRIM(ClassNo)[Class No],rtrim(StudentName)[Student Name],rtrim(Student.FatherName)[Father Name] ,(Select rtrim(TotalFee) from SemesterFees INNER JOIN Department On Department.DepartmentId = SemesterFees.DepartmentId INNER JOIN Semester On Semester.SemesterId = SemesterFees.SemesterId where Department.ClassName='" + ClassName.Text.Trim() + "' AND Department.FacultyName = '" + FacultyName.Text.Trim() + "' AND  Semester.Description='" + cmbSemseter.Text.Trim() + "')[Semester Fee] from Student Inner Join Department On Department.DepartmentId = Student.DepartmentId Inner Join Session On Session.SessionId = Student.SessionId  where Department.ClassName = '" + ClassName.Text.Trim() + "' AND Department.FacultyName = '" + FacultyName.Text.Trim() + "' AND Session.Description ='" + cmbSession.Text.Trim() + "'", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Student");
                dataGridView1.DataSource = myDataSet.Tables["Student"].DefaultView;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    if (!row.IsNewRow)
                    {
                        dataGridView1.Columns[0].Visible = true;
                        dataGridView1.Columns[1].Visible = true;
                        dataGridView1.Columns["Id"].Visible = false;
                        row.Cells[2].ReadOnly = true;
                        row.Cells[3].ReadOnly = true;
                        row.Cells[4].ReadOnly = true;
                        row.Cells[5].ReadOnly = true;
                        row.Cells[6].ReadOnly = true;
                    
                        row.Cells[0].Value = "Unpaid";

                        row.Cells[1].Value = DateTime.Now.ToShortDateString();
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct = "Select RTRIM(Status)[Status] from SemesterFeePayment INNER JOIN SemesterFees On SemesterFees.SemesterFeeId = SemesterFeePayment.SemesterFeeId INNER JOIN Student On Student.StudentId = SemesterFeePayment.StudentId INNER JOIN Department On Department.DepartmentId = SemesterFees.DepartmentId INNER JOIN Semester On Semester.SemesterId = SemesterFees.SemesterId where Department.ClassName='" + ClassName.Text.Trim() + "' AND Department.FacultyName = '" + FacultyName.Text.Trim() + "' AND  Semester.Description='" + cmbSemseter.Text.Trim() + "' AND Student.StudentId =  '" + row.Cells[2].Value + "' AND Student.StudentId = SemesterFeePayment.StudentId ";
                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            if (rdr.GetString(0) == "Paid")
                            {
                                row.Cells[0].Value = "Paid";
                            }
                            if (rdr.GetString(0) == "Unpaid")
                            {
                                row.Cells[0].Value = "Unpaid";
                            }
                        }
                        if ((rdr != null))
                        { rdr.Close(); }
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }


                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct2 = "Select RTRIM(DateOfPayment) from SemesterFeePayment INNER JOIN SemesterFees On SemesterFees.SemesterFeeId = SemesterFeePayment.SemesterFeeId INNER JOIN Student On Student.StudentId = SemesterFeePayment.StudentId INNER JOIN Department On Department.DepartmentId = SemesterFees.DepartmentId INNER JOIN Semester On Semester.SemesterId = SemesterFees.SemesterId where Department.ClassName='" + ClassName.Text.Trim() + "' AND Department.FacultyName = '" + FacultyName.Text.Trim() + "' AND  Semester.Description='" + cmbSemseter.Text.Trim() + "' AND Student.StudentId =  '" + row.Cells[2].Value + "' AND Student.StudentId = SemesterFeePayment.StudentId ";
                        cmd = new SqlCommand(ct2);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            row.Cells[1].Value = rdr.GetString(0);
                        }
                        if ((rdr != null))
                        { rdr.Close(); }
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetDGVData();
            if (label23.Text == "Admin")
            {
                Update_record.Enabled = true;
                Delete.Enabled = false;
            }
            else
            {
                Update_record.Enabled = false;
                Delete.Enabled = false;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {



            if (dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {

                    if (System.Text.RegularExpressions.Regex.IsMatch(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), @"(?:(?:31(-)(?:0?[13578]|1[0-2]|(?:Jan|Mar|May|Jul|Aug|Oct|Dec)))\1|(?:(?:29|30)(-)(?:0?[1,3-9]|1[0-2]|(?:Jan|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec))\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(-)(?:0?2|(?:Feb))\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(-)(?:(?:0?[1-9]|(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep))|(?:1[0-2]|(?:Oct|Nov|Dec)))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})"))
                    {


                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[1].Value = DateTime.Now.ToShortDateString();
                    }
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ClassName.Text == "")
            {
                MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClassName.Focus();
                return;
            }
            if (FacultyName.Text == "")
            {
                MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FacultyName.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbSemseter.Text == "")
            {
                MessageBox.Show("Please select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSemseter.Focus();
                return;
            }

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {

                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct = "select Distinct(SemesterFeeId),StudentId from SemesterFeePayment where SemesterFeeId =  '" + lblSemesterFeeId.Text.Trim() + "' And StudentId = '" + row.Cells[2].Value + "'  ";
                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read() == false)
                        {
                            // Save Record
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cb = "insert into SemesterFeePayment(DateOfPayment,Status,SemesterFeeId,StudentId) VALUES (@dateofpayment,@status,@semesterfeeid ,@studentid)";
                            cmd = new SqlCommand(cb);
                            cmd.Connection = con;
                            cmd.Parameters.Add(new SqlParameter("@dateofpayment", System.Data.SqlDbType.NVarChar, 50, "DateOfPayment"));
                            cmd.Parameters.Add(new SqlParameter("@status", System.Data.SqlDbType.NVarChar, 50, "Status"));
                            cmd.Parameters.Add(new SqlParameter("@semesterfeeid", System.Data.SqlDbType.Int, 10, "SemesterFeeId"));
                            cmd.Parameters.Add(new SqlParameter("@studentid", System.Data.SqlDbType.Int, 10, "StudentId"));
                            cmd.Parameters["@dateofpayment"].Value = row.Cells[1].Value;
                            cmd.Parameters["@status"].Value = row.Cells[0].Value;
                            cmd.Parameters["@semesterfeeid"].Value = Convert.ToInt32(lblSemesterFeeId.Text.Trim());
                            cmd.Parameters["@studentid"].Value = row.Cells[2].Value;
                            cmd.ExecuteNonQuery();
                            if ((rdr != null))
                            {
                                rdr.Close();
                            }

                        }
                    }
                }
                MessageBox.Show("Successfully saved", "Personal Ledger Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSemseter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get SemesterFeeId
            #region Get Department Id
            //Get Department Id
            lblSemesterFeeId.Text = "";
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string ct2 = "select SemesterFeeId from SemesterFees INNER JOIN Department On Department.DepartmentId = SemesterFees.DepartmentId INNER Join Semester On Semester.SemesterId = SemesterFees.SemesterId  where ClassName ='" + ClassName.Text.Trim() + "' and FacultyName = '" + FacultyName.Text.Trim() + "' AND Description= '" + cmbSemseter.Text.Trim() + "'";

            cmd = new SqlCommand(ct2);
            cmd.Connection = con;

            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {

                lblSemesterFeeId.Text = rdr.GetInt32(0).ToString();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            #endregion
            Print.Enabled = true;
        }




        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NewRecord_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (!row.IsNewRow)
                {
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                }
            }
            dataGridView1.DataSource = null;
            ClassName.Text = "";
            lblStudentId.Text = "";
            FacultyName.Text = "";
            cmbSession.Text = "";
            cmbSemseter.Text = "";
            if (label23.Text == "Admin")
            {
                Update_record.Enabled = false;
                Delete.Enabled = false;
            }
            else
            {
                Update_record.Enabled = false;
                Delete.Enabled = false;
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedCells == null)
            {
                MessageBox.Show("Select valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            // or simply use column name instead of index
            lblStudentId.Text = dr.Cells[2].Value.ToString();

            if (label23.Text == "Admin")
            {
                Delete.Enabled = true;         
                ClassName.Focus();
            }
            else
            {
                Delete.Enabled = false;            
                ClassName.Focus();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {

            if (ClassName.Text == "")
            {
                MessageBox.Show("Please Select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClassName.Focus();
                return;
            }
            if (FacultyName.Text == "")
            {
                MessageBox.Show("Please Select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FacultyName.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please Select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbSemseter.Text == "")
            {
                MessageBox.Show("Please Select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSemseter.Focus();
                return;
            }
            if (lblStudentId.Text == " ")
            {
                MessageBox.Show("Please select any Row ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.Focus();
                return;
            }

            if (MessageBox.Show("Do you really want to delete the records?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                {

                    delete_records();

                }
            }
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "Delete From SemesterFeePayment Where SemesterFeeId = (Select SemesterFeeId From SemesterFees Inner Join Department On Department.DepartmentId = SemesterFees.DepartmentId INNER JOIN Semester On Semester.SemesterId = SemesterFees.SemesterId where ClassName = '"+ClassName.Text.Trim()+"' ANd FacultyName = '"+FacultyName.Text.Trim()+"' AND Semester.Description = '"+cmbSemseter.Text.Trim()+"') AND StudentId = '"+lblStudentId.Text.Trim()+"'";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;

                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Delete.Enabled = false;
                    GetDGVData();

                    lblStudentId.Text = "";
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   Delete.Enabled = false;
                    GetDGVData();

                    lblStudentId.Text = "";

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

        private void Update_record_Click(object sender, EventArgs e)
        {
            if (ClassName.Text == "")
            {
                MessageBox.Show("Please Select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClassName.Focus();
                return;
            }
            if (FacultyName.Text == "")
            {
                MessageBox.Show("Please Select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FacultyName.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please Select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbSemseter.Text == "")
            {
                MessageBox.Show("Please Select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSemseter.Focus();
                return;
            }
            try
            {

                            // Update Record
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cb = "Update SemesterFeePayment set DateOfPayment =@dateofpayment ,Status  = @status where SemesterFeeId = @semesterfeeid AND StudentId = @studentid";
                            cmd = new SqlCommand(cb);
                            cmd.Connection = con;
                            cmd.Parameters.Add(new SqlParameter("@dateofpayment", System.Data.SqlDbType.NVarChar, 50, "DateOfPayment"));
                            cmd.Parameters.Add(new SqlParameter("@status", System.Data.SqlDbType.NVarChar, 50, "Status"));
                            cmd.Parameters.Add(new SqlParameter("@semesterfeeid", System.Data.SqlDbType.Int, 10, "SemesterFeeId"));
                            cmd.Parameters.Add(new SqlParameter("@studentid", System.Data.SqlDbType.Int, 10, "StudentId"));
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            { 
                            if (!row.IsNewRow)
                            {
                            cmd.Parameters["@dateofpayment"].Value = row.Cells[1].Value;
                            cmd.Parameters["@status"].Value = row.Cells[0].Value;
                            cmd.Parameters["@semesterfeeid"].Value = Convert.ToInt32(lblSemesterFeeId.Text.Trim());
                            cmd.Parameters["@studentid"].Value = row.Cells[2].Value;
                            cmd.ExecuteNonQuery();
                            if ((rdr != null))
                            {
                                rdr.Close();
                            }

                             }
                             }                
                             MessageBox.Show("Successfully Updated", "Personal Ledger Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRecords.frmSemesterFeePaymentRcd frm = new frmRecords.frmSemesterFeePaymentRcd();
            frm.label13.Text = label23.Text.Trim();
            frm.label14.Text = label24.Text.Trim();
            frm.Show();
        }

        private void PrintRecord()
        {
            try
            {

                timer2.Enabled = true;
                frmReports.frmSingleSemesterFeePaymentReport frm = new frmReports.frmSingleSemesterFeePaymentReport();
                Reports.rptSingleSemesterFeePayment rpt = new Reports.rptSingleSemesterFeePayment();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSets.dstSingleSemesterFeePayment myDS = new DataSets.dstSingleSemesterFeePayment();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select  * from SemesterFeePayment  Inner JOin Student On Student.StudentId = SemesterFeePayment.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN SemesterFees On SemesterFeePayment.SemesterFeeId = SemesterFees.SemesterFeeId INNER JOIN Semester ON Semester.SemesterId = SemesterFees.SemesterId  where Department.ClassName = '" + ClassName.Text.Trim() + "' AND Department.FacultyName = '" + FacultyName.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "' AND Semester.Description = '" + cmbSemseter.Text.Trim() + "'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "SingleSemesterFeePayment");
                rpt.SetDataSource(myDS);
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void Print_Click(object sender, EventArgs e)
        {
            #region Vaildation
            if (ClassName.Text == "")
            {
                MessageBox.Show("Please select Class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClassName.Focus();
                return;
            }
            if (FacultyName.Text == "")
            {
                MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FacultyName.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbSemseter.Text == "")
            {
                MessageBox.Show("Please select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSemseter.Focus();
                return;
            }
            #endregion
            PrintRecord();
        }
    }  
    }

