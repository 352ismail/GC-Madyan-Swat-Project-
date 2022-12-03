using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace College_Management_System
{
    public partial class frmGPACalculator : Form
    {
        double gpa1=0;
        double gpa2=0;
        double gpa3=0;
        double gpa4=0;
        double gpa5=0;
        double gpa6=0;
        int val1 = 0;
        int val2 = 0;
        int val3 = 0;
        int val4 = 0;
        int val5 = 0;
        int val6 = 0;

        public frmGPACalculator()
        {
            InitializeComponent();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double GP = gpa1+gpa2+gpa3+gpa4+gpa5+gpa6;
             val1 = 0;
             val2 = 0;
             val3 = 0;
             val4 = 0;
             val5 = 0;
             val6 = 0;
            int.TryParse(CH1.Text, out val1);
            int.TryParse(CH2.Text, out val2);
            int.TryParse(CH3.Text, out val3);
            int.TryParse(CH4.Text, out val4);
            int.TryParse(CH5.Text, out val5);
            int.TryParse(CH6.Text, out val6);
            int sumOfCH = val1 + val2 + val3 + val4 + val5 + val6;
            double GPASemester =( GP / sumOfCH);
            GPA.Text = Math.Round(GPASemester,2).ToString();
        }

        private void txtSub1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
         
          
        }

        private void txtSub2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtSub3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtSub4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtSub5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtSub6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void CH1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void CH2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void CH3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void CH4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void CH5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void CH6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtSub1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSub1.Text == "")
                {

                }
              
               else if (int.Parse(txtSub1.Text) > 100)
                {
                
                    txtSub1.Text = "100";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void txtSub2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSub2.Text == "")
                {

                }
                else if (int.Parse(txtSub2.Text) > 100)
                {
               
                    txtSub2.Text = "100";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void txtSub3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSub3.Text == "")
                {

                }
                else if (int.Parse(txtSub3.Text) > 100)
                {
                 
                    txtSub3.Text = "100";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void txtSub4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSub4.Text == "")
                {

                }
                else if (int.Parse(txtSub4.Text) > 100)
                {
                
                    txtSub4.Text = "100";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void txtSub5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSub5.Text == "")
                {

                }
                else if (int.Parse(txtSub5.Text) > 100)
                {
                 
                    txtSub5.Text = "100";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void txtSub6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSub6.Text == "")
                {

                }
                else if (int.Parse(txtSub6.Text) > 100)
                {
                  
                    txtSub6.Text = "100";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error" );
            }
        }

        private void CH1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (CH1.Text == "")
                {

                }
                else if (int.Parse(CH1.Text) > 4)
                {

                    CH1.Text = "4";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }




            GPA.Text = "";
            if (CH1.Text == "")
            {

            }
            else if (txtSub1.Text !="")
            {
                if (int.Parse(txtSub1.Text) <= 100)
                {
                    if (int.Parse(txtSub1.Text) >= 85 && int.Parse(txtSub1.Text) <= 100)
                    {
                        Double Value = 4.0;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;


                    }
                    else if (int.Parse(txtSub1.Text) == 84)
                    {
                        Double Value = 3.9;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;



                    }
                    else if (int.Parse(txtSub1.Text) == 83)
                    {
                        Double Value = 3.8;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 82)
                    {
                        Double Value = 3.7;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 81)
                    {
                        Double Value = 3.6;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 80)
                    {
                        Double Value = 3.5;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 79)
                    {
                        Double Value = 3.4;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 78)
                    {
                        Double Value = 3.4;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 77)
                    {
                        Double Value = 3.3;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 76)
                    {
                        Double Value = 3.3;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;
                    }
                    else if (int.Parse(txtSub1.Text) == 75)
                    {
                        Double Value = 3.2;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 74)
                    {
                        Double Value = 3.2;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 73)
                    {
                        Double Value = 3.1;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }

                    else if (int.Parse(txtSub1.Text) == 72)
                    {
                        Double Value = 3.0;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 71)
                    {
                        Double Value = 2.9;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 70)
                    {
                        Double Value = 2.8;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 69)
                    {
                        Double Value = 2.7;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;


                    }
                    else if (int.Parse(txtSub1.Text) == 68)
                    {
                        Double Value = 2.6;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 67)
                    {
                        Double Value = 2.5;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 66)
                    {
                        Double Value = 2.5;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 65)
                    {
                        Double Value = 2.4;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 64)
                    {
                        Double Value = 2.4;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 63)
                    {
                        Double Value = 2.3;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 62)
                    {
                        Double Value = 2.2;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 61)
                    {
                        Double Value = 2.1;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 60)
                    {
                        Double Value = 2.0;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 59)
                    {
                        Double Value = 1.9;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 58)
                    {
                        Double Value = 1.8;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 57)
                    {
                        Double Value = 1.7;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 56)
                    {
                        Double Value = 1.6;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 55)
                    {
                        Double Value = 1.5;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 54)
                    {
                        Double Value = 1.4;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 53)
                    {
                        Double Value = 1.3;

                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;
                    }
                    else if (int.Parse(txtSub1.Text) == 52)
                    {
                        Double Value = 1.2;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 51)
                    {
                        Double Value = 1.1;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }
                    else if (int.Parse(txtSub1.Text) == 50)
                    {
                        Double Value = 1.0;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;

                    }

                    else if (int.Parse(txtSub1.Text) <= 49)
                    {
                        Double Value = 0.0;
                        int ch = int.Parse(CH1.Text);
                        gpa1 = Value * ch;
                    }
                }
            }
            else
            {
                MessageBox.Show("please Enter Subject1 Marks","Eror",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void CH2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (CH2.Text == "")
                {

                }
                else if (int.Parse(CH2.Text) > 4)
                {

                    CH2.Text = "4";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }



            if (CH2.Text == "")
            {

            }
            else if (txtSub2.Text != "")
            {
                if (int.Parse(txtSub2.Text) <= 100)
                {
                    if (int.Parse(txtSub2.Text) >= 85 && int.Parse(txtSub2.Text) <= 100)
                    {
                        Double Value = 4.0;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;


                    }
                    else if (int.Parse(txtSub2.Text) == 84)
                    {
                        Double Value = 3.9;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;



                    }
                    else if (int.Parse(txtSub2.Text) == 83)
                    {
                        Double Value = 3.8;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;



                    }
                    else if (int.Parse(txtSub2.Text) == 82)
                    {
                        Double Value = 3.7;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 81)
                    {
                        Double Value = 3.6;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 80)
                    {
                        Double Value = 3.5;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 79)
                    {
                        Double Value = 3.4;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 78)
                    {
                        Double Value = 3.4;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 77)
                    {
                        Double Value = 3.3;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 76)
                    {
                        Double Value = 3.3;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 75)
                    {
                        Double Value = 3.2;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 74)
                    {
                        Double Value = 3.2;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 73)
                    {
                        Double Value = 3.1;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }

                    else if (int.Parse(txtSub2.Text) == 72)
                    {
                        Double Value = 3.0;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 71)
                    {
                        Double Value = 2.9;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 70)
                    {
                        Double Value = 2.8;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 69)
                    {
                        Double Value = 2.7;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;


                    }
                    else if (int.Parse(txtSub2.Text) == 68)
                    {
                        Double Value = 2.6;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 67)
                    {
                        Double Value = 2.5;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 66)
                    {
                        Double Value = 2.5;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 65)
                    {
                        Double Value = 2.4;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 64)
                    {
                        Double Value = 2.4;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 63)
                    {
                        Double Value = 2.3;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 62)
                    {
                        Double Value = 2.2;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 61)
                    {
                        Double Value = 2.1;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 60)
                    {
                        Double Value = 2.0;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 59)
                    {
                        Double Value = 1.9;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 58)
                    {
                        Double Value = 1.8;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 57)
                    {
                        Double Value = 1.7;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 56)
                    {
                        Double Value = 1.6;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 55)
                    {
                        Double Value = 1.5;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 54)
                    {
                        Double Value = 1.4;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 53)
                    {
                        Double Value = 1.3;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 52)
                    {
                        Double Value = 1.2;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 51)
                    {
                        Double Value = 1.1;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }
                    else if (int.Parse(txtSub2.Text) == 50)
                    {
                        Double Value = 1.0;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;

                    }

                    else if (int.Parse(txtSub2.Text) <= 49)
                    {
                        Double Value = 0.0;
                        int ch = int.Parse(CH2.Text);
                        gpa2 = Value * ch;


                    }


                }


            }
            else
            {
                MessageBox.Show("please Enter Subject1 Marks", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CH3_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (CH3.Text == "")
                {

                }
                else if (int.Parse(CH3.Text) > 4)
                {

                    CH3.Text = "4";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            if (CH3.Text == "")
            {

            }
            else if (txtSub3.Text != "")
            {

                {
                    if (int.Parse(txtSub3.Text) <= 100)
                    {
                        if (int.Parse(txtSub3.Text) >= 85 && int.Parse(txtSub3.Text) <= 100)
                        {
                            Double Value = 4.0;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;


                        }
                        else if (int.Parse(txtSub3.Text) == 84)
                        {
                            Double Value = 3.9;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;



                        }
                        else if (int.Parse(txtSub3.Text) == 83)
                        {
                            Double Value = 3.8;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 82)
                        {
                            Double Value = 3.7;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 81)
                        {
                            Double Value = 3.6;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 80)
                        {
                            Double Value = 3.5;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 79)
                        {
                            Double Value = 3.4;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 78)
                        {
                            Double Value = 3.4;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 77)
                        {
                            Double Value = 3.3;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 76)
                        {
                            Double Value = 3.3;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;
                        }
                        else if (int.Parse(txtSub3.Text) == 75)
                        {
                            Double Value = 3.2;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 74)
                        {
                            Double Value = 3.2;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 73)
                        {
                            Double Value = 3.1;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }

                        else if (int.Parse(txtSub3.Text) == 72)
                        {
                            Double Value = 3.0;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 71)
                        {
                            Double Value = 2.9;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 70)
                        {
                            Double Value = 2.8;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 69)
                        {
                            Double Value = 2.7;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;


                        }
                        else if (int.Parse(txtSub3.Text) == 68)
                        {
                            Double Value = 2.6;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 67)
                        {
                            Double Value = 2.5;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 66)
                        {
                            Double Value = 2.5;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 65)
                        {
                            Double Value = 2.4;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 64)
                        {
                            Double Value = 2.4;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 63)
                        {
                            Double Value = 2.3;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 62)
                        {
                            Double Value = 2.2;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 61)
                        {
                            Double Value = 2.1;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 60)
                        {
                            Double Value = 2.0;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 59)
                        {
                            Double Value = 1.9;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 58)
                        {
                            Double Value = 1.8;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 57)
                        {
                            Double Value = 1.7;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 56)
                        {
                            Double Value = 1.6;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 55)
                        {
                            Double Value = 1.5;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 54)
                        {
                            Double Value = 1.4;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 53)
                        {
                            Double Value = 1.3;

                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;
                        }
                        else if (int.Parse(txtSub3.Text) == 52)
                        {
                            Double Value = 1.2;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 51)
                        {
                            Double Value = 1.1;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }
                        else if (int.Parse(txtSub3.Text) == 50)
                        {
                            Double Value = 1.0;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;

                        }

                        else if (int.Parse(txtSub3.Text) <= 49)
                        {
                            Double Value = 0.0;
                            int ch = int.Parse(CH3.Text);
                            gpa3 = Value * ch;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("please Enter Subject1 Marks", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CH4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (CH4.Text == "")
                {

                }
                else if (int.Parse(CH4.Text) > 4)
                {

                    CH4.Text = "4";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            if (CH4.Text == "")
            {

            }
            else if (txtSub4.Text != "")
            {
                if (int.Parse(txtSub4.Text) <= 100)
                {
                    if (int.Parse(txtSub4.Text) >= 85 && int.Parse(txtSub4.Text) <= 100)
                    {
                        Double Value = 4.0;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;


                    }
                    else if (int.Parse(txtSub4.Text) == 84)
                    {
                        Double Value = 3.9;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;



                    }
                    else if (int.Parse(txtSub4.Text) == 83)
                    {
                        Double Value = 3.8;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 82)
                    {
                        Double Value = 3.7;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 81)
                    {
                        Double Value = 3.6;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 80)
                    {
                        Double Value = 3.5;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 79)
                    {
                        Double Value = 3.4;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 78)
                    {
                        Double Value = 3.4;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 77)
                    {
                        Double Value = 3.3;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 76)
                    {
                        Double Value = 3.3;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;
                    }
                    else if (int.Parse(txtSub4.Text) == 75)
                    {
                        Double Value = 3.2;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 74)
                    {
                        Double Value = 3.2;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 73)
                    {
                        Double Value = 3.1;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }

                    else if (int.Parse(txtSub4.Text) == 72)
                    {
                        Double Value = 3.0;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 71)
                    {
                        Double Value = 2.9;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 70)
                    {
                        Double Value = 2.8;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 69)
                    {
                        Double Value = 2.7;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;


                    }
                    else if (int.Parse(txtSub4.Text) == 68)
                    {
                        Double Value = 2.6;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 67)
                    {
                        Double Value = 2.5;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 66)
                    {
                        Double Value = 2.5;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 65)
                    {
                        Double Value = 2.4;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 64)
                    {
                        Double Value = 2.4;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 63)
                    {
                        Double Value = 2.3;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 62)
                    {
                        Double Value = 2.2;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 61)
                    {
                        Double Value = 2.1;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 60)
                    {
                        Double Value = 2.0;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 59)
                    {
                        Double Value = 1.9;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 58)
                    {
                        Double Value = 1.8;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 57)
                    {
                        Double Value = 1.7;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 56)
                    {
                        Double Value = 1.6;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 55)
                    {
                        Double Value = 1.5;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 54)
                    {
                        Double Value = 1.4;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 53)
                    {
                        Double Value = 1.3;

                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;
                    }
                    else if (int.Parse(txtSub4.Text) == 52)
                    {
                        Double Value = 1.2;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 51)
                    {
                        Double Value = 1.1;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }
                    else if (int.Parse(txtSub4.Text) == 50)
                    {
                        Double Value = 1.0;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;

                    }

                    else if (int.Parse(txtSub4.Text) <= 49)
                    {
                        Double Value = 0.0;
                        int ch = int.Parse(CH4.Text);
                        gpa4 = Value * ch;
                    }
                }
            }
            else
            {
                MessageBox.Show("please Enter Subject1 Marks", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CH5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (CH5.Text == "")
                {

                }
                else if (int.Parse(CH5.Text) > 4)
                {

                    CH5.Text = "4";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            if (CH5.Text == "")
            {

            }
            else if (txtSub5.Text != "")
            {
                if (int.Parse(txtSub5.Text) <= 100)
                {
                    if (int.Parse(txtSub5.Text) >= 85 && int.Parse(txtSub5.Text) <= 100)
                    {
                        Double Value = 4.0;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;


                    }
                    else if (int.Parse(txtSub5.Text) == 84)
                    {
                        Double Value = 3.9;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;



                    }
                    else if (int.Parse(txtSub5.Text) == 83)
                    {
                        Double Value = 3.8;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 82)
                    {
                        Double Value = 3.7;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 81)
                    {
                        Double Value = 3.6;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 80)
                    {
                        Double Value = 3.5;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 79)
                    {
                        Double Value = 3.4;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 78)
                    {
                        Double Value = 3.4;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 77)
                    {
                        Double Value = 3.3;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 76)
                    {
                        Double Value = 3.3;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;
                    }
                    else if (int.Parse(txtSub5.Text) == 75)
                    {
                        Double Value = 3.2;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 74)
                    {
                        Double Value = 3.2;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 73)
                    {
                        Double Value = 3.1;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }

                    else if (int.Parse(txtSub5.Text) == 72)
                    {
                        Double Value = 3.0;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 71)
                    {
                        Double Value = 2.9;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 70)
                    {
                        Double Value = 2.8;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 69)
                    {
                        Double Value = 2.7;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;


                    }
                    else if (int.Parse(txtSub5.Text) == 68)
                    {
                        Double Value = 2.6;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 67)
                    {
                        Double Value = 2.5;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 66)
                    {
                        Double Value = 2.5;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 65)
                    {
                        Double Value = 2.4;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 64)
                    {
                        Double Value = 2.4;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 63)
                    {
                        Double Value = 2.3;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 62)
                    {
                        Double Value = 2.2;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 61)
                    {
                        Double Value = 2.1;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 60)
                    {
                        Double Value = 2.0;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 59)
                    {
                        Double Value = 1.9;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 58)
                    {
                        Double Value = 1.8;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 57)
                    {
                        Double Value = 1.7;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 56)
                    {
                        Double Value = 1.6;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 55)
                    {
                        Double Value = 1.5;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 54)
                    {
                        Double Value = 1.4;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 53)
                    {
                        Double Value = 1.3;

                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;
                    }
                    else if (int.Parse(txtSub5.Text) == 52)
                    {
                        Double Value = 1.2;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 51)
                    {
                        Double Value = 1.1;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }
                    else if (int.Parse(txtSub5.Text) == 50)
                    {
                        Double Value = 1.0;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;

                    }

                    else if (int.Parse(txtSub5.Text) <= 49)
                    {
                        Double Value = 0.0;
                        int ch = int.Parse(CH5.Text);
                        gpa5 = Value * ch;
                    }
                }
            }
            else
            {
                MessageBox.Show("please Enter Subject1 Marks", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CH6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (CH6.Text == "")
                {

                }
                else if (int.Parse(CH6.Text) > 4)
                {

                    CH6.Text = "4";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            if (CH6.Text == "")
            {

            }
            else if (txtSub6.Text != "")
            {
                if (int.Parse(txtSub6.Text) <= 100)
                {
                    if (int.Parse(txtSub6.Text) >= 85 && int.Parse(txtSub6.Text) <= 100)
                    {
                        Double Value = 4.0;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;


                    }
                    else if (int.Parse(txtSub6.Text) == 84)
                    {
                        Double Value = 3.9;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;



                    }
                    else if (int.Parse(txtSub6.Text) == 83)
                    {
                        Double Value = 3.8;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 82)
                    {
                        Double Value = 3.7;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 81)
                    {
                        Double Value = 3.6;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 80)
                    {
                        Double Value = 3.5;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 79)
                    {
                        Double Value = 3.4;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 78)
                    {
                        Double Value = 3.4;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 77)
                    {
                        Double Value = 3.3;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 76)
                    {
                        Double Value = 3.3;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;
                    }
                    else if (int.Parse(txtSub6.Text) == 75)
                    {
                        Double Value = 3.2;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 74)
                    {
                        Double Value = 3.2;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 73)
                    {
                        Double Value = 3.1;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }

                    else if (int.Parse(txtSub6.Text) == 72)
                    {
                        Double Value = 3.0;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 71)
                    {
                        Double Value = 2.9;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 70)
                    {
                        Double Value = 2.8;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 69)
                    {
                        Double Value = 2.7;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;


                    }
                    else if (int.Parse(txtSub6.Text) == 68)
                    {
                        Double Value = 2.6;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 67)
                    {
                        Double Value = 2.5;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 66)
                    {
                        Double Value = 2.5;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 65)
                    {
                        Double Value = 2.4;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 64)
                    {
                        Double Value = 2.4;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 63)
                    {
                        Double Value = 2.3;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 62)
                    {
                        Double Value = 2.2;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 61)
                    {
                        Double Value = 2.1;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 60)
                    {
                        Double Value = 2.0;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 59)
                    {
                        Double Value = 1.9;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 58)
                    {
                        Double Value = 1.8;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 57)
                    {
                        Double Value = 1.7;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 56)
                    {
                        Double Value = 1.6;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 55)
                    {
                        Double Value = 1.5;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 54)
                    {
                        Double Value = 1.4;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 53)
                    {
                        Double Value = 1.3;

                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;
                    }
                    else if (int.Parse(txtSub6.Text) == 52)
                    {
                        Double Value = 1.2;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 51)
                    {
                        Double Value = 1.1;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }
                    else if (int.Parse(txtSub6.Text) == 50)
                    {
                        Double Value = 1.0;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;

                    }

                    else if (int.Parse(txtSub6.Text) <= 49)
                    {
                        Double Value = 0.0;
                        int ch = int.Parse(CH6.Text);
                        gpa6 = Value * ch;
                    }
                }
            }
            else
            {
                MessageBox.Show("please Enter Subject1 Marks", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {
            txtSub1.Text = "";
            txtSub2.Text = "";
            txtSub3.Text = "";
            txtSub4.Text = "";
            txtSub5.Text = "";
            txtSub6.Text = "";
            CH1.Text = "";
            CH2.Text = "";
            CH3.Text = "";
            CH4.Text = "";
            CH5.Text = "";
            CH6.Text = "";
            GPA.Text = "";
            gpa1 = 0;
            gpa2 = 0;
            gpa3 = 0;
            gpa4 = 0;
            gpa5 = 0;
            gpa6 = 0;
             val1 = 0;
             val2 = 0;
             val3 = 0;
             val4 = 0;
             val5 = 0;
             val6 = 0;

        }
    }
}
