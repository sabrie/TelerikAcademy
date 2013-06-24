using System;

public abstract class Human
{
    // properties
    public string FirstName { get; set;}
    public string LastName { get; set; }

    // default constructor
    public Human()
    {
    }

    // constructor
    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
}

