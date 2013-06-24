using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    public class Circle : Shape
    {
        // constructor
        // we pass as parameter only the radius
        // and call the base constructor to initialize it twice
        public Circle(double radius)
            : base(radius, radius)
        {

        }

        // we override the abstract method CalculateSurface() in class Shape
        public override double CalculateSurface()
        {
            // we call the method CalculateSurfaceHelper() from class Shape and pass as agrument Math.PI
            return base.CalculateSurfaceHelper(Math.PI);
        }
    }
}
