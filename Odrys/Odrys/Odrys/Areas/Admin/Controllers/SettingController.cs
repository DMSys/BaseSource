using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Odrys.Areas.Admin.Models;

namespace Odrys.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class SettingController : Controller
    {
        public SettingController()
        {
            ViewBag.PageMenu = "page_settings";
        }

        //
        // GET: /Admin/Settings/

        public ActionResult Index()
        {
            return View();
        }
    }
}
