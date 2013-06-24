/* Write a program that, depending on the user's choice inputs int, 
 * double or string variable. If the variable is integer or double, 
 * increases it with 1. If the variable is string, appends "*" at its end. 
 * The program must show the value of that variable as a console output. 
 * Use switch statement.
 */
using System;

class ReadUsersChoiceAndPrint
{
    static void Main()
    {
        Console.WriteLine("Enter:");
        Console.WriteLine("1 for int variable \n2 for double or \n3 for string:");
        byte choice = byte.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Enter an int: ");
                int intInput = int.Parse(Console.ReadLine());
                Console.WriteLine("{0} + 1 = {1}", intInput, intInput + 1);
                break;
            case 2:
                Console.WriteLine("Enter a double: ");
                double doubleInput = double.Parse(Console.ReadLine());
                Console.WriteLine("{0} + 1 = {1}", doubleInput, doubleInput + 1);
                break;
            case 3:
                Console.WriteLine("Enter a string: ");
                string stringInput = Console.ReadLine();
                Console.WriteLine("{0} + * = {1}", stringInput, stringInput + "*");
                break;
            default:
                Console.WriteLine("Error! The value you have entered is not valid!");
                Console.WriteLine("Please enter 1 for integer, 2 for double and 3 for string!");
                break;
        }
    }
}

