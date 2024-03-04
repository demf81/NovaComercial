using System.Web.Mvc;

namespace PortalEmpresa.Client.Areas.PersonaPaquete
{
    public class PersonaPaqueteAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PersonaPaquete";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PersonaPaquete_default",
                "PersonaPaquete/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
