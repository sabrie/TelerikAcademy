using System;
using System.Collections.Generic;
using System.Linq;

class Company : Customer
{
    public string UniqueNumber { get; private set; }

    public Company(string name, string companyType, string uniqueNumber)
        : base(name, companyType)
    {
        this.UniqueNumber = uniqueNumber;
    }


}
