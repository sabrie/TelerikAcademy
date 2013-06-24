// Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.IO;

class ReadTextPrintOddLines
{
    static void Main()
    {
        string fileName = @"LoremIpsum.txt";

        StreamReader reader = new StreamReader(fileName);
        using (reader)
        {
            int lineNumber = 0;
            string line = reader.ReadLine();
            while (line != null)
            {
                lineNumber++;
                if (lineNumber % 2 != 0)
                {
                    // number of lines are also printed to be easier to see the result
                    Console.WriteLine("Line {0}: {1}", lineNumber, line);             
                }
                line = reader.ReadLine();
            }
        }
    }
}
