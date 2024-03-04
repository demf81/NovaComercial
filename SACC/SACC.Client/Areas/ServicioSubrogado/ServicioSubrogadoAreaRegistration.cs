using System.Web.Mvc;

namespace SACC.Client.Areas.ServicioSubrogado
{
    public class ServicioSubrogadoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ServicioSubrogado";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ServicioSubrogado_default",
                "ServicioSubrogado/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
