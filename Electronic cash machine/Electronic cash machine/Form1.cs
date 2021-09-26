using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

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

        public static List<string> names_of_users = new List<string>() { null, null, null, null, "shihab", "lobster",
            "orangutan", "i junior", "poly", "mars" };

        users user1;
        users user2;
        users user3;
        users user4;

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
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);

            Button15.Enabled = false;
            Button18.Enabled = false;
            error_file = new StreamWriter($"{Convert.ToString(Directory.GetCurrentDirectory())}/error_log.txt", true);
            receipt_file = new StreamWriter($"{Convert.ToString(Directory.GetCurrentDirectory())}/Receipt.txt", true);

            user1 = new users(120000, "123A");


            user2 = new users(110000, "453C");


            user3 = new users(100000, "423A");


            user4 = new users(90000, "123C");

            user1.set_name();
            user2.set_name();
            user3.set_name();
            user4.set_name();

            Label1.Text += $"\n\fCurrent number of users: {users.num_of_users()}";
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

            if (pin == "123A")
            {
                allowed = true;
                balance = user1.get_current_balance();
                Label1.Text = $"Mr.{user1.get_user_name()}\nBal= $" + Convert.ToString(balance);
            }

            else if (pin == "453C")
            {
                allowed = true;
                balance = user2.get_current_balance();
                Label1.Text = $"Mr.{user2.get_user_name()}\nBal= $" + Convert.ToString(balance);
            }

            else if (pin == "423A")
            {
                allowed = true;
                balance = user3.get_current_balance();
                Label1.Text = $"Mr.{user3.get_user_name()}\nBal= $" + Convert.ToString(balance);
            }

            else if (pin == "123C")
            {
                allowed = true;
                balance = user4.get_current_balance();
                Label1.Text = $"Mr.{user4.get_user_name()}\nBal= $" + Convert.ToString(balance);
            }
            else
            {
                allowed = false;
                Label1.Text = "pin does not exist";
            }


        }

        private void Button14_Click(object sender, EventArgs e)
        {
            pin = TextBox1.Text;
            withdraw_with_reciept = false;
            TextBox1.Text = "";
            userinput = "";

            if (pin == "123A")
            {

                allowed = true;
            }

            else if (pin == "453C")
            {
                allowed = true;
            }
            else if (pin == "423A")
            {
                allowed = true;
            }

            else if (pin == "123C")
            {
                allowed = true;
            }
            else
            {
                allowed = false;
            }

            if (userinput != null && allowed == true)
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

            if (pin == "123A")
            {

                allowed = true;
            }

            else if (pin == "453C")
            {
                allowed = true;
            }
            else if (pin == "423A")
            {
                allowed = true;
            }

            else if (pin == "123C")
            {
                allowed = true;
            }
            else
            {
                allowed = false;
            }

            if (userinput != null && allowed == true)
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

        public void Button15_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            try
            {
                double amount = Convert.ToDouble(TextBox1.Text);
                double current_balance_1 = Convert.ToDouble(user1.get_current_balance());
                double current_balance_2 = Convert.ToDouble(user2.get_current_balance());
                double current_balance_3 = Convert.ToDouble(user3.get_current_balance());
                double current_balance_4 = Convert.ToDouble(user4.get_current_balance());

                if (withdraw_with_reciept == false)
                {
                    switch (pin)
                    {
                        case "123A":

                            if (amount <= current_balance_1)
                            {

                                user1.set_new_balance(amount);
                                //Button18.Enabled = false;
                                Label1.Text = $"Mr.{user1.get_user_name()} \n withdrew ${amount} succesfully";

                            }
                            else if (amount > current_balance_1)
                            {
                                Label1.Text = "You do not have as much funds as mentioned.";
                            }
                            break;

                        case "453C":

                            if (amount <= current_balance_2)
                            {

                                user1.set_new_balance(amount);
                                Label1.Text = $"Mr.{user2.get_user_name()} \n withdrew ${amount} succesfully";
                                //Button18.Enabled = false;
                            }
                            else if (amount > current_balance_2)
                            {
                                Label1.Text = "You do not have as much funds as mentioned.";
                            }

                            break;

                        case "423A":

                            if (amount <= current_balance_3)
                            {

                                user1.set_new_balance(amount);
                                Label1.Text = $"Mr.{user3.get_user_name()} \n withdrew ${amount} succesfully";
                                //Button18.Enabled = false;
                            }
                            else if (amount > current_balance_3)
                            {
                                Label1.Text = "You do not have as much funds as mentioned.";
                            }
                            break;

                        case "123C":

                            if (amount <= current_balance_4)
                            {

                                user1.set_new_balance(amount);
                                Label1.Text = $"Mr.{user4.get_user_name()} \n withdrew ${amount} succesfully";
                                //Button18.Enabled = false;
                            }
                            else if (amount > current_balance_4)
                            {
                                Label1.Text = "You do not have as much funds as mentioned.";
                            }
                            break;

                        default:

                            Label1.Text = "Pin does not exist";

                            break;

                    }
                }
                else if (withdraw_with_reciept == true)
                {
                    switch (pin)
                    {
                        case "123A":

                            if (amount <= current_balance_1)
                            {

                                user1.set_new_balance(amount);
                                // Button18.Enabled = false;
                                Label1.Text = $"Mr.{user1.get_user_name()}\n{DateTime.Now}\n balance - {current_balance_1} \n withdrawn amout - {amount} \n";
                                current_balance_1 = user1.get_current_balance();
                                Label1.Text += $"new balance - {current_balance_1}";
                                receipt_file.WriteLine(Label1.Text);


                            }
                            else if (amount > current_balance_1)
                            {
                                Label1.Text = "You do not have as much funds as mentioned.";
                            }

                            break;

                        case "453C":

                            if (amount <= current_balance_2)
                            {

                                user2.set_new_balance(amount);
                                // Button18.Enabled = false;
                                Label1.Text = $"Mr.{user2.get_user_name()}\n{DateTime.Now}\n balance - {current_balance_2} \n withdrawn amout - {amount} \n";
                                current_balance_2 = user2.get_current_balance();
                                Label1.Text += $"new balance - {current_balance_2}";
                                receipt_file.WriteLine(Label1.Text);

                            }
                            else if (amount > current_balance_2)
                            {
                                Label1.Text = "You do not have as much funds as mentioned.";
                            }

                            break;

                        case "423A":

                            if (amount <= current_balance_3)
                            {

                                user3.set_new_balance(amount);
                                //Button18.Enabled = false;
                                Label1.Text = $"Mr.{user3.get_user_name()}\n{DateTime.Now}\n balance - {current_balance_3} \n withdrawn amout - {amount} \n";
                                current_balance_3 = user3.get_current_balance();
                                Label1.Text += $"new balance - {current_balance_3}";
                                receipt_file.WriteLine(Label1.Text);

                            }
                            else if (amount > current_balance_3)
                            {
                                Label1.Text = "You do not have as much funds as mentioned.";
                            }
                            break;

                        case "123C":

                            if (amount <= current_balance_4)
                            {

                                user4.set_new_balance(amount);
                                //Button18.Enabled = false;
                                Label1.Text = $"Mr.{user4.get_user_name()}\n{DateTime.Now}\n balance - {current_balance_4} \n withdrawn amout - {amount} \n";
                                current_balance_4 = user4.get_current_balance();
                                Label1.Text += $"new balance - {current_balance_4}";
                                receipt_file.WriteLine(Label1.Text);

                            }
                            else if (amount > current_balance_4)
                            {
                                Label1.Text = "You do not have as much funds as mentioned.";
                            }
                            break;

                        default:

                            Label1.Text = "Pin does not exist";

                            break;

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
            Label2.Text = "Enter your pin number to login";

            Button13.Enabled = true;
            Button14.Enabled = true;
            Button16.Enabled = true;
            Button18.Enabled = false;
            Button15.Enabled = false;
            Button12.Enabled = true;
            Button10.Enabled = true;
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
    }
}


// 500 lines-ish, code not documented...
