using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Odrys.Models;

namespace Odrys.Controllers
{
    public class PageController : Controller
    {
        //
        // GET: /Page/

        public ActionResult Index(string id = "")
        {
            PageModel page = null;
            using (PageContext context = new PageContext())
            {
                page = context.GetPage(HttpSession.CurrentSiteID, id);
            }

            ViewBag.Styles = new string[] {
                "~/Content/default/white/style.responsive.css", 
                "~/Content/default/white/style.css"
            };
            ViewBag.Scripts = new string[] {
                "~/Scripts/default/white/jquery.js",
                "~/Scripts/default/white/script.js",
                "~/Scripts/default/white/script.responsive.js"
            };

            if (page != null)
            {
                ViewBag.Title = page.Title;
                ViewBag.SiteTitle = page.SiteTitle;
                if (page.TypeID == 2) // MVC Page
                { return View("~/Views/" + page.SiteVeiw + "/" + id +".cshtml", page); }
                else
                { return View("~/Views/Page/Index.cshtml", page); }
            }
            else
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }
    }
}