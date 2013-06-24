/* Write a boolean expression for finding if 
 * the bit 3 (counting from 0) of a given 
 * integer is 1 or 0.
 */
using System;

class CheckBitAtPosition3
{
    static void Main()
    {
        int p = 3;
        int n = 8;
        int mask = 1 << p;
        int nAndMask = n & mask;

        Console.Write("The bit at position {0} of number {1} is ", p, n);

        if (nAndMask == 8)
        {
            Console.WriteLine("1 -> {1}.", n, (Convert.ToString(n, 2).PadLeft(8, '0')));
        }
        else
        {
            Console.WriteLine("0 -> {1}", n, (Convert.ToString(n, 2).PadLeft(8, '0')));
        }
    }
}

