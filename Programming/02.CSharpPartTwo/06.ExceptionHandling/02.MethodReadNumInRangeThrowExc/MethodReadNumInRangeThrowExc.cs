/* Write a method ReadNumber(int start, int end) that enters an 
 * integer number in given range [start…end]. If an invalid number 
 * or non-number text is entered, the method should throw an exception.
*/
using System;

class MethodReadNumInRangeThrowExc
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
            }
        }
        catch (FormatException fe)
        {
            Console.Error.WriteLine("Error: {0}", fe.Message);
        }
        return number;
    }

    static void Main()
    {
        int start = 10;
        int end = 30;
        Console.WriteLine("Please enter a number in the range [{0}...{1}]", start, end);
        int number = ReadNumberInRange(start, end);
    }
}