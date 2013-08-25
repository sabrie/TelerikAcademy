/*
 * Task 04.
 Using the DOM parser write a program to delete 
 from catalog.xml all albums having price > 20.

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


class DeleteFromXMLUsingDOMParser
{
    static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("../../catalogue.xml");

        XmlNode rootNode = doc.DocumentElement;

        HashSet<string> artistsSet = new HashSet<string>();
        List<XmlNode> albumsToDelete = new List<XmlNode>();
        
        decimal searchedPrice = 15;
        foreach (XmlNode node in rootNode.ChildNodes)
        {
            decimal parsedPrice = decimal.Parse(node["price"].InnerText);

            if (parsedPrice > searchedPrice)
            {
                albumsToDelete.Add(node);
            }
        }

        foreach (var album in albumsToDelete)
        {
            rootNode.RemoveChild(album);
        }

        // see the created catalogue_new.xml file to see that files are deleted
        doc.Save("../../catalogue_new.xml");
    }
}

