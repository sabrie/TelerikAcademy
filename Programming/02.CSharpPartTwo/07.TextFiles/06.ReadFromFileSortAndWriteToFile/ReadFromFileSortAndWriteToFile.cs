/* Write a program that reads a text file containing a list of strings, 
 * sorts them and saves them to another text file. 
 * Example
 * Ivan             George
 * Peter    ->      Ivan
 * Maria            Maria
 * Geprge           Peter
 */
using System;
using System.Collections.Generic;
using System.IO;

class ReadFromFileSortAndWriteToFile
{
    static void Main()
    {
        string fileName = @"ReadNames.txt";
        
        // create a new instance of the StreamReader class
        StreamReader reader = new StreamReader(fileName);

        using (reader)
        {
            // save each line we have read into a list
            List<string> words = new List<string>();

            string line = reader.ReadLine();
            while (line != null)
            {
                words.Add(line);
                line = reader.ReadLine();
            }

            // sort the list
            words.Sort();

            StreamWriter writer = new StreamWriter(@"WriteSortedNames.txt", false);
            using (writer)
            {
                // write the sorted list to a file
                for (int i = 0; i < words.Count; i++)
                {
                    writer.WriteLine(words[i]);
                }
            }
        }
    }
}

