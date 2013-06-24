using System;
using System.Collections.Generic;
using System.Linq;

class Mortgage : Account
{
    public Mortgage(Customer customer, decimal balance, decimal interestRate)
        : base(customer, balance, interestRate)
    {
    }

    public override decimal CalculateInterestRate(int months)
    {
        if (this.Customer is Company)
        {
            if (months > 12)
            {
                return base.CalculateInterestRate(months - (12 / 2));
            }
            else if (months < 12)
            {
                return base.CalculateInterestRate(months / 2);
            }            
        }
        else if (this.Customer is Individual)
        {
            if (months > 6)
            {
                return base.CalculateInterestRate(months - 6);
            }
            else if (months < 6)
            {
                return 0;
            }    
        }
        return 0;
    }
}
