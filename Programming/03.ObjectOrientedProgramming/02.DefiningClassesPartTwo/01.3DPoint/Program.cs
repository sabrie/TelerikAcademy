using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // the file that we will save/write the points to and load/read the points from
        string fileName = Directory.GetCurrentDirectory() + "\\SavePath.txt";

        // create a list of points from type Struct3DPoint
        List<Struct3DPoint> points = new List<Struct3DPoint>();

        // add points to the List of points using the Add method from the Path class
        points.Add(new Struct3DPoint(1, 1, 1));
        points.Add(new Struct3DPoint(2, 2, 2));
        points.Add(new Struct3DPoint(3, 3, 3));

        // save/write the points to a text file
        PathStorage.SavePath(points, fileName);

        // load/read the points from the same file
        Path loadResult = PathStorage.LoadPath(fileName);

        // print on the Console to see if works correctly
        //foreach (var item in loadResult)
        //{
        //    Console.WriteLine(item);
        //}

        // add new points to the list
        points.Add(new Struct3DPoint(7, 7, 7));
        points.Add(new Struct3DPoint(8, 8, 8));
        points.Add(new Struct3DPoint(9, 9, 9));

        // save/write again the points to a file
        PathStorage.SavePath(points, fileName);
        
        // load/read the points from the same list
        loadResult = PathStorage.LoadPath(fileName);

        // print the points in the list
        // the points printed on the Console should be also present in the file SavePath.txt in bin/Debug folder of this project
        foreach (var item in loadResult.points)
        {
            Console.WriteLine(item);
        }
    }
}