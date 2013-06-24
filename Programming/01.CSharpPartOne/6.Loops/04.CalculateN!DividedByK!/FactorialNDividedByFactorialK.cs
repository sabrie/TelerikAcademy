// Write a program that calculates N!/K! for given N and K (1<K<N).
using System;
using System.Numerics;

class FactorialNDividedByFactorialK
{
    static void Main()
    {
        Console.WriteLine("This program calculates the expression N!/K!=? for (1<K<N).");
        Console.Write("Enter a value for K > 1: ");
        int k = int.Parse(Console.ReadLine());
        Console.Write("Enter a value for N > {0}: ", k);
        int n = int.Parse(Console.ReadLine());
        BigInteger factorial = 1;

        Console.Write("N!/K! = ");
        if (k > 1 && n > k)
        {
            for (int i = k + 1; i <= n; i++)
            {
                factorial *= i;
            }
            Console.WriteLine(factorial);
        }
        else
        {
            Console.WriteLine("Error! K should be > 1 and N > K!");
        }
    }
}

