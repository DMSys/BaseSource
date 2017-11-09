using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Odrys.Models;

namespace System.Web.Mvc
{
    public static class MenuHelpers
    {
        #region AppMenu

        public static MvcHtmlString AppMenuUL(this HtmlHelper helper, string menuName
            , string cssMenu = "", string cssGroupSelected = "", string cssItemSelected = "")
        {
            return AppMenu(helper, HttpSession.CurrentSiteID, menuName, "ul", "li"
                , cssMenu, cssGroupSelected, cssItemSelected);
        }

        public static MvcHtmlString AppMenuOL(this HtmlHelper helper, string menuName
            , string cssMenu = "", string cssGroupSelected = "", string cssItemSelected = "")
        {
            return AppMenu(helper, HttpSession.CurrentSiteID, menuName, "ol", "li"
                , cssMenu, cssGroupSelected, cssItemSelected);
        }

        public static MvcHtmlString AppMenu(this HtmlHelper helper, int siteID
            , string menuName, string groupName = "ul", string itemName = "li"
            , string cssMenu = "", string cssGroupSelected = "", string cssItemSelected = "")
        {
            AppMenuModel appMenu = null;
            // Зарежда менюто от базата
            using (AppMenuContext context = new AppMenuContext())
            {
                appMenu = context.GetAppMenu(siteID, menuName);
            }

            // Генерира елементите на менюто
            AppMenuItems items = new AppMenuItems(helper);
            items.AppMenu = appMenu;
            items.GroupName = groupName;
            items.ItemName = itemName;
            items.CSSMenu = cssMenu;
            items.CSSGroupSelected = cssGroupSelected;
            items.CSSItemSelected = cssItemSelected;

            string menu = items.Generate();
            return new MvcHtmlString(menu);
        }

        #endregion AppMenu

        public static MvcHtmlString SortMenuOL(this HtmlHelper helper, string menuName,
            string cssMenu = "", string cssItem = "", string itemFormat = "")
        {
            return SortMenu(helper, HttpSession.CurrentSiteID, menuName,
                "ol", "li", cssMenu, cssItem, itemFormat);
        }

        public static MvcHtmlString SortMenu(this HtmlHelper helper, int siteID, string menuName,
            string groupName = "ol", string itemName = "li",
            string cssMenu = "", string cssItem = "", string itemFormat = "")
        {
            AppMenuModel appMenu = null;
            // Зарежда менюто от базата
            using (AppMenuContext context = new AppMenuContext())
            {
                appMenu = context.GetAppMenu(siteID, menuName);
            }

            // Генерира елементите на менюто
            AppMenuItems items = new AppMenuItems(helper);
            items.AppMenu = appMenu;
            items.GroupName = groupName;
            items.ItemName = itemName;
            items.CSSMenu = cssMenu;
            items.CSSItem = cssItem;
            items.IsItemLink = false;
            items.IsItemID = true;
            items.ItemFormat = itemFormat;

            string menu = items.Generate();
            return new MvcHtmlString(menu);
        }

        /// <summary>
        /// Генерира HTML меню
        /// </summary>
        private class AppMenuItems
        {
            private HtmlHelper _Helper = null;
            private int index = 0;

            public AppMenuModel AppMenu = null;
            /// <summary>
            /// Име на таг за група от елементи
            /// </summary>
            public string GroupName = "ul";
            /// <summary>
            /// Име на таг за елемент
            /// </summary>
            public string ItemName = "li";
            /// <summary>
            /// Стил на менюто
            /// </summary>
            public string CSSMenu = "";
            /// <summary>
            /// Стил на елементите на менюто
            /// </summary>
            public string CSSItem = "";
            /// <summary>
            /// Стил на селектираната група от елементи
            /// </summary>
            public string CSSGroupSelected = "";
            /// <summary>
            /// Стил на селектирания елемент
            /// </summary>
            public string CSSItemSelected = "";
            /// <summary>
            /// Елементите са линкове
            /// </summary>
            public bool IsItemLink = true;
            /// <summary>
            /// Елементите са с ID
            /// </summary>
            public bool IsItemID = false;
            /// <summary>
            /// Формат на елемента
            /// </summary>
            public string ItemFormat = "";

            public AppMenuItems(HtmlHelper helper)
            {
                _Helper = helper;
            }

            public string Generate()
            {
                StringBuilder sbMenu = new StringBuilder();

                // Начало на менюто
                sbMenu.Append("<" + this.GroupName + ((this.CSSMenu == "") ? "" : " class='" + this.CSSMenu + "'") + ">");
                for (index = 0; index < this.AppMenu.Count; index++)
                {
                    AppMenuItemModel item = this.AppMenu[index];
                    AddItem(sbMenu, item, index);
                }
                // Край на менюто
                sbMenu.Append("</" + this.GroupName + ">");
                return sbMenu.ToString();
            }

            private bool AddItem(StringBuilder menu, AppMenuItemModel item, int i)
            {
                bool isSelected = false;
                // Проверява дали е селектиран
                if (this.CSSGroupSelected != "")
                {
                    if (item.ItemTypeID == 3)
                    {
                        if (("Page" == AdminHelpers.CurrentController(_Helper))
                          && (item.PageName == AdminHelpers.CurrentId(_Helper)))
                        { isSelected = true; }
                    }
                }
                // Добавя елемента
                menu.Append("<" + 
                    this.ItemName +
                    (this.IsItemID ? " id=\"item_" + item.ItemID.ToString() + "\"" : "") +
                    ((this.CSSItem == "") ? "" : " class=\"" + this.CSSItem + "\"") +
                    ">");
                menu.Append(GetItem(item, isSelected));
                // Става текущ елемент
                index = i;
                // Добавя под елементите
                StringBuilder subMenu = new StringBuilder();
                if (AddSubItems(subMenu, i + 1, item.ItemID))
                { isSelected = true; }
                if (subMenu.Length > 0 )
                {
                    string selectedClass = (isSelected ? " class='" + this.CSSItemSelected + "'" : "");
                    menu.Append("<" + this.GroupName + selectedClass + ">");
                    menu.Append(subMenu);
                    menu.Append("</" + this.GroupName + ">");
                }
                subMenu.Clear();
                // Край на елемента
                menu.Append("</" + this.ItemName + ">");

                return isSelected;
            }

            /// <summary>
            /// Добавя поделементите
            /// </summary>
            private bool AddSubItems
                (
                    StringBuilder subMenu,
                    int currentIndex,   // текущ индекс
                    int parentID        // текущ родител
                )
            {
                bool isSelected = false;
                for (int i = currentIndex; i < this.AppMenu.Count; i++)
                {
                    AppMenuItemModel item = this.AppMenu[i];
                    if (item.ParentID == parentID)
                    {
                        // Добавя елемента
                        if (AddItem(subMenu, item, i))
                        { isSelected = true; }
                    }
                    else
                    { return isSelected; }
                }
                return isSelected;
            }

            /// <summary>
            /// Дава стойноста на елемента в зависимост от типа
            /// </summary>
            private string GetItem(AppMenuItemModel item, bool isSelected)
            {
                string itemValue = "";
                // Ако елемента е линк
                if (this.IsItemLink)
                {
                    object htmlAttributes = null;
                    if (isSelected)
                    { htmlAttributes = new { @class = this.CSSGroupSelected }; }

                    // MVC Link
                    if (item.ItemTypeID == 1)
                    {
                        itemValue = Html.LinkExtensions.ActionLink(_Helper, item.ItemText, item.LinkAction, item.LinkController, new { area = item.LinkArea }, htmlAttributes).ToString();
                    }
                    // Page: Странница от базата
                    else if (item.ItemTypeID == 3)
                    {
                        itemValue = Html.LinkExtensions.ActionLink(_Helper, item.ItemText, item.PageName, "Page", null, htmlAttributes).ToString();
                    }
                    else
                    { itemValue = item.ItemText; }
                }
                // елемента не е линк
                else
                {
                    if (ItemFormat == "")
                    { itemValue = item.ItemText; }
                    else
                    { itemValue = string.Format(this.ItemFormat, item.ItemText); }
                }
                return itemValue;
            }
        }
    }
}