using System.Web.Mvc;

namespace SACC.Client.Areas.VentaDetalle
{
    public class VentaDetalleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "VentaDetalle";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "VentaDetalle_default",
                "VentaDetalle/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
