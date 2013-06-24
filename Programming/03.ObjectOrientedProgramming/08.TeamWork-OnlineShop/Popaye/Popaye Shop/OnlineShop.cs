using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{
    public class OnlineShop
    {        
        private List<Worker> workerList = new List<Worker>();

        private List<Client> clientList = new List<Client>();

        private List<Product> productList = new List<Product>();

        // design pattern Singleton - create a static instance of this class
        private static OnlineShop onlineShop;

        private SoldProducts onlineShopSoldProducts = new SoldProducts();
        
        /// <summary>
        /// If there are no products in the shop we need to add more products
        /// </summary>
        public event EventHandler OnEmpthyShop;

        /// <summary>
        /// When we create the shop we don't have anything.
        /// </summary>
        // the constructor is private so that we cannot workarround the method Instance(); 
        // and create another instance of this class
        private OnlineShop()
        {
        }

        // design pattern - Singleton
        // this is the creation method - we create instance of the class using this method
        // if we already have an instance - the method returns the instance
        public static OnlineShop Instance()
        {
            if (null == onlineShop)
                onlineShop = new OnlineShop();

            return onlineShop;
        }

        #region Properties

        public List<Product> ProductList
        {
            get
            {
                return this.productList;
            }
            private set
            {
                this.productList = value;
            }
        }

        public List<Client> ClientList
        {
            get
            {
                return this.clientList;
            }
            private set
            {
                this.clientList = value;
            }
        }

        public List<Worker> WorkerList
        {
            get
            {
                return this.workerList;
            }
            private set
            {
                this.workerList = value;
            }
        }

        public SoldProducts OnlineShopSoldProducts
        {
            get
            {
                return this.onlineShopSoldProducts;
            }
        }

        #endregion

        /// <summary>
        /// Adds the worker.
        /// </summary>
        /// <param name="hiredWorker">The hired worker.</param>
        public void AddWorker(Worker hiredWorker)
        {
            if (this.workerList.Contains(hiredWorker))
            {
                throw new PopayeShopException("We cannot hire the same person twice");
            }

            this.workerList.Add(hiredWorker);
        }

        /// <summary>
        /// Removes the worker.
        /// </summary>
        /// <param name="hiredWorker">The hired worker.</param>
        public void RemoveWorker(Worker hiredWorker)
        {
            if (this.workerList.Contains(hiredWorker))
            {
                this.workerList.Remove(hiredWorker);
            }
            else
            {
                throw new PopayeShopException("Wrong data entered...This worker doesnt exist");
            }
        }

        /// <summary>
        /// Adds the client.
        /// </summary>
        /// <param name="joinedClient">The joined client.</param>
        public void AddClient(Client joinedClient)
        {
            if (this.clientList.Contains(joinedClient))
            {
                throw new PopayeShopException("We cannot add the same person twice");
            }

            this.clientList.Add(joinedClient);
        }

        /// <summary>
        /// Removes the client.
        /// </summary>
        /// <param name="joinedClient">The joined client.</param>
        public void RemoveClient(Client joinedClient)
        {
            if (this.clientList.Contains(joinedClient))
            {
                this.clientList.Remove(joinedClient);
            }
            else
            {
                throw new PopayeShopException("Wrong data entered...This client doesnt exist");
            }
        }

        /// <summary>
        /// Adding products to the list. Here we can have many of the same product
        /// </summary>
        /// <param name="addedProduct"></param>
        public void AddProduct(Product addedProduct)
        {
            this.productList.Add(addedProduct);
        }
        
        /// <summary>
        /// Removes the product.
        /// </summary>
        /// <param name="productInStock">The product in stock.</param>
        public void RemoveProduct(Product productInStock)
        {
            if (this.productList.Count == 0)
            {
                if (this.OnEmpthyShop != null)
                {
                    this.OnEmpthyShop(this, EventArgs.Empty );
                }                
            }
            else if (this.productList.Contains(productInStock))
            {
                this.productList.Remove(productInStock);
                this.OnlineShopSoldProducts.AddProductToSoldProducts(productInStock);
            }
            else
            {
                throw new PopayeShopException("Wrong data entered or the product isnt in stock");
            }
        }

        /// <summary>
        /// Removes all products from the shop.
        /// </summary>
        public void ClearProductList()
        {
            this.productList.Clear();
        }

        /// <summary>
        /// Clears the client list.
        /// </summary>
        public void ClearClientList()
        {
            this.clientList.Clear();
        }

        /// <summary>
        /// Clears the worker list.
        /// </summary>
        public void ClearWorkerList()
        {
            this.workerList.Clear();
        }

        /// <summary>
        /// Clears the online shop.
        /// </summary>
        public void ClearOnlineShop()
        {
            this.ClearClientList();
            this.ClearProductList();
            this.ClearWorkerList();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int index = 0; index < clientList.Count; index++)
            {
                result.AppendLine(clientList[index].ToString());
                
            }
            
            for (int index = 0; index < workerList.Count; index++)
            {
                result.AppendLine(workerList[index].ToString());
                
            }
            
            for (int index = 0; index < productList.Count; index++)
            {
                result.AppendLine(productList[index].ToString());
            }

            return result.ToString(); 
        }
    }
}



