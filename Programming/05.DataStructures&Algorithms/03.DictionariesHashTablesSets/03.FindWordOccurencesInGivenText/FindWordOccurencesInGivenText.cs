/* Write a program that counts how many times each word from 
 * given text file words.txt appears in it. The character 
 * casing differences should be ignored. The result words 
 * should be ordered by their number of occurrences in the text. 
 * Example: * 
 * TEXT - This is the TEXT. Text, text, text – THIS TEXT! Is this the text?
 * RESULT:
 *  is -> 2
	the -> 2
	this -> 3
	text -> 6
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class FindWordOccurencesInGivenText
{
    static void Main()
    {
        StreamReader fileName = new StreamReader("../../words.txt");
        
        using (fileName)
        {
            string input = ReadInput(fileName);
            IDictionary<string, int> countedWordOccurences = CountWordOccurences(input);

            PrintWordOccurences(countedWordOccurences);
        }
    }

    private static string ReadInput(StreamReader input)
    {
        StringBuilder result = new StringBuilder();
        string line;

        while ((line = input.ReadLine()) != null)
        {
            result.AppendLine(line);
        }

        return result.ToString();
    }

    private static IDictionary<string, int> CountWordOccurences(string text)
    {
        string textToLower = text.ToLower();
        var words = Regex.Matches(textToLower, @"\w+");
        IDictionary<string, int> occurences = new Dictionary<string, int>();

        foreach (Match wordMatch in words)
        {
            var word = wordMatch.Value;
            if (!occurences.ContainsKey(word))
            {
                occurences[word] = 0;
            }
            occurences[word]++;
        }

        return occurences;
    }

    private static void PrintWordOccurences(IDictionary<string, int> occurences)
    {
        foreach (var number in occurences)
        {
            Console.WriteLine("{0} -> {1} times", number.Key, number.Value);
        }
    }
}

