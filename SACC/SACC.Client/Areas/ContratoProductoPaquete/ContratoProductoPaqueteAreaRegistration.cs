using System.Web.Mvc;

namespace SACC.Client.Areas.ContratoProductoPaquete
{
    public class ContratoProductoPaqueteAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ContratoProductoPaquete";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ContratoProductoPaquete_default",
                "ContratoProductoPaquete/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
