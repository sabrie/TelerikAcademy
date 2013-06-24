using System;

class Program
{
    static void Main()
    {
        BitArray64 array = new BitArray64();


        // we set the bit at given position to 1 using the indexer
        array[0] = 1;

        // we set the bit at given position to 1 using the indexer
        array[2] = 1;

        // print the value of bit at given position 
        Console.WriteLine("Bit at position {0} is: {1}", 2, array[2]);
    }
}
