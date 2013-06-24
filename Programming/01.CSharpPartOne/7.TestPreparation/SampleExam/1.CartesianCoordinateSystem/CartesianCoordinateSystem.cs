using System;

class CartesianCoordinateSystem
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());

        int result = 0;

        if (y > 0 && x > 0)
        {
            result = 1;
        }
        if (y < 0 && x < 0)
        {
            result = 3;
        }

        if (y > 0 && x < 0)
        {
            result = 2;
        }
        if (y < 0 && x > 0)
        {
            result = 4;
        }
        if (x == 0 && y != 0)
        {
            result = 5;
        }
        if (y == 0 && x != 0)
        {
            result = 6;
        }
        if (y == 0 && x == 0)
        {
            result = 0;
        }
        Console.WriteLine(result);
    }
}
