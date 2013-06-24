/* Write a program that encodes and decodes a string using given encryption key (cipher). 
 * The key consists of a sequence of characters. The encoding/decoding is done by performing 
 * XOR (exclusive or) operation over the first letter of the string with the first of the key, 
 * the second – with the second, etc. When the last key character is reached, the next is the first.
*/
using System;
using System.Text;

class EncodeAndDecodeString
{
    static void Main()
    {
        string text = "We will rock you!";
        string key = "ab";

        StringBuilder encodeText = new StringBuilder();
        for (int index = 0; index < text.Length; index++)
        {
            int encodeSymbol = (int)text[index] ^ (int)key[index % key.Length];
            encodeText.Append((char)encodeSymbol);
        }
        Console.Write(encodeText.ToString());
        Console.WriteLine();


        StringBuilder decodedText = new StringBuilder();
        for (int index = 0; index < text.Length; index++)
        {
            int encodeSymbol = (int)encodeText[index] ^ (int)key[index % key.Length];
            decodedText.Append((char)encodeSymbol);
        }
        Console.WriteLine(decodedText.ToString());


        // Another way to encode
        //string text = "We will rock you";
        //string key = "sab";
        //int[] encode = new int[text.Length];

        //for (int index = 0; index < text.Length; index++)
        //{
        //    encode[index] = (int)text[index] ^ (int)key[index % key.Length];
        //}

        //for (int i = 0; i < text.Length; i++)
        //{
        //    Console.Write((char)encode[i]);
        //}
        //Console.WriteLine();
    }
}

