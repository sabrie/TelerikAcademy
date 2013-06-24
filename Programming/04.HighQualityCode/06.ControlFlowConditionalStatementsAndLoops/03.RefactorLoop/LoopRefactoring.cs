/*
 
 Refactor the following loop: 

 int i=0;
for (i = 0; i < 100;) 
{
   if (i % 10 == 0)
   {
   	Console.WriteLine(array[i]);
   	if ( array[i] == expectedValue ) 
   	{
   	   i = 666;
   	}
   	i++;
   }
   else
   {
        Console.WriteLine(array[i]);
   	i++;
   }
}
// More code here
if (i == 666)
{
    Console.WriteLine("Value Found");
}

*/

using System;
using System.Linq;

class LoopRefactoring
{
    static void Main()
    {
        int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};
        int expectedValue = 10;
        bool isValueFound = false;

        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);

            if (i % 10 == 0)
            {
                if (array[i] == expectedValue)
                {
                    isValueFound = true;
                    break;
                }
            }
        }

        if (isValueFound)
        {
            Console.WriteLine("Value {0} is found!", expectedValue);
        }     
    }
}
