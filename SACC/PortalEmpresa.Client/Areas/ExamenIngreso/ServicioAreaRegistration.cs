using System.Web.Mvc;

namespace PortalEmpresa.Client.Areas.Servicio
{
    public class ServicioAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Servicio";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Servicio_default",
                "Servicio/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
