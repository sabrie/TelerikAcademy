using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    public abstract class Shape
    {
        // properties
        public double Width { get; protected set; }
        public double Height { get; protected set; }

        // constructor
        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        // abstract method to calculate the surface
        public abstract double CalculateSurface();

        // a helper method which is envoked by the overriden CalculateSurface(); method in each child class
        // depending on the coefficient which is passed - it calculates the surface of triangle (1/2), rectangle (1), Circle(Math.PI)
        protected virtual double CalculateSurfaceHelper(double coefficient)
        {
            return this.Width * this.Height * coefficient;
        }
    }
}
