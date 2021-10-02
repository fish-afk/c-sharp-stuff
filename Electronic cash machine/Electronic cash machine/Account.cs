using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Electronic_cash_machine
{
    public partial class Account : Form
    {
        bool valid = false;
        Form1 frm = new Form1();
        string username;
        string pin ;
        double balance ;
        public static bool isPremium = false;
        public Account()
        {
            InitializeComponent();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);

            radioButton1.Checked = false;
            radioButton2.Checked = true;
        }

        async private void Button13_Click(object sender, EventArgs e)
        {

            username = textBox1.Text;
            pin = textBox2.Text;


            try
            {
                balance = Double.Parse(textBox3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid balance.");
            }
            
            valid = true;

            if(radioButton1.Checked == true)
            {
                isPremium = true;
            }
            

            if (pin.Length < 4)
            {
                valid = false;
                MessageBox.Show("pin should be 4 characters");
            }

            if (Name.Length < 3)
            {
                valid = false;
                MessageBox.Show("name should be atleast 3 characters");
            }

            
            if(isPremium == true && balance < 40)
            {
                valid = false;
                MessageBox.Show("please deposit atleast $40, \nyou chose premium");
            }

            if (isPremium == false && balance < 30)
            {
                valid = false;
                MessageBox.Show("please deposit atleast $30, \nyou chose normal account");
            }

            for (int i = 0; i < users.users_list.Count - 1; i++)
            {
                if (username == users.users_list[i].get_user_name())
                {
                    MessageBox.Show("username already exists");
                    valid = false;
                }
            }

            do_sql_conn(valid);
            
        }
        private void do_sql_conn(bool state)
        {
            
            DialogResult nm;
            if (state == true)
            {
                string cn_string = Properties.Settings.Default.Atm_UsersConnectionString;



                //-< Database >

                SqlConnection cn_connection = new SqlConnection(cn_string);

                if (cn_connection.State != ConnectionState.Open) cn_connection.Open();



                string sql_Text = "INSERT INTO tbl_users ([user_name]) VALUES('" + username + "')";



                SqlCommand cmd_Command = new SqlCommand(sql_Text, cn_connection);

                cmd_Command.ExecuteNonQuery();
                


                if(isPremium == false)
                {
                    users _ = new users(balance, pin, username);
                    Form1.users_list.Add(_);

                }
                else if(isPremium == true)
                {
                    users_premium _ = new users_premium(30);
                    _.set_user_pin(pin);
                    _.set_user_bal(balance);
                    _.set_user_name(username);

                    Form1.users_list.Add(_);
                }

                nm = MessageBox.Show("Created account successfully", "Nice!", MessageBoxButtons.OK);
                if (nm == DialogResult.OK)
                {
                    
                    frm.Show();
                    this.Hide();
                    
                }

            }
            else { }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox2.Text.ToUpper();
            if (isPremium == true)
            {
                textBox2.MaxLength = 6;
            }else if (isPremium == false)
            {
                textBox2.MaxLength = 4;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                isPremium = true;
            }
            else
            {
                isPremium = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm.Show();
            this.Hide();
            
        }
    }
}
