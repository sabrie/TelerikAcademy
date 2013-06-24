/* Write a program that gets two numbers from the console 
 * and prints the greater of them. Don’t use if statements.
 */
using System;

class ReadTwoNumbersPrintTheGreater
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number1 = int.Parse(Console.ReadLine());
        Console.Write("Enter a number: ");
        int number2 = int.Parse(Console.ReadLine());
       
        Console.Write("The greater number is: ");
        Console.WriteLine(Math.Max(number1,number2));
    }
}

