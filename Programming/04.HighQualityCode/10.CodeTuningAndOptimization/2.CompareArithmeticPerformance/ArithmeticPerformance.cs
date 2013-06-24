/*
 2. Write a program to compare the performance of add, subtract, increment, multiply, 
 divide for int, long, float, double and decimal values.
 
*/

using System;
using System.Diagnostics;

class ArithmeticPerformance
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
        // Checks Add performance for int, long, float, double, decimal
        // ------------------------
        int sumFromZeroTo = 100000000;

        Console.WriteLine("Sum numbers from 0 to {0}", sumFromZeroTo);
        Console.WriteLine(new string('-', 50));
        
        DisplayExecutionTime("int", () =>
        {
            int sum = 0;

            for (int i = 0; i < sumFromZeroTo; i++)
            {
                sum += i;
            }
        }
        );

        DisplayExecutionTime("long", () =>
            {
                long sum = 0;

                for (int i = 0; i < sumFromZeroTo; i++)
                {
                    sum += i;
                }
            }
        );

        DisplayExecutionTime("float", () =>
        {
            float sum = 0;

            for (int i = 0; i < sumFromZeroTo; i++)
            {
                sum += i;
            }
        }
        );

        DisplayExecutionTime("double", () =>
        {
            double sum = 0;

            for (int i = 0; i < sumFromZeroTo; i++)
            {
                sum += i;
            }
        }
        );

        DisplayExecutionTime("decimal", () =>
        {
            decimal sum = 0;

            for (int i = 0; i < sumFromZeroTo; i++)
            {
                sum += i;
            }
        }
        );

        Console.WriteLine();

        // Checks Subtraction performance for int, long, float, double, decimal
        // ------------------------

        int startSubtractFrom = 100000000;

        Console.WriteLine("Subtract numbers from {0} to 0", startSubtractFrom);
        Console.WriteLine(new string('-', 50));

        DisplayExecutionTime("int", () =>
        {
            int subtractResult = 0;

            for (int i = startSubtractFrom; i <= 0; i--)
            {
                subtractResult -= i;
            }
        }
        );

        DisplayExecutionTime("long", () =>
        {
            long subtractResult = 0;

            for (int i = startSubtractFrom; i <= 0; i--)
            {
                subtractResult -= i;
            }
        }
        );

        DisplayExecutionTime("float", () =>
        {
            float subtractResult = 0;

            for (int i = startSubtractFrom; i <= 0; i--)
            {
                subtractResult -= i;
            }
        }
        );

        DisplayExecutionTime("double", () =>
        {
            double subtractResult = 0;

            for (int i = startSubtractFrom; i <= 0; i--)
            {
                subtractResult -= i;
            }
        }
        );

        DisplayExecutionTime("decimal", () =>
        {
            decimal subtractResult = 0;

            for (int i = startSubtractFrom; i <= 0; i--)
            {
                subtractResult -= i;
            }
        }
        );

        Console.WriteLine();

        // Checks Multiplication performance for int, long, float, double, decimal
        // ----------------------------

        int multiplyFromOneTo = 10;

        Console.WriteLine("Multiply numbers from 0 to {0}", multiplyFromOneTo);
        Console.WriteLine(new string('-', 50));

        DisplayExecutionTime("int", () =>
        {
            int multiplyResult = 1;

            for (int i = 1; i <= multiplyFromOneTo; i++)
            {
                multiplyResult *= i;
            }
        }
        );

        DisplayExecutionTime("long", () =>
        {
            long multiplyResult = 1;

            for (int i = 1; i <= multiplyFromOneTo; i++)
            {
                multiplyResult *= i;
            }
        }
        );

        DisplayExecutionTime("float", () =>
        {
            float multiplyResult = 1;

            for (int i = 1; i <= multiplyFromOneTo; i++)
            {
                multiplyResult *= i;
            }
        }
        );

        DisplayExecutionTime("double", () =>
        {
            double multiplyResult = 1;

            for (int i = 1; i <= multiplyFromOneTo; i++)
            {
                multiplyResult *= i;
            }
        }
        );

        DisplayExecutionTime("decimal", () =>
        {
            decimal multiplyResult = 1;

            for (int i = 1; i <= multiplyFromOneTo; i++)
            {
                multiplyResult *= i;
            }
        }
        );

        Console.WriteLine();

        // Checks division performance for int, long, float, double, decimal
        // ------------------------

        int startDivideFrom = 10;

        Console.WriteLine("Divide numbers from {0} to 0", startDivideFrom);
        Console.WriteLine(new string('-', 50));

        DisplayExecutionTime("int", () =>
        {
            int divideResult = 1;

            for (int i = 1; i <= startDivideFrom; i++)
            {
                divideResult *= i;
            }
        }
        );

        DisplayExecutionTime("long", () =>
        {
            long divideResult = 1;

            for (int i = 1; i <= startDivideFrom; i++)
            {
                divideResult *= i;
            }
        }
        );

        DisplayExecutionTime("float", () =>
        {
            float divideResult = 1;

            for (int i = 1; i <= startDivideFrom; i++)
            {
                divideResult *= i;
            }
        }
        );

        DisplayExecutionTime("double", () =>
        {
            double divideResult = 1;

            for (int i = 1; i <= startDivideFrom; i++)
            {
                divideResult *= i;
            }
        }
        );

        DisplayExecutionTime("decimal", () =>
        {
            decimal divideResult = 1;

            for (int i = 1; i <= startDivideFrom; i++)
            {
                divideResult *= i;
            }
        }
        );
    }
}
