/* Write a program to calculate the xpression
 * (((n * n) + (1 / (m * p)) + 1337) / (n - 128.523123123 * p)) + sin(m % 180);
 */
using System;

class MathExpression
{
    static void Main()
    {
        decimal n = decimal.Parse(Console.ReadLine());
        decimal m = decimal.Parse(Console.ReadLine());
        decimal p = decimal.Parse(Console.ReadLine());

        // calculates the divident
        decimal divident = (n * n) + (1 / (m * p)) + 1337;
        // calculates the divider
        decimal divider = n - (128.523123123m * p);
        // calculates sin(m % 180)
        decimal sin = (decimal) Math.Sin((int)m % 180); // 
        // calculates the expression
        decimal result = (divident / divider) + sin;

        // prints the result
        Console.WriteLine("{0:F6}", result);
    }
}
