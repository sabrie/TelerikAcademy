/* Write a program that reads a list of words, separated by spaces 
 * and prints the list in an alphabetical order.
*/
using System;

class ReadWordsPrintInAlphOrder
{
    static void Main()
    {
        //string words = Console.ReadLine();

        string words = "one sun is not enough";
        Console.WriteLine("List of words: {0}", words);

        string[] splitWords = words.Split(' ');
        Array.Sort(splitWords);

        Console.Write("In alphabetic order:");
        for (int i = 0; i < splitWords.Length; i++)
        {
            Console.Write(splitWords[i] + " ");
        }
        Console.WriteLine();
        

        // reshenie na kolega
        //string[] inWords = Console.ReadLine().Split();

        //var sortedWords = inWords.OrderBy(x => x); //.ThenBy(x => x.Length);
        //foreach (var item in sortedWords)
        //{
        //    Console.Write("{0} ", item);
        //}
    }
}

