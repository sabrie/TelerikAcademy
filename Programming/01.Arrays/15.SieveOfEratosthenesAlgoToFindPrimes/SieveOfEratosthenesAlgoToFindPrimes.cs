/* Write a program that finds all prime numbers in the range [1...10 000 000]. 
 * Use the sieve of Eratosthenes algorithm.
*/
using System;

class SieveOfEratosthenesAlgoToFindPrimes
{
    static void Main()
    {
        int n = 100;
        Console.WriteLine("Prime numbers in the range [1...{0}] are: ", n);
        
        bool[] isPrime = new bool[n]; // by default values of all elements are false

        for (int index = 2; index < n; index++)
        {
            isPrime[index] = true; //set all numbers to true
        }
        
        // clear out the non primes by finding multiples 
        for (int index = 2; index < n; index++)
        {
            if (isPrime[index]) //is true
            {
                for (long p = 2; (p * index) < n; p++)
                {
                    isPrime[p * index] = false;
                }
            }
        }

        // print prime numbers in the given range
        int prime = 0;
        for (int i = 0; i < n; i++)
        {
            if (isPrime[i])
            {                
                Console.Write(prime + "  ");              
            }
            prime++;
        }
        Console.WriteLine();
    }
}

