/* Write a program that extracts from a given sequence of strings all 
 * elements that present in it odd number of times. 
 * Example:
    {C#, SQL, PHP, PHP, SQL, SQL } -> {C#, SQL}
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RemoveElementsOccuringOddTimes
{
    static void Main()
    {
        IList<string> elements = new List<string>(
            new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" });

        IList<string> removedOddOccurences = RemoveOddOccurences(elements);

        Console.WriteLine(string.Join(", ", removedOddOccurences)); // Output -> C#, SQL
    }

    private static IList<string> RemoveOddOccurences(IList<string> list)
    {
        IDictionary<string, int> groupedByOccurences = GroupByOccurences(list);

        IList<string> oddOccuringElements = new List<string>();

        foreach (var element in groupedByOccurences)
        {
            if ((element.Value % 2) != 0)
            {
                oddOccuringElements.Add(element.Key);
            }
        }

        return oddOccuringElements;
    }

    private static IDictionary<string, int> GroupByOccurences(IList<string> list)
    {
        IDictionary<string, int> groupedByOccurences = new Dictionary<string, int>();

        foreach (var element in list)
        {
            if (!groupedByOccurences.ContainsKey(element))
            {
                groupedByOccurences[element] = 0;
            }
            groupedByOccurences[element]++;
        }

        return groupedByOccurences;
    }
}

