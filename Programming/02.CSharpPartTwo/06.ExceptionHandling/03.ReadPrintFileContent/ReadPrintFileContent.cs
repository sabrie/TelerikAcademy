/* Write a program that enters file name along with its full file path 
 * (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the 
 * console. Find in MSDN how to use System.IO.File.ReadAllText(…). 
 * Be sure to catch all possible exceptions and print user-friendly 
 * error messages.
*/
using System;
using System.IO;
using System.Text;

class ReadPrintFileContent
{
    static void Main()
    {
        string filePath = "";
        try
        {
            filePath = Console.ReadLine();
            //filePath = @"D:\01.Telerik\C#\C# II\Homework\06.ExceptionHandling\03.ReadPrintFileContent\LoremIpsum.txt";

            // File.ReadAllText opens a file, reads all lines of the file with the specified encoding
            // and then closes the file, even if exceptions are raised.
            string readText = File.ReadAllText(filePath);
            Console.WriteLine(readText);
        }
        // path is a zero-length string, contains only white space, or contains one or more invalid characters
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
            Console.WriteLine("The file specified in path {0} was not found.", filePath);
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("{0} is in an invalid format.", filePath);
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
