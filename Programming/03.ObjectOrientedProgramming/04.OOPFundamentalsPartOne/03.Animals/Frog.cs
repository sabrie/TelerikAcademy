using System;

class Frog : Animal
{
    // Frog inherits the Animal and all elements of Animal class

    public Frog(string name, int age, string sex)
        : base(name, age, sex) // we call the base (Animal) constructor to initialize the name, age and sex of the frog
    {
    }

    // we override the abstarct method from Animal class to specify the specific sound that 
    // the Frog produces 
    public override string ProduceSound()
    {
        return "I am a Frog: Quak";
    }
}
