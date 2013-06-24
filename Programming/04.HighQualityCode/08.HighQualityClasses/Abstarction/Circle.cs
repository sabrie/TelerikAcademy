using System;
using System.Linq;

namespace Abstarction
{
    class Circle : Figure
    {
        public Circle(double radius)
            : base(radius, radius)
        {
        }

        public override double CalcPerimeter()
        {
            // perimeter = Math.PI * (radius + radius)
            return base.CalcPerimeterHelper(Math.PI);
        }

        public override double CalcSurface()
        {
            // surface = Math.PI * radius * radius
            return base.CalcSurfaceHelper(Math.PI);
        }
    }
}
