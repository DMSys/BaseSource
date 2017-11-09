using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FileSynchronizer
{
    public static class xDAL
    {
        public static DataTable IgnoreItemType()
        {
            DataTable dtType = new DataTable();
            dtType.Columns.Add("TYPE_ID", typeof(System.Int32));
            dtType.Columns.Add("TYPE_NAME");
            dtType.Rows.Add(DMSys.Systems.SynchronizerFile.SynchItemType.File, "File");
            dtType.Rows.Add(DMSys.Systems.SynchronizerFile.SynchItemType.Directorie, "Directorie");
            return dtType;

            
        }
    }
}
