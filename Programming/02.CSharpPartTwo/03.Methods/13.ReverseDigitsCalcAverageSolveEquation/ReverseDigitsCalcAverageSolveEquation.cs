/* Write a program that can solve these tasks:
 *      Reverses the digits of a number
 *      Calculates the average of a sequence of integers
 *      Solves a linear equation a * x + b = 0
 * Create appropriate methods. Provide a simple text-based menu 
 * for the user to choose which task to solve.
 * Validate the input data:
 *      The decimal number should be non-negative
 *      The sequence should not be empty
 *      a should not be equal to 0
*/
using System;

class ReverseDigitsCalcAverageSolveEquation
{
    static void PrintReversedDigits(int num)
    {
        int remainder;
        do
        {
            // take the last digit of a number and print it
            remainder = num % 10;  // 123 % 10 = 3;
            Console.Write(remainder);
            num = num / 10;
        } while (num > 0);
    }

    static decimal CalcAverage(params int[] array)
    {
        decimal sum = 0;
        decimal counter = 0;

        foreach (int element in array)
        {
            counter++;
            sum = sum + element;
        }
        decimal average = sum / counter;
        return average;
    }

    static void CalcLinearEquation(decimal a, decimal b)
    {
        if (IsNotZero(a))
        {
            decimal x = -b / a;
            Console.WriteLine("x = {0:0.00}", x);
        }
        else
        {
            if (b == 0)
            {
                Console.WriteLine("The equation has countless solutions.");
            }
            else
            {
                Console.WriteLine("The equation does not have a solution.");
            }
        }        
    }

    static bool IsNotZero(decimal a)
    {
        bool aIsNotZero = (a != 0);
        return aIsNotZero;
    }

    static bool IsPositive(decimal number)
    {
        bool decimalIsPositive = (number > 0);
        return decimalIsPositive;
    }

    static bool IsNotEmpty(params int[] array)
    {
        bool arrayNotEmpty = (array.Length != 0);
        return arrayNotEmpty;
    }

    static void ReadArray(int[] array, int n)
    {
        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
    }


    static void Main()
    {
        Console.WriteLine("Please choose one of the following: ");
        Console.WriteLine(" - to reverse the digits of a number, please enter 1");
        Console.WriteLine(" - to calculate the average of a sequence enter 2");
        Console.WriteLine(" - to solve a linear equation enter 3");

        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            Console.Write("Enter a positive number: ");
            int number = int.Parse(Console.ReadLine());
            if (IsPositive(number))
            {
                Console.Write("Reversed: ");
                PrintReversedDigits(number);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Please, enter a positive number!");
            }            
        }
        else if (choice == 2)
        {
            Console.Write("How many numbers you will calculate: ");
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            Console.WriteLine("Enter the numbers (each on a new line): ");
            ReadArray(numbers, n);
            
            if (IsNotEmpty(numbers))
            {
                decimal calcAverage = CalcAverage(numbers);
                Console.WriteLine("Average = {0}", calcAverage);
            }
            else
            {
                Console.WriteLine("No input! Please enter numbers to calculate their average.");
            }           
        }
        else if (choice == 3)
        {
            Console.WriteLine("To solve the linear equation a*x + b = 0");
            Console.Write("Enter value for a ( a != 0): ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter value for b: ");
            int b = int.Parse(Console.ReadLine());

            CalcLinearEquation(a, b);
        }
        else
        {
            Console.WriteLine("Incorrect input! Please choose a number between 1 and 3!");
        }
    }
}

