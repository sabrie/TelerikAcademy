/*Write a program that prints an isosceles triangle of 9 copyright symbols ©. 
 * Use Windows Character Map to find the Unicode code of the © symbol. 
 * Note: the © symbol may be displayed incorrectly.
 */
using System;
using System.Text;
using System.Globalization;
using System.Threading;

class PrintTriangleOfCopyrightSymbols
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        char copyright = '\u00A9';
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("{0,8}", copyright);
        Console.WriteLine("{0,6}{0,4}", copyright);
        Console.WriteLine("{0,4}{0,8}", copyright);
        Console.WriteLine("{0,2}{0,4}{0,4}{0,4}", copyright);

        //Console.WriteLine(@"       {0}", copyright);
        //Console.WriteLine(@"     {0}   {1}", copyright, copyright);
        //Console.WriteLine(@"   {0}       {1}", copyright, copyright);
        //Console.WriteLine(@" {0}   {1}   {2}   {3}", copyright, copyright, copyright, copyright);
    }
}
