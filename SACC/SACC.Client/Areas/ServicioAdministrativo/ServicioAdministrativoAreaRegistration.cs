using System.Web.Mvc;

namespace SACC.Client.Areas.ServicioAdministrativo
{
    public class ServicioAdministrativoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ServicioAdministrativo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ServicioAdministrativo_default",
                "ServicioAdministrativo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
