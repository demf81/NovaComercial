using System.Web.Mvc;

namespace PortalEmpresa.Client.Areas.Paquete
{
    public class PaqueteAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Paquete";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Paquete_default",
                "Paquete/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
