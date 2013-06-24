using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AlgorithmsComplexity
{
    static void Main()
    {
        // 01. O(n^2)
        int[] arr = { 25, 4, 10, 4, 25, 4, 10, 4, 25, 4, 10, 4 };
        long steps = Compute(arr);
        Console.WriteLine("First algorythm");
        Console.WriteLine("Array size 'n' = " + arr.Length);
        Console.WriteLine("Execution steps: " + steps);
        Console.WriteLine("Complexity: O(n^2)");
        Console.WriteLine();

        // 02. Test for the worst-case - O(n*m)
        int[,] matrix = 
        {
            { 12, 4, 10, 4, 25, 4 },
            { 12, 4, 10, 4, 25, 4 },
            { 12, 4, 10, 4, 25, 4 },
            { 12, 4, 10, 4, 25, 4 },
            { 12, 4, 10, 4, 25, 4 },
            { 12, 4, 10, 4, 25, 4 },
        };

        steps = CalcCount(matrix);
        Console.WriteLine("Second algorythm");
        Console.WriteLine("Matrix size n = {0}, m = {1}",
                            matrix.GetLength(0), matrix.GetLength(0));
        Console.WriteLine("Execution steps: " + steps);
        Console.WriteLine("Complexity: ~ 2*n*m or O(n*m)");
        Console.WriteLine();

        // 03. Test for the worst-case. Assuming that n = rows = cols O(n*n)
        Console.WriteLine("Third algorythm");
        Console.WriteLine("The algorythm works only for a square matrix");
        Console.WriteLine("Matrix size n = rows = cols = {0}", matrix.GetLength(0));
        Console.WriteLine("Complexity: O(n^2)");
        
    }

    // 01. 
    // The worst-case scenario for this algorithm is O(n^2) where 'n' is the array length
    // It is clearly seen that the first loop executes 'n' times, and the inner loop executes
    // also 'n' times in the worst-case. 
    // The algorithm complexity can be checked by adding a variable 'steps' which holds the numbers of 
    // execution steps. 
    private static long Compute(int[] arr)
    {
        long steps = 0;
        long count = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            steps++;
            int start = 0, end = arr.Length - 1;
            while (start < end)
            {
                if (arr[start] < arr[end])
                {
                    start++;
                    count++;
                    steps++;
                }
                else
                {
                    end--;
                    steps++;
                }
            }
        }

        return steps;
    }

    // 02. 
    // The bets-case is when the first number of each row is odd
    // then the algorithms will be executed for 'n' steps  - O(n) 
    // where 'n' is the number of matrix rows. It is because in 
    // this scenario we will never enter the inner loop
    //
    // The worst scenario is when the first number of each row is 
    // even and then we will enter the inner loop on each iteration of 
    // the outer loop - so the algorythms will be executed for 
    // approximately n * m steps O(n*m) - where 'm' is the number of matrix cols
    //
    // The algorithm complexity can be checked by adding a variable 'steps' which holds the numbers of 
    // execution steps.
    private static long CalcCount(int[,] matrix)
    {
        long steps = 0;
        long count = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            steps++;
            if (matrix[row, 0] % 2 == 0)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    steps++;
                    if (matrix[row, col] > 0)
                    {
                        steps++;
                        count++;
                    }
                }
            }
        }

        return steps;
    }

    // 03.
    // The algorithm works only for a square matrix which is
    // a matrix with the same number of rows and columns => rows = cols = n.
    //
    // The best-case is when we pass as parameter the last row, then the loop
    // will iterate over the cols of the last row and the if statement and the recursion
    // will not be executed. 
    // So the program will be executed for O(n) steps
    //
    // The worst-case is when we pass as parameter the first row, then the program
    // will iterate over the cols of each row recursively and 
    // will be executed for n*n steps O(n^2) where n = rows = cols
    private static long CalcSum(int[,] matrix, int row)
    {
        long sum = 0;
        for (int col = 0; col < matrix.GetLength(0); col++)
        {
            sum += matrix[row, col];
        }
        if (row + 1 < matrix.GetLength(1))
        {
            sum += CalcSum(matrix, row + 1);
        }
        return sum;
    }
}

