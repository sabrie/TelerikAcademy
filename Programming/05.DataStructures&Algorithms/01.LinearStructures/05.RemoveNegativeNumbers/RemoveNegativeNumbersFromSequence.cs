// Write a program that removes from given sequence all negative numbers.

using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveNegativeNumbers
{
    class RemoveNegativeNumbersFromSequence
    {
        static void Main()
        {
            IList<int> numbers = new List<int>()
            {
                    19, -10, 12, -6, -3, 34, -2, 5
            };

            IList<int> positiveNumbers = RemoveNegativeNumbers(numbers);

            Console.WriteLine(string.Join(", ", positiveNumbers));
        }

        private static IList<int> RemoveNegativeNumbers(IList<int> numbers)
        {
            IList<int> positiveNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
			{
                if (numbers[i] > 0)
                {
                    positiveNumbers.Add(numbers[i]);
                }
			}
            
            return positiveNumbers;
        }
    }
}
