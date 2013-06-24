using System;
using System.Collections.Generic;

public class Path
{
    // a list that holds sequence of 3D points
    public List<Struct3DPoint> points = new List<Struct3DPoint>();

    // method that adds points to the list of points
    public void Add(Struct3DPoint currentPoint)
    {
        this.points.Add(currentPoint);
    }
}
