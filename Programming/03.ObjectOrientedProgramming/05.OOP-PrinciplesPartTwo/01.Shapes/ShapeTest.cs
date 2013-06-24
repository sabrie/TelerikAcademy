using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    class ShapeTest
    {
        // method that print a collection on the Console
        static void Print(IEnumerable list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // create a list of shapes using their constructors
            List<Shape> shapes = new List<Shape> 
            {
                new Triangle(4, 5), // call the constructor of Triangle class and pass 2 arguments
                new Circle(4),  // call the constructor of Circle class and pass 1 argument - the radius
                new Rectangle(5, 8) // call the constructor of Rectangle class and pass 2 arguments
            };

            Console.WriteLine();
            
            
            foreach (Shape shape in shapes)
            {
                Console.Write(shape.GetType().Name); // print the type of each shape in shapes
                Console.WriteLine(" -> Surface = {0}", shape.CalculateSurface()); // call the method CalculateSurface() for each shape in shapes
            }

            // Anothe way to print the Surface of different figures hold in the List<Shape> shapes;
            // using the method Print created in this class and lambda expression
            // Print(shapes.Select(shape => shape.CalculateSurface()));
            
        }
    }
}
