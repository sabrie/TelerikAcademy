using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{

    public class Phone : Product
    {
        private string operatingSystem;

        private BatteryType typeOfBattery;

        //Constructors
        public Phone(int price, string model, string manufacturer, string operatingSystem, BatteryType typeOfBattery)
            : base(price, model, manufacturer)
        {
            this.operatingSystem = operatingSystem;
            this.typeOfBattery = typeOfBattery;
        }

        //Properties
        public string OperatingSystem
        {
            get
            {
                return this.operatingSystem;
            }
            set
            {
                this.operatingSystem = value;
            }
        }
        public BatteryType TypeOfBattery
        {
            get
            {
                return this.typeOfBattery;
            }
        }

        //Methods
        public override string ToString()
        {
            return string.Format("Phone Model:{0} , Manufacturer:{1}\nBattery Model:{2} , OS:{3} , price:{4}",
                this.name, this.manufacturer, this.typeOfBattery, this.operatingSystem, this.price);
        }
    }
}
