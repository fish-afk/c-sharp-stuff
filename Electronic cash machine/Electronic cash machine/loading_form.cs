using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Electronic_cash_machine
{
    public partial class loading_form : Form
    {
        List<string> info = new List<string>();
        int loop = 0;
        public loading_form()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            

            if (panel2.Width % 50 == 0)
            {
                
                loop += 1;
                label2.Text = info[loop];
                System.Threading.Thread.Sleep(300);
            }

           

            if (panel2.Width >= panel1.Width)
            {
                
                timer1.Stop();
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
        }

        private void loading_form_Load(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);

            info.Add("Installing dependencies"); info.Add("Creating threads"); info.Add("updating ui"); info.Add("refreshing backend"); info.Add("Finsihing up"); info.Add("Cleaning up....");
            label2.Text = info[loop];
        }
    }
}
