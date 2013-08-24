using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Students.Services.Models
{
    [DataContract]
    public class Student
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "grade")]
        public int Grade { get; set; }

        [DataMember(Name = "age")]
        public int Age { get; set; }

        [DataMember(Name = "marks")]
        public IEnumerable<Mark> Marks { get; set; }

        public Student(int id, string firstName, string lastName, int grade, int age, List<Mark> marks = null)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
            this.Age = age;
            this.Marks = marks;              
        }
    }
}