using System;
using System.Text;

class StrBuilderSubstrTest
{
    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("One");
        sb.Append("Two");
        sb.Append("Three");

        Console.WriteLine(sb);
        // StringBuilderSubstring - the first arguments is the start index, the second argument is the length of the substring
        Console.WriteLine(sb.StringBuilderSubstring(10, 2));
    }
}

