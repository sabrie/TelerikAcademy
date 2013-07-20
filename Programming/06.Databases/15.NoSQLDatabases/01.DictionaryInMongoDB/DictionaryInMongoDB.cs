/*
 * Task 01.
Write a simple "Dictionary" application in C# or JavaScript to perform the following in MongoDB:
    Add a dictionary entry (word + translation)
    List all words and their translations
    Find the translation of given word
The UI of the application is up to you (it could be Web-based, GUI or console-based).
You may use MongoDB-as-a-Service@ MongoLab.
You may install the "Official MongoDB C# Driver" from NuGet 
or download it from its publisher: http://docs.mongodb.org/ecosystem/drivers/csharp/
*/

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DictionaryInMongoDB
{
    static void Main()
    {
        // You may download MongoDB from the following link http://www.mongodb.org/downloads
        // 1. Create a folder named 'mongodb' in C:\ to store the MongoDB 'bin' folder
        // 2. Create in C:\ an empty folder named 'data' 
        // 3. Create in C:\data an empty folder named 'db'
        // 4. Start the MongoDB server from mongod.exe file -> C:\mongodb\bin\mongod.exe
        // 5. Then start the VS project to see the results on the Console

        var mongoClient = new MongoClient("mongodb://localhost/");
        var mongoServer = mongoClient.GetServer();
        var dictionary = mongoServer.GetDatabase("DictionaryDB");

        var enBgDictionary = dictionary.GetCollection("EnBg");

        // -----------------------------------------------------------
        // Adds words and their translations to our EnBg dictionary
        // -----------------------------------------------------------
        enBgDictionary.Insert(new BsonDocument { { "word", "tree" }, { "translation", "дърво" } });
        enBgDictionary.Insert(new BsonDocument { { "word", "apple" }, { "translation", "ябълка" } });
        enBgDictionary.Insert(new BsonDocument { { "word", "cherry" }, { "translation", "череша" } });
        enBgDictionary.Insert(new BsonDocument { { "word", "strawberry" }, { "translation", "ягода" } });

        // ----------------------------------------------------------
        // List all words and their translations
        // ----------------------------------------------------------
        var allWordsAndTranslations = enBgDictionary.FindAll();

        Console.WriteLine("Word -> Translation");
        Console.WriteLine(new string('-', 30));
        foreach (var item in allWordsAndTranslations)
        {
            string word = (string)item["word"];
            string translation = (string)item["translation"];
            Console.WriteLine("{0} -> {1}", word, translation);
        }
        Console.WriteLine();

        // ----------------------------------------------------------
        // Find the translation of given word
        // ----------------------------------------------------------
        string searchedWord = "tree";
        QueryDocument query = new QueryDocument("word", searchedWord);
        var wordTranslations = enBgDictionary.Find(query);

        Console.Write("Translation of '{0}' is ", searchedWord);
        foreach (var item in wordTranslations)
        {
            Console.WriteLine(item["translation"]);
        }

        // Removes all the data from EnBg Collection
        // enBgDictionary.RemoveAll();
    }
}

