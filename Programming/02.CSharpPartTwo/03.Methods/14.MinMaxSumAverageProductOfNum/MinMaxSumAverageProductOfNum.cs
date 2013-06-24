/* Write methods to calculate minimum, maximum, average, sum and product of 
 * given set of integer numbers. Use variable number of arguments.
*/

using System;

class MinMaxSumAverageProductOfNum
{
    static void SortArray(params int[] array)
    {
        for (int index = 0; index < array.Length - 1; index++)
        {
            for (int i = index, k = index + 1; k < array.Length; k++)
            {
                if (array[index] > array[k])
                {
                    int exchange = array[k];
                    array[k] = array[index];
                    array[index] = exchange;
                }
            }
        }
    }

    static int CalcMax(params int[] array)
    {
        SortArray(array);
        // return last element of a sorted array
        return array[array.Length - 1];
    }

    static int CalcMin(params int[] array)
    {
        SortArray(array);
        // return first element of a sorted array
        return array[0];
    }

    static decimal CalcAverage(params int[] array)
    {
        decimal sum = 0;
        decimal counter = 0;
        
        foreach (int element in array)
        {
            counter++;
            sum = sum + element;
        }
        decimal average = sum / counter;
        return average;
    }

    static int CalcSum(params int[] array)
    {
        int sum = 0;
        foreach (int element in array)
        {
            sum = sum + element;
        }
        return sum;
    }

    static int CalcProduct(params int[] array)
    {
        int product = 1;
        foreach (int element in array)
        {
            product = product * element;
        }
        return product;
    }

    static void Main()
    {
        Console.WriteLine(CalcMin(1, 2, 5, 0, 10)); // 0
        Console.WriteLine(CalcMax(1, 2, 10)); // 10
        Console.WriteLine(CalcAverage(1, 2, 5, 10)); // 3.6
        Console.WriteLine(CalcSum(1, 2, 3, 4, 10, 20)); // 40
        Console.WriteLine(CalcProduct(2, 5, 2)); // 20
    }
}
