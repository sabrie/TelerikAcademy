/* Write a program that allocates array of 20 integers and 
 * initializes each element by its index multiplied by 5. 
 * Print the obtained array on the console
 */
using System;

class InitializeArrayElementsByIndexMultiplBy5
{
    static void Main()
    {
        // creats (allocates) an array with 20 elements
        int[] arr = new int[20];

        // initializes each element by index multiplied by 5
        for (int i = 0; i < 20; i++)
        {
            arr[i] = i * 5;
        }

        // prints the array
        for (int i = 0; i < 20; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }
}

