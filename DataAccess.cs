using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlliteApp
{
    class DataAccess
    {
        public static void InitializeDatabase()
        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=Customers.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS MyTable (cus_Id INTEGER PRIMARY KEY, " +
                    "cus_Name VARCHAR(50) ," +
                    "cus_Tell VARCHAR(10) NULL);";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
            }
        }

        public static void AddData(string inputName, string inputTell)
        {
            using (SqliteConnection db = 
                new SqliteConnection($"Filename=Customers.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO MyTable VALUES (NULL, @Name,@Tell);";
                insertCommand.Parameters.AddWithValue("@Name", inputName);
                insertCommand.Parameters.AddWithValue("@Tell", inputTell);

                insertCommand.ExecuteReader();

                db.Close();

            }
        }

        public static List<String> GetData()
        {
            List<String> data = new List<string>();

            using (SqliteConnection db = new SqliteConnection($"Filename=Customers.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT cus_Name,cus_Tell from MyTable", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    data.Add(query.GetString(0));
                    data.Add(query.GetString(1));

                }
                db.Close();

            }
            return data;
        }
    }

}
