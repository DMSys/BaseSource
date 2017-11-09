using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SQLite;

namespace Odrys.Models
{
    /// <summary>
    /// Базов клас за работа с AppConfig.sqlite
    /// </summary>
    public class AppConfigContext: IDisposable
    {
        private SQLiteConnection _SQLConnection = null;
        public SQLiteConnection SQLConnection
        {
            get
            { return _SQLConnection; }
        }

        public AppConfigContext()
        {
            string dataSource = HttpContext.Current.Server.MapPath("~/App_Data/AppConfig.sqlite");
            string connectionString = String.Format("Data Source={0};Version=3;", dataSource);

            _SQLConnection = new SQLiteConnection();
            _SQLConnection.ConnectionString = connectionString;
            _SQLConnection.Open();
        }

        public void Dispose()
        {
            _SQLConnection.Close();
            _SQLConnection.Dispose();
            _SQLConnection = null;
        }

        public string ParameterString(string value)
        {
            return "'" + value.Replace("'","''") + "'";
        }

        public string ParameterInt(int value)
        {
            return value.ToString();
        }

        public Int32 ParseInt(string value, int defaultValue = 0)
        {
            if (value == "")
            { return defaultValue; }
            else
            {
                Int32 res = 0;
                if (Int32.TryParse(value, out res))
                { return res; }
                else
                { return defaultValue; }
            }
        }

        public DataTable FillDataTable(SQLiteCommand command)
        {
            DataTable table = new DataTable();
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                adapter.Fill(table);
            }
            return table;
        }
    }
}