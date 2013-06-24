using System;
using System.Linq;
using System.Collections.Generic;

namespace SchoolHomework
{
    public class School
    {
        List<Student> students = new List<Student>();

        public void AddStudent(Student student) {
            if (this.students.Any(currentStudent => currentStudent.Id == student.Id))
            {
                throw new InvalidOperationException("Duplicated Id!");
            }

            this.students.Add(student);
        }
    }
}
