/* Write a program that reads from the console a positive 
 * integer number N (N < 20) and outputs a matrix like the following:
 * N = 3
 * 1 2 3
 * 2 3 4
 * 3 4 5
*/
using System;

class PrintMatrixByGivenN
{
    static void Main()
    {
        Console.WriteLine("This program prints a matrix with rows and columns from 1 to N.");
        Console.Write("Enter a positiv integer for N < 20: ");
        sbyte n = sbyte.Parse(Console.ReadLine());

        if (n > 0 && n < 20)
        {
            for (int row = 1; row <= n; row++)
            {
                for (int i = 0; i < n; i++)
                {
                    int col = row + i;
                    Console.Write("{0,4}", col);
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Enter a number in the range [1...19]");
        }
    }
}

