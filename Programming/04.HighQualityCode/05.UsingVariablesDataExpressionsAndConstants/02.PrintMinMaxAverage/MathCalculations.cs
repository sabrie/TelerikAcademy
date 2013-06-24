/*
 Refactor the following code to apply variable usage and 
 naming best practices:

public void PrintStatistics(double[] arr, int count)
{
    double max, tmp;
    for (int i = 0; i < count; i++)
    {
        if (arr[i] > max)
        {
            max = arr[i];
        }
    }
    PrintMax(max);
    
    tmp = 0;
    max = 0;
    for (int i = 0; i < count; i++)
    {
        if (arr[i] < max)
        {
            max = arr[i];
        }
    }
    PrintMin(max);

    tmp = 0;
    for (int i = 0; i < count; i++)
    {
        tmp += arr[i];
    }
    PrintAvg(tmp/count);
}

 */
using System;
using System.Linq;


class MathCalculations
{
    static void Main()
    {
        double[] array = { 1.5, 2.5, 3.5 };

        double max = Max(array);
        Console.WriteLine("Maximal element: " + max);

        double min = Min(array);
        Console.WriteLine("Minimal element: " + min);

        double sum = Sum(array);
        Console.WriteLine("Sum: " + sum);

        double average = Average(array);
        Console.WriteLine("Average: " + average);
    }

    private static double Max(double[] arr)
    {
        double max = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        return max;
    }

    private static double Min(double[] arr)
    {
        double min = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }

        return min;
    }

    private static double Sum(double[] arr)
    {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {            
            sum += arr[i];
        }

        return sum;
    }

    private static double Average(double[] arr)
    {
        double sum = Sum(arr);
        double average = sum / arr.Length;

        return average;
    }
}