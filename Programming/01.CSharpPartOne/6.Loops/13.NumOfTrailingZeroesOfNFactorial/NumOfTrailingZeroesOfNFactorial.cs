/* Write a program that calculates for given N how many 
 * trailing zeros present at the end of the number N!. 
 * Examples:
 * N = 10 -> N! = 3628800 -> 2
 * N = 20 -> N! = 2432902008176640000 -> 4
 * Does your program work for N = 50 000?
 * Hint: The trailing zeros in N! are equal to the number 
 * of its prime divisors of value 5. Think why!
*/
using System;

class NumOfTrailingZeroesOfNFactorial
{
    static void Main()
    {
        Console.WriteLine("The program calculates the trailing zeroes of N!.");
        Console.Write("Enter a value for N > 0: ");
        int n = int.Parse(Console.ReadLine());
        int result = 0; // the number of trailing zeroes of N!
        if (n > 0)
        {
            // divides N by 5, 5^2, 5^3 ... 5^n until n >= 5^n
            for (int i = 5; i <= n; i *= 5) 
            {
                // calculates the number of trailing zeroes of N! 
                // result = n/5 + n/5^2 ... n/5^n for n >= 5^n
                result = result + (n / i);
            }
            Console.WriteLine("Trailing zeroes of {0}! are {1}.", n, result);
        }
        else
        {
            Console.WriteLine("Error! Enter a positive number -> N > 0!");
        }
    }
}