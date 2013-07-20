using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Data;
using System.Data.Entity.Infrastructure;

namespace Northwind.Client
{
    class Program
    {
        static void Main()
        {
            // Task 02. Examples
            // -----------------------
            string customerId =
                DAOManipulations.InsertCustomer(
                    "SVENA", "Telerik", "Svetlin Nakov", "Manager Training",
                    "bul. Al. Malinov 31", "Sofia", "Sofia", "1729", "Bulgaria",
                    "+359 881234567", "+359 2 856 25 65");
            Console.WriteLine("Task 02.");
            Console.WriteLine("Added a new customer with Id = {0}", customerId);

            Console.WriteLine();
            DAOManipulations.ModifyCustomerNameById("SVENA", "Sv. Nakov");
            Console.WriteLine("Customer name modified.");
            Console.WriteLine();

            DAOManipulations.DeleteCustomerById("SVENA");
            Console.WriteLine("Customer deleted.");
            Console.WriteLine();

            // Task 03. Examples
            // ----------------------
            int year = 1997;
            string shippedCountry = "Canada";

            var customersByOrder = DAOManipulations.FindCustomersByOrder(year, shippedCountry);

            Console.WriteLine("Task 03.");
            Console.WriteLine("Distinct names of customers with orders in {0} shipped to {1}", year, shippedCountry);
            Console.WriteLine("using LINQ");
            Console.WriteLine();
            foreach (var customer in customersByOrder)
            {
                Console.WriteLine("- " + customer);
            }

            Console.WriteLine();

            // Task 04. Examples
            // ----------------------
            IEnumerable<string> customersByOrderNativeSQL = DAOManipulations.FindCustomersByOrderNativeSQL(year, shippedCountry);

            Console.WriteLine("Task 04");
            Console.WriteLine("Distinct names of customers with orders in {0} shipped to {1}", year, shippedCountry);
            Console.WriteLine("using native SQL");
            Console.WriteLine();
            foreach (var customer in customersByOrderNativeSQL)
            {
                Console.WriteLine("- " + customer);
            }

            Console.WriteLine();


            // Task 05. Examples
            // ----------------------
            DateTime startDate = new DateTime(1996, 07, 11);
            DateTime endDate = new DateTime(1998, 07, 11);
            string region = "RJ";

            var salesByRegionAndPeriod =
                DAOManipulations.FindSalesByRegionAndPeriod(region, startDate, endDate);

            Console.WriteLine("Task 05.");
            Console.WriteLine("Sales ID's in the period {0} - {1}", startDate, endDate);
            Console.WriteLine("in the region {0}", region);
            Console.WriteLine();
            foreach (var sale in salesByRegionAndPeriod)
            {
                Console.WriteLine(sale.OrderID);
            }
        }
    }
}
