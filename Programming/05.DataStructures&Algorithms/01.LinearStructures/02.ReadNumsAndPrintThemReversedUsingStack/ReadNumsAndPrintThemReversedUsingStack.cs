/* Write a program that reads N integers from the console 
 * and reverses them using a stack. Use the Stack<int> class.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadNumsAndPrintThemReversedUsingStack
{
    class ReadNumsAndPrintThemReversedUsingStack
    {
        static void Main()
        {
            Stack<int> numbers = new Stack<int>();

            Console.WriteLine("Provide numbers followed Enter: ");
            string input = Console.ReadLine();

            while (input != String.Empty)
            {
                int parsedInput = int.Parse(input);
                numbers.Push(parsedInput);
                input = Console.ReadLine();
            }

            Console.WriteLine("Reversed:");

            while (numbers.Count > 0)
            {
                int number = numbers.Pop();
                Console.WriteLine(number);
            }

            // Console.WriteLine(string.Join("\n", numbers));
        }
    }
}
