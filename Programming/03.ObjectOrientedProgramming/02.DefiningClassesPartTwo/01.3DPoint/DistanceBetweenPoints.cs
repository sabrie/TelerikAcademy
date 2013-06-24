using System;

public static class DistanceBetweenPoints
{
    // method that calculates the distance between two 3D points
    public static double CalcDistance(Struct3DPoint point1, Struct3DPoint point2)
    {
        double distance = Math.Sqrt((point1.X - point2.X)*(point1.X - point2.X) + 
                                    (point1.Y - point2.Y)*(point1.Y - point2.Y) + 
                                    (point1.Z - point2.Z)*(point1.Z - point2.Z));
        return distance;
    }
}

