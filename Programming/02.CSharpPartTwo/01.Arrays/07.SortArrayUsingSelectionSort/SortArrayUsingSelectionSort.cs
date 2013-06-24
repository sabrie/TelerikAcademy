/* Sorting an array means to arrange its elements in increasing order. 
 * Write a program to sort an array. Use the "selection sort" algorithm: 
 * Find the smallest element, move it at the first position, find the 
 * smallest from the rest, move it at the second position, etc.
 */

using System;

class SortArrayUsingSelectionSort
{
    static void Main()
    {
        int[] arr = {22, 12, 1, 3, 45, 8};
        int n = arr.Length;

        // prints the unsorted array
        Console.WriteLine("Unsorted array:");
        for (int count = 0; count < n; count++)
        {
            Console.Write(arr[count] + " ");
        }
        Console.WriteLine();
        Console.WriteLine();

        // Selection Sort Algorithm
        Console.WriteLine("Sorted array (using Selection Sort): ");
        int i, j; // loop counters
        int min; // index of the smallest element

        for (i = 0; i < n; i++)
        {
            min = i;

            for (j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[min])
                {
                    min = j;
                }
            }
            int exchangeValues = arr[i];
            arr[i] = arr[min];
            arr[min] = exchangeValues;

            // prints the sorted array
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }
}


