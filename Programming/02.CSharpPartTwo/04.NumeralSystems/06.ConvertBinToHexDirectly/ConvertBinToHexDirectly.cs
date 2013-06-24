/* Write a program to convert binary numbers to hexadecimal numbers (directly). */

using System;

class ConvertBinToHexDirectly
{
    static void Main()
    {
        string binNum = "11111110"; // FE
        int n = binNum.Length / 4; // length of the array that will save the hex symbols
        int result4BinSymbols = 0;
        string[] hexNum = new string[n]; // save the hex symbols
     
        int power = 1; // power of 2
        int counter = 0; // count binary symbols
        int index = 0; // index of hexNumber array

        for (int i = 0; i < binNum.Length; i++)
        {
            // take the values of the binNum elements starting from right to left
            switch (binNum[binNum.Length - i - 1])
            { 
                case '1':
                    result4BinSymbols = result4BinSymbols + power;
                    break;
                default:
                    break;
            }
            power = power * 2;
            counter++;
            
            // after we have calculated the first four binary symbols we find their equivalent in hex system
            if (counter == 4)
            {                
                if (result4BinSymbols >=0 && result4BinSymbols <= 9)
                {                    
                    hexNum[index] = "" + result4BinSymbols;
                }
                if (result4BinSymbols > 9)
                {
                    switch (result4BinSymbols)
                    {
                        case 10:
                            hexNum[index] = "A";
                            break;
                        case 11:
                            hexNum[index] = "B";
                            break;
                        case 12:
                            hexNum[index] = "C";
                            break;
                        case 13:
                            hexNum[index] = "D";
                            break;
                        case 14:
                            hexNum[index] = "E";
                            break;
                        case 15:
                            hexNum[index] = "F";
                            break;
                        default:
                            break;
                    }
                    index++; // iterate by one the index of hexNum array
                    // reset counter, power and result4BinSymbols
                    counter = 0;
                    power = 1;
                    result4BinSymbols = 0;
                }
            }
        }

        Console.Write("The binary number {0} in hexadecimal system is: ", binNum);
        // print reversed array of hex symbols
        for (int i = 0; i < n; i++)
        {
            Console.Write(hexNum[n - i - 1]);
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}

