using System.Web.Mvc;

namespace SACC.Client.Areas.MetodoPago
{
    public class MetodoPagoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MetodoPago";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MetodoPago_default",
                "MetodoPago/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
