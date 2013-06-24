/* Write a program to calculate the sum (with accuracy of 0.001):
 * 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...
 */
using System;

class SumWithAccuracy
{
    static void Main()
    {
        decimal i = 2M;
        decimal sumOld = 1M;
        decimal sumNew;
                       
        while(true)
        {
            if (i % 2 == 0)
            {
                sumNew = sumOld + 1/i;
            }
            else
            {
                sumNew = sumOld - 1/i;
            }
            
            if (Math.Abs(sumNew - sumOld) < 0.001M)
            {
                break;
            }
           
            i++;
            sumOld = sumNew;
        }
        Console.WriteLine(sumNew);
    }
}

