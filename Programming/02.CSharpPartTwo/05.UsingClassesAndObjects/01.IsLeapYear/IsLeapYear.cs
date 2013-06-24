/* Write a program that reads a year from the console 
 * and checks whether it is a leap. Use DateTime.
*/
using System;

class IsLeapYear
{
    // ot kolega - haresa mi che ne e izpolzval gotov metod, a formula.
    static bool CheckIsLeapYear(int year)
    {
        bool isLeap = false;
        int lastTwoDigits = year % 100;

        for (int i = 0; i <= 96; i += 4)
        {
            if (lastTwoDigits == i)
            {
                isLeap = true;
                break;
            }
        }
        return isLeap;
    }

    static void Main()
    {
        Console.Write("Enter a year to check if it is leap: ");
        int year = int.Parse(Console.ReadLine());

        // bool DateTime.IsLeapYear(int year);
        // returns an indication if the specified year is leap ot not
        bool isLeapYear = DateTime.IsLeapYear(year);

        if (isLeapYear)
        {
            Console.WriteLine("{0} is a leap year!", year);
        }
        else
        {
            Console.WriteLine("{0} is not a leap year!", year);
        }        
    }
}
