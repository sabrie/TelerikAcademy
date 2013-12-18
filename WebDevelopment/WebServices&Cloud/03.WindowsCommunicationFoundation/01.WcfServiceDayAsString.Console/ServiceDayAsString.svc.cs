/*
 * Task 1
 Create a simple WCF service. It should have a method that accepts a 
 DateTime parameter and returns the day of week (in Bulgarian) as string.
 Test it with the integrated WCF client.
 */

using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace _01.WcfServiceDayAsString.Console
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceDayAsString : IServiceDayAsString
    {
        public string PrintDayAsString(DateTime date)
        {
            string day = date.DayOfWeek.ToString();

            string dayAsString = "";

            switch (day)
            {
                case "Monday":
                    dayAsString = "Понеделник";
                    break;
                case "Tuesday":
                    dayAsString = "Вторник";
                    break;
                case "Wednesday":
                    dayAsString = "Сряда";
                    break;
                case "Thursday":
                    dayAsString = "Четвъртък";
                    break;
                case "Friday":
                    dayAsString = "Петък";
                    break;
                case "Saturday":
                    dayAsString = "Събота";
                    break;
                case "Sunday":
                    dayAsString = "Неделя";
                    break;
                default:
                    break;
            }

            return dayAsString;
        }
    }
}
