using System;
using System.Linq;
using System.Text;

public class GenericList<T>
    where T : IComparable<T>
{
    const int DefaultCapacity = 1;
    
    // field
    private T[] elements;

    // constructor
    public GenericList(int capacity = DefaultCapacity)
    {
        elements = new T[capacity];
    }

    // property
    public int Count { get; private set; }

    // method that adds elements to the array
    public void AddElement(T element)
    {
        if (Count >= elements.Length)
        {
            // method in this class that doubles the size of the array
            DoubleArraySize(Count);
        }
        this.elements[Count] = element;
        Count++;
    }

    // method that accesses element at given position
    public T AccessElementAtPosition(int index)
    {
        if (index >= elements.Length || index < 0)
        {
            throw new IndexOutOfRangeException(String.Format(
                "The index {0} is outside the boundaries of the array.", index));
        }
        return this.elements[index];
    }

    // method that adds element at given position
    public void AddElementAtIndex(T element, int index)
    {
        if (Count >= elements.Length)
        {
            // method in this class that doubles the size of the array
            DoubleArraySize(Count);
        }
        // move the elements in the array to the right
        for (int i = elements.Length - 1; i > index; i--)
        {
            elements[i] = elements[i - 1];
        }
        elements[index] = element;
        Count++;
    }

    // method that removes element at given position
    public void RemoveElementAtIndex(int index)
    {
        for (int i = index; i < elements.Length - 1; i++)
        {
            elements[i] = elements[i + 1];
        }
        elements[elements.Length - 1] = default(T);
        Count--;
    }

    // method that clears the list
    public void ClearAllElements()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            // assigns default value to each element
            elements[i] = default(T);
        }
        Count = 0;
    }

    // method that finds element by value and prints its index 
    public int IndexOfElement(T element)
    {
        int index = Array.IndexOf(elements, element);
        return index;
    }

    // method that creates a new array with double size - auto-grow - Exercise 6
    public void DoubleArraySize(int count)
    {
        T[] newElements = new T[2 * count];

        for (int i = 0; i < elements.Length; i++)
        {
            newElements[i] = elements[i];
        }
        elements = newElements;
    }

    // indexer
    public T this[int index]
    {
        get
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException(String.Format(
                    "Invalid index: {0}.", index));
            }
            T result = elements[index];
            return result;
        }
        set
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException(String.Format(
                    "Invalid index: {0}.", index));
            }
            elements[index] = value;
        }
    }

    // method that finds the max element in the array
    public T GetMax()
    {
        T maxElement = elements[0];

        for (int i = 0; i < elements.Length; i++)
        {
            if (elements[i].CompareTo(maxElement) > 0)
            {
                maxElement = elements[i];
            }
        }
        return maxElement;
    }

    // method that finds the max element in the array
    public T GetMin()
    {
        T minElement = elements[0];

        for (int i = 0; i < elements.Length; i++)
        {
            if (elements[i].CompareTo(minElement) < 0)
            {
                minElement = elements[i];
            }
        }
        return minElement;
    }

    // method that prints the information following the format below
    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        foreach (T element in this.elements)
        {
            info.AppendLine(element.ToString());
        }
        return info.ToString();
    }

    //// method that prints the information following the format below
    //public override string ToString()
    //{
    //    return String.Join(" ", elements);
    //}
}
