using System;
using System.Linq;

class Rotator
{
    static void Main()
    {
        Console.WriteLine("Coordinates: ");
        Coordinates coordinates = new Coordinates(4, 5);
        Console.WriteLine(coordinates);

        double rotationAngle = 30;        
        Coordinates coordinatesAfterRotation = Rotate(coordinates, rotationAngle);
        Console.WriteLine("Coordinates after rotation by {0} degrees: \n{1}", rotationAngle, coordinatesAfterRotation);
    }

    /// <summary>
    /// Rotates given coordinates by given angle in degrees
    /// </summary>
    /// <returns>Returns coordinates after rotation</returns>
    public static Coordinates Rotate(Coordinates currentCoordinates, double angleInDegrees)
    {
        double angleInRadians = (Math.PI / 180) * angleInDegrees;

        double sin = Math.Abs(Math.Sin(angleInRadians));
        double cos = Math.Abs(Math.Cos(angleInRadians));

        double xCoordinateAfterRoration = cos * currentCoordinates.X - sin * currentCoordinates.Y;
        double yCoordinateAfterRotation = sin * currentCoordinates.X + cos * currentCoordinates.Y;

        Coordinates coordinatesAfterRotation = new Coordinates(xCoordinateAfterRoration, yCoordinateAfterRotation);

        return coordinatesAfterRotation;
    }
}
