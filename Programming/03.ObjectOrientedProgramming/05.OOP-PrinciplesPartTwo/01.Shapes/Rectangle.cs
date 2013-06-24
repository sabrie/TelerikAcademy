using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    public class Rectangle : Shape
    {
        // constructor
        // we pass as parameter the width and height
        // and call the base constructor to initialize them
        public Rectangle(double width, double height)
            :base(width, height)
        {

        }
        // we override the abstract method CalculateSurface() in class Shape
        public override double CalculateSurface()
        {
            // we call the method CalculateSurfaceHelper() from class Shape and pass as agrument 1
            // as the formula for calculating the rectangle surface is  - width*height*1
            return base.CalculateSurfaceHelper(1);
        }
    }
}
