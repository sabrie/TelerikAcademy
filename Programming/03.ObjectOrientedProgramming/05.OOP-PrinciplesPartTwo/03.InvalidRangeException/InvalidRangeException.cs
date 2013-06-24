/* Define a class InvalidRangeException<T> that holds information about 
 * an error condition related to invalid range. It should 
 * hold error message and a range definition [start … end].
 */

using System;

class InvalidRangeException<T> : Exception
{
    // properties - range definition
    public T Start { get; private set; }
    public T End { get; private set; }

    // constructor - error message
    public InvalidRangeException(T start, T end)
        : base("Invalid range! Should be in the range " + start + " - " + end)
    {
        this.Start = start;
        this.End = end;
    }
}
