using System;
using System.Collections.Generic;

namespace SchoolHomework
{
    public class Course
    {
        private const int Capacity = 30;

        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            if (!(this.students.Count < Course.Capacity))
            {
                throw new InvalidOperationException("Course is full!");
            }

            if (this.students.Contains(student))
            {
                throw new ArgumentException("Student already added!");
            }

            this.students.Add(student);
        }

        public bool RemoveStudent(Student student)
        {
            return this.students.Remove(student);
        }
    }
}
