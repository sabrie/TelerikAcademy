using System;

class ShipDamage
{
    static void Main()
    {
        int sx1 = int.Parse(Console.ReadLine());
        int sy1 = int.Parse(Console.ReadLine());
        int sx2 = int.Parse(Console.ReadLine());
        int sy2 = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());
        int cx1 = int.Parse(Console.ReadLine());
        int cy1 = int.Parse(Console.ReadLine());
        int cx2 = int.Parse(Console.ReadLine());
        int cy2 = int.Parse(Console.ReadLine());
        int cx3 = int.Parse(Console.ReadLine());
        int cy3 = int.Parse(Console.ReadLine());
        int cy1Mirror = (2 * h) - cy1;
        int cy2Mirror = (2 * h) - cy2;
        int cy3Mirror = (2 * h) - cy3;
        int damage = 0;

        // if sx1 > sx2 - exchanges their values
        if (sx1 > sx2)
        {
            int exchangeX = sx1;
            sx1 = sx2;
            sx2 = exchangeX;
        }
        // if sy1 < sy2 - exchanges their values
        if (sy1 < sy2)
        {
            int exchangeY = sy1;
            sy1 = sy2;
            sy2 = exchangeY;
        }

        // checks if symmetrical point of C1, C2 and C3 are in the rectangle
        if (cx1 > sx1 && cx1 < sx2 && cy1Mirror > sy2 && cy1Mirror < sy1)
        {
            damage = damage + 100;
        }
        if (cx2 > sx1 && cx2 < sx2 && cy2Mirror > sy2 && cy2Mirror < sy1)
        {
            damage = damage + 100;
        }
        if (cx3 > sx1 && cx3 < sx2 && cy3Mirror > sy2 && cy3Mirror < sy1)
        {
            damage = damage + 100;
        }

        // checks if symmetrical point of C1, C2 and C3 are in the rectangle's side
        if (cx1 > sx1 && cx1 < sx2 && cy1Mirror == sy2)
        {
            damage = damage + 50;
        }
        if (cx2 > sx1 && cx2 < sx2 && cy2Mirror == sy2)
        {
            damage = damage + 50;
        }
        if (cx3 > sx1 && cx3 < sx2 && cy3Mirror == sy2)
        {
            damage = damage + 50;
        }
        if (cx1 > sx1 && cx1 < sx2 && cy1Mirror == sy1)
        {
            damage = damage + 50;
        }
        if (cx2 > sx1 && cx2 < sx2 && cy2Mirror == sy1)
        {
            damage = damage + 50;
        }
        if (cx3 > sx1 && cx3 < sx2 && cy3Mirror == sy1)
        {
            damage = damage + 50;
        }
        if (cy1Mirror > sy2 && cy1Mirror < sy1 && cx1 == sx1)
        {
            damage = damage + 50;
        }
        if (cy2Mirror > sy2 && cy2Mirror < sy1 && cx2 == sx1)
        {
            damage = damage + 50;
        }
        if (cy3Mirror > sy2 && cy3Mirror < sy1 && cx3 == sx1)
        {
            damage = damage + 50;
        }
        if (cy1Mirror > sy2 && cy1Mirror < sy1 && cx1 == sx2)
        {
            damage = damage + 50;
        }
        if (cy2Mirror > sy2 && cy2Mirror < sy1 && cx2 == sx2)
        {
            damage = damage + 50;
        }
        if (cy3Mirror > sy2 && cy3Mirror < sy1 && cx3 == sx2)
        {
            damage = damage + 50;
        }
        // checks if symmetrical point of C1, C2 and C3 are in the corner
        if (cx1 == sx1 && cy1Mirror == sy2)
        {
            damage = damage + 25;
        }
        if (cx2 == sx1 && cy2Mirror == sy2)
        {
            damage = damage + 25;
        }
        if (cx3 == sx1 && cy3Mirror == sy2)
        {
            damage = damage + 25;
        }
        if (cx1 == sx2 && cy1Mirror == sy2)
        {
            damage = damage + 25;
        }
        if (cx2 == sx2 && cy2Mirror == sy2)
        {
            damage = damage + 25;
        }
        if (cx3 == sx2 && cy3Mirror == sy2)
        {
            damage = damage + 25;
        }
        if (cx1 == sx1 && cy1Mirror == sy1)
        {
            damage = damage + 25;
        }
        if (cx2 == sx1 && cy2Mirror == sy1)
        {
            damage = damage + 25;
        }
        if (cx3 == sx1 && cy3Mirror == sy1)
        {
            damage = damage + 25;
        }
        if (cx1 == sx2 && cy1Mirror == sy1)
        {
            damage = damage + 25;
        }
        if (cx2 == sx2 && cy2Mirror == sy1)
        {
            damage = damage + 25;
        }
        if (cx3 == sx2 && cy3Mirror == sy1)
        {
            damage = damage + 25;
        }

        Console.WriteLine(damage + "%");
    }
}