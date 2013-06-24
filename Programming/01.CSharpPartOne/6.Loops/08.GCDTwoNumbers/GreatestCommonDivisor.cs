/* Write a program that calculates the greatest common divisor (GCD) 
 * of given two numbers. Use the Euclidean algorithm.
 */
using System;

class GreatestCommonDivisor
{
    static void Main()
    {
        Console.WriteLine("This program finds the GCD of two numbers - 'a' and 'b'");
        Console.Write("Enter a value for a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter a value for b: ");
        int b = int.Parse(Console.ReadLine());
        int exchange = 0;
        int remainder = 0;
        int gcd = 0;

        /* Euclidean algorithm:
         * If a<b, exchange a and b.
         * Divide a by b and get the remainder. 
         * If remainder = 0, report b as the GCD of a and b.
         * If remainder != 0 replace a by b and replace b by r. 
         * Return to the previous step.
         */

        if (a >= 0 && b >= 0)
        {
            if (a < b)
            {
                // exchanges the values of a and b if a<b
                exchange = a;
                a = b;
                b = exchange;
            }
            while (a != 0 && b != 0)
            {
                remainder = a % b;
                if (remainder == 0)
                {
                    gcd = b;
                    break;
                }
                // replaces a by b
                exchange = a;
                a = b;
                b = exchange;
                // replaces b by remainder
                b = remainder;
                gcd = b; //  GCD
            }
            Console.WriteLine(gcd);
        }
        else
        {
            Console.WriteLine("Enter a positive numbers!");
        }
    }
}