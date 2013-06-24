using System;

class Program
{
    static void Main(string[] args)
    {
        // person whose age is specified
        Person firstPerson = new Person("Pesho", 25);

        Console.WriteLine(firstPerson);

        // person whose age is not specified
        Person secondPerson = new Person("Sasho");

        Console.WriteLine(secondPerson);
    }
}

