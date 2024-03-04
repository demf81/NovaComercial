using System.Web.Mvc;

namespace SACC.Client.Areas.ProcedimientoDetalle
{
    public class ProcedimientoDetalleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ProcedimientoDetalle";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ProcedimientoDetalle_default",
                "ProcedimientoDetalle/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
