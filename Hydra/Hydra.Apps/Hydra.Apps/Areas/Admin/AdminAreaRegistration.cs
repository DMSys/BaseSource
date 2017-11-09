using System.Web.Mvc;

namespace Hydra.Apps.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AdminDefault",
                "Admin/{controller}/{action}/{id}",
                new { area = "Admin", controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
