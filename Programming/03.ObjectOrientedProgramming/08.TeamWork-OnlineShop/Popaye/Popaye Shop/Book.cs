using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{
    public class Book : Product
    {
        private string author;

        private string bookTitle;

        //Constructors
        public Book(int price, string author, string bookTitle) : base(price)
        {
            this.author = author;
            this.bookTitle = bookTitle;
        }

        //Properties
        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                this.author = value;
            }
        }
        public string BookTitle
        {
            get
            {
                return this.bookTitle;
            }
            set
            {
                this.bookTitle = value;
            }
        }

        //Methods
        public override string ToString()
        {
            return string.Format("Book Title:{0} , Author:{1} , price:{2}", this.bookTitle, this.author, this.price);
        }
    }
}
