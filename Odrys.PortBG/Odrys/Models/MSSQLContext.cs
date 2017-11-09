using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Odrys.Models
{
    public class MSSQLContext: IDisposable
    {
        private SqlConnection _SQLConnection = null;
        public SqlConnection SQLConnection
        {
            get
            { return _SQLConnection; }
        }

        public MSSQLContext()
        {
            System.Configuration.ConnectionStringSettings connectionSettings =
                System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MSSQLConnection"];

            _SQLConnection = new SqlConnection();
            _SQLConnection.ConnectionString = connectionSettings.ConnectionString;
            _SQLConnection.Open();
        }

        public void Dispose()
        {
            _SQLConnection.Close();
            _SQLConnection.Dispose();
            _SQLConnection = null;
        }

        public DataTable FillDataTable(SqlCommand command)
        {
            DataTable table = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(table);
            }
            return table;
        }
    }
}