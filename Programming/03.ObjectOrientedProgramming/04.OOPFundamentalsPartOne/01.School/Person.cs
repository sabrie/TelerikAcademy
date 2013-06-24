using System;

public class Person
{
    // fields
    private string firstName;
    private string lastName;
    private int age;

    // properties
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int? Age { get; set; }

    // default constructor
    public Person()
    {
    }

    // constructor
    public Person(string firstName = null, string lastName = null, int? age = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }

    // override ToString(); in order to print the information about the Person in the following format
    public override string ToString()
    {
        return String.Format(this.FirstName + " " + this.LastName);
    }
}
