using System.Web.Mvc;

namespace SACC.Client.Areas.PaqueteTipo
{
    public class PaqueteTipoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PaqueteTipo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PaqueteTipo_default",
                "PaqueteTipo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
