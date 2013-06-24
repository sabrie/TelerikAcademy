using System;

class Student : Human
{
    // field
    private int? grade;

    // property
    public int? Grade { get; set; }

    // constructor
    public Student(string firstName, string lastName, int? grade = null)
        : base(firstName, lastName) // we call the base constructor to initialize the first and last names
    {
        this.Grade = grade;
    }

    // override ToString(); in order to print the information about the Student in the following format
    public override string ToString()
    {
        return String.Format("{0} {1}, Grade: {2}", 
            this.FirstName.ToUpper(), this.LastName.ToUpper(), this.Grade);
    }
}
