using System;
using System.Linq;

namespace CohesionAndCoupling
{
    class Point2D
    {
        public double X { get; protected set; }
        public double Y { get; protected set; }

        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static double CalcDistanceBetween2DPoints(Point2D p1, Point2D p2)
        {
            double distance = Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) +
                                        (p2.Y - p1.Y) * (p2.Y - p1.Y));
            return distance;
        }

        public double CalcDiagonalXY()
        {
            double diagonalXY = Math.Sqrt(this.X + this.Y);
            return diagonalXY;
        }
    }
}
