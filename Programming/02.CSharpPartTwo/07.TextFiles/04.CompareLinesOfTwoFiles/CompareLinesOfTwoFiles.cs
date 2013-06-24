/* Write a program that compares two text files line by line and prints the number of lines 
 * that are the same and the number of lines that are different. Assume the files have equal 
 * number of lines.
*/
using System;
using System.IO;

class CompareLinesOfTwoFiles
{
    static void Main()
    {
        string fileName1 = @"file_1.txt";
        string fileName2 = @"file_2.txt";
                 
        try
        {
            // create new instances of the StreamReader class
            StreamReader reader1 = new StreamReader(fileName1);
            StreamReader reader2 = new StreamReader(fileName2);

            using (reader1)
            {
                int equalLineNum = 0; // counter for equal lines
                int diffLineNum = 0; // counter for different files
                using (reader2)
                {
                    string lineFile1 = reader1.ReadLine();
                    string lineFile2 = reader2.ReadLine();
                    while (lineFile1 != null || lineFile2 != null)
                    {
                        if (lineFile1 == lineFile2)
                        {
                            equalLineNum++;
                        }
                        else
                        {
                            diffLineNum++;
                        }

                        lineFile1 = reader1.ReadLine();
                        lineFile2 = reader2.ReadLine();
                    }
                    Console.WriteLine("Equal lines: {0}", equalLineNum); // 3
                    Console.WriteLine("Different lines: {0}", diffLineNum); // 1
                }
            }
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Empty path name.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Invalid directory in the file path.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The files specified in paths {0} or {1} were not found.", fileName1, fileName2);
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("{0} or {1} is in an invalid format.", fileName1, fileName2);
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

