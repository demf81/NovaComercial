using System.Web.Mvc;

namespace SACC.Client.Areas.Venta
{
    public class VentaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Venta";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Venta_default",
                "Venta/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
