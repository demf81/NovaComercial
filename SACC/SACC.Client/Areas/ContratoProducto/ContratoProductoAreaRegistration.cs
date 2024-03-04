using System.Web.Mvc;

namespace SACC.Client.Areas.ContratoProducto
{
    public class ContratoProductoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ContratoProducto";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ContratoProducto_default",
                "ContratoProducto/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
