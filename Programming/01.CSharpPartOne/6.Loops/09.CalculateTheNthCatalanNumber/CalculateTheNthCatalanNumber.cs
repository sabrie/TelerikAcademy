/* In the combinatorial mathematics, the Catalan numbers are calculated by the following formula:
 * Cn = 2N!/ (N+1)!*N! for N >= 0. Write a program to calculate the Nth Catalan number by given N.
*/
using System;
using System.Numerics;

class CalculateTheNthCatalanNumber
{
    static void Main()
    {
        Console.WriteLine("This program calculates the Nth Catalan number -> Cn = 2N!/ (N+1)!*N!,");
        Console.Write("Please, enter a value for N: ");
        int n = int.Parse(Console.ReadLine());

        BigInteger factorialN = 1;
        BigInteger factorialDoubleN = 1;
        BigInteger factornialNPlus1 = 1;
        BigInteger catalanNumber = 0;

        if (n >= 0)
        {
            // calculates the factorial of N -> product of numbers from 1 to N
            for (int i = 1; i <= n; i++)
            {
                factorialN *= i;
            }
            // calculates the product of numbers from n+1 to 2N
            // 2N! = factorialN * factorialDoubleN
            for (int j = n + 1; j <= 2 * n; j++)
            {
                factorialDoubleN *= j;
            }
            // calculates the product of numbers from 1 to n+1.
            for (int k = 1; k <= n + 1; k++)
            {
                factornialNPlus1 *= k;
            }
            catalanNumber = (factorialN * factorialDoubleN) / (factorialN * factornialNPlus1);
            Console.WriteLine("The Catalan number {0} = {1}", n, catalanNumber);
        }
        else
        {
            Console.WriteLine("Error! Please enter a number N >= 0.");
        }
    }
}

