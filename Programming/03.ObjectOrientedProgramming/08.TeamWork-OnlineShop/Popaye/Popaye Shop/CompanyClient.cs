using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{
    public class CompanyClient : Client
    {
        private string ownerName;

        public CompanyClient(string name) 
            : this(name, null)
        {
        }

        public CompanyClient(string name, string ownerName)
            : base(name)
        {
        }

        public string OwnerName
        {
            get
            {
                return this.ownerName;
            }
            set
            {
                this.ownerName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("The company name is {0} and it's owner is {1}", this.Name, this.ownerName);
        }
    }
}
