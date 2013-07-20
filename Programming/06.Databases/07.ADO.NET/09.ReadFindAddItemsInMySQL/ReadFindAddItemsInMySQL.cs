/*
 *Task 09.
 Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + MySQL 
 Workbench GUI administration tool . Create a MySQL database to store Books (title, author, publish date and ISBN). 
 Write methods for listing all books, finding a book by name and adding a book.

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;


class ReadFindAddItemsInMySQL
{
    // !!! Please, restore the database from Books.sql file which is in Solution folder
    
    // !!! Please change Pwd=root to your MyQSL Server password
    private static MySqlConnection dbConnection =
            new MySqlConnection("Server=localhost; Port=3306; Database=books; Uid=root; Pwd=root");

    static void Main()
    {
        dbConnection.Open();

        string allBooks = ListAllBooks();

        Console.WriteLine("All BOOKS");
        Console.WriteLine(allBooks);
        Console.WriteLine();

        string searchedTitle = "CSharp";
        string bookByTitle = FindBookByTitle(searchedTitle);
        Console.WriteLine("Book with title '{0}' found.", searchedTitle);
        Console.WriteLine(bookByTitle);

        var insertedBookId = InsertBook("Open Access", "Pesho", DateTime.Now, "123456");
        Console.WriteLine("Inserted book ID: {0}", insertedBookId);

        dbConnection.Close();
    }

    private static string ListAllBooks()
    {
        MySqlCommand cmdCount = new MySqlCommand(
                "SELECT * FROM books", dbConnection);

        var reader = cmdCount.ExecuteReader();

        StringBuilder result = new StringBuilder();
        using (reader)
        {
            while (reader.Read())
            {
                string title = (string)reader["Title"];
                string author = (string)reader["Author"];
                var date = (DateTime)reader["PublishDate"];
                string isbn = (string)reader["ISBN"];

                result.AppendLine(String.Format("Title: {0}, Author: {1}, Publish Year: {2:yyy}, ISBN: {3}", title, author, date, isbn));
            }
        }
        
        return result.ToString();
    }

    private static string FindBookByTitle(string title)
    {
        MySqlCommand cmdCount = new MySqlCommand(
                "SELECT Title, Author, PublishDate, ISBN FROM books " +
                "WHERE Title = @title", dbConnection);

        cmdCount.Parameters.AddWithValue("@title", title);
        
        MySqlDataReader reader = cmdCount.ExecuteReader();
         StringBuilder result = new StringBuilder();

        using (reader)
        {        
            while (reader.Read())
            {
                string title1 = (string)reader["Title"];
                string author = (string)reader["Author"];
                var publishDate = (DateTime)reader["PublishDate"];
                string isbn = (string)reader["ISBN"];

                result.AppendLine(String.Format("Title: {0}, Author: {1}, Publish Year: {2:yyy}, ISBN: {3}", title, author, publishDate, isbn));
            }
        }

        return result.ToString();
    }

    private static ulong InsertBook(string title, string author, DateTime publishDate, string isbn)
    {
        MySqlCommand cmdInsertBook = new MySqlCommand(
            "INSERT INTO books(Title, Author, PublishDate, ISBN) " +
            "VALUES (@title, @author, @publishDate, @isbn)", dbConnection);
        cmdInsertBook.Parameters.AddWithValue("@title", title);
        cmdInsertBook.Parameters.AddWithValue("@author", author);
        cmdInsertBook.Parameters.AddWithValue("@publishDate", publishDate);
        cmdInsertBook.Parameters.AddWithValue("@isbn", isbn);

        cmdInsertBook.ExecuteNonQuery();

        MySqlCommand cmdSelectIdentity =
            new MySqlCommand("SELECT @@Identity", dbConnection);
        var insertedRecordId =
            (ulong)cmdSelectIdentity.ExecuteScalar();

        return insertedRecordId;
    }
}