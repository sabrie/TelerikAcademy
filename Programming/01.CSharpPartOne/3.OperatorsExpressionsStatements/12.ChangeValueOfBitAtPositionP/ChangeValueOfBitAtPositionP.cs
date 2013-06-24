/* We are given integer number n, value v (v=0 or 1) and a position p. 
 * Write a sequence of operators that modifies n to hold the value v 
 * at the position p from the binary representation of n.
	Example: n = 5 (00000101), p=3, v=1 -> 13 (00001101)
	n = 5 (00000101), p=2, v=0 -> 1 (00000001)
 */
using System;

class ChangeValueOfBitAtPositionP
{
    static void Main()
    {
        // Set the bit at position p to 0 in a number n
        int p = 2;
        int n = 5;
        int mask = ~(1 << p);
        int result = n & mask;
        
        Console.WriteLine("Set the bit at position {0} to value 0 in the number {1} ({2})", p, n, Convert.ToString(n, 2).PadLeft(8, '0'));
        Console.WriteLine("The result is -> {0} ({1})", result, Convert.ToString(result, 2).PadLeft(8, '0'));

        Console.WriteLine();

        // Set the bit at position p to 1 in a number n
        p = 3;
        n = 5;
        mask = 1 << p;
        result = n | mask;
        Console.WriteLine("Set the bit at position {0} to value 1 in the number {1} ({2})", p, n, Convert.ToString(n, 2).PadLeft(8, '0'));
        Console.WriteLine("The result is -> {0} ({1})", result, Convert.ToString(result, 2).PadLeft(8, '0'));
    }
}

