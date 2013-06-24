/* The Tribonacci sequence is a sequence in which every next element is 
 * made by the sum of the previous three elements from the sequence.
 * Write a computer program that finds the Nth element of the Tribonacci 
 * sequence, if you are given the first three elements of the sequence and 
 * the number N. Mathematically said: with given T1, T2 and T3 – you must find Tn.
*/
using System;
using System.Numerics;

class TribonacciSequence
{
    static void Main()
    {
        BigInteger firstNum = BigInteger.Parse(Console.ReadLine());
        BigInteger secondNum = BigInteger.Parse(Console.ReadLine());
        BigInteger thirdNum = BigInteger.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        if (n == 1)
        {
            Console.WriteLine(firstNum);
        }
        else if (n == 2)
        {
            Console.WriteLine(secondNum);
        }
        else if (n == 3)
        {
            Console.WriteLine(thirdNum);
        }
        else
        {
            for (int i = 0; i < n - 3; i++)
            {
                BigInteger tribonacciNth = firstNum + secondNum + thirdNum;
                firstNum = secondNum;
                secondNum = thirdNum;
                thirdNum = tribonacciNth;
            }
            Console.WriteLine(thirdNum);
        }
    }
}

