/*
 * Task 06.
 Write a program, which using XDocument and LINQ query
 extracts all song titles from catalog.xml.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


class ExtractDataUsingXDocument
{
    static void Main()
    {
        XDocument xmlDoc = XDocument.Load("../../catalogue.xml");
        var songs =
            from song in xmlDoc.Descendants("song")
            select new
            {
                Title = song.Element("title").Value,
            };
        Console.WriteLine("Found {0} songs:", songs.Count());
        foreach (var song in songs)
        {
            Console.WriteLine(" - {0}", song.Title);
        }
    }
}

