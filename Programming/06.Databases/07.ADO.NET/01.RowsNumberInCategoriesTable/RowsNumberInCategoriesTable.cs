/*
 Task 01.
 Write a program that retrieves from the Northwind sample database in
 MS SQL Server the number of  rows in the Categories table.
 */

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class RowsNumberInCategoriesTable
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
            SqlCommand cmdCount = new SqlCommand(
                "SELECT COUNT(*) FROM Categories", dbConnection);
            int rowsCount = (int)cmdCount.ExecuteScalar();
            
            Console.WriteLine("Rows count in the Categories table: {0} ", rowsCount);
            Console.WriteLine();
        }
    }
}

