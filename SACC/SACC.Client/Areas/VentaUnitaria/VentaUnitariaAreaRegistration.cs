using System.Web.Mvc;

namespace SACC.Client.Areas.VentaUnitaria
{
    public class VentaUnitariaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "VentaUnitaria";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "VentaUnitaria_default",
                "VentaUnitaria/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
