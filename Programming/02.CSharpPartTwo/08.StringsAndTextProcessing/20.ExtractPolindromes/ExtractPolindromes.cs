using System;
using System.Text.RegularExpressions;

class ExtractPolindromes
{
    // reshenie na kolega
    static bool IsPolindrome(string word)
    {
        bool isPolindrome = false;
        for (int i = 0; i < word.Length/2; i++)
        {
            if (word[i]!=word[word.Length-1-i])
            {
                isPolindrome = false;
                break;
            }
            isPolindrome = true;
        }
        return isPolindrome;
    }

    // reshenie na drug kolega
    static bool IsPalindrome2(string str)
    {
        for (int i = 0; i < str.Length / 2; i++)
            if (str[i] != str[str.Length - 1 - i])
                return false;

        return true;
    }

    static void Main()
    {
        string text = "Neven ABBA, seen, travel \"reger\" comoc! littil";
        string[] wordArray = text.Split(' ',',','!','?','.',';',':','\"','\\','(',')');

        foreach (var words in wordArray)
        {
            if (IsPolindrome(words))
            {
                Console.WriteLine(words);
            }
        }

        // reshenie na drug kolega
        foreach (Match item in Regex.Matches(text, @"\w+"))
            if (IsPalindrome2(item.Value)) Console.WriteLine(item);
    }
}

