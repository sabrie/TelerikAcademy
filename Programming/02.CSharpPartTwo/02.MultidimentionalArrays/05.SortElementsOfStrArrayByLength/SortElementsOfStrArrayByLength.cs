/* You are given an array of strings. Write a method that sorts 
 * the array by the length of its elements 
 * (the number of characters composing them
 */
using System;

class SortElementsOfStrArrayByLength
{
    // method that sorts the string array
    static string[] SortElementsOfArrayByLength(string[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int k = i + 1; k < array.Length; k++)
            {
                if (array[i].Length > array[k].Length)
                {
                    string swap = array[i];
                    array[i] = array[k];
                    array[k] = swap;
                }
            }
        }
        return array;        
    }

    // the method that prints an array
    static void PrintArray(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.WriteLine("Sort string array by length of its elements");
        Console.WriteLine();
        
        string[] array = new string[] 
        { "bcd", "admcd", "cb", "a", "adbm" };
        
        Console.Write("Unsorted array: ");
        PrintArray(array);

        Console.Write("Sorted array: ");
        SortElementsOfArrayByLength(array);
        PrintArray(array);
        Console.WriteLine();
    }
}

