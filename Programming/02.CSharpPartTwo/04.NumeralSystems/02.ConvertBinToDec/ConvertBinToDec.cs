/* Write a program to convert binary numbers to their decimal representation.*/

using System;
using System.Collections.Generic;

class ConvertBinToDec
{
    static void Main()
    {
        Console.Write("Please enter a number in binary numeral system: ");
        int binNumber = int.Parse(Console.ReadLine());
        int decNumber = 0;
        int power = 1;

        while (binNumber > 0)
        {
            int lastBitValue = binNumber % 10;
            decNumber = decNumber + (lastBitValue * power);
            binNumber = binNumber / 10;
            power = power * 2;
        }
        Console.WriteLine("Its representation in decimal numeral system is: {0}", decNumber);
    }
}

