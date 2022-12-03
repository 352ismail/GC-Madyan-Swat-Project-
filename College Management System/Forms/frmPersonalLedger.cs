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
    public partial class frmPersonalLedger : Form
    {

        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        ConnectionString cs = new ConnectionString();

        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        public frmPersonalLedger()
        {
            InitializeComponent();
        }

        private void frmPersonalLedger_Load(object sender, EventArgs e)
        {
            AutocompleClassName();

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

        private void cmbClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbFacultyName.Items.Clear();
                cmbFacultyName.Text = "";
                cmbFacultyName.Enabled = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(FacultyName) from Department where ClassName = '" + cmbClassName.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbFacultyName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFacultyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbSession.Items.Clear();
                cmbSession.Text = "";
                cmbSession.Enabled = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Description) from Session where IsActive = 'true' ";
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

        }
        private void GetData()
        {
            try
            {
                if (label1.Text == "Admin")
                {
                    btnUpdate_record.Enabled = true;

                }
                else
                {
                    btnUpdate_record.Enabled = false;
                }
                 


                if (cmbClassName.Text == "")
                {
                    MessageBox.Show("Please select Class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClassName.Focus();
                    return;
                }
                if (cmbFacultyName.Text == "")
                {
                    MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFacultyName.Focus();
                    return;
                }
                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSession.Focus();
                    return;
                }

                if (rdbFirstandSecond.Checked == false && rdbThirdandFourth.Checked == false && rdbFifthandsixth.Checked == false && rdbSeventhandEigth.Checked == false && rdbFirstYear.Checked == false && rdbSecondYear.Checked == false)
                {
                    MessageBox.Show("Please select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSession.Focus();
                    return;
                }
                string Semester = "";
                if (rdbFirstandSecond.Checked == true)
                {
                    Semester = "First and Second";
                }
                else if (rdbThirdandFourth.Checked == true)
                {
                    Semester = "Third and Fourth";
                }
                else if (rdbFifthandsixth.Checked == true)
                {
                    Semester = "Fifth and Sixth";
                }
                else if (rdbSeventhandEigth.Checked == true)
                {
                    Semester = "Seventh and Eighth";
                }
                else if (rdbFirstYear.Checked == true)
                {
                    Semester = "First Year";
                }
                else if (rdbSecondYear.Checked == true)
                {
                    Semester = "Second Year";
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select Student.Studentid[Id],RTRIM(ClassNo)[Class No],rtrim(StudentName)[Student Name],rtrim(FatherName)[Father Name],(Select rtrim(RecieptNo)from PersonalLedger WHERE Student.StudentId = PersonalLedger.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFacultyName.Text.Trim() + "') and Session.SessionId = (Select SessionId From Session where Session.Description = '" + cmbSession.Text.Trim() + "' and Semester = '" + Semester + "'))[RecieptNo],(Select rtrim(GF)from PersonalLedger WHERE Student.StudentId = PersonalLedger.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFacultyName.Text.Trim() + "') and Session.SessionId = (Select SessionId From Session where Session.Description = '" + cmbSession.Text.Trim() + "' and Semester = '" + Semester + "'))[GF],(Select rtrim(PF)from PersonalLedger WHERE Student.StudentId = PersonalLedger.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFacultyName.Text.Trim() + "') and Session.SessionId = (Select SessionId From Session where Session.Description = '" + cmbSession.Text.Trim() + "' and Semester = '" + Semester + "'))[PF],(Select rtrim(Security)from PersonalLedger WHERE Student.StudentId = PersonalLedger.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFacultyName.Text.Trim() + "') and Session.SessionId = (Select SessionId From Session where Session.Description = '" + cmbSession.Text.Trim() + "' and Semester = '" + Semester + "'))[Security],(Select rtrim(FineReciept)from PersonalLedger WHERE Student.StudentId = PersonalLedger.StudentId and Student.DepartmentId = (Select DepartmentId From Department Where Department.ClassName = '" + cmbClassName.Text.Trim() + "'and FacultyName = '" + cmbFacultyName.Text.Trim() + "') and Session.SessionId = (Select SessionId From Session where Session.Description = '" + cmbSession.Text.Trim() + "' and Semester = '" + Semester + "'))[Fine] from Student INNER JOIN Department On Department.DepartmentId= Student.DepartmentId INNER JOIN Session On Session.SessionId= Student.SessionId where  className = '" + cmbClassName.Text.Trim() + "' and FacultyName = '" + cmbFacultyName.Text.Trim() + "' and  Description = '" + cmbSession.Text.Trim() + "'", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "PersonalLedger");
                dataGridView1.DataSource = myDataSet.Tables["PersonalLedger"].DefaultView;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        dataGridView1.Columns["Id"].Visible = false;
                        row.Cells[0].ReadOnly = true;
                        row.Cells[1].ReadOnly = true;
                        row.Cells[2].ReadOnly = true;
                        row.Cells[3].ReadOnly = true;

                    }
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
            GetData();
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            lblStudentIdDlt.Text = "";
            cmbClassName.Text = "";
            cmbFacultyName.Text = "";
            cmbSession.Text = "";
            DateOfReciept.Text = DateTime.Now.ToString();
            dataGridView1.DataSource = null;
            btnSave.Enabled = true;
            btnGetDetails.Enabled = true;
            btnUpdate_record.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbClassName.Text == "")
            {
                MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName.Focus();
                return;
            }
            if (cmbFacultyName.Text == "")
            {
                MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFacultyName.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }

            if (rdbFirstandSecond.Checked == false && rdbThirdandFourth.Checked == false && rdbFifthandsixth.Checked == false && rdbSeventhandEigth.Checked == false && rdbFirstYear.Checked == false && rdbSecondYear.Checked == false)
            {
                MessageBox.Show("Please select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            string Semester = "";
            if (rdbFirstandSecond.Checked == true)
            {
                Semester = "First and Second";
            }
            else if (rdbThirdandFourth.Checked == true)
            {
                Semester = "Third and Fourth";
            }
            else if (rdbFifthandsixth.Checked == true)
            {
                Semester = "Fifth and Sixth";
            }
            else if (rdbSeventhandEigth.Checked == true)
            {
                Semester = "Seventh and Eighth";
            }
            else if (rdbFirstYear.Checked == true)
            {
                Semester = "First Year";
            }
            else if (rdbSecondYear.Checked == true)
            {
                Semester = "Second Year";
            }
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        #region Avoid Duplicate Data
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct = "Select StudentId ,Semester From PersonalLedger where Studentid= '" + row.Cells[0].Value + "' AND Semester = '" + Semester + "' ";
                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read() == false)
                        {
                            // Save Record
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cb = "insert into PersonalLedger(RecieptNo,Date,GF,PF,Security,FineReciept,Semester,StudentId) VALUES (@recieptno,@date,@gf,@pf,@security,@finereciept,@semester,@studentid)";
                            cmd = new SqlCommand(cb);
                            cmd.Connection = con;
                            cmd.Parameters.Add(new SqlParameter("@date", System.Data.SqlDbType.NVarChar, 50, "Date"));
                            cmd.Parameters.Add(new SqlParameter("@semester", System.Data.SqlDbType.NVarChar, 50, "Semester"));
                            cmd.Parameters.Add(new SqlParameter("@recieptno", System.Data.SqlDbType.NVarChar, 50, "RecieptNo"));
                            cmd.Parameters.Add(new SqlParameter("@gf", System.Data.SqlDbType.Int, 10, "GF"));
                            cmd.Parameters.Add(new SqlParameter("@pf", System.Data.SqlDbType.Int, 10, "PF"));
                            cmd.Parameters.Add(new SqlParameter("@security", System.Data.SqlDbType.Int, 10, "Security"));
                            cmd.Parameters.Add(new SqlParameter("@finereciept", System.Data.SqlDbType.Int, 10, "FineReciept"));
                            cmd.Parameters.Add(new SqlParameter("@studentid", System.Data.SqlDbType.Int, 50, "StudentId"));
                            cmd.Parameters["@date"].Value = DateOfReciept.Text.Trim();
                            cmd.Parameters["@semester"].Value = Semester.Trim();
                            cmd.Parameters["@studentid"].Value = row.Cells[0].Value;
                            cmd.Parameters["@recieptno"].Value = row.Cells[4].Value;
                            cmd.Parameters["@gf"].Value = row.Cells[5].Value;
                            cmd.Parameters["@pf"].Value = row.Cells[6].Value;
                            cmd.Parameters["@security"].Value = row.Cells[7].Value;
                            cmd.Parameters["@finereciept"].Value = row.Cells[8].Value;
                            cmd.ExecuteNonQuery();
                            con.Close();                                                 
                            if ((rdr != null))
                            {
                                rdr.Close();
                            }
                           
                        }
                        #endregion
                    }
                }
                MessageBox.Show("Successfully saved", "Personal Ledger Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            
            
            
            //REciept No
            if (dataGridView1.CurrentCell.ColumnIndex == 4)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[4].Value != null)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(), @"^[0-9]*?$"))
                    {

                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[4].Value = 0;
                    }
                }

            }
            //End Reciept No
            //GF
            if (dataGridView1.CurrentCell.ColumnIndex == 5)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[5].Value != null)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(), @"^[0-9]*?$"))
                    {

                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[5].Value = 0;
                    }
                }

            }
            //End GF
            //PF
            if (dataGridView1.CurrentCell.ColumnIndex == 6)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(), @"^[0-9]*?$"))
                    {

                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[6].Value = 0;
                    }
                }

            }
            //End PF
            //Security
            if (dataGridView1.CurrentCell.ColumnIndex == 7)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[7].Value != null)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString(), @"^[0-9]*?$"))
                    {

                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[7].Value = 0;
                    }
                }

            }
            //End Security
            //Fine
            if (dataGridView1.CurrentCell.ColumnIndex == 8)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[8].Value != null)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString(), @"^[0-9]*?$"))
                    {

                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[8].Value = 0;
                    }
                }

            }
            //End Fine


            dataGridView1.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            if (cmbClassName.Text == "")
            {
                MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName.Focus();
                return;
            }
            if (cmbFacultyName.Text == "")
            {
                MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFacultyName.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }

            if (rdbFirstandSecond.Checked == false && rdbThirdandFourth.Checked == false && rdbFifthandsixth.Checked == false && rdbSeventhandEigth.Checked == false && rdbFirstYear.Checked == false && rdbSecondYear.Checked == false)
            {
                MessageBox.Show("Please select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            string Semester = "";
            if (rdbFirstandSecond.Checked == true)
            {
                Semester = "First and Second";
            }
            else if (rdbThirdandFourth.Checked == true)
            {
                Semester = "Third and Fourth";
            }
            else if (rdbFifthandsixth.Checked == true)
            {
                Semester = "Fifth and Sixth";
            }
            else if (rdbSeventhandEigth.Checked == true)
            {
                Semester = "Seventh and Eighth";
            }
            else if (rdbFirstYear.Checked == true)
            {
                Semester = "First Year";
            }
            else if (rdbSecondYear.Checked == true)
            {
                Semester = "Second Year";
            }
            try
            {
             
                        // Update Record
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "Update PersonalLedger set RecieptNo=@recieptno , Date=@date , GF=@gf , PF=@pf , Security=@security , FineReciept=@finereciept where  Semester= @semester AND StudentId=@studentid ";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@date", System.Data.SqlDbType.NVarChar, 50, "Date"));
                        cmd.Parameters.Add(new SqlParameter("@semester", System.Data.SqlDbType.NVarChar, 50, "Semester"));
                        cmd.Parameters.Add(new SqlParameter("@recieptno", System.Data.SqlDbType.NVarChar, 50, "RecieptNo"));
                        cmd.Parameters.Add(new SqlParameter("@gf", System.Data.SqlDbType.Int, 10, "GF"));
                        cmd.Parameters.Add(new SqlParameter("@pf", System.Data.SqlDbType.Int, 10, "PF"));
                        cmd.Parameters.Add(new SqlParameter("@security", System.Data.SqlDbType.Int, 10, "Security"));
                        cmd.Parameters.Add(new SqlParameter("@finereciept", System.Data.SqlDbType.Int, 10, "FineReciept"));
                        cmd.Parameters.Add(new SqlParameter("@studentid", System.Data.SqlDbType.Int, 50, "StudentId"));
                        //prepare Command 
                        cmd.Prepare();
                       // Data to be inserted
                       foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                        if (!row.IsNewRow)
                        {
                        cmd.Parameters["@date"].Value = DateOfReciept.Text.Trim();
                        cmd.Parameters["@semester"].Value = Semester.Trim();
                        cmd.Parameters["@studentid"].Value = row.Cells[0].Value;
                        cmd.Parameters["@recieptno"].Value = row.Cells[4].Value;
                        cmd.Parameters["@gf"].Value = row.Cells[5].Value;
                        cmd.Parameters["@pf"].Value = row.Cells[6].Value;
                        cmd.Parameters["@security"].Value = row.Cells[7].Value;
                        cmd.Parameters["@finereciept"].Value = row.Cells[8].Value;
                        cmd.ExecuteNonQuery();
                        }
                        }
                       MessageBox.Show("Successfully Updated", "Personal Ledger Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       GetData();
                        con.Close();
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            lblStudentIdDlt.Text = dr.Cells[0].Value.ToString();

            if (label1.Text == "Admin")
            {
                btnDelete.Enabled = true;             
                cmbClassName.Focus();
            }
            else
            {
                btnDelete.Enabled = false;              
                cmbClassName.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblStudentIdDlt.Text == "")
            {
                MessageBox.Show("Please select Any Row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.Focus();
                return;
            }
            if (cmbClassName.Text == "")
            {
                MessageBox.Show("Please select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClassName.Focus();
                return;
            }
            if (cmbFacultyName.Text == "")
            {
                MessageBox.Show("Please select Faculty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFacultyName.Focus();
                return;
            }
            if (cmbSession.Text == "")
            {
                MessageBox.Show("Please select Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }

            if (rdbFirstandSecond.Checked == false && rdbThirdandFourth.Checked == false && rdbFifthandsixth.Checked == false && rdbSeventhandEigth.Checked == false && rdbFirstYear.Checked == false && rdbSecondYear.Checked == false)
            {
                MessageBox.Show("Please select Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSession.Focus();
                return;
            }
            string Semester = "";
            if (rdbFirstandSecond.Checked == true)
            {
                Semester = "First and Second";
            }
            else if (rdbThirdandFourth.Checked == true)
            {
                Semester = "Third and Fourth";
            }
            else if (rdbFifthandsixth.Checked == true)
            {
                Semester = "Fifth and Sixth";
            }
            else if (rdbSeventhandEigth.Checked == true)
            {
                Semester = "Seventh and Eighth";
            }
            else if (rdbFirstYear.Checked == true)
            {
                Semester = "First Year";
            }
            else if (rdbSecondYear.Checked == true)
            {
                Semester = "Second Year";
            }
            if (MessageBox.Show("Do you really want to delete the records?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    int RowsAffected = 0;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cq = "Delete From PersonalLedger where Semester = '"+Semester+"' AND StudentId = '"+lblStudentIdDlt.Text.Trim()+"'";
                    cmd = new SqlCommand(cq);
                    cmd.Connection = con;
                    RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblStudentIdDlt.Text = "";
                        btnDelete.Enabled = false;
                        GetData();
                    }
                    else
                    {
                        MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblStudentIdDlt.Text = "";
                        btnDelete.Enabled = false;
                        GetData();



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
        }

        private void btnGetDetails_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPersonalLedgerRecord frm = new frmPersonalLedgerRecord();
            frm.label5.Text = label1.Text.Trim();
            frm.Show();
        }
    }
}
