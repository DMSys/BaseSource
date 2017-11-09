using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using Odrys.Helpers;

namespace Odrys.Models
{
    public class AppMenuContext: AppConfigContext
    {
        public AppMenuContext()
        { }

        public AppMenuModel GetAppMenu(int siteID, string name)
        {
            AppMenuModel appMenu = new AppMenuModel();
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                // Данни за менюто
                command.CommandText =
@"SELECT mn.ID AS MENU_ID
FROM S_MENUS mn 
WHERE mn.SITE_ID = " + ParameterInt(siteID) + @"
  AND mn.MENU_NAME = " + ParameterString(name);
                using (SQLiteDataReader dReader = command.ExecuteReader())
                {
                    if (dReader.HasRows && dReader.Read())
                    {
                        appMenu.MenuID = Int32.Parse(dReader["MENU_ID"].ToString());
                    }
                }
                // Елементи на менуто
                command.CommandText =
@"SELECT mni.ID AS ITEM_ID
       , mni.MENU_ITEM_TYPE_ID
       , mni.PARENT_ID
       , mni.ITEM_TEXT
       , mni.ITEM_VALUE
       , mni.LINK_AREA
       , mni.LINK_CONTROLLER
       , mni.LINK_ACTION
       , spg.PAGE_NAME
FROM S_MENU_ITEMS mni
LEFT JOIN S_PAGES spg
  ON spg.ID = mni.S_PAGE_ID
WHERE mni.MENU_ID = " + ParameterInt(appMenu.MenuID) + @"
ORDER BY mni.ORDER_NO ";
                using (SQLiteDataReader dReader = command.ExecuteReader())
                {
                    if (dReader.HasRows)
                    {
                        while (dReader.Read())
                        {
                            AppMenuItemModel item = new AppMenuItemModel();
                            item.ItemID = TryParse.ToInt32(dReader["ITEM_ID"]);
                            item.ItemTypeID = TryParse.ToInt32(dReader["MENU_ITEM_TYPE_ID"]);
                            item.ParentID = TryParse.ToInt32(dReader["PARENT_ID"]);
                            item.ItemText = dReader["ITEM_TEXT"].ToString();
                            item.ItemValue = dReader["ITEM_VALUE"].ToString();
                            item.LinkArea = dReader["LINK_AREA"].ToString();
                            item.LinkController = dReader["LINK_CONTROLLER"].ToString();
                            item.LinkAction = dReader["LINK_ACTION"].ToString();
                            item.PageName = dReader["PAGE_NAME"].ToString();
                            appMenu.Add(item);
                        }
                    }
                }
            }
            return appMenu;
        }
    }

    public class AppMenuModel : List<AppMenuItemModel>
    {
        public int MenuID { get; set; }
    }

    public class AppMenuItemModel
    {
        public int ItemID { get; set; }

        public int ItemTypeID { get; set; }

        public int ParentID { get; set; }

        public string ItemText { get; set; }

        public string ItemValue { get; set; }

        public string LinkArea { get; set; }

        public string LinkController { get; set; }

        public string LinkAction { get; set; }

        /// <summary>
        /// Име на странница при тип Page
        /// </summary>
        public string PageName { get; set; }
    }
}