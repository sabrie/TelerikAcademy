using System;
using System.Linq;

namespace Abstarction
{
    class Rectangle : Figure
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalcPerimeter()
        {
            return base.CalcPerimeterHelper(2);
        }

        public override double CalcSurface()
        {
            return base.CalcSurfaceHelper(1);
        }
    }
}
