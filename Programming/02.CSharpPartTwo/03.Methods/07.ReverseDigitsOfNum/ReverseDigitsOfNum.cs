/* Write a method that reverses the digits of given decimal number. 
 * Example: 256 -> 652
*/
using System;

class ReverseDigitsOfNum
{
    // reshenie na kolega - obrashta cifrite i na otritsatelni chisla
    static int ReverseDigitsOfNumber(int number)
    {
        bool numberIsNegative = false;
        if (number < 0)
        {
            numberIsNegative = true;
            number = -number;
        }

        int numberWithReversedDigits = 0;
        while (number > 0)
        {
            numberWithReversedDigits = (numberWithReversedDigits * 10) + (number % 10);
            number /= 10;
        }

        if (numberIsNegative)
        {
            numberWithReversedDigits = -numberWithReversedDigits;
        }

        return numberWithReversedDigits;
    }

    static void PrintReversedDigits(int num)
    {
        int remainder;
        do
        {
            // take the last digit of a number and print it
            remainder = num % 10;  // 123 % 10 = 3;
            Console.Write(remainder);
            num = num / 10;
        } while (num > 0);
    }

    static void Main()
    {
        int num = 256;
        Console.WriteLine("Number: {0}", num);
        Console.Write("Reversed: ");
        PrintReversedDigits(num);
        Console.WriteLine();
    }    
}

