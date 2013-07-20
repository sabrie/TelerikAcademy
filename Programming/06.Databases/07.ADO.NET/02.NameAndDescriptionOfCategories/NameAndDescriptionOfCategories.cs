/*
 * Task 02.
 * Write a program that retrieves the name and description of all 
 * categories in the Northwind DB.
 */

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NameAndDescriptionOfCategories
{
    static void Main(string[] args)
    {
        // server name for SQL Server Express is ".\\SQLEXPRESS")
        string serverName = "."; // server name for MS SQL Server 2012

        SqlConnection dbConnection = new SqlConnection("Server=" + serverName +
            "; Database=NORTHWND; Integrated Security=true");
        dbConnection.Open();

        using (dbConnection)
        {
            SqlCommand categoriesInfo = new SqlCommand(
              "SELECT CategoryName, Description FROM Categories", dbConnection);
            SqlDataReader reader = categoriesInfo.ExecuteReader();
            
            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];
                    Console.WriteLine("Category Name: {0}", categoryName);
                    Console.WriteLine("Description: {0}", description);
                    Console.WriteLine();
                }
            }
        }

        dbConnection.Close();
    }
}

