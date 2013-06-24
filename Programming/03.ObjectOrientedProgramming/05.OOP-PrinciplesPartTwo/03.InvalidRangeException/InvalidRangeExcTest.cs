/* Write a sample application that demonstrates the 
 * InvalidRangeException<int> 
 * and 
 * InvalidRangeException<DateTime> 
 * by entering numbers in the range [1..100] and 
 * dates in the range [1.1.1980 … 31.12.2013].
*/

using System;

class InvalidRangeExcTest
{
    static void Main()
    {
        // TEST the InvalidRangeException<int>
        Console.WriteLine("TEST the InvalidRangeException<DateTime>");
        Console.WriteLine();

        int startNum = 0;
        int endNum = 100;
        Console.WriteLine("Enter a number in the range [{0} ... {1}]", startNum, endNum);
        int number = int.Parse(Console.ReadLine());

        try
        {
            if (number < startNum || number > endNum)
            {
                throw new InvalidRangeException<int>(startNum, endNum);
            }
            else
            {
                int square = number * number;
                Console.WriteLine("Square of number {0} is: {1}", number, square);
            }
        }
        catch (InvalidRangeException<int> exc)
        {
            // If our exception is caught we print this message on the Console
            // Console.WriteLine("Invalid Date! Date {0} is out of range {1} - {2}", myDate, startDate, endDate);
            Console.WriteLine("Number {0} is out of range {1} - {2}. Try again!", number, startNum, endNum);

            // If our exception is caught prints the message set in the constructor 
            // : base("Invalid range! Should be in the range " + start + " - " + end)
            throw new InvalidRangeException<int>(startNum, endNum);
        }
        Console.WriteLine();


        // TEST the InvalidRangeException<DateTime>
        Console.WriteLine("TEST the InvalidRangeException<DateTime>");
        Console.WriteLine();

        DateTime startDate = new DateTime(1980, 1, 1);
        DateTime endDate = new DateTime(2013, 12, 31);

        // this will NOT throw an exception - date is in range
        //DateTime myDate = new DateTime(2013, 05, 25);

        // this will throw an exception as the date is out of range
        DateTime myDate = new DateTime(2015, 05, 25);

        try
        {
            if (myDate < startDate || myDate > endDate)
            {
                throw new InvalidRangeException<DateTime>(startDate, endDate);
            }
            else
            {
                Console.WriteLine(myDate);
            }
        }
        catch (InvalidRangeException<DateTime> exc)
        {
            // If our exception is caught we print this message on the Console
            Console.WriteLine("Invalid Date! Date {0} is out of range {1} - {2}", myDate, startDate, endDate);

            // If our exception is caught prints the message set in the constructor 
            // : base("Invalid range! Should be in the range " + start + " - " + end)
            throw new InvalidRangeException<DateTime>(startDate, endDate);
        }        
    }
}
