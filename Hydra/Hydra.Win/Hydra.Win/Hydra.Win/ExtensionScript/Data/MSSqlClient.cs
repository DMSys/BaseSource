using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Hydra.Win.ExtensionScript.Data
{
    public class MSSqlClient: ISqlClient
    {
        private SqlConnection _Connection = null;

        public MSSqlClient(string connectionString)
        {
            _Connection = new SqlConnection(connectionString);
        }
        public void Open()
        {
            _Connection.Open();
        }

        public string ExecuteReader(LinqQueryModel linqQuery)
        {
            return "";
        }
    }
}
