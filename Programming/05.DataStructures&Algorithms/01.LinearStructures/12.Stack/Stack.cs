using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Stack<T>
{
    private const int DEFAULT_LENGTH = 3;
    private T[] elements;
    private int currentSize = DEFAULT_LENGTH;
    private int count = 0;

    public Stack()
	{
        this.elements = new T[DEFAULT_LENGTH];
        count = 0;
	}

    public int Count()
    {
        return this.count;
    }

    public void Push(T element)
    {
        if (this.count >= currentSize)
        {
            Resize();
        }

        this.elements[count] = element;
        count++;
    }

    private void Resize()
    {
        int newSize = 2 * this.count;
        currentSize = newSize;
        T[] resizedArray = new T[newSize];

        for (int i = 0; i < this.elements.Length; i++)
        {
            resizedArray[i] = this.elements[i];
        }

        this.elements = resizedArray;
    }
    
    public T Peek()
    {
        if (this.count == 0)
	    {
            throw new InvalidOperationException("Stack empty");
	    }

        T lastElement = this.elements[count - 1];

        return lastElement;
    }

    public T Pop()
    {
        if (this.count == 0)
        {
            throw new InvalidOperationException("Stack empty");
        }
        
        T lastElement = this.elements[this.count - 1];
        RemoveAt(this.count - 1);
        this.count--;

        return lastElement;
    }

    private void RemoveAt(int lastIndex)
    {
        this.elements[lastIndex] = default(T);
    }

    public void Clear()
    {
        this.elements = new T[DEFAULT_LENGTH];
        this.count = 0;
    }
}

