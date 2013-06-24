/* Write a program that fills and prints a matrix of size (n, n) as shown below: 
 * (examples for n = 4)
 * 1  8  9  16
 * 2  7  10 15
 * 3  6  11 14
 * 4  5  12 13
*/
using System;

class FillAndPrintAMatrix
{
    static void Main()
    {

        int n = 4;
        int[,] matrix = new int[n, n];

        int counter = 1;

        for (int cols = 0; cols < n; cols++)
        {
            for (int rows = 0; rows < n; rows++)
            {
                // fills the even cols from top to bottom
                if (cols % 2 == 0)
                {
                    matrix[rows, cols] = counter;
                    counter++;
                }
                // even odds - fills the array from 
                else
                {
                    matrix[n - rows - 1, cols] = counter;
                    counter++;
                }
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

