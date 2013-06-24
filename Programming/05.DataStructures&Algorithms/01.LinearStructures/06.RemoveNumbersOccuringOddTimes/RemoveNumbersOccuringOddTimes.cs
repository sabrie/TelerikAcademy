/* Write a program that removes from given sequence all 
 * numbers that occur odd number of times. Example:
 * 
 * {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} -> {5, 3, 3, 5}
*/

using System;
using System.Collections.Generic;
using System.Linq;


class RemoveNumbersOccuringOddTimes
{
    static void Main()
    {
        LinkedList<int> numbers = new LinkedList<int>(
            new int[] { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 });

        LinkedList<int> removedOddOccurences = RemoveOddOccurences(numbers);

        Console.WriteLine(string.Join(", ", removedOddOccurences));
    }

    private static LinkedList<int> RemoveOddOccurences(LinkedList<int> list)
    {
        Dictionary<int, int> groupedByOccurences = GroupByOccurences(list);

        LinkedList<int> listCopy = new LinkedList<int>(list);

        foreach (var number in groupedByOccurences)
        {
            if ((number.Value % 2) != 0)
            {
                for (int i = 0; i < number.Value; i++)
                {
                    listCopy.Remove(number.Key);
                }
            }
        }

        return listCopy;
    }

    private static Dictionary<int, int> GroupByOccurences(LinkedList<int> list)
    {
        Dictionary<int, int> occurences = new Dictionary<int, int>();

        foreach (int element in list)
        {
            if (!occurences.ContainsKey(element))
            {
                occurences[element] = 0;
            }
            occurences[element]++;
        }
        return occurences;
    }
}

