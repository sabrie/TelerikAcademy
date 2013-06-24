/* Write an expression that extracts from a given integer i 
 * the value of a given bit number b. 
 * Example: i=5; b=2 -> value=1.
 */
using System;

class ExtractValueOfBitFromInteger
{
    static void Main()
    {
        int integerNum = 5;         // 0000 0101 
        int bitNumber = 2; 
        int i = 1;                  // 0000 0001 

        int mask = i << bitNumber;  // 0000 0100

        Console.Write("The value of bit number {0} of integer number {1} is ", bitNumber, integerNum);

        if ((integerNum & mask) != 0)
        {
            Console.Write("1. -> ");
            Console.WriteLine(Convert.ToString(integerNum,2).PadLeft(8, '0'));
        }
        else
        {
            Console.Write("0. -> ");
            Console.WriteLine(Convert.ToString(integerNum, 2).PadLeft(8, '0'));
        }
    }
}

