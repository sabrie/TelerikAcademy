/* Write an expression that calculates trapezoid's 
 * area by given sides a and b and height h.
 */
using System;

class CalculatesTrapezoidArea
{
    static void Main()
    {
        // a and b are the sides
        // h is the height
        double a = 5.0; 
        double b = 8.0; 
        double h = 4.0;
        // This expression calculates the trapezoid area
        double area = (a + b) * h / 2; 

        Console.WriteLine("The area of a trapezoid with sides a={0}, b={1} and height={2} is {3}.",
                            a, b, h, area);
    }
}

