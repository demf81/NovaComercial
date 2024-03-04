using System.Web.Mvc;

namespace SACC.Client.Areas.Tarifa
{
    public class TarifaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Tarifa";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Tarifa_default",
                "Tarifa/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
