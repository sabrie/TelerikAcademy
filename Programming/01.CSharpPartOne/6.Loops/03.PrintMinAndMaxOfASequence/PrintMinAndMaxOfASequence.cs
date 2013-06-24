/* Write a program that reads from the console a sequence of 
 * N integer numbers and returns the minimal and maximal of them.
*/
using System;

class PrintMinAndMaxOfASequence
{
    static void Main()
    {
        int numberSequence;
        int minNum;
        int maxNum;
        Console.Write("How many numbers your sequence will be: ");
        int n = int.Parse(Console.ReadLine());

        if (n == 0)
        {
            Console.WriteLine("Please enter a number greater than 0: ");
        }
        else if (n == 1)
        {
            Console.Write("Enter {0} number followed by Enter: ", n);
            minNum = maxNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Min Number = {0} \nMax Number = {1}", minNum, maxNum);
        }
        else
        {
            Console.WriteLine("Enter {0} numbers each on a new line: ", n);
            maxNum = minNum = int.Parse(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                numberSequence = int.Parse(Console.ReadLine());
                if (minNum < numberSequence)
                {
                    minNum = minNum;
                }
                else
                {
                    minNum = numberSequence;
                }
                if (maxNum > numberSequence)
                {
                    maxNum = maxNum;
                }
                else
                {
                    maxNum = numberSequence;
                }
            }
            Console.WriteLine("Min Number = {0} \nMax Number = {1}", minNum, maxNum);
        }
    }
}
