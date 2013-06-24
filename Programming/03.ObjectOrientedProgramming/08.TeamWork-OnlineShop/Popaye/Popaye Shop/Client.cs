using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{
    public abstract class Client : Person, INameble
    {
        protected Account clientAccount;

        private string name;

        public Client(string name)
            :base() 
        {
            this.name = name;
            this.clientAccount = new Account(0);
        }

        public Client(string name, decimal money)
            :base()
        {
            this.name = name;
            this.clientAccount = new Account(money);
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
            return string.Format("clientAccount: {0}, name: {1}", this.clientAccount, this.name);
        }
    }
}