using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DBStudio
{
    public static class DBUtilsMSSQL
    {
        public static string ConnectionString(string dataSource, string initialCatalog
            , string securityInfo, string userID, string password)
        {
            string connectionString =
               "Data Source=" + dataSource +
               ";Initial Catalog=" + initialCatalog +
               ";Persist Security Info=" + securityInfo +
               ";User ID=" + userID +
               ";Password=" + password +
               ";Connect Timeout=5";

            return connectionString;
        }

        public static SqlConnection OpenConnection(string connectionString)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            return connection;
        }

        public static int Fill(DataTable table, string commandText, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = commandText;
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                {
                    return dataAdapter.Fill(table);
                }
            }
        }

        public static string ParameterString(string value)
        {
            return "'" + value.Replace("'", "''") + "'";
        }
    }
}
