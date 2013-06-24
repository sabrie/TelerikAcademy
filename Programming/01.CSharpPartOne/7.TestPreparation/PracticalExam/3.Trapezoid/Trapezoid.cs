using System;

class Trapezoid
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        // prints the first line of trapezoid
        string dotsFirstLine = new String('.', n);
        string asterisksFirstLine = new String('*', n);
        Console.Write(dotsFirstLine);
        Console.Write(asterisksFirstLine);
        Console.WriteLine();

        // prints the body of trapezoid
        for (int i = 0; i < n - 1; i++)
        {
            string dotsLeft = new String('.', (n - 1) - i);
            string dotsRight = new String('.', (n - 1) + i);
            Console.Write(dotsLeft);
            Console.Write("*");
            Console.Write(dotsRight);
            Console.Write("*");
            Console.WriteLine();
        }
       
        // prints the last line of trapezoid
        string asterisksLastLine = new String('*', 2 * n);
        Console.Write(asterisksLastLine);
        Console.WriteLine();
    }
}

