 /* Write a program to read a large collection of products (name + price) 
 * and efficiently find the first 20 products in the price range [a…b]. 
 * Test for 500 000 products and 10 000 price searches.
 * Hint: you may use OrderedBag<T> and sub-ranges.*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

class ProductsInPriceRange
{
    static void Main()
    {
        StreamReader fileName = new StreamReader("../../products.txt");

        OrderedMultiDictionary<decimal, string> productsByPrice = new OrderedMultiDictionary<decimal, string>(true);

        using (fileName)
        {
            string line;

            while ((line = fileName.ReadLine()) != null)
            {
                var tokens = line.Split(';');
                decimal price = decimal.Parse(tokens[0]);
                string product = tokens[1];

                productsByPrice.Add(price, product);
            }
        }

        Console.WriteLine("Search products in price range: ");
        Console.Write("From price:");
        decimal fromPrice = decimal.Parse(Console.ReadLine());
        Console.Write("To price: ");
        decimal toPrice = decimal.Parse(Console.ReadLine());

        var productsInPriceRange = productsByPrice.Range(fromPrice, true, toPrice, true);

        Console.Write("Number of products to be printed: ");
        int numberOfProductsToPrint = int.Parse(Console.ReadLine());
        
        PrintGivenNumberOfProducts(numberOfProductsToPrint, productsInPriceRange);
    }

    private static void PrintGivenNumberOfProducts(int numberOfProductsToPrint, 
        OrderedMultiDictionary<decimal, string>.View productsInPriceRange)
    {
        if (numberOfProductsToPrint < productsInPriceRange.Count)
        {
            Console.WriteLine("There are no products or there are less " +
                "than {0} in the given price range.", numberOfProductsToPrint);
        }

        int counter = 0;
        foreach (var product in productsInPriceRange)
        {
            if (counter == numberOfProductsToPrint)
            {
                break;
            }
            
            Console.WriteLine(product.Key + " " + product.Value);
            counter++;
        }
    }
}
