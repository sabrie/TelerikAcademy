/* Write a method that checks if the element at given position in given array 
 * of integers is bigger than its two neighbors (when such exist).
*/

using System;

class CompareNumWithTwoNeighboursInArray
{
    static bool IsIndexInsideArray(int[] arr, int i)
    {
        bool isInRange = true;
        if (i < 0 && i > arr.Length)
        {
            isInRange = false;
        }
        return isInRange;
    }

    static bool IsBiggerThanNeighbours(int[] array, int i)
    {
        bool isBigger = true;
		if (array[i] < array[i + 1] || array[i] < array[i - 1])
	    {
		    isBigger = false;
	    }
        return isBigger;
    }


    static void Main()
    {
        int[] array = new int[] {1, 3, 10, 4, 0, 3, 15, 4 };         

        int index = 0;
        Console.Write("Enter index in the range [1...{0}]: ", array.Length - 2);

        try
        {
            index = int.Parse(Console.ReadLine());
            bool isInRange = IsIndexInsideArray(array, index);

            if (isInRange && IsBiggerThanNeighbours(array, index))
            {
                Console.WriteLine("The element with index {0} is bigger than its two neighbors!", index); ;
            }
            else
            {
                Console.WriteLine("The element with index {0} is not bigger than its two neighbors!", index);
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Index {0} has only one neighbor ot it is outside the bounds of the array!", index);
            Console.WriteLine("Please enter index in the range [1...{0}]", array.Length - 2);
        }
        catch (FormatException)
        {
            Console.WriteLine("Input was not in a correct format! Please enter an integer number!");
        }
    }
}