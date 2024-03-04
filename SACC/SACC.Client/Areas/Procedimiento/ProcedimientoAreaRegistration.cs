using System.Web.Mvc;

namespace SACC.Client.Areas.Procedimiento
{
    public class ProcedimientoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Procedimiento";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Procedimiento_default",
                "Procedimiento/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
