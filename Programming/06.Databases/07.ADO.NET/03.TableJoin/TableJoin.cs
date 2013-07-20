/*
 Task 03.
 Write a program that retrieves from the Northwind database all product 
 categories and the names of the products in each category. 
 Can you do this with a single SQL query (with table join)?
*/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TableJoin
{
    static void Main()
    {
        // server name for SQL Server Express is ".\\SQLEXPRESS")
        string serverName = "."; // server name for MS SQL Server 2012

        SqlConnection dbConnection = new SqlConnection("Server=" + serverName +
            "; Database=NORTHWND; Integrated Security=true");
        dbConnection.Open();

        using (dbConnection)
        {
            SqlCommand categoriesInfo = new SqlCommand(
              "SELECT c.CategoryName, p.ProductName " +
              "FROM Products p JOIN Categories c " +
              "ON p.CategoryID = c.CategoryID " +
              "GROUP BY c.CategoryName, p.ProductName", dbConnection);
            SqlDataReader reader = categoriesInfo.ExecuteReader();

            using (reader)
            {
                Console.WriteLine("Category Name - Product Name");
                Console.WriteLine(new string('-', 40));
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string description = (string)reader["ProductName"];
                    Console.WriteLine("{0} - {1}", categoryName, description);
                }
            }
        }        
    }
}

