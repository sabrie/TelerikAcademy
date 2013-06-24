using System;
using System.Collections;
using System.Linq;

class StudentTest
{
    static void Main()
    {
        // create an array that holds the instances of the Student class
        // each student has first name, last name and age
        Student[] students = new Student[]
        { 
          new Student ("Angel", "Zelev", 38), 
          new Student ("Zeko", "Angelov", 25),
          new Student ("Zeko", "Ivanov", 20),
          new Student ("Pesho", "Zenev", 21)
        };

        // Exercise 3
        // select all students whose first name is before its last name alphabetically
        var sortedStudentsByNames =
            from student in students
            where student.FirstName.CompareTo(student.LastName) < 0
            select student;

        Console.WriteLine("Students whose first name is before their last name alphabetically are: ");

        // print the selected students on the Console
        foreach (Student student in sortedStudentsByNames)
        {
            // print the information for each selected student using the format set in the overriden ToString method in Student class
            Console.WriteLine(student);
        }

        Console.WriteLine();
        // Exercise 4
        // we select all students whose age is between 18 and 24
        var sortedStudentsByAge =
            from student in students
            where student.Age > 18 && student.Age < 24
            select student;

        Console.WriteLine("Students with age between 18 and 24 are: ");
        // print the selected students on the Console
        foreach (Student student in sortedStudentsByAge)
        {
            // print the information for each selected student using the format set in the overriden ToString method in Student class
            Console.WriteLine(student);
        }

        Console.WriteLine();

        // Exercise 5
        // sort the students by first name in descending order using lambda expressions
        // if first names are equal then sort by last name in descending order
        Console.WriteLine("Students sorted by first name in descending order using Lambda expressions");
        var orderByFirstName = students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);
        
        // print the selected students on the Console
        foreach (Student student in orderByFirstName)
        {
            // print the information for each selected student using the format set in the overriden ToString method in Student class
            Console.WriteLine(student);
        }
        Console.WriteLine();

        // Exercise 5
        // sort the students by first name in descending order using LINQ
        // if first names are equal then sort by last name in descending order 
        Console.WriteLine("Students sorted by first name in descending order using LINQ");
        var orderNamesLinq =
            from student in students
            orderby student.FirstName descending, student.LastName descending
            select student;

        // print the selected students on the Console
        foreach (Student student in orderNamesLinq)
        {
            // print the information for each selected student using the format set in the overriden ToString method in Student class
            Console.WriteLine(student);
        }
    }
}
