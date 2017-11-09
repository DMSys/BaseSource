using System.Web.Mvc;

namespace Hydra.Apps.Areas.Play
{
    public class PlayAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Play";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PlayDefault",
                "Play/{controller}/{action}/{id}",
                new { area = "Play", controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
