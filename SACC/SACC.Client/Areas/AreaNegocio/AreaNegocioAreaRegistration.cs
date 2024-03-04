using System.Web.Mvc;

namespace SACC.Client.Areas.AreaNegocio
{
    public class AreaNegocioAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AreaNegocio";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AreaNegocio_default",
                "AreaNegocio/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
