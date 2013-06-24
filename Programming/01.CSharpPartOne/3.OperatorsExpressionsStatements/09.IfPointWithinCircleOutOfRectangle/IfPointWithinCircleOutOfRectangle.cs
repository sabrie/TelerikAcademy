/* Write an expression that checks for given point (x, y) 
 * if it is within the circle K((1,1), 3) and out of the 
 * rectangle R(top=1, left=-1, width=6, height=2).
 */
using System;

class IfPointWithinCircleOutOfRectangle
{
    static void Main()
    {
        double x = 2;
        double y = 2;
        double r = 3;
        bool checkWithinCircle = (x-1)*(x-1) + (y-1)*(y-1) <= r*r;
        bool checkXInRectangle = (x >= -1) && (x <= 5);
        bool checkYInRectangle = (y >= -1) && (y <= 1);

        if (checkWithinCircle)
        {
            Console.WriteLine("The point (x={0}, y={1}) is within the circle K((1,1),3) ", x, y);

            if (!checkXInRectangle || !checkYInRectangle)
            {
                Console.WriteLine("and out of the rectangle R(top=1, left=-1, width=6, height=2). ");
            }
            else
            {
                Console.WriteLine("and within the rectangle R(top=1, left=-1, width=6, height=2).");
            }
        }
        else
        {
            Console.WriteLine("The point (x={0}, y={1}) is NOT within the circle K((1,1),3).", x, y);
        }
    }
}

