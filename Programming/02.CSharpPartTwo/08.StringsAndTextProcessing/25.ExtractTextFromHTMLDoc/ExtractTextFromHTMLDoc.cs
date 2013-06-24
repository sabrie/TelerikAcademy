/* Write a program that extracts from given HTML file its title (if available), 
 * and its body text without the HTML tags. 
 * Example:
 * <html>
 *  <head><title>News</title></head>
 *      <body><p><a href="http://academy.telerik.com">Telerik
 *          Academy</a>aims to provide free real-world practical
 *          training for young people who want to turn into
 *          skillful .NET software engineers.</p>
 *      </body>
 * </html>
*/
using System;
using System.Text.RegularExpressions;

class ExtractTextFromHTMLDoc
{
    static void Main()
    {
        string htmlDoc = @"<html> <head><title>News</title></head> <body><p><a href=""http://academy.telerik.com"">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body></html>";
        
        // Match any HTML tag (opening or closing tags) 
        // followed by any successive whitespaces
        // consider the HTML text as a single line
        Regex tagsRegex = new Regex("(<.*?>\\s*)+", RegexOptions.Singleline);

        // replace all html tags (and consequtive whitespaces) by spaces
        // trim the first and last space
        string resultText = tagsRegex.Replace(htmlDoc, " ").Trim();
        
        Console.WriteLine(resultText);

        
        
        
        // reshenie na kolega
        //string str = @"<html><head><title>News</title></head><body><p><a href=""http://academy.telerik.com"">TelerikAcademy</a>aims to provide free real-world practicaltraining for young people who want to turn into skillful .NET software engineers.</p></body></html>";

        //foreach (Match text in Regex.Matches(str, ">(.*?)<"))
        //    if (!String.IsNullOrWhiteSpace(text.Groups[1].Value))
        //        Console.WriteLine(text.Groups[1]);
    }
}
