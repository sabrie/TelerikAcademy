using System;

public abstract class Cat : Animal
{
    // we have only constructor as Cat inherits the Animal class and all elements of Animal class

    // Cat class is an abstract class - we will extend this class by creating Tomcats and Kittens
    
    // constructor
    public Cat(string name, int age, string sex)
        : base(name, age, sex) // we call the base (Animal) constructor to initialize the name, age and sex of the cat
    {
    }
}
