using System.Web.Mvc;

namespace SACC.Client.Areas.CotizacionTipo
{
    public class CotizacionTipoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CotizacionTipo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CotizacionTipo_default",
                "CotizacionTipo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
