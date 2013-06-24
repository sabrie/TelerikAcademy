using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadNumsAndSortUsingDynamicList
{
    class ReadNumsAndSortUsingDynamicList
    {
        static void Main()
        {
            SortedSet<int> numbers = new SortedSet<int>();

            string input = Console.ReadLine();

            while (input != String.Empty)
            {
                int parsedInput = int.Parse(input);
                numbers.Add(parsedInput);
                input = Console.ReadLine();
            }

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
