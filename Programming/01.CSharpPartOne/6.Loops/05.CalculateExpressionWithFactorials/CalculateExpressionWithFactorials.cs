// Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).
using System;
using System.Numerics;

class CalculateExpressionWithFactorials
{
    static void Main()
    {
        Console.WriteLine("This program calculates the expression: ");
        Console.WriteLine("N!*K!/(K-N)!=? for (1<N<K)");
        Console.Write("Enter a value for N > 1: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter a value for K > {0}: ", n);
        int k = int.Parse(Console.ReadLine());
        BigInteger factorialN = 1;     
        BigInteger factorialKN = 1;

        if (n > 1 && k > n)
        {
            for (int i = 1; i <= n; i++)
            {
                factorialN *= i;    // calculates the factorial from 1 to N.
            }
            for (int j = (k - n) + 1; j <= k; j++)
            {
                factorialKN *= j; // calculates the factorial from (K-N+1) to N.
            }
            // N!*K!/(K-N)! = N!*(K-N+1)! = factorialN * factorialKN
            Console.WriteLine("N!*K!/(K-N)! = {0}", factorialN*factorialKN);
        }
        else
        {
            Console.WriteLine("Error! N should be > 1 and K > N!");
        }
    }
}

