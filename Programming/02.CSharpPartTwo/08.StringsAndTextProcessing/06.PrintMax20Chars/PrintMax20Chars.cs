/* Write a program that reads from the console a string of maximum 20 characters. 
 * If the length of the string is less than 20, the rest of the characters should 
 * be filled with '*'. Print the result string into the console.
*/
using System;

class PrintMax20Chars
{
    static void Main()
    {
        string inputNumber = Console.ReadLine();

        // PadRight() method - left-aligns the characters in this string, 
        // padding on the right with spaces or a specified Unicode character, 
        // for a specified total length.
        Console.WriteLine(inputNumber.PadRight(20, '*'));        
    }
}

