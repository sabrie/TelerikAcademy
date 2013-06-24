/*
 Write a program to traverse the directory C:\WINDOWS and all 
 its subdirectories recursively and to display all files 
 matching the mask *.exe. Use the class System.IO.Directory.
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TraverseMSWindowsDirectory
{
    private const string fileExtension = ".exe";

    static void Main()
    {
        try
        {
            TraverseDirectory(@"C:\Program Files");
            //TraverseDirectory("../../../ ");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine(ex.Message);
        }   
    }

    public static void TraverseDirectory(string directoryPath)
    {
        var files = Directory.GetFiles(directoryPath);
        var filesWithGivenExtension = files.Where(file => file.EndsWith(fileExtension));

        foreach (var file in filesWithGivenExtension)
        {
            Console.WriteLine(file);
        }

        var directories = Directory.GetDirectories(directoryPath);
        foreach (var directory in directories)
        {
            TraverseDirectory(directory);
        }
    }
}

