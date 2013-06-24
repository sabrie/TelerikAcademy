/* Write a program that finds in given array of integers 
 * (all belonging to the range [0..1000]) how many times each of them occurs.
    Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
    2 -> 2 times
    3 -> 4 times
    4 -> 3 times 
 */

using System;
using System.Collections.Generic;
using System.Linq;


class FindElementOccurencesInArray
{
    static void Main()
    {
        int[] array = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

        IDictionary<int, int> occurences = CountElementOccurences(array);

        PrintElementOccurences(occurences);
    }
    
    private static IDictionary<int, int> CountElementOccurences(int[] array)
    {
        IDictionary<int, int> occurences = new Dictionary<int, int>();

        foreach (int number in array)
        {
            if (!occurences.ContainsKey(number))
            {
                occurences[number] = 0;
            }
            occurences[number]++;
        }
        
        return occurences;
    }

    private static void PrintElementOccurences(IDictionary<int, int> occurences)
    {
        foreach (var number in occurences)
        {
            Console.WriteLine("{0} -> {1} times", number.Key, number.Value);
        }
    }
}

