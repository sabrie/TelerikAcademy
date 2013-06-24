/* Write a program that reverses the words in given sentence.
 * Example: "C# is not C++, not PHP and not Delphi!" 
 * Output: "Delphi not and PHP, not C++ not is C#!".
*/
using System;

class ReverseWordsInSentence
{
    static void Main()
    {
        string sentence = "C# is not C++, not PHP and not Delphi!";

        string[] splitSentence = sentence.Split(' ', ',');

        //Array.Reverse(splitSentence);

        for (int i = splitSentence.Length - 1; i >= 0; i--)
        {
            Console.Write(splitSentence[i] + " ");
        }
        Console.WriteLine();
    }
}

