/* Write a program that reads a rectangular matrix of size N x M and 
 * finds in it the square 3 x 3 that has maximal sum of its elements.
*/
using System;

class Square3x3InMatrixWithMaxSum
{
    static void Main()
    {
        // creat and initialize a matrix
        int[,] matrix = new int[,] {

        {1, 2, 15, 6, 8, 7},
        {1, 2, 2, 12, 15, 3},
        {7, 12, 3, 14, 15, 80},
        {1, 4, 3, 14, 22, 12}

        };

        int bestSum = int.MinValue;
        int currentSum = 0;
        int bestCol = 0;
        int bestRow = 0;

        for (int rowIndex = 0; rowIndex < matrix.GetLength(0) - 2; rowIndex++)
        {
            for (int colIndex = 0; colIndex < matrix.GetLength(1) - 2; colIndex++)
            {
                currentSum = matrix[rowIndex, colIndex] + matrix[rowIndex, colIndex + 1] + matrix[rowIndex, colIndex + 2] + 
                    matrix[rowIndex + 1, colIndex] + matrix[rowIndex + 1, colIndex + 1] + matrix[rowIndex + 1, colIndex + 2] +
                    matrix[rowIndex + 2, colIndex] + matrix[rowIndex + 2, colIndex + 1] + matrix[rowIndex + 2, colIndex + 2];
                if (currentSum > bestSum)
                {
                    bestSum = currentSum;
                    bestCol = colIndex;
                    bestRow = rowIndex;
                }
            }
        }

        // print the 3x3 square of the matrix with best sum
        Console.WriteLine("The square 3x3 of the matrix with maximal sum of its elements is: ");
        for (int row = bestRow; row < bestRow + 3; row++)
        {
            for (int col = bestCol; col < bestCol + 3; col++)
            {
                Console.Write("{0,3}", matrix[row, col]);
            }
            Console.WriteLine();
        }

        Console.WriteLine();

        //// another way to print the 3x3 square of the matrix with best sum
        //Console.Write("{0, 3}", matrix[bestRow, bestCol]);
        //Console.Write("{0, 3}", matrix[bestRow, bestCol + 1]);
        //Console.Write("{0, 3}", matrix[bestRow, bestCol + 2]);
        //Console.WriteLine();
        //Console.Write("{0, 3}", matrix[bestRow + 1, bestCol]);
        //Console.Write("{0, 3}", matrix[bestRow + 1, bestCol + 1]);
        //Console.Write("{0, 3}", matrix[bestRow + 1, bestCol + 2]);
        //Console.WriteLine();
        //Console.Write("{0, 3}", matrix[bestRow + 2, bestCol]);
        //Console.Write("{0, 3}", matrix[bestRow + 2, bestCol + 1]);
        //Console.Write("{0, 3}", matrix[bestRow + 2, bestCol + 2]);
        //Console.WriteLine();
    }
}

