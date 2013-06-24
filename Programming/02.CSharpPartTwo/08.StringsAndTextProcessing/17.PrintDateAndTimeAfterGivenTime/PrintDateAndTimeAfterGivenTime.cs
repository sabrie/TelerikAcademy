/* Write a program that reads a date and time given 
 * in the format: day.month.year hour:minute:second 
 * and prints the date and time after 6 hours and 30 minutes 
 * (in the same format) along with the day of week in Bulgarian.
*/
using System;
using System.Globalization;
using System.Threading;

class PrintDateAndTimeAfterGivenTime
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

        //Console.WriteLine("Въведете дата и час във формат дд.мм.гггг чч:мм:сс");
        //string dateTimeNow = Console.ReadLine();
        
        string dateTimeNow = "02.02.2013 23:00:00";

        string format = "dd.MM.yyyy HH:mm:ss";

        double addHours = 6;
        double addMinutes = 30;

        DateTime parsedDate = DateTime.ParseExact(dateTimeNow, format, CultureInfo.InvariantCulture);
        Console.WriteLine("Дата и час: {0} {1}", parsedDate.ToString("dddd"), parsedDate);

        parsedDate = parsedDate.AddHours(addHours);
        parsedDate = parsedDate.AddMinutes(addMinutes);
        Console.WriteLine("След {0} часа и {1} минути: {2} {3}",addHours, addMinutes, parsedDate.ToString("dddd"), parsedDate);
    }
}
