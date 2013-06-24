using System;
using System.Collections.Generic;

class SchoolTest
{
    static void Main()
    {
        // create a school class (an instance on the Class class :-))
        // using the constructor public Class(List<Student> students, List<Teacher> teachers);
        // each class consist of class name, list of students and list of teachers (each teacher have a set of disciplines)
        Class myClass = new Class("12 B",
            // list of students - the first parameter of the Class constructor
            new List<Student>
            {
                // we fill the List<Student> with several students who has first name, last name and class number 
                new Student("Angel", "Petrov", "1"),
                new Student("Boris", "Ivanov", "2"),
                new Student("Dimitar", "Kolev", "3"),
                new Student("Georgi", "Shishkov", "4"),
                new Student("Kiril", "Arsenov", "5"),
                new Student("Milen", "Chernev", "6")
            },
            // list of teachers - the second parameter of the Class constructor
            new List<Teacher> 
            {
                // we fill the List<Teacher> with several teachers using the constructor
                // public Teacher(string firstName, string lastName, List<Discipline> discipline)

                // we create the first teacher
                new Teacher("Veneta", "Nikolova", new List<Discipline> 
                { 
                    // we create a list of disciplines for the first teacher
                    new Discipline("Mathematics", 25, 12),
                    new Discipline("Physics", 24, 10)
                }
                ),
                // we create the second teacher
                new Teacher("Snezhana", "Cherneva", new List<Discipline> 
                { 
                    // we create a list of disciplines for the second teacher
                    new Discipline("Chemistry", 28, 5),
                    new Discipline("Physics", 24, 10)
                }
                ),
                // we create the third teacher
                new Teacher("Petar", "Ivanov", new List<Discipline> 
                { 
                    // we create a list of disciplines for the third teacher
                    new Discipline("Informatics", 28, 20),
                    new Discipline("Programming", 35, 30)
                }
                ),
            }
        );

        // create a list of Classes - List<Class>() which consists of set of classes in the School
        List<Class> classes = new List<Class>();
        // we add our class to the List of classes
        classes.Add(myClass);     

        // Each School consists of list of classes
        // we create a school by passing as parameter the list of classes using the constructor - public School(List<Class> classes)
        School school = new School(classes);

        // we print the information about the School using the overriden ToString method
        Console.WriteLine(school);



        //// THIS IS ANOTHER WAY OF CREATING A CLASS AND SCHOOL
        
        //// first we create a list of students

        //List<Student> students = new List<Student>()
        //{
        //    new Student("Angel", "Petrov", "1"),
        //    new Student("Boris", "Ivanov", "2"),
        //    new Student("Dimitar", "Kolev", "3"),
        //    new Student("Georgi", "Shishkov", "4"),
        //    new Student("Kiril", "Arsenov", "5"),
        //    new Student("Milen", "Chernev", "6")
        //};

        //// then we create a list of teachers

        //List<Teacher> teachers = new List<Teacher>()
        //{
        //    new Teacher("Veneta", "Nikolova", new List<Discipline> 
        //    { 
        //        new Discipline("Mathematics", 25, 12),
        //        new Discipline("Physics", 24, 10)
        //    }
        //    ),
        //    new Teacher("Snezhana", "Cherneva", new List<Discipline> 
        //    { 
        //        new Discipline("Chemistry", 28, 5),
        //        new Discipline("Physics", 24, 10)
        //    }
        //    ),
        //};

        //// after that we create a class that consists of this students and teachers

        //Class anotherClass = new Class("12 G", students, teachers);

        // //we add our new class to the List of classes
        //classes.Add(anotherClass);

        // // we print again the updated information about the school and its classes, teachers and ...
        //Console.WriteLine(school);

    }
}

