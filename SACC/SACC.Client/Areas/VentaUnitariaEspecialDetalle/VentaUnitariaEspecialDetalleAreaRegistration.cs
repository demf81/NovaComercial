using System.Web.Mvc;

namespace SACC.Client.Areas.VentaUnitariaEspecialDetalle
{
    public class VentaUnitariaEspecialDetalleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "VentaUnitariaEspecialDetalle";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "VentaUnitariaEspecialDetalle_default",
                "VentaUnitariaEspecialDetalle/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
