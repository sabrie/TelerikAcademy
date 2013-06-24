/* Write a program that safely compares floating-point numbers with 
 * precision of 0.000001. Examples: (5.3 ; 6.01) -> false;  
 * (5.00000001 ; 5.00000003) -> true
 */
using System;

class ComparissonFloatingPointNum
{
    static void Main()
    {
        decimal a = 5.3M;
        decimal b = 6.01M;
        decimal x = 5.00000001M;
        decimal y = 5.00000003M;

        bool c = (Math.Abs(a - b)) > 0.000001M;
        bool z = (Math.Abs(x - y)) > 0.000001M;

        if (c)
        {
            Console.WriteLine("{0} = {1} with precision of 0.000001 -> {2}", a, b, false);
        }
        else
        {
            Console.WriteLine("{0} = {1} with precision of 0.000001 -> {2}", a, b, true);
        }

        if (z)
        {
            Console.WriteLine("{0} = {1} with precision of 0.000001 -> {2}", x, y, false);
        }
        else
        {
            Console.WriteLine("{0} = {1} with precision of 0.000001 -> {2}", x, y, true);
        }
    }
}