/* Write a program that finds the index of given element in a sorted array 
 * of integers by using the binary search algorithm.
*/
using System;

class BinarySearchAlgorithm
{
    static void Main()
    {
        int[] array = new int[] { 4, 18, 24, 100, 25, 0 };

        // binary search is applied over a sorted array
        Array.Sort(array);

        int minIndex = 0;
        int maxIndex = array.Length - 1;

        Console.WriteLine("Binary search algorithm");
        int findIndexOf = 100;
        int indexFound = 0;

        while (maxIndex >= minIndex)
        {
            int middleIndex = (minIndex + maxIndex) / 2;

            if (array[middleIndex] < findIndexOf)
            {
                minIndex = middleIndex + 1;
            }
            else if (array[middleIndex] > findIndexOf)
            {
                maxIndex = middleIndex - 1;
            }
            else if (array[middleIndex] == findIndexOf)
            {
                indexFound = middleIndex;
                Console.WriteLine("The index of {0} = {1}.", findIndexOf, indexFound);
                break;
            }
        }        
    }
}