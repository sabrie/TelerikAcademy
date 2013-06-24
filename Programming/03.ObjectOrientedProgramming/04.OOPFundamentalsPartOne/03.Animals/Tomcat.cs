using System;

class Tomcat : Cat
{
    // Tomcat inherits the Cat class and all elements of Cat class (Cat inherits the Animal Class)
    public Tomcat(string name, int age)
        : base(name, age, sex: "male") // we call the base (Cat) constructor to initialize the name, age of the tomcat, 
                                        //we set the sex as male only
    {
    }

    // we override the abstarct method from Animal class to specify the specific sound that 
    // the Tomcat produces
    public override string ProduceSound()
    {
        return "I am a Tomcat: Mrrrrr";
    }
}
