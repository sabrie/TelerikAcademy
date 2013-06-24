using System;


class ConsolePrinter
{
    // we name the method just "Print" as we may create other 
    // methods with the same name "Print" that has different signature
    // (takes different variable type as parameters - int, string ...)
    public void Print(bool value)
    {
        string boolToString = value.ToString();

        Console.WriteLine(boolToString);
    }
}
