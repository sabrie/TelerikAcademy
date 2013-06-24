using System;
using System.Text.RegularExpressions;

class ReplaceConsecutiveIdenticalLetters
{
    static void Main(string[] args)
    {
        string str = "aaaaabbbbbcdddeeeedssaa";
        Console.WriteLine(Regex.Replace(str, @"(\w)\1+", "$1"));
    }
}

