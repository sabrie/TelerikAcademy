using System;
using System.Linq;

namespace Telerik.ILS.Common
{
    public class StringExtensionsTest
    {
        static void Main()
        {
            // test if converts a string to its equivalent integer representation
            short a = "5".ToShort();
            int b = "4".ToInteger();

            Console.WriteLine(a + b);
            
            string getBetween = "get string between two strings";
            string result = getBetween.GetStringBetween("get", "two");
            
            Console.WriteLine(result);

            string name = "Пешо";
            Console.WriteLine(name.ConvertCyrillicToLatinLetters());

            string userName = "Пешо";
            Console.WriteLine(userName.ToValidUsername());

            Console.WriteLine(userName.GetFirstCharacters(2));

            Console.WriteLine(userName.ToMd5Hash());

            var byteArray = "dfg".ToByteArray();

            foreach (var item in byteArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}