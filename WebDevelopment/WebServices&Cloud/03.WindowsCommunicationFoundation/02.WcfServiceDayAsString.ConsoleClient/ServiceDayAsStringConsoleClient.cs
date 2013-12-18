/*
 * Task 2
 Create a console-based client for the WCF service above. 
 Use the "Add Service Reference" in Visual Studio. 
 */
using _02.WcfServiceDayAsString.ConsoleClient.ServiceReferenceDayAsString;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.WcfServiceDayAsString.ConsoleClient
{
    class ServiceDayAsStringConsoleClient
    {
        static void Main()
        {
            ServiceDayAsStringClient client = new ServiceDayAsStringClient();

            string dayAsString = client.PrintDayAsString(new DateTime(2013, 5, 17));

            Console.WriteLine(dayAsString); // Петък
        }
    }
}
