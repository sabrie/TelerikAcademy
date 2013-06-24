/* Write a program that reads a text file and inserts line numbers in front 
 * of each of its lines. The result should be written to another text file
 */
using System;
using System.IO;

class ReadAndWriteTxtToFile
{
    static void Main()
    {
        string fileName = @"LoremIpsum.txt";

        try
        {
            // create a new instance of the StreamReader class
            StreamReader reader = new StreamReader(fileName);

            using (reader)
            {
                // create a new instance of the StreamWriter class named firstWriter
                // pass as first parameter the name of the file where we will write the text
                // if such file does not exist it is created
                // if second parameter is false the text is overwritten, if true - it is appended
                StreamWriter writer = new StreamWriter(@"LoremIpsum-LineNum.txt", false);
                int lineNumber = 0;

                using (writer)
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        lineNumber++;
                        writer.WriteLine("Line {0}: {1}", lineNumber, line);
                        line = reader.ReadLine();
                    }
                }
            }
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Empty path name.");
        }
        catch (PathTooLongException tooLong)
        {
            Console.WriteLine(tooLong.Message);
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Invalid directory in the file path.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file specified in path {0} was not found.", fileName);
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("{0} is in an invalid format.", fileName);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You have not the required permission to access the file.");
        }
        catch (IOException)
        {
            Console.WriteLine("An I/O error occurred while opening the file.");
        }
    }
}

