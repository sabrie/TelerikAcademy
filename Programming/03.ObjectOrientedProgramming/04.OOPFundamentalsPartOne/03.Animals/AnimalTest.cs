using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


class AnimalTest
{
    // method to Print the array of Animals
    static void Print(IEnumerable list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        // create a list of animals - each have name, age and sex
        // we create instances of each animal class by using their constructors
        List<Animal> animals = new List<Animal>()
            {
                new Dog("Sharo", 2, "female"),
                new Tomcat("Karaman", 5),
                new Kitten("Kitti", 8),
                new Frog("Frogi", 2, "female")
            };

        Console.WriteLine("List of animals we created:");
        // print the information about the animals using the Print ,ethod from this class
        Print(animals);

        Console.WriteLine("Sounds each animal produces:");
        // print the Sound that each animal produces
        Print(animals.Select(animal => animal.ProduceSound()));

        Console.Write("Average age of animals: ");
        // print the average age of animals in the animals list
        // use the static method in the Animal class - CalculateAverage(List<Animal> animals) 
        Console.WriteLine(Animal.CalculateAverage(animals));

        //// print the names of animals and join by selector ", "
        //Console.WriteLine(String.Join(", ", animals.Select(animal => animal.Name)));
        Console.WriteLine();
    }
}
