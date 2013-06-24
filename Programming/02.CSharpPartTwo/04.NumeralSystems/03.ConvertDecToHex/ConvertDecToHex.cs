/* Write a program to convert decimal numbers to their hexadecimal representation. */
using System;
using System.Collections.Generic;
using System.Text;

class ConvertDecToHex
{
    static void Main()
    {
        Console.Write("Enter a decimal number: ");
        int decimalNum = int.Parse(Console.ReadLine());

        // a string array of hexadecimal symbols from 0-9, A-F
        string[] hexSymbols = {
            "0", "1", "2", "3", "4", "5", "6", "7", "8",
            "9", "A", "B", "C", "D", "E", "F" };

        List<string> hexNum = new List<string>();

        if (decimalNum == 0)
        {
            Console.Write("In hexadecimal numeral system -> ");
            Console.WriteLine(hexSymbols[0]); ;
        }
        else
        {
            while (decimalNum > 0)
            {
                // take the remainder from division of the decimal number by 16 
                int remainder = decimalNum % 16;
                // add to List<string> hexNum the value which corresponds to the value at position remaider in the HexSymbols[]
                hexNum.Add(hexSymbols[remainder]);
                decimalNum = decimalNum / 16;
            }

            // reverse the List elements
            hexNum.Reverse();

            // print the List elements on the Console
            Console.Write("In hexadecimal numeral system -> ");
            for (int i = 0; i < hexNum.Count; i++)
            {
                Console.Write(hexNum[i]);
            }
            Console.WriteLine();
        }
    }    
}