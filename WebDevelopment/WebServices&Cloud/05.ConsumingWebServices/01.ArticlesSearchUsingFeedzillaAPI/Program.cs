/*
 Task
 -------- 
 Write a console application, which searches for news articles by 
 given a query string and a count of articles to retrieve. 
 The application should ask the user for input and print the 
 Titles and URLs of the articles.For news articles search use 
 the Feedzilla API and use one of WebClient, HttpWebRequest or 
 HttpClient.
 
 Additional info
 -----------------
 
 1. You can find details about the Feedzilla API at https://code.google.com/p/feedzilla-api/wiki/RestApi
 
 2. Sample JSON Result for all articles methods (see also https://code.google.com/p/feedzilla-api/wiki/RestApi#Articles_Methods):
 {
     "articles":[
        {
           "url":"http://proxy.feedzilla.com/r/35423",
           "title":"Feedzilla: News edition has changed! Please read more!",
           "summary":"Please read the article when possible, we are likely to get used to it!",
           "publish_date":"Thu, 01 Jul 2010 14:14:38 +0000",
           "author":"Feedzilla Team",
           "source":"CNN"
        },
     ],
     "syndication_url":"http://feeds.feedzilla.com/en_us/news/business.rss"-
 } 
 
 3. Example for article method to return given number of articles ("count=10") that match a specified query (q=Michael).
 - Json format: "http://api.feedzilla.com/v1/articles/search.json?q=Michael&count=10"
 
 4. See all Feedzilla API article methods at https://code.google.com/p/feedzilla-api/wiki/RestApi#Articles_Methods 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace ArticlesSearchUsingFeedzillaAPI
{
    class Program
    {
        /// <summary>
        /// Returns given number of the most recent articles that match a specified query.
        /// </summary>
        /// <param name="httpClient">HttpClient</param>
        /// <param name="queryString">Specifies the query</param>
        /// <param name="articlesCountToShow">Specifies the number of articles to retrieve. 
        /// May not be greater than 100. (Note the the number of articles returned may be smaller than the requested count). 
        /// Default is 20.</param>         
        static async void GetGivenNumberOfArticlesByQuery(HttpClient httpClient, string queryString, int articlesCountToShow)
        {
            // Base URI: http://api.feedzilla.com/
            // Example for article method to return given number of articles ("count=10") that match a specified query (q=Michael). 
            // Json format: "http://api.feedzilla.com/v1/articles/search.json?q=Michael&count=10" 

            var response = await httpClient.GetAsync(string.Format("v1/articles/search.json?q={0}&count={1}", queryString, articlesCountToShow));
            var articlesFound = response.Content.ReadAsStringAsync().Result;
            ArticlesCollection articles = JsonConvert.DeserializeObject<ArticlesCollection>(articlesFound);

            PrintArticles(articles);
        }

        private static void PrintArticles(ArticlesCollection articles)
        {
            Console.WriteLine("Search results:");
            Console.WriteLine();

            foreach (var article in articles.Articles)
            {
                Console.WriteLine("Article Title: {0} ", article.Title);
                Console.WriteLine("Url: {0}", article.Url);

                // Uncomment the code below to print additional information about the news articles
                //Console.WriteLine("Publish Date: {0}", article.Publish_Date);
                //Console.WriteLine("Source: {0}", article.Source);
                //Console.WriteLine("Source Url: {0}", article.Source_Url);
                
                Console.WriteLine();
            }
        }

        static void Main()
        {
            //Note: To use HttpClient the project has to be targeting .NET 4.5 and needs an added reference to System.Net.Http 4.0
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://api.feedzilla.com/");       
          
            Console.WriteLine("Enter the query string (example: Michael): ");
            string queryString = Console.ReadLine();

            Console.WriteLine("Enter number of articles to retrieve: ");
            int articlesCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Please wait ...");
            Console.WriteLine();

            GetGivenNumberOfArticlesByQuery(httpClient, queryString, articlesCount);
            // simulates a slow request
            System.Threading.Thread.Sleep(10000);
            //end of slowing code
        }
    }
}