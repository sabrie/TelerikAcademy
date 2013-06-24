using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{
    /// <summary>
    /// A class used to make operations with the money of a client
    /// </summary>
    public struct Account
    {
        private decimal money;

        public Account(decimal money)
        {
            this.money = money;
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
                this.money = value;
            }
        }

        /// <summary>
        /// The client can add money to his account.
        /// </summary>
        /// <param name="money"></param>
        public void AddMoney(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentOutOfRangeException("The added money cannot be negative value");
            }

            this.money += money;
        }
        
        /// <summary>
        /// When the client buys a product from the store. 
        /// </summary>
        /// <param name="money"></param>
        public void UseMoney(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentOutOfRangeException("The used money cannot be negative value");
            }
            else if (money > this.money)
            {
                throw new ArgumentOutOfRangeException("The client cannot spend more money then he has");
            }

            this.money -= money;           
        }

        public override string ToString()
        {
            return string.Format("The client has {0} money", this.money);
        }
    }
}