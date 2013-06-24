using System;
using System.Collections;
using System.Collections.Generic;

class BitArray64 : IEnumerable<int>
{
    private const int Capacity = 64;
    private ulong number = 0;

    public int this[int index]
    {
        get
        {
            if (!(0 <= index && index < Capacity))
            {
                throw new ArgumentOutOfRangeException();
            }

            return (int)((this.number >> index) & 1);
        }
        set
        {
            if (!(0 <= index && index < Capacity))
            {
                throw new ArgumentOutOfRangeException();
            }

            if (!(value == 0 || value == 1))
            {
                throw new ArgumentOutOfRangeException();
            }

            if (value == 1)
            {
                this.number = this.number | (1UL << index);
            }

            else
            {
                this.number = this.number & ~(1UL << index);
            }
        }
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < Capacity; i++)
            yield return this[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override bool Equals(object obj)
    {
        return this.number == (obj as BitArray64).number;
    }

    public static bool operator ==(BitArray64 a, BitArray64 b)
    {
        return BitArray64.Equals(a, b);
    }

    public static bool operator !=(BitArray64 a, BitArray64 b)
    {
        return !BitArray64.Equals(a, b);
    }

    public override int GetHashCode()
    {
        return this.number.GetHashCode();
    }

    public override string ToString()
    {
        return String.Join<int>("", this);
    }
}
