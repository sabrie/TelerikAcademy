using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{
    /// <summary>
    /// Used to show the products we have sold and with it we 
    /// can calculate the profit of our online shop.
    /// </summary>
    public class SoldProducts
    {
        private readonly List<Product> soldProductsList;

        private decimal onlineShopProfit;

        public event EventHandler OnSoldProduct;

        public SoldProducts()
        {
            soldProductsList = new List<Product>();
            onlineShopProfit = 0;
        }

        public decimal OnlineShopProfit
        {
            get
            {
                return this.onlineShopProfit;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The price of the product cannot be negative");
                }
                this.onlineShopProfit += value;
            }
        }

        public List<Product> SoldProductsList
        {
            get
            {
                return this.soldProductsList;
            }
        }

        public void AddProductToSoldProducts(Product soldProduct)
        {
            this.soldProductsList.Add(soldProduct);
            this.OnlineShopProfit += soldProduct.Price;

            if (this.OnSoldProduct != null)
            {
                this.OnSoldProduct(this, EventArgs.Empty);
            }
        }
    }
}
