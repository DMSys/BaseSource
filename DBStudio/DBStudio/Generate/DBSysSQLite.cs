using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBStudio.Generate
{
    public class DBSysSQLite : IDBSys
    {
        private string _ConnectionString = "";

        public DBSysSQLite(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public List<string> GetTables()
        {
            // SELECT * FROM sqlite_master  WHERE type = "table" 

            return new List<string>();
        }

        public void GetTableInfo()
        {
            // pragma table_info(ROOMS);
        }

        public List<DBTableColumn> GetTableColumns(string tableName)
        {
            return null;
        }

        public VisualComponent GetVisualComponent(string dataType)
        {
            switch (dataType)
            {
                default:
                    return VisualComponent.TextBox;
            }
        }

        public void FillTable(DataTable table, string columns, string tableName)
        { }
    }
}
