using System;
using System.Linq;

namespace CohesionAndCoupling
{
    class Point3D : Point2D
    {
        public double Z { get; protected set; }

        public Point3D(double x, double y, double z)
            : base (x, y)
        {
            Z = z;
        }

        public static double CalcDistanceBetween3DPoints(Point3D p1, Point3D p2)
        {
            double distance = Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) +
                                        (p2.Y - p1.Y) * (p2.Y - p1.Y) +
                                        (p2.Z - p1.Z) * (p2.Z - p1.Z));
            return distance;
        }        

        public double CalcDiagonalXYZ()
        {
            double diagonalXYZ = Math.Sqrt(this.X + this.Y + this.Z);
            return diagonalXYZ;
        }

        public double CalcDiagonalXY()
        {
            double diagonalXY = Math.Sqrt(this.X + this.Y);
            return diagonalXY;
        }

        public double CalcDiagonalXZ()
        {
            double diagonalXZ = Math.Sqrt(this.X + this.Z);
            return diagonalXZ;
        }

        public double CalcDiagonalYZ()
        {
            double diagonalYZ = Math.Sqrt(this.Y + this.Z);
            return diagonalYZ;
        }
    }
}
