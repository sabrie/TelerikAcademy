/* Write a program that finds how many times a substring is 
 * contained in a given text (perform case insensitive search).
*/
using System;

class CountOccurenceOfSubstr
{
    static void Main()
    {
        string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days";
        string target = "in";
        int ocurrenceCounter = 0;
        // IndexOf() is case-sensitive - use ToUpper() for workaround
        int index = text.ToUpper().IndexOf(target.ToUpper());

        Console.WriteLine("Substring: {0}", target);
        if (index == -1)
        {
            Console.WriteLine("Occurence: {0} times", ocurrenceCounter);
        }
        else
        {
            while (index != -1)
            {
                // IndexOf() is case-sensitive - use ToUpper() for workaround
                index = text.ToUpper().IndexOf(target.ToUpper(), index + 1);
                ocurrenceCounter++;
            }
            Console.WriteLine("Occurence: {0} times", ocurrenceCounter);
        }


        // reshenie na kolega
        //string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        //string substring = "in";
        //int counter = 0;
        //for (int i = 0; i < text.Length - 1; i++)
        //{
        //    if (substring == text.Substring(i, 2).ToLower())
        //    {
        //        counter++;
        //    }
        //}
        //Console.WriteLine(counter);
    }
}

