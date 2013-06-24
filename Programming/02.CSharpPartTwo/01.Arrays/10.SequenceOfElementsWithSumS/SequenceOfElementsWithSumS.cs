/* Write a program that finds in given array of integers a 
 * sequence of given sum S (if present). 
 * Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}
 */

using System;

class SequenceOfElementsWithSumS
{
    static void Main()
    {
        int[] arr = { 4, 3, 1, 4, 2, 5, 8 }; //  It works -> {4, 2, 5} = 11
        //int[] arr = { 4, 3, 1, 4, 6, 5, 8 }; // It works -> {1, 4, 6} = 11
        //int[] arr = { 4, 3, 0, 4, 6, 5, 8 }; // It works -> { 4, 3, 0, 4} = 11
        //int[] arr = { 11, 3, 1, 4, 2, 5, 8 }; // It works -> {11} = 11                
        //int[] arr = { 4, 0, 1, 4, -1, 0, 5, 8 }; // There is not a sequence of elements with given sum

        int sum = 11;
        int currentSum = 0;
        int firstIndexOfSeq = 0; // // the first index of the sequence with the given sum
        int lastIndexOfSeq = 0; // the last index of the sequence with the given sum

        // print the array
        Console.Write("Array: { ");
        for (int index = 0; index < arr.Length; index++)
        {
            // put commas after printing each element
            if (index >= 0 && index < arr.Length - 1)
            {
                Console.Write(arr[index] + ", ");
            }
            // without a comma after printing the last element
            else
            {
                Console.Write(arr[index]);
            }
        }
        Console.Write(" }");
        Console.WriteLine();

        for (int i = -1, index = 0; index < arr.Length; index++)
        {
            currentSum = currentSum + arr[index];

            if (currentSum == sum)
            {
                firstIndexOfSeq = i + 1;
                lastIndexOfSeq = index;
                break;
            }
            else if (currentSum > sum)
            {
                index = i + 1;
                i = i + 1;
                currentSum = 0;
            }
        }

        // if there is a sequence of elements with the given sum we print the sequence
        if (currentSum == sum)
        {
            // prints the sequence of elements with the given sum
            Console.Write("Sequence of elements with Sum = {0}:", sum);
            Console.Write(" { ");
            for (int index = firstIndexOfSeq; index <= lastIndexOfSeq; index++)
            {
                // put commas after printing each element
                if (index >= firstIndexOfSeq && index < lastIndexOfSeq)
                {
                    Console.Write(arr[index] + ", ");
                }
                // without a comma after printing the last element
                if (index == lastIndexOfSeq)
                {
                    Console.Write(arr[index]);
                }
            }
            Console.Write(" }");
            Console.WriteLine();
        }
        // if there is not a sequence of elements with the given sum we print the below message 
        else
        {
            Console.WriteLine("There is not a sequence of elements with Sum = {0}", sum);
        }
    }
}

