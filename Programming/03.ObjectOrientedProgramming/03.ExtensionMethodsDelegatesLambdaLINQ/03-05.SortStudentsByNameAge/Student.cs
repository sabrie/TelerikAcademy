using System;

class Student
{
    // properties
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    // constructor
    public Student(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }

    // override the string method to print the information following the format bellow
    public override string ToString()
    {
        return String.Format("{0} {1}, {2} years old",
             this.FirstName, this.LastName, this.Age);
    }
}