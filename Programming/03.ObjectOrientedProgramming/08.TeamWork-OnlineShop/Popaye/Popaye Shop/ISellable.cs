using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{
    public interface ISellable
    {
        //void SellProduct();

        int Price { get; set; }

        event EventHandler OnSellProduct;
    }
}