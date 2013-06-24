using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Animal : ISound // inherits ISound Interface
{
    // properties
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Sex { get; private set; }

    // constructor
    public Animal(string name, int age, string sex)
    {
        this.Name = name;
        this.Age = age;
        this.Sex = sex;
    }

    // each animal produces some sound
    // it is abstract method that will be overriden so that each animal can produce its specific sound
    public abstract string ProduceSound();

    // calculate the average age of list of animals
    public static double CalculateAverage(List<Animal> animals)
    {
        return animals.Average(animal => animal.Age);
    }

    // override ToString(); in order to print the information about the Animal in the following format
    public override string ToString()
    {
        return String.Format("Name: {0}, Age: {1}, Sex: {2}", this.Name, this.Age, this.Sex);
    }
}
