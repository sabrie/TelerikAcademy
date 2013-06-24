/* Write a program that reads the radius r of a 
 * circle and prints its perimeter and area.
 */
using System;

class ReadRadiusAndPrintCircleAreaPerimeter
{
    static void Main()
    {
        Console.WriteLine("To calculate the perimeter and the area of a circle, please:");
        Console.Write("Enter a value for the radius: ");
        double radius = double.Parse(Console.ReadLine());

        double perimeter = (Math.PI * radius) / 2;
        double area = Math.PI * radius * radius;

        Console.WriteLine("The perimeter of the circle with radius {0} is {1:0.00} ", radius, perimeter);
        Console.WriteLine("The area of the circle with radius {0} is {1:0.00} ", radius, area);
    }
}

