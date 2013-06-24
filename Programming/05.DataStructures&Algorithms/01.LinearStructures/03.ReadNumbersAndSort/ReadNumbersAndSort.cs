/* Write a program that reads a sequence of integers (List<int>) 
 * ending with an empty line and sorts them in an increasing order.
*/

using System;
using System.Collections.Generic;
using System.Linq;

class ReadNumbersAndSort
{
    static void Main()
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Provide numbers followed Enter: ");
        string input = Console.ReadLine();

        while (input != String.Empty)
        {
            int parsedInput = int.Parse(input);
            numbers.Add(parsedInput);
            input = Console.ReadLine();
        }

        numbers.Sort();

        Console.WriteLine("Sorted: ");
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}

