using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class LinkedQueue<T>
{
    private LinkedList<T> queue;
    int count = 0;

    public LinkedQueue()
    {
        queue = new LinkedList<T>();
        this.count = 0;
    }

    public int Count()
    {
        return this.count;
    }

    public void Enqueue(T element)
    {
        this.queue.AddLast(element);
        this.count++;
    }

    public T Peek()
    {
        return this.queue.First();
    }

    public T Dequeue()
    {
        T firstElement = this.queue.First();
        this.queue.RemoveFirst();
        this.count--;

        return firstElement;
    }

    public void Clear()
    {
        this.queue = new LinkedList<T>();
        this.count = 0;
    }
}

