/* Write a program that reads from the console a sequence of positive integer numbers. 
 * The sequence ends when empty line is entered. Calculate and print the sum and 
 * average of the elements of the sequence. Keep the sequence in List<int>.
*/

using System;
using System.Linq;
using System.Collections.Generic;

namespace SumAndAverageOfListOfNumbers
{
    public class SumAndAverageOfListOfNumbers
    {
        static void Main()
        {
            // Using List<int>
            IList<int> numbers = new List<int>();

            Console.WriteLine("Provide numbers followed Enter: ");
            string input = Console.ReadLine();

            while (input != String.Empty)
            {
                int parsedInput = int.Parse(input);
                numbers.Add(parsedInput);
                input = Console.ReadLine();
            }

            int sum = numbers.Sum();
            double average = (double) sum / numbers.Count;

            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Average: " + average);


            //// Using DynamicList
            // DynamicList numbers = new DynamicList();

            // string input = Console.ReadLine();

            // while (input != String.Empty)
            //{
            //    int parsedInput = int.Parse(input);
            //    numbers.Add(parsedInput);
            //    input = Console.ReadLine();
            //}

            // int sum = numbers.Sum();
            // double average = numbers.Average();

            // Console.WriteLine("Sum: " + sum);            
            // Console.WriteLine("Average: {0:F2}", average);
        }
    }
}
