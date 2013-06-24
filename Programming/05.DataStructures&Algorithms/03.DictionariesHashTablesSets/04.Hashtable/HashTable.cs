using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
{
    private const int DEFAULI_CAPACITY = 16;
    private readonly int currentCapacity;
    private LinkedList<KeyValuePair<K, T>>[] elements;
    private int count = 0;

    public int Count 
    {
        get
        {
            return this.count;
        }
        set
        {
            this.count = value;
        }
    }

    public int this[K key]
    {
        get 
        {
            return this.GetPosition(key);
        }
    }

    public HashTable(int capacity = DEFAULI_CAPACITY)
    {
        this.currentCapacity = capacity;
        this.elements = new LinkedList<KeyValuePair<K, T>>[capacity];
    }

    public int GetPosition(K key)
    {
        int position = key.GetHashCode() % currentCapacity;
        return Math.Abs(position);
    }

    public T Find(K key)
    {
        int position = GetPosition(key);
        LinkedList<KeyValuePair<K, T>> linkedList = 
            GetLinkedList(position);
        
        foreach (KeyValuePair<K, T> item in linkedList)
        {
            if (item.Key.Equals(key))
            {
                return item.Value;
            }
        }

        return default(T);
    }

    public void Add(K key, T value)
    {
        //if (this.count + 1 >= this.currentCapacity)
        //{
        //    Resize();
        //}

        int position = GetPosition(key);
        LinkedList<KeyValuePair<K, T>> linkedList = 
            GetLinkedList(position);
        KeyValuePair<K, T> item = new KeyValuePair<K, T>() 
        { 
            Key = key, Value = value 
        };

        linkedList.AddLast(item);
        count++;
    }

    //private void Resize()
    //{
    //    int newSize = 2 * this.elements.Length;
        
    //    LinkedList<KeyValuePair<K, T>>[] oldElements = this.elements;
    //    this.elements = new LinkedList<KeyValuePair<K, T>>[newSize];

    //    foreach (LinkedList<KeyValuePair<K, T>> oldElement in oldElements)
    //    {
    //        if (oldElement != null)
    //        {
    //            foreach (KeyValuePair<K, T> keyValuePair in oldElement)
    //            {
    //                LinkedList<KeyValuePair<K, T>> newElements =
    //                    FindChain(keyValuePair.Key, true);
    //                newElements.Add(keyValuePair);
    //            }
    //        }
    //    }
    //}

    //private LinkedList<KeyValuePair<K, T>> FindChain(
    //    K key, bool createIfMissing)
    //{
    //    int index = key.GetHashCode();
    //    index = index % this.elements.Length;
    //    if (this.elements[index] == null && createIfMissing)
    //    {
    //        this.elements[index] = new LinkedList<KeyValuePair<K, T>>();
    //    }
    //    return this.elements[index] as LinkedList<KeyValuePair<K, T>>;
    //}

    public void Remove(K key)
    {
        int position = GetPosition(key);
        LinkedList<KeyValuePair<K, T>> linkedList = 
            GetLinkedList(position);
        bool itemFound = false;
        KeyValuePair<K, T> foundItem = default(KeyValuePair<K, T>);
        foreach (KeyValuePair<K, T> item in linkedList)
        {
            if (item.Key.Equals(key))
            {
                itemFound = true;
                foundItem = item;
            }
        }

        if (itemFound)
        {
            linkedList.Remove(foundItem);
            count--;
        }
    }

    protected LinkedList<KeyValuePair<K, T>> GetLinkedList(int position)
    {
        LinkedList<KeyValuePair<K, T>> linkedList = 
            this.elements[position];

        if (linkedList == null)
        {
            linkedList = new LinkedList<KeyValuePair<K, T>>();
            this.elements[position] = linkedList;
        }

        return linkedList;
    }

    public void Clear()
    {
        if (this.elements != null)
        {
            this.elements = 
                new LinkedList<KeyValuePair<K, T>>[currentCapacity];
        }

        this.count = 0;
    }

    IEnumerator<KeyValuePair<K, T>>
        IEnumerable<KeyValuePair<K, T>>.GetEnumerator()
    {
        foreach (LinkedList<KeyValuePair<K, T>> pair in this.elements)
        {
            if (pair != null)
            {
                foreach (var item in pair)
                {
                    yield return item;
                }
            }
        }
    }
    
    /// <summary>
    /// Allows iteration over hash table elements with foreach
    /// </summary>
    /// <returns>Returns an enumerator that iterates through a collection.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<KeyValuePair<K, T>>)this).
            GetEnumerator();
    }

    public override string ToString()
    {
        StringBuilder output = new StringBuilder();

        if (this.elements.Length == 0)
        {
            throw new ArgumentNullException("HashTable is empty.");
        }

        foreach (var element in this.elements)
        {
            if (element != null)
            {
                foreach (var item in element)
                {
                    output.AppendLine(item.Key + " : " + item.Value);
                }
            }
        }

        return output.ToString();
    }
}

