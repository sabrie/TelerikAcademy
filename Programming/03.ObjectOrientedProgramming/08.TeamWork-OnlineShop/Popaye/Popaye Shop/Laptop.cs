using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{
    
    public class Laptop : ElectronicProduct
    {
        private int displaySize;

        private string processor;

        private int ramMemory;

        private string video;

        private readonly DisplayType typeOfLaptopDisplay;

        //Constructors
        public Laptop(int price, string model, string manufacturer, int displaySize, string processor, int ramMemory, string video, DisplayType type) 
            : base(price, model, manufacturer)
        {
            this.displaySize = displaySize;
            this.processor = processor;
            this.ramMemory = ramMemory;
            this.video = video;
            this.typeOfLaptopDisplay = type;
        }

        //Properties
        public int DisplaySize
        {
            get
            {
                return this.displaySize;
            }
            set
            {
                this.displaySize = value;
            }
        }
        public string Processor
        {
            get
            {
                return this.processor;
            }
            set
            {
                this.processor = value;
            }
        }
        public int RamMemory
        {
            get
            {
                return this.ramMemory;
            }
            set
            {
                this.ramMemory = value;
            }
        }
        public string Video
        {
            get
            {
                return this.video;
            }
            set
            {
                this.video = value;
            }
        }
        public DisplayType TypeOfLaptopDisplay
        {
            get
            {
                return this.typeOfLaptopDisplay;
            }
        }

        //Methods
        public override string ToString()
        {
            return string.Format("Laptop Model: {0}, Manufacturer: {1}, Price: {2} lv\n Display Size: {3}, Type: {4}\n" +
            "Processor: {5}, Ram Memory: {6} GB, Video: {7} \n comments: {8}", this.name, this.manufacturer, this.price, 
            this.displaySize, this.typeOfLaptopDisplay,this.processor, this.ramMemory, this.video, this.comments);
        }
    }
}
