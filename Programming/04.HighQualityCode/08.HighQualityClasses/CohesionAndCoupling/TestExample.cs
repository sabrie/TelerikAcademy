using System;
using System.Linq;

namespace CohesionAndCoupling
{
    class TestExample
    {
        static void Main(string[] args)
        {
            // Tests for file extraction methods
            {
                Console.WriteLine(FileExtractor.GetFileExtension("example"));
                Console.WriteLine(FileExtractor.GetFileExtension("example.pdf"));
                Console.WriteLine(FileExtractor.GetFileExtension("example.new.pdf"));

                Console.WriteLine(FileExtractor.GetFileNameWithoutExtension("example"));
                Console.WriteLine(FileExtractor.GetFileNameWithoutExtension("example.pdf"));
                Console.WriteLine(FileExtractor.GetFileNameWithoutExtension("example.new.pdf"));
            }

            Console.WriteLine();

            // Tests for 2D point methods
            {
                Point2D firstPoint2D = new Point2D(2, 2);
                Point2D secondPoint2D = new Point2D(3, 3);

                double distance = Point2D.CalcDistanceBetween2DPoints(firstPoint2D, secondPoint2D);

                Console.WriteLine("Distance in the 2D space = {0:f2}", distance);
                Console.WriteLine("Diagonal XY = {0:f2}", firstPoint2D.CalcDiagonalXY());
            }

            Console.WriteLine();

            // Tests for 3D point methods
            {
                Point3D firstPoint3D = new Point3D(1, 2, 3);
                Point3D secondPoint3D = new Point3D(4, 5, 6);

                double distance = Point3D.CalcDistanceBetween3DPoints(firstPoint3D, secondPoint3D);
                Console.WriteLine("Distance in the 3D space = {0:f2}", distance);

                // To calculate the Volume we should first create a 3D figure - i.e. a rectangular parallelepiped
                // which has width, height and depth.
                // GeometryMethods.CalcVolume(myParallepiped.Width, myParallepiped.Height, myParallepiped.Depth));
                Console.WriteLine("Diagonal XYZ = {0:f2}", firstPoint3D.CalcDiagonalXYZ());
                Console.WriteLine("Diagonal XY = {0:f2}", firstPoint3D.CalcDiagonalXY());
                Console.WriteLine("Diagonal XZ = {0:f2}", firstPoint3D.CalcDiagonalXZ());
                Console.WriteLine("Diagonal YZ = {0:f2}", firstPoint3D.CalcDiagonalYZ());
            }
        }
    }
}
