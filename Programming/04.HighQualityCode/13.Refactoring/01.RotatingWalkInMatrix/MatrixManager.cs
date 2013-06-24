using System;
using System.Linq;

class MatrixManager
{
    private readonly static int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
    private readonly static int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };

    public static void FillMatrixRotating(int[,] matrix, ref int currentDirectionX, ref int currentDirectionY)
    {
        int n = matrix.GetLength(0);
        int counter = 1;
        int row = 0;
        int col = 0;

        while (true)
        {
            matrix[col, row] = counter;

            if (!IsCellVisited(matrix, col, row))
            {
                break;
            }

            while ((col + currentDirectionX >= n || col + currentDirectionX < 0 ||
                row + currentDirectionY >= n || row + currentDirectionY < 0 ||
                matrix[col + currentDirectionX, row + currentDirectionY] != 0))
            {
                ChangeCurrentDirection(ref currentDirectionX, ref currentDirectionY);
            }

            col += currentDirectionX;
            row += currentDirectionY;
            counter++;
        }

        if (row != 0 && col != 0)
        {
            currentDirectionX = 1;
            currentDirectionY = 1;

            while (true)
            {
                matrix[row, col] = counter;

                if (!IsCellVisited(matrix, row, col))
                {
                    break;
                }

                while ((row + currentDirectionX >= n || row + currentDirectionX < 0 ||
                    col + currentDirectionY >= n || col + currentDirectionY < 0 ||
                    matrix[row + currentDirectionX, col + currentDirectionY] != 0))
                {
                    ChangeCurrentDirection(ref currentDirectionX, ref currentDirectionY);
                }
                row += currentDirectionX;
                col += currentDirectionY;
                counter++;
            }
        }
    }

    private static bool IsCellVisited(int[,] arr, int row, int col)
    {
        int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };

        for (int i = 0; i < directionX.Length; i++)
        {
            if (row + directionX[i] >= arr.GetLength(0) ||
                row + directionX[i] < 0)
            {
                directionX[i] = 0;
            }

            if (col + directionY[i] >= arr.GetLength(1) ||
                col + directionY[i] < 0)
            {
                directionY[i] = 0;
            }

            if (arr[row + directionX[i], col + directionY[i]] == 0)
            {
                return true;
            }
        }

        return false;
    }

    private static void ChangeCurrentDirection(ref int currentDirectionX, ref int currentDirectionY)
    {
        int currentDirection = 0;

        for (int i = 0; i < directionX.Length; i++)
        {
            if (directionX[i] == currentDirectionX &&
                directionY[i] == currentDirectionY)
            {
                currentDirection = i;
                break;
            }
        }

        int nextStep = (currentDirection + 1) % directionX.Length;
        currentDirectionX = directionX[nextStep];
        currentDirectionY = directionY[nextStep];
    }

    public static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
                Console.Write("{0,3}", matrix[row, col]);

            Console.WriteLine();
        }
    }
}
