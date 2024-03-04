using System.Web.Mvc;

namespace SACC.Client.Areas.CotizacionDetalle
{
    public class CotizacionDetalleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CotizacionDetalle";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CotizacionDetalle_default",
                "CotizacionDetalle/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
