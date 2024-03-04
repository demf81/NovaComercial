using System.Web.Mvc;

namespace SACC.Client.Areas.VentaUnitariaDetalleTipo
{
    public class VentaUnitariaDetalleTipoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "VentaUnitariaDetalleTipo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "VentaUnitariaDetalleTipo_default",
                "VentaUnitariaDetalleTipo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
