/* Write a method that returns the index of the first element in array 
 * that is bigger than its neighbors, or -1, if there’s no such element.
 * Use the method from the previous exercise. 
 */

using System;

class PrintIndexOfNumBiggerThanNeighbors
{
    static int GetIndexOfNumBiggerThanNeighbours(int[] array)
    {
        for (int index = 1; index < array.Length - 1; index++)
        {
            if (array[index] > array[index + 1] && array[index] > array[index - 1])
            {
                return index;
            }            
        }
        return -1;
    }

    static void Main()
    {
        int[] array = new int[] { 1, 3, 10, 4, 0, 3, 15, 4 }; // 2
        //int[] array = new int[] { 5, 3, 2, 1, 0, 4, 8, 9 }; // There is not an element bigger than its two neighbors

        if (GetIndexOfNumBiggerThanNeighbours(array) > 0)
        {
            Console.WriteLine("The index of the first number in array ");
            Console.WriteLine("which is bigger than its neighbors is: {0}", GetIndexOfNumBiggerThanNeighbours(array));            
        }
        else
        {
            Console.WriteLine(GetIndexOfNumBiggerThanNeighbours(array));
            Console.WriteLine("There is not an element in the array which is bigger than its two neighbors!");
        }
    }
}

