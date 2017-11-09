using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SQLite;
using Odrys.Helpers;

namespace Odrys.Areas.Admin.Models
{
    public class PageContext : Odrys.Models.AppConfigContext
    {
        public PageContext()
        { }

        /// <summary>
        /// Списък на страниците
        /// </summary>
        /// <param name="siteID"></param>
        /// <returns></returns>
        public List<SPageModel> GetPages(int siteID)
        {
            List<SPageModel> pages = new List<SPageModel>();
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                command.CommandText =
@"SELECT pg.ID
       , pg.PAGE_NAME
       , pg.PAGE_TITLE
       , pg.PAGE_TYPE_ID
       , pgt.PAGE_TYPE_NAME
FROM S_PAGES pg
LEFT JOIN S_PAGE_TYPES pgt
  ON pgt.ID = pg.PAGE_TYPE_ID
WHERE pg.SITE_ID = " + ParameterInt(siteID);
                using (SQLiteDataAdapter dAdapter = new SQLiteDataAdapter(command))
                {
                    using (DataTable dtPages = new DataTable())
                    {
                        dAdapter.Fill(dtPages);
                        foreach (DataRow dr in dtPages.Rows)
                        {
                            pages.Add(new SPageModel
                            {
                                ID = TryParse.ToInt32(dr["ID"]),
                                Name = dr["PAGE_NAME"].ToString(),
                                Title = dr["PAGE_TITLE"].ToString(),
                                TypeID = TryParse.ToInt32(dr["PAGE_TYPE_ID"]),
                                TypeName = dr["PAGE_TYPE_NAME"].ToString()
                            });
                        }
                    }
                }
            }
            return pages;
        }

        /// <summary>
        /// Основни данни за нова страницата
        /// </summary>
        public SPageModel GetNewPage(int siteID, int typePage)
        {
            SPageModel page = null;
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                command.CommandText =
@"SELECT pgt.ID AS PAGE_TYPE_ID
       , pgt.PAGE_TYPE_NAME
       , upt.S_PAGE_TYPE_EDITOR_ID
FROM S_PAGE_TYPES pgt
LEFT JOIN U_PAGE_TYPE_EDITOR upt
  ON upt.S_PAGE_TYPE_ID = pgt.ID
 AND upt.U_USER_ID = " + ParameterInt(HttpSession.UserID) + @"
WHERE pgt.ID = " + ParameterInt(typePage);
                using (SQLiteDataReader dReader = command.ExecuteReader())
                {
                    if (dReader.HasRows && dReader.Read())
                    {
                        page = new SPageModel
                        {
                            ID = 0,
                            SiteID = siteID,
                            TypeID = TryParse.ToInt32(dReader["PAGE_TYPE_ID"]),
                            TypeName = dReader["PAGE_TYPE_NAME"].ToString(),
                            TypeEditorID = TryParse.ToInt32(dReader["S_PAGE_TYPE_EDITOR_ID"])
                        };
                    }
                    else
                    {
                        page = new SPageModel
                        {
                            ID = 0,
                            SiteID = siteID,
                            TypeID = 1,
                            TypeName = "HTML Page",
                            TypeEditorID = 2    // Tinymce
                        };
                    }
                }
            }
            // Само при редакция
            if (page.ID > 0)
            {
                // MVC Page
                if (page.TypeID == 2)
                {
                    string pagePath = GetPagePath(page.SiteVeiw, page.Name);
                    page.Value = ReaderCSHTML(pagePath);
                }
            }
            return page;
        }

        /// <summary>
        /// Основни данни за страницата
        /// </summary>
        public SPageModel GetPage(int siteID, int pageID)
        {
            SPageModel page = null;
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                command.CommandText =
@"SELECT pg.ID
       , pg.PAGE_NAME
       , pg.PAGE_TITLE
       , pg.PAGE_VALUE
       , pg.PAGE_TYPE_ID
       , pgt.PAGE_TYPE_NAME
       , upt.S_PAGE_TYPE_EDITOR_ID
       , st.VIEW_ID
FROM S_PAGES pg
INNER JOIN S_SITES st
   ON st.ID = pg.SITE_ID
LEFT JOIN S_PAGE_TYPES pgt
  ON pgt.ID = pg.PAGE_TYPE_ID
LEFT JOIN U_PAGE_TYPE_EDITOR upt
  ON upt.S_PAGE_TYPE_ID = pg.PAGE_TYPE_ID
 AND upt.U_USER_ID = " + ParameterInt(HttpSession.UserID) + @"
WHERE pg.ID = " + ParameterInt(pageID) + @"
  AND pg.SITE_ID = " + ParameterInt(siteID);
                using (SQLiteDataReader dReader = command.ExecuteReader())
                {
                    if (dReader.HasRows && dReader.Read())
                    {
                        page = new SPageModel
                        {
                            ID = pageID,
                            SiteID = siteID,
                            Name = dReader["PAGE_NAME"].ToString(),
                            Title = dReader["PAGE_TITLE"].ToString(),
                            Value = dReader["PAGE_VALUE"].ToString(),
                            TypeID = TryParse.ToInt32(dReader["PAGE_TYPE_ID"]),
                            TypeName = dReader["PAGE_TYPE_NAME"].ToString(),
                            TypeEditorID = TryParse.ToInt32(dReader["S_PAGE_TYPE_EDITOR_ID"]),
                            SiteVeiw = dReader["VIEW_ID"].ToString()
                        };
                    }
                }
            }
            // MVC Page
            if (page.TypeID == 2)
            {
                string pagePath = GetPagePath(page.SiteVeiw, page.Name);
                page.Value = ReaderCSHTML(pagePath);
            }
            return page;
        }

        /// <summary>
        /// Добавя страница
        /// </summary>
        public void AddPage(int siteID, SPageModel page)
        {
            // HTML Page
            if (page.TypeID == 1)
            {
                using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
                {
                    command.CommandText =
@"INSERT INTO S_PAGES
  ( PAGE_NAME, PAGE_TITLE, PAGE_VALUE, SITE_ID, PAGE_TYPE_ID)
VALUES (" + ParameterString(page.Name) +
    ", " + ParameterString(page.Title) +
    ", " + ParameterString(page.Value) +
    ", " + ParameterInt(siteID) +
    ", " + ParameterInt(page.TypeID) + ")";
                    command.ExecuteNonQuery();
                }
            }
            // MVC Page & MVC Layout
            else
            {
                using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
                {
                    command.CommandText =
@"INSERT INTO S_PAGES
  ( PAGE_NAME, PAGE_TITLE, SITE_ID, PAGE_TYPE_ID)
VALUES (" + ParameterString(page.Name) +
    ", " + ParameterString(page.Title) +
    ", " + ParameterInt(siteID) +
    ", " + ParameterInt(page.TypeID) + ")";
                    command.ExecuteNonQuery();
                }

                page.SiteVeiw = GetSiteVeiw(siteID);
                string pagePath = GetPagePath(page.SiteVeiw, page.Name);
                WriterCSHTML(pagePath, page.Value);
            }
        }

        /// <summary>
        /// Променя данните за страницата
        /// </summary>
        public void SetPage(int siteID, SPageModel page)
        {
            // HTML Page
            if (page.TypeID == 1)
            {
                using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
                {
                    command.CommandText =
@"UPDATE S_PAGES
     SET PAGE_NAME = " + ParameterString(page.Name) + @"
       , PAGE_TITLE = " + ParameterString(page.Title) + @"
       , PAGE_VALUE = " + ParameterString(page.Value) + @"
WHERE ID = " + ParameterInt(page.ID) + @"
  AND SITE_ID = " + ParameterInt(siteID);
                    command.ExecuteNonQuery();
                }
            }
            // MVC Page & MVC Layout
            else
            {
                using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
                {
                    command.CommandText =
@"UPDATE S_PAGES
     SET PAGE_NAME = " + ParameterString(page.Name) + @"
       , PAGE_TITLE = " + ParameterString(page.Title) + @"
WHERE ID = " + ParameterInt(page.ID) + @"
  AND SITE_ID = " + ParameterInt(siteID);
                    command.ExecuteNonQuery();
                }

                page.SiteVeiw = GetSiteVeiw(siteID);
                string pagePath = GetPagePath(page.SiteVeiw, page.Name);
                WriterCSHTML(pagePath, page.Value);
            }
        }

        /// <summary>
        /// Прочита '.cshtml' файл
        /// </summary>
        public string ReaderCSHTML(string pagePath)
        {
            // Ако файла не съществува
            if (!System.IO.File.Exists(pagePath))
            { return ""; }

            string pageValue = "";
            using (System.IO.TextReader tr = new System.IO.StreamReader(pagePath, System.Text.Encoding.UTF8))
            {
                pageValue = tr.ReadToEnd();
                tr.Close();
            }
            return pageValue;
        }

        /// <summary>
        /// Записва '.cshtml' файл
        /// </summary>
        public void WriterCSHTML(string pagePath, string pageValue)
        {
            string htmlValue = HttpUtility.HtmlDecode(pageValue);
            using (System.IO.TextWriter tw = new System.IO.StreamWriter(pagePath, false, System.Text.Encoding.UTF8))
            {
                tw.Write(htmlValue);
                tw.Close();
            }
        }

        public string GetPagePath(string siteVeiw, string pageName)
        {
            return AppDomain.CurrentDomain.BaseDirectory +
                "Views\\" + siteVeiw + "\\" + pageName + ".cshtml";
        }

        public string GetSharedPagePath(string siteVeiw, string pageName)
        {
            return AppDomain.CurrentDomain.BaseDirectory +
                "Views\\" + siteVeiw + "\\Shared\\" + pageName + ".cshtml";
        }

        /// <summary>
        /// Типове странници
        /// </summary>
        /// <returns></returns>
        public DataTable GetPageTypes()
        {
            DataTable dtPageTypes = null;
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                command.CommandText =
@"SELECT pgt.ID AS TYPE_ID 
       , pgt.PAGE_TYPE_NAME AS TYPE_NAME 
 FROM S_PAGE_TYPES pgt 
 ORDER BY pgt.PAGE_TYPE_NAME ";
                dtPageTypes = base.FillDataTable(command);
            }
            return dtPageTypes;
        }

        public string GetSiteVeiw(int siteID)
        {
            string siteVeiw = "";
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                command.CommandText =
@"SELECT VIEW_ID
 FROM S_SITES
 WHERE ID = " + ParameterInt(siteID);
                using (SQLiteDataReader dReader = command.ExecuteReader())
                {
                    if (dReader.HasRows && dReader.Read())
                    {
                        siteVeiw = dReader["VIEW_ID"].ToString();
                    }
                }
            }
            return siteVeiw;
        }
    }

    [Serializable]
    public class SPageModel
    {
        public int ID { get; set; }

        public int SiteID { get; set; }

        [Required]
        public int TypeID { get; set; }

        /// <summary>
        /// Тип на редактора
        /// </summary>
        public int TypeEditorID { get; set; }

        [Display(Name = "Тип")]
        public string TypeName { get; set; }

        [Required]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [System.Web.Mvc.AllowHtml]
        [Display(Name = "Съдържание")]
        public string Value { get; set; }

        public string SiteVeiw { get; set; }
    }
}