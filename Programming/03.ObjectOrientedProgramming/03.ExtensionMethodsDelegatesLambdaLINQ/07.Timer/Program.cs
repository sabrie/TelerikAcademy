using System;

class Program
{
    static void Main()
    {
        // assign a lambda expression to an Action delegate instance named function
        // this lambda expression takes no arguments -  () =>
        Action function = () => Console.Write(DateTime.Now);
        
        // we add another lambda expression to Action delegate instance named function
        // this lambda expression also takes no arguments - () =>
        function += () => Console.Write("\r\b");

        // create an instance on Timer class using its constructor that takes two parameters
        Timer timer = new Timer(function, 1);
        // we access the Start method from the Timer class
        // the method Start(); says: "Execute the lambda expressions in the delegate instance named function
        // at each t seconds
        timer.Start();
    }
}
