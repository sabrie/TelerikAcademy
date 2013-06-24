/* Write a method that calculates the number of workdays between 
 * today and given date, passed as parameter. Consider that workdays 
 * are all days from Monday to Friday except a fixed list of public 
 * holidays specified preliminary as array.
*/
using System;
using System.Globalization;
using System.Threading;

class CalculateWorkingDays
{
    static void Main()
    {
            Thread.CurrentThread.CurrentCulture =
                CultureInfo.GetCultureInfo("en-US");

            DateTime startDate = DateTime.Today;
            DateTime endDate = new DateTime(2013, 02, 10);
            
            Console.Write("Working days between \n{0:D} (inclusive) and \n{1:D} (inclusive) are: ", startDate.Date, endDate.Date);
            Console.Write("{0} days", GetWorkingDays(startDate, endDate)); // 8 days - Feb 6 and 7 are included in the holidays array
            Console.ReadLine();
    }
        
    public static int GetWorkingDays(DateTime today, DateTime endDate)
    {
        // create an array to save the holiday dates
        DateTime[] holidays = 
            {
                new DateTime(2013,02,06),
                new DateTime(2013,02,07),
                new DateTime(2013,02,11),
                new DateTime(2013,03,03),
            }; 

        if (today > endDate)
        {
            return 0;
        }
        
        int counterOfWorkingDays = 0;
        // we loop until we reach the endDate
        while (today != endDate)
        {
            if (today.DayOfWeek != DayOfWeek.Saturday && today.DayOfWeek != DayOfWeek.Sunday)
            {
                bool isHoliday = false;
                foreach (DateTime holidayDate in holidays)
                {
                    if (today == holidayDate)
                    {
                        isHoliday = true;
                        break;
                    }
                }
                if (!isHoliday)
                {
                    counterOfWorkingDays++;
                }
            }
            today = today.AddDays(1);
        }
        return counterOfWorkingDays;        
    }
}

