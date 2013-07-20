/*
 Task 08.
 Write a program that reads a string from the console and finds 
 all products that contain this string. Ensure you handle correctly 
 characters like ', %, ", \ and _.

 */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FindProductContainingString
{
    static void Main()
    {
        // server name for SQL Server Express is ".\\SQLEXPRESS")
        string serverName = "."; // server name for MS SQL Server 2012

        SqlConnection dbConnection = new SqlConnection("Server=" + serverName +
            "; Database=NORTHWND; Integrated Security=true");
        dbConnection.Open();

        string searchString = Console.ReadLine().Replace("%", "[%]")
                                                .Replace("_", "[_]");


        SqlCommand command = new SqlCommand(@"
                        SELECT c.CategoryName, p.ProductName FROM Products p 
	                        JOIN Categories c ON c.CategoryID = p.CategoryID
                        WHERE p.ProductName LIKE @searchString
                        ORDER BY c.CategoryName
                     ", dbConnection);
        command.Parameters.AddWithValue("@searchString", "%" + searchString + "%");

        SqlDataReader reader = command.ExecuteReader();

        using (reader)
        {
            Console.WriteLine("All products in a category containing '{0}':", searchString);
            Console.WriteLine();
            while (reader.Read())
            {
                string categoryName = (string)reader["CategoryName"];
                string categoryDesc = (string)reader["ProductName"];

                Console.WriteLine("Cat name: {0} | Product name: {1}", categoryName.PadRight(15), categoryDesc);
            }
        }

        dbConnection.Close();
    }
}

