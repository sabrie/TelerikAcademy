/*
  3. Write a program to compare the performance of 
 square root, natural logarithm, sinus for float, double and decimal values.
 */
using System;
using System.Diagnostics;
using System.Linq;


class PerformanceOfSqrtLogSin
{
    static readonly Stopwatch stopwatch = new Stopwatch();

    static void DisplayExecutionTime(string title, Action action)
    {
        Console.Write("{0, -30}", title);
        stopwatch.Restart();

        action();

        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed);
    }

    static void Main()
    {
        // Checks performans of Square root for float, double, decimal
        int sqrtOf = 10000;

        Console.WriteLine("Square root of {0}", sqrtOf);
        Console.WriteLine(new string('-', 50));

        DisplayExecutionTime("float", () =>
        {
            for (int i = 0; i < 100000; i++)
            {
                Math.Sqrt(10000.0f);                
            }           
        }
        );

        DisplayExecutionTime("double", () =>
        {
            for (int i = 0; i < 100000; i++)
            {
                Math.Sqrt(10000.0);
            }   
        }
        );

        // We can not pass as parameter a decimal value to Math.Sqrt(); 
        // DisplayExecutionTime("decimal", () =>
        //{
        //    for (int i = 0; i < 100000; i++)
        //    {
        //        Math.Sqrt(10000.0m);
        //    }
        //}
        //);

        Console.WriteLine();

        // Checks performans of Natural Logarithm for float, double, decimal
        int logarithmOf = 10000;

        Console.WriteLine("Natural logarithm of ", logarithmOf);
        Console.WriteLine(new string('-', 50));

        DisplayExecutionTime("float", () =>
        {
            for (int i = 0; i < 100000; i++)
            {
                Math.Log(10000.0f);
            }   
        }
        );

        DisplayExecutionTime("double", () =>
        {
            for (int i = 0; i < 100000; i++)
            {
                Math.Log(10000.0);
            } 
        }
        );

        // We can not pass as parameter a decimal value to Math.Log(); 
        // DisplayExecutionTime("decimal", () =>
        //{
        //    for (int i = 0; i < 100000; i++)
        //    {
        //        Math.Log(10000.0m);
        //    }
        //}
        //);

        Console.WriteLine();

        // Checks performans of Sinus for float, double, decimal
        int sinusOf = 10000;

        Console.WriteLine("Sinus of ", sinusOf);
        Console.WriteLine(new string('-', 50));

        DisplayExecutionTime("float", () =>
        {
            for (int i = 0; i < 100000; i++)
            {
                Math.Sin(10000.0f);
            } 
        }
        );

        DisplayExecutionTime("double", () =>
        {
            for (int i = 0; i < 100000; i++)
            {
                Math.Sin(10000.0);
            } 
        }
        );

        // We can not pass as parameter a decimal value to Math.Sin();
        // DisplayExecutionTime("decimal", () =>
        //{
        //    for (int i = 0; i < 100000; i++)
        //    {
        //        Math.Sin(10000.0m);
        //    }
        //}
        //);       
    }
}
