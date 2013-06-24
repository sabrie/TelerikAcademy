/* Write a boolean expression that checks for given integer if it can be 
 * divided (without remainder) by 7 and 5 in the same time.
 */
using System;

class CheckIfNumIsDevidedBy5And7
{
    static void Main()
    {
        int number = 35;
        
        if (number % 5 == 0 && number % 7 == 0)
        {
            Console.WriteLine("Number {0} can be devided by 7 and 5 at the same time.", number);
        }
        else
        {
            Console.WriteLine("Number {0} can NOT be devided by 7 and 5 at the same time.", number);
        }
    }
}

