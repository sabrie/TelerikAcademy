using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{
    public abstract class Product : ICommentable, INameble, ISellable
    {
        protected int price;

        protected List<string> comments;

        protected string name;

        protected string manufacturer;

        public event EventHandler OnSellProduct;

        //Constructors
        public Product()
        {
        }

        public Product(int price) 
            : this(price, null, null)
        {
            this.price = price;
        }

        public Product(int price, string model, string manufacturer)
        {
            this.price = price;
            this.name = model;
            this.manufacturer = manufacturer;
        }

        public Product(int price, string model, string manufacturer, List<string> comments)
        {
            this.price = price;
            this.name = model;
            this.manufacturer = manufacturer;
            if (comments != null)
            {
                this.comments = new List<string>(comments);
            }
            else
            {
                this.comments = new List<string>();
            }
        }
    
        //Properties
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

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                this.manufacturer = value;
            }
        }

        public List<string> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

        public int Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }
        //public abstract void SellProduct();
    }
}