/* Write a program that finds the sequence of maximal sum in given array. 
 * Example: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  ->  {2, -1, 6, 4}
 * Can you do it with only one loop (with single scan through the 
 * elements of the array)?
 * 
 * Maximum Contiguous Subsequence Sum Problem - (Google)
*/
using System;

class SequenceOfMaxSumInArray
{
    static void Main()
    {
        int seqStart = 0; // start index of actual best sequence
        int seqEnd = 0; // last index of actual best sequence
        int maxSum = int.MinValue;
        int currentSum = 0;
        // create and initialize an array
        int[] arr = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };  // {2, -1, 6, 4}
        //int[] arr = { -2, -3, -6, -1, -2, -1, -6, -4, -8, -8 }; // { -1 }
        
        // print the array
        //Console.Write("Array: { ");
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    if (i >= 0 && i < arr.Length - 1)
        //    {
        //        Console.Write(arr[i] + ", ");
        //    }
        //    if (i == arr.Length - 1)
        //    {
        //        Console.Write(arr[i]);
        //    }
        //}
        Console.Write(" }");
        Console.WriteLine();

        for (int i = 0, j = 0; j < arr.Length; j++)
        {
            currentSum = currentSum + arr[j];

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                seqStart = i;
                seqEnd = j;
            }
            else if (currentSum < 0)
            {
                i = j + 1;
                currentSum = 0;
            }
        }
        // prints the maximal sum
        //Console.WriteLine(maxSum);

        // prints the sequence of elements with maximal sum
        Console.Write("Sequence of elements with maximal sum: { ");
        for (int index = seqStart; index <= seqEnd; index++)
        {
            // put commas after printing each element
            if (index >= seqStart && index < seqEnd)
            {
                Console.Write(arr[index] + ", ");
            }
            // without a comma after printing the last element
            if (index == seqEnd)
            {
                Console.Write(arr[index]);
            }
        }
        Console.Write(" }");
        Console.WriteLine();
    }
}

