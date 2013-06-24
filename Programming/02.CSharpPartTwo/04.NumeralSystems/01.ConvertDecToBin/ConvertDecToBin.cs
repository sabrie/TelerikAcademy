/* Write a program to convert decimal numbers to their binary representation.*/

using System;
using System.Collections.Generic;

class ConvertDecToBin
{
    static void Main()
    {
        //if numSyst <= 9; it converts a decimal number to any numeric system from base 2 to base 9
        int numSyst = 2;
        int decNumber = 16;
        int binNumber;

        List<int> result = new List<int>();
        //int[] result = new int[32];
        
        while (decNumber > 0)
        {
            binNumber = decNumber % numSyst;
            result.Add(binNumber);
            //result[32 - 1 - i] = binNumber;
            decNumber = decNumber / numSyst;
        }
       
        result.Reverse();

        for (int i = 0; i < result.Count; i++)
        {
            Console.Write(result[i]);
        }
        Console.WriteLine();
    }    
}
