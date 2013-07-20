/*
 Task 06.
 Create an Excel file with 2 columns: name and score.
 Write a program that reads your MS Excel file through the OLE DB 
 data provider and displays the name and score row by row.
 * 
 Task 07.
 Implement appending new rows to the Excel file.

 */

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class AppendRowsAndReadFromExcel
{
    private const string CONN_STRING =
        @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\ExcelTable.xlsx;" +
            @"Extended Properties=""Excel 12.0 Xml;HDR=YES""";

    static void Main()
    {
        OleDbConnection oleDbConn = new OleDbConnection(CONN_STRING);

        // Task 06. Create a table with 2 columns - Name and Score
        // !!! Comment next line after your have started the project
        // because the program will create the Excel table every time you start
        CreateExcelTable("Name", 20.0, oleDbConn);

        // Task 07. Append new rows to the Excel file 
        AppendRowToExcel("Svetlin Nakov", 20, oleDbConn);
        AppendRowToExcel("Doncho Minkov", 22, oleDbConn);
        AppendRowToExcel("Nikolay Kostov", 24, oleDbConn);
        AppendRowToExcel("Georgi Georgiev", 20, oleDbConn);

        // Task 06. Read the Excel file through the OLE DB data provider and display the name and score row by row
        string tableRowsdata = PrintRowsDataFromExcel(oleDbConn);
        Console.WriteLine("Name - Score");
        Console.WriteLine(tableRowsdata);
    }

    static void CreateExcelTable(string name, double score, OleDbConnection oleDbConn)
    {
        oleDbConn.Open();

        OleDbCommand myCommand =
            new OleDbCommand(
                "CREATE TABLE [Scores]([Name] nvarchar(255),[Score] real)", oleDbConn);

        myCommand.Parameters.AddWithValue("@Name", name);
        myCommand.Parameters.AddWithValue("@Score", score);
        myCommand.ExecuteNonQuery();
        oleDbConn.Close();
    }

    static void AppendRowToExcel(string name, double score, OleDbConnection oleDbConn)
    {
        oleDbConn.Open();

        OleDbCommand myCommand =
            new OleDbCommand(
                "INSERT INTO [Scores] (Name,Score) VALUES (@name,@score)", oleDbConn);

        myCommand.Parameters.AddWithValue("@Name", name);
        myCommand.Parameters.AddWithValue("@Score", score);
        myCommand.ExecuteNonQuery();
        oleDbConn.Close();
    }

    static string PrintRowsDataFromExcel(OleDbConnection oleDbConn)
    {
        StringBuilder result = new StringBuilder();

        oleDbConn.Open();

        OleDbCommand cmd = new OleDbCommand("Select * From [Scores]", oleDbConn);
        OleDbDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string tableRowName = reader.GetString(0);
            string tableRowScore = reader.GetString(1);
            result.AppendLine(String.Format("{0} - {1}", tableRowName, tableRowScore));
        }

        reader.Close();

        return result.ToString();
    }   
}

