using System;

class Program
{
    static void Main()
    {
        int[] array = new int[] { 1, 2, 3, 4, 5, 6 };

        Console.Write("Array: ");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine();
        Console.Write("Minimal value in array is: ");
        Console.WriteLine(array.Min());

        Console.Write("Maximal value in array is: ");
        Console.WriteLine(array.Max());

        Console.Write("Sum of array elements is: ");
        Console.WriteLine(array.Sum());

        Console.Write("Product of array elements is: ");
        Console.WriteLine(array.Product());        
    }
}
