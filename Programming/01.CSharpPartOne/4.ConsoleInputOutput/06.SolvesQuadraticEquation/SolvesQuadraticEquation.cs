/* Write a program that reads the coefficients a, b and c of a quadratic equation
 * axx+bx+c=0 and solves it (prints its real roots)*/
using System;

class SolvesQuadraticEquation
{
    static void Main()
    {
        Console.WriteLine("This program solves a quadratic equation axx+bx+c=0 by given coefficients 'a', 'b', and 'c':");
        Console.Write("Enter coefficient a (different from 0): ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter coefficient b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter coefficient c: ");
        double c = double.Parse(Console.ReadLine());

        double discriminant = b * b - 4 * a * c;
        // x1 and x2 are the solutions.
        double x1, x2;

        if (discriminant == 0) // If the discriminant is 0, x1=x2.
        {
            x1 = -b / (2 * a);
            Console.WriteLine("The solution is x = {0}: ", x1);
        }
        else if (discriminant < 0) // If the discriminant is negative, there are no solutions.
        {
            Console.WriteLine("There are no solutions for the equation!");
        }
        else // In other cases the discriminant is positive, so there are two different solutions.
        {
            x1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            x2 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            Console.WriteLine("The solutions are \n x1 = {0} \n x2 = {1}.", x1, x2);
        }
    }
}


