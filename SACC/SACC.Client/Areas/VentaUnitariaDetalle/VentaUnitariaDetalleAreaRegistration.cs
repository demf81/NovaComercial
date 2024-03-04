using System.Web.Mvc;

namespace SACC.Client.Areas.VentaUnitariaDetalle
{
    public class VentaUnitariaDetalleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "VentaUnitariaDetalle";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "VentaUnitariaDetalle_default",
                "VentaUnitariaDetalle/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
