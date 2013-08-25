/*
 Task 05.
 Write a program, which using XmlReader 
 extracts all song titles from catalog.xml

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


public class ExtractDataUsingXmlReader
{
    static void Main()
    {
        Console.WriteLine("Song titles in the catalogue:");
        using (XmlReader reader = XmlReader.Create("../../catalogue.xml"))
        {
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) &&
                    (reader.Name == "title"))
                {

                    Console.WriteLine(reader.ReadElementString());
                }
            }
        }
    }
}

