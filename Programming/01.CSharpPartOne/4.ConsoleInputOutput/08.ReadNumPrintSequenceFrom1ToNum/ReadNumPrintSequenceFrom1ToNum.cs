/* Write a program that reads an integer number n from the console and 
 * prints all the numbers in the interval [1..n], each on a single line.
 */
using System;

class ReadNumPrintSequenceFrom1ToNum
{
    static void Main()
    {
        Console.WriteLine("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("The numbers between 1 and the number you entered are:");
       
        for (int i = 1; i <= number; i++)
        {
            Console.Write("{0, -5}", i);
        }
        Console.WriteLine();
    }
}

