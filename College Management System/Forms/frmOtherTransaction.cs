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
    public partial class frmOtherTransaction : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        public String str;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();


        public frmOtherTransaction()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtTransactionID.Text = "";
            txtTransactionID.Visible = false;
            txtdes.Text = "";
            txtamt.Text = "";
            dtp.Text = DateTime.Today.ToString();
            rbcredit.Checked = false;
            rbdebit.Checked = false;
            btnSave.Enabled = true;
            Delete.Enabled = false;
            Update_record.Enabled = false;

        }

        private void NewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void frmOtherTransaction_Load(object sender, EventArgs e)
        {
            rbcredit.Checked = false;
            rbdebit.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (txtamt.Text == "")
            {
                MessageBox.Show("Please enter amount ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtamt.Focus();
                return;
            }
            if (txtdes.Text == "")
            {
                MessageBox.Show("Please enter Description ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdes.Focus();
                return;
            }
            if (rbcredit.Checked == false && rbdebit.Checked == false)
            {
                MessageBox.Show("Please Select Type Of Transaction ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rbcredit.Focus();
                return;
            }


            try
            {
                if (rbdebit.Checked)
                {
                    str = rbdebit.Text;
                }
                if (rbcredit.Checked)
                {
                    str = rbcredit.Text;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into OtherTransaction(TransactionType,Date,Amount,Description,UserId) VALUES (@transactiontype,@date,@amount,@description,(Select UserId From Users where UserName = '" + label6.Text.Trim() + "'))";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@transactiontype", System.Data.SqlDbType.NChar, 10, "TransactionType"));
                cmd.Parameters.Add(new SqlParameter("@date", System.Data.SqlDbType.NChar, 30, "Date"));
                cmd.Parameters.Add(new SqlParameter("@amount", System.Data.SqlDbType.NChar, 10, "Amount"));
                cmd.Parameters.Add(new SqlParameter("@description", System.Data.SqlDbType.VarChar, 400, "Description"));
                cmd.Parameters["@transactiontype"].Value = str;
                cmd.Parameters["@date"].Value = dtp.Text;
                cmd.Parameters["@amount"].Value = txtamt.Text;
                cmd.Parameters["@description"].Value = txtdes.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Update_record_Click(object sender, EventArgs e)
        {

            if (txtTransactionID.Text == "")
            {
                MessageBox.Show("Please Select Record ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTransactionID.Focus();
                return;
            }

            try
            {
                if (rbdebit.Checked)
                {
                    str = rbdebit.Text;
                }
                if (rbcredit.Checked)
                {
                    str = rbcredit.Text;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update OtherTransaction set TransactionType=@transactiontype , Date=@date , Amount=@amount , Description=@description , UserId = (Select UserId From Users where UserName = '" + label6.Text.Trim() + "') where TransactionId = @transactionid ";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@transactionid", System.Data.SqlDbType.NChar, 10, "TransactionId"));
                cmd.Parameters.Add(new SqlParameter("@transactiontype", System.Data.SqlDbType.NChar, 10, "TransactionType"));
                cmd.Parameters.Add(new SqlParameter("@date", System.Data.SqlDbType.NChar, 30, "Date"));
                cmd.Parameters.Add(new SqlParameter("@amount", System.Data.SqlDbType.NChar, 10, "Amount"));
                cmd.Parameters.Add(new SqlParameter("@description", System.Data.SqlDbType.VarChar, 400, "Description"));
                cmd.Parameters["@transactionid"].Value = Convert.ToInt32(txtTransactionID.Text.Trim());
                cmd.Parameters["@transactiontype"].Value = str;
                cmd.Parameters["@date"].Value = dtp.Text.Trim();
                cmd.Parameters["@amount"].Value = txtamt.Text.Trim();
                cmd.Parameters["@description"].Value = txtdes.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated", "Transaction Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (txtTransactionID.Text == "")
            {
                MessageBox.Show("Please Select Record ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTransactionID.Focus();
                return;
            }
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
                string cq = "delete from othertransaction where transactionid=@transactionid;";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@transactionid", System.Data.SqlDbType.Int, 10, "TransactionID"));
                cmd.Parameters["@transactionid"].Value = Convert.ToInt32(txtTransactionID.Text);
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

 

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmOtherTransactionRecord frm = new frmOtherTransactionRecord();
            frm.label1.Text = label4.Text;
            frm.label2.Text = label6.Text;
            frm.Show();
        }

        private void txtamt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void rbcredit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtdes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {

        }
    }
    }

