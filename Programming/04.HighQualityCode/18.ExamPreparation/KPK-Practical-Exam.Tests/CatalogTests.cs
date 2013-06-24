using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CatalogOfFreeContent.Tests
{
    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        public void TestMethodAddSingleItem()
        {
            Catalog catalog = new Catalog();

            ContentItem item = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            catalog.Add(item);
            
            Assert.AreEqual(1, catalog.Count);
        }

        [TestMethod]
        public void TestMethodAddAndFindItem()
        {
            Catalog catalog = new Catalog();

            ContentItem item = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            catalog.Add(item);

           var result = catalog.GetListContent("Intro C#", 1);
           Assert.AreEqual(result.Count(), 1);
           Assert.AreSame(result.First(), item);
        }

        [TestMethod]
        public void TestMethodAddDuplicateItem()
        {
            Catalog catalog = new Catalog();

            ContentItem item1 = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            catalog.Add(item1);
            catalog.Add(item1);

            ContentItem item2 = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            catalog.Add(item2);

            Assert.AreEqual(3, catalog.Count);
        }

        [TestMethod]
        public void TestMethodAddMultipleItems()
        {
            Catalog catalog = new Catalog();

            ContentItem book = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            catalog.Add(book);

            ContentItem movie1 = new ContentItem(ContentItemType.Movie,
                new string[] { "Java Movie", "James Gosling", "53265489", "http://www.introprogramming.info" });
            catalog.Add(movie1);

            ContentItem movie2 = new ContentItem(ContentItemType.Movie,
                new string[] { "Java Movie", "James Gosling", "53265489", "http://www.introprogramming.info" });
            catalog.Add(movie2);

            ContentItem song = new ContentItem(ContentItemType.Song,
                new string[] { "Java Song", "James Gosling", "2356489253", 
                    "http://www.javasong.com/mp3" });
            catalog.Add(song);

            Assert.AreEqual(4, catalog.Count);
        }

        [TestMethod]
        [Timeout(500)]
        public void TestMethodAdd10000Items()
        {
            Catalog catalog = new Catalog();
            for (int i = 0; i < 10000; i++)
            {
                ContentItem item = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#" + i, "S.Nakov", "12763892", "http://www.introprogramming.info" });
                catalog.Add(item);
            }            

            Assert.AreEqual(10000, catalog.Count);
        }

        [TestMethod]
        public void TestMethodGetListContentSingleItems()
        {
            Catalog catalog = new Catalog();

            ContentItem book = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info" });
            catalog.Add(book);

            ContentItem movie = new ContentItem(ContentItemType.Movie,
                new string[] { "Java Movie", "James Gosling", "53265489", 
                    "http://www.java.com" });
            catalog.Add(movie);

            ContentItem application = new ContentItem(ContentItemType.Application,
                new string[] { "Intro App", "John Salin", "23569842", 
                    "http://www.app.com" });
            catalog.Add(application);
            
            var result = catalog.GetListContent("Intro C#", 10);
            Assert.AreEqual(result.Count(), 1);
            Assert.AreSame(result.First(), book);
        }

        [TestMethod]
        public void TestMethodGetListContentMissingItem()
        {
            Catalog catalog = new Catalog();

            ContentItem book = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info" });
            catalog.Add(book);

            ContentItem movie = new ContentItem(ContentItemType.Movie,
                new string[] { "Java Movie", "James Gosling", "53265489", 
                    "http://www.java.com" });
            catalog.Add(movie);

            ContentItem application = new ContentItem(ContentItemType.Application,
                new string[] { "Intro App", "John Salin", "23569842", 
                    "http://www.app.com" });
            catalog.Add(application);

            var result = catalog.GetListContent("Missing Item", 10);
            Assert.AreEqual(result.Count(), 0);           
        }

        [TestMethod]
        public void TestMethodGetListContentTwoMatchingItems()
        {
            Catalog catalog = new Catalog();

            ContentItem book = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info" });
            catalog.Add(book);

            ContentItem application = new ContentItem(ContentItemType.Application,
                new string[] { "Intro App", "John Salin", "23569842", 
                    "http://www.app.com" });
            catalog.Add(application);

            ContentItem movie = new ContentItem(ContentItemType.Movie,
                new string[] { "Intro C#", "James Gosling", "53265489", 
                    "http://www.java.com" });
            catalog.Add(movie);

            var result = catalog.GetListContent("Intro C#", 10);
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void TestMethodGetListContentGetFirstOfManyMatching()
        {
            Catalog catalog = new Catalog();

            ContentItem book = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info" });
            catalog.Add(book);

            ContentItem application = new ContentItem(ContentItemType.Application,
                new string[] { "Intro App", "John Salin", "23569842", 
                    "http://www.app.com" });
            catalog.Add(application);

            ContentItem movie = new ContentItem(ContentItemType.Movie,
                new string[] { "Intro C#", "James Gosling", "53265489", 
                    "http://www.java.com" });
            catalog.Add(movie);

            var result = catalog.GetListContent("Intro C#", 1);
            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public void TestMethodGetListContentCheckOrder()
        {
            Catalog catalog = new Catalog();

            ContentItem book = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info" });
            catalog.Add(book);

            ContentItem application = new ContentItem(ContentItemType.Application,
                new string[] { "Intro C#", "Adam Salin", "23569842", 
                    "http://www.app.com" });
            catalog.Add(application);

            ContentItem movie = new ContentItem(ContentItemType.Movie,
                new string[] { "Intro C#", "James Gosling", "53265489", 
                    "http://www.java.com" });
            catalog.Add(movie);

            var result = catalog.GetListContent("Intro C#", 10);
            Assert.AreEqual(result.Count(), 3);

            string[] expected = new string[]
            {
                "Application: Intro C#; Adam Salin; 23569842; http://www.app.com",
                "Book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info",
                "Movie: Intro C#; James Gosling; 53265489; http://www.java.com"
            };

            string[] actual = new string[]
            {
                result.First().ToString(),
                result.Skip(1).First().ToString(),
                result.Skip(2).First().ToString()
            };
            
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodUpdateMissingItems()
        {
            Catalog catalog = new Catalog();

            ContentItem book = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info" });
            catalog.Add(book);

            ContentItem application = new ContentItem(ContentItemType.Application,
                new string[] { "Intro C#", "Adam Salin", "23569842", 
                    "http://www.app.com" });
            catalog.Add(application);

            ContentItem movie = new ContentItem(ContentItemType.Movie,
                new string[] { "Intro C#", "James Gosling", "53265489", 
                    "http://www.java.com" });
            catalog.Add(movie);

            int updatedCount = catalog.UpdateContent("missing", "new");
            
            Assert.AreEqual(0, updatedCount);
        }

        [TestMethod]
        public void TestMethodUpdateOneItem()
        {
            Catalog catalog = new Catalog();

            ContentItem book = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info" });
            catalog.Add(book);

            ContentItem application = new ContentItem(ContentItemType.Application,
                new string[] { "Intro C#", "Adam Salin", "23569842", 
                    "http://www.app.com" });
            catalog.Add(application);

            ContentItem movie = new ContentItem(ContentItemType.Movie,
                new string[] { "Intro C#", "James Gosling", "53265489", 
                    "http://www.java.com" });
            catalog.Add(movie);

            int updatedCount = catalog.UpdateContent("http://www.java.com", "http://new.com");
            Assert.AreEqual(1, updatedCount);

            updatedCount = catalog.UpdateContent("http://www.java.com", "http://new.com");
            Assert.AreEqual(0, updatedCount);

            updatedCount = catalog.UpdateContent("http://www.app.com", "http://new.com");
            Assert.AreEqual(1, updatedCount);

            updatedCount = catalog.UpdateContent("http://new.com", "http://alabala.com");
            Assert.AreEqual(2, updatedCount);
        }
    }
}
