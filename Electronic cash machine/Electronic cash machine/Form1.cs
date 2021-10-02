using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace Electronic_cash_machine
{
    //Make sure the CWD has read/write access...
    public partial class Form1 : Form
    {
        string userinput;
        bool allowed = false;
        bool withdraw_with_reciept = false;
        string pin;
        int dark_mode_count = 1;
        StreamWriter error_file;
        StreamWriter receipt_file;
        bool on_confirm_part = false;

        public static List<users> users_list = new List<users>(); //polymorphic list

        public Form1()
        {
            this.MaximizeBox = false;
            InitializeComponent();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            userinput += "1";
            TextBox1.Text = userinput;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            userinput += "2";
            TextBox1.Text = userinput;

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            userinput += "3";
            TextBox1.Text = userinput;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            userinput += "4";
            TextBox1.Text = userinput;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            userinput += "5";
            TextBox1.Text = userinput;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            userinput += "6";
            TextBox1.Text = userinput;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            userinput += "7";
            TextBox1.Text = userinput;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            userinput += "8";
            TextBox1.Text = userinput;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            userinput += "9";
            TextBox1.Text = userinput;
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            userinput += "A";
            TextBox1.Text = userinput;
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            userinput += "0";
            TextBox1.Text = userinput;
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            userinput += "C";
            TextBox1.Text = userinput;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            users.Text = "";

            on_confirm_part = false;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);

            Button15.Enabled = false;
            Button18.Enabled = false;
            error_file = new StreamWriter($"{Convert.ToString(Directory.GetCurrentDirectory())}/error_log.txt", true);
            receipt_file = new StreamWriter($"{Convert.ToString(Directory.GetCurrentDirectory())}/Receipt.txt", true);
            TextBox1.UseSystemPasswordChar = true;

            users_list.Add(new users(120000, "123A", "shihab"));


            users_list.Add(new users(110000, "453C", "lobster"));


            users_list.Add(new users(100000, "423A", "orangutan"));


            users_list.Add(new users(90000, "123C", "i junior"));

            //Label1.Text += $"\n\fCurrent number of users: {users.num_of_users()}";
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);


        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox1.Text = "";
            userinput = "";
            MessageBox.Show("please use the keypad only", "warning");

        }

        private void Button13_Click(object sender, EventArgs e)
        {
            pin = TextBox1.Text;
            double balance;
            Label2.Text = "";
            linkLabel1.Text = "";

            for (int i = 0; i < users_list.Count - 1; i++)
            {
                if (pin == users_list[i].get_user_pin())
                {
                    balance = users_list[i].get_current_balance();
                    Label1.Text = $"Mr.{users_list[i].get_user_name()}\nBal= $" + Convert.ToString(balance);
                }
            }


        }

        private void Button14_Click(object sender, EventArgs e)
        {
            pin = TextBox1.Text;
            withdraw_with_reciept = false;
            TextBox1.Text = "";
            userinput = "";
            linkLabel1.Text = "";
            allowed = false;

            for(int i = 0; i < users_list.Count - 1; i++)
            {
                if(pin == users_list[i].get_user_pin())
                {
                    allowed = true;
                    TextBox1.UseSystemPasswordChar = false;
                    on_confirm_part = true;
                }
                
            }

            if (allowed == true)
            {
                Button13.Enabled = false;
                Button14.Enabled = false;
                Button16.Enabled = false;
                Button15.Enabled = true;
                Button18.Enabled = true;
                Button12.Enabled = false;
                Button10.Enabled = false;
                Label1.Text = "Enter the amount you want to withdraw\n in the text area using the keypad";
                Label2.Text = "Press confirm or deny to go back to\n main screen and cancel withdrawal..";
                
            }
            else
            {
                MessageBox.Show("Either you did not enter your pin\n or your pin was incorrect..");
            }



        }

        private void Button16_Click(object sender, EventArgs e)
        {
            pin = TextBox1.Text;
            withdraw_with_reciept = true;
            TextBox1.Text = "";
            userinput = "";
            allowed = false;
            

            for(int i = 0; i < users_list.Count - 1; i++)
            {
                if (pin == users_list[i].get_user_pin())
                {
                    allowed = true;
                    TextBox1.UseSystemPasswordChar = false;
                    on_confirm_part = true;
                }
            }

            if (allowed == true)
            {
                Button13.Enabled = false;
                Button14.Enabled = false;
                Button16.Enabled = false;
                Button15.Enabled = true;
                Button18.Enabled = true;
                Button12.Enabled = false;
                Button10.Enabled = false;
                Label1.Text = "Enter the amount you want to withdraw\n in the text area using the keypad";
                Label2.Text = "Press confirm or deny to go back to\n main screen and cancel withdrawal..";
            }
            else
            {
                MessageBox.Show("Either you did not enter your pin\n or your pin was incorrect..","Warning", MessageBoxButtons.OK);
            }
        }

        public void Button15_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            try
            {
                double amount = Convert.ToDouble(TextBox1.Text);
                
                

                if (withdraw_with_reciept == false)
                {
                    for (int i = 0; i < users_list.Count - 1; i++)
                    {
                        if (pin == users_list[i].get_user_pin())
                        {
                            double current_balance_1 = Convert.ToDouble(users_list[i].get_current_balance());
                            if (amount <= current_balance_1)
                            {

                                users_list[i].set_new_balance(amount);
                                //Button18.Enabled = false;
                                Label1.Text = $"Mr.{users_list[i].get_user_name()} \n withdrew ${amount} succesfully";

                            }
                            else if (amount > current_balance_1)
                            {
                                Label1.Text = "You do not have as much funds as mentioned.";
                            }

                            on_confirm_part = true;
                            
                        }

                    }
                }
                else if (withdraw_with_reciept == true)
                {
                    for(int c = 0; c < users_list.Count - 1; c++)
                    {
                        if(pin == users_list[c].get_user_pin())
                        {
                            double current_balance_1 = Convert.ToDouble(users_list[c].get_current_balance());
                            if (amount <= current_balance_1)
                            {

                                users_list[c].set_new_balance(amount);
                                // Button18.Enabled = false;
                                Label1.Text = $"Mr.{users_list[c].get_user_name()}\n{DateTime.Now}\n balance - {current_balance_1} \n withdrawn amount - {amount} \n";
                                current_balance_1 = users_list[c].get_current_balance();
                                Label1.Text += $"new balance - {current_balance_1}";
                                receipt_file.WriteLine(Label1.Text);


                            }
                            else if (amount > current_balance_1)
                            {
                                Label1.Text = "You do not have as much funds as mentioned.";
                            }
                        }
                    }
                }
            }
            catch (Exception exception6)
            {
                MessageBox.Show("error\n" + exception6.Message);
            }
            finally { }

        }

        private void Button18_Click(object sender, EventArgs e)
        {
            Label1.Text = "Money Marketplace";
            Label2.Text = "Enter your pin number to login\n To create an account click";
            linkLabel1.Text = "here";

            Button13.Enabled = true;
            Button14.Enabled = true;
            Button16.Enabled = true;
            Button18.Enabled = false;
            Button15.Enabled = false;
            Button12.Enabled = true;
            Button10.Enabled = true;
            TextBox1.Text = "";
            userinput = "";
            TextBox1.UseSystemPasswordChar = true;
            on_confirm_part = false;
        }

        private void button17_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {

                userinput = userinput.Remove(userinput.Length - 1);
                TextBox1.Text = userinput;

            }
            catch (Exception exception)
            {

                //optional to do this
                try
                {
                    Console.WriteLine(exception.Message);

                    error_file.WriteLine(Convert.ToString(exception));
                }
                catch { }
            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            dark_mode_count += 1;

            if (dark_mode_count % 2 == 0)
            {
                this.BackColor = Color.Black;
                Panel1.BorderStyle = BorderStyle.FixedSingle;
                checkBox1.ForeColor = Color.White;

            }
            else if (dark_mode_count % 2 == 1)
            {
                this.BackColor = Color.White;
                Panel1.BorderStyle = BorderStyle.Fixed3D;
                checkBox1.ForeColor = Color.Black;
            }
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            receipt_file.Close();
            error_file.Close();
            MessageBox.Show("exiting");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Process.Start($"{Directory.GetCurrentDirectory()}/Receipt.txt");
            
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            string key = Interaction.InputBox("This action requires higher privilages, \n Enter Secret key...", "prompt", "");

            if(key == "ak123")
            {
                string cn_string = Properties.Settings.Default.Atm_UsersConnectionString;

                users.BackColor = Color.Black;
                users.ForeColor = Color.White;

                //-< Database >

                SqlConnection cn_connection = new SqlConnection(cn_string);

                if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

                string sql_Text = "SELECT * FROM tbl_users";

                DataTable tbl = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sql_Text, cn_connection);

                adapter.Fill(tbl);

                users.DisplayMember = "user_name";
                users.DataSource = tbl;

                cn_connection.Close();
            }
            else
            {
                MessageBox.Show("Wrong key!");
                users.DataSource = null;
            }
            


        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Account form = new Account();
            form.Show();
            this.Hide();
            error_file.Close();
            receipt_file.Close();
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (on_confirm_part == false && userinput.Length > 4 && Account.isPremium == false)
            {
                userinput = userinput.Remove(userinput.Length - 1);
            }

            if (on_confirm_part == false && userinput.Length > 6 && Account.isPremium == true)
            {
                userinput = userinput.Remove(userinput.Length - 1);
            }

        }
    }
}


// 400 lines-ish, code not documented...
