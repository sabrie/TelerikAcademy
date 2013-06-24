// Using delegates write a class Timer that has can execute certain method at each t seconds.

using System;
using System.Threading;

public class Timer
{
    // delegate
    public Action Function { get; set; }
    // property
    public int Timeout { get; set; }

    // constructor which takes two parameters
    public Timer(Action function, int seconds)
    {
        this.Function = function;
        this.Timeout = seconds * 1000;
    }

    // method that starts executing another method at certain time
    public void Start()
    {
        while (true)
        {
            this.Function();

            Thread.Sleep(this.Timeout);
        }
    }
}

