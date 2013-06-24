using System;
using System.Collections.Generic;
using System.Text;

class Class
{
    // fields
    private List<Student> students;
    private List<Teacher> teachers;
    private string className;

    // properties
    public List<Student> Students { get; private set; }
    public List<Teacher> Teachers { get; private set; }
    public string ClassName { get; private set; }

    // constructor
    public Class(string className, List<Student> students, List<Teacher> teachers)
    {
        this.ClassName = className;
        this.Students = students;
        this.Teachers = teachers;
    }

    // override ToString(); in order to print the information about the Class in the following format
    public override string ToString()
    {
        StringBuilder allStudents = new StringBuilder();
        foreach (var student in this.Students)
        {
            allStudents.Append(student);
        }
        
        StringBuilder allTeachers = new StringBuilder();
        foreach (var student in this.Teachers)
        {
            allTeachers.Append(student);
        }

        return String.Format("CLASS: {1}{0} {0}Students: {0}{2} {0}Teachers: {3}{0}", 
            Environment.NewLine, this.ClassName, allStudents, allTeachers);
    }
}
