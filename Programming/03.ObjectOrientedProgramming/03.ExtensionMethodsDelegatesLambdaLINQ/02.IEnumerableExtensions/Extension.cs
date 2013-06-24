/* Implement a set of extension methods for IEnumerable<T> that implement the 
 * following group functions: sum, product, min, max, average.
*/

using System;
using System.Collections.Generic;

public static class Extension
{
    // extenssion method for IEnumerable<T> that implement the function Sum
    public static T Sum<T>(this IEnumerable<T> items)
    {
        dynamic sum = 0;
        foreach (var item in items)
        {
            sum += item;
        }
        return sum;
    }

    // extenssion method for IEnumerable<T> that implement the function Product
    public static T Product<T>(this IEnumerable<T> items)
    {
        dynamic product = 1;
        foreach (var item in items)
        {
            product *= item;
        }
        return product;
    }

    // extenssion method for IEnumerable<T> that implement the function Min
    // The IComparable<T> interface defines the CompareTo(T) method
    // and this extension method can be applied to variable that are comparable
    public static T Min<T>(this IEnumerable<T> items) where T : IComparable<T>
    {
        T min = default(T);

        foreach (var item in items)
        {
            min = item;
            break;
        }

        foreach (var item in items)
        {
            if (item.CompareTo(min) < 0)
            {
                min = item;
            }
        }

        return min;
    }

    // extenssion method for IEnumerable<T> that implement the function Max
    // The IComparable<T> interface defines the CompareTo(T) method
    // and this extension method can be applied to variable that are comparable
    public static T Max<T>(this IEnumerable<T> items) where T : IComparable<T>
    {
        T max = default(T);

        foreach (var item in items)
        {
            max = item;
            break;
        }

        foreach (var item in items)
        {
            if (item.CompareTo(max) > 0)
            {
                max = item;
            }
        }

        return max;
    }
}

