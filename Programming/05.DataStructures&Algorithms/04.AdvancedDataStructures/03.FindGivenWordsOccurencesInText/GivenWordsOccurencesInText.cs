/* Write a program that finds a set of words (e.g. 1000 words) in a 
 * large text (e.g. 100 MB text file). Print how many times each 
 * word occurs in the text.
 * Hint: you may find a C# trie in Internet. */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class GivenWordsOccurencesInText
{
    static void Main()
    {
        // simple text for test
        // StreamReader fileName = new StreamReader("../../simpleText.txt");

        StreamReader fileName = new StreamReader("../../text.txt");
        string text;
        
        using (fileName)
        {
            text = ReadText(fileName);
        }

        var words = GetWords(text);

        // creates a new Trie instance
        ITrie trie = TrieFactory.GetTrie();

        foreach (var word in words)
        {
            trie.AddWord(word.ToString());
        }

        string[] searchedWords = { "trie", "tree", "structure", "implementation", "dictionary"};

        // Prints how many times each word from the searched words occurs in the text
        foreach (var word in searchedWords)
        {
            Console.Write(word + " -> ");
            int wordOcurrences = trie.WordCount(word);
            Console.WriteLine(wordOcurrences + " times");
        }
    }

    private static string ReadText(StreamReader input)
    {
        StringBuilder result = new StringBuilder();

        string line = input.ReadLine();

        while (line != null)
        {
            result.AppendLine(line);
            line = input.ReadLine();
        }

        return result.ToString();
    }

    private static MatchCollection GetWords(string text)
    {
        string textToLower = text.ToLower();
        var words = Regex.Matches(textToLower, @"\w+");

        return words;
    }
}

