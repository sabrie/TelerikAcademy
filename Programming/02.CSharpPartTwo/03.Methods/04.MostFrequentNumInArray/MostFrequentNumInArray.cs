/* Write a method that counts how many times given number appears in given array. 
 * Write a test program to check if the method is working correctly.
*/
using System;

class MostFrequentNumInArray
{
    // how many times a particuliar number appears in a given array
    static int GetNumberOfOccurrences(int number, int[] sequence)
    {
        int sequenceLength = sequence.GetLength(0);
        int numberOfOccurances = 0;
        for (int i = 0; i < sequenceLength; ++i)
        {
            if (sequence[i] == number)
            {
                numberOfOccurances++;
            }
        }

        return numberOfOccurances;
    }


    static int FindMostFrequentNum(int[] arr)
    {
        int counter = 0; // counts the equal elements
        int maxSequence = 1; // holds the value of max sequence of equal elements
        int mostFrequentNum = 0; // holds the value of the most frequent element 

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
                mostFrequentNum = arr[index];
            }
        }
        return mostFrequentNum;
    }

    static void Main()
    {
        // create and initialize an array
        int[] arr = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 }; // 4
        //int[] arr = { 4, 3, 1, 3, 1, 4, 2, 3, 3, 3, 3, 3, 3, 4, 4, 1, 3, 2, 4, 9, 3 }; // 3

        // sort the array to count easier the most frequent number
        Array.Sort(arr);

        int mostFrequentNum = FindMostFrequentNum(arr);
        Console.Write("The most frequent number in the array is: ");
        Console.WriteLine("{0} ", mostFrequentNum);
    }
}

