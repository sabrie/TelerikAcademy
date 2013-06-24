/* Write a program that creates an array containing all letters from the alphabet (A-Z). 
 * Read a word from the console and print the index of each of its letters in the array.
*/
using System;

class PrintIndexOfLettersOfWord
{
    static void Main()
    {
        char[] alphabetCapital = new char[] 
            { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 
              'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        char[] alphabetSmall = new char[] 
            { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 
              'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        
        Console.Write("Enter a word to see the indexes of its letters: ");
        string word = Console.ReadLine();

        int letterIndex = 0;
        for (int indexWord = 0; indexWord < word.Length; indexWord++)
        {
            for (int indexAlph = 0; indexAlph < alphabetCapital.Length; indexAlph++)
            {
                if (word[indexWord] == alphabetCapital[indexAlph] || word[indexWord] == alphabetSmall[indexAlph])
                {
                    letterIndex = indexAlph;
                    Console.WriteLine("Index of {0} = {1}", word[indexWord], letterIndex);
                    break;
                }
            }            
        }
    }
}

