using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hydra.Win.ExtensionScript.Data;
using Hydra.Win.Layouts;

namespace Hydra.Win.ExtensionScript
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class DataScript
    {
        /// <summary>
        /// Списък на връзките с базата
        /// </summary>
        private List<ISqlClient> _Connections = new List<ISqlClient>();

        /// <summary>
        /// Opens a connection to the database
        /// </summary>
        /// <param name="jsonConnection"></param>
        /// <returns></returns>
        public string OpenConnection(string jsonConnection)
        {
            LinqConnectionModel linqConnection = (LinqConnectionModel)Helper.JsonDeserialize(jsonConnection, typeof(LinqConnectionModel));

            ISqlClient sqlClient = null;
            switch (linqConnection.database)
            { 
                case "sqlite":
                    sqlClient = new SQLiteClient(linqConnection.connection);
                    break;
                case "mssql":
                    sqlClient = new MSSqlClient(linqConnection.connection);
                    break;
            }
            sqlClient.Open();
            _Connections.Add(sqlClient);
            return (_Connections.Count - 1).ToString();
        }

        /// <summary>
        /// Closes the connection to the database
        /// </summary>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public string CloseConnection(string connectionId = "")
        {
            return "";
        }

        /// <summary>
        /// Execute JSON command to the database
        /// </summary>
        /// <param name="jsonCommand"></param>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public string ExecuteQuery(string jsonCommand = "", int connectionId = 0)
        {
            ISqlClient sqlClient = _Connections[connectionId];

            LinqQueryModel linqQuery = (LinqQueryModel)Helper.JsonDeserialize(jsonCommand, typeof(LinqQueryModel));
            string result = "";
            switch (linqQuery.command)
            {
                case "select":
                    string dataResult = sqlClient.ExecuteReader(linqQuery);
                    result = "{\"data\":" + dataResult + "}";
                    break;
                default:
                    result = "error";
                    break;
            }
            return result;
        }
    }
}
