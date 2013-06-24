using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LinkedQueueDemo
{
    static void Main()
    {
        LinkedQueue<int> queue = new LinkedQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);

        Console.WriteLine("Queue count: " + queue.Count());
        Console.WriteLine("Top: " + queue.Peek());

        queue.Dequeue();
        Console.WriteLine("First deleted");
        Console.WriteLine("Queue count: " + queue.Count());
        Console.WriteLine("Top: " + queue.Peek());

        queue.Clear();
        Console.WriteLine("Queue cleared");
        Console.WriteLine("Queue count: " + queue.Count());
    }
}

