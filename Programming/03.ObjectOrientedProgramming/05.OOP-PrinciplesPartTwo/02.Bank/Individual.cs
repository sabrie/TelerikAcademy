using System;
using System.Collections.Generic;
using System.Linq;

class Individual : Customer
{
    public string PersonalNumber { get; private set; }

    public Individual(string firstName, string lastName, string personalNumber)
        : base(firstName, lastName)
    {
        this.PersonalNumber = personalNumber;
    }


}
