/* Write a program that reads a number and prints it as a decimal number, 
 * hexadecimal number, percentage and in scientific notation. 
 * Format the output aligned right in 15 symbols.
*/
using System;

class FormatStrInDecHexPercAlign
{
    static void Main()
    {
        int number = 42;

        string numInDec = number.ToString("D");
        Console.WriteLine("{0,15}", numInDec);

        string numInHex = number.ToString("X");
        Console.WriteLine("{0,15}", numInHex);

        double doubleNum = 0.2567;

        string numPercentage = doubleNum.ToString("P");
        Console.WriteLine("{0,15}", numPercentage);

        string numScientificNo = doubleNum.ToString("E2");
        Console.WriteLine("{0,15}", numScientificNo);
    }
}

