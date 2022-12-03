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
    public partial class frmBackUpAndRestore : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmBackUpAndRestore()
        {
            InitializeComponent();
        }

        private void frmBackUpAndRestore_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtBackup.Text = dlg.SelectedPath;
                btnBackup.Enabled = true;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                string database = con.Database.ToString();
                if (txtBackup.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter BackUp folder location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string cmd = "BACKUP DATABASE [" + database + "] TO DISK ='" + txtBackup.Text + "\\" + "CollegeManagementSystemBackUp" + "-" + DateTime.Now.ToString("dd/MM/yyyy--HH/mm/ss") + ".bak'";
                    con.Open();
                    SqlCommand command = new SqlCommand(cmd, con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("DataBase Backup Done Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    btnBackup.Enabled = false;
                }
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
  
        private void btnRestore_Click_1(object sender, EventArgs e)
        {
            if (txtRestore.Text == string.Empty)
            {
                MessageBox.Show("Please Select a file to restore", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    string database = con.Database.ToString();
                    con.Open();
                    string str1 = string.Format("ALTER DATABASE[" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE ");
                    SqlCommand cmd1 = new SqlCommand(str1, con);
                    cmd1.ExecuteNonQuery();
                    string str2 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK = '" + txtRestore.Text + "' WITH REPLACE ";
                    SqlCommand cmd2 = new SqlCommand(str2, con);
                    cmd2.ExecuteNonQuery();
                    string str3 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
                    SqlCommand cmd3 = new SqlCommand(str3, con);
                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("DataBase Successfully Restored", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnRestoreBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL Server database back up files|*.bak";
            dlg.Title = "Databse Restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtRestore.Text = dlg.FileName;
                btnRestore.Enabled = true;
            }
        }   
    }
}
