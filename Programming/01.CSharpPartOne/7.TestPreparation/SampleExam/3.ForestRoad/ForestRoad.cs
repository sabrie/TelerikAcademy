using System;

class ForestRoad
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i <= n - 1; i++)
        {
            string dotsLeft = new String('.', i);
            string asterisks = new String('*', 1);
            string dotsRight = new String('.', n - 1 - i);
            Console.Write(dotsLeft);
            Console.Write(asterisks);
            Console.Write(dotsRight);
            Console.WriteLine();
        }

        for (int j = n - 2; j >= 0; j--)
        {
            string dotsLeftBack = new String('.', j);
            string asterisksBack = new String('*', 1);
            string dotsRightBack = new String('.', n - j - 1);
            Console.Write(dotsLeftBack);
            Console.Write(asterisksBack);
            Console.Write(dotsRightBack);
            Console.WriteLine();
        }
    }
}

