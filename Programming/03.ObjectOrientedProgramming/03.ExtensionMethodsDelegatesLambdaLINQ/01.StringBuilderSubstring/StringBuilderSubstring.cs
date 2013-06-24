using System;
using System.Text;

static class StrBuilderSubstring
{
    // properties
    public static int Index {get; private set;}
    public static int Length { get; private set; }
    
    // constructor
    public static StringBuilder StringBuilderSubstring(this StringBuilder sb, int index, int length)
    {
        if (index >= sb.Length || index + length >= sb.Length)
        {
            throw new IndexOutOfRangeException(string.Format("Index {0} was outside the bounds of the array", index));
        }
        StringBuilder result = new StringBuilder();

        for (int i = index; i < length + index; i++)
        {
            result.Append(sb[i]);
        }

        return result;
    }
}

