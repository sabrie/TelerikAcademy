using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Customer
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Customer(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

}
