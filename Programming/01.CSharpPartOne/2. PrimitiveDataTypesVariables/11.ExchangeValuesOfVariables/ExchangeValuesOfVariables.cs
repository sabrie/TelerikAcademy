/* Declare  two integer variables and assign them with 5 and 10 
 * and after that exchange their values.
 */
using System;

class ExchangeValuesOfVariables
{
    static void Main()
    {
        byte a = 5;
        byte b = 10;

        byte exchange = a;
        a = b;
        b = exchange;

        Console.WriteLine(a);
        Console.WriteLine(b);
    }
}

