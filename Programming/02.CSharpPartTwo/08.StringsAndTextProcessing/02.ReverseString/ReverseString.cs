/* Write a program that reads a string, reverses it and prints the result at the console.
 * Example: "sample" -> "elpmas".
*/
using System;

class ReverseString
{
    static void Main()
    {
        string str = "sample";

        char[] ch = str.ToCharArray();
        Array.Reverse(ch);
        Console.WriteLine(ch);
    }
}
