/* Write a program that reads a number N and calculates the 
 * sum of the first N members of the sequence of Fibonacci: 
 * 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
*/
using System;
using System.Numerics;

class SumNNumbersOfFibonacciSeq
{
    static void Main()
    {
        Console.Write("How many numbers of the Fibonacci Sequence you would like to sum: ");
        int n = int.Parse(Console.ReadLine());
        BigInteger firstNum = 0;
        BigInteger secondNum = 1;
        BigInteger sum = 0;
        BigInteger exchange;

        if (n > 1)
        {
            Console.Write("Sum = 0");
            for (int i = 1; i < n; i++)
            {
                exchange = firstNum;
                firstNum = secondNum;
                secondNum = exchange + secondNum;
                sum += firstNum;
                Console.Write(" + " + firstNum);
            }
            Console.WriteLine(" = {0}", sum);
        }
        else
        {
            Console.WriteLine("Error! Please enter a positive number > 1!");
        }
    }
}

