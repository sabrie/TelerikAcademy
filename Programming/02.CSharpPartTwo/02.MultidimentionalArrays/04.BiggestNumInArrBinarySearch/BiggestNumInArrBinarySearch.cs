/* Write a program, that reads from the console an array of N integers and an integer K, 
 * sorts the array and using the method Array.BinSearch() finds the largest number 
 * in the array which is ≤ K.
 */
using System;

class BiggestNumInArrBinarySearch
{
    static void Main()
    {
        Console.Write("Length of array N = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Search for Number <= K, \nK = ");
        int k = int.Parse(Console.ReadLine());

        int[] array = new int[n];
        Console.WriteLine("Enter {0} numbers each on a new line: ", n);
        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(array);
        int indexOfSearchedNum = Array.BinarySearch(array, k);
        if (indexOfSearchedNum < -1)
        {
            Console.WriteLine("The biggest number <= {0} is: {1}", k, array[~indexOfSearchedNum - 1]);
        }
        else if (~indexOfSearchedNum == 0)
        {
            Console.WriteLine("The biggest number in the array is > K");
        }
        else
        {
            Console.WriteLine("The biggest number <= {0} is: {1}", k, array[indexOfSearchedNum]);
        }
    }
}

