using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Account : IDepositable
{
    public Customer Customer { get; protected set; }
    public decimal Balance { get; protected set; }
    public decimal InterestRate { get; protected set; }

    public Account(Customer customer, decimal balance, decimal interestRate)
    {
        this.Customer = customer;
        this.Balance = balance;
        this.InterestRate = interestRate;
    }

    public decimal Deposit(decimal amount)
    {
        this.Balance += amount;
        return this.Balance;
    }

    public virtual decimal CalculateInterestRate(int months)
    {
        if (months <= 0)
        {
            return 0;
        }
        return this.InterestRate * months;
    }
}

