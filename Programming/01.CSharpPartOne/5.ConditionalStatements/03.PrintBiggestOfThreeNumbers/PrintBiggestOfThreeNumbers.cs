// Write a program that finds the biggest of three integers using nested if statements.

using System;

class PrintBiggestOfThreeNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter three integer numbers each on e new line:");
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        int thirdNum = int.Parse(Console.ReadLine());

        Console.Write("The biggest of the three numbers is: ");

        if (firstNum > secondNum && firstNum > thirdNum)
        {
            Console.WriteLine(firstNum);
        }
        else if (secondNum > firstNum && secondNum > thirdNum)
        {
            Console.WriteLine(secondNum);
        }
        else
        {
            Console.WriteLine(thirdNum);
        }
    }
}
