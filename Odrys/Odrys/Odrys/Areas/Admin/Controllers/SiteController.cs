using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Odrys.Areas.Admin.Models;

namespace Odrys.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class SiteController : Controller
    {
        public SiteController()
        {
            ViewBag.PageMenu = "page_settings";
        }

        //
        // GET: /Admin/Site/

        public ActionResult Index(int id = 0)
        {
            // Слмяна на работния сайт
            if (id > 0)
            { HttpSession.CurrentSiteID = id; }
            // Списък на саийтовете
            List<SiteModel> sites = null;
            using (SiteContext context = new SiteContext())
            {
                sites = context.GetSites();
            }
            return View(sites);
        }

        //
        // GET: /Admin/Site/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Site/Create

        [HttpPost]
        public ActionResult Create(SiteModel site)
        {
            if (ModelState.IsValid)
            {
                using (SiteContext context = new SiteContext())
                {
                    context.AddSite(site);
                }
                return RedirectToAction("Index");
            }
            return View(site);
        }

        //
        // GET: /Admin/Site/Edit

        public ActionResult Edit(int id = 0)
        {
            SiteModel site = null;
            using (SiteContext context = new SiteContext())
            {
                site = context.GetSite(id);
            }
            return View(site);
        }

        //
        // POST: /Admin/Site/Edit

        [HttpPost]
        public ActionResult Edit(SiteModel site)
        {
            if (ModelState.IsValid)
            {
                using (SiteContext context = new SiteContext())
                {
                    context.SetSite(site);
                }
                return RedirectToAction("Index");
            }
            return View(site);
        }
    }
}
