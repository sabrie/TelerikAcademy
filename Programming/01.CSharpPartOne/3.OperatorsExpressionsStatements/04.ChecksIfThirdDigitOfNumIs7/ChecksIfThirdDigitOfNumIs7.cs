/* Write an expression that checks for given integer 
 * if its third digit (right-to-left) is 7. 
 * E. g. 1732 -> true.
 */
using System;

class ChecksIfThirdDigitOfNumIs7
{
    static void Main()
    {
        int integerNumber = 1732;
        int divisionBy100 = integerNumber / 100;
        int remainder = divisionBy100 % 10;

        Console.Write("The third digit of the number {0} (right-to-left) is 7: ", integerNumber);

        if (remainder == 7)
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}

