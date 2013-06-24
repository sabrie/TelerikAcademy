using System;

class FighterAttack
{
    static void Main()
    {
        int px1 = int.Parse(Console.ReadLine());
        int py1 = int.Parse(Console.ReadLine());
        int px2 = int.Parse(Console.ReadLine());
        int py2 = int.Parse(Console.ReadLine());
        int fx = int.Parse(Console.ReadLine());
        int fy = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        fx = fx + d;
        //// if using this it gives run time error in bgcoder.bg and 80/100 points
        //int fyUp = fy + 1; 
        //int fyDown = fy - 1;
        //int fxNext = fx + 1;

        int damage = 0;
        int pxMax = Math.Max(px1, px2);
        int pxMin = Math.Min(px1, px2);
        int pyMax = Math.Max(py1, py2);
        int pyMin = Math.Min(py1, py2);

        // check if symmetrical F is within the rectangular
        if (fx >= pxMin && fx <= pxMax && fy >= pyMin && fy <= pyMax)
        {
            damage = damage + 100;
        }
        // check if the point in front of symmetrical F is within the rectangular
        if (fx + 1 >= pxMin && fx + 1 <= pxMax && fy >= pyMin && fy <= pyMax)
        {
            damage = damage + 75;
        }
        // check if the point on the left of symmetrical F is within the rectangular
        if (fx >= pxMin && fx <= pxMax && fy + 1 >= pyMin && fy + 1 <= pyMax)
        {
            damage = damage + 50;
        }
        // check if the point on the right of symmetrical F is within the rectangular
        if (fx >= pxMin && fx <= pxMax && fy - 1 >= pyMin && fy -1 <= pyMax)
        {
            damage = damage + 50;
        }
        // prints the total damage
        Console.WriteLine(damage + "%");
    }
}

