
/*
 * Task 01.
 Create a XML file representing catalogue. 
 * The catalogue should contain albums of different artists. 
 * For each album you should define: name, artist, year, 
 * producer, price and a list of songs. Each song should 
 * be described by title and duration.
 * 
 * Task 02.
 * Write program that extracts all different artists which are 
 * found in the catalog.xml. For each author you should
 * print the number of albums in the catalogue. Use the 
 * DOM parser and a hash-table.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


class ExtractDataFromXML
{
    static void Main()
    {
        // Task 01.
        // See the created catalogue.xml file in project folder

        // Task 2
        XmlDocument doc = new XmlDocument();
        doc.Load("../../catalogue.xml");

        XmlNode rootNode = doc.DocumentElement;

        Dictionary<string, int> artistsAndAlbumsCount = new Dictionary<string, int>();

        foreach (XmlNode node in rootNode.ChildNodes)
        {
            string authorName = node["artist"].InnerText;
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

