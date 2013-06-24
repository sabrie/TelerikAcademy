using System;
using System.Collections.Generic;
using System.Linq;

namespace InheritanceAndPolymorphism
{
    class OffsiteCourse : Course
    {
        public string Town { get; set; }

        public OffsiteCourse(string courseName, string teacherName = null, List<string> students = null, string town = null)
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }
     
        public override string ToString()
        {
            string result = "OffsiteCourse { " + base.ToString();

            if (this.Town != null)
            {
                result = result + "; Town = " + this.Town;
            }
            result = result + " }";
            
            return result;
        }
    }
}
