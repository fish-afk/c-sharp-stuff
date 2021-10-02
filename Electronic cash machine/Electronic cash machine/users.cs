using System;
using System.Collections.Generic;
using System.Threading;

namespace Electronic_cash_machine
{
    public class users: Form1
    {
        double balance;
        private string _pin;
        string name;
        static int count = 0;

        public users(double userbal, string pin_of_user, string name)
        {
            this.balance = userbal;
            this._pin = pin_of_user;
            this.name = name;
            count += 1;

        }
        public users()
        {}
        public virtual double get_current_balance()
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
        public string get_user_name()
        {
            Console.WriteLine(this.name);
            return this.name;
        }

        public virtual string get_user_pin()
        {
            return this._pin;
        }
        public virtual void set_user_pin(string pin)
        {
             this._pin = pin;
        }

        public virtual void set_user_bal(double bal)
        {
            this.balance = bal;
        }

        public virtual void set_user_name(string name)
        {
            this.name = name;
        }
    }
}
//class