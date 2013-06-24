/*
 Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.
    Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
    -2.5 -> 2 times
    3 -> 4 times
    4 -> 3 times
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FindElementOccurencesInArray
{
    static void Main()
    {
        double[] elements = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

        IDictionary<double, int> groupedByOccurences = GroupByOccurences(elements);

        PrintElementOccurences(groupedByOccurences);
    }    

    private static IDictionary<double, int> GroupByOccurences(double[] array)
    {
        IDictionary<double, int> groupedByOccurences = new Dictionary<double, int>();

        foreach (double element in array)
        {
            if (!groupedByOccurences.ContainsKey(element))
            {
                groupedByOccurences[element] = 0;
            }
            groupedByOccurences[element]++;
        }

        return groupedByOccurences;
    }

    private static void PrintElementOccurences(IDictionary<double, int> groupedByOccurences)
    {
        foreach (var element in groupedByOccurences)
        {
            Console.WriteLine("{0} -> {1} times", element.Key, element.Value);
        }
    }
}

