using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DBStudio.Generate
{
    public class DBSysMSSQL : IDBSys
    {
        private string _ConnectionString = "";

        public DBSysMSSQL(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        /// <summary>
        /// Списък на таблиците
        /// </summary>
        public List<string> GetTables()
        {
            List<string> listTables = null;
            using (SqlConnection sqlConnection = DBUtilsMSSQL.OpenConnection(_ConnectionString))
            {
                listTables = GetTables(sqlConnection);
                sqlConnection.Close();
            }
            return listTables;
        }

        /// <summary>
        /// Списък на таблиците
        /// </summary>
        public List<string> GetTables(SqlConnection sqlConnection)
        {
            string commandText =
                "SELECT '['+tb.TABLE_SCHEMA+'].['+tb.TABLE_NAME+']' AS TABLE_ID " +
                "     , tb.TABLE_NAME " +
                " FROM INFORMATION_SCHEMA.TABLES tb  " +
                " WHERE tb.TABLE_TYPE = 'BASE TABLE' " +
                " ORDER BY tb.TABLE_SCHEMA, tb.TABLE_NAME ";

            List<string> listTables = new List<string>();
            using (DataTable dtTables = new DataTable())
            {
                DBUtilsMSSQL.Fill(dtTables, commandText, sqlConnection);
                foreach (DataRow drTable in dtTables.Rows)
                {
                    listTables.Add(drTable["TABLE_NAME"].ToString());
                }
            }
            return listTables;
        }

        /// <summary>
        /// Списък на колонките в таблицата
        /// </summary>
        public List<DBTableColumn> GetTableColumns(string tableName)
        {
            List<DBTableColumn> listTables = null;
            using (SqlConnection sqlConnection = DBUtilsMSSQL.OpenConnection(_ConnectionString))
            {
                listTables = GetTableColumns(sqlConnection, tableName);
                sqlConnection.Close();
            }
            return listTables;
        }

        /// <summary>
        /// Списък на колонките в таблицата
        /// </summary>
        public List<DBTableColumn> GetTableColumns(SqlConnection sqlConnection, string tableName)
        {
            string commandText =
                "SELECT cl.COLUMN_NAME "+
                "     , cl.DATA_TYPE "+
                " FROM INFORMATION_SCHEMA.COLUMNS cl "+
                " WHERE cl.TABLE_NAME = " +DBUtilsMSSQL.ParameterString(tableName)+
                " ORDER BY cl.ORDINAL_POSITION ";

            List<DBTableColumn> listTableColumns = new List<DBTableColumn>();
            using (DataTable dtTables = new DataTable())
            {
                DBUtilsMSSQL.Fill(dtTables, commandText, sqlConnection);
                foreach (DataRow drTable in dtTables.Rows)
                {
                    DBTableColumn col = new DBTableColumn();
                    col.Name = drTable["COLUMN_NAME"].ToString();
                    col.DataType = drTable["DATA_TYPE"].ToString().ToLower();
                    col.Caption = col.Name;
                    col.VComponent = this.GetVisualComponent(col.DataType);
                    listTableColumns.Add(col);
                }
            }
            return listTableColumns;
        }

        /// <summary>
        /// Дава типа на визиялизация
        /// </summary>
        public VisualComponent GetVisualComponent(string dataType)
        {
            switch (dataType)
            {
                case "tinyint":
                case "smallint":
                case "int":
                    return VisualComponent.Integer;
                case "datetime":
                    return VisualComponent.DateTime;
                default:
                    return VisualComponent.TextBox;
            }
        }

        public void FillTable(DataTable table, string columns, string tableName)
        {
            if (columns == "")
            { return; }
            if (tableName == "")
            { return; }

            string commandText =
                "SELECT " + columns +
                " FROM " + tableName;
            using (SqlConnection sqlConnection = DBUtilsMSSQL.OpenConnection(_ConnectionString))
            {
                DBUtilsMSSQL.Fill(table, commandText, sqlConnection);
                sqlConnection.Close();
            }
        }
    }
}
