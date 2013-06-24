/* Write a program that exchanges bits 3, 4 and 5 
 * with bits 24, 25 and 26 of given 32-bit unsigned integer.
 */
using System;

class ExchangeBitsOfInteger
{
    static void Main()
    {
        int n = 2147418112;
        int mask = 7;
        int getFirstBits = (7 << 3) & n;
        int getSecondBits = (7 << 24) & n;
        getFirstBits = getFirstBits << 21; 
        getSecondBits = getSecondBits >> 21; 

        n = n & (~(mask << 3)); 
        Console.WriteLine(Convert.ToString(n, 2));
        n = n & (~(mask << 21)); 
        Console.WriteLine(Convert.ToString(n, 2));
        n = n | getFirstBits; 
        Console.WriteLine(Convert.ToString(n, 2));
        n = n | getSecondBits; 
        Console.WriteLine(Convert.ToString(n, 2));
        Console.WriteLine(n);
    }
}

