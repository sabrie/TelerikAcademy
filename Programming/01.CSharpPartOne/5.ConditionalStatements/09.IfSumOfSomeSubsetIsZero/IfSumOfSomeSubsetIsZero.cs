/* We are given 5 integer numbers. Write a program that checks 
 * if the sum of some subset of them is 0. 
 * Example: 3, -2, 1, 1, 8 -> 1+1-2=0.
*/
using System;

class IfSumOfSomeSubsetIsZero
{
    static void Main()
    {
        Console.WriteLine("Check if the sum of some subset of 5 numbers is 0.");
        Console.WriteLine("Enter 5 integer numbers each on a new line: ");
        int a1 = int.Parse(Console.ReadLine());
        int a2 = int.Parse(Console.ReadLine());
        int a3 = int.Parse(Console.ReadLine());
        int a4 = int.Parse(Console.ReadLine());
        int a5 = int.Parse(Console.ReadLine());
        
        if (a1 + a2 + a3 + a4 + a5 == 0)
        {
            Console.WriteLine("The sum of the elements {0}, {1}, {2}, {3}, {4} = 0.", a1, a2, a3, a4, a5);
        }
        if (a1 + a2 + a3 + a4 == 0)
        {
            Console.WriteLine("The sum of the elements {0}, {1}, {2}, {3} = 0.", a1, a2, a3, a4);
        }
        if (a1 + a2 + a3 == 0)
        {
            Console.WriteLine("The sum of the elements {0}, {1}, {2} = 0.", a1, a2, a3);
        }
        if (a1 + a2 == 0)
        {
            Console.WriteLine("The sum of the elements {0}, {1} = 0.", a1, a2);
        }
        if (a1 == 0)
        {
            Console.WriteLine("The sum of the elements {0} = 0.", a1);
        }
        if (a2 + a3 + a4 + a5 == 0)
        {
            Console.WriteLine("The sum of the elements {0}, {1}, {2}, {3} = 0.", a2, a3, a4, a5);
        }
        if (a2 + a3 + a4 == 0)
        {
            Console.WriteLine("The sum of the elements {0}, {1}, {2} = 0.", a2, a3, a4);
        }
        if (a2 + a3 == 0)
        {
            Console.WriteLine("The sum of the elements {0}, {1} = 0.", a2, a3);
        }
        if (a2 == 0)
        {
            Console.WriteLine("The sum of the elements {0} = 0.", a2);
        }
        if (a3 + a4 + a5 == 0)
        {
            Console.WriteLine("The sum of the elements {0}, {1}, {2} = 0.", a3, a4, a5);
        }
        if (a3 + a4 == 0)
        {
            Console.WriteLine("The sum of the elements {0}, {1} = 0.", a3, a4);
        }
        if (a3 == 0)
        {
            Console.WriteLine("The sum of the elements {0} = 0.", a3);
        }
        if (a4 + a5 == 0)
        {
            Console.WriteLine("The sum of the elements {0}, {1} = 0.", a4, a5);
        }
        if (a4 == 0)
        {
            Console.WriteLine("The sum of the elements {0} = 0.", a4);
        }
        if (a5 == 0)
        {
            Console.WriteLine("The sum of the elements {0} = 0.", a5);
        }
    }
}

