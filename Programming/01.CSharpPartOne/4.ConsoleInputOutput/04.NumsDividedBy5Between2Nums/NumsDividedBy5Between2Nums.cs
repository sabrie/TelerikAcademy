/* Write a program that reads two positive integer numbers and prints 
 * how many numbers p exist between them such that the reminder of 
 * the division by 5 is 0 (inclusive). Example: p(17,25) = 2.
 */
using System;

class NumsDividedBy5Between2Nums
{
    static void Main()
    {
        Console.Write("Enter a positive integer number: ");
        int firstNum = int.Parse(Console.ReadLine());
        Console.Write("Enter another positive integer number: ");
        int secondNum = int.Parse(Console.ReadLine());

        // Calculates how many times does the divisor fit between 0 and the greater dividend
        int resultMax = Math.Max(firstNum, secondNum) / 5; 
        // Calculates how many times does the divisior fit between 0 and the smaller dividend
        int resultMin = (Math.Min(firstNum, secondNum) - 1) / 5;
        // How many times does the divisior fit between the smaller and the greater dividend 
        int result = resultMax - resultMin;
        
        // Prints how many numbers 'p' exist between the two numbers so that they are divided by 5 without remainder
        Console.WriteLine("p({0},{1}) = {2}", Math.Min(firstNum, secondNum), Math.Max(firstNum, secondNum), result);
        Console.WriteLine("It means that the positive numbers between {0} and {1} \ndivided by 5 without remainder are {2}.", 
                            Math.Min(firstNum, secondNum), Math.Max(firstNum, secondNum), result);
    }
}


