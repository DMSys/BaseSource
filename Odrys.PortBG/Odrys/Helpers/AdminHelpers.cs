using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Odrys.Areas.Admin.Models;

namespace System.Web.Mvc
{
    public static class AdminHelpers
    {
        public static MvcHtmlString SiteName(this HtmlHelper helper, int siteID)
        {
            string siteName = "";
            using (SiteContext context = new SiteContext())
            {
                siteName = context.GetSiteName(siteID);
            }
            return new MvcHtmlString(siteName);
        }

        public static MvcHtmlString ActionSiteLink(this HtmlHelper helper, int siteID)
        {
            string siteName = "";
            using (SiteContext context = new SiteContext())
            {
                // Няма избран сайт
                if (siteID == 0)
                {
                    int id = context.GetMainSiteID();
                    HttpSession.CurrentSiteID = id;
                    // Взема име на сайта
                    siteName = context.GetSiteName(id);
                }
                else
                {
                    // Взема име на сайта
                    siteName = context.GetSiteName(siteID);
                }
            }
            return Html.LinkExtensions.ActionLink(
                helper,
                siteName, 
                "Index", "Site", new { area = "Admin" }, null);
        }

        public static string CurrentController(this HtmlHelper helper)
        {
            object rawController = helper.ViewContext.Controller.ValueProvider.GetValue("controller").RawValue;
            if (rawController == null)
            { return ""; }
            else
            { return rawController.ToString(); }
        }

        public static string CurrentAction(this HtmlHelper helper)
        {
            object rawAction = helper.ViewContext.Controller.ValueProvider.GetValue("action").RawValue;
            if (rawAction == null)
            { return ""; }
            else
            { return rawAction.ToString(); }
        }

        public static string CurrentId(this HtmlHelper helper)
        {
            object rawAction = helper.ViewContext.Controller.ValueProvider.GetValue("id").RawValue;
            if (rawAction == null)
            { return ""; }
            else
            { return rawAction.ToString(); }
        }

        /// <summary>
        /// Взема ID на главния сайт
        /// </summary>
        /// <returns></returns>
        public static int GetMainSiteID()
        {
            int siteID = 0;
            using (SiteContext context = new SiteContext())
            {
                siteID = context.GetMainSiteID();
            }
            return siteID;
        }
    }
}