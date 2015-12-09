// Author: Tigran Gasparian
// This sample is part Part One of the 'Getting Started with SQLite in C#' tutorial at http://www.blog.tigrangasparian.com/

using System;
using System.Data.SQLite;

namespace SQLiteSamples
{
    public class SqLiteEasy
    {
        // Holds our connection with the database
        SQLiteConnection _mDbConnection;

        // Creates an empty database file
        public void Connection(string filePath)
        {
            SQLiteConnection.CreateFile(filePath);
            // Creates a connection with our database file.
            _mDbConnection = new SQLiteConnection("Data Source="+filePath+";Version=3;");
            _mDbConnection.Open();
        }
        // Creates a table named 'highscores' with two columns: name (a string of max 20 characters) and score (an int)
        public void Query(string queryText)
        {
            var command = new SQLiteCommand(queryText, _mDbConnection);
            command.ExecuteNonQuery();
        }
        // Writes the highscores to the console sorted on score in descending order.
        public void Reader(string queryText)
        {
            //var command = new SQLiteCommand(queryText, _mDbConnection);
            //var reader = command.ExecuteReader();
           
            //while (reader.Read())
            //    Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
            //Console.ReadLine();
        }
    }
}
