/* Write a method that finds the longest subsequence of equal numbers in given 
 * List<int> and returns the result as new List<int>. Write a program to 
 * test whether the method works correctly.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxSequenceOfEqualNumbers
{
    class MaxSequenceOfEqualNumbers
    {
        static void Main()
        {
            IList<int> numbers = new List<int>() 
            { 
                6, 3, 3, 3, 4, 5, 5, 1, 1, 1, 1
            };

            IList<int> maxSequenceOfEqualNumbers = FindMaxSequenceOfEqualNumbers(numbers);

            Console.WriteLine("Maximal sequence of equal numbers is: " + 
                string.Join(" ", maxSequenceOfEqualNumbers)); // 1 1 1 1
        }

        private static IList<int> FindMaxSequenceOfEqualNumbers(IList<int> numbers)
        {
            int currentSequence = 1;
            int maxSequence = 1;
            int bestElement = numbers[0];

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    currentSequence++;
                }
                else
                {
                    currentSequence = 1;
                }

                if (currentSequence > maxSequence)
                {
                    maxSequence = currentSequence;
                    bestElement = numbers[i];
                }
            }

            IList<int> maxSequenceOfEqualNumbers = Repeat(bestElement, maxSequence);

            return maxSequenceOfEqualNumbers;
        }

        private static IList<int> Repeat(int number, int times)
        {
            IList<int> equalNumbers = new List<int>();

            for (int i = 0; i < times; i++)
            {
                equalNumbers.Add(number);
            }

            return equalNumbers;
        }
    }
}
