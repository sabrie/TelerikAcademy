/* You are given a text. Write a program that changes the text in all regions surrounded 
 * by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested.
 */
using System;
using System.Text;
using System.Text.RegularExpressions;

class ChangeToUpperIfInTag
{
    static void Main()
    {
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        // find the index of first ocurrence of ">". 
        // After ">" is the beginning of the word that we have to change to upper
        int startIndex = text.IndexOf(">");
        // find the index of first ocurrence of "<" after first ocurrence of ">"
        // before this "<" is the end of the word that we have to change to upper
        int endIndex = text.IndexOf("<", startIndex + 1);

        while (startIndex != -1)
        {
            int lengthInclTag = (endIndex + 8) - (startIndex - 7) + 1;
            int lengthWithinTag = (endIndex - startIndex) - 1;

            string changeThis = text.Substring(startIndex - 7, lengthInclTag);
            string changeToUpper = text.Substring(startIndex + 1, lengthWithinTag).ToUpper();

            text = text.Replace(changeThis, changeToUpper);

            startIndex = text.IndexOf(">");
            endIndex = text.IndexOf("<", startIndex + 1);
        }        
        Console.WriteLine(text);        
    }
}

