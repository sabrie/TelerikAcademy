/*  Write a boolean expression that returns if 
 * the bit at position p (counting from 0) in a 
 * given integer number v has value of 1. 
 * Example: v=5; p=1 -> false.
 */
using System;

class CheckIfBitAtPositionPIsOne
{
    static void Main()
    {
        int p = 1;                  // position of the bit
        int v = 5;                 // integer number
        int mask = 1 << p;          // 1<<p moves the bits of number 1 with p positions to the left
        int nAndMask = v & mask;    
        
        
        if ((v & mask) != 0)
        {
            Console.WriteLine("The bit at position {0} in number {1} is 1 -> {2}", p, v, true);
            Console.WriteLine(Convert.ToString(v, 2).PadLeft(8, '0')); // prints integer 'v' in binary
        }
        else
        {
            Console.WriteLine("The bit at position {0} in number {1} is 1 -> {2} ", p, v, false);
            Console.WriteLine(Convert.ToString(v, 2).PadLeft(8, '0'));
        }
    }
}

