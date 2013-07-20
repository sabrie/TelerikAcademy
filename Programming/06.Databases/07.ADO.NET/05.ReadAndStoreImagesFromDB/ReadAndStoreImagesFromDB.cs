/*
 Task 05.
 Write a program that retrieves the images for all categories in the 
 Northwind database and stores them as JPG files in the file system.

 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ReadAndStoreImagesFromDB
{
    // server name for SQL Server Express is ".\\SQLEXPRESS")
    private static string serverName = "."; // server name for MS SQL Server 2012
    private static SqlConnection dbConnection = new SqlConnection("Server=" + serverName +
            "; Database=NORTHWND; Integrated Security=true");

    private const string FILE_STORE_LOCATION = @"..\";
    private const string FILE_EXTENSION = @".gif";

    private static void WriteBinaryFile(byte[] fileContents, string fileLocation)
    {
        FileStream stream = File.OpenWrite(fileLocation);
        using (stream)
        {
            stream.Write(fileContents, 0, fileContents.Length);
        }
    }

    private static void ExtractImageFromDB()
    {
        dbConnection.Open();

        using (dbConnection)
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT PICTURE, CategoryID, CategoryName FROM Categories", dbConnection);

            SqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                byte[] image;
                int categoryId;
                string categoryName;
                while (reader.Read())
                {
                    image = (byte[])reader["Picture"];
                    categoryId = (int)reader["CategoryID"];
                    categoryName = (string)reader["CategoryName"];
                    WriteBinaryFile(image, FILE_STORE_LOCATION + categoryId + FILE_EXTENSION);
                    image = null;
                }
            }
        }
    }
    
    static void Main()
    {
        // Pictures are stored in the bin directory of the project
        // Show all in the Solution files if you do not see them
        ExtractImageFromDB();
    }
}

