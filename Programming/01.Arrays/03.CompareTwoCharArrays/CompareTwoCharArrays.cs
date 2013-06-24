/* Write a program that compares two char arrays 
 * lexicographically (letter by letter).
*/
using System;

class CompareTwoCharArrays
{
    static void Main()
    {
        char[] firstArr = {'p', 'w', 's', 'a'};
        char[] secondArr = {'p', 'e', 's'};
        bool isEqual = true;

        // if the lengths of both arrays are equal then 
        // we compare them element by element 
        // (compare the elements of both arrays with the same indexes)
        if (firstArr.Length == secondArr.Length)
        {
            for (int i = 0; i < firstArr.Length; i++)
            {
                // when we reach elements that are not equal
                // we find the smaller or the bigger of the two elements 
                if (firstArr[i] != secondArr[i] && firstArr[i] < secondArr[i])
                {
                    // if firstArr element is smaller than the secondArr element
                    // we print that the first array is before the second array
                    isEqual = false;
                    Console.WriteLine("First array is before second array");
                    break;
                }
                else if (firstArr[i] != secondArr[i] && firstArr[i] > secondArr[i])
                {
                    // if firstArr element is bigger than the seccondArr element
                    // we print that the second array is before the first array
                    isEqual = false;
                    Console.WriteLine("Second array is before first array");
                    break;
                }
            }
            if (isEqual)
            {
                Console.WriteLine("The two arrays are equal");
            }
        }
        // if the lengths of both arrays are not equal then
        // the two arrays are not equal
        if (firstArr.Length != secondArr.Length)
        {
            if (firstArr.Length < secondArr.Length)
            {
                for (int i = 0; i < firstArr.Length; i++)
                {
                    if (firstArr[i] != secondArr[i] && firstArr[i] < secondArr[i])
                    {

                        isEqual = false;
                        Console.WriteLine("First array is before second array");
                        break;
                    }
                    else if (firstArr[i] != secondArr[i] && firstArr[i] > secondArr[i])
                    {
                        isEqual = false;
                        Console.WriteLine("Second array is before first array");
                        break;
                    }
                }
                if (isEqual)
                {
                    Console.WriteLine("The first array is before the second array");
                }
            }

            if (secondArr.Length < firstArr.Length)
            {
                for (int i = 0; i < secondArr.Length; i++)
                {
                    if (firstArr[i] != secondArr[i] && secondArr[i] < firstArr[i])
                    {
                        isEqual = false;
                        Console.WriteLine("Second array is before first array");
                        break;
                    }
                    else if (firstArr[i] != secondArr[i] && secondArr[i] > firstArr[i])
                    {
                        isEqual = false;
                        Console.WriteLine("First array is before second array");
                        break;
                    }
                }
                if (isEqual)
                {
                    Console.WriteLine("The second array is before the first array");
                }
            }
        }
    }
}