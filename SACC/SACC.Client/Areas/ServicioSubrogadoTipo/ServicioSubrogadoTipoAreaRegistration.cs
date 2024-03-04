using System.Web.Mvc;

namespace SACC.Client.Areas.ServicioSubrogadoTipo
{
    public class ServicioSubrogadoTipoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ServicioSubrogadoTipo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ServicioSubrogadoTipo_default",
                "ServicioSubrogadoTipo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
