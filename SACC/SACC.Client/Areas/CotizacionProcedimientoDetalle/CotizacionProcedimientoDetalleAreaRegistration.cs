using System.Web.Mvc;

namespace SACC.Client.Areas.CotizacionProcedimientoDetalle
{
    public class CotizacionProcedimientoDetalleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CotizacionProcedimientoDetalle";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CotizacionProcedimientoDetalle_default",
                "CotizacionProcedimientoDetalle/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
