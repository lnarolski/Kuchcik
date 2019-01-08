using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Kuchcik
{
    static class DatabaseControl
    {
        public static SQLiteConnection m_dbConnection;
        public static void ConnectDB()
        {
            if (!System.IO.File.Exists("db.db"))
            {
                SQLiteConnection.CreateFile("db.db");
                m_dbConnection = new SQLiteConnection("Data Source=db.db;Version=3;");
                m_dbConnection.Open();
                string sql = "CREATE TABLE recipes (id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "title TEXT NOT NULL," +
                    "description TEXT NOT NULL," +
                    "img TEXT," +
                    "time INTEGER NOT NULL," +
                    "difficulty_level INTEGER NOT NULL)";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "CREATE TABLE ingredients (id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "name TEXT NOT NULL," +
                    "unit TEXT NOT NULL)";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "CREATE TABLE my_ingredients (id INTEGER NOT NULL," +
                    "count REAL DEFAULT 0.0)";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
            else
            {
                if (m_dbConnection == null) {
                    m_dbConnection = new SQLiteConnection("Data Source=db.db;Version=3;");
                    m_dbConnection.DefaultTimeout = 5;
                    m_dbConnection.Open();
                }
            }
        }

        public static void DisonnectDB()
        {
            m_dbConnection.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            m_dbConnection = null;
        }
    }
}
