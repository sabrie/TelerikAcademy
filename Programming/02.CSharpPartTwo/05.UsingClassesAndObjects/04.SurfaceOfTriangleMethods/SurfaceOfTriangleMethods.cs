/* Write methods that calculate the surface of a triangle by given:
 * - Side and an altitude to it; 
 * - Three sides; 
 * - Two sides and an angle between them. 
 * Use System.Math
 */
using System;

class SurfaceOfTriangleMethods
{
    static double CalcTriangleSurfaceByThreeSides(double a, double b, double c)
    {
        // Heron's formula
        // p is the semiperimeter of the triangle
        double p = (a + b + c) / 2;
        double surface = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        
        return surface;
    }

    static double CalcTriangleSurfaceBySideAltitude(double side, double altitude)
    {
        double surface = (side * altitude) / 2;
        return surface;
    }

    static double CalcTriangleSurfaceByTwoSideAngle(double a, double b, double angle)
    {
        double angleToRadians = (angle * Math.PI) / 180;
        double surface = (a * b * Math.Sin(angleToRadians)) / 2;
        
        return surface;
    }

    static void Main()
    {
        double sideA = 3;
        double sideB = 4;
        double sideC = 5;
        double altitude = 3;
        double angle = 90;

        double surface = CalcTriangleSurfaceByThreeSides(sideA, sideB, sideC);
        Console.WriteLine("Surface is: {0} cm", surface);
        
        surface = CalcTriangleSurfaceBySideAltitude(sideB, altitude);
        Console.WriteLine("Surface is: {0} cm", surface);
        
        surface = CalcTriangleSurfaceByTwoSideAngle(sideA, sideB, angle);
        Console.WriteLine("Surface is: {0} cm", surface);        
    }
}

