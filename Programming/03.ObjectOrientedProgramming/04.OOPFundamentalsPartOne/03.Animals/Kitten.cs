using System;

class Kitten : Cat
{
    // Kitten inherits the Cat class and all elements of Cat class (Cat inherits the Animal Class)
    public Kitten(string name, int age)
        : base(name, age, sex: "female") // we call the base (Cat) constructor to initialize the name, age of the kitten, 
                                         //we set the sex as female only
    {
    }

    // we override the abstarct method from Animal class to specify the specific sound that 
    // the Kitten produces 
    public override string ProduceSound()
    {
        return "I am a Kitten: Miauuuuu";
    }
}
