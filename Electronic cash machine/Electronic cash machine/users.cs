using System;
using System.Collections.Generic;
using System.Threading;

namespace Electronic_cash_machine
{
    class users: Form1
    {
        double balance;
        string pin;
        string name;
        static int count = 0;
        
        public users(double userbal, string pin_of_user)
        {
            this.balance = userbal;
            this.pin = pin_of_user;
            count+=1;
            
        }

        public double get_current_balance()
        {
            Console.WriteLine("$" + balance);
            return this.balance;
        }

        public static int num_of_users()
        {
            Console.WriteLine(count + "Users.");
            return count;
        }

        public void set_new_balance(double withdrawed_amount)
        {
            this.balance = this.balance - withdrawed_amount;
        }

        public void set_name()
        {
            this.name = names_of_users[count];
            names_of_users.Remove(names_of_users[count]);
        }

        public string get_user_name()
        {
            Console.WriteLine(this.name);
            return this.name;
        }
    }
}
//class