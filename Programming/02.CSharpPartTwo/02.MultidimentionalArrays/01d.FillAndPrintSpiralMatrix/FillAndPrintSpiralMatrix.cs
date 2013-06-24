/* *Write a program that reads a positive integer number N (N < 20) 
 * from console and outputs in the console the numbers 1 ... N numbers 
 * arranged as a spiral.
 * Example for N = 4
 *  1  12  11  10
 *  2  13  16  9
 *  3  14  15  8
 *  4   5   6  7  
*/
using System;

class FillAndPrintSpiralMatrix
{
    static void Main()
    {
        Console.WriteLine("This program prints a spiral matrix from 1 to N*N.");
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine()); // n*n defines the number of matrix elements
        int a = 1; // defines the number of elements we print in the for loop
        int x = 1; // we assign to x the values from 1 to n*n -> x = 1 ... n*n
        int row = 0; // matrix rows 
        int col = -1; // matrix columns
        int[,] spiral = new int[n, n];

        for (int i = 0; i < n; i++) // input the value of elements in the first row
        {
            col = col + 1;
            spiral[row, col] = x;
            x = x + 1;
        }

        for (int j = x + 1; x < n * n; j++)
        {
            for (int i = 0; i < n - a; i++) // input the elements in column col
            {
                row = row + 1;
                spiral[row, col] = x;
                x = x + 1;
            }

            for (int i = 0; i < n - a; i++) // input the elements in row
            {
                col = col - 1;

                spiral[row, col] = x;
                x = x + 1;
            }
            a = a + 1;

            for (int i = 0; i < n - a; i++) // input the elements in column col
            {
                row = row - 1;

                spiral[row, col] = x;
                x = x + 1;
            }

            for (int i = 0; i < n - a; i++) // input the elements in row
            {
                col = col + 1;
                spiral[row, col] = x;
                x = x + 1;
            }
            a = a + 1;
        }

        // Prints the matrix
        for (row = 0; row < n; row++)
        {
            for (col = 0; col < n; col++)
            {
                Console.Write("{0,4}", spiral[row, col]);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
