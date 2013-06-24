// Write an expression that calculates rectangle’s 
// area by given width and height.
using System;

class CalculatesRectangleArea
{
    static void Main()
    {
        double rectangleWidth = 4;
        double rectangleHeight = 8;
        double rectangleArea = rectangleWidth * rectangleHeight;

        Console.WriteLine("The area of a rectangle with height={0} and width={1} is {2}: " 
                            ,rectangleHeight, rectangleWidth, rectangleArea);
    }
}

