/* Write a method that adds two positive integer numbers represented 
 * as arrays of digits (each array element arr[i] contains a digit; 
 * the last digit is kept in arr[0]). Each of the numbers that will 
 * be added could have up to 10 000 digits.
*/
using System;

class SumTwoDigitArrays
{
    static int[] SumElementsOfTwoArrays(int[] array1, int[] array2)
    {
        int minLength = Math.Min(array1.Length, array2.Length);
        int maxLength = Math.Max(array1.Length, array2.Length);
        Array.Reverse(array1);
        Array.Reverse(array2);

        // this array will save the sum of the digits
        int[] sum = new int[maxLength];
        
        // the sum of the ones is calculated as follows
        sum[0] = (array1[0] + array2[0]) % 10;

        // calculate the sum of the elements (digits) of two arrays and hold the sum in sum[i];
        for (int i = 1; i < maxLength; i++)
        {
            if (i < minLength)
            {
                sum[i] = (array1[i] + array2[i]) % 10 + (array1[i - 1] + array2[i - 1]) / 10;
            }
            else if (i == minLength)
            {
                if (array1.Length > array2.Length)
                {
                    sum[i] = array1[i] + (array1[i - 1] + array2[i - 1]) / 10;
                }
                else
                {
                    sum[i] = array2[i] + (array1[i - 1] + array2[i - 1]) / 10;
                }
            }
            else
            {
                if (array1.Length > array2.Length)
                {
                    sum[i] = array1[i] + (array1[i - 1] / 10);
                }
                else
                {
                    sum[i] = array2[i] + (array2[i - 1] / 10);
                }    
            }
        }
        //Array.Reverse(sum);
        return sum;
    }

    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.Write("First number: ");
        int[] firstNumDigits = new int[] { 1, 6, 8, 9, 5};
        PrintArray(firstNumDigits);
        Console.Write("Second number: ");        
        int[] secondNumDigits = new int[]    {9, 9, 9, 9, 9, 9, 9};
        PrintArray(secondNumDigits);

        int[] sum = SumElementsOfTwoArrays(firstNumDigits, secondNumDigits);
        Array.Reverse(sum);        
        Console.Write("Their sum: ");
        PrintArray(sum);
    }
}