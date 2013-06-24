/* Write a program to read your age from the console and print
how old you will be after 10 years.
*/
using System;

class CalculatesAgeAfterTenYears
{
    static void Main()
    {
        int age;
        
        Console.Write("Enter your age: ");
        age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Your age after ten years will be: ");
        Console.WriteLine(age + 10);
    }
}
