using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{
    public class Television : Product
    {
        private int tvDisplaySize;

        private readonly TelevisionType typeOfTelevision;

        //Constructors
        public Television(int price, string model, string manufacturer, int tvDisplaySize, TelevisionType type) : base(price, model, manufacturer)
        {
            this.tvDisplaySize = tvDisplaySize;
            this.typeOfTelevision = type;
        }

        public Television(int price, string model, string manufacturer, List<string> comments, int tvDisplaySize, TelevisionType type) : base(price, model, manufacturer, comments)
        {
            this.tvDisplaySize = tvDisplaySize;
            this.typeOfTelevision = type;
        }

        //Properties
        public int TvDisplaySize
        {
            get
            {
                return this.tvDisplaySize;
            }
            set
            {
                this.tvDisplaySize = value;
            }
        }

        public TelevisionType TypeOfTelevision
        {
            get
            {
                return this.typeOfTelevision;
            }
        }

        //Methods
        public override string ToString()
        { 
            return string.Format("TV Model: {0}, Manufacturer: {1}, Price: {2} lv\n Display Size: {3}, Type: {4}\n comments: {5}",
                this.name, this.manufacturer, this.price, this.tvDisplaySize, this.typeOfTelevision, this.comments);
        }
    }
}