/* Write a method GetMax() with two parameters that returns the bigger of two integers. 
 * Write a program that reads 3 integers from the console and prints the biggest 
 * of them using the method GetMax(). 
 */

using System;

class PrintBiggestOf3Integers
{
    static int GetMax(int firstNum, int secondNum)
    {
        int maxNum = firstNum;
        if (secondNum > firstNum)
        {
            maxNum = secondNum;
        }
        return maxNum;
    }

    static void Main()
    {
        Console.WriteLine("Find biggest of three numbers");
        Console.Write("First number = ");
        int firstNum = int.Parse(Console.ReadLine());
        Console.Write("Second number = ");
        int secondNum = int.Parse(Console.ReadLine());
        Console.Write("Third number = ");
        int thirdNum = int.Parse(Console.ReadLine());

        int maxNum = GetMax(GetMax(firstNum, secondNum), thirdNum);
        Console.WriteLine("The biggest number is: {0}", maxNum);
    }
}

