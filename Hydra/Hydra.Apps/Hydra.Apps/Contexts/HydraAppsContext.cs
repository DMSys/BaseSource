using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hydra.Apps.Models;
using System.Data;
using System.Data.SQLite;
using Hydra.Apps.Helpers;

namespace Hydra.Apps.Contexts
{
    public class HydraAppsContext: BaseContext
    {
        public HydraAppsModel GetApplications()
        {
            HydraAppsModel model = new HydraAppsModel();
            using (SQLiteConnection connection = this.OpenConnection())
            { 
                string commandText =
@"SELECT ap.uid
       , ap.app_name
       , ap.app_url
       , ap.description
       , dv.id AS developer_id
       , dv.dev_name AS developer_name
  FROM application ap 
  LEFT JOIN developer dv ON dv.id = ap.developer_id 
  ORDER BY ap.app_name ";
                using (DataTable dtApplications = this.Fill(commandText))
                {
                    foreach (DataRow app in dtApplications.Rows)
                    {
                        model.Add(new HydraAppModel()
                        {
                            UId = TryParse.ToGuid(app["uid"]),
                            Name = TryParse.ToString(app["app_name"]),
                            DeveloperId = TryParse.ToInt32(app["developer_id"]),
                            DeveloperName = TryParse.ToString(app["developer_name"]),
                            AppUrl = TryParse.ToString(app["app_url"]),
                            Description = TryParse.ToString(app["description"])
                        });
                    }
                }
            }
            return model;
        }
    }
}