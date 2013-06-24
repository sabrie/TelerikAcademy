using System;

class AstrologicalDigits
{
    static void Main()
    {
        int sumDigits = 0;
        while (true)
        {
            int ch = Console.Read();
            if ((ch == -1) || (ch == '\n') || (ch == '\r'))
            {
                break;
            }
            if (ch >= '0' && ch <= '9')
            {
                char nextChar = (char)ch;
                int digit = nextChar - '0';
                sumDigits = sumDigits + digit;
            }
        }
        
        while (sumDigits > 9)
        {
            int finalSum = 0;
            while (sumDigits > 0)
            {
                int lastDigit = sumDigits % 10;
                finalSum = finalSum + lastDigit;
                sumDigits = sumDigits / 10;
            }
            sumDigits = finalSum;
        }
        Console.WriteLine(sumDigits);
    }
}

