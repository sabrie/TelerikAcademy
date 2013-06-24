using System;
using System.Collections.Generic;
using System.IO;

public static class PathStorage
{
    // method that saves/writes the path to a file
    public static void SavePath(List<Struct3DPoint> points, string fileName)
    {
        StreamWriter writer = new StreamWriter(fileName);
        using (writer)
        {
            // write/ save the points from the List to a file
            for (int i = 0; i < points.Count; i++)
            {
                writer.WriteLine(points[i]);
            }
        }
    }

    // method that loads/saves the path from a file
    public static Path LoadPath(string fileName)
    {
        Path points = new Path();

        using (StreamReader reader = new StreamReader(fileName))
        {
            string line = reader.ReadLine();

            while (line != null)
            {
                string[] linePoints = line.Split(' ');
                Struct3DPoint currentPoint = new Struct3DPoint();

                currentPoint.X = int.Parse(linePoints[0]);
                currentPoint.Y = int.Parse(linePoints[1]);
                currentPoint.Z = int.Parse(linePoints[2]);

                points.Add(currentPoint);

                line = reader.ReadLine();                
            }  
        }
        return points;
    }
}

