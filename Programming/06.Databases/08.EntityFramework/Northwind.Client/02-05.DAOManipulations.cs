using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Data;

namespace Northwind.Client
{
    public class DAOManipulations
    {
        // Task 02. 
        // Create a DAO class with static methods which provide functionality
        // for inserting, modifying and deleting customers. Write a testing class.

        public static string InsertCustomer(string id, string companyName, string contactName = null, string contactTitle = null,
                                    string address = null, string city = null, string region = null, string postalCode = null,
                                    string country = null, string phoneNumber = null, string faxNumber = null)
        {
            Customer newCustomer = new Customer()
            {
                CustomerID = id,
                CompanyName = companyName,
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = address,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country,
                Phone = phoneNumber,
                Fax = faxNumber
            };

            NorthwindEntities context = new NorthwindEntities();

            // if the new customer does not exist in the Databases
            // we add it
            if (context.Customers.Find(id) == null)
            {
                context.Customers.Add(newCustomer);
                context.SaveChanges();

                return newCustomer.CustomerID;
            }

            return "The customer already exists in the Databases";
        }

        public static void ModifyCustomerNameById(string customerId, string newContactName)
        {
            NorthwindEntities context = new NorthwindEntities();

            Customer customer = GetCustomerById(context, customerId);
            customer.ContactName = newContactName;
            context.SaveChanges();
        }

        public static void DeleteCustomerById(string customerId)
        {
            NorthwindEntities context = new NorthwindEntities();
            Customer customer = GetCustomerById(context, customerId);
            context.Customers.Remove(customer);
            context.SaveChanges();
        }

        private static Customer GetCustomerById(NorthwindEntities context, string customerId)
        {
            Customer customer = context.Customers.FirstOrDefault(
                c => c.CustomerID == customerId);
            return customer;
        }


        // Task 03.
        // Write a method that finds all customers who have orders made 
        // in 1997 and shipped to Canada.

        public static IEnumerable<string> FindCustomersByOrder(int year, string shipCountry)
        {
            NorthwindEntities context = new NorthwindEntities();

            IList<string> customer =
            context.Orders
            .Where(o => o.OrderDate.Value.Year == year)
            .Where(o => o.ShipCountry == shipCountry)
            .Select(c => c.Customer.ContactName).Distinct().ToList();

            return customer;                
        }

        // Task 04.
        // Implement previous by using native SQL query and executing it
        // through the DbContext.

        public static IEnumerable<string> FindCustomersByOrderNativeSQL(int year, string shippedCountry)
        {
            NorthwindEntities context = new NorthwindEntities();

            string nativeSQLQuery =
                "SELECT DISTINCT c.ContactName as CustomerName " +
                "FROM Customers c JOIN Orders o " +
                "ON c.CustomerID = o.CustomerID " +
                "WHERE DATEPART(year, o.OrderDate) = {0} AND o.ShipCountry = {1} ";
            object[] parameters = { year, shippedCountry };

            var customer = context.Database.SqlQuery<string>(
              nativeSQLQuery, parameters);

            return customer;

        }

        // Task 05.
        // Write a method that finds all the sales by specified region 
        // and period (start / end dates).

        public static IEnumerable<Sales_by_Year_Result> FindSalesByRegionAndPeriod(string shipRegion, DateTime startYear, DateTime endYear)
        {
            NorthwindEntities context = new NorthwindEntities();

            var salesByRegionAndYear =
                from salesByYear in context.Sales_by_Year(startYear, endYear)
                join order in context.Orders
                .Where(o => o.ShipRegion == shipRegion)
                on salesByYear.OrderID equals order.OrderID
                select salesByYear;

            return salesByRegionAndYear;
        }
    }
}
