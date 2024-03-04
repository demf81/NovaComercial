using System.Web.Mvc;

namespace PortalEmpresa.Client.Areas.Checkup
{
    public class CheckupAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Checkup";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Checkup_default",
                "Checkup/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
