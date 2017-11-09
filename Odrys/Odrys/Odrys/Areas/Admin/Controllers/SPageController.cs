using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Odrys.Areas.Admin.Models;

namespace Odrys.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class SPageController : Controller
    {
        public SPageController()
        {
            ViewBag.PageMenu = "page_settings";
        }

        //
        // GET: /Admin/SPage/

        public ActionResult Index()
        {
            List<SPageModel> model = null;
            using (PageContext context = new PageContext())
            {
                model = context.GetPages(HttpSession.CurrentSiteID);
            }
            return View(model);
        }

        //
        // GET: /Admin/SPage/Create

        public ActionResult Create(string typePage = "")
        {
            using (PageContext context = new PageContext())
            {
                ViewBag.PageTypes = context.GetPageTypes().ToSelectList("TYPE_ID", "TYPE_NAME", 1);
            }
            ViewBag.EditPageTypes = true;
            return View("NewEditTinymce");
        }

        //
        // POST: /Admin/SPage/Create

        [HttpPost]
        public ActionResult Create(SPageModel model)
        {
            if (ModelState.IsValid)
            {
                using (PageContext context = new PageContext())
                {
                    context.AddPage(HttpSession.CurrentSiteID, model);
                }
                return RedirectToAction("Index");
            }
            ViewBag.EditPageTypes = true;
            return View("NewEditTinymce", model);
        }

        //
        // GET: /Admin/SPage/Edit

        public ActionResult Edit(int id = 0)
        {
            SPageModel model = null;
            using (PageContext context = new PageContext())
            {
                model = context.GetPage(HttpSession.CurrentSiteID, id);
            }
            ViewBag.EditPageTypes = false;
            return ReturnView(model);
        }

        //
        // POST: /Admin/SPage/Edit

        [HttpPost]
        public ActionResult Edit(SPageModel model)
        {
            if (ModelState.IsValid)
            {
                using (PageContext context = new PageContext())
                {
                    context.SetPage(HttpSession.CurrentSiteID, model);
                }
                return RedirectToAction("Index");
            }
            return ReturnView(model);
        }

        private ActionResult ReturnView(SPageModel model)
        {
            if (model.TypeEditorID == 2)
            { return View("NewEditTinymce", model); }
            else
            { return View("NewEditMvc", model); }
        }
    }
}
