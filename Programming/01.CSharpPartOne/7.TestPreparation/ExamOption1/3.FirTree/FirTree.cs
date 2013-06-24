using System;

class FirTree
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        // prints the stir tree
        for (int i = 0; i < n - 1; i++)
        {
            string dots = new String('.', (n - 2) - i);
            string asterisks = new String('*', (2 * i) + 1);
            Console.Write(dots);
            Console.Write(asterisks);
            Console.Write(dots);
            Console.WriteLine();
        }
        // Prints the stem
        string dotsStem = new String('.', n - 2);
        string asterisksStem = new String('*', 1);
        Console.Write(dotsStem);
        Console.Write(asterisksStem);
        Console.Write(dotsStem);
        Console.WriteLine();
    }
}

