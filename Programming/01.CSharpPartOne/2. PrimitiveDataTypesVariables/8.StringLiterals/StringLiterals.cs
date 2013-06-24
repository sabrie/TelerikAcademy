/*Declare two string variables and assign them with following value:
 * <The "use" of quotations causes difficulties.> 
 * Do the above in two different ways: with and without using quoted strings.
 */
using System;

class StringLiterals
{
    static void Main()
    {
        string withoutQuotation = "The use of quotations causes difficulties.";
        string withQuotations1 = "The \"use\" of quotations causes difficulties.";
        string withQuotations2 = @"The ""use"" of quotations causes difficulties.";
        
        Console.WriteLine(withoutQuotation);
        Console.WriteLine(withQuotations1);
        Console.WriteLine(withQuotations2);
    }
}

