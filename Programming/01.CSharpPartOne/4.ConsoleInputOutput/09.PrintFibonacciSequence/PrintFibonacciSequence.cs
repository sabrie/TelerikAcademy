/* Write a program to print the first 100 members of 
 * the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 
 * 21, 34, 55, 89, 144, 233, 377, …
 */
using System;

class PrintFibonacciSequence
{
    static void Main()
    {
        decimal firstNum = 0M;
        decimal secondNum = 1M;

        Console.WriteLine("0");
        for (int i = 0; i < 100; i++)
        {
            decimal temp = firstNum;
            firstNum = secondNum;
            secondNum = temp + secondNum;

            Console.WriteLine(firstNum);
        }
    }
}


        