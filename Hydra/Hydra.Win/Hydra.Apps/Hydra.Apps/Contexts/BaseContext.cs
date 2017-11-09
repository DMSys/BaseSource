using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Hydra.Apps.Contexts
{
    public class BaseContext: IDisposable
    {
        private string _DataSource = "";

        private SQLiteConnection _Connection = null;

        public BaseContext()
        {
            _DataSource = HttpContext.Current.Server.MapPath("~/App_Data/HydraApps.db");
        }

        public void Dispose()
        { }

        public SQLiteConnection OpenConnection()
        {
            if (_Connection == null)
            { _Connection = new SQLiteConnection(String.Format("Data Source={0}", _DataSource)); }

            _Connection.Open();
            return _Connection;
        }

        public int Fill(string commandText, DataTable dTable)
        {
            int tableRows = 0;
            using (SQLiteCommand command = new SQLiteCommand(_Connection))
            {
                command.CommandText = commandText;
                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command))
                {
                    tableRows = dataAdapter.Fill(dTable);
                }
            }
            return tableRows;
        }

        public DataTable Fill(string commandText)
        {
            DataTable dTable = new DataTable();
            using (SQLiteCommand command = new SQLiteCommand(_Connection))
            {
                command.CommandText = commandText;
                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command))
                {
                    dataAdapter.Fill(dTable);
                }
            }
            return dTable;
        }
    }
}