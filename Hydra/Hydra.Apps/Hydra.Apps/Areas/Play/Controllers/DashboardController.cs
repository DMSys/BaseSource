using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hydra.Apps.Models;
using Hydra.Apps.Contexts;

namespace Hydra.Apps.Areas.Play.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Play/Home/

        public ActionResult Index()
        {
            HydraAppsModel model = null;
            using (HydraAppsContext context = new HydraAppsContext())
            {
                model = context.GetApplications();
            }
            return View(model);
        }
    }
}
