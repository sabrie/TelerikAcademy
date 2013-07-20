/*
 * Task 02.
 Write a simple "Dictionary" application in C# or JavaScript to perform the following in Redis:
    Add a dictionary entry (word + translation)
    List all words and their translations
    Find the translation of given word
You may hold the "word + meaning pairs" in a hash (see http://redis.io/commands#hash)
See the HSET, HKEYS and HGET commands
You may use a local Redis instance or register for a free "Redis To Go" account at https://redistogo.com.
You may download the client libraries for your favorite programming language from http://redis.io/clients 
or use the "ServiceStack.Redis" C# client from the NuGet package manager.

 */

using Sider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DictionaryInRedis
{
    static void Main(string[] args)
    {
        // You may download Redis for Windows from https://github.com/MSOpenTech/redis/tree/2.6/bin/release
        // Start the Redis server by double-click on redis-server.exe
        // Start the Redis client by double-click on the redis-cli.exe
        // Then start the VS project to see the result on the Console

        using (var redisClient = new RedisClient())
        {
            // -----------------------------------------------------------
            // Adds words and their translations to our EnBg dictionary
            // ----------------------------------------------------------
            redisClient.HSet("EnBg", "tree", "дърво");
            redisClient.HSet("EnBg", "apple", "ябълка");
            redisClient.HSet("EnBg", "strawberry", "ягода");
            redisClient.HSet("EnBg", "blueberry", "боровинка");
            redisClient.HSet("EnBg", "peach", "праскова");
            redisClient.HSet("EnBg", "cherry", "череша");
            redisClient.HSet("EnBg", "grape", "грозде");

            // ---------------------------------------
            // List all words and their translations
            // ----------------------------------------
            string[] allWords = redisClient.HKeys("EnBg");

            Console.WriteLine("Word -> Translation");
            Console.WriteLine(new string('-', 30));
            for (int i = 0; i < allWords.Length; i++)
            {
                Console.WriteLine(allWords[i] + " -> " + redisClient.HGet("EnBg", allWords[i]));
            }
            Console.WriteLine();

            // ----------------------------------------
            // Find the translation of given word
            // ----------------------------------------
            Console.WriteLine("Find translation of a word");
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Translation of 'tree' is {0}", redisClient.HGet("EnBg", "tree"));
            Console.WriteLine("Translation of 'apple' is {0}", redisClient.HGet("EnBg", "apple"));
            Console.WriteLine("Translation of 'cherry' is {0}", redisClient.HGet("EnBg", "cherry"));
        }
    }
}

