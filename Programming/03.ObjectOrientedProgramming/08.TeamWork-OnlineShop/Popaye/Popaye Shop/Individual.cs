using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{
    class IndividualClient : Client
    {
        public IndividualClient(string name)
            : base(name)
        {                
        }

        public override string ToString()
        {
            return String.Format("Client Name: {0}", this.Name);
        }
    }
}
