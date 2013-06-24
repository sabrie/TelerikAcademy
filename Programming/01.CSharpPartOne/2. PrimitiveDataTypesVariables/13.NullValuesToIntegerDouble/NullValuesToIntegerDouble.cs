/* Create a program that assigns null values to an integer and to double variables. 
 * Try to print them on the console, try to add some values or the null literal 
 * to them and see the result.
 */
using System;

class NullValuesToIntegerDouble
{
    static void Main()
    {
        int? integerNull= null;
        double? doubleNull = null;
        
        // this prints null (nothing) on the Console
        Console.WriteLine(integerNull); 
        Console.WriteLine(doubleNull);

        // this prints null (nothing) on the Console
        Console.WriteLine(integerNull + 10); // null + value = null
        Console.WriteLine(10 + integerNull); // value + null = null
        
        // This prints the default value of integerNull variable -> 0
        Console.WriteLine(integerNull.GetValueOrDefault()); 

        integerNull = 10;
        Console.WriteLine(integerNull + doubleNull); // doubleNull = null -> value + null = null
        // This prints 10 - the value of integerNull
        Console.WriteLine(integerNull.GetValueOrDefault()); 
    }
}

