using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{
    public class Program
    {
        // method to Print the array of Students and Workers
        static void Print(IEnumerable list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        static void Main()
        {
            List<Product> products = new List<Product>()
            {
                new Television(200, "20135", "Panasonic", 33, type: TelevisionType.Lcd),
                new Television(250, "3350", "Panasonic", 32, type: TelevisionType.Lcd),
                new Laptop(350, "5505", "Acer", 20, "Intel", 4, "Video", DisplayType.LCD),
                new Laptop(350, "4008", "Sony", 18, "Intel", 6, "Video", DisplayType.LCD)
            };

            Television panasonic5550 = new Television(200, "5550", "Panasonic", 33, type: TelevisionType.Lcd);
            products.Add(panasonic5550);

            Laptop hp5525 = new Laptop(400, "552", "HP", 24, "Intel", 8, "Video", DisplayType.LCD);
            products.Add(hp5525);

            Console.WriteLine();
            Console.WriteLine("TELEVISIONS ");

            // selects products of Type Television using LINQ
            var televisions =
                             from product in products
                             where product is Television
                             select product;

            Print(televisions);

            
            // Print(products.Where(television => television is Television).OrderBy(television => television.Price));

            

            // print the selected products of Type Television using the method Print in this class
           

            Console.WriteLine("LAPTOPS: ");

            // selects products of Type Laptop using LINQ
            var laptops =
                         from product in products
                         where product is Laptop
                         select product;

            foreach (var item in laptops)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //Testing events

            OnlineShop popayeShop = OnlineShop.Instance();

            

            popayeShop.OnEmpthyShop += PopayeShopOnEmpthyShop;

            // the same 
            // popayeShop.OnEmpthyShop += (a, b) => Console.WriteLine("");

            popayeShop.RemoveProduct(products[0]);
            
            
            Console.WriteLine("Testing the event witch fires when there are no products in the shop");
            popayeShop.RemoveProduct(products[1]);

            Console.WriteLine();
            // create list of workers
            List<Worker> workers = new List<Worker>()
            {
                new Worker("Pesho", 800),
                new Worker("Gosho2", 750),
                new Worker("Pesho3", 800),
                new Worker("Gosho5", 750),
                new Worker("Pesho6", 800),
                new Worker("Gosho7", 750),
                new Worker("Pesho8", 800),
                new Worker("Gosho9", 750),
                new Worker("Pesho10", 800),
                new Worker("Gosho11", 750),
                new Worker("Pesho112", 800),
                new Worker("Pesho3", 800),
                new Worker("Gosho44", 750),
                new Worker("Pesho7", 800),
                new Worker("Gosho8", 750),
                new Worker("Gosho9", 750),

            };

            //Print list of workers
            Console.WriteLine("Printing the list of workers");
            foreach (var item in workers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            List<Client> clients = new List<Client>()
            {
                new IndividualClient("Ivanov"),
                new IndividualClient("Peshev1"),
                new IndividualClient("Ivanov"),
                new IndividualClient("Ivanov"),
                new IndividualClient("Peshev"),
                new IndividualClient("Ivanov"),
                new IndividualClient("Peshev"),
                new IndividualClient("Ivanov"),
                new IndividualClient("Peshev"),
                new IndividualClient("Ivanov"),
                new IndividualClient("Peshev34"),
                new IndividualClient("Ivanov23"),
                new IndividualClient("Peshev3"),
                new IndividualClient("Ivanov34"),
                new IndividualClient("Peshev"),
                new IndividualClient("Ivanov45"),
                new IndividualClient("Peshev56"),
                new IndividualClient("Ivanov45"),
                new IndividualClient("Peshev45"),
                new IndividualClient("Ivanov"),
                new IndividualClient("Peshev56"),
                new IndividualClient("Peshev6"),
            };
            
            Console.WriteLine();
            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }
            Console.WriteLine();
            Console.WriteLine("Printing the Shop after adding a client, worker, product");
            popayeShop.AddClient(clients[0]);
            popayeShop.AddWorker(workers[0]);
            popayeShop.AddProduct(products[0]);
            Console.WriteLine(popayeShop);

            Console.WriteLine("Print the Second shop which has to be completly identical to the first shop ");
            OnlineShop secondShop = OnlineShop.Instance();
            Console.WriteLine(secondShop);

            Console.WriteLine("Testing the OnSold event:");
            popayeShop.OnlineShopSoldProducts.OnSoldProduct += OnSoldProduct;
            popayeShop.RemoveProduct(products[0]);

            Console.WriteLine();
            foreach (var item in popayeShop.OnlineShopSoldProducts.SoldProductsList)
            {
                Console.WriteLine(item);
            } 
        }

        static void OnSoldProduct(object sender, EventArgs e)
        {
            Console.WriteLine("Product was sold");
        }

        static void PopayeShopOnEmpthyShop(object sender, EventArgs e)
        {
            Console.WriteLine("The products are empty we need to add more products");
        }
    }
}