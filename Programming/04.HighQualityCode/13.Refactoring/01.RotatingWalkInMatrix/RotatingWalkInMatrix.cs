using System;
using System.Linq;

class RotatingWalkInMatrix
{
    static void Main(string[] args)
    {
        int n = 6;
        int[,] matrix = new int[n, n];

        int currentDirectionX = 1;
        int currentDirectionY = 1;

        MatrixManager.FillMatrixRotating(matrix, ref currentDirectionX, ref currentDirectionY);
        MatrixManager.PrintMatrix(matrix); 
    }
}
