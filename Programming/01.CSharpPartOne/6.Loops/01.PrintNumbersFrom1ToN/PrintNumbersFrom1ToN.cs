// Write a program that prints all the numbers from 1 to N.
using System;

class PrintNumbersFrom1ToN
{
    static void Main()
    {
        Console.Write("Enter a positive number > 1: ");
        int number = int.Parse(Console.ReadLine());

        if (number > 0)
        {
            Console.WriteLine("The numbers from 1 to {0} are: ", number);
            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine(i);
            }
        }
        else
        {
            Console.WriteLine("Error! Please enter a positive number greater than 1.");
        }
    }
}

