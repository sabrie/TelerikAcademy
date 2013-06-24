/* Write a program that prints from given array of integers all numbers 
 * that are divisible by 7 and 3. Use the built-in extension methods and 
 * lambda expressions. Rewrite the same with LINQ.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class NumsDivisibleBy7and3
{
    static void Print(IEnumerable list)
    {
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        int[] numbers = new int[] { 2, 7, 21, 3, 42, 49 };
        Console.Write("Array: ");
        
        // print the array of numbers using the method Print
        Print(numbers);

        Console.WriteLine("");
        Console.WriteLine("Numbers in array which are not divisible by 3 and 7 (using Lambda expressions):");
        var numsDivBy7And3 = numbers.Where(number => (number % 7 == 0) && (number % 3 == 0));
        
        // print the result using the method Print
        Print(numsDivBy7And3);

        Console.WriteLine("Numbers in array which are not divisible by 3 and 7 (using LINQ): ");
        numsDivBy7And3 =
            from nums in numbers
            where (nums % 3 == 0) && (nums % 7 == 0)
            select nums;
        
        // print the result using the method Print
        Print(numsDivBy7And3);
    }
}
