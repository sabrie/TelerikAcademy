using System;
using System.Collections.Generic;
using System.Linq;

namespace InheritanceAndPolymorphism
{
    class LocalCourse : Course
    {        
        public string Lab { get; set; }

        public LocalCourse(string courseName, string teacherName = null, List<string> students = null, string lab = null)
            : base(courseName, teacherName)
        {
            this.Lab = lab;
        }        

        public override string ToString()
        {
            string result = "LocalCourse { " + base.ToString();

            if (this.Lab != null)
            {
                result = result + "; Lab = " + this.Lab;
            }
            result = result + " }";
            
            return result;
        }
    }
}
