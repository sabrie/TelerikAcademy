/* Implement the ADT stack as auto-resizable array. 
 * Resize the capacity on demand (when no space is 
 * available to add / insert a new element).
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StackDemo
{
    static void Main()
    {
        Stack<int> stack = new Stack<int>();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);
        
        Console.WriteLine("Stack count: " + stack.Count());
        Console.WriteLine("Top: " + stack.Peek());
        
        stack.Pop();
        Console.WriteLine("Top deleted");
        Console.WriteLine("Stack count: " + stack.Count());
        Console.WriteLine("Top: " + stack.Peek());

        stack.Clear();
        Console.WriteLine("Stack cleared");
        Console.WriteLine("Stack count: " + stack.Count());
    }
}

