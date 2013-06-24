using System;

public class Dog : Animal
{
    // Dog inherits the Animal class and all elements of Animal class
    public Dog(string name, int age, string sex)
        : base(name, age, sex) // we call the base (Animal) constructor to initialize the name, age and sex of the dog
    {
    }

    // we override the abstarct method from Animal class to specify the specific sound that 
    // the Dog produces 
    public override string ProduceSound()
    {
        return "I am a Dog: Bau";
    }
}