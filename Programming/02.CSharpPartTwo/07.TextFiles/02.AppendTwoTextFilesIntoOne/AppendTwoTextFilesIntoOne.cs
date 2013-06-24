// Write a program that concatenates two text files into another text file
using System;
using System.IO;

class AppendTwoTextFilesIntoOne
{
    static void Main()
    {
        // read and overwrite the first text file
        string fileName1 = @"StreamReader.txt";
        // create a new instance of the StreamReader class
        StreamReader reader = new StreamReader(fileName1);        
        
        using(reader)
        {
            string line = reader.ReadLine();
            // create a new instance of the StreamWriter class named firstWriter
            // pass as first parameter the name of the file where we will write the text - ReadAndWrite.txt
            // if such file does not exist it is created
            // if second parameter is false the text is overwritten, if true - it is appended
            StreamWriter firstWriter = new StreamWriter(@"ReadAndWrite.txt", false);

            using (firstWriter)
            {
                while (line != null)
                {
                    firstWriter.WriteLine(line);
                    line = reader.ReadLine();
                }
            }           
        }

        // we read and append the second text file - StreamWriter.txt
        string fileName2 = @"StreamWriter.txt";
        StreamReader reader2 = new StreamReader(fileName2);
        
        using (reader2)
        {
            string line2 = reader2.ReadLine();
            StreamWriter secondWriter = new StreamWriter(@"ReadAndWrite.txt", true);

            using (secondWriter)
            {
                while (line2 != null)
                {
                    secondWriter.WriteLine(line2);
                    line2 = reader2.ReadLine();
                }
            }
        }
    }
}
