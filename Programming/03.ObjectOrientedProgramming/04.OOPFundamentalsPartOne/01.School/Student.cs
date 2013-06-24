using System;

class Student : Person
{
    // field
    private string uniqueClassNumber;

    // property
    public string UniqueClassNumber { get; set; }

    // constructor
    public Student(string firstName, string lastName, string uniqueClassNumber)
        : base(firstName, lastName) // we call the base constructor to initialize the first and last name
    {
        this.UniqueClassNumber = uniqueClassNumber;
    }

    // override ToString(); in order to print the information about the Student in the following format
    public override string ToString()
    {
        return String.Format("{0} {1}, Class Number: {2} {3}",
            this.FirstName, this.LastName, this.UniqueClassNumber, Environment.NewLine);
    }
}
