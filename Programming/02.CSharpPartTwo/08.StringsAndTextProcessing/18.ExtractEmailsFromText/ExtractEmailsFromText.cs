/* Write a program for extracting all email addresses from given text. 
 * All substrings that match the format <identifier>@<host>…<domain> 
 * should be recognized as emails.
*/
using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtractEmailsFromText
{
    static void Main()
    {
        string text = "Pesho Peshov e-mail: 1pesho_pe-sh.ov23@gmail.com, _e-mail@telerik.com";

        string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

        // Regex.Matches(str, @"\w+@\w+\.\w+")
        
        Regex emailRegex = new Regex(pattern,
            RegexOptions.IgnoreCase);
        
        //find e-mails that matches with our pattern
        MatchCollection emailMatches = emailRegex.Matches(text);

        StringBuilder sb = new StringBuilder();

        foreach (Match emailMatch in emailMatches)
        {
            sb.AppendLine(emailMatch.Value);
        }
        Console.WriteLine(sb);    
   


        // reshenie na kolega
        //string text = @"lubica21@abv.bg jdjdjdjdjd vil_milanova@mail.ru kdkdkdkdkdkkd akamarashev.195@mvr.bg kdkdkdkkdkd dkdkdkdk kdkdkd avisariev@camusat.com";
        //string[] allEmails = text.Split(' ');

        //List<string> validEmails = new List<string>();

        //for (int i = 0; i < allEmails.Length; i++)
        //{
        //    if (Regex.IsMatch(allEmails[i], @"[\w.!#$%&'*=?^_`{|}~""(),:;<>@[\]]{1,64}@[\w-]{1,253}[.][\w\d._-]{1,10}"))
        //    {
        //        validEmails.Add(allEmails[i]);
        //    }
        //}

        //foreach (var mail in validEmails)
        //{
        //    Console.WriteLine(mail);
        //}


        // reshenie na drug kolega
        //string str = "Static void Main() nakov@telerik.com. using System,nakov@gmail.com return";

        //foreach (var item in Regex.Matches(str, @"\w+@\w+\.\w+"))
        //    Console.WriteLine(item);
    }
}

