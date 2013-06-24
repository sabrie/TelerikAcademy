﻿using System;

class SandGlass
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        // upper part of the Sand Glass
        for (int i = 0; i <= n / 2; i++)
        {
            string asterisks = new String('*', n - (2 * i));
            string dots = new String('.', i);
            Console.Write(dots);
            Console.Write(asterisks);
            Console.Write(dots);
            Console.WriteLine();
        }
        // lower part of the Sand Glass
        for (int j = n / 2 - 1; j >= 0; j--)
        {
            string dotsDown = new String('.', j);
            string asterisksDown = new String('*', n - (2 * j));
            Console.Write(dotsDown);
            Console.Write(asterisksDown);
            Console.Write(dotsDown);
            Console.WriteLine();
        }
    }
}
