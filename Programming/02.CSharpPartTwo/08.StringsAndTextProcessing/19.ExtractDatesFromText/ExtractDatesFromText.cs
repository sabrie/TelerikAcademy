/* Write a program that extracts from a given text all dates that match the 
 * format DD.MM.YYYY. Display them in the standard date format for Canada.
*/
using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

class ExtractDatesFromText
{
    static void Main()
    {
        string text = "Telerik Software Academy courses started on 29.10.2012. On 03.02.2013 is the C# exam and on 11.02.2013 is the CSS exam.";
        string dateSearchPattern = @"(?<Day>\d{2}).(?<Month>\d{2}).(?<Year>\d{4})|(?<Day>\d{2}).(?<Month>\d{2}).(?<Year>\d{2})";

        Regex dateRegex = new Regex(dateSearchPattern);

        MatchCollection dateMatches = dateRegex.Matches(text);

        StringBuilder dates = new StringBuilder();

        foreach (Match dateMatch in dateMatches)
        {
            dates.AppendLine(dateMatch.Value);
            
        }
        Console.WriteLine(dates); 

        // reshenie na kolega
        //string str = "Static void Main() 12.10.2012, 50.13.2012   12.03.2012";

        //DateTime date;
        //foreach (Match item in Regex.Matches(str, @"\b[0-9]{2}.[0-9]{2}.[0-9]{4}\b"))
        //    if (DateTime.TryParseExact(item.Value, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
        //        Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
    }
}
