using System;

namespace SchoolHomework
{
    public class Student
    {
        private string name = null;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name is null or empty!");
                }

                this.name = value;
            }
        }

        private int id = 0;
        public int Id
        {
            get { return this.id; }
            set
            {
                if (!(10000 <= value && value <= 99999))
                {
                    throw new ArgumentOutOfRangeException("Id should be in the range [10 000 - 99 999]");
                }

                this.id = value;
            }
        }

        public Student(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }
    }
}
