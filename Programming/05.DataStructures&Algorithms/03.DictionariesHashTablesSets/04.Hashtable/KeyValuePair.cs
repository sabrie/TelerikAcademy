using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct KeyValuePair<K, T>
{
    private K key;
    private T value;

    public K Key 
    { 
        get
        {
            return this.key;
        }
        set
        {
            this.key = value;
        }
    }

    public T Value 
    { 
        get
        {
            return this.value;
        }
        set
        {
            this.value = value;
        }
    }
}

