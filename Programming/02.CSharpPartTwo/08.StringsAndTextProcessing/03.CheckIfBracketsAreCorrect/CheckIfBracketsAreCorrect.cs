/* Write a program to check if in a given expression the brackets are put correctly.
 * Example of correct expression: ((a+b)/5-d).
 * Example of incorrect expression: )(a+b)).
*/
using System;

class CheckIfBracketsAreCorrect
{
    static void Main()
    {
        string str = ")(a+b))";

        int sum = 0;
        bool isCorrect = true;
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '(')
            {
                sum = sum + 1;
            }
            if (str[i] == ')')
            {
                sum = sum - 1;                
            }
            if (sum < 0)
            {
                isCorrect = false;
            }
        }
        if (sum > 0)
        {
            isCorrect = false;
        }
        Console.WriteLine("The brackets are put correct: {0}", isCorrect);
    }
}
