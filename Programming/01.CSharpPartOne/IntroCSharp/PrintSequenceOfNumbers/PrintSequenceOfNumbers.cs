/*Write a program that prints the first 10 numbers of the sequence: 
2, -3, 4, -5, 6, -7 ...
*/
using System;

class PrintSequenceOfNumbers
{
    static void Main()
    {
        int num;

        for (num = 2; num <= 11; num++)
        {
            if (num % 2 == 0)
            {
                Console.WriteLine(num);
            }
            else
            {
                Console.WriteLine(-num);
            }
        }
    }
}

