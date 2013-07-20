/*
 * Task 01.
Using code first approach, create database for student system with the following tables:
Students (with Id, Name, Number, etc.)
Courses (Name, Description, Materials, etc.)
StudentsInCourses (many-to-many relationship)
Homework (one-to-many relationship with students and courses), fields: Content, TimeSent
Annotate the data models with the appropriate attributes and enable code first migrations

 * Task 02.
Write a console application that uses the data

 * Task 03.
Seed the data with random values

 */

using StudentSystem.Data;
using StudentSystem.Data.Migrations;
using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Client
{
    class Program
    {
        static void Main()
        {
            // Task 01.
            // See StudentSystem.Models project
 
            // Task 02.
            // Got to View -> Server Explorer to see the created database StudentSystemDb
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());

            using (var context = new StudentSystemContext())
            {
                context.Database.Initialize(true);

                Student student = new Student()
                {
                    FullName = "Svetlin Nakov",
                    Number = "12345"
                };

                Course databaseCourse = new Course()
                {
                    Name = "Database",
                    Description = "SQL, MySQL, SQLite",
                };

                student.Courses.Add(databaseCourse);
                databaseCourse.Students.Add(student);

                context.Students.Add(student);
                context.Courses.Add(databaseCourse);

                context.SaveChanges();
            }

            // Task 03.
            // See in -> StudentSystem.Data -> Migrations -> Configuration.cs -> Seed();
        }
    }
}
