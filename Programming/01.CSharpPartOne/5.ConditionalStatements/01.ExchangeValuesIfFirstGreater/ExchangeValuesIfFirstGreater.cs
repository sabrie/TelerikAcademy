/* Write an if statement that examines two integer variables and exchanges 
 * their values if the first one is greater than the second one.
 */
using System;

class ExchangeValuesIfFirstGreater
{
    static void Main()
    {
        Console.WriteLine("Enter two numbers: ");
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());


        if (firstNumber > secondNumber)
        {
            Console.WriteLine("The first number is greater than the second number \nand the program will exchange their values.");
            int exchange = firstNumber;
            firstNumber = secondNumber;
            secondNumber = exchange;
            Console.WriteLine("First number = {0}, Second number = {1} ", firstNumber, secondNumber);
        }
        else
        {
            Console.WriteLine("The first number is smaller than the second number \nand the program will print their values.");
            Console.WriteLine("First number = {0}, Second number = {1} ", firstNumber, secondNumber);
        }

    }
}