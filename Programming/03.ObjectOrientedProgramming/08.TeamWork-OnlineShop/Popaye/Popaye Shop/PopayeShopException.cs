using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{
    class PopayeShopException : Exception
    {
        public PopayeShopException()
        {
        }

        public PopayeShopException(string message)
            :base(message)
        {            
        }

        public PopayeShopException( string message, Exception innerException)
            : base(message, innerException)
        {         
        }
    }
}
