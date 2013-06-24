/* Declare two string variables and assign them with “Hello” and “World”. Declare  
 * an object variable and assign it with the concatenation of the first two variables
 * (mind adding an interval). Declare a third string variable and initialize it with
 * the value of the object variable (you should perform type casting).
 */
using System;

class StringVarConcatenationCasting
{
    static void Main()
    {
        string hello = "Hello";
        string world = "World";
        object helloWorld = hello + " " + world;
        string typeCasting = (string)helloWorld;

        Console.WriteLine(hello);
        Console.WriteLine(world);
        Console.WriteLine(helloWorld);
        Console.WriteLine(typeCasting);
    }
}

