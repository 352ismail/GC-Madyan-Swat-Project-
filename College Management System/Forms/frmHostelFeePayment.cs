using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace College_Management_System
{
    public partial class frmHostelFeePayment : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();


        public frmHostelFeePayment()
        {
            InitializeComponent();
        }

        private void Reset()
        {
           
            Delete.Enabled = false;
            Update_record.Enabled = false;
            Print.Enabled = false;
            cmbClassName.Text = "";
            cmbFaculty.Text = "";
            cmbSession.Text = "";
            cmbHostelName.Text = "";
            txtHostelFees.Text = "";
            CmbClassNo.Text = "";
            txtStudentName.Text = "";
            txtFatherName.Text = "";
            cmbYear.Text = "";
            PaymentDate.Text = DateTime.Today.ToString();
            cmbModeOfPayment.Text = "";
            txtFine.Text = "";
            txtTotalPaid.Text = "";
            txtDueFees.Text = "";
            btnSave.Enabled = true;          
            cmbClassName.Focus();
        }

        private void NewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validation
                if (cmbClassName.Text == "")
                {
                    MessageBox.Show("Please Select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClassName.Focus();
                    return;
                }
                if (cmbFaculty.Text == "")
                {
                    MessageBox.Show("Please Select  Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFaculty.Focus();
                    return;
                }

                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSession.Focus();
                    return;
                }
                if (cmbHostelName.Text == "")
                {
                    MessageBox.Show("Please select HostelName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbHostelName.Focus();
                    return;
                }
                if (txtHostelFees.Text == "")
                {
                    MessageBox.Show("Please select Hostel Fees", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHostelFees.Focus();
                    return;
                }
                if (CmbClassNo.Text == "")
                {
                    MessageBox.Show("Please select Class No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbClassNo.Focus();
                    return;
                }
                if (cmbYear.Text == "")
                {
                    MessageBox.Show("Please select Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbYear.Focus();
                    return;
                }
                if (cmbModeOfPayment.Text == "")
                {
                    MessageBox.Show("Please select Mode Of Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbModeOfPayment.Focus();
                    return;
                }

                if (txtTotalPaid.Text == "")
                {
                    MessageBox.Show("Please Enter Total Paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTotalPaid.Focus();
                    return;
                }
                #endregion
                #region Avoid Duplicate Values
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Year,HostelId,HostelerId from HostelFeePayment where Year= '" + cmbYear.Text.Trim() + "' and HostelId= (Select HostelId From Hostel where HostelName ='" + cmbHostelName.Text.Trim() + "') and HostelerId= (Select HostelerId From Hostelers where StudentId = (Select StudentId from Student where ClassNo = '" + CmbClassNo.Text.Trim() + "' AND DepartmentId = (Select DepartmentId From Department WHere ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "')AND SessionId = (Select SessionId From Session where Session.Description = '" + cmbSession.Text.Trim() + "')) and HostelId = (Select HostelId From Hostel where HostelName = '" + cmbHostelName.Text.Trim()+"'))";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Hostelfeepayment( Year,DateOfPayment,ModeOfPayment,TotalPaid,Fine,DueFee,HostelerId,HostelId,UserId) VALUES (@year,@dateofpayment,@modeofpayment,@totalpaid,@fine,@duefee,(Select HostelerId From Hostelers where StudentId = (Select StudentId from Student where ClassNo = '" + CmbClassNo.Text.Trim() + "' AND DepartmentId = (Select DepartmentId From Department WHere ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "')AND SessionId = (Select SessionId From Session where Session.Description = '" + cmbSession.Text.Trim() + "')) and HostelId = (Select HostelId From Hostel where HostelName = '" + cmbHostelName.Text.Trim() + "')),(Select HostelId From Hostel where HostelName ='" + cmbHostelName.Text.Trim() + "'),(Select UserId From Users where UserName = '"+label4.Text.Trim()+"'))";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@year", System.Data.SqlDbType.NVarChar, 50, "Year"));
                cmd.Parameters.Add(new SqlParameter("@dateofpayment", System.Data.SqlDbType.NVarChar, 50, "DateOfPayment"));            
                cmd.Parameters.Add(new SqlParameter("@modeofpayment", System.Data.SqlDbType.NVarChar, 50, "ModeOfPayment"));
                cmd.Parameters.Add(new SqlParameter("@totalpaid", System.Data.SqlDbType.Int, 10, "TotalPaid"));
                cmd.Parameters.Add(new SqlParameter("@fine", System.Data.SqlDbType.Int, 10, "Fine"));
                cmd.Parameters.Add(new SqlParameter("@duefee", System.Data.SqlDbType.Int, 10, "DueFee"));
                cmd.Parameters["@year"].Value = cmbYear.Text.Trim();
                cmd.Parameters["@dateofpayment"].Value = PaymentDate.Text.Trim();
                cmd.Parameters["@modeofpayment"].Value = (cmbModeOfPayment.Text.Trim());
                cmd.Parameters["@totalpaid"].Value = Convert.ToInt32(txtTotalPaid.Text.Trim());
                if (txtFine.Text == "")
                {
                    cmd.Parameters["@fine"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@fine"].Value = Convert.ToInt32(txtFine.Text.Trim());
                }

                if (txtDueFees.Text == "")
                {
                    cmd.Parameters["@duefee"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@duefee"].Value = Convert.ToInt32(txtDueFees.Text.Trim());
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);               
                Print.Enabled = true;
                con.Close();           

             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        private void frmHostelFeePayemt_Load(object sender, EventArgs e)
        {
         
            AutocompleClassName();
        }

     
        private void AutocompleClassName()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(ClassName) from Department";
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

        private void Update_record_Click(object sender, EventArgs e)
        {
            #region Validation
            if (cmbClassName.Text == "")
            {
                MessageBox.Show("Please Select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName.Focus();
                return;
            }
            if (cmbFaculty.Text == "")
            {
                MessageBox.Show("Please Select  Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFaculty.Focus();
                return;
            }

            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            if (cmbHostelName.Text == "")
            {
                MessageBox.Show("Please select HostelName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbHostelName.Focus();
                return;
            }
            if (txtHostelFees.Text == "")
            {
                MessageBox.Show("Please select Hostel Fees", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHostelFees.Focus();
                return;
            }
            if (CmbClassNo.Text == "")
            {
                MessageBox.Show("Please select Class No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CmbClassNo.Focus();
                return;
            }
            if (cmbYear.Text == "")
            {
                MessageBox.Show("Please select Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbYear.Focus();
                return;
            }
            if (cmbModeOfPayment.Text == "")
            {
                MessageBox.Show("Please select Mode Of Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbModeOfPayment.Focus();
                return;
            }

            if (txtTotalPaid.Text == "")
            {
                MessageBox.Show("Please Enter Total Paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTotalPaid.Focus();
                return;
            }
            #endregion
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update  Hostelfeepayment set DateOfPayment= @dateofpayment , ModeOfPayment= @modeofpayment , TotalPaid=@totalpaid , Fine=@fine , DueFee=@duefee , UserId=(Select UserId From Users where UserName = '" + label4.Text.Trim() + "') Where Year=@year AND HostelerId=(Select HostelerId From Hostelers where StudentId = (Select StudentId from Student where ClassNo = '" + CmbClassNo.Text.Trim() + "' AND DepartmentId = (Select DepartmentId From Department WHere ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "')AND SessionId = (Select SessionId From Session where Session.Description = '" + cmbSession.Text.Trim() + "')) and HostelId = (Select HostelId From Hostel where HostelName = '" + cmbHostelName.Text.Trim() + "')) AND HostelId=(Select HostelId From Hostel where HostelName ='" + cmbHostelName.Text.Trim() + "')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@year", System.Data.SqlDbType.NVarChar, 50, "Year"));
                cmd.Parameters.Add(new SqlParameter("@dateofpayment", System.Data.SqlDbType.NVarChar, 50, "DateOfPayment"));
                cmd.Parameters.Add(new SqlParameter("@modeofpayment", System.Data.SqlDbType.NVarChar, 50, "ModeOfPayment"));
                cmd.Parameters.Add(new SqlParameter("@totalpaid", System.Data.SqlDbType.Int, 10, "TotalPaid"));
                cmd.Parameters.Add(new SqlParameter("@fine", System.Data.SqlDbType.Int, 10, "Fine"));
                cmd.Parameters.Add(new SqlParameter("@duefee", System.Data.SqlDbType.Int, 10, "DueFee"));
                cmd.Parameters["@year"].Value = cmbYear.Text.Trim();
                cmd.Parameters["@dateofpayment"].Value = PaymentDate.Text.Trim();
                cmd.Parameters["@modeofpayment"].Value = (cmbModeOfPayment.Text.Trim());
                cmd.Parameters["@totalpaid"].Value = Convert.ToInt32(txtTotalPaid.Text.Trim());
                if (txtFine.Text == "")
                {
                    cmd.Parameters["@fine"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@fine"].Value = Convert.ToInt32(txtFine.Text.Trim());
                }

                if (txtDueFees.Text == "")
                {
                    cmd.Parameters["@duefee"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@duefee"].Value = Convert.ToInt32(txtDueFees.Text.Trim());
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated", "Fees Payment Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();


            }
        }

        private void delete_records()
        {

            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "Delete From HostelFeePayment where Year = '"+cmbYear.Text.Trim()+"' AND HostelerId = (Select HostelerId From Hostelers where StudentId = (Select StudentId from Student where ClassNo = '" + CmbClassNo.Text.Trim() + "' AND DepartmentId = (Select DepartmentId From Department WHere ClassName = '" + cmbClassName.Text.Trim() + "' AND FacultyName = '" + cmbFaculty.Text.Trim() + "')AND SessionId = (Select SessionId From Session where Session.Description = '" + cmbSession.Text.Trim() + "')) and HostelId = (Select HostelId From Hostel where HostelName = '" + cmbHostelName.Text.Trim() + "')) AND HostelId = (Select HostelId From Hostel where HostelName ='" + cmbHostelName.Text.Trim() + "')";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Delete.Enabled = false;
                    Reset();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
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
    
        private void ScholarNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
             
                CmbClassNo.Items.Clear();
                CmbClassNo.Text = "";
                CmbClassNo.Enabled = true;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "Select Rtrim(ClassNo) From Hostelers Inner JOIn Student On Student.StudentId = Hostelers.StudentId   INNER Join Department On Student.DepartmentId=Department.DepartmentId   INNER Join Session On Student.SessionId=Session.SessionId INNER Join Hostel On Hostel.HostelId = Hostelers.HostelId  where Hostel.HostelName = '" + cmbHostelName.Text.Trim() + "' ANd Department.ClassName = '" + cmbClassName.Text.Trim() + "' AnD Department.FacultyName = '" + cmbFaculty.Text.Trim() + "' ANd Session.Description = '" + cmbSession.Text.Trim()+"'";

                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        CmbClassNo.Items.Add(rdr[0]);
                    }
                    con.Close();

                            
                // Hostel Fees 
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "Select HostelFee From Hostel where HostelName = '" + cmbHostelName.Text.Trim() + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtHostelFees.Text = rdr.GetInt32(0).ToString();               
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

        private void TotalPaid_TextChanged(object sender, EventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int val3 = 0;
            int.TryParse(txtHostelFees.Text, out val1);
            int.TryParse(txtFine.Text, out val2);
            int.TryParse(txtTotalPaid.Text, out val3);
           
            int I = ((val1 + val2) - val3);

           txtDueFees.Text = I.ToString();

        }

        private void TotalPaid_Validating(object sender, CancelEventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int val3 = 0;
            int.TryParse(txtHostelFees.Text, out val1);
            int.TryParse(txtFine.Text, out val2);
            int.TryParse(txtTotalPaid.Text, out val3);
            if (val3 > val1 + val2)
            {
                MessageBox.Show("Total Paid can not be more than Hostel Fees + Fine", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTotalPaid.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void PrintRecord()
        {
            try
            {               
                frmReports.frmSingleStudentHostelFeePayement frm = new frmReports.frmSingleStudentHostelFeePayement();
                Reports.rptSingleStudentHostelFeePayment rpt = new Reports.rptSingleStudentHostelFeePayment();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSets.dstSingleStudentRecord myDS = new DataSets.dstSingleStudentRecord();
                //The DataSet you created.
                myConnection = new SqlConnection(cs.DBConn);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select * from HostelFeePayment  Inner JOin Hostelers On HostelFeePayment.HostelerId = Hostelers.HostelerId Inner JOin Student On Student.StudentId = Hostelers.StudentId INNER JOIN Department ON Department.DepartmentId = Student.DepartmentId INNER JOIN Session On Session.SessionId = Student.SessionId INNER JOIN Users On Users.UserId = HostelFeePayment.UserId INNER JOIN Hostel On Hostelers.HostelId = Hostel.HostelId   where Department.ClassName = '" + cmbClassName.Text.Trim() + "' AND Department.FacultyName = '" + cmbFaculty.Text.Trim() + "' AND Session.Description = '" + cmbSession.Text.Trim() + "' AND HostelFeePayment.Year = '" + cmbYear.Text.Trim() + "' AND Student.ClassNo = '" + CmbClassNo.Text.Trim() + "' AND Hostel.HostelName = '" + cmbHostelName.Text.Trim()+"'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "SingleStudentHostelFeePayment");
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
            try
            {

                #region Validation
                if (cmbClassName.Text == "")
                {
                    MessageBox.Show("Please Select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClassName.Focus();
                    return;
                }
                if (cmbFaculty.Text == "")
                {
                    MessageBox.Show("Please Select  Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFaculty.Focus();
                    return;
                }

                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSession.Focus();
                    return;
                }
                if (cmbHostelName.Text == "")
                {
                    MessageBox.Show("Please select HostelName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbHostelName.Focus();
                    return;
                }        
                if (CmbClassNo.Text == "")
                {
                    MessageBox.Show("Please select Class No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbClassNo.Focus();
                    return;
                }
                if (cmbYear.Text == "")
                {
                    MessageBox.Show("Please select Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbYear.Focus();
                    return;
                }
                #endregion
                PrintRecord();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

        private void frmHostelFeePayment_FormClosing(object sender, FormClosingEventArgs e)
        {
    
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            Print.Enabled = false;
            try
            {
                PaymentDate.Value = DateTime.Now;
                txtFine.Text = "";
                cmbModeOfPayment.Text = "";
                txtTotalPaid.Text = "";
                txtDueFees.Text = "";
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT DateOfPayment,ModeOfPayment,Fine,TotalPaid,DueFee FROM HostelFeePayment  Inner JOIn Hostel On Hostel.HostelId = HostelFeePayment.HostelId Inner JOIn Hostelers On Hostelers.HostelerId = HostelFeePayment.HostelerId Inner JOIn Student On Student.StudentId = Hostelers.StudentId Inner JOIn Department On Student.DepartmentId = Department.DepartmentId Inner JOIn Session On Student.SessionId = Session.SessionId where  Student.ClassNo= '" + CmbClassNo.Text.Trim() + "' AND   Department.ClassName = '" + cmbClassName.Text.Trim() + "' AnD Department.FacultyName = '" + cmbFaculty.Text.Trim() + "' ANd Session.Description = '" + cmbSession.Text.Trim()+ "' AND Year = '"+cmbYear.Text.Trim()+"' ";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    PaymentDate.Text = rdr.GetString(0).ToString();
                    cmbModeOfPayment.Text = rdr.GetString(1).ToString();
                    txtFine.Text = rdr.GetInt32(2).ToString();
                    txtTotalPaid.Text = rdr.GetInt32(3).ToString();
                    txtDueFees.Text = rdr.GetInt32(4).ToString();
                    Print.Enabled = true;
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void CmbClassNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Hostel Fees 
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "Select StudentName,FatherName From Hostelers Inner JOIn Student On Student.StudentId = Hostelers.StudentId Inner JOIn Department On Student.DepartmentId = Department.DepartmentId Inner JOIn Session On Student.SessionId = Session.SessionId where  Student.ClassNo= '" + CmbClassNo.Text.Trim() + "' AND   Department.ClassName = '" + cmbClassName.Text.Trim() + "' AnD Department.FacultyName = '" + cmbFaculty.Text.Trim() + "' ANd Session.Description = '" + cmbSession.Text.Trim()+"'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtStudentName.Text = rdr.GetString(0).ToString();
                    txtFatherName.Text = rdr.GetString(1).ToString();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFaculty.Items.Clear();
            cmbFaculty.Text = "";
            cmbFaculty.Enabled = true;

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(FacultyName) from Department where ClassName= '" + cmbClassName.Text + "'";
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

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Description) from Session ";
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

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbHostelName.Items.Clear();
            cmbHostelName.Text = "";
            cmbHostelName.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(HostelName) from Hostel";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbHostelName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRecords.frmHostelFeesPaymentRecord frm = new frmRecords.frmHostelFeesPaymentRecord();
            frm.label17.Text = label3.Text.Trim();
            frm.label18.Text = label4.Text.Trim();
            frm.Show();
        }

        private void cmbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void cmbModeOfPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtFine_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtTotalPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void cmbYear_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}