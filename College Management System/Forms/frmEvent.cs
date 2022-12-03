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
    public partial class frmEvent : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;       
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmEvent()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            txtEventID.Text = "";
            EventName.Text = "";
            StartingDate.Text = System.DateTime.Today.ToString();
            StartingTime.Text = System.DateTime.Now.TimeOfDay.ToString();
            EndingDate.Text = System.DateTime.Today.ToString();
            EndingTime.Text = System.DateTime.Now.TimeOfDay.ToString();
            Activities.Text = "";
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            txtEventID.Visible =false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void frmEvent_Load(object sender, EventArgs e)
        {
         
            Autocomplete();
         
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Validation 
            if (EventName.Text == "")
            {
                MessageBox.Show("Please enter Event name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EventName.Focus();
                return;
            }
            if (Activities.Text == "")
            {
                MessageBox.Show("Please Enter Activities in the Event", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Activities.Focus();
                return;
            }
            #endregion
            try
            {
                #region Avoid Duplicate
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select EventName,StartingDate,StartingTime from Event where EventName= '" + EventName.Text + "'and StartingDate='"+StartingDate.Text+"' and StartingTime = '"+StartingTime.Text+"'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Event Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EventName.Text = "";
                    EventName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                #endregion

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Event(EventName,StartingDate,StartingTime,EndingDate,EndingTime,Activities) VALUES ('" + EventName.Text + "','" + StartingDate.Text + "','" + StartingTime.Text + "','" + EndingDate.Text + "','" + EndingTime.Text + "','" + Activities.Text + "')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Autocomplete();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Autocomplete()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT distinct EventName FROM Event", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Event");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["EventName"].ToString());

                }
                EventName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                EventName.AutoCompleteCustomSource = col;
                EventName.AutoCompleteMode = AutoCompleteMode.Suggest;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validation 
                if (txtEventID.Text == "")
                {
                    MessageBox.Show("Please enter Event Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEventID.Focus();
                    return;
                }
                if (EventName.Text == "")
                {
                    MessageBox.Show("Please enter Event name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EventName.Focus();
                    return;
                }
                if (Activities.Text == "")
                {
                    MessageBox.Show("Please Enter Activities in the Event", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Activities.Focus();
                    return;
                }
                #endregion

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update Event set  Eventname= @eventname , StartingDate= @startingdate , StartingTime= @startingtime , EndingDate= @endingdate , EndingTime = @endingtime  , Activities= @activities   where EventId =@eventid ";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@eventname", System.Data.SqlDbType.VarChar, 150, "EventName"));
                cmd.Parameters.Add(new SqlParameter("@startingdate", System.Data.SqlDbType.NChar, 50, "StartingDate"));
                cmd.Parameters.Add(new SqlParameter("@startingtime", System.Data.SqlDbType.NChar, 50, "StartingTime"));
                cmd.Parameters.Add(new SqlParameter("@endingdate", System.Data.SqlDbType.NChar, 50, "EndingDate"));
                cmd.Parameters.Add(new SqlParameter("@endingtime", System.Data.SqlDbType.NChar, 50, "EndingTime")); 
                cmd.Parameters.Add(new SqlParameter("@activities", System.Data.SqlDbType.Text, 1000, "Activities"));
                cmd.Parameters.Add(new SqlParameter("@eventid", System.Data.SqlDbType.Int, 10, "Activities"));
                cmd.Parameters["@eventname"].Value = EventName.Text;
                cmd.Parameters["@startingdate"].Value = StartingDate.Text;
                cmd.Parameters["@startingtime"].Value = StartingTime.Text;
                cmd.Parameters["@endingdate"].Value = EndingDate.Text;
                cmd.Parameters["@endingtime"].Value = EndingTime.Text;
                cmd.Parameters["@activities"].Value = Activities.Text;             
                cmd.Parameters["@eventid"].Value = Convert.ToInt32(txtEventID.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated", "Event Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Autocomplete();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtEventID.Text == "")
            {
                MessageBox.Show("Please enter Event Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEventID.Focus();
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

                    #region Check in tables 
                //Check In Event Managed By Table
                con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "Select Distinct (EventManagedBy.EventId)  From EventManagedBy INNER JOIN Event On Event.EventId= EventManagedBy.EventId  where  Event.EventName = '" + EventName.Text.Trim() + "' and Event.StartingDate= '" + StartingDate.Text.Trim() + "' AND Event.StartingTime = '"+StartingTime.Text.Trim()+"'";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Reset();
                        Autocomplete();
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;
                    }
                #endregion

                   //delete Records
                   con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cq = "delete from Event where EventId= '" + txtEventID.Text + "'";
                    cmd = new SqlCommand(cq);
                    cmd.Connection = con;
                    RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                        Autocomplete();
                    }
                    else
                    {
                        MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                        Autocomplete();
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
            frmRecords. frmEventsRecord form2 = new frmRecords.frmEventsRecord();
            form2.label1.Text = label6.Text;
            form2.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
  
        }

        private void EventName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void Activities_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void EventName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}