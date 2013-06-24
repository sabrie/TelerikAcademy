/* You are given a sequence of positive integer values written 
 * into a string, separated by spaces. Write a function that reads 
 * these values from given string and calculates their sum. 
 * Example: string = "43 68 9 23 318" -> result = 461
*/
using System;

class SumNumbersSeparBySpaces
{
    static int SumNumsSeparatedBySpaces(string str)
    {
        // remove the empty spaces in the beginning and at the end of the string
        str = str.Trim();
        // we split the string by spaces and save each element in an array
        string[] strNumbers = str.Split(' ');
        int sum = 0;
        // Parse each string element in the array and sum
        for (int i = 0; i < strNumbers.Length; i++)
        {
            sum = sum + int.Parse(strNumbers[i]);
        }
        return sum;        
    }

    static void Main()
    {
        Console.WriteLine("Enter a sequence of numbers separated by spaces: ");
        string numbers = Console.ReadLine();
        int sum = SumNumsSeparatedBySpaces(numbers);
        Console.WriteLine("Sum = {0}", sum);
    }    
}
