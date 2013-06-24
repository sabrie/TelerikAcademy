using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CountLettersInAText
{
    // reshenie na kolega
    static void Main(string[] args)
    {
        string text = "Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found.";
        List<char> alphabet = new List<char>();

        for (char i = 'a'; i < 'z'; i++)
        {
            alphabet.Add(i);
        }
        for (char i = 'A'; i < 'Z'; i++)
        {
            alphabet.Add(i);
        }

        int count = 0;
        for (int i = 0; i < alphabet.Count; i++)
        {
            for (int j = 0; j < text.Length; j++)
            {
                if (alphabet[i] == text[j])
                {
                    count++;
                }
            }
            if (count > 0)
            {
                Console.WriteLine("{0}: {1,5} times", alphabet[i], count);
            }
            count = 0;
        }

        // reshenie na drug kolega
        string str = "Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found.";

        int[] values = new int['z' - 'a' + 1];

        foreach (char c in str.ToLower())
            if ('a' <= c && c <= 'z') values[c - 'a']++;

        for (int i = 0; i < values.Length; i++)
            if (values[i] != 0) Console.WriteLine("{0}: {1}", (char)(i + 'a'), values[i]);
    }
}
