using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Number { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Homework>  Homeworks { get; set; }

        public Student()
        {
            this.Courses = new List<Course>();
            this.Homeworks = new List<Homework>();
        }
    }
}
