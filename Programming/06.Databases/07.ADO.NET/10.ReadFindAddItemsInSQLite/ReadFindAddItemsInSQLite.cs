/*
 Task 10.
 Create a MySQL database to store Books (title, author, publish date and ISBN). 
 Write methods for listing all books, finding a book by name and adding a book.
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


class Program
{
    // Data source (SQLite file) is in the Solution folder (Books.db)
    private static SQLiteConnection dbConnection =
            new SQLiteConnection(@"Data Source=..\..\..\Books.db");

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

        InsertBook("Open Access", "Pesho", DateTime.Now, "123456");

        dbConnection.Close();
    }

    private static string ListAllBooks()
    {
        SQLiteCommand cmdCount = new SQLiteCommand(
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
        SQLiteCommand cmdCount = new SQLiteCommand(
                "SELECT Title, Author, PublishDate, ISBN FROM books " +
                "WHERE Title = @title", dbConnection);

        cmdCount.Parameters.AddWithValue("@title", title);

        SQLiteDataReader reader = cmdCount.ExecuteReader();
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

    private static void InsertBook(string title, string author, DateTime publishDate, string isbn)
    {
        SQLiteCommand cmdInsertBook = new SQLiteCommand(
            "INSERT INTO books(Title, Author, PublishDate, ISBN) " +
            "VALUES (@title, @author, @publishDate, @isbn)", dbConnection);
        cmdInsertBook.Parameters.AddWithValue("@title", title);
        cmdInsertBook.Parameters.AddWithValue("@author", author);
        cmdInsertBook.Parameters.AddWithValue("@publishDate", publishDate);
        cmdInsertBook.Parameters.AddWithValue("@isbn", isbn);

        cmdInsertBook.ExecuteNonQuery();
    }
}

