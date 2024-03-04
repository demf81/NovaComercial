using System.Web.Mvc;

namespace SACC.Client.Areas.TarifaDetalleDesglose
{
    public class TarifaDetalleDesgloseAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "TarifaDetalleDesglose";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "TarifaDetalleDesglose_default",
                "TarifaDetalleDesglose/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
