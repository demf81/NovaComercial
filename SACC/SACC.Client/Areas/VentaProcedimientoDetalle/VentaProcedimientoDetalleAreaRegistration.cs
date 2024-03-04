using System.Web.Mvc;

namespace SACC.Client.Areas.VentaProcedimientoDetalle
{
    public class VentaProcedimientoDetalleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "VentaProcedimientoDetalle";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "VentaProcedimientoDetalle_default",
                "VentaProcedimientoDetalle/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
