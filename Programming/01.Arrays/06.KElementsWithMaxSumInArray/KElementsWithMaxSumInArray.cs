/* Write a program that reads two integer numbers N and K and an array 
 * of N elements from the console. Find in the array those K elements 
 * that have maximal sum.
 */
using System;

class KElementsWithMaxSumInArray
{
    static void Main()
    {
        // reads the lenght of the array
        Console.Write("Length of the array N = ");
        int n = int.Parse(Console.ReadLine());

        // reads the number of elements with maximal sum that we are searching for
        Console.Write("Number of elements with max sum K = ");
        int k = int.Parse(Console.ReadLine());

        // creats an array with size N
        int[] arr = new int[n];

        Console.WriteLine("Enter {0} numbers (elements of the array) each on a new line: ", n);
        // reads the elements of the array in a for loop
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        // the K elements of the array that have maximal sum are 
        // the last K elements of the sorted array
        // so we sort the array
        Array.Sort(arr);

        Console.Write("The {0} elements with maximal sum are: ", k);
        // print the last K elements of the sorted array
        for (int i = n - k; i < n; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }
}

