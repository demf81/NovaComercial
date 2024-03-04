using System.Web.Mvc;

namespace SACC.Client.Areas.Asociado
{
    public class AsociadoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Asociado";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Asociado_default",
                "Asociado/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
