/*
 Task 04.
 Write a method that adds a new product in the products table in 
 the Northwind database. Use a parameterized SQL command.
*/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class InsertInDBByParameterizedSQL
{
    // server name for SQL Server Express is ".\\SQLEXPRESS")
    private static string serverName = "."; // server name for MS SQL Server 2012
    private static SqlConnection dbConnection = new SqlConnection("Server=" + serverName +
            "; Database=NORTHWND; Integrated Security=true");

    static void Main()
    {
        int insertedProjectId = InsertProduct("New Product", true);

        Console.WriteLine("The Id of inserted product is: {0}", insertedProjectId);
    }

    /// <summary>
    /// Adds only NOT NULL columns in the Products table
    /// </summary>
    /// <param name="name">ProductName</param>
    /// <param name="discontinued">Discontinued</param>
    /// <returns>The Id of the inserted product</returns>
    private static int InsertProduct(string name, bool discontinued)
    {
        dbConnection.Open();

        SqlCommand cmdInsertProduct = new SqlCommand(
            "INSERT INTO Products(ProductName, Discontinued) " +
            "VALUES (@name, @discontinued)", dbConnection);
        cmdInsertProduct.Parameters.AddWithValue("@name", name);
        cmdInsertProduct.Parameters.AddWithValue("@discontinued", discontinued);
        
        cmdInsertProduct.ExecuteNonQuery();

        SqlCommand cmdSelectIdentity =
            new SqlCommand("SELECT @@Identity", dbConnection);
        int insertedRecordId =
            (int)(decimal)cmdSelectIdentity.ExecuteScalar();
        
        return insertedRecordId;
    }
}

