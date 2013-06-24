// Write a program that finds the greatest of given 5 variables.
using System;

class PrintGreatestOfFiveVariables
{
    static void Main()
    {
        Console.WriteLine("Enter 5 numbers each on a new line: ");
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        int thirdNum = int.Parse(Console.ReadLine());
        int forthNum = int.Parse(Console.ReadLine());
        int fifthNum = int.Parse(Console.ReadLine());

        int greatestFirstSecondThird = Math.Max(Math.Max(firstNum, secondNum), thirdNum);
        int greatestForthFifth = Math.Max(forthNum, fifthNum);

        Console.Write("The greatest number is: ");

        if (greatestFirstSecondThird > greatestForthFifth)
        {
            Console.WriteLine(greatestFirstSecondThird);
        }
        else
        {
            Console.WriteLine(greatestForthFifth);
        }
    }
}

