/* We are given a string containing a list of forbidden words and 
 * a text containing some of these words. Write a program that 
 * replaces the forbidden words with asterisks. 
 */
using System;

class HideForbiddenWords
{
    static void Main()
    {
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";

        text = text.Replace("PHP", "***");
        text = text.Replace("CLR", "***");
        text = text.Replace("Microsoft", "*********");
        
        Console.WriteLine(text);

        // reshenie na kolega
        //string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        //string words = "PHP, CLR, Microsoft";

        //string[] wordsArray = words.Split(',');

        //for (int i = 0; i < wordsArray.Length; i++)
        //{
        //    wordsArray[i] = wordsArray[i].Trim();
        //}

        //for (int i = 0; i < wordsArray.Length; i++)
        //{
        //    text = text.Replace(wordsArray[i], new string('*', wordsArray[i].Length));
        //}
        //Console.WriteLine(text);


        // reshenie na drug kolega
        //string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        //string[] forbidenWords = { "PHP", "CLR", "Microsoft" };
        //for (int i = 0; i < forbidenWords.Length; i++)
        //{
        //    text = text.Replace(forbidenWords[i], new string('*', forbidenWords[i].Length));
        //}
        //Console.WriteLine(text);
    }
}

