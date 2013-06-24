using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{

    /// <summary>
    /// I think we need this because we have many objects and persons
    /// which have names not only persons
    /// </summary>
    interface INameble
    {
        string Name { get; set; }
    }
}
