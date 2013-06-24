using System;
using System.Linq;

namespace Methods
{
    class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string OtherInfo { get; private set; }
        public DateTime BirthDate { get; private set; }

        public bool IsOlderThan(Student other)
        {
            return this.BirthDate > other.BirthDate;
        }
    }
}
