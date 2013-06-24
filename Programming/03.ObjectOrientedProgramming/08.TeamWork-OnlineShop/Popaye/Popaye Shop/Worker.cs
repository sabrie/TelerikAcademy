using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{
    public class Worker : Person, INameble
    {
        protected string name;

        protected decimal salary;

        public Worker(string name, decimal salary)
            :base()
        {
            this.name = name;
            this.salary = salary;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + ((name != null) ? this.name.GetHashCode() : 0);
                result = result * 23 + this.salary.GetHashCode();
                return result;
            }
        }

        public bool Equals(Worker value)
        {
            if (ReferenceEquals(null, value))
            {
                return false;
            }
            if (ReferenceEquals(this, value))
            {
                return true;
            }
            return Equals(this.name, value.name) &&
                   this.salary == value.salary;
        }

        public override bool Equals(object obj)
        {
            Worker temp = obj as Worker;
            if (temp == null)
            {
                return false;
            }
          
            if (temp.name == this.name  )
            {
                return true;
            }
            return false;
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                this.salary = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public override string ToString()
        {
            return string.Format("The workers name is: {0}, with salary: {1}", name, salary, Salary, Name);
        }
    }
}
