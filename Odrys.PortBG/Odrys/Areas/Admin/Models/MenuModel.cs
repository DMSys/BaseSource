using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SQLite;

namespace Odrys.Areas.Admin.Models
{
    public class MenuContext : Odrys.Models.AppConfigContext
    {
        public MenuContext()
        { }

        public List<MenuModel> GetMenus(int siteID)
        {
            List<MenuModel> menus = new List<MenuModel>();
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                command.CommandText =
@"SELECT mn.ID
       , mn.MENU_NAME
       , mn.MENU_TEXT
FROM S_MENUS mn 
WHERE mn.SITE_ID = " + ParameterInt(siteID);
                using (SQLiteDataAdapter dAdapter = new SQLiteDataAdapter(command))
                {
                    using (DataTable dtSites = new DataTable())
                    {
                        dAdapter.Fill(dtSites);
                        foreach (DataRow dr in dtSites.Rows)
                        {
                            menus.Add(new MenuModel
                            {
                                ID = Int32.Parse(dr["ID"].ToString()),
                                Name = dr["MENU_NAME"].ToString(),
                                Text = dr["MENU_TEXT"].ToString(),
                            });
                        }
                    }
                }
            }
            return menus;
        }

        /// <summary>
        /// Основни данни за менюто
        /// </summary>
        public MenuModel GetMenu(int menuID)
        {
            MenuModel menu = null;
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                command.CommandText =
@"SELECT mm.ID
       , mm.SITE_ID
       , mm.MENU_NAME
       , mm.MENU_TEXT
FROM S_MENUS mm 
WHERE mm.ID = " + ParameterInt(menuID);
                using (SQLiteDataReader dReader = command.ExecuteReader())
                {
                    if (dReader.HasRows && dReader.Read())
                    {
                        menu = new MenuModel
                        {
                            ID = Int32.Parse(dReader["ID"].ToString()),
                            SiteID = Int32.Parse(dReader["SITE_ID"].ToString()),
                            Name = dReader["MENU_NAME"].ToString(),
                            Text = dReader["MENU_TEXT"].ToString()
                        };
                    }
                }
            }
            return menu;
        }

        public void SetMenu(MenuModel menu)
        {
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                command.CommandText =
@"UPDATE S_MENUS
     SET MENU_NAME = " + ParameterString(menu.Name) + @"
       , MENU_TEXT = " + ParameterString(menu.Text) + @"
WHERE ID = " + ParameterInt(menu.ID);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Списък елементи на менюто
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        public List<MenuItemModel> GetMenuItems(int menuID)
        {
            List<MenuItemModel> menuItems = new List<MenuItemModel>();
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                command.CommandText =
@"SELECT mni.ID
       , mni.ITEM_TEXT
       , mni.MENU_ITEM_TYPE_ID
       , mit.ITEM_TYPE_NAME
       , mni.ORDER_NO
       , mni.PARENT_ID
       , mip.ITEM_TEXT AS PARENT_TEXT
FROM S_MENU_ITEMS mni
LEFT JOIN S_MENU_ITEM_TYPES mit
  ON mit.ID = mni.MENU_ITEM_TYPE_ID
LEFT JOIN S_MENU_ITEMS mip
  ON mip.ID = mni.PARENT_ID
WHERE mni.MENU_ID = " + ParameterInt(menuID) + @"
ORDER BY mni.ORDER_NO ";
                using (SQLiteDataAdapter dAdapter = new SQLiteDataAdapter(command))
                {
                    using (DataTable dtSites = new DataTable())
                    {
                        dAdapter.Fill(dtSites);
                        foreach (DataRow dr in dtSites.Rows)
                        {
                            menuItems.Add(new MenuItemModel
                            {
                                ID = ParseInt(dr["ID"].ToString()),
                                Text = dr["ITEM_TEXT"].ToString(),
                                TypeID = ParseInt(dr["MENU_ITEM_TYPE_ID"].ToString()),
                                TypeName = dr["ITEM_TYPE_NAME"].ToString(),
                                OrderNo = ParseInt(dr["ORDER_NO"].ToString()),
                                ParentID = ParseInt(dr["PARENT_ID"].ToString()),
                                ParentName = dr["PARENT_TEXT"].ToString()
                            });
                        }
                    }
                }
            }
            return menuItems;
        }

        public MenuItemModel GetMenuItem(int itemID)
        {
            MenuItemModel menuItem = null;
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                command.CommandText =
@"SELECT mmi.ID
       , mmi.ITEM_TEXT
       , mmi.MENU_ID
       , mmi.PARENT_ID
       , mmi.MENU_ITEM_TYPE_ID
       , mmi.ORDER_NO 
       , mmi.ITEM_VALUE
       , mmi.LINK_AREA
       , mmi.LINK_CONTROLLER
       , mmi.LINK_ACTION
FROM S_MENU_ITEMS mmi
WHERE mmi.ID = " + ParameterInt(itemID);
                using (SQLiteDataReader dReader = command.ExecuteReader())
                {
                    if (dReader.HasRows && dReader.Read())
                    {
                        menuItem = new MenuItemModel
                        {
                            ID = ParseInt(dReader["ID"].ToString()),
                            Text = dReader["ITEM_TEXT"].ToString(),
                            MenuID = ParseInt(dReader["MENU_ID"].ToString()),
                            ParentID = ParseInt(dReader["PARENT_ID"].ToString()),
                            TypeID = ParseInt(dReader["MENU_ITEM_TYPE_ID"].ToString()),
                            OrderNo = ParseInt(dReader["ORDER_NO"].ToString()),
                            LinkValue = dReader["ITEM_VALUE"].ToString(),
                            LinkArea = dReader["LINK_AREA"].ToString(),
                            LinkController = dReader["LINK_CONTROLLER"].ToString(),
                            LinkAction = dReader["LINK_ACTION"].ToString()
                        };
                    }
                }
                menuItem.TypeList = GetMenuItemTypes(menuItem.TypeID);
            }
            return menuItem;
        }

        public void SetMenuItem(MenuItemModel menuItem)
        {
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {/*
                command.CommandText =
@"UPDATE S_MENUS
     SET MENU_NAME = " + ParameterString(menuItem.Name) + @"
       , MENU_TEXT = " + ParameterString(menuItem.Text) + @"
       , CSS_CLASS = " + ParameterString(menuItem.ClassCSS) + @"
WHERE ID = " + ParameterInt(menuItem.ID);
                command.ExecuteNonQuery();*/
            }
        }

        public List<System.Web.Mvc.SelectListItem> GetMenuItemTypes(int selectedValue = 0)
        {
            List<System.Web.Mvc.SelectListItem> items = new List<System.Web.Mvc.SelectListItem>();
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                command.CommandText =
@"SELECT mit.ID
       , mit.ITEM_TYPE_NAME
FROM S_MENU_ITEM_TYPES mit
ORDER BY mit.ITEM_TYPE_NAME ";
                using (SQLiteDataAdapter dAdapter = new SQLiteDataAdapter(command))
                {
                    using (DataTable dtSites = new DataTable())
                    {
                        dAdapter.Fill(dtSites);
                        foreach (DataRow dr in dtSites.Rows)
                        {
                            items.Add(new System.Web.Mvc.SelectListItem
                            {
                                Value = dr["ID"].ToString(),
                                Text = dr["ITEM_TYPE_NAME"].ToString(),
                                Selected = (ParseInt(dr["ID"].ToString()) == selectedValue)
                            });
                        }
                    }
                }
            }
            return items;
        }

        /// <summary>
        /// Задава подредба на елемент от менюто
        /// </summary>
        public void SetSortItem(int menuID, int itemID, int parentID, int orderNo)
        {
            using (SQLiteCommand command = new SQLiteCommand(base.SQLConnection))
            {
                command.CommandText =
@"UPDATE S_MENU_ITEMS
     SET PARENT_ID = " + ((parentID == -1) ? "null" : ParameterInt(parentID)) + @"
       , ORDER_NO = " + ((orderNo == -1) ? "null" : ParameterInt(orderNo)) + @"
WHERE MENU_ID = " + ParameterInt(menuID) + @"
  AND ID = " + ParameterInt(itemID);
                command.ExecuteNonQuery();
            }
        }
    }

    [Serializable]
    public class MenuModel
    {
        public int ID { get; set; }

        public int SiteID { get; set; }

        [Required]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Текст")]
        public string Text { get; set; }
    }

    [Serializable]
    public class MenuItemModel
    {
        public int ID { get; set; }

        public int MenuID { get; set; }

        public int ParentID { get; set; }

        [Display(Name = "Родител")]
        public string ParentName { get; set; }

        [Required]
        [Display(Name = "Тип")]
        public int TypeID { get; set; }

        [Display(Name = "Тип")]
        public string TypeName { get; set; }

        [Display(Name = "Типове", Prompt = "Типове", Description = "Типове елементи")]
        public List<System.Web.Mvc.SelectListItem> TypeList { get; set; }

        [Required]
        [Display(Name = "Елемнет")]
        public string Text { get; set; }

        [Display(Name = "URL Link")]
        public string LinkValue { get; set; }

        [Display(Name = "MVC Link: Area")]
        public string LinkArea { get; set; }

        [Display(Name = "MVC Link: Controller")]
        public string LinkController { get; set; }

        [Display(Name = "MVC Link: Action")]
        public string LinkAction{ get; set; }

        [Required]
        [Display(Name = "Номер")]
        public int OrderNo { get; set; }
    }
}