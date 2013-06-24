using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class HumanTest
{
    // method to Print the array of Students and Workers
    static void Print(IEnumerable list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        // create an array of 10 students. Each student has first name, last name and grade
        Student[] students = {

            // use the constructor - public Student(string firstName, string lastName, int? grade)
            new Student("Ivan", "Cholakov", 3),
            new Student("Petar", "Georgiev", 6),
            new Student("Dimitar", "Shanev", 4),
            new Student("Grigor", "Kirov", 4),
            new Student("Valentin", "Chernev", 5),
            new Student("Svetlin", "Nakov", 6),
            new Student("Doncho", "Minkov", 4),
            new Student("Mihail", "Petrov", 6),
            new Student("Georgi", "Georgiev", 5),
            new Student("Veselin", "Marinov", 6),
        };

        // order students by their grades
        // using LINQ
        var orderedByGrade =
            from student in students
            orderby student.Grade ascending
            select student;

        Console.WriteLine("Students ordered by their grades:");
        Console.WriteLine();
        // print the students ordered by their grades using the method Print created in this class
        Print(orderedByGrade);

        // create an array of 10 workers. Each worker has first name, last name,  and grade
        Worker[] workers = {
            // use the constructor - public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
            new Worker("Sevdalin", "Zvezdev", 200, 8),
            new Worker("Nikolay", "Peshev", 400, 10),
            new Worker("Chavdar", "Stoyanov", 100, 4),
            new Worker("Zoya", "Ivanova", 50, 2),
            new Worker("Miglena", "Dimitrova", 340, 10),
            new Worker("Petar", "Atanasov", 120, 6),
            new Worker("Nikolay", "Dobrev", 120, 8),
            new Worker("Plamen", "Zahariev", 220, 10),
            new Worker("Georgi", "Slavchev", 180, 6),
            new Worker("Ivan", "Sharenkov", 360, 9),
        };

        // order workers by money per hour in descending order
        // using LINQ
        var orderedByMoneyPerHour =
            from worker in workers
            orderby worker.MoneyPerHour() descending
            select worker;

        Console.WriteLine("Workers ordered by money per hour in descending order");
        Console.WriteLine();
        // print the workers ordered by money per hour in descending order using the method Print created in this class
        Print(orderedByMoneyPerHour);

        // create a list where we will merge the list of students and workers
        List<Human> merged = new List<Human>();

        // we merge the array of students and workers
        merged.AddRange(students);
        merged.AddRange(workers);

        // order the merged array of students and workers by their first name and Last name
        // using LINQ
        var sortedByName =
            from human in merged
            orderby human.FirstName, human.LastName
            select human;

        Console.WriteLine("Merged List of Students and Teachers sorted by their first name and Last name");
        Console.WriteLine();
        // print the workers and students ordered by their first name and Last name
        Print(sortedByName);
    }
}
