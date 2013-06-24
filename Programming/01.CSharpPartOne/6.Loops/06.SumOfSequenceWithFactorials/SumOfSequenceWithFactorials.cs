/* Write a program that, for a given two integer numbers N and X, 
 * calculates the sumS = 1 + 1!/X + 2!/X^2 + … + N!/X^N
 */
using System;
using System.Numerics;

class SumOfSequenceWithFactorials
{
    static void Main()
    {
        Console.WriteLine("This program calculates the sum of the sequence \nS = 1 + 1!/x + 2!/x^2 + 3!/x^3 ... N!/X^N = ?");
        Console.Write("Enter a value for N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter a value for X: ");
        int x = int.Parse(Console.ReadLine());
        BigInteger factorial = 1;
        BigInteger power = 1;
        BigInteger sum = 1;

        if (x != 0)
        {
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
                power *= x;
                sum += factorial / power;
            }
            Console.WriteLine("Sum = {0}", sum);
        }
        else
        {
            Console.WriteLine("Please enter a value for X != 0.");
        }
    }
}
