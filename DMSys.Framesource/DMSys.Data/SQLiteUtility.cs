using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DMSys.Data.SQLiteClient;
using System.IO;

namespace DMSys.Data
{
    public class SQLiteUtility : IDisposable
    {
        #region Properties

        /// <summary>
        /// Файл на базата
        /// </summary>
        private string _DBFile = "";
        public string DBFile
        {
            get
            { return _DBFile; }
            set
            {
                _ConnectionString = string.Format("Version=3,uri=file:{0};", value);
                _DBFile = value; 
            }
        }

        /// <summary>
        /// ConnectionString на базата
        /// </summary>
        private string _ConnectionString = "";

        #endregion Properties

        public SQLiteUtility()
        { }

        public void Dispose()
        { }

        public SqliteConnection OpenConnection()
        {   /*
            if (!File.Exists(_DBFile))
            {
                throw new SqliteException("Файл '" + _DBFile + "' не е намерен.");
            }*/
            SqliteConnection connection = new SqliteConnection();
            connection.ConnectionString = _ConnectionString;
            connection.Open();

            return connection;
        }

        /// <summary>
        /// Зарежда таблицата с данни
        /// </summary>
        public int Fill(DataTable dataTable, SqliteCommand selectCommand)
        {
            int result = 0;
            using (SqliteDataAdapter dataAdapter = new SqliteDataAdapter(selectCommand))
            {
                result = dataAdapter.Fill(dataTable);
            }
            return result;
        }

        /// <summary>
        /// Зарежда таблицата с данни
        /// </summary>
        public int Fill(DataTable dataTable, string commandText)
        {
            int result = 0;
            using (SqliteConnection connection = OpenConnection())
            {
                using (SqliteCommand command = new SqliteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = commandText;
                    using (SqliteDataAdapter dataAdapter = new SqliteDataAdapter(command))
                    {
                        result = dataAdapter.Fill(dataTable);
                    }
                }
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Изпълнява SQL заявка
        /// </summary>
        public int ExecuteNonQuery(string commandText)
        {
            int result = 0;
            using (SqliteConnection connection = OpenConnection())
            {
                using (SqliteCommand command = new SqliteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = commandText;
                    result = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Изпълнява SQL заявка
        /// </summary>
        public int ExecuteNonQuery(string commandText, SqliteConnection connection, System.Data.Common.DbTransaction transaction = null)
        {
            int result = 0;
            using (SqliteCommand command = new SqliteCommand())
            {
                command.Connection = connection;
                command.Transaction = transaction;
                command.CommandText = commandText;
                result = command.ExecuteNonQuery();
            }
            return result;
        }

        /// <summary>
        /// Изпълнява SQL заявка
        /// </summary>
        public SqliteDataReader ExecuteReader(string commandText)
        {
            SqliteDataReader result = null;
            using (SqliteConnection connection = OpenConnection())
            {
                using (SqliteCommand command = new SqliteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = commandText;
                    result = command.ExecuteReader();
                }
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Изпълнява SQL заявка
        /// </summary>
        public SqliteDataReader ExecuteReader(string commandText, SqliteConnection connection, System.Data.Common.DbTransaction transaction = null)
        {
            SqliteDataReader result = null;
            using (SqliteCommand command = new SqliteCommand())
            {
                command.Connection = connection;
                command.Transaction = transaction;
                command.CommandText = commandText;
                result = command.ExecuteReader();
            }
            return result;
        }

        /// <summary>
        /// Изпълнява SQL заявка
        /// </summary>
        public object ExecuteScalar(string commandText)
        {
            object result = null;
            using (SqliteConnection connection = OpenConnection())
            {
                using (SqliteCommand command = new SqliteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = commandText;
                    result = command.ExecuteScalar();
                }
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Изпълнява SQL заявка
        /// </summary>
        public object ExecuteScalar(string commandText, SqliteConnection connection, System.Data.Common.DbTransaction transaction = null)
        {
            object result = null;
            using (SqliteCommand command = new SqliteCommand())
            {
                command.Connection = connection;
                command.Transaction = transaction;
                command.CommandText = commandText;
                using(SqliteDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.HasRows && dataReader.Read())
                    {
                        result = dataReader[0];
                    }
                    dataReader.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Изтрива данните от таблицата
        /// </summary>
        public void DeleteTable(string tableName)
        {
            string commandText = "DELETE FROM " + tableName;

            this.ExecuteNonQuery(commandText);
        }

        /// <summary>
        /// Нулира брояча
        /// </summary>
        public void ResetSequence(string tableName)
        {
            string commandText =
@"UPDATE sqlite_sequence
  SET seq = 0
  WHERE name = " + this.PrmtrString(tableName);

            this.ExecuteNonQuery(commandText);
        }

        #region SQLParameters

        public string SQLDateTime(DateTime value)
        {
            // return "'" + value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'";
            return "'" + value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
        }

        public string SQLInt(int value)
        {
            return value.ToString();
        }

        public string SQLInt(string value)
        {
            int intValue = 0;
            Int32.TryParse(value, out intValue);
            return intValue.ToString();
        }

        public string PrmtrString(string value)
        {
            return "'" + value.ToString() + "'";
        }

        public string PrmtrReal(decimal value)
        {
            return "'" + value.ToString().Replace(',', '.') + "'";
        }

        public string PrmtrReal(string value)
        {
            decimal dValue = 0;
            Decimal.TryParse(value, out dValue);
            return "'" + dValue.ToString().Replace(',', '.') + "'";
        }

        #endregion SQLParameters
    }
}
