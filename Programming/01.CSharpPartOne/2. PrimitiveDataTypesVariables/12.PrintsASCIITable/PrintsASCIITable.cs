/*Find online more information about ASCII (American Standard Code for Information 
 * Interchange) and write a program that prints the entire ASCII table of characters 
 * on the console.
 */
using System;
using System.Text;
using System.Globalization;
using System.Threading;

class PrintsASCIITable
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.OutputEncoding = Encoding.ASCII;
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine(new string('-', 25) + 
                           "\nDEC\tHEX\tCHAR\n" 
                           + new string('-', 25)); // Prints the title of the table - DEC HEX CHAR

        for (int i = 0; i < 256; i++)
        {
            //string hex = i.ToString("X"); // Converts into hex format
            Console.WriteLine("{0}\t{0:X}\t{1}", i, (char)i); // This prints the ASCII table
        }
    }
}

