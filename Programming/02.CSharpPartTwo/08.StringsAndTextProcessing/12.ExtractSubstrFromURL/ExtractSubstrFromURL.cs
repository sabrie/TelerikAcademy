/* Write a program that parses an URL address given in the format:
 * and extracts from it the [protocol], [server] and [resource] elements. 
 * For example from the URL http://www.devbg.org/forum/index.php the 
 * following information should be extracted:
 * 		[protocol] = "http"
 * 		[server] = "www.devbg.org"
 * 		[resource] = "/forum/index.php"
*/
using System;

class ExtractSubstrFromURL
{
    static void Main()
    {
        string urlAddress = "http://www.devbg.org/forum/index.php";

        int colon = urlAddress.IndexOf(':');
        // index of first occurence of slash after ://
        int urlSlash = urlAddress.IndexOf('/', colon + 3);

        if (colon != -1)
        {
            // prints the protocol starting from [0] until ":" is reached 
            string protocol = urlAddress.Substring(0, colon);
            Console.WriteLine("[protocol] = {0}", protocol);

            int serverLength = urlSlash - (colon + 3);
            string server = urlAddress.Substring(colon + 3, serverLength);
            Console.WriteLine("[server] = {0}", server);

            // print the substring of the url starting from the slash after "://"
            string resources = urlAddress.Substring(urlSlash);
            Console.WriteLine("[resource] = {0}", resources);
        }

        //reshenie na drug kolega
        //string uri = "http://academy.telerik.com/academy/majors/about.index";
        //var fragments = Regex.Match(uri, "(.*)://(.*?)(/.*)").Groups;
        //Console.WriteLine(fragments[1]);
        //Console.WriteLine(fragments[2]);
        //Console.WriteLine(fragments[3]);
    }
}

