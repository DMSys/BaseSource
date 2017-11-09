using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SQLite;

namespace Odrys.Models
{
    public class PageContext : Odrys.Models.AppConfigContext
    {
        public PageContext()
        { }

        public PageModel GetPage(int siteID, string pageName = "")
        {
            PageModel page = null;
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                // Ако няма стр. се зарежда началната
                if (pageName == "")
                {
                    command.CommandText =
@"SELECT pg.ID
       , pg.PAGE_TITLE 
       , pg.PAGE_VALUE
       , st.VIEW_ID
       , st.VIEW_THEME_ID
       , st.SITE_TITLE
       , pg.PAGE_TYPE_ID
FROM S_SITES st
INNER JOIN S_PAGES pg
   ON pg.ID = st.S_PAGE_ID
WHERE st.ID = " + ParameterInt(siteID);
                }
                else
                {
                    command.CommandText =
@"SELECT pg.ID
       , pg.PAGE_TITLE 
       , pg.PAGE_VALUE
       , st.VIEW_ID
       , st.VIEW_THEME_ID
       , st.SITE_TITLE
       , pg.PAGE_TYPE_ID
FROM S_SITES st
INNER JOIN S_PAGES pg
   ON pg.SITE_ID = st.ID 
  AND pg.PAGE_NAME = " + ParameterString(pageName) + @"
WHERE st.ID = " + ParameterInt(siteID);
                }
                using (SQLiteDataReader dReader = command.ExecuteReader())
                {
                    if (dReader.HasRows && dReader.Read())
                    {
                        page = new PageModel
                        {
                            ID = Int32.Parse(dReader["ID"].ToString()),
                            Title = dReader["PAGE_TITLE"].ToString(),
                            Value = dReader["PAGE_VALUE"].ToString(),
                            SiteTitle = dReader["SITE_TITLE"].ToString(),
                            Layout = "_Layout",
                            SiteVeiw = dReader["VIEW_ID"].ToString(),
                            SiteVeiwTheme = dReader["VIEW_THEME_ID"].ToString(),
                            TypeID = Int32.Parse(dReader["PAGE_TYPE_ID"].ToString())
                        };
                    }
                }
            }
            return page;
        }
    }

    public class PageModel
    {
        public int ID { get; set; }

        /// <summary>
        /// Заглавие на странницата
        /// </summary>
        public string Title { get; set; }

        public string Value { get; set; }

        /// <summary>
        /// Заглавие на сайта
        /// </summary>
        public string SiteTitle { get; set; }

        /// <summary>
        /// Тип на странницата
        /// </summary>
        public int TypeID { get; set; }

        public string Layout { get; set; }

        public string LayoutUrl
        {
            get
            { return GetVeiwName(this.SiteVeiw, "Shared/" + this.Layout); }
        }

        public string SiteVeiw { get; set; }

        public string SiteVeiwTheme { get; set; }

        public string VeiwName { get; set; }

        public string VeiwNameUrl
        {
            get
            { return GetVeiwName(this.SiteVeiw, this.VeiwName); }
        }

        private string GetVeiwName(string siteVeiw, string veiwName)
        {
            return "~/Views/" + siteVeiw + "/" + veiwName + ".cshtml";
        }
    }
}