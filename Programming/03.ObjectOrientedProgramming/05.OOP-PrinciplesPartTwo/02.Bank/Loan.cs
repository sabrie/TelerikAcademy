using System;
using System.Collections.Generic;
using System.Linq;

class Loan : Account
{
    public Loan(Customer customer, decimal balance, decimal interestRate)
        : base(customer, balance, interestRate)
    {
    }

    public override decimal CalculateInterestRate(int months)
    {
        if (this.Customer is Individual)
        {
            return base.CalculateInterestRate(months - 3);
        }
        else if (this.Customer is Company)
        {
            return base.CalculateInterestRate(months - 2);
        }
        return 0;
    }
}
