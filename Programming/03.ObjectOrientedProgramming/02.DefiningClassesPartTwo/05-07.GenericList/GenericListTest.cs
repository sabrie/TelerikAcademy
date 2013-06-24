using System;
using System.Collections.Generic;
using System.IO;

class GenericListTest
{
    static void Main(string[] args)
    {
        // create an instance of the GenericList class;
        GenericList<int> list = new GenericList<int>();

        // add elements to the List using the method AddElement in GenericList class
        list.AddElement(1);
        list.AddElement(5);
        list.AddElement(10);
        list.AddElement(15);
        list.AddElement(20);

        //print the List - usint the overriden ToString() in GenericList class
        Console.WriteLine("List elements are: ");
        Console.WriteLine(list);

        // access the element by given index using the method AccessElementAtPosition in GenericList class
        int index = 2;
        Console.Write("Element at index {0} is: ", index);
        Console.WriteLine(list.AccessElementAtPosition(index));
        Console.WriteLine();

        // insert an element at given position
        index = 0;
        int num = 1000000000;
        list[index] = num;
        Console.WriteLine("Assign {0} to index {1}", num, index);
        Console.WriteLine(list);

        // add new element at given index
        //all elements after the given index are replaced to the right
        // the length of the array is increased by one
        index = 2;
        num = 22222;
        list.AddElementAtIndex(num, index);
        Console.WriteLine("Add new element with value {0} at index {1}", num, index);
        Console.WriteLine("Note that all element after the given index are replaced to the right \nand the length of the array is increased by one.");
        Console.WriteLine(list);

        // remove the element at given index
        // all elements after the given index are replaced to the left
        // the length of the array is decreased by one
        index = 3;
        Console.WriteLine("Remove the element at index {0}", index);
        Console.WriteLine("Note that all element after the given index are replaced to the left \nand the length of the array is decreased by one.");
        list.RemoveElementAtIndex(3);
        Console.WriteLine(list);

        // find element by its value using the method IndexOfElement in GenericList
        int elementValue = 5;
        Console.Write("The index of element with value {0} is: ", elementValue);
        Console.WriteLine(list.IndexOfElement(elementValue));

        // gets the Minimal element of the list using the GetMin() method in the GenericList class
        Console.Write("Minimal element of the array is: ");
        Console.WriteLine(list.GetMin());
        // gets the Maximal element of the list using the GetMax() method in the GenericList class
        Console.Write("Maximal element of the array is: ");
        Console.WriteLine(list.GetMax());

        // clear the list and assing the default value of T type to each index
        Console.WriteLine("Clear the list");
        list.ClearAllElements();
        Console.WriteLine(list);
    }
}
