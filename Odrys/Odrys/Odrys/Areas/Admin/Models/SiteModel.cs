using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SQLite;

namespace Odrys.Areas.Admin.Models
{
    public class SiteContext : Odrys.Models.AppConfigContext
    {
        public SiteContext()
        { }

        public List<SiteModel> GetSites()
        {
            List<SiteModel> sites = new List<SiteModel>();
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                command.CommandText =
@"SELECT sst.ID
       , sst.SITE_TITLE
       , sst.VIEW_ID
       , sst.VIEW_THEME_ID 
       , CASE WHEN sst.IS_MAIN = 1 THEN mst.SITE_NAME ELSE sst.SITE_NAME||'.'||mst.SITE_NAME END AS SITE_NAME
FROM S_SITES sst 
LEFT JOIN S_SITES mst ON mst.IS_MAIN = 1
WHERE sst.ID > -1 ";
                using (SQLiteDataAdapter dAdapter = new SQLiteDataAdapter(command))
                {
                    using (DataTable dtSites = new DataTable())
                    {
                        dAdapter.Fill(dtSites);
                        foreach (DataRow dr in dtSites.Rows)
                        {
                            sites.Add(new SiteModel 
                            {
                                ID = Int32.Parse(dr["ID"].ToString()),
                                Title = dr["SITE_TITLE"].ToString(),
                                ViewID = dr["VIEW_ID"].ToString(),
                                ViewThemeID = dr["VIEW_THEME_ID"].ToString(),
                                Name = dr["SITE_NAME"].ToString()
                            });
                        }
                    }
                }
            }
            return sites;
        }

        public SiteModel GetSite(int siteID)
        {
            SiteModel site = new SiteModel();
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                command.CommandText =
@"SELECT sst.ID
       , sst.SITE_TITLE
       , sst.SITE_NAME
       , sst.VIEW_ID
       , sst.VIEW_THEME_ID 
FROM S_SITES sst 
WHERE sst.ID = " + ParameterInt(siteID);
                using (SQLiteDataReader dReader = command.ExecuteReader())
                {
                    if (dReader.HasRows && dReader.Read())
                    {
                        site.ID = Int32.Parse(dReader["ID"].ToString());
                        site.Title = dReader["SITE_TITLE"].ToString();
                        site.Name = dReader["SITE_NAME"].ToString();
                        site.ViewID = dReader["VIEW_ID"].ToString();
                        site.ViewThemeID = dReader["VIEW_THEME_ID"].ToString();
                    }
                }
            }
            return site;
        }

        /// <summary>
        /// Добавя нов сайт
        /// </summary>
        /// <param name="site"></param>
        public void AddSite(SiteModel site)
        {
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                command.CommandText =
@"INSERT INTO S_SITES
 (SITE_TITLE, SITE_NAME, VIEW_ID, VIEW_THEME_ID )
VALUES (" + ParameterString(site.Title) + 
", " + ParameterString(site.Name) + 
", " + ParameterString(site.ViewID) + 
", " + ParameterString(site.ViewThemeID) + ") ";
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Променя информацията на сайта
        /// </summary>
        /// <param name="site"></param>
        public void SetSite(SiteModel site)
        {
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                command.CommandText =
@"UPDATE S_SITES
     SET SITE_TITLE = " + ParameterString(site.Title) + @"
       , SITE_NAME = " + ParameterString(site.Name) + @"
       , VIEW_ID = " + ParameterString(site.ViewID) + @"
       , VIEW_THEME_ID = " + ParameterString(site.ViewThemeID) + @"
WHERE ID = " + ParameterInt(site.ID);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Име на сайт
        /// </summary>
        /// <param name="siteID"></param>
        /// <returns></returns>
        public string GetSiteName(int siteID)
        {
            string siteName = "";
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                command.CommandText =
@"SELECT CASE WHEN sst.IS_MAIN = 1 THEN mst.SITE_NAME ELSE sst.SITE_NAME||'.'||mst.SITE_NAME END AS SITE_NAME
FROM S_SITES sst 
LEFT JOIN S_SITES mst ON mst.IS_MAIN = 1
WHERE sst.ID = " + ParameterInt(siteID);
                using (SQLiteDataReader dReader = command.ExecuteReader())
                {
                    if (dReader.HasRows && dReader.Read())
                    {
                        siteName = dReader["SITE_NAME"].ToString();
                    }
                }
            }
            return siteName;
        }

        /// <summary>
        /// Взема ID на главния сайт
        /// </summary>
        /// <returns></returns>
        public int GetMainSiteID()
        {
            int siteID = 0;
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                command.CommandText =
@"SELECT st.ID
FROM S_SITES st
WHERE st.IS_MAIN = 1";
                using (SQLiteDataReader dReader = command.ExecuteReader())
                {
                    if (dReader.HasRows && dReader.Read())
                    {
                        siteID = Int32.Parse(dReader["ID"].ToString());
                    }
                }
            }
            return siteID;
        }
    }

    [Serializable]
    public class SiteModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Изглед")]
        public string ViewID { get; set; }

        [Required]
        [Display(Name = "Тема на изгледа")]
        public string ViewThemeID { get; set; }

        public bool IsMain { get; set; }

        public string MainName { get; set; }
    }
}