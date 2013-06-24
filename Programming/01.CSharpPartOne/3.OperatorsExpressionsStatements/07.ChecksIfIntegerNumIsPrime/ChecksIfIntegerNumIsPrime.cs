/* Write an expression that checks if given positive integer * number n (n <= 100) is prime. E.g. 37 is prime.
 */
using System;

class ChecksIfIntegerNumIsPrime
{
    static void Main()
    {
        Console.WriteLine("Enter a number between 1 and 100 and check if it is prime: ");
        
        int n = int.Parse(Console.ReadLine());
        int divider = 2;
        int maxDivider = (int)Math.Sqrt(n);
        bool prime = true;

        if (n <= 100)
        {
            while (prime && divider <= maxDivider)
            {
                if (n % divider == 0)
                {
                    prime = false;
                }
                divider++;
            }
            Console.WriteLine("The number {0} is prime -> {1}", n, prime);
        }
        else
        {
            Console.WriteLine("Enter a number between 1 and 100.");
        }
    }
}

