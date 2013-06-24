/* Write a program that reads two dates in the format: day.month.year 
 * and calculates the number of days between them. 
 * Example:
 * Enter the first date: 27.02.2006
 * Enter the second date: 3.03.2006
 * Distance: 4 days
*/
using System;
using System.Globalization;

class CalcDaysBetweenTwoDays
{
    static void Main()
    {
        ////Console.WriteLine("Please enter the first date in the format dd.mm.yyyy followed by enter");
        ////string firstDate = Console.ReadLine();
        ////Console.WriteLine("Please enter the second date in the format dd.mm.yyyy followed by enter");
        ////string secondDate = Console.ReadLine();

        string startDate = "27.02.2006";
        string endDate = "03.03.2006";
        string format = "d.MM.yyyy";

        DateTime parseStartDate = DateTime.ParseExact(startDate, format, CultureInfo.InvariantCulture);
        DateTime parseEndDate = DateTime.ParseExact(endDate, format, CultureInfo.InvariantCulture);

        double difference = (parseEndDate - parseStartDate).TotalDays;
        Console.WriteLine("Distance: {0}", difference);


        // reshenie na kolega
        //DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
        //DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
        //DateTime addDate;
        //int count = 0;

        //if (startDate < endDate)
        //{
        //    addDate = startDate;

        //}
        //else
        //{
        //    addDate = endDate;
        //    endDate = startDate;
        //}

        //while (addDate != endDate)
        //{
        //    addDate = addDate.AddDays(1);
        //    count++;
        //}
        //Console.WriteLine(count);
    }
}

