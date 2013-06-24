using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{
    public class Accessoire : Product
    {
        private string accessoireName;

        public Accessoire(int price, string accessoireName) 
            : base(price)   
        {
            this.accessoireName = accessoireName;
        }

        public string AccessoireName
        {
            get
            {
                return this.accessoireName;
            }
            set
            {
                this.accessoireName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Accessoire:{0} , price:{1}", this.accessoireName, this.price);
        }
    }
}
