using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Linq;

namespace WPFWorkTracker
{
    public class SQLiteDataAccess
    {
        public static List<TaskModel> LoadTasks()
        {
            //using scope makes sure the connection closes no matter what
            using(IDbConnection conn = new SQLiteConnection("Data Source=./TaskDB.db"))
            {
                IEnumerable<TaskModel> output = conn.Query<TaskModel>("SELECT * FROM Task", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveTask(TaskModel task)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=./TaskDB.db"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand("INSERT INTO Task (Title, Completed, Description) VALUES (@Title, @Completed, @Description)", conn);

                command.Parameters.AddWithValue("@Title", task.GetTitle());
                command.Parameters.AddWithValue("@Completed", task.IsCompleted());
                command.Parameters.AddWithValue("@Description", task.GetDescription());

                command.ExecuteNonQuery();
            }
        }

        public static void DelTask(TaskModel task)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=./TaskDB.db"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand("DELETE FROM Task WHERE Title=@Title", conn);

                command.Parameters.AddWithValue("@Title", task.GetTitle());

                command.ExecuteNonQuery();
            }
        }
    }
}
