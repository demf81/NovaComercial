using System.Web.Mvc;

namespace SACC.Client.Areas.MembresiaRenovacion
{
    public class MembresiaRenovacionAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MembresiaRenovacion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MembresiaRenovacion_default",
                "MembresiaRenovacion/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
