/* Write a program that reads a text file containing a square matrix of 
 * numbers and finds in the matrix an area of size 2 x 2 with a maximal 
 * sum of its elements. The first line in the input file contains the size 
 * of matrix N. Each of the next N lines contain N numbers separated by space. 
 * The output should be a single number in a separate text file. 
 * Example:
 * 4
 * 2 3 3 4
 * 0 2 3 4			17
 * 3 7 1 2
 * 4 3 3 2
*/
using System;
using System.IO;

class Sqr2x2WithMaxSum
{
    static void Main()
    { 

        string fileName = @"ReadMatrix.txt";
        StreamReader reader = new StreamReader(fileName);

        using (reader)
        {
            int n = int.Parse(reader.ReadLine().Trim());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                string[] numbers = reader.ReadLine().Split(' ');
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = int.Parse(numbers[col]);
                }
            }

            int bestSum = int.MinValue;
            int currentSum = 0;
            int bestCol = 0;
            int bestRow = 0;

            for (int rowIndex = 0; rowIndex < n -1; rowIndex++)
            {
                for (int colIndex = 0; colIndex < n - 1; colIndex++)
                {
                    currentSum = matrix[rowIndex, colIndex] + matrix[rowIndex, colIndex + 1] +
                                matrix[rowIndex + 1, colIndex] + matrix[rowIndex + 1, colIndex + 1];
                    if (currentSum > bestSum)
                    {
                        bestSum = currentSum;
                        bestCol = colIndex;
                        bestRow = rowIndex;
                    }
                }
            }

            // initialize a new instance of the class StreamWriter
            StreamWriter writer = new StreamWriter(@"Result.txt", false);

            using (writer)
            {
                int maxSum = 0;
                for (int row = bestRow; row < bestRow + 2; row++)
                {
                    for (int col = bestCol; col < bestCol + 2; col++)
                    {
                        maxSum = maxSum + matrix[row, col];
                    }
                }
                // overwrite the maximal sum in a file
                writer.WriteLine(maxSum);
            }
        }
    }
}
