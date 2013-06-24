using System;
using System.Collections.Generic;
using System.Linq;

class Bank
{
    public List<Account> Accounts { get; private set; }

    public Bank(List<Account> accounts)
    {
        this.Accounts = accounts;
    }
}
