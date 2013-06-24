/* Write a program that prints all the numbers from 1 to N, 
 * that are not divisible by 3 and 7 at the same time.
*/
using System;

class NumbersFrom1ToNNotDivisibleBy3And7
{
    static void Main()
    {
        Console.Write("Enter a positive number > 1: ");
        int number = int.Parse(Console.ReadLine());
        
        if (number > 0)
        {
            Console.WriteLine("The numbers from 1 to {0} ", number);
            Console.WriteLine("which are not divisible by 7 and 3 at the same time are:");
            for (int i = 1; i <= number; i++)
            {
                if (i % (3*7) != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        else
        {
            Console.WriteLine("Error! Please enter a positive number greater than 1.");
        }
    }
}

