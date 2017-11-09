using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DMSys.Data.SQLiteClient;

namespace DBStudio
{
    public static class DBUtilsSQLite
    {
        public static string ConnectionString(string uriFile, int version = 3)
        {
            return string.Format("Version={0},uri=file:{1}", version, uriFile);
        }

        /// <summary>
        /// Създава и попълва DataTable
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DataTable Fill(string commandText, SqliteConnection connection)
        {
            DataTable table = new DataTable();
            DBUtilsSQLite.Fill(table, commandText, connection);
            return table;
        }

        /// <summary>
        /// Попълва DataTable
        /// </summary>
        /// <param name="table"></param>
        /// <param name="commandText"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static int Fill(DataTable table, string commandText, SqliteConnection connection)
        {
            using (SqliteCommand command = new SqliteCommand())
            {
                command.Connection = connection;
                command.CommandText = commandText;
                using (SqliteDataAdapter dataAdapter = new SqliteDataAdapter(command))
                {
                    return dataAdapter.Fill(table);
                }
            }
        }

        public static int ExecuteNonQuery(string commandText, SqliteConnection connection)
        {
            using (SqliteCommand command = new SqliteCommand())
            {
                command.Connection = connection;
                command.CommandText = commandText;
                return command.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string commandText, SqliteConnection connection)
        {
            using (SqliteCommand command = new SqliteCommand())
            {
                command.Connection = connection;
                command.CommandText = commandText;
                return command.ExecuteScalar();
            }
        }

        /// <summary>
        /// Създава и отваря Connection към базата
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static SqliteConnection OpenConnection(string connectionString)
        {
            SqliteConnection connection = new SqliteConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            return connection;
        }

        public static string ParameterString(string value)
        {
            return "'" + value.Replace("'", "''") + "'";
        }

        public static string ParameterInt(int value)
        {
            return value.ToString();
        }

        public static string ParameterList(List<int> value)
        {
            StringBuilder result = new StringBuilder();
            
            for (int i = 0; i < value.Count; i++)
            {
                if (i == 0)
                { result.Append(value[i].ToString()); }
                else
                { result.Append(","+value[i].ToString()); }
            }
            return "(" + result.ToString() + ")";
        }
    }
}
