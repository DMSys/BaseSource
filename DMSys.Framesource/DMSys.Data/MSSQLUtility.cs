using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DMSys.Data
{
    public class MSSQLUtility : IDisposable, ISQLUtility
    {
       #region Properties

        private string _ConnectionString = "";
        public string ConnectionString
        {
            get
            { return _ConnectionString; }
            set
            { _ConnectionString = value; }
        }

        private SqlConnection _Connection = null;

        #endregion Properties

        public MSSQLUtility(string connectionString)
        {
            _ConnectionString = connectionString;
            _Connection = this.OpenConnection();
        }

        public void Dispose()
        {
            if (_Connection != null)
            {
                _Connection.Close();
                _Connection.Dispose();
                _Connection = null;
            }
        }

        private SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = this.ConnectionString;
            connection.Open();

            return connection;
        }

        #region SQL Parameters

        public string SQLDateTime(DateTime value)
        {
            return String.Format("'{0}'", value.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        public string SQLString(string value)
        {
            return (value == null) ? "NULL" : String.Format("N'{0}'", value);
        }

        public string SQLStringMD5(string value)
        {
            return (value == null) ? "''" : String.Format("'{0}'", CalculateMD5Hash(value));
        }

        public string SQLInt(int value)
        {
            return value.ToString();
        }

        public string SQLInt(int? value)
        {
            return ((value == null) ? "NULL" : value.ToString());
        }

        public string SQLInt(bool value)
        {
            return (value ? "1" : "0");
        }

        public string SQLDecimal(decimal value)
        {
            return String.Format("'{0}'", value.ToString().Replace(',', '.'));
        }

        public string SQLInt(string value)
        {
            int intValue = 0;
            Int32.TryParse(value, out intValue);
            return intValue.ToString();
        }

        public string SQLList(int[] value)
        {
            if (value == null)
            { return ""; }
            if (value.Length == 0)
            { return ""; }

            string strValue = "(" + value[0].ToString();
            for (int i = 1; i < value.Length; i++)
            {
                strValue += "," + value[i].ToString();
            }
            return strValue + ")";
        }

        #endregion SQL Parameters

        #region SQL Methods

        public int Fill(DataTable dataTable, SqlCommand selectCommand)
        {
            int result = 0;
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand))
            {
                result = dataAdapter.Fill(dataTable);
            }
            return result;
        }

        public int Fill(DataTable dataTable, string commandText)
        {
            int result = 0;
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = _Connection;
                command.CommandText = commandText;

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                {
                    result = dataAdapter.Fill(dataTable);
                }
            }
            return result;
        }

        public DataTable FillDataTable(string commandText)
        {
            DataTable dataTable = new DataTable();
            Fill(dataTable, commandText);
            return dataTable;
        }

        public object ExecuteScalar(string commandText)
        {
            object result = null;
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = _Connection;
                command.CommandText = commandText;
                result = command.ExecuteScalar();
            }
            return result;
        }

        public object ExecuteNonQuery(string commandText)
        {
            int result = 0;
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = _Connection;
                command.CommandText = commandText;
                result = command.ExecuteNonQuery();
            }
            return result;
        }

        #endregion SQL Methods

        private string CalculateMD5Hash(string value)
        {
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(value);
            string encodedValue = "";
            using (System.Security.Cryptography.MD5 cryptMD5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] hash = cryptMD5.ComputeHash(inputBytes);

                // string representation (similar to UNIX format)
                encodedValue = BitConverter.ToString(hash)
                    // without dashes
                   .Replace("-", string.Empty)
                    // make uppercase
                   .ToUpper();
            }
            return encodedValue;
        }
    }
}
