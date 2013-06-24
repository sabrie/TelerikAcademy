/* Write a program that shows the sign (+ or -) of the product of three 
 * real numbers without calculating it. Use a sequence of if statements.
 */
using System;

class ShowSignOfProductOfThreeIntegers
{
    static void Main()
    {
        Console.WriteLine("Enter three real numbers each on a new line: ");
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        double thirdNumber = double.Parse(Console.ReadLine());

        Console.Write("The product of the three numbers is: ");

        if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
        {
            Console.WriteLine(" 0.");
        }
        else
        {
            if ((firstNumber > 0 && secondNumber > 0 && thirdNumber > 0) || 
                (firstNumber < 0 && secondNumber < 0 && thirdNumber > 0) || 
                (firstNumber > 0 && secondNumber < 0 && thirdNumber < 0) ||
                (firstNumber < 0 && secondNumber > 0 && thirdNumber < 0))
            {
                Console.WriteLine("positive.");
            }
            else
            {
                Console.WriteLine("negative.");
            }
        }
    }
}

