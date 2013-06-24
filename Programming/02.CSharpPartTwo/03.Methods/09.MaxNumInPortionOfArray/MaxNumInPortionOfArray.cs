/* Write a method that return the maximal element in a portion of array 
 * of integers starting at given index. Using it write another method 
 * that sorts an array in ascending / descending order.
*/
using System;

class MaxNumInPortionOfArray
{
    static void PrintArray(int[] myArr)
    {
        Console.Write("{ ");
        for (int i = 0; i < myArr.Length; i++)
        {
            if (i >= 0 && i < myArr.Length - 1)
            {
                Console.Write(myArr[i] + ", ");
            }
            else
            {
                Console.Write(myArr[i]);
            }
        }
        Console.Write(" }");
        Console.WriteLine();
    }

    static void SortArray(int[] partOfArray)
    {
        for (int index = 0; index < partOfArray.Length - 1; index++)
        {
            for (int i = index, k = index + 1; k < partOfArray.Length; k++)
            {
                if (partOfArray[index] > partOfArray[k])
                {
                    int exchange = partOfArray[k];
                    partOfArray[k] = partOfArray[index];
                    partOfArray[index] = exchange;
                }
            }
        }
    }


    static void Main()
    {
        int[] originalArray = {5, 4, 8, 10, 3};

        int startIndex = 4;
        int endIndex = 2;

        // if start index is bigger than end index we swap their values
        if (startIndex > endIndex)
        {
            int exchange = startIndex;
            startIndex = endIndex;
            endIndex = exchange;
        }

        // create array which will hold the values of the portion of originalArray
        int[] partOfArray = new int[endIndex - startIndex + 1];

        // check if indexes are in range
        if (startIndex >= 0 && startIndex < originalArray.Length &&
            endIndex >= 0 && endIndex < originalArray.Length)
        {
            // copy the values of a portion of original array (between startIndex and endIndex) to the new array - partOfArray)
            for (int i = startIndex, index = 0; i <= endIndex; i++, index++)
            {
                partOfArray[index] = originalArray[i];
            }

            Console.Write("The maximal element between indexes {0} - {1} in the array ", startIndex, endIndex);
            PrintArray(originalArray);

            SortArray(partOfArray);
            // print the last element of the sorted partOfArray - wxhich is maximal
            Console.WriteLine("is: {0}", partOfArray[partOfArray.Length - 1]);
        }
        // if indexes are not in range print error message
        else
        {
            Console.WriteLine("Invalid index! Start index and end index should be in the range [0 ... {0}]", originalArray.Length - 1);
        }
    }    
}

