using System.Web.Mvc;

namespace SACC.Client.Areas.TarifaDetalle
{
    public class TarifaDetalleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "TarifaDetalle";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "TarifaDetalle_default",
                "TarifaDetalle/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
