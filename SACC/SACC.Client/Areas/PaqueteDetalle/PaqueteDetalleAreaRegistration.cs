using System.Web.Mvc;

namespace SACC.Client.Areas.PaqueteDetalle
{
    public class PaqueteDetalleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PaqueteDetalle";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PaqueteDetalle_default",
                "PaqueteDetalle/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
