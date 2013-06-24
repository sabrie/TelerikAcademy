using System;
using System.Collections.Generic;
using System.Text;

class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null)
        {
            throw new ArgumentNullException("The array is null!");
        }

        if (!(0 <= startIndex && startIndex < arr.Length))
        {
            throw new ArgumentOutOfRangeException("Start index is outside the bounds of the array.");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(
                "count", "The number of elements in the array to be substracted should be positive!");
        }

        if (startIndex + count > arr.Length)
        {
            throw new ArgumentOutOfRangeException(
                String.Format("There are no {0} elements in the array starting from index {1}", count, startIndex));
        }
        
        List<T> result = new List<T>();

        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count > str.Length)
        {
            throw new ArgumentOutOfRangeException(
                "count", "Number of elements which you would like to extract are bigger than the array length");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }
        return result.ToString();
    }

    public static bool IsPrime(int number)
    {
        if (number <= 0)
        {
            throw new ArgumentOutOfRangeException("number", "Please, enter a positive number.");
        }

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    static void Main()
    {
        var subStr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(subStr);

        var subArr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(String.Join(" ", subArr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(String.Join(" ", allarr));

        var emptyArr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(String.Join(" ", emptyArr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));

        try
        {
            Console.WriteLine(ExtractEnding("Hi", 100));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("23 is prime: " + IsPrime(23));
        Console.WriteLine("33 is prime: " + IsPrime(33));

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResult();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
