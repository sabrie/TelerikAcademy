/* Write an expression that checks if given point 
 * (x, y) is within a circle K(O, 5).
 */
using System;

class CheckIfAPointIsWithinCircle
{
    static void Main()
    {
        double x = 2.5;
        double y = 8.4;
        double r = 5;
        bool checkIfWithin = (x * x) + (y * y) <= (r*r);

        Console.Write("The point (x={0}, y={1}) is ", x, y);

        if (checkIfWithin)
        {
            Console.WriteLine("within the circle K(0,5).");
        }
        else
        {
            Console.WriteLine("NOT within the circle K(0,5).");
        }
    }
}

