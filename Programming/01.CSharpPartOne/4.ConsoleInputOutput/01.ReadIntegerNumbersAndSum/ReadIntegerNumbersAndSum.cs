/* Write a program that reads 3 integer numbers from 
 * the console and prints their sum.
 */
using System;

class ReadIntegerNumbersAndSum
{
    static void Main()
    {
        Console.WriteLine("To calculate the sum of 3 integers, please:");
        Console.Write("Enter a value for first integer: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter a value for second integer: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Enter a value for third integer: ");
        int c = int.Parse(Console.ReadLine());

        Console.WriteLine("{0} + {1} + {2} = {3}", a, b, c, a+b+c);
    }
}

