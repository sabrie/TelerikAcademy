using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.WcfServiceStringOccurrencesCounter.Client
{
    class Client
    {
        static void Main()
        {
            ServiceStringOccurrencesCounterClient client = new ServiceStringOccurrencesCounterClient();

            int count = client.CountStringOccurrences("a", "aaa"); // 3

            Console.WriteLine(count);
        }
    }
}
