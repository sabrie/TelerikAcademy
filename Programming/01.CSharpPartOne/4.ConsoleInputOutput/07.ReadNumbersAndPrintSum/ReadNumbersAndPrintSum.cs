/* Write a program that gets a number n and after that 
 * gets more n numbers and calculates and prints their sum.
 */
using System;

class ReadNumbersAndPrintSum
{
    static void Main()
    {
        Console.Write("Enter how many numbers you want to sum: ");
        int n = int.Parse(Console.ReadLine());
        double sum = 0;
        for (int i = 1; i <= n; i++)
        {
            Console.Write("Enter number: ");
            sum += double.Parse(Console.ReadLine());
        }
        Console.WriteLine("The sum is: {0}", sum);
    }
}

