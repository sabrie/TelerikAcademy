/* Write a program that converts a string to a sequence of C# Unicode character literals. 
 * Use format strings. 
 * Sample input: Hi!
 * Expected output: \u0048\u0069\u0021
*/
using System;

class PrintStrAsSeqOfUnicodeChars
{
    static void Main()
    {
        string hi = "Hi!";

        for (int i = 0; i < hi.Length; i++)
        {
            char ch = hi[i];
            Console.Write("\\u{0:x4}", (int)ch);
        }
        Console.WriteLine();
    }
}
