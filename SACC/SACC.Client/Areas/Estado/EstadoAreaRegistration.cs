using System.Web.Mvc;

namespace SACC.Client.Areas.Estado
{
    public class EstadoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Estado";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Estado_default",
                "Estado/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
