using System;
using System.Linq;

class HumanTest
{
    static void Main()
    {
        Human human = new Human();

        human.GetGenderById(9312051224);

        Console.WriteLine(human);        
    }
}
