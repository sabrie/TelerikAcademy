/* Write a method ReadNumber(int start, int end) that enters an 
 * integer number in given range [start…end]. If an invalid number 
 * or non-number text is entered, the method should throw an exception. 
 * Using this method write a program that enters 10 numbers:
 * a1, a2, … a10, such that 1 < a1 < … < a10 < 100
*/
using System;

class MethodRead10Nums
{
    static int ReadNumberInRange(int start, int end)
    {
        int number = 0;
        try
        {
            number = int.Parse(Console.ReadLine());
            if ((number < start) || (number > end))
            {
                ArgumentOutOfRangeException outOfRange = new ArgumentOutOfRangeException();
                Console.WriteLine("Error: {0}", outOfRange.Message);
                Console.WriteLine("Each next number should be smaller than the previous one!");
            }
        }
        catch (FormatException fe)
        {
            Console.Error.WriteLine("Error: {0}", fe.Message);
            //Console.WriteLine("Invalid input! Please enter a number!");
        }
        return number;
    }

    static void Main()
    {
        int nNumbers = 10;
        int start = 1;
        int end = 100;
        Console.WriteLine("Please enter 10 numbers in the range [{0}...{1}]", start, end);
        Console.WriteLine("so that each next number is smaller than the previous one: ");
        
        for (int i = 0; i < nNumbers; i++)
        {
            int number = ReadNumberInRange(start, end);
            // we assign the value of the number we have read to the end variable
            // and that the new range will be (start, number)
            end = number;
        }
    }
}

