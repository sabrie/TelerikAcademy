/* Write a program to calculate n! for each n in the range [1..100]. 
 * Hint: Implement first a method that multiplies a number represented 
 * as array of digits by given integer number.
 */

using System;
using System.Numerics;

class CalcFactorialN
{
    static BigInteger CalcFactorial(int n)
    {
        BigInteger factorial = 1;
        do
        {
            factorial *= n;
            n--;
        } while (n > 0);
        
        return factorial;
    }

    static void Main()
    {
        Console.WriteLine("This program calculates N! in the range [1...100]");
        Console.Write("N = ");

        int n = int.Parse(Console.ReadLine());
        BigInteger factorialN = CalcFactorial(n);

        if (n >= 1 && n <= 100)
        {
            Console.WriteLine("N! = {0}", factorialN);
        }
        else
        {
            Console.WriteLine("The value of N should be in the range [1...100]");
        }        
    }
}

