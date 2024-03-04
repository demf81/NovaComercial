using System.Web.Mvc;

namespace SACC.Client.Areas.VentaUnitariaEspecial
{
    public class VentaUnitariaEspecialAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "VentaUnitariaEspecial";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "VentaUnitariaEspecial_default",
                "VentaUnitariaEspecial/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
