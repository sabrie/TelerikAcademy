/*
 * Task
 Write program that extracts all different artists 
 * which are found in the catalog.xml. For each author 
 * you should print the number of albums in the catalogue. 
 * Use the XPath parser.

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

class ExtractDataUsingXPath
{
    static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("../../catalogue.xml");
        string xPathQuery = "/catalog/album";

        XmlNodeList ArtistsList = xmlDoc.SelectNodes(xPathQuery);
        Dictionary<string, int> artistsAndAlbumsCount = new Dictionary<string, int>();

        foreach (XmlNode ArtistNode in ArtistsList)
        {
            string authorName = ArtistNode.SelectSingleNode("artist").InnerText;
            if (artistsAndAlbumsCount.ContainsKey(authorName))
            {
                artistsAndAlbumsCount[authorName]++;
            }
            else
            {
                artistsAndAlbumsCount.Add(authorName, 1);
            }
        }

        foreach (var artist in artistsAndAlbumsCount)
        {
            Console.WriteLine("Artist: {0}", artist.Key);
            Console.WriteLine("Albums count: {0}", artist.Value);
            Console.WriteLine();
        }
    }
}

