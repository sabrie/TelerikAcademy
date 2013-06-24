using System;
using System.Linq;


class GeometryMethods
{
    public static double CalcVolume(double width, double height, double depth)
    {
        if (width <= 0 || height <= 0 || depth <= 0)
        {
            throw new ArgumentOutOfRangeException("Sides must be positive!");
        }
        
        double volume = width * height * depth;
        
        return volume;
    }
}

