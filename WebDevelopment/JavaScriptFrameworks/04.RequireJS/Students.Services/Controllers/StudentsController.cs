/*
 Create the following web services:
    GET api/students  - returns all students
    Students have id, name and grade
    GET api/students/{studentId}/marks - returns the marks of a student
    Marks have subject and score
 No need to use a database, xml file or any other kinds of data storage. You can use a regular array.

 */

using Students.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Students.Services.Controllers
{
    public class StudentsController : ApiController
    {
        private static IList<Student> students { get; set; }

        // GET api/students
        public IList<Student> Get()
        {
            return GenerateStudents();
        }

        // GET api/students/id/marks
        [ActionName("marks")]
        public IList<Mark> GetMarks(int id)
        {
            var students = GenerateStudents();
            if (students[id-1].Marks!=null)
            {
                return students[id - 1].Marks;
            }

            return new List<Mark>();
        }

        public IList<Student> GenerateStudents()
        {
            IList<Student> students = new List<Student>
            {
                new Student(1, "Doncho", "Minkov", 5, 18, new List<Mark>{ new Mark("Math", 4), new Mark("JavaScript", 6)}),
                new Student(2, "Nikolay", "Kostov", 4, 17, new List<Mark>{ new Mark("MVC", 6), new Mark("JavaScript", 5)}),
                new Student(3, "Ivaylo", "Kendov", 5, 25, new List<Mark>{ new Mark("OOP", 4), new Mark("C#", 6)}),
                new Student(4, "Svetlin", "Nakov", 10, 28, new List<Mark>{ new Mark("Unit Testing", 5), new Mark("WPF", 6)}),
                new Student(5, "Asya", "Georgieva", 8, 20, new List<Mark>{ new Mark("Automation Testing", 6), new Mark("Manual Testing", 4)}),
                new Student(6, "Georgi", "Georgiev", 28, 8)
            };

            return students;
        }
    }
}
