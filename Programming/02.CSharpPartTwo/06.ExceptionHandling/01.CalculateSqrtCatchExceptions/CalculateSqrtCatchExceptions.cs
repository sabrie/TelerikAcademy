/* Write a program that reads an integer number and calculates 
 * and prints its square root. If the number is invalid or 
 * negative, print "Invalid number". In all cases 
 * finally print "Good bye". Use try-catch-finally
 */
using System;

class CalculateSqrtCatchExceptions
{
    static void Main()
    {
        uint number = 0;

        try
        {
            Console.Write("Enter a positive number to calculate its square root: ");      
            number = uint.Parse(Console.ReadLine());
            Console.WriteLine("Square root of {0} is {1:F2}.", number, Math.Sqrt(number));
        }
        // if number is negative an OverflowException is catched
        catch (OverflowException)
        {
            Console.WriteLine("Invalid number!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number!");
        }
        // finally block will be executed in any case even if an exception is catched
        finally
        {
            Console.WriteLine("Good Bye");
        }        
    }
}
