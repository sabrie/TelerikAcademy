/*
 Implement the data structure "hash table" in a class HashTable<K,T>. Keep the data 
 * in array of lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[]) with 
 * initial capacity of 16. When the hash table load runs over 75%, perform resizing 
 * to 2 times larger capacity. Implement the following methods and properties: 
 * Add(key, value), Find(key)-> value, Remove( key), Count, Clear(), this[], Keys. 
 * Try to make the hash table to support iterating over its elements with foreach.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class HashTableDemo
{
    static void Main()
    {
        HashTable<string, int> studentMarks = new HashTable<string, int>();
        
        // Test for Add(); method
        studentMarks.Add("Pesho", 6);
        studentMarks.Add("Gosho", 4);
        studentMarks.Add("Nakov", 6);
        studentMarks.Add("Niki", 5);
        studentMarks.Add("Doncho", 3);
        studentMarks.Add("Ivan", 2);
        // Test for ToString(); method
        Console.WriteLine(studentMarks);

        // Test for Count(); method
        Console.WriteLine("Number of Students: " + studentMarks.Count);
        Console.WriteLine();
       
        // Test for Remove(); method
        studentMarks.Remove("Ivan");
        Console.WriteLine("Ivan is removed");

        // Test for support of iterating over elements with foreach 
        // (IEnumerable<KeyValuePair<K, T>> implementation)
        foreach (var studentMark in studentMarks)
        {
            Console.WriteLine(studentMark.Key + " : " + 
                                studentMark.Value);
        }

        Console.WriteLine("Number of Students: " + studentMarks.Count);
        Console.WriteLine();

        // Test for Find(); method
        string nameToFind = "Nakov";
        Console.WriteLine("{0}'s mark is {1}", nameToFind, studentMarks.Find(nameToFind)); // 6

        // Test for indexer this[]
        Console.WriteLine("{0}'s position in the hash table is: {1}", nameToFind, studentMarks[nameToFind]);

        // Test for Clear(); method
        studentMarks.Clear();
        Console.WriteLine();
        Console.WriteLine("Cleared");
        Console.WriteLine("Number of Students: " + studentMarks.Count);     
    }
}

