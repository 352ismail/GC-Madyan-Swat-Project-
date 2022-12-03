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
    public partial class frmSemesterFee : Form
    {

        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
       

        public frmSemesterFee()
        {
            InitializeComponent();
        }

        private void AutocompleClassName()
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




        private void FeesDetails_Load(object sender, EventArgs e)
        {
            AutocompleClassName();

         

        }

        private void btnSave_Click(object sender, EventArgs e)
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
                if (cmbFacultyName.Text == "")
                {
                    MessageBox.Show("Please select Faculty Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFacultyName.Focus();
                    return;
                }
                if (cmbSemester.Text == "")
                {
                    MessageBox.Show("Please select semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSemester.Focus();
                    return;
                }
                if (SemesterFee.Text == "")
                {
                    MessageBox.Show("Please Enter Semester Fee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SemesterFee.Focus();
                    return;
                }
                #endregion
                #region Avoid Duplicate Data
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select SemesterId,DepartmentId from SemesterFees where SemesterId= (Select SemesterId from Semester where Description = '" + cmbSemester.Text.Trim() + "') and DepartmentId = (Select DepartmentId From Department where Classname ='" + cmbClassName.Text.Trim() + "' and FacultyName = '" + cmbFacultyName.Text.Trim() + "')";
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
                string cb = "insert into SemesterFees(SemesterFee,OtherFee,TotalFee,SemesterId,DepartmentId) VALUES (@semesterfee,@otherfee,@totalfee,(Select SemesterId from Semester where Description = '" + cmbSemester.Text.Trim() + "'),(Select DepartmentId From Department where Classname ='" + cmbClassName.Text.Trim() + "' and FacultyName = '" + cmbFacultyName.Text.Trim() + "'))";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@semesterfee", System.Data.SqlDbType.NChar, 50, "SemesterFee"));
                cmd.Parameters.Add(new SqlParameter("@otherfee", System.Data.SqlDbType.NChar, 50, "OtherFee"));
                cmd.Parameters.Add(new SqlParameter("@totalfee", System.Data.SqlDbType.NChar, 30, "TotalFee"));
                if (SemesterFee.Text == "")
                {
                    cmd.Parameters["@semesterfee"].Value = "0";
                }
                else
                {
                    cmd.Parameters["@semesterfee"].Value = Convert.ToInt32(SemesterFee.Text);
                }
                //end if 
                if (OtherFees.Text == "")
                {
                    cmd.Parameters["@otherfee"].Value = "0";
                }
                else
                {
                    cmd.Parameters["@otherfee"].Value = Convert.ToInt32(OtherFees.Text);

                }
                //end if
                cmd.Parameters["@totalfee"].Value = Convert.ToInt32(TotalFees.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Fees Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     



        private void Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFacultyName.Items.Clear();
            cmbFacultyName.Text = "";
            cmbFacultyName.Enabled = true;
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
                    cmbFacultyName.Items.Add(rdr[0]);
                }
               
            }

          
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TutionFees_KeyPress(object sender, KeyPressEventArgs e)
        {


            try
            {





            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }



            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }



        }

        private void UDFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void LibraryFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void USFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void OtherFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }


        }

        private void CautionMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void NewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        
          
            
        }
        private void Reset()
        {
            cmbClassName.Focus();
            FeeID.Text = "";
            cmbClassName.Text = "";
            cmbFacultyName.Text = "";
            cmbSemester.Text = "";
            txtSeason.Text = "";
            SemesterFee.Text = "";
            OtherFees.Text = "";
            cmbFacultyName.Enabled = false;
            lblFeeId.Visible  = false;
            cmbSemester.Enabled = false;
            Delete.Enabled = false;
            Update_record.Enabled = false;
            btnSave.Enabled = true;
            FeeID.Visible = false;
        }

        private void Update_record_Click(object sender, EventArgs e)
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
                if (cmbFacultyName.Text == "")
                {
                    MessageBox.Show("Please select Faculty Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFacultyName.Focus();
                    return;
                }
                if (cmbSemester.Text == "")
                {
                    MessageBox.Show("Please select semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSemester.Focus();
                    return;
                }
                if (FeeID.Text == "")
                {
                    MessageBox.Show("Please select Fee ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FeeID.Focus();
                    return;
                }
                #endregion
                #region Avoid Duplicate Data
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select SemesterId,DepartmentId,SemesterFee,OtherFee,TotalFee from SemesterFees where SemesterId= (Select SemesterId from Semester where Description = '" + cmbSemester.Text.Trim() + "') and DepartmentId = (Select DepartmentId From Department where Classname ='" + cmbClassName.Text.Trim() + "' and FacultyName = '" + cmbFacultyName.Text.Trim() + "' AND SemesterFee = '"+SemesterFee.Text.Trim()+ "' AND OtherFee = '" + OtherFees.Text.Trim() + "' AND TotalFee = '" + TotalFees.Text.Trim() + "')";
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
                string cb = "Update SemesterFees  set SemesterFee= @semesterfee,OtherFee=@otherfee,TotalFee = @totalfee,SemesterId=(Select SemesterId From Semester where Description ='" + cmbSemester.Text.Trim() + "'),DepartmentId = (Select DepartmentId From Department where ClassName = '" + cmbClassName.Text.Trim() + "' and FacultyName = '" + cmbFacultyName.Text.Trim() + "') where SemesterFeeId = '" + FeeID.Text.Trim() + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@semesterfee", System.Data.SqlDbType.NChar, 10, "SemesterFee"));
                cmd.Parameters.Add(new SqlParameter("@otherfee", System.Data.SqlDbType.NChar, 10, "OtherFee"));
                cmd.Parameters.Add(new SqlParameter("@totalfee", System.Data.SqlDbType.NChar, 10, "TotalFee"));
                if (SemesterFee.Text == "")
                {
                    cmd.Parameters["@semesterfee"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@semesterfee"].Value = Convert.ToInt32(SemesterFee.Text);
                }//end if 
                if (OtherFees.Text == "")
                {
                    cmd.Parameters["@otherfee"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@otherfee"].Value = Convert.ToInt32(OtherFees.Text);
                }//end if 
                if (TotalFees.Text == "")
                {
                    cmd.Parameters["@totalfee"].Value = 0;
                }
                else
                {
                    cmd.Parameters["@totalfee"].Value = Convert.ToInt32(TotalFees.Text);
                }//end if 
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated", "Fees Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                //Check In  SemesterFee Payment Table 
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "Select Distinct(SemesterFeePayment.SemesterFeeId) From SemesterFeePayment  INNER JOIN SemesterFees ON SemesterFeePayment.SemesterFeeId=SemesterFees.SemesterFeeId INNER JOIN Semester ON Semester.SemesterId=SemesterFees.SemesterId  INNER JOIN Department ON Department.DepartmentId=SemesterFees.DepartmentId where  Semester.Description = '" + cmbSemester.Text.Trim() + "'  and Department.ClassName = '" + cmbClassName.Text.Trim() + "' AND Department.FacultyName ='" + cmbFacultyName.Text.Trim() + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from SemesterFees where SemesterFeeID=@semesterfeeid;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@semesterfeeid", System.Data.SqlDbType.Int, 20, "SemesterFeeID"));
                cmd.Parameters["@semesterfeeid"].Value = Convert.ToInt32(FeeID.Text.Trim());
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void GetDetails_Click(object sender, EventArgs e)
        {
            frmSemesterFeeRecord frm = new frmSemesterFeeRecord();
            this.Hide();
            Reset();
            frm.label1.Text = label13.Text;
            frm.Show();
        }

     

        private void button2_Click(object sender, EventArgs e)
        {
            frmSemesterFeeRecord frm = new frmSemesterFeeRecord();
            this.Hide();
            Reset();
            frm.label1.Text = label13.Text;
            frm.Show();
        }

      

        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        private void cmbFacultyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSemester.Items.Clear();
            cmbSemester.Text = "";
            cmbSemester.Enabled = true;
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();


                string SM= "select distinct RTRIM(Description) from Semester";

                cmd = new SqlCommand(SM);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbSemester.Items.Add(rdr[0]);
                }

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TutionFees_TextChanged(object sender, EventArgs e)
        {

            int val4 = 0;
            int val5 = 0;

            int.TryParse(SemesterFee.Text, out val4);
            int.TryParse(OtherFees.Text, out val5);

            int I = ((val4 + val5 ));
            TotalFees.Text = I.ToString();
        }

        private void LibraryFees_TextChanged(object sender, EventArgs e)
        {

            int val4 = 0;
            int val5 = 0;
            int.TryParse(SemesterFee.Text, out val4);
            int.TryParse(OtherFees.Text, out val5);
  
            int I = (( val4 + val5));
            TotalFees.Text = I.ToString();
        }

        private void OtherFees_TextChanged(object sender, EventArgs e)
        {

            int val4 = 0;
            int val5 = 0;

            int.TryParse(SemesterFee.Text, out val4);
            int.TryParse(OtherFees.Text, out val5);

            int I = ((val4 + val5));
            TotalFees.Text = I.ToString();
        }

        private void SemesterFee_TextChanged(object sender, EventArgs e)
        {

            int val4 = 0;
            int val5 = 0;
            int.TryParse(SemesterFee.Text, out val4);
            int.TryParse(OtherFees.Text, out val5);

            int I = ((val4 + val5));
            TotalFees.Text = I.ToString();
        }

        private void cmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "select Distinct RTRIM(Season) from Semester where Description = '" + cmbSemester.Text.Trim() + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    txtSeason.Text = rdr.GetString(0).Trim();
                }
                if ((rdr != null))
                { rdr.Close(); }
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
    }
      
    }

