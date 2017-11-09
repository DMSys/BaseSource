using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DBStudio.Generate
{
    /// <summary>
    /// Работа с база за настройки
    /// </summary>
    public interface IDBConfig
    {
        /// <summary>
        /// Списък на ДБ
        /// </summary>
        /// <param name="dtConnections"></param>
        void FillConnections(DataTable dtConnections);

        /// <summary>
        /// Дава информация за връзка с ДБ
        /// </summary>
        /// <param name="DBSysID"></param>
        /// <returns></returns>
        DataRow GetConnection(int DBSysID);

        /// <summary>
        /// Таблиците на ДБ
        /// </summary>
        /// <param name="DBSysID"></param>
        /// <returns></returns>
        DataTable GetTables(int DBSysID);

        /// <summary>
        /// Дава данните за избраната таблица
        /// </summary>
        /// <param name="tableID"></param>
        /// <returns></returns>
        DBTable GetTable(int tableID);

        /// <summary>
        /// Добавя нова таблица
        /// </summary>
        /// <param name="DBSysID"></param>
        /// <param name="dbTable"></param>
        /// <returns></returns>
        bool SetTable(int DBSysID, DBTable dbTable);

        /// <summary>
        /// Добавя нова или редактира избраната таблица
        /// </summary>
        /// <param name="DBSysID"></param>
        /// <param name="tableID"></param>
        /// <param name="dbTable"></param>
        /// <returns></returns>
        bool SetTable(int DBSysID, int tableID, DBTable dbTable);

        /// <summary>
        /// Изтрива таблица
        /// </summary>
        /// <param name="DBSysID"></param>
        /// <param name="tableID"></param>
        /// <returns></returns>
        bool DeleteTable(int tableID);
    }
}
