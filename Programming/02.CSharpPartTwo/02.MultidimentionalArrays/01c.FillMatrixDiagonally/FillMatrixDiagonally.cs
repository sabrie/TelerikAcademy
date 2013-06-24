/* Write a program that fills and prints a matrix of size (n, n) as shown below: 
 * (examples for n = 4)
 * 7  11  14  16
 * 4   8  12  15
 * 2   5   9  13
 * 1   3   6  10
*/
using System;

class FillMatrixDiagonally
{
    static void Main()
    {
        int n = 4;
        int sum1ToN = 1;
        for (int i = 1; i < n; i++)
        {
            sum1ToN = sum1ToN + i;
        }

        int[,] matrix = new int[n,n];
        // topLeftNum is the number at position [0,0] and it is equal to the sum of numbers from 1 to N
        int topLeftNum = sum1ToN;

        // fill the top-right part of the matrix starting from position [0,0], then [1,1], [2,2] ...
        for (int i = 0; i < n; i++)
        {
            for (int rows = 0, cols = i; cols < n; rows++, cols++)
            {
                matrix[rows, cols] = topLeftNum;
                topLeftNum++;
            }
        }

        // fill the bottom-left part of the matrix starting from the bottom
        int startNum = sum1ToN - 1;
        for (int i = n - 2; i >= 0; i--)
        {
            for (int row = n-1, col = i; col >= 0; row--, col--)
            {
                matrix[row, col] = startNum;
                startNum--;
            }
        }

        // print the matrix
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0,3}", matrix[row,col]);
            }
            Console.WriteLine();
        }
    }
}

