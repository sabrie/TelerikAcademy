using System;
using System.Collections.Generic;
using System.Linq;

class Deposit : Account, IWithdrawable
{
    public Deposit(Customer customer, decimal balance, decimal interestRate)
        : base(customer, balance, interestRate)
    {
    }

    public override decimal CalculateInterestRate(int months)
    {
        if (this.Balance > 0 || this.Balance < 1000)
        {
            return 0;
        }
        return base.CalculateInterestRate(months);
    }

    public decimal Withdraw(decimal amount)
    {
        this.Balance -= amount;
        return this.Balance;
    }

}
