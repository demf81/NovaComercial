using System.Web.Mvc;

namespace SACC.Client.Areas.Pais
{
    public class PaisAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Pais";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Pais_default",
                "Pais/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
