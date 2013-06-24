using System;
using System.Collections.Generic;
using System.Text;

class Teacher : Person
{
    // property
    public List<Discipline> Disciplines { get; private set; }

    // constructor
    public Teacher(string firstName, string lastName, List<Discipline> discipline)
        : base(firstName, lastName) // we call the base constructor to initialize the first and last name
    {
        this.Disciplines = discipline;
    }

    //public void AddDiscipline(Discipline discipline)
    //{
    //    this.Disciplines.Add(discipline);
    //}

    //public void RemoveDiscipline(Discipline discipline)
    //{
    //    this.Disciplines.Remove(discipline);              
    //}

    // override ToString(); in order to print the information about the Teachers in the following format
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        foreach (var item in this.Disciplines)
        {
            result.Append(item + " ");
        }
        
        return String.Format("{0} {1} {2} {0}Disciplines: {3}{0}",
            Environment.NewLine, this.FirstName.ToUpper(), this.LastName.ToUpper(), result.ToString());
    }
}
