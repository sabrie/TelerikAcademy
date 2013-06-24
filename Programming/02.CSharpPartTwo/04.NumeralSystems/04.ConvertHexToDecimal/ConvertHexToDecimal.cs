/* Write a program to convert hexadecimal numbers to their decimal representation.*/
using System;
using System.Collections.Generic;

class ConvertHexToDecimal
{
    static void Main()
    {
        string hexNumber = "A4"; 
        int decimalNum = 0;
        int decValueOfHexSymbol = 1;
        int power = 1;

        Console.WriteLine("The hexadecimal number {0} ", hexNumber);

        for (int i = 0; i < hexNumber.Length; i++)
        {
            switch (hexNumber[hexNumber.Length - i - 1])
            {
                case '1':
                    decValueOfHexSymbol = 1;
                    break;
                case '2':
                    decValueOfHexSymbol = 2;
                    break;
                case '3':
                    decValueOfHexSymbol = 3;
                    break;
                case '4':
                    decValueOfHexSymbol = 4;
                    break;
                case '5':
                    decValueOfHexSymbol = 5;
                    break;
                case '6':
                    decValueOfHexSymbol = 6;
                    break;
                case '7':
                    decValueOfHexSymbol = 7;
                    break;
                case '8':
                    decValueOfHexSymbol = 8;
                    break;
                case '9':
                    decValueOfHexSymbol = 9;
                    break;
                case 'A':
                    decValueOfHexSymbol = 10;
                    break;
                case 'B':
                    decValueOfHexSymbol = 11;
                    break;
                case 'C':
                    decValueOfHexSymbol = 12;
                    break;
                case 'D':
                    decValueOfHexSymbol = 13;
                    break;
                case 'E':
                    decValueOfHexSymbol = 14;
                    break;
                case 'F':
                    decValueOfHexSymbol = 15;
                    break;
                default:
                    decValueOfHexSymbol = hexNumber[i];
                    break;
            }
            decimalNum = decimalNum + decValueOfHexSymbol * power;
            power = power * 16;
        }

        Console.Write("in decimal representation is: ");
        Console.WriteLine(decimalNum);
    }
}

