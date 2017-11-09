using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{
    public static class PageHelpers
    {
        public static MvcHtmlString RenderDBPage(this HtmlHelper helper, string pageValue)
        {
            return new MvcHtmlString(pageValue);
        }

        public static MvcHtmlString RenderDBPage(this HtmlHelper helper, int siteID, string pageName)
        {
            return new MvcHtmlString(pageName);
        }

        /// <summary>
        /// Преобразува DataTable в SelectList
        /// </summary>
        /// <param name="table"></param>
        /// <param name="valueField"></param>
        /// <param name="textField"></param>
        /// <param name="selectedValue"></param>
        /// <returns></returns>
        public static SelectList ToSelectList(this System.Data.DataTable table, string valueField, string textField, object selectedValue = null)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (System.Data.DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }
            if (selectedValue == null)
            { return new SelectList(list, "Value", "Text"); }
            else
            { return new SelectList(list, "Value", "Text", selectedValue); }
        }
    }
}