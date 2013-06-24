using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    public class Triangle : Shape
    {
        // constructor
        // and call the base constructor to initialize the side and height
        public Triangle(double side, double height)
            : base(side, height)
        {

        }
        // we override the abstract method CalculateSurface() in class Shape
        public override double CalculateSurface()
        {
            // we call the method CalculateSurfaceHelper() from class Shape and pass as agrument 0.5 (or 1/2)
            // as the formula for calculating the triangle surface is  - width*height*(1/2)
            return base.CalculateSurfaceHelper(0.5);
        }
    }
}
