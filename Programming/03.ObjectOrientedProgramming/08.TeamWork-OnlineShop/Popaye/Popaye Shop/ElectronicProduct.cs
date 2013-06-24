using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{
    public abstract class ElectronicProduct : Product
    {
        public ElectronicProduct(int price, string model, string manufacturer)
            : base(price, model, manufacturer)
        {
        }
    }
}
