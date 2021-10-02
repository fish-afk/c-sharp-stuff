using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_cash_machine
{
    class users_premium : users
    {
        double bouns_amt;
        public users_premium(double bonus)
        {
            this.bouns_amt = bonus;
        }

        public override double get_current_balance()
        {
            return base.get_current_balance() + this.bouns_amt;
        }

    }
}
