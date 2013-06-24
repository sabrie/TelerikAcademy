/* Write a method that returns the last digit of given integer as an English word. 
 * Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine".
*/
using System;

class ReturnLastDigitOfIntAsWord
{
    static void SayDigit(int digit)
    {
        string[] digits = new string[] {
            "one", "two", "three", "four", "five", "six",
            "seven", "eight", "nine"
        };
        Console.WriteLine(digits[digit-1]);
    }
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int lastDigit = number % 10;
        Console.Write("The last digit is -> ");
        
        if (lastDigit == 0)
        {
            Console.WriteLine("zero");
        }
        else
        {
            SayDigit(lastDigit);
        }
    }
}

