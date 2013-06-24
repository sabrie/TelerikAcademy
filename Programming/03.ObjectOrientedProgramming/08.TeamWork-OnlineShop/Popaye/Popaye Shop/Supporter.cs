using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{
    /// <summary>
    /// If there are any problems with the online shop
    /// </summary>
    public class Supporter : Worker
    {      
        public Supporter(string name, decimal salary) 
            : base(name, salary)
        {
        }
    }
}
