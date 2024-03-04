using System.Web.Mvc;

namespace SACC.Client.Areas.FrecuenciaPago
{
    public class FrecuenciaPagoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "FrecuenciaPago";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "FrecuenciaPago_default",
                "FrecuenciaPago/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
