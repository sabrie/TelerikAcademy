/* Write a program that sorts an array of strings using the 
 * quick sort algorithm.
*/
using System;

class QuickSortAlgorithm
{
    static void QuickSwap(string[] array, int left, int right)
    {
        string swap = array[right];
        array[right] = array[left];
        array[left] = swap;
    }

    static void QuickSort(string[] array, int left, int right)
    {
        int leftHold = left;
        int rightHold = right;
        Random objRan = new Random();
        int pivot = objRan.Next(left, right);
        QuickSwap(array, pivot, left);
        pivot = left;
        left++;

        while (right >= left)
        {
            int compareLeftVal = array[left].CompareTo(array[pivot]);
            int compareRightVal = array[right].CompareTo(array[pivot]);

            if ((compareLeftVal >= 0) && (compareRightVal < 0))
            {
                QuickSwap(array, left, right);
            }
            else
            {
                if (compareLeftVal >= 0)
                {
                    right--;
                }
                else
                {
                    if (compareRightVal < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                        left++;
                    }
                }
            }
        }
        QuickSwap(array, pivot, right);
        pivot = right;
        if (pivot > leftHold)
        {
            QuickSort(array, leftHold, pivot);
        }
        if (rightHold > pivot + 1)
        {
            QuickSort(array, pivot + 1, rightHold);
        }
    }

    static void PrintArray(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (i < array.Length - 1)
            {
                Console.Write(array[i] + ", ");
            }
            else
            {
                Console.Write(array[i]);
            }
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.WriteLine("Sorting string array using QuickSort Algorithm.");
        string[] numbers = { "a", "c", "w", "b" };
        int n = numbers.Length;

        Console.Write("Unsorted array: ");
        PrintArray(numbers);

        QuickSort(numbers, 0, (numbers.Length - 1));

        Console.Write("Sorted array: ");
        PrintArray(numbers);
    }   
}

