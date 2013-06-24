using System;
using System.Linq;
using System.Text;

namespace Abstarction
{
    abstract class Figure
    {
        private double width = 0;
        private double height = 0;

        public virtual double Width 
        { 
            get
            {
                return this.width;
            } 
            protected set 
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Parameters of the figure should be bigger than 0.");
                }

                this.width = value;
            } 
        }

        public virtual double Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Parameters of the figure should be bigger than 0.");
                }

                this.height = value;
            }
        }

        public Figure()
        {
        }

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public abstract double CalcPerimeter();

        protected virtual double CalcPerimeterHelper(double coefficient)
        {
            double perimeter = coefficient * (this.Width + this.Height);
            
            return perimeter;
        }

        public abstract double CalcSurface();

        protected virtual double CalcSurfaceHelper(double coefficient)
        {
            double surface = coefficient * this.Width * this.Height;
            
            return surface;
        }

        public override string ToString()
        {
            return String.Format("I am a {0}. " +
                "My perimeter is {1:f2}. My surface is {2:f2}.",
                this.GetType().Name, this.CalcPerimeter(), this.CalcSurface());
        }
    }
}
