using System.Web.Mvc;

namespace SACC.Client.Areas.VentaTipo
{
    public class VentaTipoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "VentaTipo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "VentaTipo_default",
                "VentaTipo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
