/* Write a program that downloads a file from Internet 
 * (e.g. http://www.devbg.org/img/Logo-BASD.jpg) 
 * and stores it the current directory. Find in Google how 
 * to download files in C#. Be sure to catch all exceptions 
 * and to free any used resources in the finally block.
*/
using System;
using System.Net;
using System.Security;
using System.Text;

class DownloadFileFromInternet
{
    static void Main()
    {
        WebClient client = new WebClient();
        string url = @"http://downloads.academy.telerik.com/svn/csharppart2/Lectures/6.%20Exceptions%20Handling/Exception-Handling.pptx";
        // we find the last occurance of "/" because we know that after it (to the end of the url address) is the name of the file
        string getFileName = url.Substring(url.LastIndexOf('/') + 1);
        try
        {
            using (client)
            {
                client.DownloadFile(new Uri(url), getFileName);
            }
        }
        catch (WebException)
        {
            Console.WriteLine("Invalid or empty url address!");
        }
        catch (SecurityException)
        {
            Console.WriteLine("You may have not permission to download the file!");
        }
    }
}

