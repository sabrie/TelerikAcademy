/* Write a program that generates and prints to the console 
 * 10 random values in the range [100, 200].
*/
using System;

class Print10RandomNumsInGivenRange
{
    static void Main()
    {
        int numberOfValues = 10;
        int minRange = 100;
        int maxRange = 200;

        Random random = new Random();
        Console.WriteLine("{0} random values in the range [{1},{2}]: ", numberOfValues, minRange, maxRange);
        for (int i = 1; i <= numberOfValues; i++)
        {
            int randomNumber = random.Next(minRange, maxRange) + 1;
            Console.Write("{0} ", randomNumber);
        }
        Console.WriteLine();
    }
}
