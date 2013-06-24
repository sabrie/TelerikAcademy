/* Write a program that reads two arrays from the console 
 * and compares them element by element.
 */
using System;

class CompareTwoArrays
{
    static void Main()
    {
        Console.WriteLine("This program compares two arrays");
        Console.Write("Lenght of first array: ");
        int lengthFirstArr = int.Parse(Console.ReadLine());
        Console.Write("Lenght of second array: ");
        int lengthSecondArr = int.Parse(Console.ReadLine());

        // creat arrays with a given length
        int[] firstArr = new int[lengthFirstArr];
        int[] secondArr = new int[lengthSecondArr];

        // read the elements of first array
        Console.WriteLine("Enter each element of the first array followed by Enter: ");
        for (int i = 0; i < lengthFirstArr; i++)
        {
            firstArr[i] = int.Parse(Console.ReadLine());
        }
        // read the elements of second array
        Console.WriteLine("Enter each element of the second array followed by Enter: ");
        for (int i = 0; i < lengthSecondArr; i++)
        {
            secondArr[i] = int.Parse(Console.ReadLine());
        }

        bool isEqual = true;

        // if the lengths of both arrays are equal then 
        // we compare them element by element 
        // (compare the elements of both arrays with the same indexes)
        if (lengthFirstArr == lengthSecondArr)
        {
            for (int i = 0; i < lengthFirstArr; i++)
            {
                // when we reach elements that are not equal
                // it means that the two arrays are not equal so we break the loop
                // and print the result
                if (firstArr[i] != secondArr[i])
                {
                    isEqual = false;
                    break;
                }
            }
        }
        // if the lengths of both arrays are not equal then
        // the two arrays are not equal
        else
        {
            isEqual = false;
        }

        Console.WriteLine("The two arrays are equal: {0}", isEqual);
    }
}
