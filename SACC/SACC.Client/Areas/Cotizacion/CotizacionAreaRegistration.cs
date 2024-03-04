using System.Web.Mvc;

namespace SACC.Client.Areas.Cotizacion
{
    public class CotizacionAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Cotizacion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Cotizacion_default",
                "Cotizacion/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
