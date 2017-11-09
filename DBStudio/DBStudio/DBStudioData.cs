using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBStudio.Generate;

namespace DBStudio
{
    public class DBStudioData
    {
        /// <summary>
        /// Директория на припожението
        /// </summary>
        public string ApplicationPath = "";

        /// <summary>
        /// Системна информация за база
        /// </summary>
        public IDBSys DBSys = null;

        /// <summary>
        /// базата с настройки
        /// </summary>
        public IDBConfig DBConfig = null;

        public int DBSysID = 0;
    }
}
