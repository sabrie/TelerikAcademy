/* Write a program that finds the maximal increasing sequence in an array. 
 * Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.
*/
using System;

class MaxIncreasingSequenceInArray
{
    static void Main()
    {
        Console.WriteLine("This program prints the maximal increasing sequence of elements in an array.");
        // creat and initialize an array
        int[] arr = { 3, 2, 3, 4, 2, 2, 4 }; // {2, 3, 4}
        //int[] arr = { 1, 3, 2 }; // {1, 3}
        
        int currentSequence = 1; // counts the sequence of equal elements
        int maxSequence = 0; // has the value of maximal sequence of equal elements
        int bestElement = 0; // has the value of the elements which has maximal sequence

        // the for loop compares the neighbour elements of the array
        for (int i = 0; i < arr.Length - 1; i++)
        {
            // if neighbour elements are equal we increase the value of currentSequence counter
            if (arr[i] < arr[i + 1])
            {
                currentSequence++;
            }
            // if neighbour elements are not equal we assign the value 1 to currentSequence
            // because this is the minimal value for a max sequence in an array
            else
            {
                currentSequence = 1;
            }
            if (currentSequence > maxSequence)
            {
                maxSequence = currentSequence;
                bestElement = i + 1;
            }
        }

        // prints the elements of the array on the console
        Console.Write("Array: { ");
        for (int i = 0; i < arr.Length; i++)
        {
            if (i >= 0 && i <= arr.Length - 2)
            {
                Console.Write(arr[i] + ", ");
            }
            // without comma after the last element 
            if (i == arr.Length - 1)
            {
                Console.Write(arr[i]);
            }
        }
        Console.Write(" }");
        Console.WriteLine();

        // prints the maximal sequence of equal elements
        Console.Write("Max sequence -> { ");

        // if the length of the array is 1 
        // we print the only element of the array
        if (arr.Length == 1)
        {
            Console.WriteLine(arr[0] + " }");
        }
        // if the length of the array is > 1
        // we print the value of bestElement maxSequence times
        else
        {
            for (int i = bestElement - maxSequence + 1; i <= bestElement; i++)
            {
                if (i >= 0 && i <= bestElement - 1)
                {
                    Console.Write(arr[i] + ", ");
                }
                if (i == bestElement)
                {
                    // without coma after the last element
                    Console.Write(arr[i]);
                }
            }
            Console.Write(" }");
            Console.WriteLine();
        }
    }
}

