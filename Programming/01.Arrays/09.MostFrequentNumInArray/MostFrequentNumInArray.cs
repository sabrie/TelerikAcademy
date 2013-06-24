/* Write a program that finds the most frequent number in an array. 
 * Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4(5 times)
 */
using System;

class MostFrequentNumInArray
{
    static void Main()
    {
        // create and initialize an array
        int[] arr = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 }; // 4 (5 times)
        //int[] arr = { 4, 3, 1, 3, 1, 4, 2, 3, 3, 3, 3, 3, 3, 4, 4, 1, 3, 2, 4, 9, 3 }; // 3 (10 times)

        // print the array
        Console.Write("Array: ");
        for (int i = 0; i < arr.Length; i++)
        {
            // put commas after printing each element
            if (i >= 0 && i < arr.Length - 1)
            {
                Console.Write(arr[i] + ", ");
            }
            // without comma after printing the last element
            if (i == arr.Length - 1)
            {
                Console.Write(arr[i]);
            }
        }
        Console.WriteLine();

        // sort the array
        Array.Sort(arr);

        //// print the sorted array
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    Console.Write(arr[i] + " ");
        //}
        //Console.WriteLine();

        int counter = 0; // counts the equal elements
        int maxSequence = 1; // saves the value of max sequence of equal elements
        int maxElement = 0; // saves the value of the most frequent element 

        // find the maximal sequence of equal elements in an array
        for (int index = 0; index < arr.Length - 1; index++)
        {
            if (arr[index] == arr[index + 1])
            {
                counter++;
            }
            else
            {
                counter = 1;
            }
            if (counter > maxSequence)
            {
                maxSequence = counter;
                maxElement = arr[index];
            }
        }
        // prints the result
        Console.Write("The most frequent element: ");
        Console.WriteLine("{0} ({1} times)", maxElement, maxSequence);
    }
}
