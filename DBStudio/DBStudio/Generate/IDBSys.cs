using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DBStudio.Generate
{
    /// <summary>
    /// Работи с целевата база
    /// </summary>
    public interface IDBSys
    {
        /// <summary>
        /// Списък на таблиците
        /// </summary>
        List<string> GetTables();

        /// <summary>
        /// Списък на колонките в таблицата
        /// </summary>
        List<DBTableColumn> GetTableColumns(string tableName);

        /// <summary>
        /// Дава типа на визиялизация
        /// </summary>
        VisualComponent GetVisualComponent(string dataType);

        void FillTable(DataTable table, string columns, string tableName);
    }
}
