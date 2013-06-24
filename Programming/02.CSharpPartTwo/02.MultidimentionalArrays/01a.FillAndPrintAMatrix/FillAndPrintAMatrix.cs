/* Write a program that fills and prints a matrix of size (n, n) as shown below: 
 * (examples for n = 4)
 * 1  5  9  13
 * 2  6  10 14
 * 3  7  11 15
 * 4  8  12 16
*/
using System;

class FillAndPrintAMatrix
{
    static void Main()
    {
        int n = 4;
        int i = 1;

        int[,] matrix = new int[n,n];

        for (int cols = 0; cols < n; cols++)
        {
            for (int rows = 0; rows < n; rows++)
            {
                //matrix[rows, cols] = cols * n + rows + 1;
                matrix[rows, cols] = i;
                i++;
            }
        }

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0,3}", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}

