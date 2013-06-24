// Sort 3 real values in descending order using nested if statements.

using System;

class SortValuesInDescendingOrder
{
    static void Main()
    {
        Console.WriteLine("Enter 3 different real numbers each on a new line: ");
        double firstNum = double.Parse(Console.ReadLine());
        double secondNum = double.Parse(Console.ReadLine());
        double thirdNum = double.Parse(Console.ReadLine());
        double exchange;

        if (secondNum > firstNum)
        {
            exchange = firstNum;
            firstNum = secondNum;
            secondNum = exchange;
            if (thirdNum > secondNum)
            {
                exchange = thirdNum;
                thirdNum = secondNum;
                secondNum = exchange;
            }
            if (secondNum > firstNum)
            {
                exchange = firstNum;
                firstNum = secondNum;
                secondNum = exchange;
            }
        }
        if (thirdNum > secondNum)
        {
            exchange = thirdNum;
            thirdNum = secondNum;
            secondNum = exchange;
            if (secondNum > firstNum)
            {
                exchange = firstNum;
                firstNum = secondNum;
                secondNum = exchange;
            }
        }
        Console.WriteLine("Numbers in descending order are: {0}, {1}, {2}", firstNum, secondNum, thirdNum);
    }
}

