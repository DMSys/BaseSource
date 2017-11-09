using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DMSys.Data
{
    interface ISQLUtility
    {
        #region SQL Parameters

        string SQLDateTime(DateTime value);

        string SQLString(string value);

        string SQLStringMD5(string value);

        string SQLInt(int value);

        string SQLInt(string value);

        string SQLList(int[] value);

        #endregion SQL Parameters

        #region SQL Methods

        int Fill(DataTable dataTable, string commandText);

        DataTable FillDataTable(string commandText);

        object ExecuteScalar(string commandText);

        object ExecuteNonQuery(string commandText);

        #endregion SQL Methods
    }
}
