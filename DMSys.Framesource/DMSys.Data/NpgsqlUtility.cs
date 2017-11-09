using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Npgsql;
using System.IO;

namespace DMSys.Data
{
    public class NpgsqlUtility : IDisposable
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

        private NpgsqlConnection _Connection = null;

        #endregion Properties

        public NpgsqlUtility(string connectionString)
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

        #region SQLParameters

        public string SQLDateTime(DateTime value)
        {
            return "'" + value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'";
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

        public string SQLList(int[] value)
        {
            if (value == null)
            { return ""; }
            if (value.Length == 0)
            { return ""; }

            string strValue = "("+value[0].ToString();
            for (int i = 1; i < value.Length; i++)
            {
                strValue += "," + value[i].ToString();
            }
            return strValue + ")";
        }

        public string SQLString(string value)
        {
            return string.Format("'{0}'", value.Replace("'", "''"));
        }

        public string SQLDecimal(decimal value)
        {
            return String.Format("'{0}'", value.ToString().Replace(',', '.'));
        }

        #endregion SQLParameters

        #region Npgsql Methods

        public NpgsqlConnection OpenConnection()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = this._ConnectionString;
            connection.Open();
            return connection;
        }

        public bool TestConnection()
        {
            try
            {
                if (this._ConnectionString.Equals(""))
                { return false; }
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = this._ConnectionString;
                    connection.Open();
                    connection.Close();
                }
                return true;
            }
            catch
            { return false; }
        }

        public int Fill(DataTable dataTable, NpgsqlCommand selectCommand)
        {
            int result = 0;
            using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(selectCommand))
            {
                result = dataAdapter.Fill(dataTable);
            }
            return result;
        }

        public int Fill(DataTable dataTable, string commandText)
        {
            int result = 0;
            using (NpgsqlConnection connection = OpenConnection())
            {
                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = commandText;

                    using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command))
                    {
                        result = dataAdapter.Fill(dataTable);
                    }
                }
                connection.Close();
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
            using (NpgsqlConnection connection = OpenConnection())
            {
                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = commandText;
                    result = command.ExecuteScalar();
                }
                connection.Close();
            }
            return result;
        }

        public object ExecuteNonQuery(string commandText)
        {
            int result = 0;
            using (NpgsqlConnection connection = OpenConnection())
            {
                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = commandText;
                    result = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return result;
        }

        #endregion Npgsql Methods

        public void BackUp(string binDir, string backupDir, string host, int port
            , string dbname, string username, string password, bool visible)
        {
            if (!Directory.Exists(binDir))
            {
                throw new Exception("Не е намерена директория '" + binDir + "'");
            }
            if (!Directory.Exists(backupDir))
            {
                throw new Exception("Не е намерена директория '" + backupDir + "' за бекъп");
            }

            string batFile = Path.Combine(backupDir, "backup.bat");
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(batFile))
            {
                sw.WriteLine("@echo off");
                sw.WriteLine("SET PGPASSWORD=" + password);
                sw.WriteLine("echo on");
                
                string dumpFile = System.IO.Path.Combine(binDir, "pg_dump.exe");
                string backupFile = System.IO.Path.Combine(backupDir, dbname + "_" + DateTime.Now.ToString("yyyy.MM.dd_HHmmss") + ".backup");

                sw.WriteLine("\"" + dumpFile + "\" -i -h " + host + 
                    " -p " + port.ToString() +
                    " -U " + username + 
                    " -F c -b -v -f \"" + backupFile + "\" " + dbname);

                sw.WriteLine("del \"" + batFile + "\"");
                sw.Flush();
                sw.Close();
            }

            using (System.Diagnostics.Process processBackup = new System.Diagnostics.Process())
            {
                processBackup.StartInfo.FileName = batFile;
                processBackup.StartInfo.CreateNoWindow = true;
                if (visible)
                {
                    processBackup.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                }
                else
                {
                    processBackup.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                }
                //processBackup.StartInfo.Verb = "print";
                processBackup.Start();
            }
        }
    }
}
