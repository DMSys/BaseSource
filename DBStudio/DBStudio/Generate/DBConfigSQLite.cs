using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DMSys.Data.SQLiteClient;
using DMSys.Utility;

namespace DBStudio.Generate
{
    public class DBConfigSQLite : IDBConfig
    {
        private string _ConnectionString = "";

        public DBConfigSQLite(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public void FillConnections(DataTable dtConnections)
        {
            using (SqliteConnection connection = DBUtilsSQLite.OpenConnection(_ConnectionString))
            {
                FillConnections(dtConnections, connection);
            }
        }

        public void FillConnections(DataTable dtConnections, SqliteConnection connection)
        {
            string commandText =
                "SELECT cn.ID AS C_ID " +
                "     , cn.C_TYPE_ID " +
                "     , cn.C_NAME " +
                "     , cnt.T_NAME AS C_TYPE " +
                " FROM G_CONNECTIONS cn " +
                " LEFT JOIN G_CONNECTION_TYPE cnt " +
                "   ON cnt.ID = cn.C_TYPE_ID ";

            DBUtilsSQLite.Fill(dtConnections, commandText, connection);
        }

        public DataRow GetConnection(int DBSysID)
        {
            DataRow drConnection = null;
            using (SqliteConnection connection = DBUtilsSQLite.OpenConnection(_ConnectionString))
            {
                drConnection = GetConnection(DBSysID, connection);
            }
            return drConnection;
        }

        public DataRow GetConnection(int DBSysID, SqliteConnection connection)
        {
            string commandText =
                    "SELECT * " +
                    " FROM G_CONNECTIONS " +
                    " WHERE ID = " + DBSysID.ToString();
            DataRow drConnection = null;
            using (DataTable dtConnection = DBUtilsSQLite.Fill(commandText, connection))
            {
                if (dtConnection.Rows.Count > 0)
                {
                    drConnection = dtConnection.Rows[0];
                }
            }
            return drConnection;
        }

        public DataTable GetTables(int DBSysID)
        {
            DataTable dtTables = null;
            using (SqliteConnection connection = DBUtilsSQLite.OpenConnection(_ConnectionString))
            {
                dtTables = GetTables(DBSysID, connection);
            }
            return dtTables;
        }

        public DataTable GetTables(int DBSysID, SqliteConnection connection)
        {
            string commandText =
                "SELECT * " +
                " FROM G_TABLES " +
                " WHERE G_CONNECTION_ID = " + DBSysID.ToString();
            DataTable dtTables = DBUtilsSQLite.Fill(commandText, connection);
            return dtTables;
        }

        public DBTable GetTable(int tableID)
        {
            DBTable table = null;
            using (SqliteConnection connection = DBUtilsSQLite.OpenConnection(_ConnectionString))
            {
                table = GetTable(tableID, connection);
            }
            return table;
        }

        public DBTable GetTable(int tableID, SqliteConnection connection)
        {
            DBTable table = new DBTable();
            // Основни данни за таблицата
            string commandText =
                "SELECT * " +
                " FROM G_TABLES " +
                " WHERE ID = " + tableID.ToString();
            using (DataTable dtTable = DBUtilsSQLite.Fill(commandText, connection))
            {
                if (dtTable.Rows.Count == 0)
                { return table; }
                DataRow drTable = dtTable.Rows[0];
                table.Name = Utility.ToString(drTable["T_NAME"]);
                table.Caption = Utility.ToString(drTable["T_CAPTION"]);
            }
            // Колонките на таблицата
            commandText =
                "SELECT tc.* " +
                " FROM G_TABLE_COLUMNS tc " +
                " WHERE tc.G_TABLE_ID = " + tableID.ToString() +
                " ORDER BY tc.ORDER_NO ";
            using (DataTable dtColumns = DBUtilsSQLite.Fill(commandText, connection))
            {
                if (dtColumns.Rows.Count == 0)
                { return table; }
                foreach (DataRow drColumn in dtColumns.Rows)
                { 
                    DBTableColumn dbColumn = new DBTableColumn();
                    Int32.TryParse(drColumn["ID"].ToString(), out dbColumn.Id);
                    dbColumn.Name = drColumn["C_NAME"].ToString();
                    dbColumn.Caption = drColumn["C_CAPTION"].ToString();
                    dbColumn.DataType = drColumn["C_DATA_TYPE"].ToString();
                    int vComponent = 0;
                    Int32.TryParse(drColumn["VISUAL_COMPONENT_ID"].ToString(), out vComponent);
                    dbColumn.VComponent = (VisualComponent)vComponent;
                    Int32.TryParse(drColumn["ORDER_NO"].ToString(), out dbColumn.OrderNo);

                    table.Columns.Add(dbColumn);
                }
            }
            return table;
        }

        public bool SetTable(int DBSysID, DBTable dbTable)
        {
            bool result = false;
            using (SqliteConnection connection = DBUtilsSQLite.OpenConnection(_ConnectionString))
            {
                result = SetTable(DBSysID, 0, dbTable, connection);
            }
            return result;
        }

        public bool SetTable(int DBSysID, int tableID, DBTable dbTable)
        {
            bool result = false;
            using (SqliteConnection connection = DBUtilsSQLite.OpenConnection(_ConnectionString))
            {
                result = SetTable(DBSysID, tableID, dbTable, connection);
            }
            return result;
        }

        public bool SetTable(int DBSysID, int tableID, DBTable dbTable, SqliteConnection connection)
        {
            int gTableID = tableID;
            // Добавя нова таблица
            if (gTableID == 0)
            {
                string commandText =
                    "INSERT INTO G_TABLES " +
                    " (T_NAME, T_CAPTION, G_CONNECTION_ID ) " +
                    "VALUES (" + DBUtilsSQLite.ParameterString(dbTable.Name) +
                        ", " + DBUtilsSQLite.ParameterString(dbTable.Caption) +
                        ", " + DBUtilsSQLite.ParameterInt(DBSysID) + "); " +
                    // ID на добавената таблица
                    " SELECT MAX(ID) AS TABLE_ID FROM G_TABLES " +
                    " WHERE G_CONNECTION_ID = " + DBUtilsSQLite.ParameterInt(DBSysID);

                DataTable dtTables = DBUtilsSQLite.Fill(commandText, connection);
                if (dtTables.Rows.Count > 0)
                {
                    Int32.TryParse(dtTables.Rows[0]["TABLE_ID"].ToString(), out gTableID);
                }
                // Проблем с добавянето
                if (gTableID == 0)
                { return false; }
            }
            // Редакция на основните данни на таблица
            else
            {
                string commandText =
                    "UPDATE G_TABLES " +
                    "   SET T_NAME = " + DBUtilsSQLite.ParameterString(dbTable.Name) +
                    "     , T_CAPTION = " + DBUtilsSQLite.ParameterString(dbTable.Caption) +
                    " WHERE ID = " + DBUtilsSQLite.ParameterInt(gTableID);
                DBUtilsSQLite.ExecuteNonQuery(commandText, connection);
            }
            return SetTableColumns(gTableID, dbTable.Columns, connection);
        }

        public bool SetTableColumns(int tableID, List<DBTableColumn> columns, SqliteConnection connection)
        {
            int orderNo = 1;
            // Списък с валидните колони на таблицата
            List<int> validColumns = new List<int>();
            
            foreach (DBTableColumn column in columns)
            {
                // Нова колона
                if (column.Id == 0)
                {
                    string commandText =
                        "INSERT INTO G_TABLE_COLUMNS " +
                        " ( C_NAME, C_CAPTION, G_TABLE_ID, ORDER_NO, C_DATA_TYPE, VISUAL_COMPONENT_ID ) " +
                        " VALUES (" + DBUtilsSQLite.ParameterString(column.Name) +
                            ", " + DBUtilsSQLite.ParameterString(column.Caption) +
                            ", " + DBUtilsSQLite.ParameterInt(tableID) +
                            ", " + DBUtilsSQLite.ParameterInt(orderNo) +
                            ", " + DBUtilsSQLite.ParameterString(column.DataType) +
                            ", " + DBUtilsSQLite.ParameterInt((int)column.VComponent) + "); " +
                        // ID на добавената колона
                        " SELECT MAX(ID) AS COLUMN_ID FROM G_TABLE_COLUMNS " +
                        " WHERE G_TABLE_ID = " + DBUtilsSQLite.ParameterInt(tableID);

                    DataTable dtColumn = DBUtilsSQLite.Fill(commandText, connection);
                    int columnID = 0;
                    if (dtColumn.Rows.Count > 0)
                    {
                        Int32.TryParse(dtColumn.Rows[0]["COLUMN_ID"].ToString(), out columnID);
                    }
                    // Проблем с добавянето
                    if (columnID == 0)
                    { return false; }
                    // свалидни колони
                    validColumns.Add(columnID);
                }
                // Редакция на колона
                else
                {
                    string commandText =
                        "UPDATE G_TABLE_COLUMNS " +
                        "   SET C_NAME = " + DBUtilsSQLite.ParameterString(column.Name) +
                        "     , C_CAPTION = " + DBUtilsSQLite.ParameterString(column.Caption) +
                        "     , ORDER_NO = " + DBUtilsSQLite.ParameterInt(orderNo) +
                        "     , C_DATA_TYPE = " + DBUtilsSQLite.ParameterString(column.DataType) +
                        "     , VISUAL_COMPONENT_ID = " + DBUtilsSQLite.ParameterInt((int)column.VComponent) +
                        " WHERE ID = " + DBUtilsSQLite.ParameterInt(column.Id);
                    DBUtilsSQLite.ExecuteNonQuery(commandText, connection);
                    // свалидни колони
                    validColumns.Add(column.Id);
                }
                orderNo++;
            }
            // Изтрива невалидните колони
            string deleteCommandText =
                "DELETE FROM G_TABLE_COLUMNS " +
                " WHERE G_TABLE_ID = " + DBUtilsSQLite.ParameterInt(tableID) +
                "   AND ID NOT IN " + DBUtilsSQLite.ParameterList(validColumns);
            DBUtilsSQLite.ExecuteNonQuery(deleteCommandText, connection);

            return true;
        }

        public bool DeleteTable(int tableID)
        {
            bool result = true;
            using (SqliteConnection connection = DBUtilsSQLite.OpenConnection(_ConnectionString))
            {
                result = DeleteTable(tableID, connection);
            }
            return result;
        }

        public bool DeleteTable(int tableID, SqliteConnection connection)
        {
            bool result = true;
            // Изтрива колоните на таблицата
            string commandText =
                "DELETE FROM G_TABLE_COLUMNS " +
                " WHERE G_TABLE_ID = " + DBUtilsSQLite.ParameterInt(tableID);
            DBUtilsSQLite.ExecuteNonQuery(commandText, connection);
            // Изтрива таблицата
            commandText =
                "DELETE FROM G_TABLES " +
                " WHERE ID = " + DBUtilsSQLite.ParameterInt(tableID);
            DBUtilsSQLite.ExecuteNonQuery(commandText, connection);
            
            return result;
        }
    }
}
